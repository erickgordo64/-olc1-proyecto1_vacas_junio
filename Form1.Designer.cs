namespace _olc1_proyecto1
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.archivoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.nueboToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.abrirToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.guardarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.guardarComoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.herramientasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ejecutarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cargarTablasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.imprmirTokenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.imprimirErrorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.verTablasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.verArbolToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ayudaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.archivoToolStripMenuItem,
            this.herramientasToolStripMenuItem,
            this.ayudaToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(800, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // archivoToolStripMenuItem
            // 
            this.archivoToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.nueboToolStripMenuItem,
            this.abrirToolStripMenuItem,
            this.guardarToolStripMenuItem,
            this.guardarComoToolStripMenuItem,
            this.toolStripMenuItem1});
            this.archivoToolStripMenuItem.Name = "archivoToolStripMenuItem";
            this.archivoToolStripMenuItem.Size = new System.Drawing.Size(60, 20);
            this.archivoToolStripMenuItem.Text = "Archivo";
            // 
            // nueboToolStripMenuItem
            // 
            this.nueboToolStripMenuItem.Name = "nueboToolStripMenuItem";
            this.nueboToolStripMenuItem.Size = new System.Drawing.Size(150, 22);
            this.nueboToolStripMenuItem.Text = "Nuevo";
            this.nueboToolStripMenuItem.Click += new System.EventHandler(this.nueboToolStripMenuItem_Click);
            // 
            // abrirToolStripMenuItem
            // 
            this.abrirToolStripMenuItem.Name = "abrirToolStripMenuItem";
            this.abrirToolStripMenuItem.Size = new System.Drawing.Size(150, 22);
            this.abrirToolStripMenuItem.Text = "Abrir";
            this.abrirToolStripMenuItem.Click += new System.EventHandler(this.abrirToolStripMenuItem_Click);
            // 
            // guardarToolStripMenuItem
            // 
            this.guardarToolStripMenuItem.Name = "guardarToolStripMenuItem";
            this.guardarToolStripMenuItem.Size = new System.Drawing.Size(150, 22);
            this.guardarToolStripMenuItem.Text = "Guardar";
            // 
            // guardarComoToolStripMenuItem
            // 
            this.guardarComoToolStripMenuItem.Name = "guardarComoToolStripMenuItem";
            this.guardarComoToolStripMenuItem.Size = new System.Drawing.Size(150, 22);
            this.guardarComoToolStripMenuItem.Text = "Guardar como";
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(150, 22);
            this.toolStripMenuItem1.Text = "Salir";
            // 
            // herramientasToolStripMenuItem
            // 
            this.herramientasToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ejecutarToolStripMenuItem,
            this.cargarTablasToolStripMenuItem,
            this.imprmirTokenToolStripMenuItem,
            this.imprimirErrorToolStripMenuItem,
            this.verTablasToolStripMenuItem,
            this.verArbolToolStripMenuItem});
            this.herramientasToolStripMenuItem.Name = "herramientasToolStripMenuItem";
            this.herramientasToolStripMenuItem.Size = new System.Drawing.Size(90, 20);
            this.herramientasToolStripMenuItem.Text = "Herramientas";
            // 
            // ejecutarToolStripMenuItem
            // 
            this.ejecutarToolStripMenuItem.Name = "ejecutarToolStripMenuItem";
            this.ejecutarToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.ejecutarToolStripMenuItem.Text = "Ejecutar";
            this.ejecutarToolStripMenuItem.Click += new System.EventHandler(this.ejecutarToolStripMenuItem_Click);
            // 
            // cargarTablasToolStripMenuItem
            // 
            this.cargarTablasToolStripMenuItem.Name = "cargarTablasToolStripMenuItem";
            this.cargarTablasToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.cargarTablasToolStripMenuItem.Text = "Cargar tablas";
            this.cargarTablasToolStripMenuItem.Click += new System.EventHandler(this.cargarTablasToolStripMenuItem_Click);
            // 
            // imprmirTokenToolStripMenuItem
            // 
            this.imprmirTokenToolStripMenuItem.Name = "imprmirTokenToolStripMenuItem";
            this.imprmirTokenToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.imprmirTokenToolStripMenuItem.Text = "Imprmir token";
            this.imprmirTokenToolStripMenuItem.Click += new System.EventHandler(this.imprmirTokenToolStripMenuItem_Click);
            // 
            // imprimirErrorToolStripMenuItem
            // 
            this.imprimirErrorToolStripMenuItem.Name = "imprimirErrorToolStripMenuItem";
            this.imprimirErrorToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.imprimirErrorToolStripMenuItem.Text = "imprimir error";
            this.imprimirErrorToolStripMenuItem.Click += new System.EventHandler(this.imprimirErrorToolStripMenuItem_Click);
            // 
            // verTablasToolStripMenuItem
            // 
            this.verTablasToolStripMenuItem.Name = "verTablasToolStripMenuItem";
            this.verTablasToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.verTablasToolStripMenuItem.Text = "ver tablas";
            this.verTablasToolStripMenuItem.Click += new System.EventHandler(this.verTablasToolStripMenuItem_Click);
            // 
            // verArbolToolStripMenuItem
            // 
            this.verArbolToolStripMenuItem.Name = "verArbolToolStripMenuItem";
            this.verArbolToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.verArbolToolStripMenuItem.Text = "ver arbol";
            this.verArbolToolStripMenuItem.Click += new System.EventHandler(this.verArbolToolStripMenuItem_Click);
            // 
            // ayudaToolStripMenuItem
            // 
            this.ayudaToolStripMenuItem.Name = "ayudaToolStripMenuItem";
            this.ayudaToolStripMenuItem.Size = new System.Drawing.Size(51, 20);
            this.ayudaToolStripMenuItem.Text = "ayuda";
            // 
            // tabControl1
            // 
            this.tabControl1.Location = new System.Drawing.Point(12, 27);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(547, 398);
            this.tabControl1.TabIndex = 1;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 454);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "SQL";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem archivoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem nueboToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem abrirToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem guardarToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem guardarComoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem herramientasToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ejecutarToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ayudaToolStripMenuItem;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.ToolStripMenuItem cargarTablasToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem imprmirTokenToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem imprimirErrorToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem verTablasToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem verArbolToolStripMenuItem;
    }
}

