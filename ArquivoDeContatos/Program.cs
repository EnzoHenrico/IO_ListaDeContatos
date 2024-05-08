using System;
using System.Runtime.CompilerServices;
using System.Xml.Linq;

namespace ArquivoDeContatos
{
    internal class Program
    {
        static void Main(string[] args)
        {
            PhoneBook phoneBook = new();
            string path = @"C:\PhoneBook\", file = "contacts.txt";
            bool exit = false;
            do
            {
                string contactName;
                int option = Menu();
                switch (option)
                {
                    case 0:

                        exit = true;

                        break;
                    case 1:
                        phoneBook.AddContact(InputContactFromUser());
                        break;
                    case 2:

                        Console.Write("\nInsira o nome do contato a ser selecionado: ");
                        contactName = Console.ReadLine();

                        if (!phoneBook.ContainsContact(contactName))
                        {
                            Console.WriteLine("Contato não encontrado, tente novamente.");
                            break;
                        }

                        var removed = phoneBook.RemoveContactByName(contactName);
                        Console.WriteLine(removed ? "Contato removido com sucesso!" : "Erro ao remover contato");
                        break;
                    case 3:
                        Console.Write("\nInsira o nome do contato a ser selecionado: ");
                        contactName = Console.ReadLine();

                        if (!phoneBook.ContainsContact(contactName))
                        {
                            Console.WriteLine("Contato não encontrado, tente novamente.");
                            break;
                        }
                        
                        Console.WriteLine("\n" + phoneBook.GetContactString(contactName) + "\n");
                        break;
                    case 4:

                        if (phoneBook.IsEmpty())
                        {
                            Console.WriteLine("\nA lista está vazia impossível exibir contatos.\n");
                            break;
                        }
                        Console.WriteLine(phoneBook.ToString());
                        break;
                    case 5:
                        if (phoneBook.IsEmpty())
                        {
                            Console.WriteLine("\nA lista está vazia impossível realizar operação\n"); 
                            break;
                        }

                        Console.Write("\nInsira o nome do contato a ser selecionado: ");
                        contactName = Console.ReadLine();

                        if (!phoneBook.ContainsContact(contactName))
                        {
                            Console.WriteLine("Contato não encontrado, tente novamente.");
                            break;
                        }

                        option = UpdateMenu();
                        switch (option)
                        {
                            case 0:
                                break;
                            case 1:
                                phoneBook.UpdateName(contactName, InputName());
                                break;
                            case 2:
                                phoneBook.UpdatePhones(contactName, InputPhoneNumber());                                
                                break;
                            case 3:
                                phoneBook.UpdateEmail(contactName, InputContactEmail());
                                break;
                            case 4:
                                phoneBook.UpdateAddress(contactName, inputContactAddress());
                                break;
                        }
                        break;
                }
                phoneBook.SaveOnFile(path, file);
            } while (!exit);
            Console.ReadKey();
        }

        // TODO: Load file and populate PhoneBook

        static int Menu()
        {
            int option = 0;
            do
            {
                Console.WriteLine("\r\n" +
                                  "1) Adicionar novo contato\r\n" +
                                  "2) Remover contato\r\n" +
                                  "3) Buscar contato\r\n" +
                                  "4) Exibir todos contatos\r\n" +
                                  "5) Editar contato\r\n" +
                                  "0) Sair\r\n");
                option = int.Parse(Console.ReadLine());

                if (option < 0 || option > 5)
                {
                    Console.WriteLine("Opção inválida, tente novamente.\n");
                }
            } while (option < 0 || option > 5);

            return option;
        }

        static int UpdateMenu()
        {
            int option;
            do
            {
                Console.WriteLine("Qual informação deseja editar? \r\n" +
                                  "1) Nome\r\n" +
                                  "2) Números de telefone\r\n" +
                                  "3) E-mail\r\n" +
                                  "4) Endereço\r\n" +
                                  "0) Sair\r\n");
                option = int.Parse(Console.ReadLine());

                if (option is < 0 or > 4)
                {
                    Console.WriteLine("Opção inválida, tente novamente.\n");
                }
            } while (option is < 0 or > 5);

            return option;
        }
        
        static string InputName()
        {
            Console.Write("Nome do contato: ");
            return Console.ReadLine();
        }

        static string InputPhoneNumber()
        {
            Console.Write("Telefone do contato: ");
            return Console.ReadLine();
        }

        static string InputContactEmail()
        {
            Console.Write("E-mail do contato: ");
            return Console.ReadLine();
        }

        static ContactAddress inputContactAddress()
        {
            Console.Write("Nome da rua: ");
            string street = Console.ReadLine();

            Console.Write("Nome da cidade: ");
            string city = Console.ReadLine();

            Console.Write("Estado: ");
            string state = Console.ReadLine();

            Console.Write("CEP: ");
            string zip = Console.ReadLine();

            return new(street, city, state, zip);
        }

        static Contact InputContactFromUser()
        {
            Console.Write("Nome do contato: ");
            string name = Console.ReadLine();

            Console.Write("Número de telefone: ");
            string phone = Console.ReadLine();

            Contact contact = new(name, phone);

            Console.Write("Deseja adiconar mais alugum telefone? s / n : ");
            bool decision = Console.ReadLine() == "s";

            if (decision)
            {
                Console.Write("Número de telefone adicional: ");
                contact.AddPhoneNumber(Console.ReadLine());
            }

            Console.Write("Deseja adiconar um e-mail agora? s / n : ");
            decision = Console.ReadLine() == "s";

            if (decision)
            {
                Console.Write("E-mail: ");
                contact.Email = Console.ReadLine();
            }

            Console.Write("Deseja adiconar um endereço? s / n : ");
            decision = Console.ReadLine() == "s";

            if (decision)
            {
                Console.Write("Nome da rua: ");
                string street = Console.ReadLine();

                Console.Write("Nome da cidade: ");
                string city = Console.ReadLine();

                Console.Write("Estado: ");
                string state = Console.ReadLine();

                Console.Write("CEP: ");
                string zip = Console.ReadLine();

                contact.ContactAddress = new(street, city, state, zip);
            }
            Console.WriteLine("\nContato criado com sucesso!");
            return contact;
        }
    }
}
