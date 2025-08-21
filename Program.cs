using StudentApp.Filters;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

//registering filter in program.cs, now every request will be loged before and after model binding
builder.Services.AddScoped<LogResourceFilter>();

//
builder.Services.AddScoped<ValidateStudentFilter>();

// registering the custom exception filter, now every exception will be logged and a custom error response will be returned
builder.Services.AddScoped<CustomExceptionFilters>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseRouting();

app.UseAuthorization();

app.MapStaticAssets();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}")
    .WithStaticAssets();


app.Run();

internal class CustomExceptionFilters
{
}