using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace Step4.Unit7.Model;

/// <summary>
/// 银行案件
/// </summary>
[Table("Account")]
public class Account:BaseEntity
{
    /// <summary>
    /// 债务人
    /// </summary>
    public long DebtorId { get; set; }
    /// <summary>
    /// 银行名称
    /// </summary>
    public string? BankName { get; set; }
    /// <summary>
    /// 当前案件状态
    /// </summary>
    public AccountStateEnum AccountState { get; set; }
    /// <summary>
    /// 业务员
    /// </summary>
    public string? SaleMan { get; set; }
    /// <summary>
    /// 欠款金额
    /// </summary>
    public int DebtorMoney { get; set; }
}

/// <summary>
/// 案件状态
/// </summary>
public enum AccountStateEnum
{
    [Description("等待还款")]
    Wait,
    [Description("已还部分")]
    Partial,
    [Description("禁止催收")]
    Forbid,
    [Description("已完结")]
    Finish
}