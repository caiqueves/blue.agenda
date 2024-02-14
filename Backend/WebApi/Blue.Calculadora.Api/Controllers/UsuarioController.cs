using Blue.Calculadora.Shareable.Requests;
using Blue.Calculadora.Shareable.Responses;
using MediatR;
using Microsoft.AspNetCore.Mvc;


[ApiController]
[Route("api/[controller]")]
public class UsuarioController : ControllerBase
{
    private readonly IMediator _mediator;

    public UsuarioController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost("CriarCadastro")]
    public async Task<ActionResult<OperacaoAgendaResponse>> CriarCadastro(string nome, string login, string senha, string? tipoOperacao)
    {
        var request = new CriarCadastroRequest(nome, login, senha, tipoOperacao);
        var validator = new CriarCadastroRequestValidator();
        var validationResult = validator.Validate(request);

        if (!validationResult.IsValid)
        {
            // Se a validação falhar, retorne um BadRequest com mensagens personalizadas
            var errors = validationResult.Errors.Select(e => e.ErrorMessage);
            return BadRequest(errors);
        }
        OperacaoAgendaResponse result = await _mediator.Send(request);

        // Se a autenticação falhar, retorne um AuthenticationResult nulo ou um resultado personalizado
        return result; // Ou qualquer resultado que você queira retornar em caso de falha
    }

    [HttpPost("Authenticate")]
    public async Task<ActionResult<AuthenticationResult>> Authenticate([FromBody] AuthenticationRequest authenticationRequest)
    {
        //var request = new AuthenticationRequest(username, password);
        var validator = new AuthenticationRequestValidator();
        var validationResult = validator.Validate(authenticationRequest);

        if (!validationResult.IsValid)
        {
            // Se a validação falhar, retorne um BadRequest com mensagens personalizadas
            var errors = validationResult.Errors.Select(e => e.ErrorMessage);
            return BadRequest(errors);
        }
        AuthenticationResult result = await _mediator.Send(authenticationRequest);

        // Se a autenticação falhar, retorne um AuthenticationResult nulo ou um resultado personalizado
        return result; // Ou qualquer resultado que você queira retornar em caso de falha
    }
}