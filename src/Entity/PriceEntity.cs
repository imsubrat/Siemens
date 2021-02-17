using System.ComponentModel.DataAnnotations;

namespace Siemens.Entity
{
    public class Discount
    {
        public int id {get;set;}
        public UserType userType {get;set;}
        public int discount {get;set;}
    }
}