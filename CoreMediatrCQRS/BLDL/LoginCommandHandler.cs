using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BLDL
{
    public class LoginCommandHandler : IRequestHandler<LoginCommand, bool>
    {


        //public async Task<LoginCommandResult> Handle(LoginCommand request, CancellationToken cancellationToken)
        //{

        //        return new LoginCommandResult() { IsSuccess = false };

        //}
        public  Task<bool> Handle(LoginCommand request, CancellationToken cancellationToken)
        {
             bool res;
            var d =  new  LoginCommandResult() { IsSuccess = false };
            res = true;
            return Task.FromResult(res);
        }
    }
}
