namespace VendinhaDesktop.Screens
{
	partial class ClienteForm
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
            components = new System.ComponentModel.Container();
            txtBoxNome = new TextBox();
            labelNomeCadastro = new Label();
            labelCpfCadastro = new Label();
            labelDatanascCadastro = new Label();
            txtBoxEmail = new TextBox();
            labelEmailCadastro = new Label();
            buttonCadastrar = new Button();
            maskedTxtBoxCpf = new MaskedTextBox();
            dateTimePickerDatanasc = new DateTimePicker();
            errorProvider1 = new ErrorProvider(components);
            errorProvider2 = new ErrorProvider(components);
            errorProvider3 = new ErrorProvider(components);
            ((System.ComponentModel.ISupportInitialize)errorProvider1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)errorProvider2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)errorProvider3).BeginInit();
            SuspendLayout();
            // 
            // txtBoxNome
            // 
            txtBoxNome.Location = new Point(220, 66);
            txtBoxNome.Margin = new Padding(3, 2, 3, 2);
            txtBoxNome.Name = "txtBoxNome";
            txtBoxNome.Size = new Size(272, 23);
            txtBoxNome.TabIndex = 0;
            // 
            // labelNomeCadastro
            // 
            labelNomeCadastro.AutoSize = true;
            labelNomeCadastro.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            labelNomeCadastro.Location = new Point(160, 66);
            labelNomeCadastro.Name = "labelNomeCadastro";
            labelNomeCadastro.Size = new Size(54, 19);
            labelNomeCadastro.TabIndex = 1;
            labelNomeCadastro.Text = "Nome:";
            // 
            // labelCpfCadastro
            // 
            labelCpfCadastro.AutoSize = true;
            labelCpfCadastro.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            labelCpfCadastro.Location = new Point(176, 104);
            labelCpfCadastro.Name = "labelCpfCadastro";
            labelCpfCadastro.Size = new Size(38, 19);
            labelCpfCadastro.TabIndex = 3;
            labelCpfCadastro.Text = "CPF:";
            // 
            // labelDatanascCadastro
            // 
            labelDatanascCadastro.AutoSize = true;
            labelDatanascCadastro.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            labelDatanascCadastro.Location = new Point(65, 140);
            labelDatanascCadastro.Name = "labelDatanascCadastro";
            labelDatanascCadastro.Size = new Size(148, 19);
            labelDatanascCadastro.TabIndex = 5;
            labelDatanascCadastro.Text = "Data de Nascimento:";
            // 
            // txtBoxEmail
            // 
            txtBoxEmail.Location = new Point(220, 179);
            txtBoxEmail.Margin = new Padding(3, 2, 3, 2);
            txtBoxEmail.Name = "txtBoxEmail";
            txtBoxEmail.Size = new Size(272, 23);
            txtBoxEmail.TabIndex = 6;
            // 
            // labelEmailCadastro
            // 
            labelEmailCadastro.AutoSize = true;
            labelEmailCadastro.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            labelEmailCadastro.Location = new Point(172, 182);
            labelEmailCadastro.Name = "labelEmailCadastro";
            labelEmailCadastro.Size = new Size(49, 19);
            labelEmailCadastro.TabIndex = 7;
            labelEmailCadastro.Text = "Email:";
            // 
            // buttonCadastrar
            // 
            buttonCadastrar.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            buttonCadastrar.Location = new Point(269, 220);
            buttonCadastrar.Margin = new Padding(3, 2, 3, 2);
            buttonCadastrar.Name = "buttonCadastrar";
            buttonCadastrar.Size = new Size(144, 32);
            buttonCadastrar.TabIndex = 8;
            buttonCadastrar.Text = "Cadastrar";
            buttonCadastrar.UseVisualStyleBackColor = true;
            buttonCadastrar.Click += btnCadastrarCliente_Click;
            // 
            // maskedTxtBoxCpf
            // 
            maskedTxtBoxCpf.Location = new Point(220, 104);
            maskedTxtBoxCpf.Margin = new Padding(3, 2, 3, 2);
            maskedTxtBoxCpf.Name = "maskedTxtBoxCpf";
            maskedTxtBoxCpf.Size = new Size(272, 23);
            maskedTxtBoxCpf.TabIndex = 9;
            // 
            // dateTimePickerDatanasc
            // 
            dateTimePickerDatanasc.Location = new Point(220, 140);
            dateTimePickerDatanasc.Margin = new Padding(3, 2, 3, 2);
            dateTimePickerDatanasc.Name = "dateTimePickerDatanasc";
            dateTimePickerDatanasc.Size = new Size(272, 23);
            dateTimePickerDatanasc.TabIndex = 10;
            // 
            // errorProvider1
            // 
            errorProvider1.ContainerControl = this;
            // 
            // errorProvider2
            // 
            errorProvider2.ContainerControl = this;
            // 
            // errorProvider3
            // 
            errorProvider3.ContainerControl = this;
            // 
            // ClienteForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(700, 338);
            Controls.Add(dateTimePickerDatanasc);
            Controls.Add(maskedTxtBoxCpf);
            Controls.Add(buttonCadastrar);
            Controls.Add(labelEmailCadastro);
            Controls.Add(txtBoxEmail);
            Controls.Add(labelDatanascCadastro);
            Controls.Add(labelCpfCadastro);
            Controls.Add(labelNomeCadastro);
            Controls.Add(txtBoxNome);
            Margin = new Padding(3, 2, 3, 2);
            Name = "ClienteForm";
            Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)errorProvider1).EndInit();
            ((System.ComponentModel.ISupportInitialize)errorProvider2).EndInit();
            ((System.ComponentModel.ISupportInitialize)errorProvider3).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txtBoxNome;
		private Label labelNomeCadastro;
		private Label labelCpfCadastro;
		private Label labelDatanascCadastro;
		private TextBox txtBoxEmail;
		private Label labelEmailCadastro;
		private Button buttonCadastrar;
		private MaskedTextBox maskedTxtBoxCpf;
		private DateTimePicker dateTimePickerDatanasc;
        private ErrorProvider errorProvider1;
        private ErrorProvider errorProvider2;
        private ErrorProvider errorProvider3;
    }
}