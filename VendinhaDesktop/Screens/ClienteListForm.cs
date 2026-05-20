using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using VendinhaTrabalho;

namespace VendinhaDesktop.Screens
{
	public partial class ClienteListForm : Form
	{
		private readonly ClienteServices _service;
		public ClienteListForm(ClienteServices service)
		{
			_service = service;


			InitializeComponent();
			CarregarClientesTable();


		}

		private void CarregarClientesTable()
		{
			dataGridViewClientes.Rows.Clear();

			foreach (var item in _service.ObterTodos())
			{
				dataGridViewClientes.Rows.Add(
					item.IdCliente.ToString(),
					item.Nome,
					item.Cpf,
					item.DataNascimento.ToString("dd/MM/yyyy"),
					item.Idade,
					item.Email
				);
			}
		}

		private void dataGridViewClientes_CellContentClick(object sender, DataGridViewCellEventArgs e)
		{

		}

		private void labelListagemClientes_Click(object sender, EventArgs e)
		{

		}
	}
}
