namespace SingleResponsibilityViolation
{
    public class Customer
    {
        private readonly string cprNummer;
        private readonly string firstName;
        private readonly string lastName;
        private readonly Address address;


        public Customer(string cprNummer, string firstName, string lastName, Address address)
        {
            this.cprNummer = cprNummer;
            this.firstName = firstName;
            this.lastName = lastName;
            this.address = address;
        }

        public string CprNummer
        {
            get { return cprNummer; }
        }

        public string FirstName
        {
            get { return firstName; }
        }

        public string LastName
        {
            get { return lastName; }
        }

        public Address Address
        {
            get { return address; }
        }
    }
}