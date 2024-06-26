using UsesCases;
using DataAccess;
using Microsoft.EntityFrameworkCore;
using Domain.Models;
using Microsoft.AspNetCore.Authorization;
using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Domain.Dtos;

namespace WebApiArticulos
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            builder.Services.AddDbContext<DbContext, Contexto>(options =>
            {
                options.UseSqlServer(builder.Configuration.GetConnectionString("StringConnection"));
            });

            builder.Services.AddScoped(typeof(IRepositoryUsuario<Usuario>), typeof(RepositoryUsuario));
            builder.Services.AddScoped(typeof(IServicioUsuario), typeof(ServicioUsuario));

           

            builder.Services.AddScoped(typeof(IRepositoryParametro), typeof(RepositoryParametro));
            builder.Services.AddScoped(typeof(IServicioParametro), typeof(ServicioParametro));

            builder.Services.AddScoped(typeof(IRepositoryArticulo), typeof(RepositoryArticulo));
            builder.Services.AddScoped(typeof(IServicioArticulo), typeof(ServicioArticulo));

            

            builder.Services.AddScoped(typeof(IRepositoryTipoDeMovimiento), typeof(RepositoryTipoDeMovimiento));
            builder.Services.AddScoped(typeof(IServicioTipoDeMovimiento), typeof(ServicioTipoDeMovimiento));

            builder.Services.AddScoped(typeof(IRepositoryMovimientoDeStock), typeof(RepositoryMovimientoDeStock));
            builder.Services.AddScoped(typeof(IServicioMovimientoDeStock), typeof(ServicioMovimientoDeStock));

            builder.Services.AddScoped(typeof(IServicioLogin<LoginDto, LoginOutDto>), typeof(ServicioLogin));

            builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

            // Add services to the container.
            builder.Services.Configure<JwtSettings>(builder.Configuration.GetSection("JwtSettings"));

            // Configurar la autenticacion JWT
            var claveSecreta = "clave_secreta_del_servidor_clave_secreta_del_servidor_clave_secreta_del_servidor_";
            var claveBytes = Encoding.ASCII.GetBytes(claveSecreta);

            builder.Services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(options =>
            {
                options.RequireHttpsMetadata = false;
                options.SaveToken = true;
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(claveBytes),
                    ValidateIssuer = false,
                    ValidateAudience = false
                };
            });

            // Configurar la autorizacion
            builder.Services.AddAuthorization(options =>
            {
                options.DefaultPolicy = new AuthorizationPolicyBuilder()
                    .RequireAuthenticatedUser()
                    .Build();
            });

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }
    }
}
