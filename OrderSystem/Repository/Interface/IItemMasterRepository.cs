using OrderSystem.FilterClass;
using OrderSystem.Models;
using OrderSystem.UserModel;

namespace OrderSystem.Repository.Interface
{
    public interface IItemMasterRepository
    {
        Task<List<ItemMaster>> GetAllItemAsync(int CompanyId,int UserId);
        Task<List<ItemsDto>> GetItemsByCompanyId(int CompanyId);
        Task<int> AddItemAsync(ItemMasterDto user);
        Task<int> UpdateItemAsync(ItemMasterDto user);
        Task<int> DeleteItemAsync(int itemId);
        Task<List<TopItemDto>> GetTopItemAsync(ItemDto user);
    }
}
