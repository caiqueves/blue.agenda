using AutoMapper;
using Blue.Calculadora.Domain.Entity;
using Blue.Calculadora.Domain.Interfaces;
using Blue.Calculadora.Domain.Repositories;
using Blue.Calculadora.Shareable.Requests;
using Blue.Calculadora.Shareable.Responses;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Blue.Calculadora.Domain.Services
{

    public class MessageHandlingService : IMessageHandlingService
    {
        private readonly IContatoRepository _contatoRepository;
        private readonly IUsuarioRepository _usuarioRepository;
        private readonly IMapper _mapper;


        public MessageHandlingService(IContatoRepository contatoRepository, IUsuarioRepository usuarioRepository, IMapper mapper)
        {
            _contatoRepository = contatoRepository;
            _usuarioRepository = usuarioRepository;
            _mapper = mapper;
        }

        public void HandleMessage(string message)
        {
            var parsedMessage = JsonConvert.DeserializeObject<BaseRequest>(message);

            
            switch (parsedMessage?.TipoOperacao.ToLower())
            {
                case "adicionarcontato":
                     HandleAdicionarContato(JsonConvert.DeserializeObject<AdicionarContatoRequest>(message));
                    break;
                case "atualizarcontato":
                    HandleAtualizarContato(JsonConvert.DeserializeObject<AtualizarContatoRequest>(message));
                    break;
                case "removercontato":
                    HandleRemoveContato(JsonConvert.DeserializeObject<RemoverContatoRequest>(message));
                    break;
                case "cadastrousuario":
                    HandleCriarCadastro(JsonConvert.DeserializeObject<CriarCadastroRequest>(message));
                    break;
            }
            // Restante do código
        }

        private void HandleAdicionarContato(AdicionarContatoRequest? request)
        {
            try
            {
                var teste = this._mapper.Map<Contato>(request);
                var contato = new Contato
                {
                    Nome = request.Nome,
                    Telefone = request.Telefone,
                    Email = request.Email
                };

                 _contatoRepository.AddContatoAsync(contato);
            }
            catch (Exception ex)
            {
                new BaseResponse(false, $"Erro ao adicionar contato: {ex.Message}");
            }
        }

        private void HandleAtualizarContato(AtualizarContatoRequest? request)
        {
            try
            {
                var contato = _contatoRepository.GetContatoByIdAsync(request.ContatoId);

                if (contato == null)
                {
                    new BaseResponse(false, "Contato não encontrado.");
                }
                else
                {
                    contato.Nome = request.NovoNome ?? contato.Nome;
                    contato.Telefone = request.NovoTelefone ?? contato.Telefone;
                    contato.Email = request.NovoEmail ?? contato.Email;

                    _contatoRepository.UpdateContatoAsync(contato);
                }
            }
            catch (Exception ex)
            {
               new BaseResponse(false, $"Erro ao atualizar contato: {ex.Message}");
            }
        }

        private void HandleRemoveContato(RemoverContatoRequest? request)
        {
            try
            {
                var contato = _contatoRepository.GetContatoByIdAsync(request.ContatoId);

                if (contato == null)
                {
                    new BaseResponse(false, "Contato não encontrado.");
                }
                else
                {

                    _contatoRepository.DeleteContatoAsync(contato.Id);
                }

                new BaseResponse(true, "Contato removido com sucesso.");
            }
            catch (Exception ex)
            {
                new BaseResponse(false,"Erro ao remover contato: {ex.Message}");
            }
        }

        private void HandleCriarCadastro(CriarCadastroRequest? request)
        {
            try
            {
                var teste = this._mapper.Map<Usuario>(request);

                _usuarioRepository.AddUsuarioAsync(teste);

                new BaseResponse(true, "Cadastro criado com sucesso.");
            }
            catch (Exception ex)
            {
                new BaseResponse(false, $"Erro ao criar cadastro: {ex.Message}");
            }
        }
    }
}