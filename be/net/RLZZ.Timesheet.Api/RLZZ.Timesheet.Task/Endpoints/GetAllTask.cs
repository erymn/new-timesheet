using SysTask = System.Threading.Tasks;
using Commandor;
using FastEndpoints;
using RLZZ.Timesheet.Task.Features;
using RLZZ.Timesheet.Task.Services;

namespace RLZZ.Timesheet.Task.Endpoints;

public class GetAllTask(ICommandor commandor) : EndpointWithoutRequest
{
    public override void Configure()
    {
        Get("/api/v1/tasks");
        Policies("UserPolicy");
    }

    public override async SysTask.Task HandleAsync(CancellationToken ct)
    {
        var query = new GetAllTaskCommand();
        var tasks = await commandor.SendAsync(query, ct);
        
        await Send.OkAsync(tasks, ct);
    }
}