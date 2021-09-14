using SingleResponsibilityViolation;

namespace SingleResponsibilityDependencyViolationTest
{
    public class AddressBuilder
    {
        private string street;
        private int streetnumber;
        private int zipcode;
        private string city;

        public AddressBuilder()
        {
            street = "Boulevard de la bastille";
            streetnumber = 111;
            zipcode = 1235;
            city = "Paris";
        }

        public Address Build()
        {
            return new Address(street, streetnumber, zipcode, city);
        }
        public AddressBuilder WithStreet(string street)
        {
            this.street = street;
            return this;
        }
        public AddressBuilder WithStreetNumber(int streetnumber)
        {
            this.streetnumber = streetnumber;
            return this;
        }

        public AddressBuilder WithZipCode(int zipcode)
        {
            this.zipcode = zipcode;
            return this;
        }

        public AddressBuilder WithCity(string city)
        {
            this.city = city;
            return this;
        }
    }
}