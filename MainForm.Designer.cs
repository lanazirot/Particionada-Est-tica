
namespace Particionada_Estática {
    partial class MainForm {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.components = new System.ComponentModel.Container();
            this.grbDatos = new System.Windows.Forms.GroupBox();
            this.lblSENA = new System.Windows.Forms.Label();
            this.btnReset = new System.Windows.Forms.Button();
            this.cboMemoriaSO = new System.Windows.Forms.ComboBox();
            this.cboMemoriaTotal = new System.Windows.Forms.ComboBox();
            this.btnEmpezarSimulacion = new System.Windows.Forms.Button();
            this.btnCapturarParticiones = new System.Windows.Forms.Button();
            this.txtParticiones = new System.Windows.Forms.TextBox();
            this.txtMemoriaOS = new System.Windows.Forms.TextBox();
            this.txtMemoriaTotal = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.dtgParticiones = new System.Windows.Forms.DataGridView();
            this.clmnParticion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmnTamano = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmnEstado = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmnDesperdicio = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmnTrabajoEnCurso = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.grbTrabajos = new System.Windows.Forms.GroupBox();
            this.cboTrabajo = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtIDTrabajo = new System.Windows.Forms.TextBox();
            this.btnCapturarTrabajos = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.txtValorTrabajo = new System.Windows.Forms.TextBox();
            this.dtgRelTrabajoParticion = new System.Windows.Forms.DataGridView();
            this.clmnTrabajo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmnEstatus = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.grbGrafica = new System.Windows.Forms.GroupBox();
            this.graficaMemoria = new ZedGraph.ZedGraphControl();
            this.grbLog = new System.Windows.Forms.GroupBox();
            this.listLog = new System.Windows.Forms.ListBox();
            this.lblCapturarOtraParticion = new System.Windows.Forms.Label();
            this.txtNuevaParticion = new System.Windows.Forms.TextBox();
            this.cboNuevaParticion = new System.Windows.Forms.ComboBox();
            this.BtnNuevaParticion = new System.Windows.Forms.Button();
            this.grbDatos.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgParticiones)).BeginInit();
            this.grbTrabajos.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgRelTrabajoParticion)).BeginInit();
            this.grbGrafica.SuspendLayout();
            this.grbLog.SuspendLayout();
            this.SuspendLayout();
            // 
            // grbDatos
            // 
            this.grbDatos.Controls.Add(this.BtnNuevaParticion);
            this.grbDatos.Controls.Add(this.cboNuevaParticion);
            this.grbDatos.Controls.Add(this.txtNuevaParticion);
            this.grbDatos.Controls.Add(this.lblCapturarOtraParticion);
            this.grbDatos.Controls.Add(this.lblSENA);
            this.grbDatos.Controls.Add(this.btnReset);
            this.grbDatos.Controls.Add(this.cboMemoriaSO);
            this.grbDatos.Controls.Add(this.cboMemoriaTotal);
            this.grbDatos.Controls.Add(this.btnEmpezarSimulacion);
            this.grbDatos.Controls.Add(this.btnCapturarParticiones);
            this.grbDatos.Controls.Add(this.txtParticiones);
            this.grbDatos.Controls.Add(this.txtMemoriaOS);
            this.grbDatos.Controls.Add(this.txtMemoriaTotal);
            this.grbDatos.Controls.Add(this.label3);
            this.grbDatos.Controls.Add(this.label2);
            this.grbDatos.Controls.Add(this.label1);
            this.grbDatos.Location = new System.Drawing.Point(12, 12);
            this.grbDatos.Name = "grbDatos";
            this.grbDatos.Size = new System.Drawing.Size(535, 209);
            this.grbDatos.TabIndex = 0;
            this.grbDatos.TabStop = false;
            this.grbDatos.Text = "Datos de entrada";
            // 
            // lblSENA
            // 
            this.lblSENA.AutoSize = true;
            this.lblSENA.Location = new System.Drawing.Point(198, 186);
            this.lblSENA.Name = "lblSENA";
            this.lblSENA.Size = new System.Drawing.Size(116, 15);
            this.lblSENA.TabIndex = 10;
            this.lblSENA.Text = "Memoria disponible:";
            // 
            // btnReset
            // 
            this.btnReset.Location = new System.Drawing.Point(15, 171);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(75, 23);
            this.btnReset.TabIndex = 10;
            this.btnReset.Text = "Reset";
            this.btnReset.UseVisualStyleBackColor = true;
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // cboMemoriaSO
            // 
            this.cboMemoriaSO.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboMemoriaSO.FormattingEnabled = true;
            this.cboMemoriaSO.Items.AddRange(new object[] {
            "KB",
            "MB",
            "GB"});
            this.cboMemoriaSO.Location = new System.Drawing.Point(283, 63);
            this.cboMemoriaSO.Name = "cboMemoriaSO";
            this.cboMemoriaSO.Size = new System.Drawing.Size(71, 23);
            this.cboMemoriaSO.TabIndex = 9;
            // 
            // cboMemoriaTotal
            // 
            this.cboMemoriaTotal.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboMemoriaTotal.FormattingEnabled = true;
            this.cboMemoriaTotal.Items.AddRange(new object[] {
            "KB",
            "MB",
            "GB"});
            this.cboMemoriaTotal.Location = new System.Drawing.Point(283, 28);
            this.cboMemoriaTotal.Name = "cboMemoriaTotal";
            this.cboMemoriaTotal.Size = new System.Drawing.Size(71, 23);
            this.cboMemoriaTotal.TabIndex = 8;
            // 
            // btnEmpezarSimulacion
            // 
            this.btnEmpezarSimulacion.Location = new System.Drawing.Point(360, 28);
            this.btnEmpezarSimulacion.Name = "btnEmpezarSimulacion";
            this.btnEmpezarSimulacion.Size = new System.Drawing.Size(169, 58);
            this.btnEmpezarSimulacion.TabIndex = 5;
            this.btnEmpezarSimulacion.Text = "Establecer memoria";
            this.btnEmpezarSimulacion.UseVisualStyleBackColor = true;
            this.btnEmpezarSimulacion.Click += new System.EventHandler(this.btnEmpezarSimulacion_Click);
            // 
            // btnCapturarParticiones
            // 
            this.btnCapturarParticiones.Location = new System.Drawing.Point(360, 92);
            this.btnCapturarParticiones.Name = "btnCapturarParticiones";
            this.btnCapturarParticiones.Size = new System.Drawing.Size(169, 29);
            this.btnCapturarParticiones.TabIndex = 6;
            this.btnCapturarParticiones.Text = "Capturar particiones";
            this.btnCapturarParticiones.UseVisualStyleBackColor = true;
            this.btnCapturarParticiones.Click += new System.EventHandler(this.btnComenzarSimulacion_Click);
            // 
            // txtParticiones
            // 
            this.txtParticiones.Location = new System.Drawing.Point(198, 98);
            this.txtParticiones.Name = "txtParticiones";
            this.txtParticiones.Size = new System.Drawing.Size(156, 23);
            this.txtParticiones.TabIndex = 5;
            // 
            // txtMemoriaOS
            // 
            this.txtMemoriaOS.Location = new System.Drawing.Point(198, 63);
            this.txtMemoriaOS.Name = "txtMemoriaOS";
            this.txtMemoriaOS.Size = new System.Drawing.Size(79, 23);
            this.txtMemoriaOS.TabIndex = 4;
            // 
            // txtMemoriaTotal
            // 
            this.txtMemoriaTotal.Location = new System.Drawing.Point(198, 28);
            this.txtMemoriaTotal.Name = "txtMemoriaTotal";
            this.txtMemoriaTotal.Size = new System.Drawing.Size(79, 23);
            this.txtMemoriaTotal.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(15, 101);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(128, 15);
            this.label3.TabIndex = 2;
            this.label3.Text = "Número de particiones";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(15, 66);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(164, 15);
            this.label2.TabIndex = 1;
            this.label2.Text = "Tamaño del sistema operativo";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(15, 31);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(128, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "Tamaño de la memoria";
            // 
            // dtgParticiones
            // 
            this.dtgParticiones.AllowUserToAddRows = false;
            this.dtgParticiones.AllowUserToDeleteRows = false;
            this.dtgParticiones.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dtgParticiones.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgParticiones.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.clmnParticion,
            this.clmnTamano,
            this.clmnEstado,
            this.clmnDesperdicio,
            this.clmnTrabajoEnCurso});
            this.dtgParticiones.Location = new System.Drawing.Point(12, 236);
            this.dtgParticiones.MultiSelect = false;
            this.dtgParticiones.Name = "dtgParticiones";
            this.dtgParticiones.ReadOnly = true;
            this.dtgParticiones.RowTemplate.Height = 25;
            this.dtgParticiones.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgParticiones.Size = new System.Drawing.Size(783, 226);
            this.dtgParticiones.TabIndex = 1;
            // 
            // clmnParticion
            // 
            this.clmnParticion.HeaderText = "Particion";
            this.clmnParticion.Name = "clmnParticion";
            this.clmnParticion.ReadOnly = true;
            // 
            // clmnTamano
            // 
            this.clmnTamano.HeaderText = "Tamaño";
            this.clmnTamano.Name = "clmnTamano";
            this.clmnTamano.ReadOnly = true;
            // 
            // clmnEstado
            // 
            this.clmnEstado.HeaderText = "Estado";
            this.clmnEstado.Name = "clmnEstado";
            this.clmnEstado.ReadOnly = true;
            // 
            // clmnDesperdicio
            // 
            this.clmnDesperdicio.HeaderText = "Desperdicio";
            this.clmnDesperdicio.Name = "clmnDesperdicio";
            this.clmnDesperdicio.ReadOnly = true;
            // 
            // clmnTrabajoEnCurso
            // 
            this.clmnTrabajoEnCurso.HeaderText = "Trabajo en curso";
            this.clmnTrabajoEnCurso.Name = "clmnTrabajoEnCurso";
            this.clmnTrabajoEnCurso.ReadOnly = true;
            // 
            // grbTrabajos
            // 
            this.grbTrabajos.Controls.Add(this.cboTrabajo);
            this.grbTrabajos.Controls.Add(this.label5);
            this.grbTrabajos.Controls.Add(this.txtIDTrabajo);
            this.grbTrabajos.Controls.Add(this.btnCapturarTrabajos);
            this.grbTrabajos.Controls.Add(this.label4);
            this.grbTrabajos.Controls.Add(this.txtValorTrabajo);
            this.grbTrabajos.Location = new System.Drawing.Point(553, 12);
            this.grbTrabajos.Name = "grbTrabajos";
            this.grbTrabajos.Size = new System.Drawing.Size(242, 209);
            this.grbTrabajos.TabIndex = 2;
            this.grbTrabajos.TabStop = false;
            this.grbTrabajos.Text = "Trabajos";
            // 
            // cboTrabajo
            // 
            this.cboTrabajo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboTrabajo.FormattingEnabled = true;
            this.cboTrabajo.Items.AddRange(new object[] {
            "KB",
            "MB",
            "GB"});
            this.cboTrabajo.Location = new System.Drawing.Point(85, 149);
            this.cboTrabajo.Name = "cboTrabajo";
            this.cboTrabajo.Size = new System.Drawing.Size(71, 23);
            this.cboTrabajo.TabIndex = 9;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(53, 44);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(59, 15);
            this.label5.TabIndex = 5;
            this.label5.Text = "ID Trabajo";
            // 
            // txtIDTrabajo
            // 
            this.txtIDTrabajo.Location = new System.Drawing.Point(53, 66);
            this.txtIDTrabajo.Name = "txtIDTrabajo";
            this.txtIDTrabajo.Size = new System.Drawing.Size(140, 23);
            this.txtIDTrabajo.TabIndex = 4;
            // 
            // btnCapturarTrabajos
            // 
            this.btnCapturarTrabajos.Location = new System.Drawing.Point(53, 178);
            this.btnCapturarTrabajos.Name = "btnCapturarTrabajos";
            this.btnCapturarTrabajos.Size = new System.Drawing.Size(140, 23);
            this.btnCapturarTrabajos.TabIndex = 2;
            this.btnCapturarTrabajos.Text = "Capturar trabajo";
            this.btnCapturarTrabajos.UseVisualStyleBackColor = true;
            this.btnCapturarTrabajos.Click += new System.EventHandler(this.btnCapturarTrabajos_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(53, 102);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(73, 15);
            this.label4.TabIndex = 1;
            this.label4.Text = "Valor trabajo";
            // 
            // txtValorTrabajo
            // 
            this.txtValorTrabajo.Location = new System.Drawing.Point(53, 120);
            this.txtValorTrabajo.Name = "txtValorTrabajo";
            this.txtValorTrabajo.Size = new System.Drawing.Size(140, 23);
            this.txtValorTrabajo.TabIndex = 0;
            // 
            // dtgRelTrabajoParticion
            // 
            this.dtgRelTrabajoParticion.AllowUserToAddRows = false;
            this.dtgRelTrabajoParticion.AllowUserToDeleteRows = false;
            this.dtgRelTrabajoParticion.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dtgRelTrabajoParticion.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgRelTrabajoParticion.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.clmnTrabajo,
            this.dataGridViewTextBoxColumn2,
            this.dataGridViewTextBoxColumn3,
            this.clmnEstatus});
            this.dtgRelTrabajoParticion.Location = new System.Drawing.Point(12, 468);
            this.dtgRelTrabajoParticion.MultiSelect = false;
            this.dtgRelTrabajoParticion.Name = "dtgRelTrabajoParticion";
            this.dtgRelTrabajoParticion.ReadOnly = true;
            this.dtgRelTrabajoParticion.RowTemplate.Height = 25;
            this.dtgRelTrabajoParticion.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgRelTrabajoParticion.Size = new System.Drawing.Size(783, 232);
            this.dtgRelTrabajoParticion.TabIndex = 3;
            // 
            // clmnTrabajo
            // 
            this.clmnTrabajo.HeaderText = "Trabajo";
            this.clmnTrabajo.Name = "clmnTrabajo";
            this.clmnTrabajo.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.HeaderText = "Tamaño";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.HeaderText = "Partición";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.ReadOnly = true;
            // 
            // clmnEstatus
            // 
            this.clmnEstatus.HeaderText = "Estatus";
            this.clmnEstatus.Name = "clmnEstatus";
            this.clmnEstatus.ReadOnly = true;
            // 
            // grbGrafica
            // 
            this.grbGrafica.Controls.Add(this.graficaMemoria);
            this.grbGrafica.Location = new System.Drawing.Point(814, 22);
            this.grbGrafica.Name = "grbGrafica";
            this.grbGrafica.Size = new System.Drawing.Size(419, 678);
            this.grbGrafica.TabIndex = 8;
            this.grbGrafica.TabStop = false;
            this.grbGrafica.Text = "Grafica";
            // 
            // graficaMemoria
            // 
            this.graficaMemoria.Location = new System.Drawing.Point(16, 27);
            this.graficaMemoria.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.graficaMemoria.Name = "graficaMemoria";
            this.graficaMemoria.ScrollGrace = 0D;
            this.graficaMemoria.ScrollMaxX = 0D;
            this.graficaMemoria.ScrollMaxY = 0D;
            this.graficaMemoria.ScrollMaxY2 = 0D;
            this.graficaMemoria.ScrollMinX = 0D;
            this.graficaMemoria.ScrollMinY = 0D;
            this.graficaMemoria.ScrollMinY2 = 0D;
            this.graficaMemoria.Size = new System.Drawing.Size(362, 636);
            this.graficaMemoria.TabIndex = 0;
            this.graficaMemoria.UseExtendedPrintDialog = true;
            this.graficaMemoria.PointValueEvent += new ZedGraph.ZedGraphControl.PointValueHandler(this.graficaMemoria_PointValueEvent);
            // 
            // grbLog
            // 
            this.grbLog.Controls.Add(this.listLog);
            this.grbLog.Location = new System.Drawing.Point(12, 706);
            this.grbLog.Name = "grbLog";
            this.grbLog.Size = new System.Drawing.Size(1221, 142);
            this.grbLog.TabIndex = 9;
            this.grbLog.TabStop = false;
            this.grbLog.Text = "Log";
            // 
            // listLog
            // 
            this.listLog.FormattingEnabled = true;
            this.listLog.ItemHeight = 15;
            this.listLog.Location = new System.Drawing.Point(6, 31);
            this.listLog.Name = "listLog";
            this.listLog.Size = new System.Drawing.Size(1209, 94);
            this.listLog.TabIndex = 0;
            // 
            // lblCapturarOtraParticion
            // 
            this.lblCapturarOtraParticion.AutoSize = true;
            this.lblCapturarOtraParticion.Location = new System.Drawing.Point(63, 128);
            this.lblCapturarOtraParticion.Name = "lblCapturarOtraParticion";
            this.lblCapturarOtraParticion.Size = new System.Drawing.Size(80, 15);
            this.lblCapturarOtraParticion.TabIndex = 11;
            this.lblCapturarOtraParticion.Text = "Otra particion";
            // 
            // txtNuevaParticion
            // 
            this.txtNuevaParticion.Location = new System.Drawing.Point(198, 128);
            this.txtNuevaParticion.Name = "txtNuevaParticion";
            this.txtNuevaParticion.Size = new System.Drawing.Size(100, 23);
            this.txtNuevaParticion.TabIndex = 12;
            // 
            // cboNuevaParticion
            // 
            this.cboNuevaParticion.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboNuevaParticion.FormattingEnabled = true;
            this.cboNuevaParticion.Items.AddRange(new object[] {
            "KB",
            "MB",
            "GB"});
            this.cboNuevaParticion.Location = new System.Drawing.Point(304, 128);
            this.cboNuevaParticion.Name = "cboNuevaParticion";
            this.cboNuevaParticion.Size = new System.Drawing.Size(50, 23);
            this.cboNuevaParticion.TabIndex = 13;
            // 
            // BtnNuevaParticion
            // 
            this.BtnNuevaParticion.Location = new System.Drawing.Point(198, 157);
            this.BtnNuevaParticion.Name = "BtnNuevaParticion";
            this.BtnNuevaParticion.Size = new System.Drawing.Size(156, 23);
            this.BtnNuevaParticion.TabIndex = 14;
            this.BtnNuevaParticion.Text = "Capturar particion";
            this.BtnNuevaParticion.UseVisualStyleBackColor = true;
            this.BtnNuevaParticion.Click += new System.EventHandler(this.BtnNuevaParticion_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1245, 860);
            this.Controls.Add(this.grbLog);
            this.Controls.Add(this.grbGrafica);
            this.Controls.Add(this.dtgRelTrabajoParticion);
            this.Controls.Add(this.grbTrabajos);
            this.Controls.Add(this.dtgParticiones);
            this.Controls.Add(this.grbDatos);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Simulación de memoria particionada estática X Alan Peña Ortiz";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.grbDatos.ResumeLayout(false);
            this.grbDatos.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgParticiones)).EndInit();
            this.grbTrabajos.ResumeLayout(false);
            this.grbTrabajos.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgRelTrabajoParticion)).EndInit();
            this.grbGrafica.ResumeLayout(false);
            this.grbLog.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox grbDatos;
        private System.Windows.Forms.Button btnCapturarParticiones;
        private System.Windows.Forms.TextBox txtParticiones;
        private System.Windows.Forms.TextBox txtMemoriaOS;
        private System.Windows.Forms.TextBox txtMemoriaTotal;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dtgParticiones;
        private System.Windows.Forms.GroupBox grbTrabajos;
        private System.Windows.Forms.Button btnCapturarTrabajos;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtValorTrabajo;
        private System.Windows.Forms.DataGridView dtgRelTrabajoParticion;
        private System.Windows.Forms.Button btnEmpezarSimulacion;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtIDTrabajo;
        private System.Windows.Forms.ComboBox cboMemoriaSO;
        private System.Windows.Forms.ComboBox cboMemoriaTotal;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmnTrabajo;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmnEstatus;
        private System.Windows.Forms.GroupBox grbGrafica;
        private ZedGraph.ZedGraphControl graficaMemoria;
        private System.Windows.Forms.Button btnReset;
        private System.Windows.Forms.GroupBox grbLog;
        private System.Windows.Forms.ListBox listLog;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmnParticion;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmnTamano;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmnEstado;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmnDesperdicio;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmnTrabajoEnCurso;
        private System.Windows.Forms.ComboBox cboTrabajo;
        private System.Windows.Forms.Label lblSENA;
        private System.Windows.Forms.Button BtnNuevaParticion;
        private System.Windows.Forms.ComboBox cboNuevaParticion;
        private System.Windows.Forms.TextBox txtNuevaParticion;
        private System.Windows.Forms.Label lblCapturarOtraParticion;
    }
}

