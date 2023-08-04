using Microsoft.EntityFrameworkCore;
using TaskManagement.Data;
using TaskManagement.IRepository;
using TaskManagement.IServices;

using TaskManagement.Repository;
using TaskManagement.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace TaskManagement
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());


            builder.Services.AddScoped<IRegisterService, RegisterService>();
            builder.Services.AddScoped<IRegisterRepository, RegisterRepository>();
            builder.Services.AddScoped<ILoginService, LoginService>();
            builder.Services.AddScoped<ILoginRepository, LoginRepository>();
            builder.Services.AddScoped<IRoleService, RoleService>();
            builder.Services.AddScoped<IRoleRepository, RoleRepository>();
            builder.Services.AddScoped<IPermissionService, PermissionService>();
            builder.Services.AddScoped<IPermissionRepository, PermissionRepository>();
            builder.Services.AddScoped<IUserRoleService, UserRoleService>();
            builder.Services.AddScoped<IUserRoleRepository, UserRoleRepository>();
            builder.Services.AddScoped<IRolePermissionRepository, RolePermissionRepository>();
            builder.Services.AddScoped<IRolePermissionService, RolePermissionService>();


           
           
           
         
           



            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.AddDbContext<DataContext>(options =>
           options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

            builder.Services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(o =>
            {
                o.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidIssuer = builder.Configuration["Jwt:Issuer"],
                    ValidAudience = builder.Configuration["Jwt:Audience"],
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"])),
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = false,
                    ValidateIssuerSigningKey = true
                };
            });

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();
            app.UseAuthentication();
            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}