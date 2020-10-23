using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using PremiumCalc.Services.DBContext;

using PremiumCalc.Services;
using PremiumCalc.API.Utility;
using AutoMapper;
using NLog;
using System.IO;
using PremiumCalc.Infra;
using PremiumCalc.API.Extensions;

namespace PremiumCalc.API
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
            LogManager.LoadConfiguration(String.Concat(Directory.GetCurrentDirectory(), "/nlog.config"));

        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

            services.AddDbContext<DBContext>(options =>
               options.UseSqlServer(Configuration.GetConnectionString("TAL_DBConn")));

            services.AddTransient<IPremiumCalcService, PremiumCalculator>();
            services.AddTransient<IPremiumCalcLogic, PremiumCalcLogic>();
            services.AddSingleton<ILoggerManager, LoggerManager>();

            services.AddAutoMapper(typeof(Startup));

        }
    
        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerManager loggerManager)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            //Extension method to handle exception
            app.ConfigureExceptionHandler(loggerManager);
            app.UseMvc();
        }
    }
}
