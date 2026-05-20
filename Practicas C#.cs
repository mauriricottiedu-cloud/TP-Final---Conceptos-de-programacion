using System;
using System.Diagnostics;

namespace HotelReservas
{
    struct Reserva
    {
        public string fechaIngreso;
        public int plazasReservadas;
        public int cantidadNoches;
        public double costoPorNoche;
    };

    struct Cliente
    {
        public string nombre;
        public string apellido;
        public string DNI;
        public string telefono;
        public string email;
        public string localidad;
        public Reserva[] reservas;
        public int cantidadReservas;
    };


    class Program
    {
        static void Main(string[] args)
        {
            Cliente[] listaClientes = new Cliente[100];
            int cantidadClientes = 0;
            string opcion = "";

            while (opcion != "5")
            {
                menuPrincipal();

                Console.WriteLine();
                Console.Write("Seleccione una opción: ");
                opcion = Console.ReadLine() ?? "";

                switch (opcion)
                {
                    case "1":
                        cargarClientes(listaClientes, ref cantidadClientes);
                        break;

                    case "2":
                        buscarCliente(listaClientes, cantidadClientes);
                        break;

                    case "3":
                        buscarReserva(listaClientes, cantidadClientes);
                        break;

                    case "4":
                        nuevaReserva(listaClientes, cantidadClientes);
                        break;

                    case "5":
                        Console.WriteLine("Saliendo del programa...");
                        break;

                    default:
                        Console.WriteLine("Opcion no valida.");
                        break;
                }

                Console.WriteLine();
                Console.WriteLine("Presione cualquier tecla para continuar...");
                Console.ReadKey();
            }

        }

        // MENÚ PRINCIPÁL
        static void menuPrincipal()
        {
            Console.Clear();
            Console.WriteLine("========== MENÚ PRINCIPAL ==========");
            Console.WriteLine();

            Console.WriteLine("1. Cargar datos");
            Console.WriteLine("2. Buscar cliente");
            Console.WriteLine("3. Buscar reserva");
            Console.WriteLine("4. Nueva reserva");
            Console.WriteLine("5. Salir del programa");
        }

        // SUBMENÚ (OPCION 4 DEL MENÚ PRINCIPÁL).
        static void subMenu()
        {
            Console.Clear();
            Console.WriteLine("========== SUBMENÚ ==========");
            Console.WriteLine();

            Console.WriteLine("1. Cargar nueva reserva");
            Console.WriteLine("2. Modificar reserva");
            Console.WriteLine("3. Cancelar reserva");
            Console.WriteLine("4. Volver al menú principal");
        }

        // PRIMER MODULO: CARGAR CLIENTE AL SISTEMA.
        static void cargarClientes(Cliente[] listaClientes, ref int cantidadClientes)
        {
            if (cantidadClientes >= 100)
            {
                Console.WriteLine("Llegaste al limite de carga de clientes. Elimina algunos antes de continuar.");
                return;
            }

            Console.Clear();
            Console.WriteLine("=== Cargando cliente ===");
            Console.WriteLine();

            Console.Write("Ingrese el nombre: ");
            listaClientes[cantidadClientes].nombre = Console.ReadLine() ?? "";

            Console.Write("Ingrese el apellido: ");
            listaClientes[cantidadClientes].apellido = Console.ReadLine() ?? "";

            Console.Write("Ingrese el DNI: ");
            listaClientes[cantidadClientes].DNI = Console.ReadLine() ?? "";

            Console.Write("Ingrese el email:");
            listaClientes[cantidadClientes].email = Console.ReadLine() ?? "";

            Console.Write("Ingrese el telefono: ");
            listaClientes[cantidadClientes].telefono = Console.ReadLine() ?? "";

            Console.Write("Ingrese la localidad: ");
            listaClientes[cantidadClientes].localidad = Console.ReadLine() ?? "";

            listaClientes[cantidadClientes].reservas = new Reserva[100];
            listaClientes[cantidadClientes].cantidadReservas = 0;

            cantidadClientes++;

            Console.WriteLine();
            Console.WriteLine("Cliente agregado correctamente.");
        }

