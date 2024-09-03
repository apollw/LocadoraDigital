using LocadoraDigital.Core.Interfaces.InputPorts;
using LocadoraDigital.Infrastructure.Adapters.Mapping;

namespace LocadoraDigital.Core.Factories
{
    public class ConsoleDeviceFactory : IFactoryService<ConsoleDeviceTable>
    {
        public ConsoleDeviceTable Create(int id, string name, decimal hourlyRate)
        {
            return new ConsoleDeviceTable
            {
                Id = id,
                Name = name,
                PricePerHour = hourlyRate
            };
        }

        public ConsoleDeviceTable Create()
        {
            return new ConsoleDeviceTable
            {
                
            };
        }
    }
}
