using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticaPrograIII
{
    public class Proyecto : IReporteable
    {
        public string NombreProyecto { get; set; }
        public DateTime FechaInicio { get; set; }
        public DateTime FechaFin { get; set; }
        public string EstadoProyecto { get; set; }
        private List<Empleado> empleados;

        public Proyecto(string nombre, DateTime inicio, DateTime fin, string estado)
        {
            NombreProyecto = nombre;
            FechaInicio = inicio;
            FechaFin = fin;
            EstadoProyecto = estado;
            empleados = new List<Empleado>();
        }

        // Método para agregar empleados al proyecto
        public void AgregarEmpleado(Empleado empleado)
        {
            empleados.Add(empleado);
        }

        // Método para calcular las horas totales trabajadas en el proyecto
        public int CalcularHorasTotales()
        {
            int totalHoras = 0;
            foreach (Empleado emp in empleados)
            {
                totalHoras += emp.GetHorasTrabajadas();
            }
            return totalHoras;
        }

        // Método para generar un reporte
        public void GenerarReporte()
        {
            Console.WriteLine($"Reporte del Proyecto: {NombreProyecto}");
            Console.WriteLine($"Estado: {EstadoProyecto}");
            Console.WriteLine("Empleados asignados:");
            foreach (Empleado emp in empleados)
            {
                Console.WriteLine($"{emp.GetNombre()} - Horas trabajadas: {emp.GetHorasTrabajadas()}");
            }
            Console.WriteLine($"Total horas trabajadas: {CalcularHorasTotales()}");
        }

        // Método para simular el envío del reporte
        public void EnviarReporte()
        {
            Console.WriteLine("El reporte ha sido enviado al gerente.");
        }
    }
}
public interface IReporteable
{
    void GenerarReporte();
    void EnviarReporte();
}