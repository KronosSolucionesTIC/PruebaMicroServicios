using FluentValidation.Results;
using Microservicios_bl;
using Microservicios_common.Common;
using Microservicios_dal;
using Moq;
using NUnit.Framework;

namespace Microservicios_test.MovimientoTest
{
    public class MovimientoBlTest
    {
        #region Properties
        MovimientoBl movimientoBl;

        readonly Mock<ValidationResult> validationResultMock = new();  
        readonly Mock<IMovimientoDal> movimientoDalMock = new();
        #endregion

        [SetUp]
        public void SetUp()
        {
            validationResultMock.Setup(x => x.IsValid).Returns(true);

            //Mockup exitoso
            movimientoDalMock.Setup(x => x.GetMovimientos()).Returns(new List<MovimientoDto> { new MovimientoDto { Id = 1 } });
        }

        [Test]
        public void GetMovimientos()
        {
            movimientoBl = new MovimientoBl(movimientoDalMock.Object){};

            ResponseQuery<List<MovimientoDto>> response = new();
            ResponseQuery<List<MovimientoDto>> movimientoResponse = movimientoBl.GetMovimientos(response);
            int expected = movimientoResponse.ObjetoResultado[0].Id;
            var actual = 1;
            Assert.AreEqual(expected, actual);
        }
    }
}
