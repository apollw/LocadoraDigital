using SQLite;
using LocadoraDigital.Infrastructure.Adapters.Mapping; 

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
                // Opção 1: Criação do banco na pasta de dados local do aplicativo
                string localDevicePath = Path.Combine(
                    Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData));
                string dbFileName = "LocadoraDigitalDB.db3";
                string dbPathLocal = Path.Combine(localDevicePath, dbFileName);

                // Opção 2: Criação do banco na área de trabalho do usuário
                string desktopPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
                string dbPathDesktop = Path.Combine(desktopPath, dbFileName);

                string dbPath = dbPathDesktop; 
                //string dbPath = dbPathLocal; 

                _dbConnection = new SQLiteAsyncConnection(dbPath);

                await CreateTables();
            }
        }

        private async Task CreateTables()
        {
            await _dbConnection.CreateTablesAsync(
                CreateFlags.AllImplicit,
                typeof(AccessoryTable),
                typeof(ClientTable),
                typeof(ConsoleDeviceTable),
                typeof(ConsoleUsageByClientTable),
                typeof(GameTable),
                typeof(GamePlatformTable),
                typeof(PlatformTable),
                typeof(RentalTable),
                typeof(RentalItemTable)
            );
        }

        public SQLiteAsyncConnection GetDbConnection()
        {
            return _dbConnection;
        }
    }
}
