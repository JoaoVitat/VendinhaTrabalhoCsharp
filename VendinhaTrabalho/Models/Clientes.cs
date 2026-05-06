using System.ComponentModel.DataAnnotations;
using System.Data;

namespace VendinhaTrabalho.Models
{
	public class Clientes
	{
		[Required(ErrorMessage = "O nome do cliente é obrigatório")]
		[StringLength(100, MinimumLength = 10)]
		[RegularExpression("^[A-Z][A-zA-z]+ [A-Z][A-zA-z ]+[^ ]$")]
		public string Nome { get; set; }

		[Required, StringLength(11)]
		[RegularExpression("[0-9]+$")]
		public string Cpf { get; set; }

		public DateTime DataNascimento { get; set; }

		[Range (15, 99)]
		public int Idade
		{
			get 
			{
				var hoje = DateTime.Today;
				var anos = hoje.Year - DataNascimento.Year;
				var diaAnoNascimento = hoje.AddYears(-anos);
				if (DataNascimento > diaAnoNascimento)
				{
					anos--;
				}
				return anos;
			}
		}
	}
}
