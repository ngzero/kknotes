using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using kknotes.Services;
using kknotes.Services.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace kknotes.Installer
{
    public class ServiceInstaller : IInstaller
    {
        public void InstallService(IServiceCollection services, IConfiguration configuration)
        {
            services.AddAutoMapper(typeof(Startup));
            services.AddScoped<INoteService, NoteService>();
        }
    }
}
