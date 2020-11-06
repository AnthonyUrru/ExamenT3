using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Examen_T3.Models
{
    public class Rutine
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Tipo { get; set; }
        public int UserId { get; set; }
        public List<EjercicioRutine> ejercicioRutines { get; set; }
        
    }
}
