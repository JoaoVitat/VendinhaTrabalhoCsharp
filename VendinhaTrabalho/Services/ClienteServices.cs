using System;
using System.Collections.Generic;
using System.Text;
using VendinhaTrabalho.Models;
using VendinhaTrabalho.Services;

namespace VendinhaTrabalho
{
    public class ClienteServices
    {
        private static List<Clientes> list = new List<Clientes>();
        private static int contadorId = 1;

        public bool AdicionarCliente(Clientes cliente, out string erro)
        {
            erro = null;

            if(list.Any(c => c.Cpf == cliente.Cpf))
            {
                erro = "Este Cpf já está cadastrado!";
                return false;
            }

            cliente.IdCliente = contadorId++;

            list.Add(cliente);
            return true;
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

        public bool AtualizarCliente(Clientes atualizarCliente, out string erro)
        {
            erro = null;

            var cadastroOriginalCliente = list.FirstOrDefault(cliente => cliente.IdCliente == atualizarCliente.IdCliente);
            if (cadastroOriginalCliente == null)
            {
                erro = "Cliente não foi encontrado!";
                return false;
            }

            if (list.Any(cliente => cliente.Cpf == atualizarCliente.Cpf && cliente.IdCliente != atualizarCliente.IdCliente))
            {
                erro = "Este Cpf já está sendo usado por um cliente!";
                return false;
            }

            cadastroOriginalCliente.Nome = atualizarCliente.Nome;
			cadastroOriginalCliente.Cpf = atualizarCliente.Cpf;
			cadastroOriginalCliente.DataNascimento = atualizarCliente.DataNascimento;
			cadastroOriginalCliente.Email = atualizarCliente.Email;

            return true;
		}

        public bool RemoverCliente(int IdCliente)
        {
            var removerCliente = list.FirstOrDefault(c => c.IdCliente == IdCliente);

            if (removerCliente == null)
            {
                return false;
            }
            else
            {
                list.Remove(removerCliente);
                return true;
            }
        }

        public List<Clientes> OrdenadosPorDivida(DividaService dividaService)
        {
            return list
                    .OrderByDescending(cliente => dividaService.TotalDividaPorCpf(cliente.Cpf))
                    .ToList();
        }

        public Clientes RecuperarCliente(string cpfPesquisa)
        {
            return list.FirstOrDefault(cliente => cliente.Cpf.Trim() == cpfPesquisa.Trim());
        }

        public Clientes ObterPorId(int id)
        {
            return list.FirstOrDefault(c => c.IdCliente == id);
        }

        public List<Clientes> ObterTodos()
        {
            return list.OrderBy(c => c.Nome).ToList();
        }
    }
}
