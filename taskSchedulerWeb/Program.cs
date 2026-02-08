var builder = WebApplication.CreateBuilder(args);

// Added services to the container.
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configuring the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. need to change incase. 
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseDefaultFiles();// Enables default file mapping like index.html 
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
