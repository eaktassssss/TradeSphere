using CustomerService.Application.Contract.Response.Customer;

namespace CustomerService.Application.Contract.Request.Customer
{
    public class CreateCustomerRequest
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime JoiningDate { get; set; }
        public CreateCustomerResponse MapToPaylod(Domain.Entities.Customer customer)
        {
            return new CreateCustomerResponse { Id = customer.Id, FirstName = customer.FirstName, LastName = customer.LastName, JoiningDate = customer.JoiningDate, CreatedOn = customer.CreatedOn };
        }
        public Domain.Entities.Customer MapToEntity()
        {
            return new CustomerService.Domain.Entities.Customer()
            {
                LastName = LastName,
                JoiningDate = JoiningDate,
                FirstName = FirstName
            };

        }

    }
}
