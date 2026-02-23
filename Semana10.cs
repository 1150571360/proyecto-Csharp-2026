using System;
using System.Collections.Generic;
using System.Linq;

class ProgramaVacunacion
{
    static void Main()
    {
        // 1. Generar ciudadanos ficticios
        List<string> ciudadanos = new List<string>();
        for (int i = 1; i <= 500; i++)
        {
            ciudadanos.Add("Ciudadano " + i);
        }

        // 2. Crear conjuntos de vacunados
        HashSet<string> pfizer = new HashSet<string>();
        HashSet<string> astrazeneca = new HashSet<string>();

        // Selección ficticia de 75 ciudadanos para cada vacuna
        for (int i = 1; i <= 75; i++)
        {
            pfizer.Add("Ciudadano " + i);
            astrazeneca.Add("Ciudadano " + (i + 50)); // desplazamiento para variar
        }

        // 3. Operaciones de teoría de conjuntos
        var ambasDosis = new HashSet<string>(pfizer.Intersect(astrazeneca));
        var soloPfizer = new HashSet<string>(pfizer.Except(astrazeneca));
        var soloAstrazeneca = new HashSet<string>(astrazeneca.Except(pfizer));
        var vacunados = new HashSet<string>(pfizer.Union(astrazeneca));
        var noVacunados = new HashSet<string>(ciudadanos.Except(vacunados));

        // 4. Mostrar resultados
        Console.WriteLine("=== Ciudadanos NO vacunados ===");
        foreach (var c in noVacunados) Console.WriteLine(c);

        Console.WriteLine("\n=== Ciudadanos con ambas dosis ===");
        foreach (var c in ambasDosis) Console.WriteLine(c);

        Console.WriteLine("\n=== Ciudadanos solo Pfizer ===");
        foreach (var c in soloPfizer) Console.WriteLine(c);

        Console.WriteLine("\n=== Ciudadanos solo AstraZeneca ===");
        foreach (var c in soloAstrazeneca) Console.WriteLine(c);
    }
}