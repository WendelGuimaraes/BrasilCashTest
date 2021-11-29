using BrasilCashTest.Domain.Enum;
using System;

namespace BrasilCashTest.Domain.Entities
{

        public class Customer
        {
            public Guid Id { get; private set; }
            public string Name { get; private set; }
            public string TaxId { get; private set; }
            public string Password { get; private set; }
            public string PhoneNumber { get; private set; }
            public string PostalCode { get; private set; }
            public DateTime CreatedAt { get; private set; }
            public Status Status { get; private set; }
            public Address Address { get; private set; }

        public Customer(string Name, string TaxId, string Password, string PhoneNumber, string PostalCode)
            {
                this.Name = Name;
                this.TaxId = TaxId;
                this.Password = Password;
                this.PhoneNumber = PhoneNumber;
                this.PostalCode = PostalCode;


            if (!string.IsNullOrEmpty(PostalCode))
                Status = Status.aprroved;
            else
                Status = Status.Pending;
        }
        public void setAddress(Address address)
        {
            Address = address;
        }
    
        }
    }

