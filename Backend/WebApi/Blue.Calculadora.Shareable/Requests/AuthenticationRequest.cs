using Blue.Calculadora.Shareable.Responses;
using MediatR;

namespace Blue.Calculadora.Shareable.Requests
{
    public class AuthenticationRequest : IRequest<AuthenticationResult>
    {
        public string Username { get; set; }
        public string Password { get; set; }

        public AuthenticationRequest(string username, string password)
        {
            Username = username;
            Password = password;
        }
    }
}


