// Insert After Data Specific Data position in doubly linked list
public void InsertNode(Node prevNode, int newData)
// Prev node pointing to new data, new data being new data.
{
    if (prevNode == null) // if prev node is null, 
    // then we cannot insert the new node after it.
    {
        Console.WriteLine("The node is null.");
        return;
    }

    Node newNode = new Node(newData); // create new node with new data
    newNode.Next = prevNode.Next; // new node's next pointer points to prev node's next pointer
    newNode.Prev = prevNode; // new node's prev pointer points to prev node

    if (prevNode.Next != null) // if the next node is not null
    {
        prevNode.Next.Prev = newNode; // update the next node's prev pointer
    }

    // prev node's next pointer points to new node
    prevNode.Next = newNode;
}

// Delete Node
public void DeleteNode(int key)
{
    Node tempNode = head, prev = null; // set temporary node to head and prev node to null. 

    // If head node holds the node to be deleted
    if (tempNode != null && tempNode.Data == key)
    {
        head = tempNode.Next; // change head to next
        if (head != null) // if head is not null
        {
            head.Prev = null; // update the new head's prev pointer
        }
        return;
    }

    // search for the key to be deleted, 
    // keep track of the previous node as we need to change temp.Next
    while (tempNode != null && tempNode.Data != key)
    {
        prev = tempNode;
        tempNode = tempNode.Next;
    }

    // If node isn't in linked list
    if (tempNode == null)
        return;

    // Delete the node from linked list
    prev.Next = tempNode.Next;
    if (tempNode.Next != null) // if the next node is not null
    {
        tempNode.Next.Prev = prev; // update the next node's prev pointer
    }
}