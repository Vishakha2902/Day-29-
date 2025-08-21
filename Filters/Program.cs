using StudentApp.Filters;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddScoped<CustomAuthorizationFilter>();
// Register the resource filter, now every request will be logged before and after model binding
builder.Services.AddScoped<LogResourceFilter>();

// Register the action filter for student validation
builder.Services.AddScoped<ValidateStudentFilter>();

// Register the exception filter
builder.Services.AddScoped<CustomExceptionFilter>();

// Register the append message filter
builder.Services.AddScoped<AppendMessageFilter>();

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
