using Groupe1.Webzine.Business;
using Groupe1.Webzine.Business.Contracts;
using Groupe1.Webzine.EntitiesContext;
using Groupe1.Webzine.EntitiesContext.Seeder;
using Groupe1.Webzine.Repository;
using Groupe1.Webzine.Repository.Contracts;
using Groupe1.Webzine.WebApplication.Filters;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;

namespace Groupe1.Webzine.WebApplication
{
    public class Startup
    {
        public IConfiguration Configuration { get; set; }
        public Startup(IConfiguration iConfig)
        {
            Configuration = iConfig;
        }
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews(options =>
            {
                options.Filters.Add(typeof(TracerActionFilter));
            });
            services.AddRazorPages().AddRazorRuntimeCompilation();

            Config.DatabaseOption = Configuration.GetSection("Config").GetSection("DatabaseOption").Value;
            Config.RepositoryOptions = Configuration.GetSection("Config").GetSection("RepositoryOptions").Value;

            if (Config.RepositoryOptions == "db")
            {
                services.AddScoped<ITime, Time>();
                services.AddScoped<IArtisteRepository, DbArtisteRepository>();
                services.AddScoped<ICommentaireRepository, DbCommentaireRepository>();
                services.AddScoped<IStyleRepository, DbStyleRepository>();
                services.AddScoped<ITitreRepository, DbTitreRepository>();
                if (Config.DatabaseOption == "db")
                {
                    services.AddDbContext<WebzineDbContext>(options =>
                        options.UseSqlServer(@"Server=(localdb)\\mssqllocaldb;Database=WebzineDbContext;Trusted_Connection=True;MultipleActiveResultSets=true")
                       );
                }
                else
                {
                    services.AddDbContext<WebzineDbContext>(options =>
                        //options.UseSqlite("Data Source=C:/inetpub/wwwroot/db/Webzine.db")
                        options.UseSqlite("Data Source=Webzine.db")
                        );
                }
            }
            else
            {
                services.AddScoped<IArtisteRepository, LocalArtisteRepository>();
                services.AddScoped<ICommentaireRepository, LocalCommentaireRepository>();
                services.AddScoped<IStyleRepository, LocalStyleRepository>();
                services.AddScoped<ITitreRepository, LocalTitreRepository>();
            }
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.z
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseStaticFiles();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                // Page d'accueil
                endpoints.MapControllerRoute( // GET
                    name: "defaultArea",
                    pattern: "{area:exists}/{controller}/{action=Index}/{id?}"
                );

                // Page Recherche
                endpoints.MapControllerRoute( // GET
                    name: "default",
                    pattern: "{controller=Recherche}/{libelle}"
                );

                // Page TitreArtiste
                endpoints.MapControllerRoute( // GET
                    name: "default",
                    pattern: "{controller=Artiste}/{libelle}"
                );

                endpoints.MapControllerRoute( // GET
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}"
                );
            });
        }
    }
}
