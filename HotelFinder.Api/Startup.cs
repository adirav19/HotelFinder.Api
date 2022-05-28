using BussinesLayer.Abstract;
using BussinesLayer.Concrete;
using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotelFinder.Api
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
            services.AddControllers();
            services.AddSingleton<IHotelService, HotelManager>();
            //birisi sende nhotel service istiyorsa sen hotel manager gönder 
            services.AddSingleton<IHotelRepository, HotelRepository>();
            services.AddSwaggerDocument(config=>
            {
                config.PostProcess = (doc =>
                  {
                      doc.Info.Title = "Bütün otellerin apisi";
                      doc.Info.Version = "1.0.0";
                      doc.Info.Contact = new NSwag.OpenApiContact()
                      {
                          Name = "Suat Dirav",
                          Url = "http://www.suatdirav.com",
                          Email = "ahmetsuatdirav4@gmail.com"
                      };
                  });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            
            app.UseRouting();
            app.UseOpenApi();
            app.UseSwaggerUi3();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
