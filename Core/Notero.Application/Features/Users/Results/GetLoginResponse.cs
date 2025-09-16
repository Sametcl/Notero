using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Notero.Application.Features.Users.Results
{
    public class GetLoginResponse
    {
        public string Token { get; set; }
        public DateTime ExpirationTime { get; set; }
    }
}
