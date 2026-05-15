using VendinhaTrabalho;
using VendinhaTrabalho.Models;
using VendinhaTrabalho.Services;
using VendinhaDesktop.Screens;

namespace VendinhaDesktop
{
	public partial class Form1 : Form
	{
		public ClienteServices Service { get; } = new ClienteServices();
		public Form1()
		{
			InitializeComponent();
		}

		private void button1_Click(object sender, EventArgs e)
		{
			var telaCadastro = new ClienteForm(Service);

			telaCadastro.ShowDialog();
		}
		private void btnListar_Click(object sender, EventArgs e)
		{
			var telaListar = new ClienteListForm(Service);

			telaListar.ShowDialog();
		}

		private void labelEscolhaOpcao_Click(object sender, EventArgs e)
		{

		}
	}
}
