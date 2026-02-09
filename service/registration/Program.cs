using Microsoft.EntityFrameworkCore;
using registration.Data;
using registration.Services;

var builder = WebApplication.CreateBuilder(args);

// Clients HTTP
builder.Services.AddHttpClient<StudentClient>(c =>
{
    c.BaseAddress = new Uri("http://student-service:8080");
});

builder.Services.AddHttpClient<SubjectClient>(c =>
{
    c.BaseAddress = new Uri("http://subject-service:8080");
});

builder.Services.AddDbContext<AppDbContext>(options =>
{
    options.UseMySql(
        builder.Configuration.GetConnectionString("DockerDb"),
        ServerVersion.AutoDetect(
            builder.Configuration.GetConnectionString("DockerDb")
        )
    );
});

builder.Services.AddControllers();

var app = builder.Build();

// idem with upgrade database
using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<AppDbContext>();
    db.Database.Migrate();
}

app.MapControllers();
app.Run();

