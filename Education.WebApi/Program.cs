using Education.BusinessLayer.Abstract;
using Education.BusinessLayer.Concrete;
using Education.DataAccessLayer.Abstract;
using Education.DataAccessLayer.Concrete;
using Education.DataAccessLayer.EntityFramework;
using Education.EntityLayer.Concrete;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<AppDbContext>(options =>
{
    options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));
});
builder.Services.AddIdentity<ApplicationUser, ApplicationRole>(options =>
{
    options.Password.RequireDigit = true;
    options.Password.RequireLowercase = true;
    options.Password.RequireUppercase = true;
    options.Password.RequiredLength = 5;
}).AddEntityFrameworkStores<AppDbContext>().AddDefaultTokenProviders();

var jwtIssuer = builder.Configuration["AuthSettings:Issuer"];
var jwtKey = builder.Configuration["AuthSettings:Key"];
var jwtAudience = builder.Configuration["AuthSettings:Audience"];

builder.Services.AddAuthentication(auth =>
{
    auth.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    auth.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8
                .GetBytes(builder.Configuration.GetSection("AuthSettings:Token").Value)),
            ValidateIssuer = false,
            ValidIssuer = builder.Configuration.GetSection("AuthSettings:Issuer").Value,
            ValidateAudience = false,
            ValidAudience = builder.Configuration.GetSection("AuthSettings:Audience").Value,
            RequireExpirationTime = false,
        };
    });

builder.Services.AddScoped<IAbsenceDal, EfAbsenceDal>();
builder.Services.AddScoped<IAbsenceService, AbsenceManager>();

builder.Services.AddScoped<IApplicationUserDal, EfApplicationUserDal>();
builder.Services.AddScoped<IApplicationUserService, ApplicationUserManager>();

builder.Services.AddScoped<IApplicationRoleDal, EfApplicationRoleDal>();
builder.Services.AddScoped<IApplicationRoleService, ApplicationRoleManager>();

builder.Services.AddScoped<IDepartmentDal, EfDepartmentDal>();
builder.Services.AddScoped<IDepartmentService, DepartmentManager>();

builder.Services.AddScoped<ICafeteriaCardDal, EfCafeteriaCardDal>();
builder.Services.AddScoped<ICafeteriaCardService, CafeteriaCardManager>();

builder.Services.AddScoped<IGradeDal, EfGradeDal>();
builder.Services.AddScoped<IGradeService, GradeManager>();

builder.Services.AddScoped<IMessageDal, EfMessageDal>();
builder.Services.AddScoped<IMessageService, MessageManager>();

builder.Services.AddCors(opt =>
{
    opt.AddDefaultPolicy( opts =>
    {
        opts.AllowAnyHeader().AllowAnyMethod().AllowCredentials().SetIsOriginAllowed(hostName => true);
    });
});

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme);

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.

    app.UseSwagger();
    app.UseSwaggerUI();

app.UseCors();

app.UseHttpsRedirection();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();


app.Run();
