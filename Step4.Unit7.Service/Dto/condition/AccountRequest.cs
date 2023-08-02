using Step4.Unit7.Model;

namespace Step4.Unit7.Service.Dto.condition;

/// <summary>
/// 案件搜索条件
/// </summary>
public class AccountRequest:PageRequest
{
    /// <summary>
    /// 债务人名称
    /// </summary>
    public string? DebtorName { get; set; }
    /// <summary>
    /// 银行名称
    /// </summary>
    public string? BankName { get; set; }
    /// <summary>
    /// 当前案件状态
    /// </summary>
    public AccountStateEnum? AccountState { get; set; }
}