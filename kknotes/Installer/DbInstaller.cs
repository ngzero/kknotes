using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using kknotes.Data;
using kknotes.Data.Repositories;
using kknotes.Data.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace kknotes.Installer
{
    public class DbInstaller : IInstaller
    {
        public void InstallService(IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<NotesDbContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("ApplicationDbConnectionString")));

            services.AddScoped<INoteRepository, NotesRepository>();
        }
    }
}
