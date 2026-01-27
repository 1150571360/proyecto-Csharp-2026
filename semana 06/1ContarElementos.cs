using System;

// CLASE NODO
class Nodo
{
    public int Dato;          // Guarda el valor
    public Nodo Siguiente;    // Apunta al siguiente nodo
}

// CLASE LISTA ENLAZADA
class ListaEnlazada
{
    public Nodo cabeza; // Primer nodo

    // Agregar nodos a la lista
    public void Agregar(int dato)
    {
        Nodo nuevo = new Nodo();
        nuevo.Dato = dato;
        nuevo.Siguiente = cabeza;
        cabeza = nuevo;
    }

    // EJERCICIO 1: Contar elementos
    public int ContarElementos()
    {
        int contador = 0;
        Nodo actual = cabeza;

        // Recorremos la lista
        while (actual != null)
        {
            contador++;                 // Contamos un nodo
            actual = actual.Siguiente;  // Pasamos al siguiente
        }

        return contador;
    }
}

// PROGRAMA PRINCIPAL
class Program
{
    static void Main()
    {
        ListaEnlazada lista = new ListaEnlazada();

        lista.Agregar(10);
        lista.Agregar(20);
        lista.Agregar(30);

        Console.WriteLine(
            "Cantidad de elementos de la lista: " + lista.ContarElementos()
        );
    }
}