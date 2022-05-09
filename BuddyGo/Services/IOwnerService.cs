using BuddyGo.DTOs.Owner;
using BuddyGo.Models;

namespace BuddyGo.Services {
    public interface IOwnerService : IGenericUserService<Owner, OwnerDTO, OwnerCreateDTO, OwnerUpdateDTO, OwnerLoginDTO> {
        //public Task<OwnerDTO> Create(OwnerCreateDTO owner);

        //public Task<OwnerDTO> GetById(string id);
        //public Task<OwnerDTO> GetByLogin(OwnerLoginDTO ownerLoginDTO);

        //public IEnumerable<OwnerDTO> GetAll();
        //public Task<bool> Update(string id, OwnerUpdateDTO owner);

        //public Task<bool> Delete(string id);
    }
}
