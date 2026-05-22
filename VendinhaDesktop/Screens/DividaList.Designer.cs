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
			btnRetirarDivida = new Button();
			((System.ComponentModel.ISupportInitialize)dataGridViewDividas).BeginInit();
			SuspendLayout();
			// 
			// dataGridViewDividas
			// 
			dataGridViewDividas.BackgroundColor = SystemColors.ButtonHighlight;
			dataGridViewDividas.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			dataGridViewDividas.Columns.AddRange(new DataGridViewColumn[] { valorDivida, situacaoDivida, dataCompraDivida, dataPagamentoDivida });
			dataGridViewDividas.Location = new Point(211, 237);
			dataGridViewDividas.Margin = new Padding(3, 4, 3, 4);
			dataGridViewDividas.Name = "dataGridViewDividas";
			dataGridViewDividas.RowHeadersWidth = 51;
			dataGridViewDividas.Size = new Size(505, 200);
			dataGridViewDividas.TabIndex = 0;
			dataGridViewDividas.CellContentClick += dataGridViewDividas_CellContentClick;
			// 
			// valorDivida
			// 
			valorDivida.HeaderText = "Valor";
			valorDivida.MinimumWidth = 6;
			valorDivida.Name = "valorDivida";
			valorDivida.Width = 125;
			// 
			// situacaoDivida
			// 
			situacaoDivida.HeaderText = "Situação";
			situacaoDivida.MinimumWidth = 6;
			situacaoDivida.Name = "situacaoDivida";
			situacaoDivida.Width = 125;
			// 
			// dataCompraDivida
			// 
			dataCompraDivida.HeaderText = "Data da compra";
			dataCompraDivida.MinimumWidth = 6;
			dataCompraDivida.Name = "dataCompraDivida";
			dataCompraDivida.Width = 125;
			// 
			// dataPagamentoDivida
			// 
			dataPagamentoDivida.HeaderText = "Data do Pagamento";
			dataPagamentoDivida.MinimumWidth = 6;
			dataPagamentoDivida.Name = "dataPagamentoDivida";
			dataPagamentoDivida.Width = 125;
			// 
			// lblNomeCliente
			// 
			lblNomeCliente.AutoSize = true;
			lblNomeCliente.Font = new Font("Segoe UI", 20.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
			lblNomeCliente.Location = new Point(211, 69);
			lblNomeCliente.Name = "lblNomeCliente";
			lblNomeCliente.Size = new Size(117, 46);
			lblNomeCliente.TabIndex = 1;
			lblNomeCliente.Text = "label1";
			// 
			// lblValorDivida
			// 
			lblValorDivida.AutoSize = true;
			lblValorDivida.Font = new Font("Segoe UI", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
			lblValorDivida.Location = new Point(211, 156);
			lblValorDivida.Name = "lblValorDivida";
			lblValorDivida.Size = new Size(92, 37);
			lblValorDivida.TabIndex = 2;
			lblValorDivida.Text = "Valor:";
			// 
			// txtBoxValor
			// 
			txtBoxValor.Location = new Point(298, 165);
			txtBoxValor.Margin = new Padding(3, 4, 3, 4);
			txtBoxValor.Name = "txtBoxValor";
			txtBoxValor.Size = new Size(188, 27);
			txtBoxValor.TabIndex = 3;
			// 
			// btnSalvarDivida
			// 
			btnSalvarDivida.Font = new Font("Segoe UI Black", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
			btnSalvarDivida.Location = new Point(494, 161);
			btnSalvarDivida.Margin = new Padding(3, 4, 3, 4);
			btnSalvarDivida.Name = "btnSalvarDivida";
			btnSalvarDivida.Size = new Size(99, 40);
			btnSalvarDivida.TabIndex = 4;
			btnSalvarDivida.Text = "Salvar";
			btnSalvarDivida.UseVisualStyleBackColor = true;
			btnSalvarDivida.Click += btnSalvarDivida_Click;
			// 
			// btnRetirarDivida
			// 
			btnRetirarDivida.Font = new Font("Segoe UI", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
			btnRetirarDivida.Location = new Point(332, 444);
			btnRetirarDivida.Name = "btnRetirarDivida";
			btnRetirarDivida.Size = new Size(261, 47);
			btnRetirarDivida.TabIndex = 5;
			btnRetirarDivida.Text = "Retirar Divida";
			btnRetirarDivida.UseVisualStyleBackColor = true;
			btnRetirarDivida.Click += btnRetirarDivida_Click;
			// 
			// DividaList
			// 
			AutoScaleDimensions = new SizeF(8F, 20F);
			AutoScaleMode = AutoScaleMode.Font;
			ClientSize = new Size(914, 600);
			Controls.Add(btnRetirarDivida);
			Controls.Add(btnSalvarDivida);
			Controls.Add(txtBoxValor);
			Controls.Add(lblValorDivida);
			Controls.Add(lblNomeCliente);
			Controls.Add(dataGridViewDividas);
			Margin = new Padding(3, 4, 3, 4);
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
		private Button btnRetirarDivida;
	}
}