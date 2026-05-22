using System;
using System.Windows.Forms;
using VendinhaTrabalho.Models;
using VendinhaTrabalho.Services;

namespace VendinhaDesktop.Screens
{
	public partial class DividaList : Form
	{
		private readonly Clientes _cliente;
		private readonly DividaService _dividaService;

		public DividaList(Clientes clienteSelecionado, DividaService dividaService)
		{
			InitializeComponent();

			_cliente = clienteSelecionado;
			_dividaService = dividaService;

			lblNomeCliente.Text = $"Cliente: {_cliente.Nome} | CPF: {_cliente.Cpf}";

			CarregarDividasTable();
		}

		private void CarregarDividasTable()
		{
			dataGridViewDividas.Rows.Clear();

			var dividasDoCliente = _dividaService.ObterDividasPorCpf(_cliente.Cpf);

			foreach (var div in dividasDoCliente)
			{
				string status = div.Situacao ? "Paga" : "Pendente";
				string dataPagamento = div.DatadePagamento?.ToString("dd/MM/yyyy") ?? "—";

				dataGridViewDividas.Rows.Add(
					$"R$ {div.Valor:N2}",
					status,
					div.DatadeCriacao.ToString("dd/MM/yyyy"),
					dataPagamento
				);
			}
		}

		private void btnSalvarDivida_Click(object sender, EventArgs e)
		{

			if (!decimal.TryParse(txtBoxValor.Text, out decimal valorDigitado) || valorDigitado <= 0)
			{
				MessageBox.Show("Por favor, insira um valor válido maior que zero.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
				return;
			}

			string resultado = _dividaService.AdicionarDivida(_cliente.Cpf, valorDigitado);

			if (resultado.StartsWith("Error"))
			{
				MessageBox.Show(resultado, "Regra de Negócio", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
			else
			{
				MessageBox.Show(resultado, "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
				txtBoxValor.Clear();
				CarregarDividasTable();
			}
		}

		private void DividaList_Load(object sender, EventArgs e)
		{

		}

		private void dataGridViewDividas_CellContentClick(object sender, DataGridViewCellEventArgs e)
		{

		}

		private void btnRetirarDivida_Click(object sender, EventArgs e)
		{
			string resultado = _dividaService.DividaPaga(_cliente.Cpf);

			if (resultado.StartsWith("Erro"))
			{
				MessageBox.Show(resultado, "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
			}
			else
			{
				MessageBox.Show(resultado, "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
				CarregarDividasTable();
			}
		}
	}
}