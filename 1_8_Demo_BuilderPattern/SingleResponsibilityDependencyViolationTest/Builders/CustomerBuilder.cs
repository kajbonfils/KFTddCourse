using SingleResponsibilityViolation;
using SingleResponsibilityViolation.Service;

namespace SingleResponsibilityDependencyViolationTest
{
    public class CustomerBuilder
    {
        private string cpr;
        private string firstName;
        private string lastName;
        private Address address;

        public CustomerBuilder()
        {
            cpr = "111111-1111";
            firstName = "Foo";
            lastName = "Bar";
            address = new AddressBuilder().Build();            
        }

        public Customer Build()
        {
            return new Customer(cpr, firstName, lastName, address);
        }

        public CustomerBuilder WithCpr(string cpr)
        {
            this.cpr = cpr;
            return this;
        }

        public CustomerBuilder WithFirstname(string firstname)
        {
            this.firstName = firstname;
            return this;
        }
        public CustomerBuilder WithLastname(string lastname)
        {
            this.lastName = lastname;
            return this;
        }

        public CustomerBuilder WithAddress(Address address)
        {
            this.address = address;
            return this;
        }
       
    }
}