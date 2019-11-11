using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using Serilog;
using Serilog.Events;
using Serilog.Formatting.Json;

namespace ConceirgeDinning.API
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCors(Options =>
            {
                Options.AddPolicy("MyPolicy",
                    builder =>
                    {
                        builder.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin();
                    }
                    );
            });
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
            StartLogger();
            Guid GuId = Guid.NewGuid();
            Log.Information("SessionId : " + GuId.ToString());
            Log.Information("timestamp: "+DateTime.Now.ToString());
            


        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseCors("MyPolicy");
           
            app.UseHttpsRedirection();
            app.UseMvc();
        }
        private void StartLogger()
        {
            //var client = new MongoClient("mongodb+srv://mattapalliswarnesh:lthliCuE4xi80DOE@logs-et0xz.mongodb.net/test?retryWrites=true&w=majority");
            //var database = client.GetDatabase("ConceirgeLogs");
            //var collection = database.GetCollection<object>("ConceirgeLogs");
            
            Log.Logger = new LoggerConfiguration()
            .MinimumLevel.Debug()
            .WriteTo.MongoDB("mongodb+srv://mattapalliswarnesh:lthliCuE4xi80DOE@logs-et0xz.mongodb.net/ConceirgeLogs?retryWrites=true&w=majority", "ConceirgeLogs")
            .CreateLogger();
            
            /* Log.Logger = new LoggerConfiguration()
             .WriteTo.RollingFile(new JsonFormatter(), Path.Combine(@"..\Logs\", "[filename]-{Date}.json"))
             .CreateLogger();
            /* Log.Logger = new LoggerConfiguration()
                          .MinimumLevel.Verbose()
                          .WriteTo.File(@"..\Logs\log.csv", rollingInterval: RollingInterval.Day)
                          .CreateLogger();*/
        }
    }
}