        // MODULO 2: BUSCAR CLIENTE MEDIANTE DNI.
        static void buscarCliente(Cliente[] listaClientes, int cantidadClientes)
        {

            Console.Clear();
            Console.WriteLine("=== Buscnado cliente ===");
            Console.WriteLine();
            Console.Write("Ingrese el DNI a buscar: ");
            string dniBuscado = Console.ReadLine() ?? "";

            for (int i = 0; i < cantidadClientes; i++)
            {
                if (listaClientes[i].DNI == dniBuscado)
                {
                    Console.Clear();
                    Console.WriteLine("Cliente encontrado:");
                    Console.WriteLine();

                    Console.WriteLine("Nombre: " + listaClientes[i].nombre);
                    Console.WriteLine("Apellido: " + listaClientes[i].apellido);
                    Console.WriteLine("DNI: " + listaClientes[i].DNI);
                    Console.WriteLine("Telefono: " + listaClientes[i].telefono);
                    Console.WriteLine("Email: " + listaClientes[i].email);
                    Console.WriteLine("Localidad: " + listaClientes[i].localidad);
                    return;
                }
            }
            Console.WriteLine($"No se encontro al cliente: {dniBuscado}.");
        }


        // MODULO 3: BUSCAR RESERVA DEL CLIENTE.
        static void buscarReserva(Cliente[] listaClientes, int cantidadClientes)
        {
            Console.Clear();
            Console.WriteLine("=== Buscando reservas del cliente ===");
            Console.WriteLine("");

            Console.Write("Ingrese el DNI a buscar: ");
            string dniBuscado = Console.ReadLine() ?? "";

            for (int i = 0; i < cantidadClientes; i++)
            {
                if (listaClientes[i].DNI == dniBuscado)
                {
                    Console.WriteLine();
                    Console.WriteLine("Cliente encontrado: " + listaClientes[i].nombre + " " + listaClientes[i].apellido);

                    if (listaClientes[i].cantidadReservas == 0)
                    {
                        Console.WriteLine();
                        Console.WriteLine("El cliente" + listaClientes[i].nombre + " no tiene reservas cargadas.");
                        return;
                    }

                    for (int j = 0; j < listaClientes[i].cantidadReservas; j++)
                    {
                        Console.WriteLine("Reserva " + (j + 1));
                        Console.WriteLine("Fecha de ingreso: " + listaClientes[i].reservas[j].fechaIngreso);
                        Console.WriteLine("Plazas reservadas: " + listaClientes[i].reservas[j].plazasReservadas);
                        Console.WriteLine("Cantidad de noches: " + listaClientes[i].reservas[j].cantidadNoches);
                        Console.WriteLine("Costo por noche: " + listaClientes[i].reservas[j].costoPorNoche);
                        Console.WriteLine("----------------------");

                    }
                    return;
                }

            }
            Console.WriteLine($"No se encontro al cliente: {dniBuscado}.");
        }

        // MODULO 4: CREAR NUEVA RESERVA PARA UN CLIENTE.
        static void nuevaReserva(Cliente[] listaClientes, int cantidadClientes)
        {
            string opcion = "";

            while (opcion != "4")
            {
                subMenu();

                Console.WriteLine();
                Console.Write("Seleccione una opcion: ");
                opcion = Console.ReadLine() ?? "";

                switch (opcion)
                {
                    case "1":
                        cargarNuevaReserva(listaClientes, cantidadClientes);
                        break;

                    case "2":
                        modificarReserva(listaClientes, ref cantidadClientes);
                        break;

                    case "3":
                        cancelarReserva(listaClientes, ref cantidadClientes);
                        break;

                    case "4":
                        Console.WriteLine("Volviendo al menu principal...");
                        break;

                    default:
                        Console.WriteLine("Opcion no valida.");
                        break;
                }
                if (opcion != "4")
                {
                    Console.WriteLine("Presiona cualquier tecla para continuar...");
                    Console.ReadKey();
                }
            }
        }

