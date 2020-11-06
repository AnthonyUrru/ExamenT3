using Microsoft.EntityFrameworkCore.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Examen_T3.Models.GenerarEjercicios
{
    public class Intermedio : InterfaceGenerar
    {
        public int num;
        public int generar()
        {
            
                Random random = new Random();
                 num = random.Next(1, 10);
            

            return num;
        }
    }
}
