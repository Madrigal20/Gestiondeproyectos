using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticaPrograIII
{
    using System;

    public class Empleado
    {
        protected string nombre; // Protected para acceder desde clases derivadas
        protected string posicion;
        protected int horasTrabajadas;

        public Empleado(string nombre, string posicion)
        {
            this.nombre = nombre;
            this.posicion = posicion;
            horasTrabajadas = 0;
        }

        public string GetNombre()
        {
            return nombre;
        }

        public string GetPosicion()
        {
            return posicion;
        }

        public virtual int GetHorasTrabajadas() 
        {
            return horasTrabajadas;
        }

        public void SetHorasTrabajadas(int horas)
        {
            try
            {
                if (horas < 0)
                    throw new ArgumentException("Las horas trabajadas no pueden ser negativas.");
                horasTrabajadas = horas;
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}