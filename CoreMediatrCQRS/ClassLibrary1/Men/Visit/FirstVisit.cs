//using ClassLibrary1.LoginCommandFolder;
using FluentValidation;
using MediatR;
using MediatR.Pipeline;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ClassLibrary1.Men.Visit
{
    public class FirstVisit
    {

        #region BoyfriendDetails
        public class BoyFriend : IRequest<bool>
        {
            public string FirstName { get; set; }

            public string LastName { get; set; }

            public string Birthday { get; set; }
        }

        #endregion

        #region FriendDetails

        public class Friend : INotification
        {
            public string FirstName { get; set; }

            public string LastName { get; set; }
        }

        #endregion

        #region RuleTobeGetIntoCab

        public class RuleTobeGetIntoCab : AbstractValidator<BoyFriend>
        {
            public RuleTobeGetIntoCab()
            {
                RuleFor(x => x.FirstName).NotEmpty().Length(0, 10);
                RuleFor(x => x.LastName).NotEmpty().Length(0, 5);
            }
        }

        #endregion

        #region IsHeYourDriver
        public class CheckIfHeisYourDriver<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
        {
            private readonly IEnumerable<IValidator<TRequest>> _validators;

            public CheckIfHeisYourDriver(IEnumerable<IValidator<TRequest>> validators)
            {
                _validators = validators;
            }

            public async Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken, RequestHandlerDelegate<TResponse> next)
            {
                var context = new ValidationContext(request);

                var failures =
                    _validators.Select(v => v.Validate(context)).SelectMany(r => r.Errors).Where(f => f != null).ToList();

                if (failures.Any())
                {
                    // Leave that guy he is not your asset
                }
                return await next();
            }

        }

        #endregion

        #region PurchaseFancyDress
        public class PurchaseDress<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
        {
            public async Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken, RequestHandlerDelegate<TResponse> next)
            {
                // take dress of choice
                return await next();
            }

        }

        #endregion

        #region PurchaseGoodGift
        public class PurchaseGift<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
        {
            public async Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken, RequestHandlerDelegate<TResponse> next)
            {
                // take gift of choice
                return await next();
            }

        }

        #endregion

        #region MeetGF
        public class TimeToMeetGF : IRequestHandler<BoyFriend, bool>
        {
           
            public async Task<bool> Handle(BoyFriend request, CancellationToken cancellationToken)
            {
                // Have a great Time with GF
              
                return await Task.FromResult(true);
            }
        }
        #endregion

        #region Post Tasks

        public class PostLogger<TRequest, TResponse> : IRequestPostProcessor<TRequest, TResponse> //where TRequest : CustomerCommand 
        {
            private readonly IMediator _mediator;

            public PostLogger(IMediator mediator)
            {
                _mediator = mediator;
            }

            public Task Process(TRequest request, TResponse response)
            {
                BoyFriend friend = request as BoyFriend;


                Friend friends = new Friend
                {
                    FirstName = friend.FirstName,
                    LastName = friend.LastName
                };

                _mediator.Publish(friends);

                return Task.CompletedTask;
            }
        }

        #endregion

        #region ChildHoodFriends
        public class ChildHoodFriends : INotificationHandler<Friend>
        {
            public Task Handle(Friend notification, CancellationToken cancellationToken)
            {
                return Task.CompletedTask;
            }
        }

        #endregion

        #region CricketFriends
        public class CricketFriends : INotificationHandler<Friend>
        {
            public Task Handle(Friend notification, CancellationToken cancellationToken)
            {
                return Task.CompletedTask;
            }
        }

        #endregion
    }
}