        static void cargarNuevaReserva(Cliente[] listaClientes, int cantidadClientes)
        {
            Console.Clear();
            Console.WriteLine("=== Cargando nueva reserva ===");
            Console.WriteLine();

            Console.Write("Ingrese el DNI del cliente: ");
            string dniBuscado = Console.ReadLine() ?? "";

            for (int i = 0; i < cantidadClientes; i++)
            {
                if (listaClientes[i].DNI == dniBuscado)
                {
                    Console.WriteLine("Cliente encontrado: " + listaClientes[i].nombre + " " + listaClientes[i].apellido);

                    int posicionReserva = listaClientes[i].cantidadReservas;

                    Console.Write("Ingrese la fecha de ingreso: ");
                    string fecha = Console.ReadLine() ?? "";
                    listaClientes[i].reservas[posicionReserva].fechaIngreso = fecha;

                    Console.Write("Ingrese la cantidad de plazas: ");
                    int plazas = int.Parse(Console.ReadLine() ?? "0");
                    listaClientes[i].reservas[posicionReserva].plazasReservadas = plazas;

                    string fechaNueva = listaClientes[i].reservas[posicionReserva].fechaIngreso;
                    int plazasReservadasEnFecha = 0;

                    for (int cliente = 0; cliente < cantidadClientes; cliente++)
                    {
                        for (int reserva = 0; reserva < listaClientes[cliente].cantidadReservas; reserva++)
                        {
                            string fechaReservaExistente = listaClientes[cliente].reservas[reserva].fechaIngreso;

                            if (fechaReservaExistente == fechaNueva)
                            {
                                plazasReservadasEnFecha = plazasReservadasEnFecha + listaClientes[cliente].reservas[reserva].plazasReservadas;
                            }
                        }
                    }

                    int totalPlazas = plazasReservadasEnFecha + plazas;

                    if (totalPlazas > 40)
                    {
                        Console.WriteLine("No hay plazas suficientes para esa fecha.");
                        return;
                    }

                    Console.Write("Ingrese la cantidad de noches: ");
                    int noches = int.Parse(Console.ReadLine() ?? "0");
                    listaClientes[i].reservas[posicionReserva].cantidadNoches = noches;

                    Console.Write("Ingrese el costo por noche: ");
                    double costo = double.Parse(Console.ReadLine() ?? "0");
                    listaClientes[i].reservas[posicionReserva].costoPorNoche = costo;

                    listaClientes[i].cantidadReservas++;

                    Console.WriteLine();
                    Console.WriteLine("Reserva cargada correctamente.");
                    Console.WriteLine();
                    return;
                }
            }
            Console.WriteLine("No se encontro un cliente con ese DNI.");
        }

