namespace BrasilCashTest.Domain.Entities
{

        public class Customer
        {
            public string Name { get; private set; }
            public string TaxId { get; private set; }
            public string Password { get; private set; }
            public string PhoneNumber { get; private set; }
            public string PostalCode { get; private set; }
            public string Status { get; private set; }

            public Customer(string Name, string TaxId, string Password, string PhoneNumber, string PostalCode)
            {
                this.Name = Name;
                this.TaxId = TaxId;
                this.Password = Password;
                this.PhoneNumber = PhoneNumber;
                this.PostalCode = PostalCode;

                if (PostalCode != null)
                {
                    Status = "Pending";
                }
                else
                {
                    Status = "Approved";
            }
            }
        }
    }

