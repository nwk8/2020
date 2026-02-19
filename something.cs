class List <T>
{
T [ ] L; // An array L to store items of List
int count; // Number of items stored in List
// Creates an empty List to store n items
public List (int n) {
    L = new T [n]; //init array
    count = 0; // set count to 0 
}
// Inserts an item at position i in the List (0 ≤ i ≤ count)
// Note: Double the length of L whenever necessary
public bool Insert (T item, int i) {
    if (i < 0 || i > count) // Invalid position
        return false;

    if (count == L.Length) // Need to expand L
        Double();
    for (int j = count - 1; j >= i; j--) // traverse from the end
        L[j + 1] = L[j]; // count becomes j+1
    L[i] = item; // Insert item
    count++; // Increase count
    return true;
 }
// Doubles the length of the List to store 2n items
private void Double ( ) {
    T [ ] newL = new T [2 * L.Length];
    for (int i = 0; i < L.Length; i++)
        newL[i] = L[i];
    L = newL;
}
 }
// Returns the value of count (a property)
public int Count {
    get {
        return count;
}
}
}