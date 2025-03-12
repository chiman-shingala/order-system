using AutoMapper;
using Newtonsoft.Json;
using OrderSystem.email;
using OrderSystem.FilterClass;
using OrderSystem.Models;
using OrderSystem.Repository;
using OrderSystem.Repository.Interface;
using OrderSystem.Service.Interface;
using OrderSystem.UserModel;
using System.ComponentModel.Design;
using System.Text;

namespace OrderSystem.Service
{
    public class OrderDetailService : IOrderdetailService
    {
        private readonly IOrderDetailRepository _repository;
        private readonly IMapper _mapper;
        private readonly IDRepository _dbRepository;
        private readonly IEmailSender _emailSender;
        private readonly ICompanyMasterRepository _companyMaster;

        public OrderDetailService(IOrderDetailRepository repository, IMapper mapper, IDRepository dbRepository, IEmailSender emailSender, ICompanyMasterRepository companyMaster)
        {
            _repository = repository;
            _mapper = mapper;
            _dbRepository = dbRepository;
            _emailSender = emailSender;
            _companyMaster = companyMaster;
        }

        public async Task<List<OrderDetailGetFilter>> GetOrderDetailAsync(OrderDetailFilter user)
        {
            return await _repository.GetOrderDetailAsync(user);
        }

        public async Task<List<OrderDetail>> AddOrderDetailAsync(OrderDetailsDto user)
        {
            var record = await _repository.AddOrderDetailAsync(user);
            return _mapper.Map<List<OrderDetail>>(record);
        }

        public async Task<List<OrderDetail>> UpdateOrderDetailAsync(OrderDetailsDto user)
        {
            var record = await _repository.UpdateOrderDetailAsync(user);
            return _mapper.Map<List<OrderDetail>>(record);
        }
        public async Task<int> DeleteOrderDetailAsync(OrderDetailDeleteFilter filter)
        {
            var record = await _repository.DeleteOrderDetailAsync(filter);
            return record;
        }
        public async Task<List<TransectionNoDto>> GetTransactionNoAsync(GetTransectionNoFilter user)
        {
            return await _repository.GetTransactionNoAsync(user);
        }

        public async Task<List<PartyMastDto>> GetAllPartyAsync(int CompanyId, int AcYear)
        {
            return await _dbRepository.GetAll<PartyMastDto>("sp_Get_AllParty", new { CompanyId, AcYear });
        }
        public async Task<List<ItemMaster>> GetAllItemAsync(int CompanyId, int UserId)
        {
            return await _dbRepository.GetAll<ItemMaster>("sp_Get_ItemMaster", new { CompanyId, UserId });
        }

