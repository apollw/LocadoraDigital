using LocadoraDigital.Core.Interfaces.InputPorts;
using LocadoraDigital.Infrastructure.Adapters.Mapping;

namespace LocadoraDigital.Core.Factories
{
    public class ConsoleUsageByClientFactory : IFactoryService<ConsoleUsageByClientTable>
    {
        public ConsoleUsageByClientTable Create(int id, int clientId, int consoleId, DateTime startTime, DateTime endTime)
        {
            return new ConsoleUsageByClientTable
            {
                Id = id,
                ClientId = clientId,
                ConsoleId = consoleId,
                Start = startTime,
                End = endTime
            };
        }

        public ConsoleUsageByClientTable Create()
        {
            return new ConsoleUsageByClientTable
            {
                
            };
        }
    }
}
