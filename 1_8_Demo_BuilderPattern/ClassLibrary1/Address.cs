namespace SingleResponsibilityViolation
{
    public class Address
    {
        private readonly string street;
        private readonly int streetnumber;
        private readonly int zipcode;
        private readonly string city;
        public Address(string street, int streetnumber, int zipcode, string city)
        {
            this.street = street;
            this.streetnumber = streetnumber;
            this.zipcode = zipcode;
            this.city = city;
        }
        public string Street
        {
            get { return street; }
        }

        public int Streetnumber
        {
            get { return streetnumber; }
        }

        public int Zipcode
        {
            get { return zipcode; }
        }

        public string City
        {
            get { return city; }
        }
    }
}