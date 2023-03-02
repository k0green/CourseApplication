using System.Globalization;
using CourseApplication.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using CourseApplication.Entities;
using CourseApplication.Repositories.Impl;
using CourseApplication.Repositories;
using CourseApplication.Services.Impl;
using CourseApplication.Services;
using CourseApplication;
using CourseApplication.Middlewares;
using Microsoft.AspNetCore.Localization;

//    //"DefaultConnection": "Server=(localdb)\\mssqllocaldb;Database=CourseApplication;Trusted_Connection=True;MultipleActiveResultSets=true"
//Data Source=SQL8003.site4now.net;Initial Catalog=db_a935ed_courseapplication;User Id=db_a935ed_courseapplication_admin;Password=4704egor


var builder = WebApplication.CreateBuilder(args);

builder.Services.AddRazorPages();

// Add services to the container.
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(connectionString));

/*
builder.Services.AddDefaultIdentity<User>(options => options.SignIn.RequireConfirmedAccount = true).AddEntityFrameworkStores<ApplicationDbContext>();
*/
builder.Services.AddDatabaseDeveloperPageExceptionFilter();

builder.Services.AddAutoMapper(typeof(AppMappingProfile));

builder.Services.AddScoped<IUserRepository, UserImpl>();
builder.Services.AddScoped<IUserService, UserServiceImpl>();
builder.Services.AddScoped<IThemRepository, ThemRepositoryImpl>();
builder.Services.AddScoped<IThemService, ThemServiceImpl>();
builder.Services.AddScoped<ICollectionService, CollectionServiceImpl>();
builder.Services.AddScoped<ICollectionRepository, CollectionRepositoryImpl>();
builder.Services.AddScoped<IItemService, ItemServiceImpl>();
builder.Services.AddScoped<IItemRepository, ItemRepositoryImpl>();
builder.Services.AddScoped<ITagService, TagServiceImpl>();
builder.Services.AddScoped<ITagRepository, TagRepositoryImpl>();
builder.Services.AddScoped<IValueTypeService, ValueTypeServiceImpl>();
builder.Services.AddScoped<IValueTypeRepository, ValueTypeRepositoryImpl>();
builder.Services.AddScoped<ICustomFieldRepository, CustomFieldRepositoryImpl>();
builder.Services.AddScoped<ICustomFieldService, CustomFieldServiceImpl>();
builder.Services.AddScoped<ICustomFieldsValuesRepository, CustomFieldValueRepositoryImpl>();
builder.Services.AddScoped<ICustomFieldValueService, CustomFieldValueServiceImpl>();
builder.Services.AddScoped<IItemTagRepository, ItemTagRepositoryImpl>();
builder.Services.AddScoped<ICommentsRepository, CommentsRepositoryImpl>();
builder.Services.AddScoped<ICommentsService, CommentsServiceImpl>();
builder.Services.AddScoped<ILikesRepository, LikesRepositoryImpl>();
builder.Services.AddScoped<ILikesService, LikesServiceImpl>();

builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

builder.Services.AddLocalization(options =>
{
    options.ResourcesPath = "Resources";
});
builder.Services.AddControllersWithViews()
    .AddViewLocalization();

builder.Services.Configure<RequestLocalizationOptions>(options =>
{
    options.SetDefaultCulture("en");
    options.AddSupportedUICultures("en", "ru");
    options.FallBackToParentCultures = true;
});

builder.Services.AddRazorPages().AddViewLocalization();


builder.Services.AddIdentity<User, IdentityRole>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddRoles<IdentityRole>().AddDefaultUI()
    .AddEntityFrameworkStores<ApplicationDbContext>().AddTokenProvider<DataProtectorTokenProvider<User>>(TokenOptions.DefaultProvider);

builder.Services.AddControllersWithViews();

builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromSeconds(10);
    options.Cookie.HttpOnly = true;
    options.Cookie.IsEssential = true;
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseMigrationsEndPoint();
}
else
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

var supportedCultures = new[]
{
    new CultureInfo("en"),
    new CultureInfo("ru")
};
app.UseRequestLocalization(new RequestLocalizationOptions
{
    DefaultRequestCulture = new RequestCulture("en"),
    SupportedCultures = supportedCultures,
    SupportedUICultures = supportedCultures
});

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.UseMiddleware<GeneralMiddleware>();

app.UseSession();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
app.MapRazorPages();

app.Run();
