using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Identity.Application.Contract.Response.User
{
    public class GetSingleUserResponse
    {
        public string Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string IdentityNumber { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string UserName { get; set; }
        public string PasswordHash { get; set; }

        public GetSingleUserResponse MapToPaylod(Identity.Domain.Entities.User user)
        {
            GetSingleUserResponse getSingleUserResponse = new GetSingleUserResponse();

            getSingleUserResponse.Id = user.Id;
            getSingleUserResponse.FirstName = user.FirstName;
            getSingleUserResponse.LastName = user.LastName;
            getSingleUserResponse.IdentityNumber = user.IdentityNumber;
            getSingleUserResponse.PhoneNumber = user.PhoneNumber;
            getSingleUserResponse.Email = user.Email;
            getSingleUserResponse.UserName = user.UserName;
            getSingleUserResponse.PasswordHash = user.PasswordHash;
            return getSingleUserResponse;
        }
    }
}
