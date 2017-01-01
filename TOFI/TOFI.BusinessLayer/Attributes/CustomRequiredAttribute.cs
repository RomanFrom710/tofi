using System.ComponentModel.DataAnnotations;

namespace BLL.Attributes
{
    public class CustomRequiredAttribute: RequiredAttribute
    {
        public CustomRequiredAttribute()
        {
            ErrorMessage = "{0} — обязательное поле.";
        }
    }
}