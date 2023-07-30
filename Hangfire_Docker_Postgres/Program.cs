using Hangfire;
using Hangfire.PostgreSql;
using Hangfire_Docker_Postgres.Hangfire;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
GlobalConfiguration.Configuration.UsePostgreSqlStorage("Host=postgres;Port=5432;Username=testUser;Password=testPass123#;Database=hangfire_testdb");
RecurringJob.AddOrUpdate("my-task", () => JobMethods.RunTask(), Cron.Minutely());

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHangfireDashboard();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
