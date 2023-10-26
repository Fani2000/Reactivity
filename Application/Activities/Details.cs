using Application.Core;
using Domain;
using MediatR;
using Persistence;

namespace Application.Activities
{
    public class Details
    {
        public class Query : IRequest<Result<Activity>>
        {
            public Guid Id { get; set; }
        }

        public class Handler : IRequestHandler<Query, Result<Activity>>
        {
            public readonly DataContext context;

            public Handler(DataContext context)
            {
                this.context = context;
            }

            public async Task<Result<Activity>> Handle(Query request, CancellationToken cancellationToken)
            {
                var activity = await context.Activities.FindAsync(request.Id);

                // bool v = activity == null;

                // if (v) throw new Exception("Activity not found.");

                return Result<Activity>.Success(activity);
            }
        }
    }
}