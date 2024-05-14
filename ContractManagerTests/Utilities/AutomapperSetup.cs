using AutoMapper;
using Mappings.MappingProfiles;

namespace ContractManagerTests.Utilities;

public static class AutomapperSetup
{
    public static IMapper GetMapper()
    {
        var config = new MapperConfiguration(cfg =>
        {
            cfg.AllowNullCollections = true;
            cfg.AddProfile<LegalContractMapperProfile>();
        });

        return config.CreateMapper();
    }
}