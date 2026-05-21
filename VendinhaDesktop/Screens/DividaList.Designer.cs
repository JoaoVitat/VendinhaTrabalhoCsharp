namespace VendinhaDesktop.Screens
{
    partial class DividaList
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            dataGridViewDividas = new DataGridView();
            valorDivida = new DataGridViewTextBoxColumn();
            situacaoDivida = new DataGridViewTextBoxColumn();
            dataCompraDivida = new DataGridViewTextBoxColumn();
            dataPagamentoDivida = new DataGridViewTextBoxColumn();
            lblNomeCliente = new Label();
            lblValorDivida = new Label();
            txtBoxValor = new TextBox();
            btnSalvarDivida = new Button();
            ((System.ComponentModel.ISupportInitialize)dataGridViewDividas).BeginInit();
            SuspendLayout();
            // 
            // dataGridViewDividas
            // 
            dataGridViewDividas.BackgroundColor = SystemColors.ButtonHighlight;
            dataGridViewDividas.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewDividas.Columns.AddRange(new DataGridViewColumn[] { valorDivida, situacaoDivida, dataCompraDivida, dataPagamentoDivida });
            dataGridViewDividas.Location = new Point(185, 178);
            dataGridViewDividas.Name = "dataGridViewDividas";
            dataGridViewDividas.Size = new Size(442, 150);
            dataGridViewDividas.TabIndex = 0;
            dataGridViewDividas.CellContentClick += dataGridViewDividas_CellContentClick;
            // 
            // valorDivida
            // 
            valorDivida.HeaderText = "Valor";
            valorDivida.Name = "valorDivida";
            // 
            // situacaoDivida
            // 
            situacaoDivida.HeaderText = "Situação";
            situacaoDivida.Name = "situacaoDivida";
            // 
            // dataCompraDivida
            // 
            dataCompraDivida.HeaderText = "Data da compra";
            dataCompraDivida.Name = "dataCompraDivida";
            // 
            // dataPagamentoDivida
            // 
            dataPagamentoDivida.HeaderText = "Data do Pagamento";
            dataPagamentoDivida.Name = "dataPagamentoDivida";
            // 
            // lblNomeCliente
            // 
            lblNomeCliente.AutoSize = true;
            lblNomeCliente.Font = new Font("Segoe UI", 20.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblNomeCliente.Location = new Point(185, 52);
            lblNomeCliente.Name = "lblNomeCliente";
            lblNomeCliente.Size = new Size(96, 37);
            lblNomeCliente.TabIndex = 1;
            lblNomeCliente.Text = "label1";
            // 
            // lblValorDivida
            // 
            lblValorDivida.AutoSize = true;
            lblValorDivida.Font = new Font("Segoe UI", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblValorDivida.Location = new Point(185, 117);
            lblValorDivida.Name = "lblValorDivida";
            lblValorDivida.Size = new Size(70, 30);
            lblValorDivida.TabIndex = 2;
            lblValorDivida.Text = "Valor:";
            // 
            // txtBoxValor
            // 
            txtBoxValor.Location = new Point(261, 124);
            txtBoxValor.Name = "txtBoxValor";
            txtBoxValor.Size = new Size(165, 23);
            txtBoxValor.TabIndex = 3;
            // 
            // btnSalvarDivida
            // 
            btnSalvarDivida.Font = new Font("Segoe UI Black", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnSalvarDivida.Location = new Point(432, 121);
            btnSalvarDivida.Name = "btnSalvarDivida";
            btnSalvarDivida.Size = new Size(87, 30);
            btnSalvarDivida.TabIndex = 4;
            btnSalvarDivida.Text = "Salvar";
            btnSalvarDivida.UseVisualStyleBackColor = true;
            btnSalvarDivida.Click += btnSalvarDivida_Click;
            // 
            // DividaList
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(btnSalvarDivida);
            Controls.Add(txtBoxValor);
            Controls.Add(lblValorDivida);
            Controls.Add(lblNomeCliente);
            Controls.Add(dataGridViewDividas);
            Name = "DividaList";
            Text = "DividaForm";
            Load += DividaList_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridViewDividas).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dataGridViewDividas;
        private DataGridViewTextBoxColumn valorDivida;
        private DataGridViewTextBoxColumn situacaoDivida;
        private DataGridViewTextBoxColumn dataCompraDivida;
        private DataGridViewTextBoxColumn dataPagamentoDivida;
        private Label lblNomeCliente;
        private Label lblValorDivida;
        private TextBox txtBoxValor;
        private Button btnSalvarDivida;
    }
}