        public async Task<InserOrderGetFilter> AddOrderDetail(List<OrderDetailsDto> order)
        {
            var json = JsonConvert.SerializeObject(order);
            var record = await _repository.AddOrderDetail(json);

            var CompanyId = order[0].CompanyId;
            var AcYear = order[0].AcYear;
            var PartyCode = order[0].PartyCode;

            var partyList = await GetAllPartyAsync(CompanyId, AcYear);
            var email = partyList.FirstOrDefault(p => p.PartyCode == PartyCode)?.Email;
            var companyData = await _companyMaster.GetAllCompanyMasterAsync();

            var company = companyData.FirstOrDefault(c => c.CompanyId == CompanyId);
            var isInvoice = company?.IsInvoice ?? false;
            if (record != null && isInvoice)
            {
                var emailBody = await CreateOrderDetailsTable(order, record);
                _emailSender.SendEmail(email, "Insert Order", emailBody);
            }
            return record;
        }
        private async Task<string> CreateOrderDetailsTable(List<OrderDetailsDto> order, InserOrderGetFilter record)
        {
            var sb = new StringBuilder();
            sb.AppendLine("<html><head><style>");
            sb.AppendLine("body {font-family: Arial, sans-serif;font-size: 14px;}");
            sb.AppendLine("table {border-collapse: collapse; width: 100%;margin-bottom: 20px;}");
            sb.AppendLine("th, td {border: 1px solid #ddd; padding: 8px;}");
            sb.AppendLine("th{background-color: #f2f2f2;}");
            sb.AppendLine(".invoice-header{text-align: center; margin-bottom: 20px;}");
            sb.AppendLine(".invoice-number{font-size: 18px;font-weight: bold;}");
            sb.AppendLine(".invoice-details{margin-bottom: 20px;}");
            sb.AppendLine(".main_div{width:50%;border:1px solid black;padding:20px;}");
            sb.AppendLine(".payment-info {margin-top: 20px;}");
            sb.AppendLine(" @media (max-width: 600px) {table {width: 100%;}.main_div{width:95%;}}");
            sb.AppendLine("</style></head><body>" +
                          "<div class='main_div'> ");

            sb.AppendLine("<div class='invoice-details'>" +
                          "<h2 style='text-align: center;'>Invoice</h2>");
            sb.AppendLine($"<p><span>Invoice Number:- </span>{record.InvoiceNo}</p>");
            sb.AppendLine($"<p><span>Date:- </span>{record.TrnDate.ToString("dd-MM-yyyy")}</p>");

            sb.AppendLine("<div class='table-responsive'>");
            sb.AppendLine("<table>");
            sb.AppendLine("<tr>" +
                          "<th>Item Name</th>" +
                          "<th>Qty</th>" +
                          "<th>Rate</th>" +
                          "<th>Amount</th>" +
                          "</tr>");

            decimal totalQuantity = 0;
            decimal totalRate = 0;
            decimal totalAmount = 0;
            var itemList = await GetAllItemAsync(order[0].CompanyId, order[0].UserId);
            foreach (var item in order)
            {
                var itemName = itemList.FirstOrDefault(i => i.ItemId == item.ItemId)?.ItemName;

                sb.AppendLine("<tr>");
                sb.AppendLine($"<td>{itemName}</td>");
                sb.AppendLine($"<td style='text-align:right;'>{item.Pcs}</td>");
                sb.AppendLine($"<td style='text-align:right;'>{item.Rate}</td>");
                sb.AppendLine($"<td style='text-align:right;'>{item.Amount}</td>");
                sb.AppendLine("</tr>");

                totalQuantity += item.Pcs;
                totalRate += item.Rate;
                totalAmount += item.Amount;
            }

            sb.AppendLine("<tr>");
            sb.AppendLine("<td style='font-weight:bold;'>Total</td>");
            sb.AppendLine($"<td style='font-weight:bold; text-align:right;'>{totalQuantity}</td>");
            sb.AppendLine($"<td style='font-weight:bold; text-align:right;'>{totalRate}</td>");
            sb.AppendLine($"<td style='font-weight:bold; text-align:right;'>{totalAmount}</td>");
            sb.AppendLine("</tr>");
            sb.AppendLine("</table>");
            sb.AppendLine("</div>");

            sb.AppendLine("<div class='payment-info'>");
            sb.AppendLine($"<p><span>Payment Due By:- </span>{record.PaymentDate.ToString("dd-MM-yyyy")}</p>");
            sb.AppendLine("<p>Thank you for your business!</p>");

            sb.AppendLine("</div>");
            sb.AppendLine("</div></body></html>");

            return sb.ToString();
        }


        public async Task<List<GetOrderDetailsFromTrnNo>> GetOrderDetailsFromTrnNoAsync(OrderDetailsFromTrnNoParaFilter user)
        {
            return await _repository.GetOrderDetailsFromTrnNoAsync(user);
        }
        public async Task<int> OrderConfirmedAsync(OrderConfirmedDto order)
        {
            return await _repository.OrderConfirmedAsync(order);
        }
        public async Task<int> OrderDetailOrderConfirmedAsync(OrderDetailOrderConfirmedPara order)
        {
            return await _repository.OrderDetailOrderConfirmedAsync(order);
        }
        public async Task<int> OrderMasterOrderDispatchedAsync(OrderMasterOrderDispatchedPara order)
        {
            return await _repository.OrderMasterOrderDispatchedAsync(order);
        }
        public async Task<int> OrderDetailOrderDispatchedAsync(OrderDetailOrderDispatchedPara order)
        {
            return await _repository.OrderDetailOrderDispatchedAsync(order);
        }

        public async Task<int> OrderDetailOrderReceivedAsync(OrderDetailOrderReceivedPara order)
        {
            return await _repository.OrderDetailOrderReceivedAsync(order);
        }
        public async Task<int> OrderMasterOrderReceivedAsync(OrderMasterOrderReceivedPara order)
        {
            return await _repository.OrderMasterOrderReceivedAsync(order);
        }
        public async Task<List<OrderMasterGetFilter>> GetOrderMasterDeatilsAsync(OrderMasterFilter filter)
        {
            var record = await _repository.GetOrderMasterDetailsAsync(filter);
            return record;
        }
        public async Task<List<GetTotalOrder>> GetTotalOrderAsync(TotalOrderDto total)
        {
            return await _repository.GetTotalOrderAsync(total);
        }
        public async Task<int> OrderMasterOrderReturnAsync(OrderMasterOrderReturnPara order)
        {
            return await _repository.OrderMasterOrderReturnAsync(order);
        }
        public async Task<int> OrderDetailOrderReturnAsync(OrderDetailOrderReturnPara order)
        {
            return await _repository.OrderDetailOrderReturnAsync(order);
        }
    }
}
