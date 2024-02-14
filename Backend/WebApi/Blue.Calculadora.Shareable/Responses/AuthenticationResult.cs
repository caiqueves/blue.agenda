namespace Blue.Calculadora.Shareable.Responses
{
    public class AuthenticationResult
    {
        public bool Success { get; set; }
        public string? Token { get; set; }
        // Outras informações sobre o usuário, se necessário
    }
}
