using System;
using System.Collections.Generic;
using System.Text;
using VendinhaTrabalho.Models;

namespace VendinhaTrabalho
{
	public class ClientesServices
	{
        private List<Clientes> list = new List<Clientes>();

        public void AdicionarCliente(Clientes cliente)
        {
            list.Add(cliente);
        }

        public void ListarClientes()
        {
            foreach (var cliente in list)
            {
                Console.WriteLine("------------------------");
                Console.WriteLine($"Nome: {cliente.Nome}");
                Console.WriteLine($"CPF: {cliente.Cpf}");
                Console.WriteLine($"Nascimento: {cliente.DataNascimento.ToShortDateString()}");
                Console.WriteLine($"Idade: {cliente.Idade}");
            }
        }


    }
}
