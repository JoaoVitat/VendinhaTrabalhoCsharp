namespace VendinhaDesktop.Screens
{
	partial class ClienteListForm
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
			dataGridViewClientes = new DataGridView();
			labelListagemClientes = new Label();
			btnGerenciarCategorias = new Button();
			btnExcluirCliente = new Button();
			btnEditarCliente = new Button();
			lblRecuperar = new Label();
			txtBoxRecuperar = new TextBox();
			btnRecuperarCliente = new Button();
			idDivida = new DataGridViewTextBoxColumn();
			nomeCliente = new DataGridViewTextBoxColumn();
			CpfCliente = new DataGridViewTextBoxColumn();
			datanascCliente = new DataGridViewTextBoxColumn();
			IdadeCliente = new DataGridViewTextBoxColumn();
			emailCliente = new DataGridViewTextBoxColumn();
			totalDivida = new DataGridViewTextBoxColumn();
			((System.ComponentModel.ISupportInitialize)dataGridViewClientes).BeginInit();
			SuspendLayout();
			// 
			// dataGridViewClientes
			// 
			dataGridViewClientes.BackgroundColor = SystemColors.Window;
			dataGridViewClientes.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			dataGridViewClientes.Columns.AddRange(new DataGridViewColumn[] { idDivida, nomeCliente, CpfCliente, datanascCliente, IdadeCliente, emailCliente, totalDivida });
			dataGridViewClientes.Location = new Point(54, 86);
			dataGridViewClientes.Name = "dataGridViewClientes";
			dataGridViewClientes.RowHeadersWidth = 51;
			dataGridViewClientes.Size = new Size(998, 322);
			dataGridViewClientes.TabIndex = 0;
			dataGridViewClientes.CellContentClick += dataGridViewClientes_CellContentClick;
			// 
			// labelListagemClientes
			// 
			labelListagemClientes.AutoSize = true;
			labelListagemClientes.Font = new Font("Segoe UI", 22.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
			labelListagemClientes.Location = new Point(54, 9);
			labelListagemClientes.Name = "labelListagemClientes";
			labelListagemClientes.Size = new Size(379, 50);
			labelListagemClientes.TabIndex = 1;
			labelListagemClientes.Text = "Listagem de Clientes";
			labelListagemClientes.Click += labelListagemClientes_Click;
			// 
			// btnGerenciarCategorias
			// 
			btnGerenciarCategorias.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
			btnGerenciarCategorias.Location = new Point(235, 414);
			btnGerenciarCategorias.Margin = new Padding(3, 4, 3, 4);
			btnGerenciarCategorias.Name = "btnGerenciarCategorias";
			btnGerenciarCategorias.Size = new Size(189, 40);
			btnGerenciarCategorias.TabIndex = 2;
			btnGerenciarCategorias.TabStop = false;
			btnGerenciarCategorias.Text = "Gerenciar Dividas";
			btnGerenciarCategorias.UseVisualStyleBackColor = true;
			btnGerenciarCategorias.Click += btnGerenciarDividas_Click;
			// 
			// btnExcluirCliente
			// 
			btnExcluirCliente.Font = new Font("Segoe UI", 12.2F, FontStyle.Bold);
			btnExcluirCliente.Location = new Point(473, 414);
			btnExcluirCliente.Name = "btnExcluirCliente";
			btnExcluirCliente.Size = new Size(189, 40);
			btnExcluirCliente.TabIndex = 3;
			btnExcluirCliente.Text = "Excluir Cliente";
			btnExcluirCliente.UseVisualStyleBackColor = true;
			btnExcluirCliente.Click += btnExcluirCliente_Click;
			// 
			// btnEditarCliente
			// 
			btnEditarCliente.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
			btnEditarCliente.Location = new Point(716, 414);
			btnEditarCliente.Name = "btnEditarCliente";
			btnEditarCliente.Size = new Size(189, 40);
			btnEditarCliente.TabIndex = 4;
			btnEditarCliente.Text = "Editar Cliente";
			btnEditarCliente.UseVisualStyleBackColor = true;
			btnEditarCliente.Click += btnEditarCliente_Click;
			// 
			// lblRecuperar
			// 
			lblRecuperar.AutoSize = true;
			lblRecuperar.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
			lblRecuperar.Location = new Point(758, 9);
			lblRecuperar.Name = "lblRecuperar";
			lblRecuperar.Size = new Size(208, 31);
			lblRecuperar.TabIndex = 5;
			lblRecuperar.Text = "Recuperar Cliente:";
			// 
			// txtBoxRecuperar
			// 
			txtBoxRecuperar.Location = new Point(758, 47);
			txtBoxRecuperar.Name = "txtBoxRecuperar";
			txtBoxRecuperar.Size = new Size(178, 27);
			txtBoxRecuperar.TabIndex = 6;
			// 
			// btnRecuperarCliente
			// 
			btnRecuperarCliente.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
			btnRecuperarCliente.Location = new Point(942, 47);
			btnRecuperarCliente.Name = "btnRecuperarCliente";
			btnRecuperarCliente.Size = new Size(94, 29);
			btnRecuperarCliente.TabIndex = 7;
			btnRecuperarCliente.Text = "Buscar";
			btnRecuperarCliente.UseVisualStyleBackColor = true;
			btnRecuperarCliente.Click += btnRecuperarCliente_Click;
			// 
			// idDivida
			// 
			idDivida.HeaderText = "ID";
			idDivida.MinimumWidth = 6;
			idDivida.Name = "idDivida";
			idDivida.Width = 50;
			// 
			// nomeCliente
			// 
			nomeCliente.HeaderText = "Nome";
			nomeCliente.MinimumWidth = 6;
			nomeCliente.Name = "nomeCliente";
			nomeCliente.Width = 200;
			// 
			// CpfCliente
			// 
			CpfCliente.HeaderText = "CPF";
			CpfCliente.MinimumWidth = 6;
			CpfCliente.Name = "CpfCliente";
			CpfCliente.Width = 160;
			// 
			// datanascCliente
			// 
			datanascCliente.HeaderText = "Data de Nascimento";
			datanascCliente.MinimumWidth = 6;
			datanascCliente.Name = "datanascCliente";
			datanascCliente.Width = 125;
			// 
			// IdadeCliente
			// 
			IdadeCliente.HeaderText = "Idade";
			IdadeCliente.MinimumWidth = 6;
			IdadeCliente.Name = "IdadeCliente";
			IdadeCliente.Width = 60;
			// 
			// emailCliente
			// 
			emailCliente.HeaderText = "Email";
			emailCliente.MinimumWidth = 6;
			emailCliente.Name = "emailCliente";
			emailCliente.Width = 200;
			// 
			// totalDivida
			// 
			totalDivida.HeaderText = "Total de divida";
			totalDivida.MinimumWidth = 6;
			totalDivida.Name = "totalDivida";
			totalDivida.Width = 150;
			// 
			// ClienteListForm
			// 
			AutoScaleDimensions = new SizeF(8F, 20F);
			AutoScaleMode = AutoScaleMode.Font;
			ClientSize = new Size(1099, 494);
			Controls.Add(btnRecuperarCliente);
			Controls.Add(txtBoxRecuperar);
			Controls.Add(lblRecuperar);
			Controls.Add(btnEditarCliente);
			Controls.Add(btnExcluirCliente);
			Controls.Add(btnGerenciarCategorias);
			Controls.Add(labelListagemClientes);
			Controls.Add(dataGridViewClientes);
			Name = "ClienteListForm";
			Text = "Form1";
			((System.ComponentModel.ISupportInitialize)dataGridViewClientes).EndInit();
			ResumeLayout(false);
			PerformLayout();
		}

		#endregion

		private DataGridView dataGridViewClientes;
		private Label labelListagemClientes;
        private Button btnGerenciarCategorias;
		private Button btnExcluirCliente;
		private Button btnEditarCliente;
		private Label lblRecuperar;
		private TextBox txtBoxRecuperar;
		private Button btnRecuperarCliente;
		private DataGridViewTextBoxColumn idDivida;
		private DataGridViewTextBoxColumn nomeCliente;
		private DataGridViewTextBoxColumn CpfCliente;
		private DataGridViewTextBoxColumn datanascCliente;
		private DataGridViewTextBoxColumn IdadeCliente;
		private DataGridViewTextBoxColumn emailCliente;
		private DataGridViewTextBoxColumn totalDivida;
	}
}