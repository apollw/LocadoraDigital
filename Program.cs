using LocadoraDigital.Core.Entities;
using LocadoraDigital.Core.Factories;
using LocadoraDigital.Core.Interfaces.InputPorts;
using LocadoraDigital.Core.Interfaces.OutputPorts;
using LocadoraDigital.Infrastructure.Adapters.Mapping;
using LocadoraDigital.Infrastructure.Configurations;

namespace LocadoraDigital
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Adiciona os servi�os de banco de dados
            builder.Services.AddSingleton<DatabaseConfig>();

            // Adicione servi�os e reposit�rios
            builder.Services.AddSingleton<IDbService, DbService>();
            builder.Services.AddTransient<IClientService, ClientService>();

            builder.Services.AddTransient<FactoryService>();
            builder.Services.AddTransient<IFactoryService<GameTable>, GameFactory>();

            // Add services to the container.
            builder.Services.AddControllersWithViews();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            // Ensure database is initialized
            InitializeDatabase(app.Services).GetAwaiter().GetResult();

            app.Run();
        }

        private static async Task InitializeDatabase(IServiceProvider services)
        {
            using (var scope = services.CreateScope())
            {
                var dbService = scope.ServiceProvider.GetRequiredService<IDbService>();
                await dbService.InitializeAsync();
            }
        }

    }
}
