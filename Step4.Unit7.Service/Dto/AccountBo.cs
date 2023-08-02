using System.ComponentModel.DataAnnotations;
namespace Step4.Unit7.Service.Dto;

public class AccountBo
{
    
    /// <summary>
    /// 债务人
    /// </summary>
    [Required(ErrorMessage = "请选择债务人")]
    [Display(Name = "债务人")]
    public long? DebtorId { get; set; }
    
    /// <summary>
    /// 银行名称
    /// </summary>
    [Required(ErrorMessage = "请输入银行名称")]
    [Display(Name = "银行名称")]
    public string? BankName { get; set; }
  
    /// <summary>
    /// 业务员
    /// </summary>
    [Display(Name = "业务员")]
    [Required(ErrorMessage = "请输入业务员姓名")]
    public string? SaleMan { get; set; }
    
    /// <summary>
    /// 欠款金额
    /// </summary>
    [Display(Name = "欠款金额")]
    [Required(ErrorMessage = "请输入欠款金额")]
    [Range(1,int.MaxValue,ErrorMessage = "必须输入整数")]
    public int DebtorMoney { get; set; }
}