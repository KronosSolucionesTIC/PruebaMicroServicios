using System.ComponentModel.DataAnnotations;

namespace Microservicios_dal
{
    public class MovimientoDto
    {
        #region Propiedades
        public int Id { get; set; }

        public DateTime? FechaMovimiento { get; set; }

        [StringLength(50)]
        public string? TipoMovimiento { get; set; } = String.Empty;

        public int? ValorMovimiento { get; set; }

        public int? SaldoMovimiento { get; set; }

        [StringLength(50)]
        public string? NumeroCuenta { get; set; } = String.Empty;

        [StringLength(50)]
        public string? TipoCuenta { get; set; } = String.Empty;

        public int? SaldoInicial { get; set; }

        [StringLength(5)]
        public string? EstadoCuenta { get; set; }
        #endregion
    }
}