using LocadoraDigital.Core.Entities;
using LocadoraDigital.Core.Interfaces.InputPorts;
using LocadoraDigital.Infrastructure.Adapters.Mapping;

namespace LocadoraDigital.Core.Factories
{
    public class PlatformFactory : IFactoryService<PlatformTable>
    {
        public PlatformTable Create(int id, string name)
        {
            return new PlatformTable
            {
                Id = id,
                Name = name
            };
        }

        public PlatformTable Create()
        {
            return new PlatformTable
            {
                // Propriedades padrão ou valores iniciais
            };
        }
    }
}
