namespace EcoStep.Domain.Models;
public class Image : BaseModel
{
    public int? UserId { get; set; }

    public List<string>? ImageUrl { get; set; }

    public virtual User? User { get; set; } = default!;
}