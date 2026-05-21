namespace VendinhaDesktop
{
	partial class Form1
	{
		/// <summary>
		///  Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            buttonCadastrar = new Button();
            buttonListar = new Button();
            labelEscolhaOpcao = new Label();
            SuspendLayout();
            // 
            // buttonCadastrar
            // 
            buttonCadastrar.Font = new Font("Segoe UI", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            buttonCadastrar.Location = new Point(47, 185);
            buttonCadastrar.Margin = new Padding(3, 2, 3, 2);
            buttonCadastrar.Name = "buttonCadastrar";
            buttonCadastrar.Size = new Size(263, 40);
            buttonCadastrar.TabIndex = 0;
            buttonCadastrar.Text = "Cadastrar Clientes";
            buttonCadastrar.UseVisualStyleBackColor = true;
            buttonCadastrar.Click += button1_Click;
            // 
            // buttonListar
            // 
            buttonListar.Font = new Font("Segoe UI", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            buttonListar.Location = new Point(380, 185);
            buttonListar.Margin = new Padding(3, 2, 3, 2);
            buttonListar.Name = "buttonListar";
            buttonListar.Size = new Size(263, 40);
            buttonListar.TabIndex = 1;
            buttonListar.Text = "Listar Clientes";
            buttonListar.UseVisualStyleBackColor = true;
            buttonListar.Click += btnListar_Click;
            // 
            // labelEscolhaOpcao
            // 
            labelEscolhaOpcao.AutoSize = true;
            labelEscolhaOpcao.Font = new Font("Segoe UI", 24F, FontStyle.Bold, GraphicsUnit.Point, 0);
            labelEscolhaOpcao.Location = new Point(200, 75);
            labelEscolhaOpcao.Name = "labelEscolhaOpcao";
            labelEscolhaOpcao.Size = new Size(319, 45);
            labelEscolhaOpcao.TabIndex = 2;
            labelEscolhaOpcao.Text = "Escolha uma Opção:";
            labelEscolhaOpcao.Click += labelEscolhaOpcao_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(700, 338);
            Controls.Add(labelEscolhaOpcao);
            Controls.Add(buttonListar);
            Controls.Add(buttonCadastrar);
            Margin = new Padding(3, 2, 3, 2);
            Name = "Form1";
            Text = "Form1";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button buttonCadastrar;
		private Button buttonListar;
		private Label labelEscolhaOpcao;
    }
}
