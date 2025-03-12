using AutoMapper;
using OrderSystem.FilterClass;
using OrderSystem.Models;
using OrderSystem.Repository.Interface;
using OrderSystem.Service.Interface;
using OrderSystem.UserModel;

namespace OrderSystem.Service
{
    public class ItemMasterService : IItemMasterService
    {
        private readonly IItemMasterRepository _repository;
        private readonly IMapper _mapper;
        private readonly IWebHostEnvironment _hostingEnvironment;

        public ItemMasterService(IItemMasterRepository repository, IMapper mapper, IWebHostEnvironment hostingEnvironment)
        {
            _repository = repository;
            _mapper = mapper;
            _hostingEnvironment = hostingEnvironment;
        }

        public async Task<List<ItemMaster>> GetAllItemAsync(int CompanyId,int UserId)
        {
            var records = await _repository.GetAllItemAsync(CompanyId,UserId);
            return _mapper.Map<List<ItemMaster>>(records);
        }
        public async Task<List<ItemsDto>> GetItemsByCompanyId(int CompanyId)
        {
            var records = await _repository.GetItemsByCompanyId(CompanyId);
            return _mapper.Map<List<ItemsDto>>(records);
        }
        public async Task<int> AddItemAsync(ItemMasterDto item, IFormFile file)
        {
            string contentRootPath = _hostingEnvironment.ContentRootPath;
            string fileName = System.IO.Path.Combine(DateTime.Now.ToString("yyyyMMddHHmmss") + System.IO.Path.GetExtension(file.FileName));
            item.ItemImage = fileName;
            var record = await _repository.AddItemAsync(item);
            string path = Path.Combine(contentRootPath, "Images");
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
            string filePath = Path.Combine(path, fileName);
            using (Stream fileStream = new FileStream(filePath, FileMode.Create))
            {
                await file.CopyToAsync(fileStream);
            }
            return record;
        }
        public async Task<int> UpdateItemAsync(ItemMasterDto item, IFormFile file,string OldImageName)
        {
            if (file != null)
            {
                string contentRootPath = _hostingEnvironment.ContentRootPath;
                string fileName = System.IO.Path.Combine(DateTime.Now.ToString("yyyyMMddHHmmss") + System.IO.Path.GetExtension(file.FileName));
                item.ItemImage = fileName;
                string oldFilePath = Path.Combine(contentRootPath, "Images", OldImageName);
                if (File.Exists(oldFilePath))
                {
                    File.Delete(oldFilePath);
                }
                string path = Path.Combine(contentRootPath, "Images");
                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }
                string filePath = Path.Combine(path, fileName);
                using (Stream fileStream = new FileStream(filePath, FileMode.Create))
                {
                    await file.CopyToAsync(fileStream);
                }
            }
            else
            {
                item.ItemImage = OldImageName; 
            }
            return await _repository.UpdateItemAsync(item);
        }
        public async Task<int> DeleteItemAsync(int itemId,string OldImageName)
        {
            var record = await _repository.DeleteItemAsync(itemId);
            string contentRootPath = _hostingEnvironment.ContentRootPath;
            string path = Path.Combine(contentRootPath,"Images", OldImageName);
            if (System.IO.File.Exists(path))
            {
                System.IO.File.Delete(path);
            }
            return record;
        }
        public async Task<List<TopItemDto>> GetTopItemAsync(ItemDto user)
        {
            var record = await _repository.GetTopItemAsync(user);
            return record;
        }
    }
}
