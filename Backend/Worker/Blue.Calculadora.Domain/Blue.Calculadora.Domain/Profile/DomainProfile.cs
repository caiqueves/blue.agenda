using AutoMapper;
using Blue.Calculadora.Domain.Entity;
using Blue.Calculadora.Shareable.Requests;

public class DomainProfile : Profile
{
    public DomainProfile()
    {
        CreateMap<AdicionarContatoRequest, Contato>()
            .ForMember(dest => dest.Id, opt => opt.Ignore()); // Ignora o mapeamento da propriedade Id

        CreateMap<Contato, AdicionarContatoRequest>();


        CreateMap<AtualizarContatoRequest, Contato>()
            .ForMember(dest => dest.Id, opt => opt.Ignore()); // Ignora o mapeamento da propriedade Id

        CreateMap<Contato, AtualizarContatoRequest>();

        CreateMap<RemoverContatoRequest,Contato>()
            .ForMember(dest => dest.Id, opt => opt.Ignore()); // Ignora o mapeamento da propriedade Id

        CreateMap<Contato, RemoverContatoRequest>();

        CreateMap<CriarCadastroRequest, Usuario>();

        CreateMap<Usuario, CriarCadastroRequest>();
    }
}
