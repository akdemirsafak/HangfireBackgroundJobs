using Hangfire;
using HangfireBackgroundJobs.Jobs;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddHangfire(x =>
{
    x.UseSqlServerStorage(builder.Configuration.GetConnectionString("Hangfire")); 
    //Bu database'i kendisi oluşturmuyor. Kendimiz manuel olarak oluşturmalıyız.
    //Db'de oluşturduktan sonra builder.Services.AddHangfireServer() ile oluşturuyoruz.


    RecurringJob.AddOrUpdate<MyJob>(j => j.DbControl(),
        Cron.Weekly(DayOfWeek.Saturday),
        TimeZoneInfo.Utc); // çağırılacak class generic olarak geçilir ve methodu belirttik.
    //buradaki expression ile her cuma 12.00'da çalışacak bir job oluşturduk.
    //Hangfire cron expression generator ile buradaki configuration'ları yapabiliriz. crontab.cronhub.io'da görebiliriz.
});
builder.Services.AddHangfireServer();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.UseHangfireDashboard(); // Bu dashboard'a sadece uygulamanın çalıştığı yerden erişilebilir. Güvenlik amaçlı bu şekildedir.

app.MapControllers();

app.Run();
