using OrderSystem.FilterClass;
using OrderSystem.Models;
using OrderSystem.Repository.Interface;
using OrderSystem.UserModel;

namespace OrderSystem.Repository
{
    public class ItemMasterRepository : IItemMasterRepository
    {
        private readonly IDRepository _dbRepository;
        public ItemMasterRepository(IDRepository dbRepository)
        {
            _dbRepository = dbRepository;
        }

        public async Task<List<ItemMaster>> GetAllItemAsync(int CompanyId,int UserId)
        {
           return await _dbRepository.GetAll<ItemMaster>("sp_Get_ItemMaster", new { CompanyId , UserId });
        }
        public async Task<List<ItemsDto>> GetItemsByCompanyId(int CompanyId)
        {
            return await _dbRepository.GetAll<ItemsDto>("sp_Get_ItemsByCompanyId",new { CompanyId });
        }
        public async Task<int> AddItemAsync(ItemMasterDto user)
        {
            return await _dbRepository.ExecuteAsyncQuery("sp_InsertUpdate_ItemMaster", user);
        }
        public async Task<int> UpdateItemAsync(ItemMasterDto user)
        {
            return await _dbRepository.ExecuteAsyncQuery("sp_InsertUpdate_ItemMaster", user);
        }
        public async Task<int> DeleteItemAsync(int itemId)
        {
            return await _dbRepository.ExecuteAsyncQuery("sp_Delete_ItemMaster", new {itemId});
        }
        public async Task<List<TopItemDto>> GetTopItemAsync(ItemDto user)
        {
            return await _dbRepository.GetAll<TopItemDto>("sp_GetTopItems", user);
        }
    }
}
