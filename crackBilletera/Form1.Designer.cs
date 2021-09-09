
namespace crackBilletera
{
    partial class Form1
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.btnIniciar = new System.Windows.Forms.Button();
            this.txtHistorial = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtNumeroBilletera = new System.Windows.Forms.TextBox();
            this.comboDigitos = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.lblResultado = new System.Windows.Forms.Label();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.lblAvance = new System.Windows.Forms.Label();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.label2 = new System.Windows.Forms.Label();
            this.ordenAleatorio = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(133, 17);
            this.label1.TabIndex = 1;
            this.label1.Text = "Número de Billetera";
            // 
            // btnIniciar
            // 
            this.btnIniciar.BackColor = System.Drawing.Color.Teal;
            this.btnIniciar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnIniciar.ForeColor = System.Drawing.Color.White;
            this.btnIniciar.Location = new System.Drawing.Point(225, 12);
            this.btnIniciar.Name = "btnIniciar";
            this.btnIniciar.Size = new System.Drawing.Size(78, 39);
            this.btnIniciar.TabIndex = 2;
            this.btnIniciar.Text = "Iniciar";
            this.btnIniciar.UseVisualStyleBackColor = false;
            this.btnIniciar.Click += new System.EventHandler(this.btnIniciar_Click);
            // 
            // txtHistorial
            // 
            this.txtHistorial.Location = new System.Drawing.Point(17, 111);
            this.txtHistorial.Multiline = true;
            this.txtHistorial.Name = "txtHistorial";
            this.txtHistorial.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtHistorial.Size = new System.Drawing.Size(434, 207);
            this.txtHistorial.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(14, 91);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(59, 17);
            this.label3.TabIndex = 5;
            this.label3.Text = "Historial";
            // 
            // txtNumeroBilletera
            // 
            this.txtNumeroBilletera.Location = new System.Drawing.Point(15, 29);
            this.txtNumeroBilletera.Name = "txtNumeroBilletera";
            this.txtNumeroBilletera.Size = new System.Drawing.Size(130, 22);
            this.txtNumeroBilletera.TabIndex = 1;
            this.txtNumeroBilletera.Text = "83619016";
            // 
            // comboDigitos
            // 
            this.comboDigitos.FormattingEnabled = true;
            this.comboDigitos.Items.AddRange(new object[] {
            "4",
            "6",
            "8"});
            this.comboDigitos.Location = new System.Drawing.Point(161, 27);
            this.comboDigitos.Name = "comboDigitos";
            this.comboDigitos.Size = new System.Drawing.Size(58, 24);
            this.comboDigitos.TabIndex = 6;
            this.comboDigitos.Text = "6";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(158, 7);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(51, 17);
            this.label4.TabIndex = 7;
            this.label4.Text = "Digitos";
            // 
            // lblResultado
            // 
            this.lblResultado.AutoSize = true;
            this.lblResultado.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblResultado.ForeColor = System.Drawing.Color.DarkRed;
            this.lblResultado.Location = new System.Drawing.Point(14, 321);
            this.lblResultado.Name = "lblResultado";
            this.lblResultado.Size = new System.Drawing.Size(168, 32);
            this.lblResultado.TabIndex = 8;
            this.lblResultado.Text = "Resultado...";
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(309, 27);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(142, 23);
            this.progressBar1.TabIndex = 9;
            // 
            // lblAvance
            // 
            this.lblAvance.AutoSize = true;
            this.lblAvance.ForeColor = System.Drawing.Color.DimGray;
            this.lblAvance.Location = new System.Drawing.Point(309, 7);
            this.lblAvance.Name = "lblAvance";
            this.lblAvance.Size = new System.Drawing.Size(0, 17);
            this.lblAvance.TabIndex = 10;
            // 
            // linkLabel1
            // 
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.Location = new System.Drawing.Point(142, 382);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(161, 17);
            this.linkLabel1.TabIndex = 11;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "https://carlosernesto.net";
            this.linkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(132, 365);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(183, 17);
            this.label2.TabIndex = 12;
            this.label2.Text = "Creado por Carlos E. López";
            // 
            // ordenAleatorio
            // 
            this.ordenAleatorio.AutoSize = true;
            this.ordenAleatorio.Checked = true;
            this.ordenAleatorio.CheckState = System.Windows.Forms.CheckState.Checked;
            this.ordenAleatorio.Location = new System.Drawing.Point(15, 57);
            this.ordenAleatorio.Name = "ordenAleatorio";
            this.ordenAleatorio.Size = new System.Drawing.Size(130, 21);
            this.ordenAleatorio.TabIndex = 13;
            this.ordenAleatorio.Text = "Orden Aleatorio";
            this.ordenAleatorio.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(463, 409);
            this.Controls.Add(this.ordenAleatorio);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.linkLabel1);
            this.Controls.Add(this.lblAvance);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.lblResultado);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.comboDigitos);
            this.Controls.Add(this.txtNumeroBilletera);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtHistorial);
            this.Controls.Add(this.btnIniciar);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Crack Billetera (Prueba de Concepto)";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnIniciar;
        private System.Windows.Forms.TextBox txtHistorial;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtNumeroBilletera;
        private System.Windows.Forms.ComboBox comboDigitos;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lblResultado;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.Label lblAvance;
        private System.Windows.Forms.LinkLabel linkLabel1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckBox ordenAleatorio;
    }
}

