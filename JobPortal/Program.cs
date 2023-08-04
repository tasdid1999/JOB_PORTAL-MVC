using AutoMapper;
using JobPortal.BussinessLogicLayer;
using JobPortal.BussinessLogicLayer.Application;
using JobPortal.BussinessLogicLayer.Job;
using JobPortal.BussinessLogicLayer.SeekerProfileService;
using JobPortal.BussinessLogicLayer.User;
using JobPortal.DataAccessLayer.Data;
using JobPortal.DataAccessLayer.Interfaces;
using JobPortal.DataAccessLayer.Repository;
using JobPortal.DataAccessLayer.Repository.ApplicationRepository;
using JobPortal.DataAccessLayer.Repository.JobRepository;
using JobPortal.DataAccessLayer.Repository.SeekerProfileRepository;
using JobPortal.DataAccessLayer.Repository.UserRepository;
using JobPortal.PresentationLayer.Helper;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("deafultDB")));
builder.Services.AddIdentity<ApplicationUser, IdentityRole>().AddEntityFrameworkStores<ApplicationDbContext>();
builder.Services.AddScoped<IJobRepository, JobRepository>();
builder.Services.AddScoped<IJobServices, JobServices>();
builder.Services.AddScoped<ICatagoryServices, CatagoryServices>();
builder.Services.AddScoped<ICatagoryRepository, CatagoryRepository>();
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IUserServices, UserServices>();
builder.Services.AddScoped<IApplicationRepository, ApplicationRepository>();
builder.Services.AddScoped<IApplicationServices, ApplicationServices>();
builder.Services.AddScoped<ISeekerProfileServices, SeekerProfileServices>();
builder.Services.AddScoped<ISeekerProfileRepository, SeekerProfileRepository>();

var automapper = new MapperConfiguration(item => item.AddProfile(new MapperClass()));
IMapper mapper = automapper.CreateMapper();
builder.Services.AddSingleton(mapper);

builder.Services.Configure<IdentityOptions>(options =>
{
    options.Password.RequireDigit = false;
    options.Password.RequireLowercase = false;
    options.Password.RequireUppercase = false;
    options.Password.RequiredLength = 2;
    options.Password.RequireNonAlphanumeric = false;

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
app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
