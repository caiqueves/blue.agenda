using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Blue.Calculadora.Domain.Entity;
using Blue.Calculadora.Domain.Repositories;
using Blue.Calculadora.RabbitMQ.Interfaces;
using Blue.Calculadora.Shareable.Exceptions;
using Blue.Calculadora.Shareable.Requests;
using Blue.Calculadora.Shareable.Responses;
using MediatR;

public class BuscarCadastrosHandler : IRequestHandler<ObterContatosRequest, ObterContatosResponse>
{
    private readonly IContatoRepository _contatoRepository;

    public BuscarCadastrosHandler(IContatoRepository contatoRepository)
    {
        _contatoRepository = contatoRepository;
    }

    public Task<ObterContatosResponse> Handle(ObterContatosRequest request, CancellationToken cancellationToken)
    {
        // Use o repositório para buscar a lista de contatos
        //var contatos = new List<Contato>();
        var contatos = _contatoRepository.GetAllContatosAsync();

        if (contatos == null)
        {
            throw new ContatoNaoEncontradoException("Nenhum contato encontrado.");
        }

        List<ObterContatoResponse> contatosResponse = new List<ObterContatoResponse>();

        foreach (var contatosItem in contatos)
        {
            var obterContatoResponse = new ObterContatoResponse();
            obterContatoResponse.IdContato = contatosItem.Id;
            obterContatoResponse.Nome = contatosItem.Nome;
            obterContatoResponse.Telefone = contatosItem.Telefone;
            obterContatoResponse.Email = contatosItem.Email;

            contatosResponse.Add(obterContatoResponse);
        }

        var obterContatos = new ObterContatosResponse();
        obterContatos.Contatos = contatosResponse;

        return Task.FromResult(obterContatos);
    }
}
