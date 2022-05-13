
namespace Ejercicio_Guía_9
{
    partial class Simulador
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
            this.components = new System.ComponentModel.Container();
            this.Pizarra = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.CMSVertice = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.nombreVerticeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.eliminarVérticeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnEliminarVertice = new System.Windows.Forms.Button();
            this.CBArco = new System.Windows.Forms.ComboBox();
            this.CBVertice = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnAnchura = new System.Windows.Forms.Button();
            this.btnProfundidad = new System.Windows.Forms.Button();
            this.CBNodoPartida = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.txtBuscar = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.button5 = new System.Windows.Forms.Button();
            this.añadirVerticeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.btnDijktra = new System.Windows.Forms.Button();
            this.lstboxDatos = new System.Windows.Forms.ListBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.CMSVertice.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.contextMenuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // Pizarra
            // 
            this.Pizarra.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.Pizarra.Location = new System.Drawing.Point(329, 66);
            this.Pizarra.Name = "Pizarra";
            this.Pizarra.Size = new System.Drawing.Size(458, 457);
            this.Pizarra.TabIndex = 0;
            this.Pizarra.Paint += new System.Windows.Forms.PaintEventHandler(this.Pizarra_Paint);
            this.Pizarra.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Pizarra_MouseDown);
            this.Pizarra.MouseLeave += new System.EventHandler(this.Pizarra_MouseLeave);
            this.Pizarra.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Pizarra_MouseMove);
            this.Pizarra.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Pizarra_MouseUp);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe Print", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(453, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(234, 37);
            this.label1.TabIndex = 1;
            this.label1.Text = "Simulador de Gráfos";
            // 
            // CMSVertice
            // 
            this.CMSVertice.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.nombreVerticeToolStripMenuItem,
            this.eliminarVérticeToolStripMenuItem});
            this.CMSVertice.Name = "CMSCrearVertice";
            this.CMSVertice.Size = new System.Drawing.Size(157, 48);
            this.CMSVertice.Opening += new System.ComponentModel.CancelEventHandler(this.CMSVertice_Opening);
            // 
            // nombreVerticeToolStripMenuItem
            // 
            this.nombreVerticeToolStripMenuItem.Name = "nombreVerticeToolStripMenuItem";
            this.nombreVerticeToolStripMenuItem.Size = new System.Drawing.Size(156, 22);
            this.nombreVerticeToolStripMenuItem.Text = "Nombre Vértice";
            this.nombreVerticeToolStripMenuItem.Click += new System.EventHandler(this.nuevoVérticeToolStripMenuItem_Click);
            // 
            // eliminarVérticeToolStripMenuItem
            // 
            this.eliminarVérticeToolStripMenuItem.Name = "eliminarVérticeToolStripMenuItem";
            this.eliminarVérticeToolStripMenuItem.Size = new System.Drawing.Size(156, 22);
            this.eliminarVérticeToolStripMenuItem.Text = "Eliminar Vértice";
            this.eliminarVérticeToolStripMenuItem.Click += new System.EventHandler(this.eliminarVérticeToolStripMenuItem_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnEliminarVertice);
            this.groupBox1.Controls.Add(this.CBArco);
            this.groupBox1.Controls.Add(this.CBVertice);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Font = new System.Drawing.Font("Segoe Print", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(21, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(270, 164);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Eliminar";
            this.groupBox1.Enter += new System.EventHandler(this.groupBox1_Enter);
            // 
            // btnEliminarVertice
            // 
            this.btnEliminarVertice.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(17)))), ((int)(((byte)(84)))));
            this.btnEliminarVertice.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEliminarVertice.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnEliminarVertice.Location = new System.Drawing.Point(102, 118);
            this.btnEliminarVertice.Name = "btnEliminarVertice";
            this.btnEliminarVertice.Size = new System.Drawing.Size(80, 34);
            this.btnEliminarVertice.TabIndex = 4;
            this.btnEliminarVertice.Text = "Eliminar";
            this.btnEliminarVertice.UseVisualStyleBackColor = false;
            this.btnEliminarVertice.Click += new System.EventHandler(this.button1_Click);
            // 
            // CBArco
            // 
            this.CBArco.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CBArco.FormattingEnabled = true;
            this.CBArco.Location = new System.Drawing.Point(78, 79);
            this.CBArco.Name = "CBArco";
            this.CBArco.Size = new System.Drawing.Size(126, 31);
            this.CBArco.TabIndex = 3;
            // 
            // CBVertice
            // 
            this.CBVertice.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CBVertice.FormattingEnabled = true;
            this.CBVertice.Location = new System.Drawing.Point(103, 35);
            this.CBVertice.Name = "CBVertice";
            this.CBVertice.Size = new System.Drawing.Size(79, 31);
            this.CBVertice.TabIndex = 2;
            this.CBVertice.SelectedIndexChanged += new System.EventHandler(this.CBVertice_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe Print", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(27, 82);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 23);
            this.label3.TabIndex = 1;
            this.label3.Text = "Arco";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe Print", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(40, 38);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(57, 23);
            this.label2.TabIndex = 0;
            this.label2.Text = "Vertice";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.lstboxDatos);
            this.groupBox2.Controls.Add(this.btnAnchura);
            this.groupBox2.Controls.Add(this.btnProfundidad);
            this.groupBox2.Controls.Add(this.CBNodoPartida);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Font = new System.Drawing.Font("Segoe Print", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(21, 193);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(270, 260);
            this.groupBox2.TabIndex = 4;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Recorridos";
            // 
            // btnAnchura
            // 
            this.btnAnchura.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(17)))), ((int)(((byte)(84)))));
            this.btnAnchura.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAnchura.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnAnchura.Location = new System.Drawing.Point(131, 81);
            this.btnAnchura.Name = "btnAnchura";
            this.btnAnchura.Size = new System.Drawing.Size(117, 34);
            this.btnAnchura.TabIndex = 5;
            this.btnAnchura.Text = "Anchura";
            this.btnAnchura.UseVisualStyleBackColor = false;
            this.btnAnchura.Click += new System.EventHandler(this.button3_Click);
            // 
            // btnProfundidad
            // 
            this.btnProfundidad.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(17)))), ((int)(((byte)(84)))));
            this.btnProfundidad.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnProfundidad.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnProfundidad.Location = new System.Drawing.Point(6, 81);
            this.btnProfundidad.Name = "btnProfundidad";
            this.btnProfundidad.Size = new System.Drawing.Size(117, 34);
            this.btnProfundidad.TabIndex = 4;
            this.btnProfundidad.Text = "Profundidad";
            this.btnProfundidad.UseVisualStyleBackColor = false;
            this.btnProfundidad.Click += new System.EventHandler(this.button2_Click);
            // 
            // CBNodoPartida
            // 
            this.CBNodoPartida.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CBNodoPartida.FormattingEnabled = true;
            this.CBNodoPartida.Location = new System.Drawing.Point(157, 34);
            this.CBNodoPartida.Name = "CBNodoPartida";
            this.CBNodoPartida.Size = new System.Drawing.Size(79, 31);
            this.CBNodoPartida.TabIndex = 2;
            this.CBNodoPartida.SelectedIndexChanged += new System.EventHandler(this.CBNodoPartida_SelectedIndexChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe Print", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(17, 37);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(121, 23);
            this.label5.TabIndex = 0;
            this.label5.Text = "Nodo de Partida";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.btnBuscar);
            this.groupBox3.Controls.Add(this.txtBuscar);
            this.groupBox3.Controls.Add(this.label4);
            this.groupBox3.Font = new System.Drawing.Font("Segoe Print", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox3.Location = new System.Drawing.Point(52, 459);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(205, 111);
            this.groupBox3.TabIndex = 5;
            this.groupBox3.TabStop = false;
            // 
            // btnBuscar
            // 
            this.btnBuscar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(17)))), ((int)(((byte)(84)))));
            this.btnBuscar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBuscar.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnBuscar.Location = new System.Drawing.Point(47, 59);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(91, 33);
            this.btnBuscar.TabIndex = 5;
            this.btnBuscar.Text = "Buscar";
            this.btnBuscar.UseVisualStyleBackColor = false;
            this.btnBuscar.Click += new System.EventHandler(this.button4_Click);
            // 
            // txtBuscar
            // 
            this.txtBuscar.Location = new System.Drawing.Point(89, 23);
            this.txtBuscar.Name = "txtBuscar";
            this.txtBuscar.Size = new System.Drawing.Size(100, 30);
            this.txtBuscar.TabIndex = 1;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe Print", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(17, 26);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(57, 23);
            this.label4.TabIndex = 0;
            this.label4.Text = "Vertice";
            // 
            // button5
            // 
            this.button5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(17)))), ((int)(((byte)(84)))));
            this.button5.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button5.Font = new System.Drawing.Font("Segoe Print", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button5.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.button5.Location = new System.Drawing.Point(87, 576);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(116, 41);
            this.button5.TabIndex = 6;
            this.button5.Text = "Distancia";
            this.button5.UseVisualStyleBackColor = false;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // añadirVerticeToolStripMenuItem
            // 
            this.añadirVerticeToolStripMenuItem.Name = "añadirVerticeToolStripMenuItem";
            this.añadirVerticeToolStripMenuItem.Size = new System.Drawing.Size(147, 22);
            this.añadirVerticeToolStripMenuItem.Text = "Añadir Vertice";
            this.añadirVerticeToolStripMenuItem.Click += new System.EventHandler(this.añadirVerticeToolStripMenuItem_Click);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.añadirVerticeToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(148, 26);
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // btnDijktra
            // 
            this.btnDijktra.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(17)))), ((int)(((byte)(84)))));
            this.btnDijktra.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDijktra.Font = new System.Drawing.Font("Segoe Print", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDijktra.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnDijktra.Location = new System.Drawing.Point(354, 16);
            this.btnDijktra.Name = "btnDijktra";
            this.btnDijktra.Size = new System.Drawing.Size(80, 34);
            this.btnDijktra.TabIndex = 7;
            this.btnDijktra.Text = "Dijkstra";
            this.btnDijktra.UseVisualStyleBackColor = false;
            this.btnDijktra.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // lstboxDatos
            // 
            this.lstboxDatos.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.lstboxDatos.FormattingEnabled = true;
            this.lstboxDatos.ItemHeight = 23;
            this.lstboxDatos.Location = new System.Drawing.Point(18, 121);
            this.lstboxDatos.Name = "lstboxDatos";
            this.lstboxDatos.Size = new System.Drawing.Size(230, 115);
            this.lstboxDatos.TabIndex = 6;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Segoe Print", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(430, 547);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(257, 23);
            this.label6.TabIndex = 8;
            this.label6.Text = "Click derecho para añadir un vértice";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Segoe Print", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(360, 576);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(379, 46);
            this.label7.TabIndex = 9;
            this.label7.Text = "Para añadir un arco presione sobre un nodo en donde \r\n         iniciara y arrastr" +
    "elo al nodo destino";
            // 
            // Simulador
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(819, 641);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.btnDijktra);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Pizarra);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "Simulador";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Funcionalidad Gráfica de los Grafos";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.CMSVertice.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.contextMenuStrip1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel Pizarra;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ContextMenuStrip CMSVertice;
        private System.Windows.Forms.ToolStripMenuItem nombreVerticeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem eliminarVérticeToolStripMenuItem;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox CBArco;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnEliminarVertice;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnAnchura;
        private System.Windows.Forms.Button btnProfundidad;
        private System.Windows.Forms.ComboBox CBNodoPartida;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button btnBuscar;
        private System.Windows.Forms.TextBox txtBuscar;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.ToolStripMenuItem añadirVerticeToolStripMenuItem;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.Button btnDijktra;
        public System.Windows.Forms.ComboBox CBVertice;
        private System.Windows.Forms.ListBox lstboxDatos;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
    }
}

