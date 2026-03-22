using System;

class Nodo
{
    public int Valor;
    public Nodo Izquierdo;
    public Nodo Derecho;

    public Nodo(int valor)
    {
        Valor = valor;
        Izquierdo = null;
        Derecho = null;
    }
}

class ArbolBST
{
    private Nodo raiz;

    // INSERTAR
    public void Insertar(int valor)
    {
        raiz = InsertarRec(raiz, valor);
    }

    private Nodo InsertarRec(Nodo nodo, int valor)
    {
        if (nodo == null)
            return new Nodo(valor);

        if (valor < nodo.Valor)
            nodo.Izquierdo = InsertarRec(nodo.Izquierdo, valor);
        else if (valor > nodo.Valor)
            nodo.Derecho = InsertarRec(nodo.Derecho, valor);

        return nodo;
    }

    // BUSCAR
    public bool Buscar(int valor)
    {
        return BuscarRec(raiz, valor);
    }

    private bool BuscarRec(Nodo nodo, int valor)
    {
        if (nodo == null)
            return false;

        if (valor == nodo.Valor)
            return true;

        if (valor < nodo.Valor)
            return BuscarRec(nodo.Izquierdo, valor);
        else
            return BuscarRec(nodo.Derecho, valor);
    }

    // ELIMINAR
    public void Eliminar(int valor)
    {
        raiz = EliminarRec(raiz, valor);
    }

    private Nodo EliminarRec(Nodo nodo, int valor)
    {
        if (nodo == null)
            return nodo;

        if (valor < nodo.Valor)
            nodo.Izquierdo = EliminarRec(nodo.Izquierdo, valor);
        else if (valor > nodo.Valor)
            nodo.Derecho = EliminarRec(nodo.Derecho, valor);
        else
        {
            if (nodo.Izquierdo == null)
                return nodo.Derecho;
            else if (nodo.Derecho == null)
                return nodo.Izquierdo;

            nodo.Valor = Minimo(nodo.Derecho);
            nodo.Derecho = EliminarRec(nodo.Derecho, nodo.Valor);
        }

        return nodo;
    }

    // RECORRIDOS
    public void Inorden()
    {
        InordenRec(raiz);
        Console.WriteLine();
    }

    private void InordenRec(Nodo nodo)
    {
        if (nodo != null)
        {
            InordenRec(nodo.Izquierdo);
            Console.Write(nodo.Valor + " ");
            InordenRec(nodo.Derecho);
        }
    }

    public void Preorden()
    {
        PreordenRec(raiz);
        Console.WriteLine();
    }

    private void PreordenRec(Nodo nodo)
    {
        if (nodo != null)
        {
            Console.Write(nodo.Valor + " ");
            PreordenRec(nodo.Izquierdo);
            PreordenRec(nodo.Derecho);
        }
    }

    public void Postorden()
    {
        PostordenRec(raiz);
        Console.WriteLine();
    }

    private void PostordenRec(Nodo nodo)
    {
        if (nodo != null)
        {
            PostordenRec(nodo.Izquierdo);
            PostordenRec(nodo.Derecho);
            Console.Write(nodo.Valor + " ");
        }
    }

    // MINIMO
    private int Minimo(Nodo nodo)
    {
        while (nodo.Izquierdo != null)
            nodo = nodo.Izquierdo;

        return nodo.Valor;
    }

    public int ObtenerMinimo()
    {
        if (raiz == null)
        {
            Console.WriteLine("Árbol vacío");
            return 0;
        }
        return Minimo(raiz);
    }

    // MAXIMO
    public int ObtenerMaximo()
    {
        if (raiz == null)
        {
            Console.WriteLine("Árbol vacío");
            return 0;
        }

        Nodo actual = raiz;
        while (actual.Derecho != null)
            actual = actual.Derecho;

        return actual.Valor;
    }

    // ALTURA
    public int Altura()
    {
        return AlturaRec(raiz);
    }

    private int AlturaRec(Nodo nodo)
    {
        if (nodo == null)
            return -1;

        return 1 + Math.Max(AlturaRec(nodo.Izquierdo), AlturaRec(nodo.Derecho));
    }

    // LIMPIAR
    public void Limpiar()
    {
        raiz = null;
    }
}

class Program
{
    static void Main()
    {
        ArbolBST arbol = new ArbolBST();
        int opcion, valor;

        do
        {
            Console.WriteLine("\n--- MENÚ ÁRBOL BST ---");
            Console.WriteLine("1. Insertar");
            Console.WriteLine("2. Buscar");
            Console.WriteLine("3. Eliminar");
            Console.WriteLine("4. Recorridos");
            Console.WriteLine("5. Minimo / Maximo / Altura");
            Console.WriteLine("6. Limpiar árbol");
            Console.WriteLine("0. Salir");
            Console.Write("Seleccione una opción: ");

            opcion = int.Parse(Console.ReadLine());

            switch (opcion)
            {
                case 1:
                    Console.Write("Ingrese valor: ");
                    valor = int.Parse(Console.ReadLine());
                    arbol.Insertar(valor);
                    break;

                case 2:
                    Console.Write("Valor a buscar: ");
                    valor = int.Parse(Console.ReadLine());
                    Console.WriteLine(arbol.Buscar(valor) ? "Encontrado" : "No encontrado");
                    break;

                case 3:
                    Console.Write("Valor a eliminar: ");
                    valor = int.Parse(Console.ReadLine());
                    arbol.Eliminar(valor);
                    break;

                case 4:
                    Console.WriteLine("Inorden:");
                    arbol.Inorden();
                    Console.WriteLine("Preorden:");
                    arbol.Preorden();
                    Console.WriteLine("Postorden:");
                    arbol.Postorden();
                    break;

                case 5:
                    Console.WriteLine("Minimo: " + arbol.ObtenerMinimo());
                    Console.WriteLine("Maximo: " + arbol.ObtenerMaximo());
                    Console.WriteLine("Altura: " + arbol.Altura());
                    break;

                case 6:
                    arbol.Limpiar();
                    Console.WriteLine("Árbol limpiado");
                    break;
            }

        } while (opcion != 0);
    }
}