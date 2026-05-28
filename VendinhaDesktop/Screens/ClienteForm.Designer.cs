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
			txtBoxNome.Location = new Point(251, 88);
			txtBoxNome.Name = "txtBoxNome";
			txtBoxNome.Size = new Size(310, 27);
			txtBoxNome.TabIndex = 0;
			// 
			// labelNomeCadastro
			// 
			labelNomeCadastro.AutoSize = true;
			labelNomeCadastro.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
			labelNomeCadastro.Location = new Point(183, 88);
			labelNomeCadastro.Name = "labelNomeCadastro";
			labelNomeCadastro.Size = new Size(63, 23);
			labelNomeCadastro.TabIndex = 1;
			labelNomeCadastro.Text = "Nome:";
			// 
			// labelCpfCadastro
			// 
			labelCpfCadastro.AutoSize = true;
			labelCpfCadastro.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
			labelCpfCadastro.Location = new Point(201, 139);
			labelCpfCadastro.Name = "labelCpfCadastro";
			labelCpfCadastro.Size = new Size(45, 23);
			labelCpfCadastro.TabIndex = 3;
			labelCpfCadastro.Text = "CPF:";
			// 
			// labelDatanascCadastro
			// 
			labelDatanascCadastro.AutoSize = true;
			labelDatanascCadastro.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
			labelDatanascCadastro.Location = new Point(74, 187);
			labelDatanascCadastro.Name = "labelDatanascCadastro";
			labelDatanascCadastro.Size = new Size(177, 23);
			labelDatanascCadastro.TabIndex = 5;
			labelDatanascCadastro.Text = "Data de Nascimento:";
			// 
			// txtBoxEmail
			// 
			txtBoxEmail.Location = new Point(251, 239);
			txtBoxEmail.Name = "txtBoxEmail";
			txtBoxEmail.Size = new Size(310, 27);
			txtBoxEmail.TabIndex = 6;
			// 
			// labelEmailCadastro
			// 
			labelEmailCadastro.AutoSize = true;
			labelEmailCadastro.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
			labelEmailCadastro.Location = new Point(197, 243);
			labelEmailCadastro.Name = "labelEmailCadastro";
			labelEmailCadastro.Size = new Size(59, 23);
			labelEmailCadastro.TabIndex = 7;
			labelEmailCadastro.Text = "Email:";
			// 
			// buttonCadastrar
			// 
			buttonCadastrar.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
			buttonCadastrar.Location = new Point(307, 293);
			buttonCadastrar.Name = "buttonCadastrar";
			buttonCadastrar.Size = new Size(165, 43);
			buttonCadastrar.TabIndex = 8;
			buttonCadastrar.Text = "Cadastrar";
			buttonCadastrar.UseVisualStyleBackColor = true;
			buttonCadastrar.Click += btnCadastrarCliente_Click;
			// 
			// maskedTxtBoxCpf
			// 
			maskedTxtBoxCpf.Location = new Point(251, 139);
			maskedTxtBoxCpf.Name = "maskedTxtBoxCpf";
			maskedTxtBoxCpf.Size = new Size(310, 27);
			maskedTxtBoxCpf.TabIndex = 9;
			// 
			// dateTimePickerDatanasc
			// 
			dateTimePickerDatanasc.Location = new Point(251, 187);
			dateTimePickerDatanasc.Name = "dateTimePickerDatanasc";
			dateTimePickerDatanasc.Size = new Size(310, 27);
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
			AutoScaleDimensions = new SizeF(8F, 20F);
			AutoScaleMode = AutoScaleMode.Font;
			ClientSize = new Size(800, 451);
			Controls.Add(dateTimePickerDatanasc);
			Controls.Add(maskedTxtBoxCpf);
			Controls.Add(buttonCadastrar);
			Controls.Add(labelEmailCadastro);
			Controls.Add(txtBoxEmail);
			Controls.Add(labelDatanascCadastro);
			Controls.Add(labelCpfCadastro);
			Controls.Add(labelNomeCadastro);
			Controls.Add(txtBoxNome);
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