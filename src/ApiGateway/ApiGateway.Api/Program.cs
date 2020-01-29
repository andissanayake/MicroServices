// Copyright (c) Brock Allen & Dominick Baier. All rights reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE in the project root for license information.

using System;
using System.IO;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;

namespace ApiGateway.Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.Title = "Api Gateway API";

            BuildWebHost(args).Run();
        }

        public static IWebHost BuildWebHost(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
            .ConfigureAppConfiguration((host, config) => {
                config.AddJsonFile(Path.Combine("", "configuration.json"));
            })
            .UseStartup<Startup>()
            .Build();
    }
}