using System.ComponentModel.DataAnnotations;

namespace DAL.Models
{
    public class Model : IModel
    {
        [Key]
        public int Id { get; set; }
    }
}