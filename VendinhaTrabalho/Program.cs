using VendinhaTrabalho;
using VendinhaTrabalho.Models;

var service = new ClientesServices();

while (true) {
	Console.ReadKey();
	Console.Clear();
	Console.WriteLine("Digite uma Opção:");
    Console.WriteLine("1 - Adicionar dividas");
    Console.WriteLine("2 - Listar dividas");

    int opcao;
    try
    {
        opcao = int.Parse(Console.ReadLine());
    }
    catch (FormatException excecao)
    {
        Console.WriteLine("Opção inválida: {0}", excecao.Message);
        continue;
    }
    catch (Exception excecao)
    {
        Console.WriteLine("Erro desconhecido: {0}", excecao.Message);
        continue;
    }


    if (opcao == 1)
	{
        Clientes cliente = new Clientes();

        Console.Write("Nome: ");
        cliente.Nome = Console.ReadLine();

        Console.Write("CPF: ");
        cliente.Cpf = Console.ReadLine();

        Console.Write("Data de nascimento: ");
        cliente.DataNascimento = DateTime.Parse(Console.ReadLine());

        service.AdicionarCliente(cliente);

        Console.WriteLine("Cliente cadastrado!");
        Console.ReadKey();
    }
    else if (opcao == 2)
    {
        service.ListarClientes();
        Console.ReadKey();
    }
}
