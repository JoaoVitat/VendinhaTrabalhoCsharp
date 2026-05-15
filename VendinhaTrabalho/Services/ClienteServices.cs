using System;
using System.Collections.Generic;
using System.Text;
using VendinhaTrabalho.Models;

namespace VendinhaTrabalho
{
    public class ClienteServices
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
                Console.WriteLine($"Email: {cliente.Email}");
            }
        }

        public void RemoverCliente(string removerCpf)
        {
            var removerCliente = list.FirstOrDefault(c => c.Cpf == removerCpf);

            if (removerCliente == null)
            {
                Console.WriteLine($"Error: Dívida não encontrada para este Cpf({removerCpf})!");
            }
            else
            {
                list.Remove(removerCliente);
                Console.WriteLine($"Cliente {removerCliente.Nome} e suas dívidas foram removidos com sucesso!");
            }
        }

		public List<Clientes> ObterTodos()
		{
			return list.OrderBy(c => c.Nome).ToList();
		}
	}
}
