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

        public ClienteServices Service { get; }

        public ClienteForm(ClienteServices service)
        {
            Service = service;
            InitializeComponent();
        }

        private void btnCadastrarCliente_Click(object sender, EventArgs e)
        {

            //var cliente = new Clientes();

            //cliente.Nome = txtBoxNome.Text;
            //cliente.Cpf = maskedTxtBoxCpf.Text;
            //cliente.Email = txtBoxEmail.Text;
            //cliente.DataNascimento = dateTimePickerDatanasc.Value;

            //var sucesso = Service.AdicionarCliente(cliente, out string erroDaValidacao);

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
                // Se caiu aqui, é porque o CPF já existia no banco em memória
                errorProvider1.SetError(maskedTxtBoxCpf, erroDeValidacao);
                MessageBox.Show(erroDeValidacao, "Erro de Cadastro", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            //try
            //{
            //	_service.AdicionarCliente(novoCadastroCliente);
            //	MessageBox.Show("Cliente Cadastrado com sucesso!");
            //	this.Close();
            //}
            //catch (Exception ex)
            //{
            //	MessageBox.Show($"Erro ao cadastrar: {ex.Message}");
            //}
        }
    }
}