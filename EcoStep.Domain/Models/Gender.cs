namespace EcoStep.Domain.Models;

public class Gender : BaseModel
{
    public string GenderName { get; set; } = default!;

    #region Navitation Properties

    public virtual List<User>? User { get; set; }


    #endregion
}