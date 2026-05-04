using FastEndpoints;
using FastEndpoints.Swagger;
using Microsoft.Extensions.Configuration;
using RLZZ.Timesheet.Client.Extension;
using RLZZ.Timesheet.Group.Extension;
using RLZZ.Timesheet.Project.Extension;
using RLZZ.Timesheet.ProjectType.Extension;
using RLZZ.Timesheet.Securities;
using RLZZ.Timesheet.Task.Extension;
using RLZZ.Timesheet.User.Extension;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddFastEndpoints();
builder.Services.SwaggerDocument();

var jwtSettings = builder.Configuration.GetSection("JwtSettings").Get<JwtSettings>() ?? new JwtSettings();
builder.Services.AddSecurityServices(jwtSettings);

builder.Services.AddClientService(builder.Configuration);
builder.Services.AddGroupService(builder.Configuration);
builder.Services.AddUserService(builder.Configuration);
builder.Services.AddProjectService(builder.Configuration);
builder.Services.AddProjectTypeService(builder.Configuration);
builder.Services.AddTaskService(builder.Configuration);

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwaggerGen();
}

app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();
app.UseFastEndpoints();

app.Run();