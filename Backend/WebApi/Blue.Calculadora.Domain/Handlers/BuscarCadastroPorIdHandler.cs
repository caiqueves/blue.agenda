using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Blue.Calculadora.Domain.Repositories;
using Blue.Calculadora.RabbitMQ.Interfaces;
using Blue.Calculadora.Shareable.Exceptions;
using Blue.Calculadora.Shareable.Requests;
using Blue.Calculadora.Shareable.Responses;
using MediatR;


public class BuscarCadastroPorIdHandler : IRequestHandler<ObterContatoRequest, ObterContatoResponse>
{
    private readonly IContatoRepository _contatoRepository;
    private readonly IMapper _mapper;

    public BuscarCadastroPorIdHandler(IContatoRepository contatoRepository, IMapper mapper)
    {
            _contatoRepository = contatoRepository;
            _mapper = mapper;
    }

    public Task<ObterContatoResponse> Handle(ObterContatoRequest request, CancellationToken cancellationToken)
    {
        // Lógica de manipulação do comando ObterContatoRequest
        if (request == null)
        {
            throw new RequestNullException("A solicitação não pode ser nula.");
        }

        var contato = _contatoRepository.GetContatoByIdAsync(request.ContatoId);

        if (contato == null)
        {
            throw new ContatoNaoEncontradoException($"Contato com ID {request.ContatoId} não encontrado.");
        }

        // Pode retornar uma resposta específica se necessário
        var response = _mapper.Map<ObterContatoResponse>(contato);

        return Task.FromResult(response);
    }
}
