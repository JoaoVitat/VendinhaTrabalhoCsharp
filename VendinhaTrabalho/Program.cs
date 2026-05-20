using VendinhaTrabalho;
using VendinhaTrabalho.Models;
using VendinhaTrabalho.Services;

var serviceCliente = new ClienteServices();
var serviceDivida = new DividaService();

while (true) {
	Console.ReadKey();
	Console.Clear();
	Console.WriteLine("Digite uma Opção:");
    Console.WriteLine("1 - Adicionar clientes");
    Console.WriteLine("2 - adicionar dívidas");
    Console.WriteLine("2 - Listar dívidas");
    Console.WriteLine("2 - Pagar dívidas");

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

		Console.Write("Email: ");
		cliente.Email = Console.ReadLine();

		serviceCliente.AdicionarCliente(cliente, out string erro);

        Console.WriteLine("Cliente cadastrado!");
        Console.ReadKey();
    }
    //else if (opcao == 2)
    //{
    //    serviceCliente.ListarClientes();
    //    Console.ReadKey();
    //}

    else if (opcao == 2)
    {
        Dividas dividas = new Dividas();

        Console.Write("CPF: ");
        string cpf = Console.ReadLine();

        Console.Write("Valor da Compra: ");
        decimal valor = decimal.Parse(Console.ReadLine());

        string mensagem = serviceDivida.AdicionarDivida(cpf, valor);

        Console.WriteLine(mensagem);
    }

    else if (opcao == 3)
    {
        serviceDivida.ListarDividas();
        Console.ReadKey();
    }

    else if (opcao == 4)
    {
        Console.Write("CPF: ");
        string cpf = Console.ReadLine();

        serviceDivida.DividaPaga(cpf);
    }

    else if (opcao == 5)
    {
        Console.Write("Inserir Cpf: ");
        string cpfRemover = Console.ReadLine();

        serviceCliente.RemoverCliente(cpfRemover);
    }
}
