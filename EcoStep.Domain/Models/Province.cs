namespace EcoStep.Domain.Models;

public class  Province :  BaseModel
{
    public string ProvinceName { get; set; } = default!;
    public int CountryId { get; set; }

    #region Navigation Properties

    public virtual Country? Country { get; set; }
    public virtual List<User>? User { get; set; }

    #endregion

}