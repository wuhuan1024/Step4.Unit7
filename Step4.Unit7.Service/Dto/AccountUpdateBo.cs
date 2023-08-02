using System.ComponentModel.DataAnnotations;
using Step4.Unit7.Model;

namespace Step4.Unit7.Service.Dto;

public class AccountUpdateBo
{
    public long Id { get; set; }
    [Display(Name = "状态")]
    [Required(ErrorMessage = "请选择案件状态")]
    public AccountStateEnum AccountState { get; set; }
      
    [Display(Name = "业务员")]
    [Required(ErrorMessage = "请输入业务员姓名")]
    public string? SaleMan { get; set; }
}