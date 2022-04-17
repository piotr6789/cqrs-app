using CQRS.Domain.Core;
using CQRS.Infrastructure.Database;
using CQRS.Infrastructure.Providers;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using Newtonsoft.Json.Converters;
using System.Reflection;
using MediatR;

var builder = WebApplication.CreateBuilder(args);

builder.Services
    .AddControllers()
    .AddNewtonsoftJson(options => options.SerializerSettings.Converters.Add(new StringEnumConverter()));

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

builder.Logging.AddApplicationInsights(builder.Configuration["InstrumentationKey"]);

//builder.Configuration.AddAzureKeyVault(
//        new Uri(Environment.GetEnvironmentVariable("KeyVault__URL")!),
//        new ClientSecretCredential(TENANT_ID, CLIENT_ID, CLIENT_SECRET_ID));

builder.Services.AddDbContext<PostDbContext>(optionsBuilder =>
    optionsBuilder.UseSqlServer(builder.Configuration["Database"], options =>
    {
        options.EnableRetryOnFailure();
        options.CommandTimeout(15);
    }));

builder.Services.AddScoped<IPostProvider, PostProvider>();
builder.Services.AddScoped<IAuthorProvider, AuthorProvider>();
builder.Services.AddMediatR(typeof(PostProvider).Assembly);

var app = builder.Build();

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
