namespace Formularios
{
    partial class FrmConfiguracion
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmConfiguracion));
            this.lblAutoGuardado = new System.Windows.Forms.Label();
            this.BtnAutoGuardado = new System.Windows.Forms.Button();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.txtDirectorio = new System.Windows.Forms.TextBox();
            this.lblUbicacion = new System.Windows.Forms.Label();
            this.BtnSeleccionarDirectorio = new System.Windows.Forms.Button();
            this.lblHorariosDeAtencion = new System.Windows.Forms.Label();
            this.lblNombreCentroMedico = new System.Windows.Forms.Label();
            this.txtNombreCentro = new System.Windows.Forms.TextBox();
            this.BtnGuardarNombre = new System.Windows.Forms.Button();
            this.btnCambiarHorarios = new System.Windows.Forms.Button();
            this.btnAgregarEspecialidad = new System.Windows.Forms.Button();
            this.lblEspecialidades = new System.Windows.Forms.Label();
            this.cmbEspecialidades = new System.Windows.Forms.ComboBox();
            this.BtnEliminarEspecialidad = new System.Windows.Forms.Button();
            this.lblHorarioDelCentro = new System.Windows.Forms.Label();
            this.txtAgregarEspecialidad = new System.Windows.Forms.TextBox();
            this.lblAgregarEspecialidad = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblAutoGuardado
            // 
            this.lblAutoGuardado.AutoSize = true;
            this.lblAutoGuardado.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblAutoGuardado.Location = new System.Drawing.Point(35, 126);
            this.lblAutoGuardado.Name = "lblAutoGuardado";
            this.lblAutoGuardado.Size = new System.Drawing.Size(141, 28);
            this.lblAutoGuardado.TabIndex = 27;
            this.lblAutoGuardado.Text = "Autoguardado";
            // 
            // BtnAutoGuardado
            // 
            this.BtnAutoGuardado.BackColor = System.Drawing.Color.Transparent;
            this.BtnAutoGuardado.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.BtnAutoGuardado.FlatAppearance.BorderSize = 0;
            this.BtnAutoGuardado.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnAutoGuardado.Font = new System.Drawing.Font("Segoe UI", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.BtnAutoGuardado.ForeColor = System.Drawing.Color.Transparent;
            this.BtnAutoGuardado.ImageIndex = 0;
            this.BtnAutoGuardado.ImageList = this.imageList1;
            this.BtnAutoGuardado.Location = new System.Drawing.Point(260, 115);
            this.BtnAutoGuardado.Name = "BtnAutoGuardado";
            this.BtnAutoGuardado.Size = new System.Drawing.Size(57, 45);
            this.BtnAutoGuardado.TabIndex = 28;
            this.BtnAutoGuardado.UseVisualStyleBackColor = false;
            this.BtnAutoGuardado.Click += new System.EventHandler(this.BtnAutoGuardado_Click);
            // 
            // imageList1
            // 
            this.imageList1.ColorDepth = System.Windows.Forms.ColorDepth.Depth32Bit;
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "habilitar.png");
            this.imageList1.Images.SetKeyName(1, "palanca.png");
            // 
            // txtDirectorio
            // 
            this.txtDirectorio.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txtDirectorio.Location = new System.Drawing.Point(260, 185);
            this.txtDirectorio.Name = "txtDirectorio";
            this.txtDirectorio.Size = new System.Drawing.Size(388, 34);
            this.txtDirectorio.TabIndex = 29;
            // 
            // lblUbicacion
            // 
            this.lblUbicacion.AutoSize = true;
            this.lblUbicacion.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblUbicacion.Location = new System.Drawing.Point(35, 185);
            this.lblUbicacion.Name = "lblUbicacion";
            this.lblUbicacion.Size = new System.Drawing.Size(103, 28);
            this.lblUbicacion.TabIndex = 30;
            this.lblUbicacion.Text = "Ubicación:";
            // 
            // BtnSeleccionarDirectorio
            // 
            this.BtnSeleccionarDirectorio.Location = new System.Drawing.Point(665, 185);
            this.BtnSeleccionarDirectorio.Name = "BtnSeleccionarDirectorio";
            this.BtnSeleccionarDirectorio.Size = new System.Drawing.Size(102, 34);
            this.BtnSeleccionarDirectorio.TabIndex = 31;
            this.BtnSeleccionarDirectorio.Text = "Abrir";
            this.BtnSeleccionarDirectorio.UseVisualStyleBackColor = true;
            this.BtnSeleccionarDirectorio.Visible = false;
            this.BtnSeleccionarDirectorio.Click += new System.EventHandler(this.BtnSeleccionarDirectorio_Click);
            // 
            // lblHorariosDeAtencion
            // 
            this.lblHorariosDeAtencion.AutoSize = true;
            this.lblHorariosDeAtencion.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblHorariosDeAtencion.Location = new System.Drawing.Point(35, 401);
            this.lblHorariosDeAtencion.Name = "lblHorariosDeAtencion";
            this.lblHorariosDeAtencion.Size = new System.Drawing.Size(189, 56);
            this.lblHorariosDeAtencion.TabIndex = 32;
            this.lblHorariosDeAtencion.Text = "Horario de Atención\r\ndel Centro Medico:";
            // 
            // lblNombreCentroMedico
            // 
            this.lblNombreCentroMedico.AutoSize = true;
            this.lblNombreCentroMedico.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblNombreCentroMedico.Location = new System.Drawing.Point(35, 242);
            this.lblNombreCentroMedico.Name = "lblNombreCentroMedico";
            this.lblNombreCentroMedico.Size = new System.Drawing.Size(185, 28);
            this.lblNombreCentroMedico.TabIndex = 33;
            this.lblNombreCentroMedico.Text = "Nombre del Centro:";
            // 
            // txtNombreCentro
            // 
            this.txtNombreCentro.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txtNombreCentro.Location = new System.Drawing.Point(260, 242);
            this.txtNombreCentro.Name = "txtNombreCentro";
            this.txtNombreCentro.Size = new System.Drawing.Size(388, 34);
            this.txtNombreCentro.TabIndex = 34;
            // 
            // BtnGuardarNombre
            // 
            this.BtnGuardarNombre.Location = new System.Drawing.Point(665, 242);
            this.BtnGuardarNombre.Name = "BtnGuardarNombre";
            this.BtnGuardarNombre.Size = new System.Drawing.Size(102, 34);
            this.BtnGuardarNombre.TabIndex = 35;
            this.BtnGuardarNombre.Text = "Guardar";
            this.BtnGuardarNombre.UseVisualStyleBackColor = true;
            this.BtnGuardarNombre.Click += new System.EventHandler(this.BtnGuardarNombre_Click);
            // 
            // btnCambiarHorarios
            // 
            this.btnCambiarHorarios.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnCambiarHorarios.Location = new System.Drawing.Point(260, 601);
            this.btnCambiarHorarios.Name = "btnCambiarHorarios";
            this.btnCambiarHorarios.Size = new System.Drawing.Size(397, 36);
            this.btnCambiarHorarios.TabIndex = 41;
            this.btnCambiarHorarios.Text = "Cambiar horarios";
            this.btnCambiarHorarios.UseVisualStyleBackColor = true;
            this.btnCambiarHorarios.Click += new System.EventHandler(this.btnCambiarHorarios_Click);
            // 
            // btnAgregarEspecialidad
            // 
            this.btnAgregarEspecialidad.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnAgregarEspecialidad.Location = new System.Drawing.Point(665, 299);
            this.btnAgregarEspecialidad.Name = "btnAgregarEspecialidad";
            this.btnAgregarEspecialidad.Size = new System.Drawing.Size(102, 34);
            this.btnAgregarEspecialidad.TabIndex = 44;
            this.btnAgregarEspecialidad.Text = "Guardar";
            this.btnAgregarEspecialidad.UseVisualStyleBackColor = true;
            this.btnAgregarEspecialidad.Click += new System.EventHandler(this.BtnAgregarEspecialidad_Click);
            // 
            // lblEspecialidades
            // 
            this.lblEspecialidades.AutoSize = true;
            this.lblEspecialidades.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblEspecialidades.Location = new System.Drawing.Point(35, 357);
            this.lblEspecialidades.Name = "lblEspecialidades";
            this.lblEspecialidades.Size = new System.Drawing.Size(142, 28);
            this.lblEspecialidades.TabIndex = 42;
            this.lblEspecialidades.Text = "Especialidades:";
            // 
            // cmbEspecialidades
            // 
            this.cmbEspecialidades.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbEspecialidades.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.cmbEspecialidades.FormattingEnabled = true;
            this.cmbEspecialidades.Location = new System.Drawing.Point(260, 354);
            this.cmbEspecialidades.Name = "cmbEspecialidades";
            this.cmbEspecialidades.Size = new System.Drawing.Size(388, 36);
            this.cmbEspecialidades.TabIndex = 45;
            // 
            // BtnEliminarEspecialidad
            // 
            this.BtnEliminarEspecialidad.BackColor = System.Drawing.Color.LightCoral;
            this.BtnEliminarEspecialidad.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.BtnEliminarEspecialidad.Location = new System.Drawing.Point(665, 351);
            this.BtnEliminarEspecialidad.Name = "BtnEliminarEspecialidad";
            this.BtnEliminarEspecialidad.Size = new System.Drawing.Size(41, 41);
            this.BtnEliminarEspecialidad.TabIndex = 46;
            this.BtnEliminarEspecialidad.Text = "X";
            this.BtnEliminarEspecialidad.UseVisualStyleBackColor = false;
            this.BtnEliminarEspecialidad.Click += new System.EventHandler(this.BtnEliminarEspecialidad_Click);
            // 
            // lblHorarioDelCentro
            // 
            this.lblHorarioDelCentro.AutoSize = true;
            this.lblHorarioDelCentro.Location = new System.Drawing.Point(263, 409);
            this.lblHorarioDelCentro.Name = "lblHorarioDelCentro";
            this.lblHorarioDelCentro.Size = new System.Drawing.Size(204, 20);
            this.lblHorarioDelCentro.TabIndex = 47;
            this.lblHorarioDelCentro.Text = "Descripción de todos los dias";
            // 
            // txtAgregarEspecialidad
            // 
            this.txtAgregarEspecialidad.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txtAgregarEspecialidad.Location = new System.Drawing.Point(260, 299);
            this.txtAgregarEspecialidad.Name = "txtAgregarEspecialidad";
            this.txtAgregarEspecialidad.PlaceholderText = "Inserte especialidad";
            this.txtAgregarEspecialidad.Size = new System.Drawing.Size(388, 34);
            this.txtAgregarEspecialidad.TabIndex = 49;
            // 
            // lblAgregarEspecialidad
            // 
            this.lblAgregarEspecialidad.AutoSize = true;
            this.lblAgregarEspecialidad.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblAgregarEspecialidad.Location = new System.Drawing.Point(35, 299);
            this.lblAgregarEspecialidad.Name = "lblAgregarEspecialidad";
            this.lblAgregarEspecialidad.Size = new System.Drawing.Size(200, 28);
            this.lblAgregarEspecialidad.TabIndex = 48;
            this.lblAgregarEspecialidad.Text = "Agregar especialidad:";
            // 
            // FrmConfiguracion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(840, 662);
            this.Controls.Add(this.txtAgregarEspecialidad);
            this.Controls.Add(this.lblAgregarEspecialidad);
            this.Controls.Add(this.lblHorarioDelCentro);
            this.Controls.Add(this.BtnEliminarEspecialidad);
            this.Controls.Add(this.cmbEspecialidades);
            this.Controls.Add(this.btnAgregarEspecialidad);
            this.Controls.Add(this.lblEspecialidades);
            this.Controls.Add(this.btnCambiarHorarios);
            this.Controls.Add(this.BtnGuardarNombre);
            this.Controls.Add(this.txtNombreCentro);
            this.Controls.Add(this.lblNombreCentroMedico);
            this.Controls.Add(this.lblHorariosDeAtencion);
            this.Controls.Add(this.BtnSeleccionarDirectorio);
            this.Controls.Add(this.lblUbicacion);
            this.Controls.Add(this.txtDirectorio);
            this.Controls.Add(this.BtnAutoGuardado);
            this.Controls.Add(this.lblAutoGuardado);
            this.Name = "FrmConfiguracion";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.FrmConfiguracion_Load);
            this.Controls.SetChildIndex(this.lblAutoGuardado, 0);
            this.Controls.SetChildIndex(this.BtnAutoGuardado, 0);
            this.Controls.SetChildIndex(this.txtDirectorio, 0);
            this.Controls.SetChildIndex(this.lblUbicacion, 0);
            this.Controls.SetChildIndex(this.BtnSeleccionarDirectorio, 0);
            this.Controls.SetChildIndex(this.lblHorariosDeAtencion, 0);
            this.Controls.SetChildIndex(this.lblNombreCentroMedico, 0);
            this.Controls.SetChildIndex(this.txtNombreCentro, 0);
            this.Controls.SetChildIndex(this.BtnGuardarNombre, 0);
            this.Controls.SetChildIndex(this.btnCambiarHorarios, 0);
            this.Controls.SetChildIndex(this.lblEspecialidades, 0);
            this.Controls.SetChildIndex(this.btnAgregarEspecialidad, 0);
            this.Controls.SetChildIndex(this.cmbEspecialidades, 0);
            this.Controls.SetChildIndex(this.BtnEliminarEspecialidad, 0);
            this.Controls.SetChildIndex(this.lblHorarioDelCentro, 0);
            this.Controls.SetChildIndex(this.lblAgregarEspecialidad, 0);
            this.Controls.SetChildIndex(this.txtAgregarEspecialidad, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblAutoGuardado;
        private System.Windows.Forms.Button BtnAutoGuardado;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.TextBox txtDirectorio;
        private System.Windows.Forms.Label lblUbicacion;
        private System.Windows.Forms.Button BtnSeleccionarDirectorio;
        private System.Windows.Forms.Label lblHorariosDeAtencion;
        private System.Windows.Forms.Label lblNombreCentroMedico;
        private System.Windows.Forms.TextBox txtNombreCentro;
        private System.Windows.Forms.Button BtnGuardarNombre;
        private System.Windows.Forms.Button btnCambiarHorarios;
        private System.Windows.Forms.Button btnAgregarEspecialidad;
        private System.Windows.Forms.Label lblEspecialidades;
        private System.Windows.Forms.ComboBox cmbEspecialidades;
        private System.Windows.Forms.Button BtnEliminarEspecialidad;
        private System.Windows.Forms.Label lblHorarioDelCentro;
        private System.Windows.Forms.TextBox txtAgregarEspecialidad;
        private System.Windows.Forms.Label lblAgregarEspecialidad;
    }
}