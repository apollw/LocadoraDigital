using SQLite;
using LocadoraDigital.Core.Entities;

namespace LocadoraDigital.Infrastructure.Configurations
{
    public class DatabaseConfig
    {
        private SQLiteAsyncConnection _dbConnection;

        public async Task InitializeAsync()
        {
            await SetUpDb();
        }

        private async Task SetUpDb()
        {
            if (_dbConnection == null)
            {
                string localDevicePath = Path.Combine(
                    Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData));

                string dbFileName = "LocadoraDigitalDB.db3";
                string dbPath = Path.Combine(localDevicePath, dbFileName);

                _dbConnection = new SQLiteAsyncConnection(dbPath);

                await CreateTables();
            }
        }

        private async Task CreateTables()
        {
            await _dbConnection.CreateTablesAsync(
                CreateFlags.AllImplicit,
                typeof(Accessory),
                typeof(Client),
                typeof(Console),
                typeof(ConsoleUsageByClient),
                typeof(Game),
                typeof(GamePlatform),
                typeof(Platform),
                typeof(Rental),
                typeof(RentalItem)
            );
        }

        public SQLiteAsyncConnection GetDbConnection()
        {
            return _dbConnection;
        }
    }
}
