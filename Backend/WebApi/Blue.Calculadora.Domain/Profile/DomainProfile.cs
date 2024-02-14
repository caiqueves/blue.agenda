using AutoMapper;
using Blue.Calculadora.Domain.Entity;
using Blue.Calculadora.Shareable.Requests;
using Blue.Calculadora.Shareable.Responses;

public class DomainProfile : Profile
{
    public DomainProfile()
    {
        CreateMap<Contato, ObterContatoResponse>()
            .ForMember(dest => dest.IdContato, opt => opt.MapFrom(src => src.Id))
            .ReverseMap(); // Caso precise do mapeamento inverso
    }
}
