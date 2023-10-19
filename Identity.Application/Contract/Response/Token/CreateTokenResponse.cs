using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Identity.Application.Contract.Response.Token
{
    public class CreateTokenResponse
    {
        public string Token { get; set; }
        public DateTime ExperiDate { get; set; }
    }
}
