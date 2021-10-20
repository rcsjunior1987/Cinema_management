using System;
using System.Collections;
using System.Collections.Generic;

/*
This class is a Generic Linked List node with the generic datatype <T>,
    which is Extended by IDisposable that allows an efficient garbage collection when the node is removed from the list.
*/
public class Node<T> : IDisposable
{
    private T content;
    public T Content { get => content; set => content = value; }

    private Node<T> previous;
    public Node<T> Previous { get => previous; set => previous = value; }

    private Node<T> next;
    public Node<T> Next { get => next; set => next = value; }

    public int quantity = 1;

    
    public Node(T content, Node<T> next)
    //public Node(T content, Node<T> previous, Node<T> next)
    {
        this.Content = content;
        //this.Previous = previous;
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