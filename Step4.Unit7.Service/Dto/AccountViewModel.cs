namespace Step4.Unit7.Service.Dto;

public class AccountViewModel
{
     public long Id { get; set; }
    
    
    /// <summary>
    /// 债务人
    /// </summary>
    public long DebtorId { get; set; }
    public string? DebtorName { get; set; }
    public string? IdCard { get; set; }
    public string? Phone { get; set; }
    
    /// <summary>
    /// 银行名称
    /// </summary>
    public string? BankName { get; set; }

    /// <summary>
    /// 当前案件状态(值) 数据库中的植
    /// </summary>
    public int State { get; set; }
    
    /// <summary>
    /// 当前案件状态(要显示的中文)
    /// </summary>
    public String? AccountState { get; set; }
    /// <summary>
    /// 业务员
    /// </summary>
    public string? SaleMan { get; set; }
    /// <summary>
    /// 欠款金额
    /// </summary>
    public int DebtorMoney { get; set; }
    
    public DateTime UpdatedTime { get; set; }
    public int Deleted { get; set; }
}