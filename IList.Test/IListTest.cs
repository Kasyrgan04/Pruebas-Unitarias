using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IList.Test;

[TestClass] //Se utiliza para determinar que la clase es una clase de prueba

/*NombreMetodo_Escenario_ResultadoEsperado()
 * {
 * //Arrange
 * 
 * //Act
 * 
 * //Assert
 * 
 * }*/
public class IListTest
{ 
    [TestMethod]
    public void MergeSorted_ListAEsNull_Exception()
    {
        //Arrange
        ListaDoble? listA = null;
        ListaDoble listB = new ListaDoble();
        listB.InsertInOrder(1);

        //Act
        var exception = Assert.ThrowsException<ArgumentNullException>(() => listB.MergeSorted(listA, listB, SortDirection.Ascendente));

        //Assert
        Assert.AreEqual("Lista A no puede ser nula (Parameter 'listA')", exception.Message);
    }

    [TestMethod]
    public void MergeSorted_ListBEsNull_Exception()
    {
        //Arrange
        ListaDoble listA = new ListaDoble();
        ListaDoble? listB = null;

        //Act
        var exception = Assert.ThrowsException<ArgumentNullException>(() => listA.MergeSorted(listA, listB, SortDirection.Ascendente));

        //Assert
        Assert.AreEqual("Lista B no puede ser nula (Parameter 'listB')", exception.Message);
    }

    [TestMethod]
    public void MergeSorted_Ascendente_ListaCombinada()
    {
        //Arrange
        ListaDoble listA = new ListaDoble();
        listA.InsertInOrder(0);
        listA.InsertInOrder(2);
        listA.InsertInOrder(6);
        listA.InsertInOrder(10);
        listA.InsertInOrder(25);
        System.Console.WriteLine("Lista A:");
        listA.printAll();
        ListaDoble listB = new ListaDoble();
        listB.InsertInOrder(3);
        listB.InsertInOrder(7);
        listB.InsertInOrder(11);
        listB.InsertInOrder(40);
        listB.InsertInOrder(50);
        System.Console.WriteLine("Lista B:");
        listB.printAll();

        //Act
        listA.MergeSorted(listA, listB, SortDirection.Ascendente);
        Console.WriteLine("Lista combinada:");
        listA.printAll();

        //Assert
        int[] expected = { 0, 2, 3, 6, 7, 10, 11, 25, 40, 50 };
        //int[] expected = { 50, 40, 25, 11, 10, 7, 6, 3, 2, 0 };
        Nodo actual = listA.head;
        foreach (var i in expected )
        {
            Assert.IsNotNull(actual);
            Assert.AreEqual(i, actual.Value);
            actual = actual.Next;
        }
        Assert.IsNull(actual); //Verifica que la lista haya terminado
    }

    [TestMethod]
    public void MergeSorted_Descendente_ListaCombinada()
    {
        //Arrange
        ListaDoble listA = new ListaDoble();
        listA.InsertInOrder(10);
        listA.InsertInOrder(15);
        Console.WriteLine("Lista A:");
        listA.printAll();
        ListaDoble listB = new ListaDoble();
        listB.InsertInOrder(9);
        listB.InsertInOrder(40);
        listB.InsertInOrder(50);
        Console.WriteLine("Lista B:");
        listB.printAll();

        //Act
        listA.MergeSorted(listA, listB, SortDirection.Descendente);
        Console.WriteLine("Lista combinada:");
        listA.printAll();

        //Assert
        int[] expected = { 50, 40, 15, 10, 9};
        Nodo actual = listA.head;
        foreach (var i in expected)
        {
            Assert.IsNotNull(actual);
            Assert.AreEqual(i, actual.Value);
            actual = actual.Next;
        }
        //Assert.IsNull(actual); //Verifica que la lista haya terminado
    }

    [TestMethod]
    public void MergeSorted_ListaVacia_ListaB()
    {
        //Arrange
        ListaDoble listA = new ListaDoble();
        
        ListaDoble listB = new ListaDoble();
        listB.InsertInOrder(9);
        listB.InsertInOrder(40);
        listB.InsertInOrder(50);

        listB.printAll();

        //Act
        listA.MergeSorted(listA, listB, SortDirection.Descendente);

        //Assert
        int[] expected = {50,40,9};
        Nodo actual = listA.head;
        foreach (var i in expected)
        {
            Assert.IsNull(actual);
            Assert.AreEqual(i, actual.Value);
            actual = actual.Next;
        }
        Assert.IsNull(actual); //Verifica que la lista haya terminado
    }

