using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using VendinhaTrabalho;
using VendinhaTrabalho.Models;
using VendinhaTrabalho.Services;

namespace VendinhaDesktop.Screens
{
	public partial class ClienteListForm : Form
	{
		private readonly ClienteServices _service;
		private readonly DividaService _dividaService;
		public ClienteListForm(ClienteServices service, DividaService dividaService)
		{
			_service = service;
			_dividaService = dividaService;


			InitializeComponent();
			CarregarClientesTable();


		}

		private void CarregarClientesTable()
		{
			dataGridViewClientes.Rows.Clear();

			var clientesOrdenadosPorDivida = _service.ObterTodos()
											.OrderByDescending(cliente => _dividaService.TotalDividaPorCpf(cliente.Cpf))
											.ToList();

			foreach (var item in clientesOrdenadosPorDivida)
			{
				decimal totalPendente = _dividaService.TotalDividaPorCpf(item.Cpf);

				dataGridViewClientes.Rows.Add(
					item.IdCliente.ToString(),
					item.Nome,
					item.Cpf,
					item.DataNascimento.ToString("dd/MM/yyyy"),
					item.Idade,
					item.Email,
					$"R$ {totalPendente:N2}"
				);
			}
		}

		private void dataGridViewClientes_CellContentClick(object sender, DataGridViewCellEventArgs e)
		{

		}

		private void labelListagemClientes_Click(object sender, EventArgs e)
		{

		}

		private void btnGerenciarDividas_Click(object sender, EventArgs e)
		{
			if (dataGridViewClientes.CurrentRow == null || dataGridViewClientes.CurrentRow.Index < 0)
			{
				MessageBox.Show("Por favor, selecione um cliente na lista primeiro.");
				return;
			}

			var IdUsers = dataGridViewClientes.CurrentRow.Cells[0].Value;

			if (IdUsers != null && int.TryParse(IdUsers.ToString(), out int IdCliente))
			{
				var clienteSelecionado = _service.ObterPorId(IdCliente);

				if (clienteSelecionado != null)
				{
					DividaList telaDividas = new DividaList(clienteSelecionado, _dividaService);

					telaDividas.ShowDialog();

					CarregarClientesTable();
				}
			}
		}

		private void btnExcluirCliente_Click(object sender, EventArgs e)
		{
			if (dataGridViewClientes.CurrentRow == null) return;

			var idDoCliente = dataGridViewClientes.CurrentRow.Cells[0].Value;

			if (idDoCliente != null && int.TryParse(idDoCliente.ToString(), out int idCliente))
			{
				var resposta = MessageBox.Show("Tem certeza que deseja excluir esse cliente?", "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

				if (resposta == DialogResult.Yes)
				{
					bool sucesso = _service.RemoverCliente(idCliente);

					if (sucesso)
					{
						MessageBox.Show("Cliente removido com sucesso!");
						CarregarClientesTable();
					}
				}
			}
		}

		private void btnEditarCliente_Click(object sender, EventArgs e)
		{
			if (dataGridViewClientes.CurrentRow == null)
			{
				MessageBox.Show("Por favor, selecione um cliente da tabela para editar.", "Aviso");
				return;
			}

			var idDoCliente = dataGridViewClientes.CurrentRow.Cells[0].Value;

			if (idDoCliente != null && int.TryParse(idDoCliente.ToString(), out int idCliente))
			{
				var clienteSelecionado = _service.ObterPorId(idCliente);

				if (clienteSelecionado != null)
				{
					ClienteForm telaEdicao = new ClienteForm(_service, clienteSelecionado);
					telaEdicao.ShowDialog();

					CarregarClientesTable();
				}
			}
		}

		private void btnRecuperarCliente_Click(object sender, EventArgs e)
		{
			if (string.IsNullOrWhiteSpace(txtBoxRecuperar.Text))
			{
				MessageBox.Show("Por favor, digite um CPF para recuperar o cliente.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
				return;
			}

			Clientes clienteRecuperado = _service.RecuperarCliente(txtBoxRecuperar.Text);

			if (clienteRecuperado != null)
			{
				dataGridViewClientes.Rows.Clear();

				decimal totalPendente = _dividaService.TotalDividaPorCpf(clienteRecuperado.Cpf);

				dataGridViewClientes.Rows.Add(
					clienteRecuperado.IdCliente.ToString(),
					clienteRecuperado.Nome,
					clienteRecuperado.Cpf,
					clienteRecuperado.DataNascimento.ToString("dd/MM/yyyy"),
					clienteRecuperado.Idade,
					clienteRecuperado.Email,
					$"R$ {totalPendente:N2}"
				);
			}
			else
			{
				MessageBox.Show("Nenhum cliente cadastrado com este CPF foi encontrado.", "Não Encontrado", MessageBoxButtons.OK, MessageBoxIcon.Information);
			}
		}
	}
}
