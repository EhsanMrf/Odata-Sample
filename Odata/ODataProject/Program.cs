using ODataProject;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.OData;
using ODataProject.ProviderExtensions;
using Odata.Application.Service;
using Odata.Contract.Interface;
using API;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.InjectScope();
builder.Services.AddScoped<IAreaService, AreaService>();
builder.Services.DatabaseContext(builder.Configuration.GetSection("Connection").Value);


builder.Services.AddControllers(mvcOptions =>
    {
        mvcOptions.EnableEndpointRouting = false;
    })
    .AddOData(opt => opt.Select().Filter().Expand().OrderBy().Count().SetMaxTop(100));


var app = builder.Build();
app.UseMiddleware<ExceptionMiddleware>();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();


app.MapControllers();

app.Run();
