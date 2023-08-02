using Step4.Unit7.Service.Dto;
using Step4.Unit7.Service.Dto.condition;

namespace Step4.Unit7.Service;

public interface IAccountService
{
    List<AccountViewModel> Search(AccountRequest? request);
    void Add(AccountBo bo);
    void Update(AccountUpdateBo bo);
    AccountUpdateBo GetModel(long id);
    void Delete(long id);
    
    List<DebtorViewModel> GetDebtor();
}