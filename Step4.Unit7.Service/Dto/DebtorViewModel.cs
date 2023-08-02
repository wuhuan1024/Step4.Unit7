namespace Step4.Unit7.Service.Dto;

public class DebtorViewModel
{
    public long Id { get; set; }
    // <summary>
    /// 姓名
    /// </summary>
    public String? NickName { get; set; }
    /// <summary>
    /// 身份证
    /// </summary>
    public string? IdCard { get; set; }
    /// <summary>
    /// 家庭地址
    /// </summary>
    public String? HomeAddress { get; set; }
    /// <summary>
    /// 手机号
    /// </summary>
    public string? Phone { get; set; }
    /// <summary>
    /// 欠款总金额
    /// </summary>
    public int? TotalDebtorMoney { get; set; }
    /// <summary>
    /// 性别
    /// </summary>
    public string? Gender { get; set; }
}