    [TestMethod]
    public void MergeSorted_ListaVacia_ListaA()
    {
        //Arrange
        ListaDoble listA = new ListaDoble();
        listA.InsertInOrder(10);
        listA.InsertInOrder(15);
        ListaDoble listB = new ListaDoble();

        //Act
        listA.MergeSorted(listA, listB, SortDirection.Ascendente);

        //Assert
        int[] expected = { 10, 15 };
        Nodo actual = listA.head;
        foreach (var i in expected)
        {
            Assert.IsNotNull(actual);
            Assert.AreEqual(i, actual.Value);
            actual = actual.Next;
        }
        Assert.IsNull(actual); //Verifica que la lista haya terminado
    }

    [TestMethod]
    public void InvertirLista_Null_Excepcion()
    {
        //Arrange
        ListaDoble? list = null;

        //Act
        Assert.ThrowsException<NullReferenceException>(() => list.Invert());

        //Assert
        
    }

    [TestMethod]
    public void Invert_ListaVacia_ListaVacia()
    {
        //Arrange
        ListaDoble list = new ListaDoble();

        //Act
        list.Invert();

        //Assert
        Assert.IsNull(list.head);
        Assert.IsNull(list.tail);
    }

    [TestMethod]
    public void Invert_ListaConElementos_ListaInvertida()
    {
        //Arrange
        ListaDoble list = new ListaDoble();
        list.InsertInOrder(1);
        list.InsertInOrder(0);
        list.InsertInOrder(30);
        list.InsertInOrder(50);
        list.InsertInOrder(2);

        list.printAll();
        //Act
        list.Invert();
        Console.WriteLine("Lista invertida:");
        list.printAll();

        //Assert
        int[] expected = {2,50,30,0,1 };
        Nodo actual = list.head;
        foreach (var i in expected)
        {
            Assert.IsNotNull(actual); 
            Assert.AreEqual(i, actual.Value);
            actual = actual.Next;
        }
        Assert.IsNull(actual); //Verifica que la lista haya terminado
    }

    [TestMethod]
    public void Invert_ListaConUnElemento_ListaInvertida()
    {
        //Arrange
        ListaDoble list = new ListaDoble();
        list.InsertInOrder(2);

        //Act
        list.Invert();

        //Assert
        int[] expected = { 2 };
        Nodo actual = list.head;
        foreach (var i in expected)
        {
            Assert.IsNotNull(actual);
            Assert.AreEqual(i, actual.Value);
            actual = actual.Next;
        }
        Assert.IsNull(actual); //Verifica que la lista haya terminado
    }

    [TestMethod]
    public void GetMiddle_ListaNula_Excepcion()
    {
        //Arrange
        ListaDoble? list = null;

        //Act
        var exception = Assert.ThrowsException<NullReferenceException>(() => list.GetMiddle());

        //Assert
        Assert.AreEqual("Object reference not set to an instance of an object.", exception.Message);
    }

    [TestMethod]
    public void GetMiddle_ListaVacia_Excepcion()
    {
        //Arrange
        ListaDoble list = new ListaDoble();

        //Act
        var exception = Assert.ThrowsException<InvalidOperationException>(() => list.GetMiddle());

        //Assert
        Assert.AreEqual("Lista vacia", exception.Message);
    }

    [TestMethod]
    public void GetMiddle_ListaConUnElemento_Elemento()
    {
        //Arrange
        ListaDoble list = new ListaDoble();
        list.InsertInOrder(1);

        //Act
        var middle = list.GetMiddle();

        //Assert
        Assert.AreEqual(1, middle);
    }

    [TestMethod]
    public void GetMiddle_ListaConDosElementos_ElementoFinal()
    {
        //Arrange
        ListaDoble list = new ListaDoble();
        list.InsertInOrder(1);
        list.InsertInOrder(2);
        list.printAll();

        //Act
        var middle = list.GetMiddle();
        Console.WriteLine("Middle: " + middle);

        //Assert
        Assert.AreEqual(2, middle);
    }

    [TestMethod]
    public void GetMiddle_ListaConElementosImpares_Medio()
    {
        //Arrange
        ListaDoble list = new ListaDoble();
        list.InsertInOrder(0);
        list.InsertInOrder(1);
        list.InsertInOrder(2);
        

        list.printAll();

        //Act
        var middle = list.GetMiddle();
        Console.WriteLine("Middle: " + middle);

        //Assert
        Assert.AreEqual(1, middle);
    }

    [TestMethod]
    public void GetMiddle_ListaConElementosPares_Medio()
    {
        //Arrange
        ListaDoble list = new ListaDoble();
        list.InsertInOrder(0);
        list.InsertInOrder(1);
        list.InsertInOrder(2);
        list.InsertInOrder(3);

        list.printAll();

        //Act
        var middle = list.GetMiddle();
        Console.WriteLine("Middle: " + middle);
        Console.WriteLine("Count: " + list.Count()/2);

        //Assert
        Assert.AreEqual(2, middle);
    }
}
