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
			Service = service;
			clientesParaEditar = clienteSelecionado;
			this.Text = "Editar Cliente";
			InitializeComponent();

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
                errorProvider1.SetError(maskedTxtBoxCpf, "Digite seu Cpf!");
                error = true;
            }

            if (txtBoxEmail.Text.Trim() == "")
            {
                errorProvider1.SetError(txtBoxEmail, "Digite seu Email!");
            }
            if (error)
            {
                return;
            }

            var novoCadastroCliente = new Clientes
            {
                Nome = txtBoxNome.Text,
                Cpf = maskedTxtBoxCpf.Text,
                DataNascimento = dateTimePickerDatanasc.Value,
                Email = txtBoxEmail.Text
            };

            var sucesso = Service.AdicionarCliente(novoCadastroCliente, out string erroDeValidacao);

            if (sucesso)
            {
                MessageBox.Show("Cliente cadastrado com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Close();
            }
            else
            {
                errorProvider1.SetError(maskedTxtBoxCpf, erroDeValidacao);
                MessageBox.Show(erroDeValidacao, "Erro de Cadastro", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}