namespace Martes22.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Registros
    {
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Nombre { get; set; }

        [Required]
        [StringLength(50)]
        public string Apellidos { get; set; }

        [Required]
        [StringLength(50)]
        public string Pais { get; set; }

        public int edad { get; set; }

        public int Salario { get; set; }

        [Required]
        [StringLength(50)]
        public string Puesto { get; set; }
    }
}
