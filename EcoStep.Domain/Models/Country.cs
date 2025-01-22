namespace EcoStep.Domain.Models;

public class Country : BaseModel
{
    public string CountryName { get; set; } = default!;

    #region Navigation Properties

    public virtual List<Province>? Province { get; set; }
    public virtual List<User>? User { get; set; }

    #endregion

}