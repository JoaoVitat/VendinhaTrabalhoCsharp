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
			nomeCliente = new DataGridViewTextBoxColumn();
			CpfCliente = new DataGridViewTextBoxColumn();
			datanascCliente = new DataGridViewTextBoxColumn();
			IdadeCliente = new DataGridViewTextBoxColumn();
			emailCliente = new DataGridViewTextBoxColumn();
			((System.ComponentModel.ISupportInitialize)dataGridViewClientes).BeginInit();
			SuspendLayout();
			// 
			// dataGridViewClientes
			// 
			dataGridViewClientes.BackgroundColor = SystemColors.Window;
			dataGridViewClientes.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			dataGridViewClientes.Columns.AddRange(new DataGridViewColumn[] { nomeCliente, CpfCliente, datanascCliente, IdadeCliente, emailCliente });
			dataGridViewClientes.Location = new Point(3, 62);
			dataGridViewClientes.Name = "dataGridViewClientes";
			dataGridViewClientes.RowHeadersWidth = 51;
			dataGridViewClientes.Size = new Size(795, 352);
			dataGridViewClientes.TabIndex = 0;
			dataGridViewClientes.CellContentClick += dataGridViewClientes_CellContentClick;
			// 
			// labelListagemClientes
			// 
			labelListagemClientes.AutoSize = true;
			labelListagemClientes.Font = new Font("Segoe UI", 22.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
			labelListagemClientes.Location = new Point(219, 9);
			labelListagemClientes.Name = "labelListagemClientes";
			labelListagemClientes.Size = new Size(389, 50);
			labelListagemClientes.TabIndex = 1;
			labelListagemClientes.Text = "Listagem de Clientes:";
			labelListagemClientes.Click += labelListagemClientes_Click;
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
			// ClienteListForm
			// 
			AutoScaleDimensions = new SizeF(8F, 20F);
			AutoScaleMode = AutoScaleMode.Font;
			ClientSize = new Size(800, 450);
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
		private DataGridViewTextBoxColumn nomeCliente;
		private DataGridViewTextBoxColumn CpfCliente;
		private DataGridViewTextBoxColumn datanascCliente;
		private DataGridViewTextBoxColumn IdadeCliente;
		private DataGridViewTextBoxColumn emailCliente;
	}
}