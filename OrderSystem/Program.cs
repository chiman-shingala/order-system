using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.FileProviders;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using OrderSystem.email;
using OrderSystem.Models;
using OrderSystem.Repository;
using OrderSystem.Repository.Interface;
using OrderSystem.Service;
using OrderSystem.Service.Interface;

using System.Text;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllers().AddJsonOptions(options =>
{
    options.JsonSerializerOptions.PropertyNamingPolicy = null;
});
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "OrderSystem", Version = "v1" });
    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Description = "Jwt Authorization",
        Name = "Authorization",
        In = ParameterLocation.Header,
        Type = SecuritySchemeType.ApiKey,
        Scheme = "Bearer"
    });
    c.AddSecurityRequirement(new OpenApiSecurityRequirement {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "Bearer"
                }
            },
            new string []{}
        }
    });
});

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
{
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ClockSkew = TimeSpan.Zero,
        ValidateIssuerSigningKey = true,
        ValidIssuer = builder.Configuration["Jwt:Issuer"],
        ValidAudience = builder.Configuration["Jwt:Audience"],
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"]))
    };
});


builder.Services.AddAutoMapper(typeof(Program));

// Register SQL database configuration context as services.
builder.Services.AddDbContext<OrderSystemContext>(
    options => options.UseSqlServer(builder.Configuration.GetConnectionString("OrderSystem")));

builder.Services.AddTransient<IDRepository, DRepository>();
builder.Services.AddTransient<IUserRepository, UserRepository>();
builder.Services.AddTransient<IUserService, UserServices>();
builder.Services.AddTransient<ICompanyMasterRepository, CompanyMasterRepository>();
builder.Services.AddTransient<ICompanyMasterService, ComapnyMasterService>();
builder.Services.AddTransient<IUserService, UserServices>();
builder.Services.AddTransient<IItemMasterRepository, ItemMasterRepository>();
builder.Services.AddTransient<IItemMasterService, ItemMasterService>();
builder.Services.AddTransient<IUserWiseItemMasterRepository, UserWiseItemMasterRepository>();
builder.Services.AddTransient<IUserWiseItemMasterService, UserWiseItemMasterService>();
builder.Services.AddTransient<IUserCategoryMasterService, UserCategoryMasterService>();
builder.Services.AddTransient<IUserCategoryMasterRepository, UserCategoryMasterRepository>();
builder.Services.AddTransient<IOrderDetailRepository, OrderDetailRepository>();
builder.Services.AddTransient<IOrderdetailService, OrderDetailService>();
builder.Services.AddTransient<IReportRepository, ReportRepository>();
builder.Services.AddTransient<IReportService, ReportService>();
builder.Services.AddTransient<IMenuMasterRepository, MenuMasterRepository>();
builder.Services.AddTransient<IMenuMasterService, MenuMasterService>();
builder.Services.AddTransient<IMenuPermissionRepository, MenuPermissionRepository>();
builder.Services.AddTransient<IMenuPermissionService, MenuPermissionService>();
builder.Services.AddTransient<IUtilityRepository, UtilityRepository>();
builder.Services.AddTransient<IUtilityService, UtilityService>();
builder.Services.AddTransient<IOrderDetailByUserService, OrderDetailByUserService>();
builder.Services.AddTransient<IOrderDetailByUserRepository, OrderDetailByUserRepository>();
builder.Services.AddTransient<IPaymentService,PaymentService>();
builder.Services.AddTransient<IPaymentRepository, PaymentRepository>();
builder.Services.AddTransient<IPartyMastService, PartyMastService>();
builder.Services.AddTransient<IPartyMastRepository, PartyMastRepository>();
builder.Services.AddTransient<IUserWisePartyMasterService, UserWisePartyMasterService>();
builder.Services.AddTransient<IUserWisePartyMasterRepository, UserWisePartyMasterRepository>();
builder.Services.AddTransient<IEmailSender, EmailSender>();
builder.Services.AddTransient<IGlobalSearchService, GlobalSearchService>();
builder.Services.AddTransient<IGlobalSearchRepository, GlobalSearchRepository>();
builder.Services.AddTransient<IExceptionRepository, ExceptionRepository>();



builder.Services.AddCors(option =>
{
    option.AddDefaultPolicy(builder =>
    {
        builder.WithOrigins("*").AllowAnyHeader().AllowAnyMethod();
    });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment() || app.Environment.IsProduction())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseHttpsRedirection();
app.UseMiddleware<ExceptionHandlerMiddleware>();
app.UseStaticFiles();
app.UseAuthentication();
app.UseStaticFiles(new StaticFileOptions
{
    FileProvider = new PhysicalFileProvider(
            Path.Combine(Directory.GetCurrentDirectory(), "Images")),
    RequestPath = "/StaticFiles"
});
app.UseCors();
app.UseAuthorization();
app.MapControllers();

app.Run();
