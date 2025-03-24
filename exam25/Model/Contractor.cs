using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exam25
{
    public class Contractor
    {
        public long Id { get; set; }
        public ContractorType? Type { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string INN { get; set; }
        public string Person { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public int Rating { get; set; }
        public string? Safety { get; set; }

        public Contractor(long id, ContractorType? type, string name, string address, string inn, string person, string phone, string email, int rating, string? safety)
        {
            Id = id;
            Type = type;
            Name = name;
            Address = address;
            INN = inn;
            Person = person;
            Phone = phone;
            Email = email;
            Rating = rating;
            Safety = safety;
        }
    }
}
