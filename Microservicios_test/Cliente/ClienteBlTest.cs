using FluentValidation.Results;
using Microservicios_bl;
using Microservicios_common.Common;
using Microservicios_dal;
using Moq;
using NUnit.Framework;

namespace Microservicios_test.ClienteTest
{
    public class ClienteBlTest
    {
        #region Properties
        ClienteBl clienteBl;

        readonly Mock<ValidationResult> validationResultMock = new();
        readonly Mock<IClienteDal> clienteDalMock = new();
        #endregion

        [SetUp]
        public void SetUp()
        {
            validationResultMock.Setup(x => x.IsValid).Returns(true);

            //Mockup exitoso
            clienteDalMock.Setup(x => x.GetClientes()).Returns(new List<ClienteDto> { new ClienteDto { Id = 1 } });
        }

        [Test]
        public void GetClientes()
        {
            clienteBl = new ClienteBl(clienteDalMock.Object){};

            ResponseQuery<List<ClienteDto>> response = new();
            ResponseQuery<List<ClienteDto>> clienteResponse = clienteBl.GetClientes(response);
            int expected = clienteResponse.ObjetoResultado[0].Id;
            var actual = 1;
            Assert.AreEqual(expected, actual);
        }
    }
}
