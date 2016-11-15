using System.ComponentModel.DataAnnotations;

namespace DAL.Models
{
    public abstract class Model : IModel
    {
        [Key]
        public int Id { get; set; }
    }
}