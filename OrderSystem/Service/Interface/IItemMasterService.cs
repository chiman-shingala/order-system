using OrderSystem.FilterClass;
using OrderSystem.Models;
using OrderSystem.UserModel;

namespace OrderSystem.Service.Interface
{
    public interface IItemMasterService
    {
        Task<List<ItemMaster>> GetAllItemAsync(int CompanyId,int UserId);
        Task<List<ItemsDto>> GetItemsByCompanyId(int CompanyId);
        Task<int> AddItemAsync(ItemMasterDto item, IFormFile file);
        Task<int> UpdateItemAsync(ItemMasterDto item, IFormFile file, string OldImageName);
        Task<int> DeleteItemAsync(int itemId,string OldImageName);
        Task<List<TopItemDto>> GetTopItemAsync(ItemDto user);
    }
}
