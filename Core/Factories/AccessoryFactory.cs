using LocadoraDigital.Core.Interfaces.InputPorts;
using LocadoraDigital.Infrastructure.Adapters.Mapping;

namespace LocadoraDigital.Core.Factories
{
    public class AccessoryFactory : IFactoryService<AccessoryTable>
    {
        public AccessoryTable Create(int id, string name, int consoleId)
        {
            return new AccessoryTable
            {
                Id = id,
                Name = name,
                ConsoleId = consoleId
            };
        }

        public AccessoryTable Create()
        {
            return new AccessoryTable
            {
                
            };
        }
    }
}
