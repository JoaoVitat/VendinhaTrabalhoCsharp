using System;
using System.Collections.Generic;
using System.Text;

namespace VendinhaTrabalho.Models
{
	public class Dividas
	{
		public string CpfCliente { get; set; }
		public decimal Valor { get; set; }
		public bool Situacao { get; set; }
		
		public DateTime DatadeCriacao { get; set; }

		public DateTime? DatadePagamento { get; set; }

		public Clientes Cliente { get; set; }

		public int ClienteId { get; set; }

	}
}
