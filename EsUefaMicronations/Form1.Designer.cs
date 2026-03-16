namespace EsUefaMicronations
{
    partial class Form1
    {
        /// <summary>
        /// Variabile di progettazione necessaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Pulire le risorse in uso.
        /// </summary>
        /// <param name="disposing">ha valore true se le risorse gestite devono essere eliminate, false in caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Codice generato da Progettazione Windows Form

        /// <summary>
        /// Metodo necessario per il supporto della finestra di progettazione. Non modificare
        /// il contenuto del metodo con l'editor di codice.
        /// </summary>
        private void InitializeComponent()
        {
            this.txtSquadraCasa = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtGolCasa = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtSquadraOspite = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtGolOspite = new System.Windows.Forms.TextBox();
            this.lstInterfaccia = new System.Windows.Forms.ListBox();
            this.btnStatistiche = new System.Windows.Forms.Button();
            this.btnCerca = new System.Windows.Forms.Button();
            this.btnSalva = new System.Windows.Forms.Button();
            this.txtCerca = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // txtSquadraCasa
            // 
            this.txtSquadraCasa.Location = new System.Drawing.Point(12, 42);
            this.txtSquadraCasa.Name = "txtSquadraCasa";
            this.txtSquadraCasa.Size = new System.Drawing.Size(139, 22);
            this.txtSquadraCasa.TabIndex = 0;
            this.txtSquadraCasa.TextChanged += new System.EventHandler(this.txtSquadraCasa_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(32, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(106, 16);
            this.label1.TabIndex = 1;
            this.label1.Text = "Squadra di casa";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(23, 117);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(128, 16);
            this.label4.TabIndex = 7;
            this.label4.Text = "Gol squadra di casa";
            // 
            // txtGolCasa
            // 
            this.txtGolCasa.Location = new System.Drawing.Point(38, 136);
            this.txtGolCasa.Name = "txtGolCasa";
            this.txtGolCasa.Size = new System.Drawing.Size(100, 22);
            this.txtGolCasa.TabIndex = 6;
            this.txtGolCasa.TextChanged += new System.EventHandler(this.txtGolCasa_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(236, 23);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(99, 16);
            this.label2.TabIndex = 9;
            this.label2.Text = "Squadra ospite";
            // 
            // txtSquadraOspite
            // 
            this.txtSquadraOspite.Location = new System.Drawing.Point(216, 42);
            this.txtSquadraOspite.Name = "txtSquadraOspite";
            this.txtSquadraOspite.Size = new System.Drawing.Size(139, 22);
            this.txtSquadraOspite.TabIndex = 8;
            this.txtSquadraOspite.TextChanged += new System.EventHandler(this.txtSquadraOspite_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(223, 117);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(121, 16);
            this.label3.TabIndex = 11;
            this.label3.Text = "Gol squadra ospite";
            // 
            // txtGolOspite
            // 
            this.txtGolOspite.Location = new System.Drawing.Point(235, 136);
            this.txtGolOspite.Name = "txtGolOspite";
            this.txtGolOspite.Size = new System.Drawing.Size(100, 22);
            this.txtGolOspite.TabIndex = 10;
            this.txtGolOspite.TextChanged += new System.EventHandler(this.txtGolOspite_TextChanged);
            // 
            // lstInterfaccia
            // 
            this.lstInterfaccia.FormattingEnabled = true;
            this.lstInterfaccia.ItemHeight = 16;
            this.lstInterfaccia.Location = new System.Drawing.Point(376, 18);
            this.lstInterfaccia.Name = "lstInterfaccia";
            this.lstInterfaccia.Size = new System.Drawing.Size(412, 420);
            this.lstInterfaccia.TabIndex = 12;
            // 
            // btnStatistiche
            // 
            this.btnStatistiche.Location = new System.Drawing.Point(243, 228);
            this.btnStatistiche.Name = "btnStatistiche";
            this.btnStatistiche.Size = new System.Drawing.Size(92, 23);
            this.btnStatistiche.TabIndex = 13;
            this.btnStatistiche.Text = "Statistiche";
            this.btnStatistiche.UseVisualStyleBackColor = true;
            this.btnStatistiche.Click += new System.EventHandler(this.btnStatistiche_Click);
            // 
            // btnCerca
            // 
            this.btnCerca.Location = new System.Drawing.Point(239, 326);
            this.btnCerca.Name = "btnCerca";
            this.btnCerca.Size = new System.Drawing.Size(92, 43);
            this.btnCerca.TabIndex = 14;
            this.btnCerca.Text = "Cerca partite squadra";
            this.btnCerca.UseVisualStyleBackColor = true;
            this.btnCerca.Click += new System.EventHandler(this.btnCerca_Click);
            // 
            // btnSalva
            // 
            this.btnSalva.Location = new System.Drawing.Point(35, 228);
            this.btnSalva.Name = "btnSalva";
            this.btnSalva.Size = new System.Drawing.Size(92, 23);
            this.btnSalva.TabIndex = 15;
            this.btnSalva.Text = "Salva";
            this.btnSalva.UseVisualStyleBackColor = true;
            this.btnSalva.Click += new System.EventHandler(this.btnSalva_Click);
            // 
            // txtCerca
            // 
            this.txtCerca.Location = new System.Drawing.Point(96, 336);
            this.txtCerca.Name = "txtCerca";
            this.txtCerca.Size = new System.Drawing.Size(100, 22);
            this.txtCerca.TabIndex = 16;
            this.txtCerca.TextChanged += new System.EventHandler(this.txtCerca_TextChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(99, 317);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(97, 16);
            this.label5.TabIndex = 17;
            this.label5.Text = "Nome squadra";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtCerca);
            this.Controls.Add(this.btnSalva);
            this.Controls.Add(this.btnCerca);
            this.Controls.Add(this.btnStatistiche);
            this.Controls.Add(this.lstInterfaccia);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtGolOspite);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtSquadraOspite);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtGolCasa);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtSquadraCasa);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtSquadraCasa;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtGolCasa;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtSquadraOspite;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtGolOspite;
        private System.Windows.Forms.ListBox lstInterfaccia;
        private System.Windows.Forms.Button btnStatistiche;
        private System.Windows.Forms.Button btnCerca;
        private System.Windows.Forms.Button btnSalva;
        private System.Windows.Forms.TextBox txtCerca;
        private System.Windows.Forms.Label label5;
    }
}

