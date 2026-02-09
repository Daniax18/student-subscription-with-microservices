using Microsoft.EntityFrameworkCore;
using subject.Data;

var builder = WebApplication.CreateBuilder(args);

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


