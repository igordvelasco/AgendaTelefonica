using ProjetoEstrutura;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace EstruturaOficial
{
    class Program
    {
        static void Main(string[] args)
        {
            string input;
            int switcher;
            string nome;
            string telefone;
            string email;
            int index = 1;
            int id = 1;
            int codigo;
            string a = null, b = null, c = null;
            ConsoleKeyInfo alvo;

            LinkedList Agenda = new LinkedList();

            System.IO.StreamReader arquivo = new System.IO.StreamReader("agendinha.txt");
            for ((string line, int number) record = (arquivo.ReadLine(), 3);
                record.line != null;
                record = (arquivo.ReadLine(), ++record.number))
            {
                if (record.number % 3 == 0)
                {
                    a = record.line;
                }

                if (record.number % 3 == 1)
                {
                    b = record.line;
                }

                if (record.number % 3 == 2)
                {
                    c = record.line;
                    Agenda.Add(id, a, b, c);
                    id++;
                }
            }
            arquivo.Dispose();

            Menu();

            void Menu()
            {
                Console.WriteLine("Selecione uma das opçoes abaixo:");
                Console.WriteLine("1 - Adicionar Contato.");
                Console.WriteLine("2 - Remover Contato.");
                Console.WriteLine("3 - Atualizar Contato.");
                Console.WriteLine("4 - Buscar Contato.");
                Console.WriteLine("5 - Ordenar Agenda.");
                Console.WriteLine("6 - Listar Agenda.");
                Console.WriteLine("7 - Navegar pelos Contatos.");
                Console.WriteLine("8 - Sair do Menu.");
                input = Console.ReadLine();
                Console.Clear();

                switcher = Convert.ToInt32(input);

                switch (switcher)
                {
                    case 1:

                        Console.WriteLine("Qual o nome do contato?");
                        nome = Console.ReadLine();
                        Console.Clear();

                        Console.WriteLine("Qual o email do contato?");
                        email = Console.ReadLine();
                        Console.Clear();

                        Console.WriteLine("\rQual o telefone do contato?");
                        telefone = Console.ReadLine();
                        Console.Clear();

                        Agenda.Add(index, nome, telefone, email);
                        
                        index++;

                        Agenda.Textar();

                        Menu();

                        break;

                    case 2:

                        Console.WriteLine("Por favor digite o ID do contato que vai ser excluido:");
                        input = Console.ReadLine();
                        codigo = Convert.ToInt32(input);
                        Agenda.Remove(codigo);
                        Console.Clear();

                        Agenda.Textar();

                        Menu();

                        break;

                    case 3:

                        Console.WriteLine("Por favor digite o ID do contato que vai ser modificado:");
                        input = Console.ReadLine();
                        codigo = Convert.ToInt32(input);
                        Console.Clear();
                        Console.WriteLine("Nome: " + Agenda.Find(codigo).Nome + "\r\n" + "Telefone: " + Agenda.Find(codigo).Telefone + "\r\n" + "Email: " + Agenda.Find(codigo).Email);
                        Console.WriteLine("O que deseja ser modificado?");
                        input = Console.ReadLine();

                        if (input == "nome" || input == "Nome")
                        {
                            Console.Clear();
                            Console.WriteLine("Qual o novo nome?");
                            nome = Console.ReadLine();
                            Agenda.Find(codigo).Nome = nome;

                        }

                        else if (input == "telefone" || input == "Telefone")
                        {
                            Console.Clear();
                            Console.WriteLine("Qual o novo telefone?");
                            telefone = Console.ReadLine();
                            Agenda.Find(codigo).Telefone = telefone;
                        }

                        else if (input == "email" || input == "Email")
                        {
                            Console.Clear();
                            Console.WriteLine("Qual o novo email?");
                            email = Console.ReadLine();
                            Agenda.Find(codigo).Email = email;
                        }

                        Agenda.Textar();

                        Console.Clear();
                        Menu();
                        break;

                    case 4:

                        Console.WriteLine("Qual ID deverá ser buscado?");
                        input = Console.ReadLine();
                        codigo = Convert.ToInt32(input);

                        Console.Clear();

                        Console.WriteLine("Nome: " + Agenda.Find(codigo).Nome + "\r\n" + "Telefone: " + Agenda.Find(codigo).Telefone + "\r\n" + "Email: " + Agenda.Find(codigo).Email);
                        Console.WriteLine("\r\nAperte uma tecla para continuar.");
                        Console.ReadKey();

                        Console.Clear();

                        Menu();

                        break;

                    case 5:

                        Console.WriteLine("Deseja ordenar por qual dado?");
                        input = Console.ReadLine();
                        Console.Clear();

                        if (input == "nome" || input == "Nome")
                        {
                            int t = Agenda.Count();
                            for (int ii = 1; ii < t; ii++)
                            {
                                for (int j = 1; j < t; j++)
                                {
                                    string x = Agenda.Find(j).Nome;
                                    string y = Agenda.Find(j + 1).Nome;
                                    if (x[0] > y[0])
                                    {
                                        LinkedList ajuda = new LinkedList();
                                        ajuda.Add(1, Agenda.Find(j).Nome, Agenda.Find(j).Telefone, Agenda.Find(j).Email);

                                        Agenda.Find(j).Nome = Agenda.Find(j + 1).Nome;
                                        Agenda.Find(j).Telefone = Agenda.Find(j + 1).Telefone;
                                        Agenda.Find(j).Email = Agenda.Find(j + 1).Email;

                                        Agenda.Find(j + 1).Nome = ajuda.Find(1).Nome;
                                        Agenda.Find(j + 1).Telefone = ajuda.Find(1).Telefone;
                                        Agenda.Find(j + 1).Email = ajuda.Find(1).Email;
                                    }
                                }
                            }
                        }

                        if (input == "telefone" || input == "Telefone")
                        {
                            int t = Agenda.Count();
                            for (int ii = 1; ii < t; ii++)
                            {
                                for (int j = 1; j < t; j++)
                                {
                                    string x = Agenda.Find(j).Telefone;
                                    string y = Agenda.Find(j + 1).Telefone;
                                    if (x[0] > y[0])
                                    {
                                        LinkedList ajuda = new LinkedList();
                                        ajuda.Add(1, Agenda.Find(j).Nome, Agenda.Find(j).Telefone, Agenda.Find(j).Email);

                                        Agenda.Find(j).Nome = Agenda.Find(j + 1).Nome;
                                        Agenda.Find(j).Telefone = Agenda.Find(j + 1).Telefone;
                                        Agenda.Find(j).Email = Agenda.Find(j + 1).Email;

                                        Agenda.Find(j + 1).Nome = ajuda.Find(1).Nome;
                                        Agenda.Find(j + 1).Telefone = ajuda.Find(1).Telefone;
                                        Agenda.Find(j + 1).Email = ajuda.Find(1).Email;
                                    }
                                }
                            }
                        }

                        if (input == "Email" || input == "email")
                        {
                            int t = Agenda.Count();
                            for (int ii = 1; ii < t; ii++)
                            {
                                for (int j = 1; j < t; j++)
                                {
                                    string x = Agenda.Find(j).Email;
                                    string y = Agenda.Find(j + 1).Email;
                                    if (x[0] > y[0])
                                    {
                                        LinkedList ajuda = new LinkedList();
                                        ajuda.Add(1, Agenda.Find(j).Nome, Agenda.Find(j).Telefone, Agenda.Find(j).Email);

                                        Agenda.Find(j).Nome = Agenda.Find(j + 1).Nome;
                                        Agenda.Find(j).Telefone = Agenda.Find(j + 1).Telefone;
                                        Agenda.Find(j).Email = Agenda.Find(j + 1).Email;

                                        Agenda.Find(j + 1).Nome = ajuda.Find(1).Nome;
                                        Agenda.Find(j + 1).Telefone = ajuda.Find(1).Telefone;
                                        Agenda.Find(j + 1).Email = ajuda.Find(1).Email;
                                    }
                                }
                            }
                        }

                        Agenda.Textar();

                        Menu();
                     


                        break;

                    case 6:

                        Agenda.Print();

                        Console.WriteLine("\r\nAperte uma tecla para continuar.");
                        Console.ReadKey();

                        Console.Clear();
                        Menu();

                        break;

                    case 7:

                        int num = 1;

                        do
                        {
                            Console.WriteLine("Nome: " + Agenda.Find(num).Nome + "\r\n" + "Telefone: " + Agenda.Find(num).Telefone + "\r\n" + "Email: " + Agenda.Find(num).Email);
                            Console.WriteLine("\r\n\r\nAperte <- para navegar para a esquerda.        Aperte -> para navegar para a direita. \r\n                                  Aperte ENTER para sair.");

                            alvo = Console.ReadKey();

                            if (alvo.Key == ConsoleKey.RightArrow)
                            {
                                num += 1;
                            }

                            if (alvo.Key == ConsoleKey.LeftArrow)
                            {
                                num -= 1;
                            }

                            if (num == 0)
                            {
                                num = Agenda.Count();
                            }

                            if (num == Agenda.Count() + 1)
                            {
                                num = 1;
                            }
                            Console.Clear();
                        } while (alvo.Key != ConsoleKey.Enter);

                        Menu();

                        break;
                }
            }
        }
    }
}