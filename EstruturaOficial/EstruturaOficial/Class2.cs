using ProjetoEstrutura;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;


public class LinkedList
{
    public Node head;

    public LinkedList()
    {
        head = null;
    }
    public void Add(int valor, string nome, string telefone, string email)
    {
        Node aux = head;
        var newNode = new Node(valor, nome, telefone, email);
        if (head != null)
        {
            while (aux.next != head)
            {
                aux = aux.next;
            }
        }
        else
        {
            aux = newNode;
        }
        newNode.next = head;
        head = newNode;
        aux.next = head;
    }
    public Node Find(int valor)
    {
        Node aux = head;
        while ((aux != null) && (aux.data != valor))
        {
            aux = aux.next;
        }
        return aux;
    }
    public bool IsEmpty()
    {
        return (head == null);
    }
    public void Print()
    {
        if (head == null)
        {

        }
        var aux = head;

        do
        {
            Console.WriteLine("__________________________");
            Console.WriteLine ("Nome: " + aux.Nome + "     Telefone: " + aux.Telefone + "     Email: " + aux.Email);
            Console.WriteLine("--------------------------\r\n");
            aux = aux.next;
        } while (aux != head);
    }
    public void Remove(int valor)
    {
        if (this.IsEmpty())
        {
            return;
        }
        Node aux = head;
        Node ant = null;
        while ((aux != null) && (aux.data != valor))
        {
            ant = aux;
            aux = aux.next;
        }
        if (ant == null)
        {
            head = aux.next;
        }
        else
        {
            ant.next = aux.next;
        }
    }
    public void Textar()
    {
        if (head == null)
        {

        }
        var aux = head;

        using (StreamWriter outputFile = new StreamWriter("agendinha.txt"))
        {
            do
            {
                outputFile.WriteLine(aux.Nome);
                outputFile.WriteLine(aux.Telefone);
                outputFile.WriteLine(aux.Email);
                aux = aux.next;
            } while (aux != head);
        }
    }
    public int Count()
    {
        int tamanho = 0;
        if (head == null)
        {

        }
        var aux = head;

        do
        {
            tamanho++;
            aux = aux.next;
        } while (aux != head);

        return tamanho;
    }
}