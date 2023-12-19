using AssoSw.Lesson7.AspNetCoreWebApi.Context;
using AssoSw.Lesson7.AspNetCoreWebApi.Models;
using AssoSw.Lesson7.AspNetCoreWebApi.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using Microsoft.Net.Http.Headers;
using Microsoft.OpenApi.Models;
using System.Text;

namespace AssoSw.Lesson7.AspNetCoreWebApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.Configure<JwtTokenOptions>(builder.Configuration.GetSection("Jwt"));

            // Add services to the container.
            builder.Services.AddDbContext<WarehouseContext>();
            builder.Services.AddDbContext<UsersContext>();

            builder.Services.AddScoped<TokenService, TokenService>();

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();

            // Add the SwaggerGen service.
            builder.Services.AddSwaggerGen(option =>
            {
                option.EnableAnnotations();
                // Configure the Swagger documentation.
                option.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "La prima applicazione ASP.NET Core Web Api con autenticazione JWT",
                    Version = "v1",
                });
                option.AddSecurityDefinition(JwtBearerDefaults.AuthenticationScheme, new OpenApiSecurityScheme()
                {
                    In = ParameterLocation.Header,
                    Description = "Insert the Bearer Token",
                    Name = HeaderNames.Authorization,
                    Type = SecuritySchemeType.Http,
                    BearerFormat = "JWT",
                    Scheme = JwtBearerDefaults.AuthenticationScheme
                });
                option.AddSecurityRequirement(new OpenApiSecurityRequirement()
                {
                    {
                        new OpenApiSecurityScheme()
                        {
                            Reference = new OpenApiReference
                            {
                                Type = ReferenceType.SecurityScheme,
                                Id = JwtBearerDefaults.AuthenticationScheme
                            }
                        },
                        new string[]{}
                    }
                });
            });

            // Add a service for handling Jwt bearer authentication.
            builder.Services
                .AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                {
                    options.TokenValidationParameters = new TokenValidationParameters()
                    {
                        /*
                         * E' buona pratica gestire il ValidIssuer e ValidAudience in un file di configurazione 
                         * come il file appsettings.json; inoltre IssuerSigningKey dovrebbe essere mantenuto 
                         * segreto in un posto come un file .env o in user secrets.
                         */
                        IssuerSigningKey = new SymmetricSecurityKey(
                            Encoding.UTF8.GetBytes(builder.Configuration["Jwt:SigningKey"])
                        ),
                        ValidateIssuerSigningKey = true,
                        ValidIssuer = builder.Configuration["Jwt:Issuer"],
                        ValidateIssuer = true,
                        ValidAudience = builder.Configuration["Jwt:Audience"],
                        ValidateAudience = true,
                        ClockSkew = TimeSpan.Zero,
                        ValidateLifetime = true,
                    };
                });

            builder.Services
                .AddIdentityCore<IdentityUser>(options =>
                {
                    options.SignIn.RequireConfirmedAccount = false;
                    options.User.RequireUniqueEmail = true;
                    options.Password.RequireDigit = false;
                    options.Password.RequiredLength = 6;
                    options.Password.RequireNonAlphanumeric = false;
                    options.Password.RequireUppercase = false;
                    options.Password.RequireLowercase = false;
                })
                .AddEntityFrameworkStores<UsersContext>();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseAuthentication();
            app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }
    }
}