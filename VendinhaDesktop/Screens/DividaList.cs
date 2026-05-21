using System;
using System.Windows.Forms;
using VendinhaTrabalho.Models;   // Ajuste para o seu namespace dos modelos
using VendinhaTrabalho.Services; // Ajuste para o seu namespace das services

namespace VendinhaDesktop.Screens
{
    public partial class DividaList : Form
    {
        // 1. Variáveis para guardar o cliente e o serviço que vieram da outra tela
        private readonly Clientes _cliente;
        private readonly DividaService _dividaService;

        // 2. O Construtor preparado para receber os dados
        public DividaList(Clientes clienteSelecionado, DividaService dividaService)
        {
            InitializeComponent();

            _cliente = clienteSelecionado;
            _dividaService = dividaService;

            // Coloca os dados do cliente no topo da tela
            lblNomeCliente.Text = $"Cliente: {_cliente.Nome} | CPF: {_cliente.Cpf}";

            // Carrega o histórico de dívidas assim que a tela abre
            CarregarDividasTable();
        }

        // 3. Método para Listar as dívidas na tabela
        private void CarregarDividasTable()
        {
            dataGridViewDividas.Rows.Clear();

            // Usa o seu método da service passando o CPF do cliente atual
            var dividasDoCliente = _dividaService.ObterDividasPorCpf(_cliente.Cpf);

            foreach (var div in dividasDoCliente)
            {
                string status = div.Situacao ? "🟢 Paga" : "🔴 Pendente";
                string dataPagamento = div.DatadePagamento?.ToString("dd/MM/yyyy") ?? "—";

                dataGridViewDividas.Rows.Add(
                    $"R$ {div.Valor:N2}",
                    status,
                    div.DatadeCriacao.ToString("dd/MM/yyyy"),
                    dataPagamento
                );
            }
        }

        // 4. Evento do botão de Criar Dívida
        private void btnSalvarDivida_Click(object sender, EventArgs e)
        {
            // Valida se digitou um valor numérico correto
            if (!decimal.TryParse(txtBoxValor.Text, out decimal valorDigitado) || valorDigitado <= 0)
            {
                MessageBox.Show("Por favor, insira um valor válido maior que zero.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Chama a sua service passando o CPF e o Valor
            string resultado = _dividaService.AdicionarDivida(_cliente.Cpf, valorDigitado);

            if (resultado.StartsWith("Error"))
            {
                MessageBox.Show(resultado, "Regra de Negócio", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                MessageBox.Show(resultado, "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtBoxValor.Clear();
                CarregarDividasTable(); // Recarrega a tabela para mostrar a nova dívida
            }
        }

        // 5. Evento do botão de Marcar como Paga
        //private void btnPagar_Click(object sender, EventArgs e)
        //{
        //    // Chama o seu método de pagar passando o CPF
        //    string resultado = _dividaService.DividaPaga(_cliente.Cpf);

        //    if (resultado.StartsWith("Erro"))
        //    {
        //        MessageBox.Show(resultado, "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        //    }
        //    else
        //    {
        //        MessageBox.Show(resultado, "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
        //        CarregarDividasTable(); // Recarrega a tabela para mudar o status para Paga
        //    }
        //}

        private void DividaList_Load(object sender, EventArgs e)
        {

        }

        private void dataGridViewDividas_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}