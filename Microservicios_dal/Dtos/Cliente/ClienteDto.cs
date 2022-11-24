using System.ComponentModel.DataAnnotations;

namespace Microservicios_dal
{
    public class ClienteDto : Persona
    {
        #region Propiedades
        public int Id { get; set; }

        [StringLength(50)]
        public string? PassCliente { get; set; } = String.Empty;

        [StringLength(5)]
        public string? EstadoCliente { get; set; } = String.Empty;

        #endregion
    }
}