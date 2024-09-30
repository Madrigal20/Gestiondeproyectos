// See https://aka.ms/new-console-template for more information
using PracticaPrograIII;

using System;
using System.Collections.Generic;

namespace PracticaPrograIII
{
    class Program
    {
        // Lista para almacenar los proyectos y los gerentes
        static List<Proyecto> proyectos = new List<Proyecto>();
        static List<GerenteProyecto> gerentes = new List<GerenteProyecto>();

        static void Main(string[] args)
        {
            bool continuar = true;

            while (continuar)
            {
                // Mostrar el menú principal
                Console.WriteLine("\nMenú Principal:");
                Console.WriteLine("1. Ingresar Proyecto");
                Console.WriteLine("2. Ingresar Gerente");
                Console.WriteLine("3. Imprimir Información");
                Console.WriteLine("4. Salir");
                Console.Write("Seleccione una opción: ");

                string opcion = Console.ReadLine();
                switch (opcion)
                {
                    case "1":
                        MenuIngresarProyecto();
                        break;
                    case "2":
                        MenuIngresarGerente();
                        break;
                    case "3":
                        ImprimirInformacion();
                        break;
                    case "4":
                        continuar = false;
                        Console.WriteLine("Saliendo del programa...");
                        break;
                    default:
                        Console.WriteLine("Opción no válida. Intente de nuevo.");
                        break;
                }
            }
        }

        static void MenuIngresarProyecto()
        {
            Console.WriteLine("\nIngrese los datos del proyecto:");

            Console.Write("Nombre del proyecto: ");
            string nombreProyecto = Console.ReadLine();

            DateTime fechaInicio = LeerFecha("Fecha de inicio");
            DateTime fechaFin = LeerFecha("Fecha de fin");

            Console.Write("Estado del proyecto (Activo, Finalizado, En Proceso): ");
            string estadoProyecto = Console.ReadLine();

            Proyecto nuevoProyecto = new Proyecto(nombreProyecto, fechaInicio, fechaFin, estadoProyecto);

            int numEmpleados = LeerEnteroPositivo("Ingrese el número de empleados que participan en el proyecto");

            for (int i = 0; i < numEmpleados; i++)
            {
                Console.WriteLine($"\nIngrese los datos del empleado {i + 1}:");

                Console.Write("Nombre del empleado: ");
                string nombreEmpleado = Console.ReadLine();

                Console.Write("Posición del empleado (Gerente, Desarrollador, Tester, etc.): ");
                string posicion = Console.ReadLine();

                int horasTrabajadas = LeerEnteroPositivo("Horas trabajadas por el empleado");

                Empleado nuevoEmpleado = new Empleado(nombreEmpleado, posicion);
                nuevoEmpleado.SetHorasTrabajadas(horasTrabajadas);
                nuevoProyecto.AgregarEmpleado(nuevoEmpleado);
            }

            proyectos.Add(nuevoProyecto);

            Console.WriteLine("\nGenerando y enviando reporte...");
            nuevoProyecto.GenerarReporte();
            nuevoProyecto.EnviarReporte();

            Console.WriteLine("Proyecto ingresado y reporte enviado exitosamente.");
        }

        static void MenuIngresarGerente()
        {
            Console.WriteLine("\nIngrese los datos del gerente:");

            Console.Write("Nombre del gerente: ");
            string nombreGerente = Console.ReadLine();

            int cantidadProyectos = LeerEnteroPositivo("Cantidad de proyectos que gestiona");

            GerenteProyecto nuevoGerente = new GerenteProyecto(nombreGerente, cantidadProyectos);
            gerentes.Add(nuevoGerente);

            Console.WriteLine("Gerente ingresado exitosamente.");
        }

        static void ImprimirInformacion()
        {
            Console.WriteLine("\nInformación de los Proyectos:");

            if (proyectos.Count > 0)
            {
                foreach (var proyecto in proyectos)
                {
                    proyecto.GenerarReporte();
                }
            }
            else
            {
                Console.WriteLine("No hay proyectos registrados.");
            }

            Console.WriteLine("\n Información de los Gerentes:");

            if (gerentes.Count > 0)
            {
                foreach (var gerente in gerentes)
                {
                    Console.WriteLine($"Gerente: {gerente.GetNombre()}, Proyectos que gestiona: {gerente.CantidadProyectos}");
                }
            }
            else
            {
                Console.WriteLine(" No hay gerentes registrados.");
            }
        }
        //Validación del formato de la fecha
        static DateTime LeerFecha(string mensaje)
        {
            DateTime fecha;
            while (true)
            {
                Console.Write($"{mensaje} (formato: Día-Mes-Año): ");
                if (DateTime.TryParse(Console.ReadLine(), out fecha))
                {
                    return fecha;
                }
                Console.WriteLine("Formato de fecha inválido. Por favor, intente de nuevo.");
            }
        }

        static int LeerEnteroPositivo(string mensaje)
        {
            int numero;
            while (true)
            {
                Console.Write($"{mensaje}: ");
                if (int.TryParse(Console.ReadLine(), out numero) && numero >= 0)
                {
                    return numero;
                }
                Console.WriteLine("Por favor, ingrese un número entero no negativo.");
            }
        }
    }
}