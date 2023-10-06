using Domain;
using MediatR;
using Persistence;

namespace Application.Activities
{
    public class Create
    {
        public class Command : IRequest
        {
            public Activity Activity { get; set; }
        }

        public class Handler : IRequestHandler<Command>
        {
            private readonly DataContext context;
            public Handler(DataContext context)
            {
                this.context = context;
            }


            async Task IRequestHandler<Command>.Handle(Command request, CancellationToken cancellationToken)
            {
                await context.Activities.AddAsync(request.Activity);

                await context.SaveChangesAsync();

            }

        }


    }
}