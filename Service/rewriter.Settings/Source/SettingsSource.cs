﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
namespace rewriter.Settings.Source
{
    public  class SettingsSource : ISettingSource
    {
        protected readonly IConfiguration configuration;
        public SettingsSource(IConfiguration config = null)
        {
            if (config != null)
            {
                configuration = config;
                return;
            }

            var builder = new ConfigurationBuilder()
                .SetBasePath(Path.Combine(Directory.GetCurrentDirectory()))
                .AddJsonFile("appsettings.json", optional: false);
                
            

            var aspNetCoreEnv = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") ?? "";
            bool idDev = aspNetCoreEnv.ToLower().Equals("development");

            if (idDev)
                builder.AddJsonFile("appsettings.development.json", optional: true);

            configuration = builder
                .AddEnvironmentVariables()
                .Build();
         }
        private string ApplyEnvironmentVariable(string value)
        {
            value ??= "";
            var list = Regex.Matches(value, @"{[^}]+}").OfType<Match>().Select(c => c.Value).ToList();

            foreach (var itm in list)
            {
                var v = itm.Replace("{", "").Replace("}", "");
                value = value.Replace($"{{{v}}}", configuration[$"{v}"]);
            }

            return value;
        }
        public bool GetAsBool(string source, bool defaultValue = false)
        {
            var val = ApplyEnvironmentVariable(configuration[source]);
            return bool.TryParse(val, out var result) ? result : defaultValue;
        }

        public int GetAsInt(string source, int defaultValue = 0)
        {
            var val = ApplyEnvironmentVariable(configuration[source]);
            return int.TryParse(val, out var result) ? result : defaultValue;
        }

        public string GetAsString(string source, string defaultValue = null)
        {
            var val = ApplyEnvironmentVariable(configuration[source]);
            return val ?? defaultValue;
        }

        public string GetConnectionString(string source = null)
        {
            return ApplyEnvironmentVariable(configuration.GetConnectionString(source ?? "ConnectionString"));
        }
    }
}
