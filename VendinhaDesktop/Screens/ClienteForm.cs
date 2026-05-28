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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace VendinhaDesktop.Screens
{
    public partial class ClienteForm : Form
    {
        private readonly Clientes clientesParaEditar;
        public ClienteServices Service { get; }

        public ClienteForm(ClienteServices service)
        {
            Service = service;
            clientesParaEditar = null;
            this.Text = "Cadstrar Cliente";
            InitializeComponent();
        }

        public ClienteForm(ClienteServices service, Clientes clienteSelecionado)
        {

			InitializeComponent();

			Service = service;
			clientesParaEditar = clienteSelecionado;
			this.Text = "Editar Cliente";
			

			txtBoxNome.Text = clientesParaEditar.Nome;
			maskedTxtBoxCpf.Text = clientesParaEditar.Cpf;
			txtBoxEmail.Text = clientesParaEditar.Email;
			dateTimePickerDatanasc.Value = clientesParaEditar.DataNascimento;
		}

		private void btnCadastrarCliente_Click(object sender, EventArgs e)
        {

            errorProvider1.Clear();

            bool error = false;

            if (txtBoxNome.Text.Trim() == "")
            {
                errorProvider1.SetError(txtBoxNome, "Digite seu nome!");
                error = true;
            }

            if (maskedTxtBoxCpf.Text.Trim() == "")
            {
                errorProvider2.SetError(maskedTxtBoxCpf, "Digite seu Cpf!");
                error = true;
            }

            if (txtBoxEmail.Text.Trim() == "")
            {
                errorProvider3.SetError(txtBoxEmail, "Digite seu Email!");
                error = true;
            }
            if (error)
            {
                return;
            }

            var cadastroCliente = new Clientes
            {
                Nome = txtBoxNome.Text,
                Cpf = maskedTxtBoxCpf.Text,
                DataNascimento = dateTimePickerDatanasc.Value,
                Email = txtBoxEmail.Text
            };

			bool sucesso;
			string erroDeValidacao;

            if (clientesParaEditar == null)
            {
			     sucesso = Service.AdicionarCliente(cadastroCliente, out erroDeValidacao);
            }
            else
            {
                cadastroCliente.IdCliente = clientesParaEditar.IdCliente;

				sucesso = Service.AtualizarCliente(cadastroCliente, out erroDeValidacao);
			}


            if (sucesso)
            {
                string mensagemSucesso = clientesParaEditar == null ? "Cliente cadastrado com sucesso!" : "Cliente editado com sucesso!";
				MessageBox.Show(mensagemSucesso, "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Close();
            }
            else
            {
                errorProvider1.SetError(maskedTxtBoxCpf, erroDeValidacao);
                MessageBox.Show(erroDeValidacao, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

        }
    }
}