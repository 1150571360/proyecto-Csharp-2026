using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        // Conjunto para evitar jugadores repetidos
        HashSet<string> jugadores = new HashSet<string>();

        // Mapa para relacionar equipos con sus jugadores
        Dictionary<string, List<string>> equipos = new Dictionary<string, List<string>>();

        int opcion = 0;

        while (opcion != 5)
        {
            Console.WriteLine("\n===== TORNEO DE FÚTBOL =====");
            Console.WriteLine("1. Registrar equipo");
            Console.WriteLine("2. Registrar jugador en equipo");
            Console.WriteLine("3. Ver equipos registrados");
            Console.WriteLine("4. Ver jugadores de un equipo");
            Console.WriteLine("5. Salir");
            Console.Write("Seleccione una opción: ");

            opcion = int.Parse(Console.ReadLine());

            switch (opcion)
            {
                case 1:

                    Console.Write("Ingrese nombre del equipo: ");
                    string equipo = Console.ReadLine();

                    if (!equipos.ContainsKey(equipo))
                    {
                        equipos.Add(equipo, new List<string>());
                        Console.WriteLine("Equipo registrado correctamente.");
                    }
                    else
                    {
                        Console.WriteLine("El equipo ya existe.");
                    }

                    break;

                case 2:

                    Console.Write("Ingrese nombre del equipo: ");
                    string equipoJugador = Console.ReadLine();

                    if (equipos.ContainsKey(equipoJugador))
                    {
                        Console.Write("Ingrese nombre del jugador: ");
                        string jugador = Console.ReadLine();

                        if (jugadores.Contains(jugador))
                        {
                            Console.WriteLine("El jugador ya está registrado en el torneo.");
                        }
                        else
                        {
                            jugadores.Add(jugador);
                            equipos[equipoJugador].Add(jugador);

                            Console.WriteLine("Jugador agregado al equipo.");
                        }
                    }
                    else
                    {
                        Console.WriteLine("El equipo no existe.");
                    }

                    break;

                case 3:

                    Console.WriteLine("\n===== EQUIPOS REGISTRADOS =====");

                    foreach (var item in equipos)
                    {
                        Console.WriteLine("- " + item.Key);
                    }

                    break;

                case 4:

                    Console.Write("Ingrese nombre del equipo: ");
                    string buscarEquipo = Console.ReadLine();

                    if (equipos.ContainsKey(buscarEquipo))
                    {
                        Console.WriteLine("\nJugadores del equipo:");

                        foreach (var j in equipos[buscarEquipo])
                        {
                            Console.WriteLine("- " + j);
                        }
                    }
                    else
                    {
                        Console.WriteLine("Equipo no encontrado.");
                    }

                    break;

                case 5:
                    Console.WriteLine("Saliendo del sistema...");
                    break;

                default:
                    Console.WriteLine("Opción inválida.");
                    break;
            }
        }
    }
}