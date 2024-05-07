using System.Runtime.CompilerServices;
using System.Xml.Linq;

namespace ArquivoDeContatos
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int option;
            bool exit = false;
            PhoneBook phoneBook = new();
            Contact? target = null;
            do
            {
                option = Menu();
                switch (option)
                {
                    case 0:

                        exit = true;

                        break;
                    case 1:

                        phoneBook.AddContact(InputContactFromUser());

                        break;
                    case 2:

                        target = RequestContactName(phoneBook);

                        if (target != null)
                        {
                            var removed = phoneBook.RemoveContactByName(target.Name);
                            Console.WriteLine(removed ? "Contato removido com sucesso!" : "Erro ao remover contato");
                        }

                        break;
                    case 3:

                        target = RequestContactName(phoneBook);

                        if (target != null)
                        {
                            Console.WriteLine("\n" + target.ToString() + "\n");
                        }

                        break;
                    case 4:

                        if (phoneBook.IsEmpty())
                        {
                            Console.WriteLine("\nA lista está vazia impossível exibir contatos.\n");
                            break;
                        }
                        Console.WriteLine(phoneBook);

                        break;
                    case 5:
                        target = RequestContactName(phoneBook);
                        
                        
                        break;
                }
            } while (!exit);
            Console.ReadKey();
        }

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

                Console.Write("Nome da rua: ");
                string city = Console.ReadLine();

                Console.Write("Nome da rua: ");
                string state = Console.ReadLine();

                Console.Write("Nome da rua: ");
                string zip = Console.ReadLine();

                contact.ContactAddress = new(street, city, state, zip);
            }
            Console.WriteLine("\nContato criado com sucesso!");
            return contact;
        }

        static Contact? RequestContactName(PhoneBook phoneBook)
        {
            if (phoneBook.IsEmpty())
            {
                Console.WriteLine("\nA lista está vazia impossível realizar operação\n");
                return null;
            }

            Console.Write("\nInsira o nome do contato a ser selecionado: ");
            string name = Console.ReadLine();
            Contact? contact = phoneBook.FindContactByName(name);

            if (contact == null)
            {
                Console.WriteLine("Contato não encontrado, tente novamente.");
            }

            return contact;
        }

        static void RequestContactUpdate(Contact contactName)
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

            switch (option)
            {
                case 0:
                    return;
                    break;
                case 1:
                    Console.Write("Novo nome: ");
                    contactName.Name = Console.ReadLine();
                    break;
                case 2:
                    Console.Write("Novo telefone: ");
                    contactName.PhoneNumbers;

                    break;
                case 3:
                    Console.Write("Novo e-mail: ");
                    contactName.Email = Console.ReadLine();
                    break;
                case 0:
                    break;
            }
        }
    }
}
