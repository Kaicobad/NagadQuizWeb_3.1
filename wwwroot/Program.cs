using NagadQuizWeb.Repository;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews().AddRazorRuntimeCompilation();
//Register Services in StartUp
builder.Services.AddTransient<ISignIn,SignIn>();
builder.Services.AddTransient<ICategory, Category>();
builder.Services.AddTransient<IQuizQuestion, QuizQuestion>();
builder.Services.AddTransient<ICheckAnswer, CheckAnswer>();
builder.Services.AddTransient<ISubmitResult, SubmitResult>();
builder.Services.AddTransient<IProfileService, UserProfileServices>();
builder.Services.AddTransient<IPrediction, Prediction>();
builder.Services.AddTransient<INagadPoll,NagadPoll>();

//Add Session
builder.Services.AddDistributedMemoryCache();

builder.Services.AddSession(option =>
{
    option.IdleTimeout = TimeSpan.FromHours(24);
    option.Cookie.HttpOnly = true;
    option.Cookie.IsEssential = true;
});

var app = builder.Build();


// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

//app.UseAuthentication();
app.UseAuthorization();

//user session

app.UseSession();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Profile}/{action=Index}/{id?}");

app.Run();
