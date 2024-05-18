namespace AppCodigosPostalesCSharp
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
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.cboEstado = new System.Windows.Forms.ComboBox();
            this.ComboBoxFiltrar = new System.Windows.Forms.ComboBox();
            this.cboMunicipio = new System.Windows.Forms.ComboBox();
            this.TextBoxBuscar = new System.Windows.Forms.TextBox();
            this.ButtonBuscar = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(12, 146);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowTemplate.Height = 25;
            this.dataGridView1.Size = new System.Drawing.Size(1007, 292);
            this.dataGridView1.TabIndex = 0;
            // 
            // cboEstado
            // 
            this.cboEstado.FormattingEnabled = true;
            this.cboEstado.Location = new System.Drawing.Point(33, 26);
            this.cboEstado.Name = "cboEstado";
            this.cboEstado.Size = new System.Drawing.Size(182, 23);
            this.cboEstado.TabIndex = 1;
            this.cboEstado.SelectedIndexChanged += new System.EventHandler(this.cboEstado_SelectedIndexChanged_1);
            // 
            // ComboBoxFiltrar
            // 
            this.ComboBoxFiltrar.FormattingEnabled = true;
            this.ComboBoxFiltrar.Location = new System.Drawing.Point(409, 117);
            this.ComboBoxFiltrar.Name = "ComboBoxFiltrar";
            this.ComboBoxFiltrar.Size = new System.Drawing.Size(121, 23);
            this.ComboBoxFiltrar.TabIndex = 2;
            this.ComboBoxFiltrar.SelectedIndexChanged += new System.EventHandler(this.ComboBoxFiltrar_SelectedIndexChanged);
            // 
            // cboMunicipio
            // 
            this.cboMunicipio.FormattingEnabled = true;
            this.cboMunicipio.Location = new System.Drawing.Point(221, 26);
            this.cboMunicipio.Name = "cboMunicipio";
            this.cboMunicipio.Size = new System.Drawing.Size(182, 23);
            this.cboMunicipio.TabIndex = 3;
            this.cboMunicipio.SelectedIndexChanged += new System.EventHandler(this.cboMunicipio_SelectedIndexChanged);
            // 
            // TextBoxBuscar
            // 
            this.TextBoxBuscar.Location = new System.Drawing.Point(115, 117);
            this.TextBoxBuscar.Name = "TextBoxBuscar";
            this.TextBoxBuscar.Size = new System.Drawing.Size(288, 23);
            this.TextBoxBuscar.TabIndex = 4;
            // 
            // ButtonBuscar
            // 
            this.ButtonBuscar.Location = new System.Drawing.Point(536, 117);
            this.ButtonBuscar.Name = "ButtonBuscar";
            this.ButtonBuscar.Size = new System.Drawing.Size(75, 23);
            this.ButtonBuscar.TabIndex = 5;
            this.ButtonBuscar.Text = "button1";
            this.ButtonBuscar.UseVisualStyleBackColor = true;
            this.ButtonBuscar.Click += new System.EventHandler(this.ButtonBuscar_Click);
            // 
            // Form1
            // 
            this.AcceptButton = this.ButtonBuscar;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1031, 450);
            this.Controls.Add(this.ButtonBuscar);
            this.Controls.Add(this.TextBoxBuscar);
            this.Controls.Add(this.cboMunicipio);
            this.Controls.Add(this.ComboBoxFiltrar);
            this.Controls.Add(this.cboEstado);
            this.Controls.Add(this.dataGridView1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DataGridView dataGridView1;
        private ComboBox cboEstado;
        private ComboBox ComboBoxFiltrar;
        private ComboBox cboMunicipio;
        private TextBox TextBoxBuscar;
        private Button ButtonBuscar;
        internal Label Label1;
        internal Button ButtonBuscar1;
        internal ComboBox ComboBoxFiltrar1;
        internal TextBox TextBoxBuscar1;
        internal ComboBox cboMunicipio1;
        internal ComboBox cboEstado1;
        internal DataGridView dataGridView2;
    }
}