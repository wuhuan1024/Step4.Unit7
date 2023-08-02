using System.ComponentModel.DataAnnotations;

namespace Step4.Unit7.Model;

public class BaseEntity
{
    [Key]
    public long Id { get; set; }

    public DateTime UpdatedTime { get; set; } = DateTime.Now;
    public DateTime CreatedTime { get; set; }= DateTime.Now;
    public long UpdatedUserId { get; set; }
    public long CreatedUserId { get; set; }
    public int Deleted { get; set; } = 0;
}