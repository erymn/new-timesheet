using Commandor;
using RLZZ.Timesheet.Task.Model;

namespace RLZZ.Timesheet.Task.Features;

public record CreateTaskCommand(TsTaskDto Task) : IRequest<TsTaskDto>;
public record UpdateTaskCommand(TsTaskDto Task): IRequest<bool>;
public record DeleteTaskCommand(long Id): IRequest<bool>;
public record GetTaskByIdCommand(long Id) : IRequest<TsTaskDto>;
public record GetAllTaskCommand(): IRequest<List<TsTaskDto>>;