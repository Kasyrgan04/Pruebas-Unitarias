
using System.ComponentModel;
using System.Runtime.InteropServices;

public class Nodo
{
    public int Value;
    public Nodo? Next;
    public Nodo? Previous;
    public Nodo(int value)
    {
        Value = value;
        Next = null;
        Previous = null;
    }
}


public class ListaDoble : IList
{
    public Nodo? head;
    public Nodo? tail;
    public int count;

    public ListaDoble()
    {
        head = null;
        tail = null;
        count = 0;
    }

    public void InsertInOrder(int value)
    {
        Nodo? newNode = new Nodo(value);
        if (head == null)
        {
            head = newNode;
            tail = newNode;
        }
        else
        {
            Nodo? current = head;
            while (current.Next != null)
            {
                current = current.Next;
            }
            current.Next = newNode;
            newNode.Previous = current;
        }
        count++;

    }

    public int DeleteFirst()
    {
        if (head == null)
        {
            throw new InvalidOperationException("List is empty");
        }
        int value = head.Value;
        head = head.Next;
        if (head != null)
        {
            head.Previous = null;
        }
        else
        {
            tail = null;
        }
        return value;
    }

    public int DeleteLast()
    {
        if (tail == null)
        {
            throw new InvalidOperationException("List is empty");
        }
        int value = tail.Value;
        tail = tail.Previous;
        if (tail != null)
        {
            tail.Next = null;
        }
        else
        {
            head = null;
        }
        return value;
    }

    public bool DeleteValue(int value)
    {
        if (head == null)
        {
            return false;
        }
        if (head.Value == value)
        {
            head = head.Next;
            if (head != null)
            {
                head.Previous = null;
            }
            else
            {
                tail = null;
            }
            return true;
        }
        Nodo current = head;
        while (current.Next != null && current.Next.Value != value)
        {
            current = current.Next;
        }
        if (current.Next == null)
        {
            return false;
        }
        if (current.Next == tail)
        {
            tail = current;
            current.Next = null;
        }
        else
        {
            current.Next = current.Next.Next;
            current.Next.Previous = current;
        }
        return true;
    }


    public int GetMiddle()
    {
        
        
        if (this == null)
        {
            throw new ArgumentNullException("Lista nula");
        }
        if(head == null)
        {
            throw new InvalidOperationException("Lista vacia");
        }
        Nodo? actual = head;
        
        if (count % 2 == 0)
        {
            if(count == 2)
            {
                return actual.Next.Value;
            }
            
            else 
            {
                int i = (count / 2);
                while (i != 0)
                {
                    actual = actual.Next;
                    i--;
                }
                return actual.Value;
            }

        }
        else
        {
            int i = count / 2;
            while (i != 0)
            {
                actual = actual.Next;
                i--;
            }
            return actual.Value;
        }
    }

    public void MergeSorted(IList listA, IList listB, SortDirection direction)
    {
        
        if (listA == null)
        {
            throw new ArgumentNullException(nameof(listA), "Lista A no puede ser nula");
        }

        if (listB == null)
        {
            throw new ArgumentNullException(nameof(listB), "Lista B no puede ser nula");
        }

        ListaDoble listaA = (ListaDoble)listA;
        ListaDoble listaB = (ListaDoble)listB;

        Nodo cabezaA = listaA.head;
        Nodo colaA = listaA.tail;
        Nodo cabezaB = listaB.head;
        Nodo colaB = listaB.tail;

        
        while (cabezaB != null)
        {
            Nodo nextB = cabezaB.Next;

            if (direction == SortDirection.Ascendente)
            {
               
                while (cabezaA != null && cabezaA.Next != null && cabezaA.Next.Value < cabezaB.Value)
                {
                    cabezaA = cabezaA.Next;
                }
                
                Nodo nodeNextA = cabezaA != null ? cabezaA.Next : null; 
                if (cabezaA != null)
                {
                    cabezaA.Next = cabezaB;
                    cabezaB.Previous = cabezaA;
                    cabezaB.Next = nodeNextA;

                    if (nodeNextA != null)
                    {
                        nodeNextA.Previous = cabezaB;
                    }
                    else
                    {
                        listaA.tail = cabezaB;
                    }
                }
                else
                {
                    
                    listaA.head = cabezaB;
                    cabezaB.Previous = null;
                    listaA.tail = cabezaB;
                }

                cabezaB = nextB;
            }
            else
            {
                
                while (colaA != null && colaA.Previous != null && colaA.Value > cabezaB.Value)
                {
                    colaA = colaA.Previous;
                }

                Nodo nodeNextA = colaA != null ? colaA.Next : listaA.head;
                if (colaA != null)
                {
                    colaA.Next = cabezaB;
                    cabezaB.Previous = colaA;
                    cabezaB.Next = nodeNextA;

                    if (nodeNextA != null)
                    {
                        nodeNextA.Previous = cabezaB;
                    }
                    else
                    {
                        listaA.tail = cabezaB;
                    }
                }
                else
                {
                    
                    listaA.head = cabezaB;
                    cabezaB.Previous = null;
                    listaA.tail = cabezaB;
                }

                cabezaB = nextB;
            }
        }

        
        listaB.head = null;
        listaB.tail = null;
    }
   
    public void Invert()
    {
        if (this == null)
        {
            throw new InvalidOperationException("Lista vacia");
        }

        if (head == null)
        {
            return;
        }

        Nodo current = head;
        Nodo prev = null;
        Nodo next;

        while (current != null)
        {
            next = current.Next;
            current.Next = prev;
            prev = current;
            current = next;

        }
        head = prev;




    }

    public void printAll()
    {
        Nodo? current = head;
        while (current != null)
        {
            System.Console.WriteLine(current.Value);
            current = current.Next;
        }
    }

    public int Count()
    {
        return count;
    }
}