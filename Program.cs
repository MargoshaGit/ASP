using Practice12_1;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

string connection = builder.Configuration.GetConnectionString("ConnectionString");
builder.Services.AddDbContext<AppDbContext>(options => options.UseSqlServer(connection));

builder.Services.AddRazorPages();

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();



app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();


using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;

    var dbContext = services.GetRequiredService<AppDbContext>();

    dbContext.Users.Add(new User { FirstName = "����", LastName = "³����", Age = 18 });
    dbContext.Users.Add(new User { FirstName = "�����", LastName = "����������", Age = 16 });
    dbContext.Users.Add(new User { FirstName = "����", LastName = "�����", Age = 27 });

    dbContext.SaveChanges();

    var users = dbContext.Users.ToList();
    foreach (var user in users)
    {
        Console.WriteLine($"Id: {user.Id}, ��'�: {user.FirstName} {user.LastName}, ³�: {user.Age}");
    }
    
}

app.Run();
