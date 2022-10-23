using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPM_2310.Models
{
    public class Phone
    {
        public string Name { get; set; }
        public string PhoneNumber { get; set;}
        public Phone(string name, string phoneNumber)
        {
            Name = name;
            PhoneNumber = phoneNumber;
        }
    }
}
