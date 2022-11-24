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
        #endregion
    }
}