using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace backend_Tareas.Models
{
    public class Tarea
    {
        public int id { get; set; }
        [Required]
        [Column(TypeName ="varchar(100)")]
        public string nombre { get; set; }
        [Required]
        public bool estado { get; set; }
    }
}
