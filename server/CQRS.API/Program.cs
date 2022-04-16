using CQRS.Domain;
using CQRS.Infrastructure.Database;
using CQRS.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using Newtonsoft.Json.Converters;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services
    .AddControllers()
    .AddNewtonsoftJson(options => options.SerializerSettings.Converters.Add(new StringEnumConverter()));

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "CQRS - API",
        Version = "v1",
        Description = "Example of cqrs"
    });
    c.EnableAnnotations();
});

builder.Services.AddLogging((builder) =>
{
    builder.AddApplicationInsights(Environment.GetEnvironmentVariable("InstrumentationKey"));
});

//builder.Configuration.AddAzureKeyVault(
//        new Uri(Environment.GetEnvironmentVariable("KeyVault__URL")!),
//        new ClientSecretCredential(TENANT_ID, CLIENT_ID, CLIENT_SECRET_ID));

builder.Services.AddDbContext<PostDbContext>(optionsBuilder =>
    optionsBuilder.UseSqlServer(builder.Configuration["Database"], options =>
    {
        options.EnableRetryOnFailure();
        options.CommandTimeout(15);
    }));

builder.Services.AddScoped<IPostRepository, PostRepository>();
builder.Services.AddScoped<IAuthorRepository, AuthorRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseRouting();

app.UseAuthorization();

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
    endpoints.Map("/", context => context.Response.WriteAsync($"{Assembly.GetEntryAssembly()?.GetName().Name} [{Assembly.GetEntryAssembly()?.GetCustomAttribute<AssemblyInformationalVersionAttribute>()?.InformationalVersion}]"));
});

app.Run();
