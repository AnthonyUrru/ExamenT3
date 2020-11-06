using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Examen_T3.Models.GenerarEjercicios
{
    public class Avanzado : InterfaceGenerar
    {
        public int rnd;
        public int generar()
        {
            
                Random random = new Random();
                rnd = random.Next(1, 20);
          

            return rnd;
        }
    }
}
