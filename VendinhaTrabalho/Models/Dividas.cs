using System;
using System.Collections.Generic;
using System.Text;

namespace VendinhaTrabalho.Models
{
	public class Dividas
	{
		public string Valor { get; set; }
		public string Situacao { get; set; }
		
		public DateTime DatadeCriacao { get; set; }

		public DateTime DatadePagamento { get; set; }

	}
}
