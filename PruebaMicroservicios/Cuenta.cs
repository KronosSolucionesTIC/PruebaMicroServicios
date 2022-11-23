using System.ComponentModel.DataAnnotations;

namespace PruebaMicroservicios
{
    public class Cuenta
    {
        #region Propiedades
        public int Id { get; set; }

        [StringLength(50)]
        public string NumeroCuenta { get; set; } = String.Empty;

        [StringLength(50)]
        public string TipoCuenta { get; set; } = String.Empty;

        public int SaldoInicial { get; set; }

        [StringLength(5)]
        public string EstadoCuenta { get; set; }
        #endregion
    }
}
