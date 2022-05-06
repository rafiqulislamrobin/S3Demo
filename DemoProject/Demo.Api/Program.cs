using Autofac;
using Autofac.Extensions.DependencyInjection;
using Custom.DataLayer;
using Demo.Api;

const string connectionStringName = "DemoDbConnection";
var builder = WebApplication.CreateBuilder(args);
builder.Configuration.SetBasePath(builder.Environment.ContentRootPath)
    .AddJsonFile("appsettings.json", false, true)
    .AddEnvironmentVariables()
    .Build();
// Add services to the container.

var webHostEnvironment = builder.Environment;
var connectionString = builder.Configuration.GetConnectionString(connectionStringName);
var migrationAssemblyName = typeof(Program).Assembly.FullName;
builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory());
builder.Host.ConfigureContainer<ContainerBuilder>(containerBuilder =>
{
    containerBuilder
        .RegisterModule(new ApiModule())
        .RegisterModule(new DataLayerModule());
});
// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();
var autofacContainer = app.Services.GetAutofacRoot();
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}


app.UseAuthorization();

app.MapControllers();

app.Run();
