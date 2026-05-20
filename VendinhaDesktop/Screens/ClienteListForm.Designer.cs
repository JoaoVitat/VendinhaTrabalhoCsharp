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
            idDivida = new DataGridViewTextBoxColumn();
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
            dataGridViewClientes.Columns.AddRange(new DataGridViewColumn[] { idDivida, nomeCliente, CpfCliente, datanascCliente, IdadeCliente, emailCliente });
            dataGridViewClientes.Location = new Point(3, 46);
            dataGridViewClientes.Margin = new Padding(3, 2, 3, 2);
            dataGridViewClientes.Name = "dataGridViewClientes";
            dataGridViewClientes.RowHeadersWidth = 51;
            dataGridViewClientes.Size = new Size(696, 264);
            dataGridViewClientes.TabIndex = 0;
            dataGridViewClientes.CellContentClick += dataGridViewClientes_CellContentClick;
            // 
            // labelListagemClientes
            // 
            labelListagemClientes.AutoSize = true;
            labelListagemClientes.Font = new Font("Segoe UI", 22.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            labelListagemClientes.Location = new Point(192, 7);
            labelListagemClientes.Name = "labelListagemClientes";
            labelListagemClientes.Size = new Size(316, 41);
            labelListagemClientes.TabIndex = 1;
            labelListagemClientes.Text = "Listagem de Clientes:";
            labelListagemClientes.Click += labelListagemClientes_Click;
            // 
            // idDivida
            // 
            idDivida.HeaderText = "ID";
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
            // ClienteListForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(700, 338);
            Controls.Add(labelListagemClientes);
            Controls.Add(dataGridViewClientes);
            Margin = new Padding(3, 2, 3, 2);
            Name = "ClienteListForm";
            Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)dataGridViewClientes).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dataGridViewClientes;
		private Label labelListagemClientes;
        private DataGridViewTextBoxColumn idDivida;
        private DataGridViewTextBoxColumn nomeCliente;
        private DataGridViewTextBoxColumn CpfCliente;
        private DataGridViewTextBoxColumn datanascCliente;
        private DataGridViewTextBoxColumn IdadeCliente;
        private DataGridViewTextBoxColumn emailCliente;
    }
}