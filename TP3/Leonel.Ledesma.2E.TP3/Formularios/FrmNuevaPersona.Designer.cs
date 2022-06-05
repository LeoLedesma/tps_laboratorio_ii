﻿namespace Formularios
{
    partial class FrmNuevaPersona
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
            this.lblNombre = new System.Windows.Forms.Label();
            this.lblApellido = new System.Windows.Forms.Label();
            this.lblGenero = new System.Windows.Forms.Label();
            this.lblDocumento = new System.Windows.Forms.Label();
            this.lblTelefono = new System.Windows.Forms.Label();
            this.lblObraSocial = new System.Windows.Forms.Label();
            this.txbNombre = new System.Windows.Forms.TextBox();
            this.txbApellido = new System.Windows.Forms.TextBox();
            this.txbDocumento = new System.Windows.Forms.TextBox();
            this.txbTelefono = new System.Windows.Forms.TextBox();
            this.txbObraSocial = new System.Windows.Forms.TextBox();
            this.cmbGenero = new System.Windows.Forms.ComboBox();
            this.BtnEnviar = new System.Windows.Forms.Button();
            this.txbNumeroAfiliado = new System.Windows.Forms.TextBox();
            this.lblNumeroAfiliado = new System.Windows.Forms.Label();
            this.txbTelefonoContacto = new System.Windows.Forms.TextBox();
            this.lblTelefonoContacto = new System.Windows.Forms.Label();
            this.BtnVaciarCampos = new System.Windows.Forms.Button();
            this.lblNacionalidad = new System.Windows.Forms.Label();
            this.gpbFechaNacimiento = new System.Windows.Forms.GroupBox();
            this.txbDiaNacimiento = new System.Windows.Forms.TextBox();
            this.txbAñoNacimiento = new System.Windows.Forms.TextBox();
            this.txbMesNacimiento = new System.Windows.Forms.TextBox();
            this.cmbNacionalidad = new System.Windows.Forms.ComboBox();
            this.lblNumeroMatricula = new System.Windows.Forms.Label();
            this.txbNumeroMatricula = new System.Windows.Forms.TextBox();
            this.lblEspecialidades = new System.Windows.Forms.Label();
            this.ltbEspecialidades = new System.Windows.Forms.ListBox();
            this.ltbEspecialidadesSeleccionadas = new System.Windows.Forms.ListBox();
            this.BtnAgregarEspecialidad = new System.Windows.Forms.Button();
            this.BtnEliminarEspecialidad = new System.Windows.Forms.Button();
            this.gpbFechaNacimiento.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblNombre
            // 
            this.lblNombre.AutoSize = true;
            this.lblNombre.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblNombre.Location = new System.Drawing.Point(119, 121);
            this.lblNombre.Name = "lblNombre";
            this.lblNombre.Size = new System.Drawing.Size(110, 28);
            this.lblNombre.TabIndex = 1;
            this.lblNombre.Text = "Nombre (*)";
            // 
            // lblApellido
            // 
            this.lblApellido.AutoSize = true;
            this.lblApellido.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblApellido.Location = new System.Drawing.Point(118, 195);
            this.lblApellido.Name = "lblApellido";
            this.lblApellido.Size = new System.Drawing.Size(111, 28);
            this.lblApellido.TabIndex = 2;
            this.lblApellido.Text = "Apellido (*)";
            // 
            // lblGenero
            // 
            this.lblGenero.AutoSize = true;
            this.lblGenero.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblGenero.Location = new System.Drawing.Point(428, 339);
            this.lblGenero.Name = "lblGenero";
            this.lblGenero.Size = new System.Drawing.Size(101, 28);
            this.lblGenero.TabIndex = 4;
            this.lblGenero.Text = "Genero (*)";
            // 
            // lblDocumento
            // 
            this.lblDocumento.AutoSize = true;
            this.lblDocumento.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblDocumento.Location = new System.Drawing.Point(118, 267);
            this.lblDocumento.Name = "lblDocumento";
            this.lblDocumento.Size = new System.Drawing.Size(168, 28);
            this.lblDocumento.TabIndex = 5;
            this.lblDocumento.Text = "N° Documento (*)";
            // 
            // lblTelefono
            // 
            this.lblTelefono.AutoSize = true;
            this.lblTelefono.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblTelefono.Location = new System.Drawing.Point(118, 341);
            this.lblTelefono.Name = "lblTelefono";
            this.lblTelefono.Size = new System.Drawing.Size(111, 28);
            this.lblTelefono.TabIndex = 6;
            this.lblTelefono.Text = "Teléfono (*)";
            // 
            // lblObraSocial
            // 
            this.lblObraSocial.AutoSize = true;
            this.lblObraSocial.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblObraSocial.Location = new System.Drawing.Point(428, 121);
            this.lblObraSocial.Name = "lblObraSocial";
            this.lblObraSocial.Size = new System.Drawing.Size(113, 28);
            this.lblObraSocial.TabIndex = 7;
            this.lblObraSocial.Text = "Obra Social";
            // 
            // txbNombre
            // 
            this.txbNombre.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txbNombre.Location = new System.Drawing.Point(119, 149);
            this.txbNombre.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txbNombre.Name = "txbNombre";
            this.txbNombre.Size = new System.Drawing.Size(219, 34);
            this.txbNombre.TabIndex = 1;
            this.txbNombre.TextChanged += new System.EventHandler(this.CambioRealizado);
            this.txbNombre.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.ValidarCampoChars);
            // 
            // txbApellido
            // 
            this.txbApellido.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txbApellido.Location = new System.Drawing.Point(118, 223);
            this.txbApellido.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txbApellido.Name = "txbApellido";
            this.txbApellido.Size = new System.Drawing.Size(219, 34);
            this.txbApellido.TabIndex = 2;
            this.txbApellido.TextChanged += new System.EventHandler(this.CambioRealizado);
            this.txbApellido.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.ValidarCampoChars);
            // 
            // txbDocumento
            // 
            this.txbDocumento.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txbDocumento.Location = new System.Drawing.Point(118, 295);
            this.txbDocumento.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txbDocumento.Name = "txbDocumento";
            this.txbDocumento.Size = new System.Drawing.Size(219, 34);
            this.txbDocumento.TabIndex = 3;
            this.txbDocumento.TextChanged += new System.EventHandler(this.CambioRealizado);
            this.txbDocumento.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.ValidarCampoNumerico);
            // 
            // txbTelefono
            // 
            this.txbTelefono.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txbTelefono.Location = new System.Drawing.Point(118, 369);
            this.txbTelefono.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txbTelefono.Name = "txbTelefono";
            this.txbTelefono.Size = new System.Drawing.Size(219, 34);
            this.txbTelefono.TabIndex = 4;
            this.txbTelefono.TextChanged += new System.EventHandler(this.CambioRealizado);
            this.txbTelefono.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.ValidarCampoNumerico);
            // 
            // txbObraSocial
            // 
            this.txbObraSocial.CausesValidation = false;
            this.txbObraSocial.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txbObraSocial.Location = new System.Drawing.Point(428, 151);
            this.txbObraSocial.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txbObraSocial.Name = "txbObraSocial";
            this.txbObraSocial.Size = new System.Drawing.Size(219, 34);
            this.txbObraSocial.TabIndex = 7;
            this.txbObraSocial.TextChanged += new System.EventHandler(this.CambioRealizado);
            this.txbObraSocial.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.ValidarCampoChars);
            // 
            // cmbGenero
            // 
            this.cmbGenero.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbGenero.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.cmbGenero.FormattingEnabled = true;
            this.cmbGenero.Location = new System.Drawing.Point(428, 369);
            this.cmbGenero.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cmbGenero.Name = "cmbGenero";
            this.cmbGenero.Size = new System.Drawing.Size(219, 36);
            this.cmbGenero.TabIndex = 11;
            this.cmbGenero.TextChanged += new System.EventHandler(this.CambioRealizado);
            // 
            // BtnEnviar
            // 
            this.BtnEnviar.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.BtnEnviar.FlatAppearance.BorderSize = 0;
            this.BtnEnviar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnEnviar.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.BtnEnviar.Location = new System.Drawing.Point(428, 529);
            this.BtnEnviar.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.BtnEnviar.Name = "BtnEnviar";
            this.BtnEnviar.Size = new System.Drawing.Size(251, 44);
            this.BtnEnviar.TabIndex = 13;
            this.BtnEnviar.Text = "Enviar";
            this.BtnEnviar.UseVisualStyleBackColor = false;
            this.BtnEnviar.Click += new System.EventHandler(this.BtnEnviar_Click);
            // 
            // txbNumeroAfiliado
            // 
            this.txbNumeroAfiliado.CausesValidation = false;
            this.txbNumeroAfiliado.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txbNumeroAfiliado.Location = new System.Drawing.Point(428, 225);
            this.txbNumeroAfiliado.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txbNumeroAfiliado.Name = "txbNumeroAfiliado";
            this.txbNumeroAfiliado.Size = new System.Drawing.Size(219, 34);
            this.txbNumeroAfiliado.TabIndex = 8;
            this.txbNumeroAfiliado.TextChanged += new System.EventHandler(this.CambioRealizado);
            this.txbNumeroAfiliado.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.ValidarCampoNumerico);
            // 
            // lblNumeroAfiliado
            // 
            this.lblNumeroAfiliado.AutoSize = true;
            this.lblNumeroAfiliado.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblNumeroAfiliado.Location = new System.Drawing.Point(428, 195);
            this.lblNumeroAfiliado.Name = "lblNumeroAfiliado";
            this.lblNumeroAfiliado.Size = new System.Drawing.Size(108, 28);
            this.lblNumeroAfiliado.TabIndex = 19;
            this.lblNumeroAfiliado.Text = "N° Afiliado";
            // 
            // txbTelefonoContacto
            // 
            this.txbTelefonoContacto.CausesValidation = false;
            this.txbTelefonoContacto.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txbTelefonoContacto.Location = new System.Drawing.Point(428, 450);
            this.txbTelefonoContacto.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txbTelefonoContacto.Name = "txbTelefonoContacto";
            this.txbTelefonoContacto.Size = new System.Drawing.Size(219, 34);
            this.txbTelefonoContacto.TabIndex = 12;
            this.txbTelefonoContacto.TextChanged += new System.EventHandler(this.CambioRealizado);
            this.txbTelefonoContacto.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.ValidarCampoNumerico);
            // 
            // lblTelefonoContacto
            // 
            this.lblTelefonoContacto.AutoSize = true;
            this.lblTelefonoContacto.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblTelefonoContacto.Location = new System.Drawing.Point(428, 417);
            this.lblTelefonoContacto.Name = "lblTelefonoContacto";
            this.lblTelefonoContacto.Size = new System.Drawing.Size(171, 28);
            this.lblTelefonoContacto.TabIndex = 21;
            this.lblTelefonoContacto.Text = "Teléfono Contacto";
            // 
            // BtnVaciarCampos
            // 
            this.BtnVaciarCampos.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.BtnVaciarCampos.FlatAppearance.BorderSize = 0;
            this.BtnVaciarCampos.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnVaciarCampos.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.BtnVaciarCampos.Location = new System.Drawing.Point(119, 529);
            this.BtnVaciarCampos.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.BtnVaciarCampos.Name = "BtnVaciarCampos";
            this.BtnVaciarCampos.Size = new System.Drawing.Size(251, 44);
            this.BtnVaciarCampos.TabIndex = 14;
            this.BtnVaciarCampos.Text = "Vaciar campos";
            this.BtnVaciarCampos.UseVisualStyleBackColor = false;
            this.BtnVaciarCampos.Click += new System.EventHandler(this.BtnVaciarCampos_Click);
            // 
            // lblNacionalidad
            // 
            this.lblNacionalidad.AutoSize = true;
            this.lblNacionalidad.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblNacionalidad.Location = new System.Drawing.Point(428, 265);
            this.lblNacionalidad.Name = "lblNacionalidad";
            this.lblNacionalidad.Size = new System.Drawing.Size(153, 28);
            this.lblNacionalidad.TabIndex = 27;
            this.lblNacionalidad.Text = "Nacionalidad (*)";
            // 
            // gpbFechaNacimiento
            // 
            this.gpbFechaNacimiento.Controls.Add(this.txbDiaNacimiento);
            this.gpbFechaNacimiento.Controls.Add(this.txbAñoNacimiento);
            this.gpbFechaNacimiento.Controls.Add(this.txbMesNacimiento);
            this.gpbFechaNacimiento.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.gpbFechaNacimiento.Location = new System.Drawing.Point(112, 415);
            this.gpbFechaNacimiento.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.gpbFechaNacimiento.Name = "gpbFechaNacimiento";
            this.gpbFechaNacimiento.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.gpbFechaNacimiento.Size = new System.Drawing.Size(235, 81);
            this.gpbFechaNacimiento.TabIndex = 5;
            this.gpbFechaNacimiento.TabStop = false;
            this.gpbFechaNacimiento.Text = "Fecha de nacimiento";
            // 
            // txbDiaNacimiento
            // 
            this.txbDiaNacimiento.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txbDiaNacimiento.Location = new System.Drawing.Point(6, 33);
            this.txbDiaNacimiento.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txbDiaNacimiento.Name = "txbDiaNacimiento";
            this.txbDiaNacimiento.Size = new System.Drawing.Size(45, 34);
            this.txbDiaNacimiento.TabIndex = 5;
            this.txbDiaNacimiento.TextChanged += new System.EventHandler(this.CambioRealizado);
            this.txbDiaNacimiento.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.ValidarCampoNumerico);
            // 
            // txbAñoNacimiento
            // 
            this.txbAñoNacimiento.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txbAñoNacimiento.Location = new System.Drawing.Point(107, 33);
            this.txbAñoNacimiento.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txbAñoNacimiento.Name = "txbAñoNacimiento";
            this.txbAñoNacimiento.Size = new System.Drawing.Size(112, 34);
            this.txbAñoNacimiento.TabIndex = 7;
            this.txbAñoNacimiento.TextChanged += new System.EventHandler(this.CambioRealizado);
            this.txbAñoNacimiento.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.ValidarCampoNumerico);
            // 
            // txbMesNacimiento
            // 
            this.txbMesNacimiento.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txbMesNacimiento.Location = new System.Drawing.Point(56, 33);
            this.txbMesNacimiento.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txbMesNacimiento.Name = "txbMesNacimiento";
            this.txbMesNacimiento.Size = new System.Drawing.Size(45, 34);
            this.txbMesNacimiento.TabIndex = 6;
            this.txbMesNacimiento.TextChanged += new System.EventHandler(this.CambioRealizado);
            this.txbMesNacimiento.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.ValidarCampoNumerico);
            // 
            // cmbNacionalidad
            // 
            this.cmbNacionalidad.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbNacionalidad.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.cmbNacionalidad.FormattingEnabled = true;
            this.cmbNacionalidad.Location = new System.Drawing.Point(428, 295);
            this.cmbNacionalidad.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cmbNacionalidad.Name = "cmbNacionalidad";
            this.cmbNacionalidad.Size = new System.Drawing.Size(219, 36);
            this.cmbNacionalidad.TabIndex = 10;
            this.cmbNacionalidad.TextChanged += new System.EventHandler(this.CambioRealizado);
            // 
            // lblNumeroMatricula
            // 
            this.lblNumeroMatricula.AutoSize = true;
            this.lblNumeroMatricula.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblNumeroMatricula.Location = new System.Drawing.Point(428, 121);
            this.lblNumeroMatricula.Name = "lblNumeroMatricula";
            this.lblNumeroMatricula.Size = new System.Drawing.Size(147, 28);
            this.lblNumeroMatricula.TabIndex = 30;
            this.lblNumeroMatricula.Text = "N° Matricula (*)";
            // 
            // txbNumeroMatricula
            // 
            this.txbNumeroMatricula.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txbNumeroMatricula.Location = new System.Drawing.Point(428, 151);
            this.txbNumeroMatricula.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txbNumeroMatricula.Name = "txbNumeroMatricula";
            this.txbNumeroMatricula.Size = new System.Drawing.Size(219, 34);
            this.txbNumeroMatricula.TabIndex = 8;
            this.txbNumeroMatricula.TextChanged += new System.EventHandler(this.CambioRealizado);
            this.txbNumeroMatricula.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.ValidarCampoNumerico);
            // 
            // lblEspecialidades
            // 
            this.lblEspecialidades.AutoSize = true;
            this.lblEspecialidades.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblEspecialidades.Location = new System.Drawing.Point(428, 339);
            this.lblEspecialidades.Name = "lblEspecialidades";
            this.lblEspecialidades.Size = new System.Drawing.Size(138, 28);
            this.lblEspecialidades.TabIndex = 35;
            this.lblEspecialidades.Text = "Especialidades";
            // 
            // ltbEspecialidades
            // 
            this.ltbEspecialidades.FormattingEnabled = true;
            this.ltbEspecialidades.ItemHeight = 20;
            this.ltbEspecialidades.Location = new System.Drawing.Point(428, 369);
            this.ltbEspecialidades.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.ltbEspecialidades.Name = "ltbEspecialidades";
            this.ltbEspecialidades.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.ltbEspecialidades.Size = new System.Drawing.Size(121, 124);
            this.ltbEspecialidades.TabIndex = 11;
            this.ltbEspecialidades.SelectedIndexChanged += new System.EventHandler(this.ltbEspecialidades_SelectedIndexChanged);
            // 
            // ltbEspecialidadesSeleccionadas
            // 
            this.ltbEspecialidadesSeleccionadas.FormattingEnabled = true;
            this.ltbEspecialidadesSeleccionadas.ItemHeight = 20;
            this.ltbEspecialidadesSeleccionadas.Location = new System.Drawing.Point(586, 369);
            this.ltbEspecialidadesSeleccionadas.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.ltbEspecialidadesSeleccionadas.Name = "ltbEspecialidadesSeleccionadas";
            this.ltbEspecialidadesSeleccionadas.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.ltbEspecialidadesSeleccionadas.Size = new System.Drawing.Size(121, 124);
            this.ltbEspecialidadesSeleccionadas.TabIndex = 36;
            // 
            // BtnAgregarEspecialidad
            // 
            this.BtnAgregarEspecialidad.Location = new System.Drawing.Point(553, 386);
            this.BtnAgregarEspecialidad.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.BtnAgregarEspecialidad.Name = "BtnAgregarEspecialidad";
            this.BtnAgregarEspecialidad.Size = new System.Drawing.Size(29, 32);
            this.BtnAgregarEspecialidad.TabIndex = 37;
            this.BtnAgregarEspecialidad.Text = ">";
            this.BtnAgregarEspecialidad.UseVisualStyleBackColor = true;
            this.BtnAgregarEspecialidad.Click += new System.EventHandler(this.BtnAgregarEspecialidad_Click);
            // 
            // BtnEliminarEspecialidad
            // 
            this.BtnEliminarEspecialidad.Location = new System.Drawing.Point(553, 440);
            this.BtnEliminarEspecialidad.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.BtnEliminarEspecialidad.Name = "BtnEliminarEspecialidad";
            this.BtnEliminarEspecialidad.Size = new System.Drawing.Size(29, 35);
            this.BtnEliminarEspecialidad.TabIndex = 38;
            this.BtnEliminarEspecialidad.Text = "<";
            this.BtnEliminarEspecialidad.UseVisualStyleBackColor = true;
            this.BtnEliminarEspecialidad.Click += new System.EventHandler(this.BtnEliminarEspecialidad_Click);
            // 
            // FrmNuevaPersona
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(1167, 736);
            this.Controls.Add(this.BtnEliminarEspecialidad);
            this.Controls.Add(this.BtnAgregarEspecialidad);
            this.Controls.Add(this.ltbEspecialidadesSeleccionadas);
            this.Controls.Add(this.ltbEspecialidades);
            this.Controls.Add(this.lblEspecialidades);
            this.Controls.Add(this.txbNumeroMatricula);
            this.Controls.Add(this.lblNumeroMatricula);
            this.Controls.Add(this.cmbNacionalidad);
            this.Controls.Add(this.gpbFechaNacimiento);
            this.Controls.Add(this.lblNacionalidad);
            this.Controls.Add(this.BtnVaciarCampos);
            this.Controls.Add(this.txbTelefonoContacto);
            this.Controls.Add(this.lblTelefonoContacto);
            this.Controls.Add(this.txbNumeroAfiliado);
            this.Controls.Add(this.lblNumeroAfiliado);
            this.Controls.Add(this.cmbGenero);
            this.Controls.Add(this.BtnEnviar);
            this.Controls.Add(this.txbObraSocial);
            this.Controls.Add(this.txbTelefono);
            this.Controls.Add(this.txbDocumento);
            this.Controls.Add(this.txbApellido);
            this.Controls.Add(this.txbNombre);
            this.Controls.Add(this.lblObraSocial);
            this.Controls.Add(this.lblTelefono);
            this.Controls.Add(this.lblDocumento);
            this.Controls.Add(this.lblGenero);
            this.Controls.Add(this.lblApellido);
            this.Controls.Add(this.lblNombre);
            this.Location = new System.Drawing.Point(0, 0);
            this.Name = "FrmNuevaPersona";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmNuevaPersona_FormClosing);
            this.Controls.SetChildIndex(this.lblNombre, 0);
            this.Controls.SetChildIndex(this.lblApellido, 0);
            this.Controls.SetChildIndex(this.lblGenero, 0);
            this.Controls.SetChildIndex(this.lblDocumento, 0);
            this.Controls.SetChildIndex(this.lblTelefono, 0);
            this.Controls.SetChildIndex(this.lblObraSocial, 0);
            this.Controls.SetChildIndex(this.txbNombre, 0);
            this.Controls.SetChildIndex(this.txbApellido, 0);
            this.Controls.SetChildIndex(this.txbDocumento, 0);
            this.Controls.SetChildIndex(this.txbTelefono, 0);
            this.Controls.SetChildIndex(this.txbObraSocial, 0);
            this.Controls.SetChildIndex(this.BtnEnviar, 0);
            this.Controls.SetChildIndex(this.cmbGenero, 0);
            this.Controls.SetChildIndex(this.lblNumeroAfiliado, 0);
            this.Controls.SetChildIndex(this.txbNumeroAfiliado, 0);
            this.Controls.SetChildIndex(this.lblTelefonoContacto, 0);
            this.Controls.SetChildIndex(this.txbTelefonoContacto, 0);
            this.Controls.SetChildIndex(this.BtnVaciarCampos, 0);
            this.Controls.SetChildIndex(this.lblNacionalidad, 0);
            this.Controls.SetChildIndex(this.gpbFechaNacimiento, 0);
            this.Controls.SetChildIndex(this.cmbNacionalidad, 0);
            this.Controls.SetChildIndex(this.lblNumeroMatricula, 0);
            this.Controls.SetChildIndex(this.txbNumeroMatricula, 0);
            this.Controls.SetChildIndex(this.lblEspecialidades, 0);
            this.Controls.SetChildIndex(this.ltbEspecialidades, 0);
            this.Controls.SetChildIndex(this.ltbEspecialidadesSeleccionadas, 0);
            this.Controls.SetChildIndex(this.BtnAgregarEspecialidad, 0);
            this.Controls.SetChildIndex(this.BtnEliminarEspecialidad, 0);
            this.gpbFechaNacimiento.ResumeLayout(false);
            this.gpbFechaNacimiento.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label lblNombre;
        private System.Windows.Forms.Label lblApellido;
        private System.Windows.Forms.Label lblGenero;
        private System.Windows.Forms.Label lblDocumento;
        private System.Windows.Forms.Label lblTelefono;
        private System.Windows.Forms.Label lblObraSocial;
        private System.Windows.Forms.TextBox txbNombre;
        private System.Windows.Forms.TextBox txbApellido;
        private System.Windows.Forms.TextBox txbDocumento;
        private System.Windows.Forms.TextBox txbTelefono;
        private System.Windows.Forms.TextBox txbObraSocial;
        private System.Windows.Forms.ComboBox cmbGenero;
        private System.Windows.Forms.Button BtnEnviar;
        private System.Windows.Forms.TextBox txbNumeroAfiliado;
        private System.Windows.Forms.Label lblNumeroAfiliado;
        private System.Windows.Forms.TextBox txbTelefonoContacto;
        private System.Windows.Forms.Label lblTelefonoContacto;        
        private System.Windows.Forms.Button BtnVaciarCampos;
        private System.Windows.Forms.Label lblNacionalidad;
        private System.Windows.Forms.GroupBox gpbFechaNacimiento;
        private System.Windows.Forms.TextBox txbAñoNacimiento;
        private System.Windows.Forms.TextBox txbMesNacimiento;
        private System.Windows.Forms.TextBox txbDiaNacimiento;
        private System.Windows.Forms.ComboBox cmbNacionalidad;
        private System.Windows.Forms.Label lblNumeroMatricula;
        private System.Windows.Forms.TextBox txbNumeroMatricula;
        private System.Windows.Forms.Label lblEspecialidades;
        private System.Windows.Forms.ListBox ltbEspecialidades;
        private System.Windows.Forms.ListBox ltbEspecialidadesSeleccionadas;
        private System.Windows.Forms.Button BtnAgregarEspecialidad;
        private System.Windows.Forms.Button BtnEliminarEspecialidad;
    }
}