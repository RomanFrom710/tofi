using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace TOFI.TransferObjects.Client.Enums
{
    public enum Sex // https://www.youtube.com/watch?v=lQlIhraqL7o
    {
        [Display(Name = "Женский")]
        Female,
        [Display(Name = "Мужской")]
        Male
    }
}
