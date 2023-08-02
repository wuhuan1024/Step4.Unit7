using AutoMapper;
using Step4.Unit7.Model;
using Step4.Unit7.Service.Dto;

namespace Step4.Unit7.Service.Profiles;

public class AccountProfile : Profile
{
    public AccountProfile()
    {
        CreateMap<AccountBo, Account>();
        CreateMap<Account, AccountUpdateBo>();
        CreateMap<Debtor, DebtorViewModel>();
      
    }
}