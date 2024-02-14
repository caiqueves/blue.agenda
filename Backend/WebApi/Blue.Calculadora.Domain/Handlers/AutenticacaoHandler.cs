using Blue.Calculadora.Domain.Repositories;
using Blue.Calculadora.Shareable.Exceptions;
using Blue.Calculadora.Shareable.Requests;
using Blue.Calculadora.Shareable.Responses;
using MediatR;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

public class AutenticacaoHandler : IRequestHandler<AuthenticationRequest, AuthenticationResult>
{
    private readonly IUsuarioRepository _usuarioRepository;
    public AutenticacaoHandler(IUsuarioRepository usuarioRepository)
    {
        _usuarioRepository = usuarioRepository;
    }
    public Task<AuthenticationResult> Handle(AuthenticationRequest request, CancellationToken cancellationToken)
    {
        
        AuthenticationResult result =  new AuthenticationResult();

        bool authenticationSuccess = PerformAuthentication(request.Username, request.Password);

       
        if (authenticationSuccess)
        {
            result.Success = true;
            result.Token = GenerateTokenForUser(request.Username);
        }
        else
        {
            result.Success = false;
            result.Token = "";
        }

        return Task.FromResult(result);
    }


    private bool PerformAuthentication(string username, string password)
    {
        var usuario = _usuarioRepository.GetUsuarioByLoginSenha(username, password);

        if(usuario == null)
        {
            throw new ContatoNaoEncontradoException("Cadastro não localizado");
        }
        return true;
    }

    //private string GenerateTokenForUser(string username)
    //{
    //    var tokenHandler = new JwtSecurityTokenHandler();
    //    var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("8q24g9zAtn32vS1yf5wKuXlF3oPbRdIh"));
    //    var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

    //    var token = new JwtSecurityToken(
    //        issuer: "Blue.Calculadora.WebApi",                  // Emissor (issuer)
    //        audience: "UsuarioBackoffice",               // Audiência (audience)
    //        claims: new[]
    //        {
    //            new Claim(ClaimTypes.Name, username.ToString()),
    //            new Claim(ClaimTypes.Role, "admin")
    //        },
    //        expires: DateTime.UtcNow.AddHours(1), // Tempo de expiração
    //        signingCredentials: credentials
    //    );

        
    //    return tokenHandler.WriteToken(token);
    //}

    private string GenerateTokenForUser(string username)
    {
        var tokenHandler = new JwtSecurityTokenHandler();
        var key = Encoding.ASCII.GetBytes("8q24g9zAtn32vS1yf5wKuXlF3oPbRdIh");
        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity(new Claim[]
            {
                    new Claim(ClaimTypes.Name, username.ToString()),
                    new Claim(ClaimTypes.Role, "Admin")
            }),
            Expires = DateTime.UtcNow.AddHours(2),
            SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
        };
        var token = tokenHandler.CreateToken(tokenDescriptor);
        return tokenHandler.WriteToken(token);
    }
}
