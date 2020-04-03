using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ClassLibrary1;
//using ClassLibrary1.CustomerCommandFolder;
//using ClassLibrary1.LoginCommandFolder;
//using ClassLibrary1.PipeLine;
//using ClassLibrary1.Validation;
using FluentValidation;
using FluentValidation.AspNetCore;
using MediatR;
using MediatR.Pipeline;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Swashbuckle.AspNetCore.Swagger;
using static ClassLibrary1.Men.Visit.FirstVisit;

namespace CoreMediatrCQRS
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
            AddApplicationServices(services);
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
            services.AddSwaggerGen(c =>
            {
                //The generated Swagger JSON file will have these properties.
                c.SwaggerDoc("v1", new Info
                {
                    Title = "Swagger XML Api Demo",
                    Version = "v1",
                });

            });

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseSwagger();

            //This line enables Swagger UI, which provides us with a nice, simple UI with which we can view our API calls.
            app.UseSwaggerUI(c => { c.SwaggerEndpoint("/swagger/v1/swagger.json", "Swagger XML Api Demo v1"); });

            app.UseMvc();
        }

        private static void AddApplicationServices(IServiceCollection services)
        {
            //services.AddScoped<IUserRepository, UserRepository>();
            AddMediatr(services);
        }

        private static void AddMediatr(IServiceCollection services)
        {
            const string applicationAssemblyName = "ClassLibrary1";
            var assembly = AppDomain.CurrentDomain.Load(applicationAssemblyName);

            AssemblyScanner
                .FindValidatorsInAssembly(assembly)
                .ForEach(result => services.AddScoped(result.InterfaceType, result.ValidatorType));

            //services.AddScoped(typeof(IPipelineBehavior<,>), typeof(ModelPipelineBehavior<,>));
            services.AddScoped(typeof(IPipelineBehavior<BoyFriend,bool>), typeof(CheckIfHeisYourDriver<BoyFriend,bool>));
            services.AddScoped(typeof(IPipelineBehavior<BoyFriend, bool>), typeof(PurchaseDress<BoyFriend, bool>));
            services.AddScoped(typeof(IPipelineBehavior<BoyFriend, bool>), typeof(PurchaseGift<BoyFriend, bool>));
           
            
            services.AddMediatR();
        }
    }
}
