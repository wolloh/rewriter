﻿using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace rewriter.Shared.Common.Helpers
{
    public static class AutoMappersRegisterHelper
    {
        public static void Register(IServiceCollection services)
        {
            var assemblies = AppDomain.CurrentDomain.GetAssemblies()
                .Where(s => s.FullName != null && s.FullName.ToLower().StartsWith("rewriter."));

            services.AddAutoMapper(assemblies);
        }
    }
}
