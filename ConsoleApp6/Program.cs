using System;
using System.Collections.Generic;

public class Cliente
{
    public string Nombre { get; set; }
    public int Edad { get; set; }
    public string Correo { get; set; }

    public virtual void MostrarInformacion()
    {
        Console.WriteLine($"Nombre: {Nombre}, Edad: {Edad}, Correo: {Correo}");
    }
}

public class ClienteCorporativo : Cliente
{
    public string NombreEmpresa { get; set; }

    public override void MostrarInformacion()
    {
        base.MostrarInformacion();
        Console.WriteLine($"Nombre de la empresa: {NombreEmpresa}");
    }
}

public class Tarea
{
    public string Titulo { get; set; }
    public string Descripcion { get; set; }
    public DateTime FechaLimite { get; set; }

    public virtual void MostrarDetalles()
    {
        Console.WriteLine($"Título: {Titulo}, Descripción: {Descripcion}, Fecha límite: {FechaLimite:dd/MM/yyyy}");
    }
}

public class TareaUrgente : Tarea
{
    public string NivelUrgencia { get; set; }

    public override void MostrarDetalles()
    {
        base.MostrarDetalles();
        Console.WriteLine($"Nivel de urgencia: {NivelUrgencia}");
    }
}

class Program
{
    static List<Cliente> clientes = new List<Cliente>();
    static List<Tarea> tareas = new List<Tarea>();

    static void Main(string[] args)
    {
        while (true)
        {
            Console.WriteLine("Seleccione una opción:");
            Console.WriteLine("1. Caso 1: Sistema de Registro de Clientes");
            Console.WriteLine("2. Caso 2: Sistema de Seguimiento de Tareas");
            Console.WriteLine("3. Salir");

            if (int.TryParse(Console.ReadLine(), out int opcion))
            {
                switch (opcion)
                {
                    case 1:
                        Caso1();
                        break;
                    case 2:
                        Caso2();
                        break;
                    case 3:
                        return;
                    default:
                        Console.WriteLine("Opción inválida");
                        break;
                }
            }
            else
            {
                Console.WriteLine("Entrada no válida. Por favor, ingrese un número.");
            }
        }
    }

    static void Caso1()
    {
        while (true)
        {
            Console.WriteLine("Menú de opciones:");
            Console.WriteLine("1. Agregar cliente");
            Console.WriteLine("2. Listar clientes");
            Console.WriteLine("3. Volver al menú principal");

            if (int.TryParse(Console.ReadLine(), out int opcion))
            {
                switch (opcion)
                {
                    case 1:
                        AgregarCliente();
                        break;
                    case 2:
                        ListarClientes();
                        break;
                    case 3:
                        return;
                    default:
                        Console.WriteLine("Opción inválida");
                        break;
                }
            }
            else
            {
                Console.WriteLine("Entrada no válida. Por favor, ingrese un número.");
            }
        }
    }

    static void AgregarCliente()
    {
        Console.Write("Ingrese el nombre del cliente: ");
        string nombre = Console.ReadLine();

        int edad;
        while (true)
        {
            Console.Write("Ingrese la edad del cliente: ");
            if (int.TryParse(Console.ReadLine(), out edad))
            {
                break;
            }
            else
            {
                Console.WriteLine("Edad no válida. Por favor, ingrese un número.");
            }
        }

        Console.Write("Ingrese el correo del cliente: ");
        string correo = Console.ReadLine();

        Console.Write("¿Es un cliente corporativo? (s/n): ");
        string respuesta = Console.ReadLine();

        if (respuesta.ToLower() == "s")
        {
            Console.Write("Ingrese el nombre de la empresa: ");
            string nombreEmpresa = Console.ReadLine();

            ClienteCorporativo clienteCorporativo = new ClienteCorporativo
            {
                Nombre = nombre,
                Edad = edad,
                Correo = correo,
                NombreEmpresa = nombreEmpresa
            };

            clientes.Add(clienteCorporativo);
        }
        else
        {
            Cliente cliente = new Cliente
            {
                Nombre = nombre,
                Edad = edad,
                Correo = correo
            };

            clientes.Add(cliente);
        }
    }

    static void ListarClientes()
    {
        if (clientes.Count == 0)
        {
            Console.WriteLine("No hay clientes registrados.");
        }
        else
        {
            foreach (var cliente in clientes)
            {
                cliente.MostrarInformacion();
                Console.WriteLine();
            }
        }
    }

    static void Caso2()
    {
        while (true)
        {
            Console.WriteLine("Menú de opciones:");
            Console.WriteLine("1. Agregar tarea");
            Console.WriteLine("2. Ver tareas");
            Console.WriteLine("3. Volver al menú principal");

            if (int.TryParse(Console.ReadLine(), out int opcion))
            {
                switch (opcion)
                {
                    case 1:
                        AgregarTarea();
                        break;
                    case 2:
                        VerTareas();
                        break;
                    case 3:
                        return;
                    default:
                        Console.WriteLine("Opción inválida");
                        break;
                }
            }
            else
            {
                Console.WriteLine("Entrada no válida. Por favor, ingrese un número.");
            }
        }
    }

    static void AgregarTarea()
    {
        Console.Write("Ingrese el título de la tarea: ");
        string titulo = Console.ReadLine();

        Console.Write("Ingrese la descripción de la tarea: ");
        string descripcion = Console.ReadLine();

        DateTime fechaLimite;
        while (true)
        {
            Console.Write("Ingrese la fecha límite de la tarea (dd/MM/yyyy): ");
            if (DateTime.TryParseExact(Console.ReadLine(), "dd/MM/yyyy", null, System.Globalization.DateTimeStyles.None, out fechaLimite))
            {
                break;
            }
            else
            {
                Console.WriteLine("Fecha no válida. Por favor, ingrese la fecha en el formato dd/MM/yyyy.");
            }
        }

        Console.Write("¿Es una tarea urgente? (s/n): ");
        string respuesta = Console.ReadLine();

        if (respuesta.ToLower() == "s")
        {
            Console.Write("Ingrese el nivel de urgencia: ");
            string nivelUrgencia = Console.ReadLine();

            TareaUrgente tareaUrgente = new TareaUrgente
            {
                Titulo = titulo,
                Descripcion = descripcion,
                FechaLimite = fechaLimite,
                NivelUrgencia = nivelUrgencia
            };

            tareas.Add(tareaUrgente);
        }
        else
        {
            Tarea tarea = new Tarea
            {
                Titulo = titulo,
                Descripcion = descripcion,
                FechaLimite = fechaLimite
            };

            tareas.Add(tarea);
        }
    }

    static void VerTareas()
    {
        if (tareas.Count == 0)
        {
            Console.WriteLine("No hay tareas registradas.");
        }
        else
        {
            foreach (var tarea in tareas)
            {
                tarea.MostrarDetalles();
                Console.WriteLine();
            }
        }
    }
}
