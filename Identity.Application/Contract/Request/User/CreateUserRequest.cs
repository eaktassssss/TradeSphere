
using Identity.Application.Contract.Response.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Identity.Application.Contract.Request.User
{
    public class CreateUserRequest
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string IdentityNumber { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string PasswordConfrim { get; set; }
        public string UserName { get; set; }


        public CreateUserResponse MapToPaylod(Identity.Domain.Entities.User user)
        {
            return new CreateUserResponse { Id=user.Id,FirstName = user.FirstName, LastName = user.LastName, IdentityNumber = user.IdentityNumber, PhoneNumber = user.PhoneNumber, Email = user.Email,UserName=user.UserName };
        }
        public Identity.Domain.Entities.User MapToEntity()
        {
            return new Domain.Entities.User()
            {
                FirstName=this.FirstName, LastName=this.LastName, IdentityNumber=this.IdentityNumber, PhoneNumber=this.PhoneNumber, Email=this.Email,UserName=this.UserName,Id=Guid.NewGuid().ToString()
            };
        }
    }
}
