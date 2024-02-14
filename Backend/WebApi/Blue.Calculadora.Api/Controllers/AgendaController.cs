using Blue.Calculadora.Domain.Entity;
using Blue.Calculadora.Shareable.Requests;
using Blue.Calculadora.Shareable.Responses;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;


[ApiController]
[Route("api/[controller]")]
public class AgendaController : ControllerBase
{
    private readonly IMediator _mediator;

    public AgendaController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost("AdicionarContato")]
    public async Task<ActionResult<OperacaoAgendaResponse>> AdicionarContato([FromBody] AdicionarContatoRequest adicionarContatoRequest)
    {
        try
        {
            //var request = new AdicionarContatoRequest(nome, telefone, email, tipoOperacao);
            var validator = new AdicionarContatoRequestValidator();
            var validationResult = validator.Validate(adicionarContatoRequest);

            if (!validationResult.IsValid)
            {
                // Se a validação falhar, retorne um BadRequest com mensagens personalizadas
                var errors = validationResult.Errors.Select(e => e.ErrorMessage);
                return BadRequest(errors);
            }
            var resultado = await _mediator.Send(adicionarContatoRequest);

            return resultado;
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Erro ao publicar a mensagem: {ex.Message}");
        }
    }

    [HttpGet("BuscarContatoPorId")]
    public async Task<ActionResult<ObterContatoResponse>> BuscarCadastroPorId(int contatoId, string tipoOperacao)
    {
        try
        {
            var request = new ObterContatoRequest(contatoId, tipoOperacao);
            var validator = new ObterContatoRequestValidator();
            var validationResult = validator.Validate(request);

            if (!validationResult.IsValid)
            {
                // Se a validação falhar, retorne um BadRequest com mensagens personalizadas
                var errors = validationResult.Errors.Select(e => e.ErrorMessage);
                return BadRequest(errors);
            }
            var retorno = await _mediator.Send(request);

            return retorno;
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Erro ao publicar a mensagem: {ex.Message}");
        }
    }

    [HttpGet("BuscarContatos")]
    public async Task<ActionResult<ObterContatosResponse>> BuscarCadastros()
    {
        try
        {
            var retorno = await _mediator.Send(new ObterContatosRequest(1, "teste"));

            return retorno;
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Erro ao publicar a mensagem: {ex.Message}");
        }
    }


    [HttpPut("AtualizarContato")]
    public async Task<ActionResult<OperacaoAgendaResponse>> AtualizarCadastro([FromBody] AtualizarContatoRequest atualizarContatoRequest)
    {
        try
        {   //var request = new AtualizarContatoRequest(contatoId,novoNome, novoTelefone, novoEmail, tipoOperacao);
            var validator = new AtualizarContatoRequestValidator();
            var validationResult = validator.Validate(atualizarContatoRequest);

            if (!validationResult.IsValid)
            {
                // Se a validação falhar, retorne um BadRequest com mensagens personalizadas
                var errors = validationResult.Errors.Select(e => e.ErrorMessage);
                return BadRequest(errors);
            }
            var retorno = await _mediator.Send(atualizarContatoRequest);

            return retorno;
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Erro ao publicar a mensagem: {ex.Message}");
        }
    }

    [HttpPatch("AtualizarPatch/{id}")]
    public async Task<ActionResult<OperacaoAgendaResponse>> AtualizarPatch(int id, [FromBody] JsonPatchDocument<AtualizarContatoRequest> patchDocument)
    {
        if (patchDocument == null)
        {
            return BadRequest();
        }

        var obterRequest = new ObterContatoRequest(id, "Obter");
        var entidade = await _mediator.Send(obterRequest);

        if (entidade == null)
        {
            return NotFound();
        }

        var atualizar = new AtualizarContatoRequest();
        patchDocument.ApplyTo(atualizar);

        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        // Lógica de atualização aqui (substitua pelo código relevante)
        var resultadoAtualizacao = await _mediator.Send(atualizar);

        if (resultadoAtualizacao != null)
        {
            return NoContent();
        }
        else
        {
            // Lógica para lidar com falhas na atualização
            return StatusCode(500, "Falha na atualização do contato.");
        }
    }


    [HttpDelete("RemoverContato")]
    public async Task<ActionResult<OperacaoAgendaResponse>> RemoverCadastro([FromBody] RemoverContatoRequest removerContatoRequest)
    {
        try
        {
            //var request = new RemoverContatoRequest(contatoId, tipoOperacao);
            var validator = new RemoverContatoRequestValidator();
            var validationResult = validator.Validate(removerContatoRequest);

            if (!validationResult.IsValid)
            {
                // Se a validação falhar, retorne um BadRequest com mensagens personalizadas
                var errors = validationResult.Errors.Select(e => e.ErrorMessage);
                return BadRequest(errors);
            }
            var retorno = await _mediator.Send(removerContatoRequest);

            return retorno;
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Erro ao publicar a mensagem: {ex.Message}");
        }
    }
}
