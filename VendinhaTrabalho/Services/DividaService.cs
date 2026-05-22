using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using VendinhaTrabalho.Models;

namespace VendinhaTrabalho.Services
{
    public class DividaService
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
                DatadeCriacao = DateTime.Now,
                DatadePagamento = null
            };

            list.Add(novaDivida);

            return "Sucesso: Divida cadastrada.";

        }

        public decimal TotalDividaPorCpf(string cpf)
        {

			return list
		        .Where(d => d.CpfCliente == cpf && !d.Situacao)
		        .Sum(d => d.Valor);
		}

        public string DividaPaga(string cpfP)
        {
            var pagarDivida = list.FirstOrDefault(d => d.CpfCliente == cpfP);

            if (pagarDivida == null)
            {
                return $"Erro: Nenhuma divida foi encontrada neste cpf!";
            }

            pagarDivida.Situacao = true;
            pagarDivida.DatadePagamento = DateTime.Now;
            return $"Divida do cpf({cpfP}) paga com sucesso!";
        }

        public List<Dividas> ObterDividasPorCpf(string cpf)
        {
            return list.Where(divida => divida.CpfCliente == cpf).ToList();
        }
    }
}
