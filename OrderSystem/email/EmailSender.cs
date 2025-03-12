using System;
using System.IO;
using System.Net;
using System.Net.Mail;
using OrderSystem.Repository.Interface;
using OrderSystem.UserModel;
using System.Data.SqlClient;
using Dapper;
using System.Data;
using NReco.PdfGenerator;

namespace OrderSystem.email
{
    public interface IEmailSender
    {
        Task<bool> SendEmail(string recipientEmail, string subject, string body);
    }

    public class EmailSender : IEmailSender
    {
        private readonly IDRepository _dbRepository;

        public EmailSender(IDRepository dbRepository)
        {
            _dbRepository = dbRepository;
        }

        //public async Task<EmailSettingModel> GetEmailAsync()
        //{
        //    var email = await _dbRepository.QueryFirstOrDefaultAsync<EmailSettingModel>("sp_TestEmail");
        //    return email;
        //}
        public async Task<EmailSettingModel> GetEmailAsync()
        {
            //var connection = new SqlConnection("Data Source=EC2AMAZ-C9DVHUU\\SQLEXPRESS;Initial Catalog=OrderSystem;User ID=sa;Password=SoftClues@2021;Integrated Security=false;TrustServerCertificate=true;"))
            using (var connection = new SqlConnection("Data Source=192.168.29.56;Initial Catalog=OrderSystem;User ID=sa;Password=sw;Integrated Security=false;TrustServerCertificate=true;"))
            {
                await connection.OpenAsync();

                var result = await connection.QueryFirstOrDefaultAsync<EmailSettingModel>("sp_GetEmail", commandType: CommandType.StoredProcedure);

                return result;
            }
        }
    
        public async Task<bool> SendEmail(string recipientEmail, string subject, string body)
        {
            try
            {
                var email = await GetEmailAsync();

                string smtpServer = email.Smtpserver;
                int smtpPort = (int)email.Port;
                string smtpUsername = email.Email;
                string smtpPassword = email.Password;
                string fromAddress = email.Email;
                string toAddress = recipientEmail;

                using (var message = new MailMessage(fromAddress, toAddress))
                {
                    message.Subject = subject;

                    // Convert HTML to PDF using Wkhtmltopdf.NetCore
                    var pdfBytes = new HtmlToPdfConverter().GeneratePdf(body);

                    // Create a MemoryStream for the PDF content
                    MemoryStream pdfStream = new MemoryStream(pdfBytes);

                    // Create an Attachment from the MemoryStream
                    Attachment pdfAttachment = new Attachment(pdfStream, "OrderDetail.pdf", "application/pdf");

                    // Attach the PDF to the email
                    message.Attachments.Add(pdfAttachment);

                    using (var client = new SmtpClient(smtpServer, smtpPort))
                    {
                        client.EnableSsl = true;
                        client.UseDefaultCredentials = false;
                        client.Credentials = new NetworkCredential(smtpUsername, smtpPassword);

                        await client.SendMailAsync(message);
                        return true;
                    }
                }
            }
            catch (Exception ex)
            {
                // Handle the exception or log it
                return false;
            }
        }
    }
}
