namespace CustomerService.Application.Contract.Response.Customer
{
    public class GetSingleCustomerResponse
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime JoiningDate { get; set; }
        public DateTime CreatedOn { get; set; }
    }
}
