using System;

public class List<T>
{
    private T[] L;      // Internal array to store list items
    private int count;  // Number of items currently in the list

    // Constructor: creates an empty list with initial capacity n
    public List(int n = 4) // default size 4 if not specified
    {
        if (n <= 0) n = 4;       // ensure minimum size
        L = new T[n];
        count = 0;
    }

    // Property to get current number of items
    public int Count
    {
        get { return count; }
    }

    // Insert an item at position i (0 <= i <= count)
    // Returns false if the index is invalid
    public bool Insert(T item, int i)
    {
        if (i < 0 || i > count) // invalid position
            return false;

        // Resize array if full
        if (count == L.Length)
            DoubleSize();

        // Shift elements to the right
        for (int j = count - 1; j >= i; j--)
        {
            L[j + 1] = L[j];
        }

        // Insert new item
        L[i] = item;
        count++;
        return true;
    }

    // Add item at the end (like PushBack)
    public void Add(T item)
    {
        Insert(item, count);
    }

    // Get item at index i
    public T Get(int i)
    {
        if (i < 0 || i >= count)
            throw new IndexOutOfRangeException("Index out of range");
        return L[i];
    }

    // Remove item at index i
    public bool RemoveAt(int i)
    {
        if (i < 0 || i >= count)
            return false;

        for (int j = i; j < count - 1; j++)
        {
            L[j] = L[j + 1]; // shift left
        }

        count--;
        return true;
    }

    // Double the size of the internal array
    private void DoubleSize()
    {
        int newSize = L.Length == 0 ? 1 : L.Length * 2;
        T[] newL = new T[newSize];
        for (int i = 0; i < count; i++)
            newL[i] = L[i];
        L = newL;
    }

    // Print all items in the list
    public void PrintList()
    {
        Console.WriteLine("List contents:");
        for (int i = 0; i < count; i++)
        {
            Console.WriteLine(L[i]);
        }
    }
}

// Example usage
class Program
{
    static void Main()
    {
        List<int> myList = new List<int>();

        myList.Add(10);
        myList.Add(20);
        myList.Add(30);
        myList.Insert(15, 1); // insert 15 at index 1
        myList.PrintList();

        myList.RemoveAt(2); // remove item at index 2 (20)
        Console.WriteLine("After removing index 2:");
        myList.PrintList();

        Console.WriteLine("Item at index 1: " + myList.Get(1));
    }
}
