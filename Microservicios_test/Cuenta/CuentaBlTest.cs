using FluentValidation.Results;
using Microservicios_bl;
using Microservicios_common.Common;
using Microservicios_dal;
using Moq;
using NUnit.Framework;

namespace Microservicios_test.CuentaTest
{
    public class CuentaBlTest
    {
        #region Properties
        CuentaBl cuentaBl;

        readonly Mock<ValidationResult> validationResultMock = new();  
        readonly Mock<ICuentaDal> cuentaDalMock = new();
        #endregion

        [SetUp]
        public void SetUp()
        {
            validationResultMock.Setup(x => x.IsValid).Returns(true);

            //Mockup exitoso
            cuentaDalMock.Setup(x => x.GetCuentas()).Returns(new List<CuentaDto> { new CuentaDto { Id = 1 } });
        }

        [Test]
        public void GetCuentas()
        {
            cuentaBl = new CuentaBl(cuentaDalMock.Object){};

            ResponseQuery<List<CuentaDto>> response = new();
            ResponseQuery<List<CuentaDto>> cuentaResponse = cuentaBl.GetCuentas(response);
            int expected = cuentaResponse.ObjetoResultado[0].Id;
            var actual = 1;
            Assert.AreEqual(expected, actual);
        }
    }
}
