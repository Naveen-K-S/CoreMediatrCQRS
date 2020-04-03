using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ClassLibrary1.Men.Visit;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CoreMediatrCQRS.Controllers
{
    [ApiController]
    public class MenController : ControllerBase
    {
        private readonly IMediator _mediator;
        public MenController(IMediator mediator)
        {
            _mediator = mediator;
        }


        [HttpPost]
        [Route("api/Visit")]
        public async Task<IActionResult> Visit(FirstVisit.BoyFriend boyFriend)
        {
            var result = await _mediator.Send(boyFriend);
            return Ok(result);
        }

    }
}