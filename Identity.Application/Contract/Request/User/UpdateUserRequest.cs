using Identity.Application.Contract.Response.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Identity.Application.Contract.Request.User
{
    public class UpdateUserRequest
    {
        public string Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string IdentityNumber { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string UserName { get; set; }
        public UpdateUserResponse MapToPaylod(Identity.Domain.Entities.User user)
        {
            return new UpdateUserResponse { UserName = user.UserName, Id = user.Id, FirstName = user.FirstName, LastName = user.LastName, IdentityNumber = user.IdentityNumber, PhoneNumber = user.PhoneNumber, Email = user.Email };
        }
        public Identity.Domain.Entities.User MapToEntity()
        {
            return new Domain.Entities.User()
            {
                Id = this.Id,
                FirstName = this.FirstName,
                LastName = this.LastName,
                IdentityNumber = this.IdentityNumber,
                PhoneNumber = this.PhoneNumber,
                Email = this.Email,
                UserName = this.UserName,
            };
        }


        public Identity.Domain.Entities.User MapToEntity(Identity.Domain.Entities.User user)
        {
            user.Id = this.Id;
            user.FirstName = this.FirstName;
            user.LastName = this.LastName;
            user.IdentityNumber = this.IdentityNumber;
            user.PhoneNumber = this.PhoneNumber;
            user.Email = this.Email;
            user.UserName = this.UserName;
            return user;
        }
    }
}
