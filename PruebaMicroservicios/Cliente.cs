using System.ComponentModel.DataAnnotations;

namespace PruebaMicroservicios
{
    public class Cliente
    {
        #region Propiedades
        public int Id { get; set; }

        [StringLength(50)]
        public string NombrePersona { get; set; } = String.Empty;

        [StringLength(50)]
        public string GeneroPersona { get; set; } = String.Empty;

        public int EdadPersona { get; set; }

        [StringLength(50)]
        public string IdentificacionPersona { get; set; } = String.Empty;

        [StringLength(200)]
        public string DireccionPersona { get; set; } = String.Empty;

        [StringLength(50)]
        public string TelefonoPersona { get; set; } = String.Empty;

        [StringLength(50)]
        public string PassCliente { get; set; } = String.Empty;

        [StringLength(5)]
        public string EstadoCliente { get; set; } = String.Empty;

        #endregion
    }
}