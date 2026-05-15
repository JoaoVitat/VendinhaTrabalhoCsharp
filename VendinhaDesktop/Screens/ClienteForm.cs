using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using VendinhaTrabalho;
using VendinhaTrabalho.Models;

namespace VendinhaDesktop.Screens
{
	public partial class ClienteForm : Form
	{
		private readonly ClienteServices _service;
		public ClienteForm(ClienteServices service)
		{
			InitializeComponent();

			_service = service;
		}

		private void btnCadastrarCliente_Click(object sender, EventArgs e)
		{
			var novoCadastroCliente = new Clientes
			{
				Nome = txtBoxNome.Text,
				Cpf = maskedTxtBoxCpf.Text,
				DataNascimento = dateTimePickerDatanasc.Value,
				Email = txtBoxEmail.Text
			};

			try
			{
				_service.AdicionarCliente(novoCadastroCliente);
				MessageBox.Show("Cliente Cadastrado com sucesso!");
				this.Close();
			}
			catch (Exception ex)
			{
				MessageBox.Show($"Erro ao cadastrar: {ex.Message}");
			}
		}
	}
}
