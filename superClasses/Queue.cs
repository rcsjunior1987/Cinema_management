using System;
using System.Collections;
using System.Collections.Generic;

/*
    This class is a linear structure that follows the order First In First Out (FIFO).
     That means, the first element to get in the queue is the first to be manipulated.
      This class the attibutes Head, Tail, and Current that are instances from Node<T>.
       The object Head contains instances of any (T) type objects,
        and it represents the element located in the first position of the Queue.
       The object Tail stores the element in the last position of the Queue,
        whereas Current is the actual element being manipulated.
       Among the Head and Tail are stored elements gathered by Nodes elements previous
        and next that represent which element lies in a one before position,
        and next is the element that lies in one after position.
       To conclude, Queue has the methods Add to add new object always in Tail,
        Remove to Exclude an element from Head, GetHeadElement that returns the Head element,
         Contains to check whether an object is stored in the queue
          and Find that finds an object located in the queue.
*/
public class Queue<T> : IEnumerable<T>
{
    private Node<T> head = null;
    private Node<T> tail = null;
    private Node<T> current = null;
    private int length = 0;
    public Node<T> Head { get => head; set => head = value; }
    public Node<T> Tail { get => tail; set => tail = value; }
    public Node<T> Current { get => current; set => current = value; }
    public int Length { get => length; set => length = value; }

    public Queue()
    {
        this.Length = 0;
        this.Head = null;
        this.Tail = null;
        Current = null;
    }

    public Node<T> Previous()
    {
        return Current.previous;
    }

    public Node<T> Next()
    {
        return Current.next;
    }

    public virtual void Add(T obj)
    {
        Node<T> previous = null;
        if (this.Tail != null)
            previous = this.Tail;

        Node<T> newNode = new Node<T>(obj, previous, null);

        if (this.Length == 0)
        {
            this.Head = newNode;
            this.Tail = newNode;
            this.Current = newNode;
        }
        else
        {
            Node<T> testObject = this.Find(obj);
            if (testObject != null)
                testObject.quantity += 1;
            else
            {
                newNode.previous = this.Tail;
                this.Tail.next = newNode;
                this.Tail = newNode;
            }
        }

        this.Length += 1;
    }

    public virtual void Remove()
    {
        if (this.Length > 0)
        {
            if (this.Current == this.Tail)
            {
                this.Tail = this.Current.previous;    
                this.Current.previous.next = null;
                this.Current.previous = null;
            }
            else
            {
                if (this.Current == this.Head)
                {
                    this.Current.next.previous = null;
                    this.Head = this.Current.next;
                }
                else{
                    this.Current.next.previous = this.Current.previous;
                    this.Current.previous.next = this.Current.next;
                }
            }

            --this.Length;
        }
    }

    public virtual T GetHeadElement()
    {
        T headObj;

        if ((this is not null)
         && (this.Head is not null))
        {
            Node<T> afterNode = this.Head.next;
            headObj = this.head.NodeObject;

            this.Head.next = null;
            afterNode.previous = null;

            this.Head = afterNode;

            return headObj;
        }

        return default(T);
    }

    public virtual bool Contains(T obj)
    {
        foreach (T element in this)
        {
            if (element.Equals(obj))
                return true;
        }
        return false;
    }

    public virtual Node<T> Find(T obj)
    {
        if (this.Contains(obj))
            return this.Current;
        return null;
    }

    public virtual int GetQuantity(T obj)
    {
        Node<T> testObject = this.Find(obj);
        if (testObject != null)
            return testObject.quantity;
        return 0;
    }

    public IEnumerator<T> GetEnumerator()
    {
        this.Current = this.Head;

        while (this.Current != null)
        {
            yield return this.Current.NodeObject;
            this.Current = this.Current.next;
        }
    }      

    IEnumerator IEnumerable.GetEnumerator()
    {
        throw new NotImplementedException();
    }
        
}