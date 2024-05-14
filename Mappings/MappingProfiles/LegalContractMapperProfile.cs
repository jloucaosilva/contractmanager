using AutoMapper;
using Domain.Models;
using PublicContracts.Requests;
using PublicContracts.Responses;

namespace Mappings.MappingProfiles;

public class LegalContractMapperProfile : Profile
{
    public LegalContractMapperProfile()
    {
        CreateMap<LegalContract, LegalContract>();

        CreateMap<LegalContract, CreateLegalContractRequest>()
            .ForMember(dest => dest.Author, opts => opts.MapFrom(src => src.AuthorName))
            .ForMember(dest => dest.Contract, opts => opts.MapFrom(src => src.LegalEntityDescription))
            .ForMember(dest => dest.LegalEntity, opts => opts.MapFrom(src => src.LegalEntityName));
        
        CreateMap<CreateLegalContractRequest, LegalContract>()
            .ForMember(dest => dest.AuthorName, opts => opts.MapFrom(src => src.Author))
            .ForMember(dest => dest.LegalEntityName, opts => opts.MapFrom(src => src.LegalEntity))
            .ForMember(dest => dest.LegalEntityDescription, opts => opts.MapFrom(src => src.Contract))
            .ForMember(dest => dest.CreatedAt, opts => opts.Ignore())
            .ForMember(dest => dest.UpdatedAt, opts => opts.Ignore())
            .ForMember(dest => dest.Id, opts => opts.Ignore());
        
        CreateMap<LegalContract, UpdateLegalContractRequest>()
            .ForMember(dest => dest.Author, opts => opts.MapFrom(src => src.AuthorName))
            .ForMember(dest => dest.Contract, opts => opts.MapFrom(src => src.LegalEntityDescription))
            .ForMember(dest => dest.LegalEntity, opts => opts.MapFrom(src => src.LegalEntityName))
            .ForMember(dest => dest.Id, opts => opts.MapFrom(src => src.Id));

        CreateMap<UpdateLegalContractRequest, LegalContract>()
            .ForMember(dest => dest.AuthorName, opts => opts.MapFrom(src => src.Author))
            .ForMember(dest => dest.LegalEntityName, opts => opts.MapFrom(src => src.LegalEntity))
            .ForMember(dest => dest.LegalEntityDescription, opts => opts.MapFrom(src => src.Contract))
            .ForMember(dest => dest.Id, opts => opts.MapFrom(src => src.Id))
            .ForMember(dest => dest.CreatedAt, opts => opts.Ignore())
            .ForMember(dest => dest.UpdatedAt, opts => opts.Ignore());
        
        CreateMap<LegalContract, LegalContractResponse>()
            .ForMember(dest => dest.Author, opts => opts.MapFrom(src => src.AuthorName))
            .ForMember(dest => dest.LegalEntity, opts => opts.MapFrom(src => src.LegalEntityName))
            .ForMember(dest => dest.Contract, opts => opts.MapFrom(src => src.LegalEntityDescription))
            .ForMember(dest => dest.CreatedAt, opts => opts.MapFrom(src => src.CreatedAt))
            .ForMember(dest => dest.UpdatedAt, opts => opts.MapFrom(src => src.UpdatedAt))
            .ForMember(dest => dest.Id, opts => opts.MapFrom(src => src.Id));
        
        CreateMap<LegalContractResponse, LegalContract>()
            .ForMember(dest => dest.AuthorName, opts => opts.MapFrom(src => src.Author))
            .ForMember(dest => dest.LegalEntityName, opts => opts.MapFrom(src => src.LegalEntity))
            .ForMember(dest => dest.LegalEntityDescription, opts => opts.MapFrom(src => src.Contract))
            .ForMember(dest => dest.CreatedAt, opts => opts.MapFrom(src => src.CreatedAt))
            .ForMember(dest => dest.UpdatedAt, opts => opts.MapFrom(src => src.UpdatedAt))
            .ForMember(dest => dest.Id, opts => opts.MapFrom(src => src.Id));
    }
}