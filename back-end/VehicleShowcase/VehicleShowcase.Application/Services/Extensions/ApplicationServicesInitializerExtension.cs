﻿using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Reflection;
using VehicleShowcase.Application.Interfaces;

namespace VehicleShowcase.Application.Services.Extensions
{
    public static partial class ApplicationServicesInitializerExtension
    {
        public static IServiceCollection RegisterApplicationServices(
                                    this IServiceCollection services)
        {
            RegisterCustomServices(services);
            RegisterMapper(services);
            RegisterAuthentication(services);
            RegisterSwagger(services);

            return services;
        }

        public static void RegisterCustomServices(IServiceCollection services)
        {
            services.AddScoped<IAdminService, AdminService>();
            services.AddScoped<IVehicleService, VehicleService>();
        }

        public static void RegisterMapper(IServiceCollection services)
        {
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
        }

        public static void RegisterAuthentication(IServiceCollection services)
        {
            services.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(x =>
            {
                x.RequireHttpsMetadata = true;
                x.SaveToken = true;
                x.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(PrivateKeyService.privateKey),
                    ValidateIssuer = false,
                    ValidateAudience = false
                };
            });
        }

        public static void RegisterSwagger(IServiceCollection services)
        {
            services.AddSwaggerGen(c =>
            {
                c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    Name = "Authorization",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.ApiKey,
                    Scheme = "Bearer"
                });

                c.AddSecurityRequirement(new OpenApiSecurityRequirement() {
                {
                  new OpenApiSecurityScheme {
                    Reference = new OpenApiReference {
                        Type = ReferenceType.SecurityScheme,
                          Id = "Bearer"
                      },
                      Scheme = "oauth2",
                      Name = "Bearer",
                      In = ParameterLocation.Header,

                  },
                  new List < string > ()
                }
              });
            });
        }
    }
}
