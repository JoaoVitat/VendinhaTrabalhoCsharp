using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using VendinhaTrabalho;
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
    }
}
