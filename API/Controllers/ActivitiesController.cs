using API.Controllers;
using Application.Activities;
using Domain;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace API;

public class ActivitiesController : BaseApiController
{
    public ActivitiesController(IMediator mediator) : base(mediator)
    {
    }

    [HttpGet]
    public async Task<ActionResult<List<Activity>>> GetActivities()
    {
        var results = await Mediator.Send(new List.Query());

        return HandleResult(results);
    }


    [HttpGet("{id}")]
    public async Task<IActionResult> GetActivity(Guid id)
    {
        var result = await Mediator.Send(new Details.Query { Id = id });

        return HandleResult(result);
    }


    [HttpPost]
    public async Task<ActionResult> CreateActivity(Activity activity)
    {
        var result = await Mediator.Send(new Create.Command { Activity = activity });

        return HandleResult(result);
    }

    [HttpPut("{id}")]
    public async Task<ActionResult> Edit(Guid Id, Activity activity)
    {
        activity.Id = Id;

        await Mediator.Send(new Edit.Command { Activity = activity });

        return Ok();
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult> Delete(Guid id)
    {
        await Mediator.Send(new Delete.Command { Id = id });

        return Ok();
    }

}
