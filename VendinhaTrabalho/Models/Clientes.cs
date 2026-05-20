using System.ComponentModel.DataAnnotations;
using System.Data;

namespace VendinhaTrabalho.Models
{
	public class Clientes
	{
		public int IdCliente { get; set; }

		[Required(ErrorMessage = "O nome do cliente é obrigatório")]
		[StringLength(100, MinimumLength = 10)]
		[RegularExpression("^[A-Z][A-zA-z]+ [A-Z][A-zA-z ]+[^ ]$")]
		public string Nome { get; set; }

		[Required]
		[StringLength(11, MinimumLength = 11, ErrorMessage = "O mínimo é 11 e o máximo é 11 números")]
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

		[Required]
		public string Email { get; set; }

		public List<Dividas> Dividas { get; set; } = new List<Dividas>();
	}
}
