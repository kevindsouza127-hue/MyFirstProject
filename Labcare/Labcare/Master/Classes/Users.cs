using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Labcare.Master.Classes
{
    public class Users
    {
        [Key]
        public int Id { get; set; }
        public string Userid { get; set;}
        public  string Password { get; set; }
        public int UID { get; set;  }
        public int processat { get; set; }
        public  string LicenceNo { get; set; }
        public string valid { get; set;}
        public string compname { get; set; }

        
    }



    

}
