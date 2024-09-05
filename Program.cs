using LocadoraDigital.Core.Interfaces.InputPorts;
using LocadoraDigital.Core.Interfaces.OutputPorts;
using LocadoraDigital.Infrastructure.Configurations;

namespace LocadoraDigital
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Adiciona os serviços de banco de dados
            builder.Services.AddSingleton<DatabaseConfig>();
            builder.Services.AddSingleton<IDbService, DbService>();

            //builder.Services.AddTransient<IRentalRepository, RentalRepository>();
            builder.Services.AddScoped<IRentalService, RentalService>();

            //Adiciona serviços e repositórios
            builder.Services.AddTransient<IClientService, ClientService>();

            builder.Services.AddTransient<IGameService, GameService>();
            builder.Services.AddTransient<IPlatformService, PlatformService>();
            builder.Services.AddTransient<IConsoleDeviceService, ConsoleDeviceService>();
            builder.Services.AddTransient<IAccessoryService, AccessoryService>();

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
