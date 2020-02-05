using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Warthog.Api.Core.Services.Students;
using Warthog.Api.Core.Services.Subjects;
using Warthog.Api.Core.Repositories.Students;
using Warthog.Api.Core.Repositories.Subjects;
using Warthog.Api.Models;

namespace Warthog.Api
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
            services.Configure<WarthogDatabaseSettings>(
        Configuration.GetSection(nameof(WarthogDatabaseSettings)));

            services.AddSingleton<IWarthogDatabaseSettings>(sp =>
                sp.GetRequiredService<IOptions<WarthogDatabaseSettings>>().Value);

            services.AddControllers();
            services.TryAddSingleton<IStudentService, StudentService>();
            services.TryAddSingleton<IStudentRepository, StudentRepository>();
            services.TryAddSingleton<ISubjectService, SubjectService>();
            services.TryAddSingleton<ISubjectRepository, SubjectRepository>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
