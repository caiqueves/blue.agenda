    using System.Threading;
    using System.Threading.Tasks;
    using Blue.Calculadora.RabbitMQ.Interfaces;
    using Blue.Calculadora.Domain.Handlers;
    using Blue.Calculadora.Shareable;
    using MediatR;
    using Moq;
    using Xunit;

namespace Blue.Calculadora.Domain.Tests
{

    public class AdicionarContatoHandlerTests
    {
        [Fact]
        public async Task Handle_ValidRequest_ReturnsSuccessResponse()
        {
            // Arrange
            var rabbitMQConnectionMock = new Mock<IConnectionRabbitMQ>();
            var handler = new AdicionarContatoHandler(rabbitMQConnectionMock.Object);

            var request = new AdicionarContatoRequest
            {
                // Defina os atributos do seu objeto de solicita��o aqui
            };

            rabbitMQConnectionMock.Setup(x => x.PublishMessage("Contato", request))
                                 .Returns(new OperacaoAgendaResponse { /* Defina os atributos necess�rios aqui */ });

            // Act
            var result = await handler.Handle(request, CancellationToken.None);

            // Assert
            Assert.NotNull(result);
            // Adicione mais verifica��es conforme necess�rio para garantir que o resultado esperado seja retornado.
        }

        [Fact]
        public async Task Handle_NullRequest_ThrowsRequestNullException()
        {
            // Arrange
            var rabbitMQConnectionMock = new Mock<IConnectionRabbitMQ>();
            var handler = new AdicionarContatoHandler(rabbitMQConnectionMock.Object);

            // Act & Assert
            await Assert.ThrowsAsync<RequestNullException>(() => handler.Handle(null, CancellationToken.None));
        }
    }
}
