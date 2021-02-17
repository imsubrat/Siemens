using System.ComponentModel.DataAnnotations;

namespace Siemens.Entity
{
    public class User
    {
        public int id { get; set; }
        public string username { get; set; }
        public string password{get;set;}
        public UserType userType {get;set;}
    }

    public enum UserType
    {
        Normal,
        Priviledge
    }
}