        static void modificarReserva(Cliente[] listaClientes, ref int cantidadClientes)
        {
            Console.Write("Ingrese el DNI del cliente: ");
            string dniBuscado = Console.ReadLine() ?? "";

            for (int i = 0; i < cantidadClientes; i++)
            {
                if (listaClientes[i].DNI == dniBuscado)
                {
                    Console.WriteLine("Cliente encontrado: " + listaClientes[i].nombre + " " + listaClientes[i].apellido);

                    if (listaClientes[i].cantidadReservas == 0)
                    {
                        Console.WriteLine("El cliente no tiene reservas.");
                        return;
                    }

                    for (int j = 0; j < listaClientes[i].cantidadReservas; j++)
                    {
                        Console.WriteLine();
                        Console.WriteLine("RESERVA  " + (j + 1));
                        Console.WriteLine("Fecha de ingreso: " + listaClientes[i].reservas[j].fechaIngreso);
                        Console.WriteLine("Plazas reservadas: " + listaClientes[i].reservas[j].plazasReservadas);
                        Console.WriteLine("Cantidad de noches: " + listaClientes[i].reservas[j].cantidadNoches);
                        Console.WriteLine("Costo por noche: " + listaClientes[i].reservas[j].costoPorNoche);
                        Console.WriteLine("----------------------");
                    }

                    Console.Write("Ingrese el numero de reserva: ");
                    int numReserva = int.Parse(Console.ReadLine() ?? "");

                    int posicionReserva = numReserva - 1;

                    if (posicionReserva < 0 || posicionReserva >= listaClientes[i].cantidadReservas)
                    {
                        Console.WriteLine("Numero de reserva invalido.");
                        return;
                    }

                    Console.Write("Ingrese la nueva fecha de ingreso: ");
                    string fechaIngreso = Console.ReadLine() ?? "";

                    Console.Write("Ingrese la nueva cantidad de plazas: ");
                    int plazas = int.Parse(Console.ReadLine() ?? "0");

                    int plazasReservadasEnFecha = 0;

                    for (int cliente = 0; cliente < cantidadClientes; cliente++)
                    {
                        for (int reserva = 0; reserva < listaClientes[cliente].cantidadReservas; reserva++)
                        {
                            if (cliente == i && reserva == posicionReserva)
                            {
                                continue;
                            }

                            string fechaReservaExistente = listaClientes[cliente].reservas[reserva].fechaIngreso;

                            if (fechaReservaExistente == fechaIngreso)
                            {
                                plazasReservadasEnFecha = plazasReservadasEnFecha + listaClientes[cliente].reservas[reserva].plazasReservadas;
                            }
                        }
                    }

                    int totalPlazas = plazasReservadasEnFecha + plazas;

                    if (totalPlazas > 40)
                    {
                        Console.WriteLine("No hay plazas suficientes para esa fecha.");
                        Console.WriteLine("La reserva no fue modificada.");
                        return;
                    }

                    Console.Write("Ingrese la nueva cantidad de noches: ");
                    int noches = int.Parse(Console.ReadLine() ?? "");

                    Console.Write("Ingrese el nuevo costo por noche: ");
                    double costo = double.Parse(Console.ReadLine() ?? "0");

                    listaClientes[i].reservas[posicionReserva].fechaIngreso = fechaIngreso;
                    listaClientes[i].reservas[posicionReserva].plazasReservadas = plazas;
                    listaClientes[i].reservas[posicionReserva].cantidadNoches = noches;
                    listaClientes[i].reservas[posicionReserva].costoPorNoche = costo;

                    Console.WriteLine("Reserva modificada correctamente");
                    return;
                }
            }
            Console.WriteLine("El cliente con el DNI " + dniBuscado + " no fue encontrado.");
        }


        // MODULO 6: CANCELAR UNA RESERVA
        static void cancelarReserva(Cliente[] listaClientes, ref int cantidadClientes)
        {
            Console.Write("Ingrese el DNI del cliente: ");
            string dniBuscado = Console.ReadLine() ?? "";

            for (int i = 0; i < cantidadClientes; i++)
            {
                if (listaClientes[i].DNI == dniBuscado)
                {
                    Console.WriteLine("Cliente encontrado: " + listaClientes[i].nombre + " " + listaClientes[i].apellido);

                    if (listaClientes[i].cantidadReservas == 0)
                    {
                        Console.WriteLine("El cliente no tiene reservas");
                        return;
                    }

                    for (int j = 0; j < listaClientes[i].cantidadReservas; j++)
                    {
                        Console.WriteLine("Reserva " + (j + 1));
                        Console.WriteLine("Fecha de ingreso: " + listaClientes[i].reservas[j].fechaIngreso);
                        Console.WriteLine("Plazas reservadas: " + listaClientes[i].reservas[j].plazasReservadas);
                        Console.WriteLine("Cantidad de noches: " + listaClientes[i].reservas[j].cantidadNoches);
                        Console.WriteLine("Costo por noche: " + listaClientes[i].reservas[j].costoPorNoche);
                        Console.WriteLine("------------------------");
                    }

                    Console.WriteLine();
                    Console.WriteLine("Ingrese el numero de reserva que quiere cancelar.");
                    int numReserva = int.Parse(Console.ReadLine() ?? "");

                    int posicionReserva = numReserva - 1;

                    for (int reserva = posicionReserva; reserva < listaClientes[i].cantidadReservas - 1; reserva++)
                    {
                        listaClientes[i].reservas[reserva] = listaClientes[i].reservas[reserva + 1];
                    }

                    listaClientes[i].cantidadReservas--;

                    Console.WriteLine("Reserva cancelada correctamente.");
                    return;

                }
            }
            Console.WriteLine("El cliente con el DNI " + dniBuscado + "no fue encontrado.");
        }
    }
}