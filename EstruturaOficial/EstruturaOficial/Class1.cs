using ProjetoEstrutura;

public class Node
{
    public int data;
    public Node next;
    public string Nome, Telefone, Email;

    public Node()
    {
        data = -1;
        next = null;
    }
    public Node(int valor, string nome, string telefone, string email)
    {
        Nome = nome;
        Telefone = telefone;
        Email = email;
        data = valor;
        next = null;
    }
}