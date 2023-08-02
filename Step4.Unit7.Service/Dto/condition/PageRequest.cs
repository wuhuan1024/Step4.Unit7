namespace Step4.Unit7.Service.Dto.condition;

public class PageRequest
{
    /// <summary>
    /// 页大小
    /// </summary>
    public int PageSize { get; set; } = 3;
    /// <summary>
    /// 当前页
    /// </summary>
    public int PageIndex { get; set; } = 1;

    /// <summary>
    /// 总页数
    /// </summary>
    public int Total { get; set; }
}