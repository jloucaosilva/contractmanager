using AutoMapper;
using Domain.Models;
using PublicContracts.Requests;
using PublicContracts.Responses;

namespace Mappings.MappingProfiles;

/// <summary>
/// Sets up the mapping between the domain model and the public request/response models for legal contracts
/// </summary>
public class LegalContractMapperProfile : Profile
{
    /// <summary>
    /// Instantiates a new instance of the <see cref="LegalContractMapperProfile"/>
    /// </summary>
    public LegalContractMapperProfile()
    {
        // Maps the domain model to itself
        CreateMap<LegalContract, LegalContract>();

        // Maps the LegalContract domain model to the CreateLegalContractRequest request model
        CreateMap<LegalContract, CreateLegalContractRequest>()
            .ForMember(dest => dest.Author, opts => opts.MapFrom(src => src.AuthorName))
            .ForMember(dest => dest.Contract, opts => opts.MapFrom(src => src.LegalEntityDescription))
            .ForMember(dest => dest.LegalEntity, opts => opts.MapFrom(src => src.LegalEntityName));
        
        // Maps the CreateLegalContractRequest request model to the LegalContract domain model
        CreateMap<CreateLegalContractRequest, LegalContract>()
            .ForMember(dest => dest.AuthorName, opts => opts.MapFrom(src => src.Author))
            .ForMember(dest => dest.LegalEntityName, opts => opts.MapFrom(src => src.LegalEntity))
            .ForMember(dest => dest.LegalEntityDescription, opts => opts.MapFrom(src => src.Contract))
            .ForMember(dest => dest.CreatedAt, opts => opts.Ignore())
            .ForMember(dest => dest.UpdatedAt, opts => opts.Ignore())
            .ForMember(dest => dest.Id, opts => opts.Ignore());
        
        // Maps the LegalContract domain model to the UpdateLegalContractRequest request model
        CreateMap<LegalContract, UpdateLegalContractRequest>()
            .ForMember(dest => dest.Author, opts => opts.MapFrom(src => src.AuthorName))
            .ForMember(dest => dest.Contract, opts => opts.MapFrom(src => src.LegalEntityDescription))
            .ForMember(dest => dest.LegalEntity, opts => opts.MapFrom(src => src.LegalEntityName))
            .ForMember(dest => dest.Id, opts => opts.MapFrom(src => src.Id));

        // Maps the UpdateLegalContractRequest request model to the LegalContract domain model
        CreateMap<UpdateLegalContractRequest, LegalContract>()
            .ForMember(dest => dest.AuthorName, opts => opts.MapFrom(src => src.Author))
            .ForMember(dest => dest.LegalEntityName, opts => opts.MapFrom(src => src.LegalEntity))
            .ForMember(dest => dest.LegalEntityDescription, opts => opts.MapFrom(src => src.Contract))
            .ForMember(dest => dest.Id, opts => opts.MapFrom(src => src.Id))
            .ForMember(dest => dest.CreatedAt, opts => opts.Ignore())
            .ForMember(dest => dest.UpdatedAt, opts => opts.Ignore());
        
        // Maps the LegalContract domain model to the LegalContractResponse response model
        CreateMap<LegalContract, LegalContractResponse>()
            .ForMember(dest => dest.Author, opts => opts.MapFrom(src => src.AuthorName))
            .ForMember(dest => dest.LegalEntity, opts => opts.MapFrom(src => src.LegalEntityName))
            .ForMember(dest => dest.Contract, opts => opts.MapFrom(src => src.LegalEntityDescription))
            .ForMember(dest => dest.CreatedAt, opts => opts.MapFrom(src => src.CreatedAt))
            .ForMember(dest => dest.UpdatedAt, opts => opts.MapFrom(src => src.UpdatedAt))
            .ForMember(dest => dest.Id, opts => opts.MapFrom(src => src.Id));
        
        // Maps the LegalContractResponse response model to the LegalContract domain model
        CreateMap<LegalContractResponse, LegalContract>()
            .ForMember(dest => dest.AuthorName, opts => opts.MapFrom(src => src.Author))
            .ForMember(dest => dest.LegalEntityName, opts => opts.MapFrom(src => src.LegalEntity))
            .ForMember(dest => dest.LegalEntityDescription, opts => opts.MapFrom(src => src.Contract))
            .ForMember(dest => dest.CreatedAt, opts => opts.MapFrom(src => src.CreatedAt))
            .ForMember(dest => dest.UpdatedAt, opts => opts.MapFrom(src => src.UpdatedAt))
            .ForMember(dest => dest.Id, opts => opts.MapFrom(src => src.Id));
    }
}