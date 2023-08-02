using AutoMapper;
using Snowflake;
using Step4.Unit7.Model;
using Step4.Unit7.Service.Dto;
using Step4.Unit7.Service.Dto.condition;
using Step4.Unit7.Service.utils;
using Step4.Unit7.Service.utils.Snowflake;

namespace Step4.Unit7.Service;

public class AccountService : IAccountService
{
    private readonly StepDbContext _context;
    private readonly IMapper _mapper;
    private IdWorker _idWorker;

    public AccountService(StepDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
        _idWorker = SnowflakeUtil.CreateIdWorker();
    }

    public List<AccountViewModel> Search(AccountRequest? request)
    {
        var accounts = from a in _context.Accounts
            join d in _context.Debtors on a.DebtorId equals d.Id into abtemp
            from abJoin in abtemp.DefaultIfEmpty()
            select new AccountViewModel
            {
                Id = a.Id,
                AccountState = a.AccountState.ToDescription(),
                State = (int)a.AccountState,
                BankName = a.BankName,
                DebtorId = a.DebtorId,
                SaleMan = a.SaleMan,
                UpdatedTime = a.UpdatedTime,
                DebtorMoney = a.DebtorMoney,
                DebtorName = abJoin.NickName,
                IdCard = abJoin.IdCard,
                Phone = abJoin.Phone,
                Deleted = a.Deleted
            };
        //过滤掉已经删除的数据
        accounts = accounts.Where(p => p.Deleted == 0);
        if (!string.IsNullOrEmpty(request.BankName))
        {
            accounts = accounts.Where(p => p.BankName.Contains(request.BankName));
        }

        if (!string.IsNullOrEmpty(request.DebtorName))
        {
            accounts = accounts.Where(p => p.DebtorName.Contains(request.DebtorName));
        }

        if (request.AccountState != null)
        {
            accounts = accounts.Where(p => p.State == (int)request.AccountState);
        }


        request.Total = accounts.Count();
        return accounts.OrderByDescending(p => p.Id).Skip((request.PageIndex - 1) * request.PageSize)
            .Take(request.PageSize).ToList();
    }

    public void Add(AccountBo bo)
    {
        var account = _mapper.Map<Account>(bo);
        account.Id = _idWorker.NextId();
        account.AccountState = AccountStateEnum.Wait;
        _context.Accounts.Add(account);
        _context.SaveChanges();
    }

    public void Update(AccountUpdateBo bo)
    {
        var entity = _context.Accounts.FirstOrDefault(p => p.Id == bo.Id);
        entity.AccountState = bo.AccountState;
        entity.SaleMan = bo.SaleMan;
        entity.UpdatedTime = DateTime.Now;
        _context.SaveChanges();
    }

    public AccountUpdateBo GetModel(long id)
    {
        return _mapper.Map<AccountUpdateBo>(_context.Accounts.FirstOrDefault(p => p.Id == id));
    }

    public void Delete(long id)
    {
        //真删除
        // _context.Accounts.Remove(_context.Accounts.FirstOrDefault(p => p.Id == id));
        // _context.SaveChanges();

        //假删除
        var entity = _context.Accounts.FirstOrDefault(p => p.Id == id);
        entity.Deleted = 1;
        entity.UpdatedTime = DateTime.Now;
        _context.SaveChanges();
    }

    public List<DebtorViewModel> GetDebtor()
    {
        return _mapper.Map<List<DebtorViewModel>>(_context.Debtors.ToList());
    }
}