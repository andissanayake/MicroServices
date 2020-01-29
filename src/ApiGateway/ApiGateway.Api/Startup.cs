// Copyright (c) Brock Allen & Dominick Baier. All rights reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE in the project root for license information.

using HealthChecks.UI.Client;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Ocelot.DependencyInjection;
using Ocelot.Middleware;

namespace ApiGateway.Api
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvcCore()
                .AddAuthorization()
                .AddJsonFormatters();

            services.AddAuthentication("Bearer")
                .AddJwtBearer("Bearer", options =>
                {
                    options.Authority = "http://auth.ui";
                    options.RequireHttpsMetadata = false;
                    options.Audience = "ApiGateway";
                    options.TokenValidationParameters= new TokenValidationParameters
                    {
                        ValidateIssuer =false
                    };
                });

            services.AddCors(options =>
            {
                // this defines a CORS policy called "default"
                options.AddPolicy("default", policy =>
                {
                    policy.WithOrigins("http://localhost:5110", "http://healthcheck")
                        .AllowAnyHeader()
                        .AllowAnyMethod();
                });
            });
            services.AddOcelot();
            services.AddHealthChecks();
        }

        public void Configure(IApplicationBuilder app)
        {
            app.UseCors("default");
            app.UseAuthentication();
            app.UseMvc();
            app.UseHealthChecks(path: "/hc", options: new HealthCheckOptions()
            {
                Predicate = _ => true,
                ResponseWriter = UIResponseWriter.WriteHealthCheckUIResponse
            });
            app.UseOcelot().Wait();
        }
    }
}