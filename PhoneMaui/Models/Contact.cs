using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneMaui.Models  
{
    public interface IContact
    {
        string FirstName { get; set; }
        string LastName { get; set; }
        string Email { get; set; }
        int PhoneNumber { get; set; }
        
    }



    public class Contact : IContact
    {
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public string Email { get; set; } = null!;
        public int PhoneNumber { get; set; }
    }

}
