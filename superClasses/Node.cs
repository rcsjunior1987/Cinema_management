using System;
using System.Collections;
using System.Collections.Generic;

/*
    This class is a Generic Linked List node with the generic datatype <T>,
    which is Extended by IDisposable that allows an efficient garbage collection when the node is removed from the list.
*/
public class Node<T> : IDisposable
{
    /* Content of the Node */
    private T content;
    public T Content { get => content; set => content = value; }

    /* Link to the next element  */
    private Node<T> next;
    public Node<T> Next { get => next; set => next = value; }
    
    public Node(T content, Node<T> next)
    {
        this.Content = content;
        this.Next = next;
    }

    // Required for IDisposable objects
    public void Dispose()
    {
        this.Content = default(T);
        //this.Previous = null;
        this.Next = null;
    }
}