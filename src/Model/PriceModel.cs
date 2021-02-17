using System.ComponentModel.DataAnnotations;

namespace Siemens.Model
{
    public class PriceModel
    {
        [Required]
        public double pricePerGm { get; set; }

        [Required]
        public double weight { get; set; }
        public Entity.UserType userType {get;set;}
        public double total{get;set;}
    }
}