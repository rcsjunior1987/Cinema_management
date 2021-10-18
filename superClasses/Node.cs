using System;
using System.Collections;
using System.Collections.Generic;

/*
This class is a Generic Linked List node with the generic datatype <T>,
    which is Extended by IDisposable that allows an efficient garbage collection when the node is removed from the list.
*/
public class Node<T> : IDisposable
    {
    private T nodeObject;
    public Node<T> previous;
    public Node<T> next;
    public int quantity = 1;

    public T NodeObject { get => nodeObject; set => nodeObject = value; }

    public Node(T nodeObject, Node<T> previous, Node<T> next)
        {
            this.nodeObject = nodeObject;
            this.previous = previous;
            this.next = next;
        }

        // Required for IDisposable objects
        public void Dispose()
        {
            this.nodeObject = default(T);
            this.previous = null;
            this.next = null;
        }
    }