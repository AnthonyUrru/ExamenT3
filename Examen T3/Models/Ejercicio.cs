using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Examen_T3.Models
{
    public class Ejercicio
    {
        public int Id { get; set; }
        public string NombreEjercicio { get; set; }
        public string LinkVideo { get; set; }
        public List<EjercicioRutine> ejercicioRutines { get; set; }
    }
}
