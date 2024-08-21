using System.ComponentModel.DataAnnotations.Schema;

namespace Clase1.Models
{
    public class Empleado : BaseEntity
    {

        public string Nombre { get; set; }

        public string Apellido { get; set; }

        public string Email { get; set; }

        public string Dui { get; set; }

        public string NumeroTelefonico { get; set; }

        [ForeignKey ("TipoEmpleado")]

        public int TipoEmpleadoId { get; set; }

        //public TipoEmpleado TipoEmpleado { get; set; }
    }
}
