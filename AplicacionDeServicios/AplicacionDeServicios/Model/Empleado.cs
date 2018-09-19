namespace AplicacionDeServicios.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Empleado")]
    public partial class Empleado
    {
        public int EmpleadoId { get; set; }

        public int Legajo { get; set; }

        [Required]
        [StringLength(50)]
        public string Nombre { get; set; }

        [Required]
        [StringLength(50)]
        public string Apellido { get; set; }

        [Required]
        [StringLength(10)]
        public string DNI { get; set; }

        [Required]
        [StringLength(20)]
        public string Telefono { get; set; }
    }
}
