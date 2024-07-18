using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.ModelsSchool
{
    public class Address
    {
        public int AddressId { get; set; }
        public string Street { get; set; }
        public int Number { get; set; }
        public string PostalCode { get; set; }
        public string Locale { get; set; }

        public Address() { }
        public Address(int addressId, string street, int number, string postalCode, string locale)
        {
            AddressId = addressId;
            Street = street;
            Number = number;
            PostalCode = postalCode;
            Locale = locale;
        }

        public Address(string street, int number, string postalCode, string locale)
        {
            Street = street;
            Number = number;
            PostalCode = postalCode;
            Locale = locale;
        }
    }
}
