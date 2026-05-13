using System;
using System.Collections.Generic;
using System.Text;
using VendinhaTrabalho.Models;

namespace VendinhaTrabalho.Services
{
    internal class DividaService
    {
        private List<Dividas> list = new List<Dividas>();

        public string AdicionarDivida(string cpf, decimal valor)
        {
            var dividaAberta = list.Any(d => d.CpfCliente == cpf && !d.Situacao);

            if (dividaAberta)
            {
                return "Error: Cliente já tem uma divida em aberto!";
            }

            var novaDivida = new Dividas
            {
                CpfCliente = cpf,
                Valor = valor,
                Situacao = false,
                DatadeCriacao = DateTime.Now
            };

            list.Add(novaDivida);

            return "Sucesso: Divida cadastrada.";

        }

        public void ListarDividas()
        {

			var dividasOrdenadas = list.OrderByDescending(d => d.Valor).ToList();

            foreach (var divida in dividasOrdenadas)
            {
                Console.WriteLine("------------------------");
                Console.WriteLine($"CPF: {divida.CpfCliente}");
                Console.WriteLine($"Valor: {divida.Valor}");
                string status = divida.Situacao ? "Paga" : "Pendente";
                Console.WriteLine($"Situação da divida: {status}");
                Console.WriteLine($"Data da divida: {divida.DatadeCriacao.ToShortDateString()}");
            }
        }

        public void DividaPaga(string cpfP)
        {
            var pagarDivida = list.FirstOrDefault(d => d.CpfCliente == cpfP);

            if (pagarDivida == null)
            {
                Console.WriteLine($"Erro: Nenhuma divida foi encontrada neste cpf ({cpfP})!");
            }

            if (pagarDivida != null)
            {
                pagarDivida.Situacao = true;
                Console.WriteLine($"Divida do cpf({cpfP}) paga com sucesso!");
                //list.Remove(pagarDivida);
                //Console.WriteLine($"Cliente com o cpf ({cpfP}) foi removido das Dívidas com sucesso!");


            }
            else
            {
                Console.WriteLine($"Error: Dívida não encontrada para este Cpf({cpfP})!");
            }
        }
	}
}
