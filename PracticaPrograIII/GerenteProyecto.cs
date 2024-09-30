using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticaPrograIII
{

    using System;

    public class GerenteProyecto : Empleado
    {
        public int CantidadProyectos { get; set; }
        public GerenteProyecto(string nombre, int cantidadProyectos) : base(nombre, "Gerente")
        {
            CantidadProyectos = cantidadProyectos;
        }

        public override int GetHorasTrabajadas()
        {
            // Aplica una bonificación del 10%
            return (int)(horasTrabajadas * 1.1);
        }
    }
}