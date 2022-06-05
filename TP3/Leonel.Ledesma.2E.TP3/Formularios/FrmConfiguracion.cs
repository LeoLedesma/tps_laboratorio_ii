using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Entidades;
using Entidades.Models;

namespace Formularios
{
    public partial class FrmConfiguracion : FrmSecundario
    {
        private SaveFileDialog saveFile;

        public FrmConfiguracion() : base("Configuración")
        {
            InitializeComponent();
            this.saveFile = new SaveFileDialog();
            this.saveFile.Filter = "Archivo JSON |*.json|Archivo XML |*.xml";
        }

        public bool AutoGuardado { get => FrmCentroSalud.Instancia().AutoGuardado; set => FrmCentroSalud.Instancia().AutoGuardado = value; }
        public string PathAutoguardado { get => FrmCentroSalud.Instancia().PathAutoGuardado; set => FrmCentroSalud.Instancia().PathAutoGuardado = value; }

        public void CargarConfiguracionAutoGuardado()
        {
            if (this.AutoGuardado)
            {
                BtnAutoGuardado.ImageIndex = 0;
                this.txtDirectorio.Text = this.PathAutoguardado;
                lblUbicacion.Visible = true;
                txtDirectorio.Visible = true;
            }
            else
            {
                BtnAutoGuardado.ImageIndex = 1;
                lblUbicacion.Visible = false;
                txtDirectorio.Visible = false;
                MessageBox.Show("Auto guardado es false");
            }
        }

        public void CambiarVisibilidadDirectorio()
        {
            if (lblUbicacion.Visible == true)
            {
                lblUbicacion.Visible = false;
                txtDirectorio.Visible = false;
            }
            else
            {
                lblUbicacion.Visible = true;
                txtDirectorio.Visible = true;
            }
        }

        private void BtnAutoGuardado_Click(object sender, EventArgs e)
        {
            if (BtnAutoGuardado.ImageIndex == 1)
            {
                BtnAutoGuardado.ImageIndex = 0;
                this.AutoGuardado = true;
                this.CambiarVisibilidadDirectorio();
            }
            else
            {
                BtnAutoGuardado.ImageIndex = 1;
                this.AutoGuardado = false;
                this.CambiarVisibilidadDirectorio();
            }
        }

        private void BtnSeleccionarDirectorio_Click(object sender, EventArgs e)
        {
            if (DialogResult.OK == saveFile.ShowDialog())
            {
                this.PathAutoguardado = saveFile.FileName;
                this.txtDirectorio.Text = PathAutoguardado;
            }
        }

        private void BtnGuardarNombre_Click(object sender, EventArgs e)
        {
            CentroMedico.Instancia.Nombre = txtNombreCentro.Text;
            FrmCentroSalud.Instancia().ActualizarNombre();
        }

        private void FrmConfiguracion_Load(object sender, EventArgs e)
        {
            this.CargarConfiguracionAutoGuardado();
            this.txtNombreCentro.Text = this.centroMedico.Nombre;
            this.cmbEspecialidades.DataSource = this.centroMedico.ListaEspecialidades;
            this.lblHorarioDelCentro.Text = this.centroMedico.DiasDeAtencion.ToString();
        }


        private void button1_Click(object sender, EventArgs e)
        {
            FrmSeleccionarHorariosAtencion horarios = new FrmSeleccionarHorariosAtencion(centroMedico);
            FrmCentroSalud.Instancia().AbrirFormularioSecundario(horarios);
        }

        private void BtnAgregarEspecialidad_Click(object sender, EventArgs e)
        {
            try
            {
                this.centroMedico.AgregarEspecialidad(this.cmbEspecialidades.Text);
                cmbEspecialidades.DataSource = null;
                cmbEspecialidades.DataSource = this.centroMedico.ListaEspecialidades;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
