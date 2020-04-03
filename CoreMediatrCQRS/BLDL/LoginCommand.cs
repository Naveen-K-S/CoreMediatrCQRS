using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLDL
{
    public class LoginCommand : IRequest<bool>
    {
       
        public string UserName { get; set; }

        
        public string Password { get; set; }

       
        public bool RememberMe { get; set; }
    }
}
