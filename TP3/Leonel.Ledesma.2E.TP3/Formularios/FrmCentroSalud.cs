using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Entidades;
using Entidades.Exceptions;

namespace Formularios
{
    public partial class FrmCentroSalud : Form
    {
        private static FrmCentroSalud instancia;

        private CentroMedico centroMedico;

        private FrmNuevaPersona nuevoPaciente;
        private FrmNuevaPersona nuevoProfesional;
        private FrmBuscar buscarPaciente;
        private FrmConfiguracion configuracion;
        private FrmNuevoTurno nuevoTurno;

        private OpenFileDialog openFile;
        private SaveFileDialog saveFile;

        private string pathAutoGuardado;
        private bool autoGuardado;

        public string PathAutoGuardado { get => pathAutoGuardado; set => pathAutoGuardado = value; }
        public bool AutoGuardado { get => autoGuardado; set => autoGuardado = value; }

        public static FrmCentroSalud Instancia()
        {
            if (FrmCentroSalud.instancia is null)
            {
                FrmCentroSalud.instancia = new FrmCentroSalud();
            }
            return FrmCentroSalud.instancia;
        }

        private FrmCentroSalud()
        {
            InitializeComponent();
            this.CargarDiseño();

            this.centroMedico = CentroMedico.Instanciar("Centro Medico Ledesma");
            this.Text = centroMedico.Nombre;
            
            this.ActualizarNombre();
            this.InicializarFileDialogs();
            this.CargarConfiguracion();
            this.CargarCantidadPersonas();
        }

        public void InicializarFileDialogs()
        {
            this.openFile = new OpenFileDialog();
            this.saveFile = new SaveFileDialog();

            this.saveFile.Filter = "Archivo JSON |*.json|Archivo XML |*.xml";
            this.openFile.Filter = "Archivo JSON |*.json|Archivo XML |*.xml";
        }


        #region Diseño

        private void CargarDiseño()
        {
            this.pnlLogo.Visible = false;
            this.pnlArchivosSubMenu.Visible = false;
            this.pnlPacientesSubMenu.Visible = false;
            this.pnlProfesionalesSubMenu.Visible = false;
            this.pnlTurnosSubMenu.Visible = false;
            this.pnlConfiguracionSubMenu.Visible = false;
        }

        private static void AbrirSubMenu(Panel subMenu)
        {
            if (subMenu.Visible == false)
            {
                subMenu.Visible = true;
            }
            else
            {
                subMenu.Visible = false;
            }
        }

        private void CerrarSubMenus()
        {
            if (pnlArchivosSubMenu.Visible == true)
                pnlArchivosSubMenu.Visible = false;
            if (pnlPacientesSubMenu.Visible == true)
                pnlPacientesSubMenu.Visible = false;
            if (pnlTurnosSubMenu.Visible == true)
                pnlTurnosSubMenu.Visible = false;
            if (pnlProfesionalesSubMenu.Visible == true)
                pnlProfesionalesSubMenu.Visible = false;
        }

        private void CargarCantidadPersonas()
        {
            this.lblCantidadPacientes.Text = $"Cantidad pacientes: {this.centroMedico.Pacientes.Count}";
            this.lblCantidadProfesionales.Text = $"Cantidad profesionales: {this.centroMedico.Profesionales.Count}";
        }

        public void ActualizarNombre()
        {
            this.lblNombre.Text = this.centroMedico.Nombre;
        }


        #endregion


        #region botones

        private void BtnPacientesSubMenu_Click(object sender, EventArgs e)
        {
            AbrirSubMenu(pnlPacientesSubMenu);
        }

        #region botones Titulares
        private void BtnTurnosSubMenu_Click(object sender, EventArgs e)
        {
            AbrirSubMenu(pnlTurnosSubMenu);
        }

        private void BtnProfesionalesSubMenu_Click(object sender, EventArgs e)
        {

            AbrirSubMenu(pnlProfesionalesSubMenu);
        }

        private void BtnOtrosSubMenu_Click(object sender, EventArgs e)
        {
            AbrirSubMenu(pnlArchivosSubMenu);
        }

        private void BtnConfiguracionSubMenu_Click(object sender, EventArgs e)
        {
            AbrirSubMenu(pnlConfiguracionSubMenu);
        }
        #endregion

        #region pacientes
        private void BtnNuevoPaciente_Click(object sender, EventArgs e)
        {
                       
            if (this.nuevoPaciente != null)
            {
                this.nuevoPaciente.Close();
            }
            this.nuevoPaciente = new FrmNuevaPersona(true, "Nuevo paciente");
            this.AbrirFormularioSecundario(this.nuevoPaciente);
            this.CerrarSubMenus();
        }


        private void BtnBuscarPaciente_Click(object sender, EventArgs e)
        {
            this.buscarPaciente = new FrmBuscar(true, "Buscar paciente");
            this.AbrirFormularioSecundario(this.buscarPaciente);
            this.CerrarSubMenus();
        }
        #endregion

        #region turnos
        private void BtnConfirmarTurno_Click(object sender, EventArgs e)
        {
            FrmBuscar buscar = new FrmBuscar(true);
            this.AbrirFormularioSecundario(buscar);
            CerrarSubMenus();
        }

        private void BtnNuevoTurno_Click(object sender, EventArgs e)
        {
            FrmNuevoTurno nuevoTurno = new FrmNuevoTurno(centroMedico.Pacientes.FirstOrDefault());
            this.AbrirFormularioSecundario(nuevoTurno);
            CerrarSubMenus();
        }

        private void BtnBuscarTurno_Click(object sender, EventArgs e)
        {
            FrmVerTurnos verTurnos= new FrmVerTurnos();
            this.AbrirFormularioSecundario(verTurnos);
            CerrarSubMenus();
        }
        #endregion

        #region profesionales
        private void BtnNuevoProfesional_Click(object sender, EventArgs e)
        {
            if (nuevoProfesional != null)
            {
                nuevoProfesional.Close();
            }
            nuevoProfesional = new FrmNuevaPersona(false, "Nuevo profesional");
            AbrirFormularioSecundario(nuevoProfesional);
            CerrarSubMenus();
        }

        private void BtnBuscarProfesional_Click(object sender, EventArgs e)
        {
            buscarPaciente = new FrmBuscar(false, "Buscar profesional");
            AbrirFormularioSecundario(buscarPaciente);
            CerrarSubMenus();
        }

        private void BtnVerTurnosDelDia_Click(object sender, EventArgs e)
        {
            CerrarSubMenus();
        }
        #endregion
        #endregion


        /// <summary>
        /// Abre un formulario secundario
        /// </summary>
        /// <param name="formulario">Formulario a ser abierto</param>
        public void AbrirFormularioSecundario(FrmSecundario formulario)
        {

            if (formulario != null)
            {
                this.CerrarFormulariosAbiertos();
                formulario.TopLevel = false;
                formulario.FormBorderStyle = FormBorderStyle.None;
                formulario.Dock = DockStyle.Right;
                this.pnlContenedor.Controls.Add(formulario);
                this.pnlContenedor.Tag = formulario;
                formulario.Show();
                formulario.BringToFront();
            }
        }

        /// <summary>
        /// Cierra los formularios abiertos dentro de pnlContenedor.
        /// </summary>
        private void CerrarFormulariosAbiertos()
        {
            foreach (Control control in this.pnlContenedor.Controls)
            {
                if (control is Form && control.IsDisposed == false)
                {
                    ((Form)control).Close();
                }
            }

            CargarCantidadPersonas();
        }



        private void BtnGuardarCentro_Click(object sender, EventArgs e)
        {
            string fullPath = this.SeleccionarRutaGuardado();
            centroMedico.SerializarToJSON(fullPath);
        }

        public string SeleccionarRutaGuardado()
        {
            if (saveFile.ShowDialog() == DialogResult.OK)
            {
                return saveFile.FileName;
            }

            return string.Empty;
        }

        public string SeleccionarRutaArchivo()
        {
            if (openFile.ShowDialog() == DialogResult.OK)
            {
                return openFile.FileName;
            }

            return string.Empty;
        }

        private void BtnGuardarPacientes_Click(object sender, EventArgs e)
        {
            centroMedico.GuardarPacientes(this.SeleccionarRutaGuardado());
        }

        private void BtnImportarPacientes_Click(object sender, EventArgs e)
        {
            try
            {
                int cantidadImportados = centroMedico.ImportarPacientes(this.SeleccionarRutaArchivo());
                MessageBox.Show($"Se importaron {cantidadImportados} pacientes");
                this.CerrarFormulariosAbiertos();
            }
            catch (SerializarException ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void BtnImportarProfesionales_Click(object sender, EventArgs e)
        {
            try
            {
                int cantidadImportados = centroMedico.ImportarProfesionales(this.SeleccionarRutaArchivo());
                MessageBox.Show($"Se importaron {cantidadImportados} profesionales");
                this.CerrarFormulariosAbiertos();
            }
            catch (SerializarException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void BtnGuardarProfesionales_Click(object sender, EventArgs e)
        {
            try
            {
                centroMedico.GuardarProfesionales(this.SeleccionarRutaGuardado());

            }
            catch (SerializarException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void BtnImportarCentro_Click(object sender, EventArgs e)
        {
            if (DialogResult.Yes == MessageBox.Show("Al hacer esto, se eliminaran todos los datos del centro medico actual. Desea continuar?", "Alerta", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning))
            {
                try
                {
                    centroMedico.ImportarCentroMedico(this.SeleccionarRutaArchivo());
                    MessageBox.Show("Se importó el Centro Medico Correctamente");
                    this.CerrarFormulariosAbiertos();
                }
                catch (SerializarException ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void FrmCentroSalud_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.GuardarConfiguracion();
            if (this.AutoGuardado)
            {
                centroMedico.GuardarCentroMedico(this.PathAutoGuardado);
                this.GuardarConfiguracion();
            }
        }

        private void GuardarConfiguracion()
        {
            GestorDeArchivos.GuardarArchivo($"{Directory.GetCurrentDirectory()}.cds", $"{this.AutoGuardado},{this.PathAutoGuardado}");
        }

        private void CargarConfiguracion()
        {

            string lectura = GestorDeArchivos.LeerArchivo($"{Directory.GetCurrentDirectory()}.cds");

            if (!string.IsNullOrEmpty(lectura))
            {
                string[] datos = lectura.Split(',', '\r');
                this.AutoGuardado = bool.Parse(datos[0]);
                this.PathAutoGuardado = datos[1];

                if (this.AutoGuardado)
                {
                    try
                    {
                        centroMedico.ImportarCentroMedico(this.PathAutoGuardado);
                    }
                    catch (DeserializarException ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (this.configuracion != null)
            {
                this.configuracion.Close();
            }
            this.configuracion = new FrmConfiguracion();
            this.AbrirFormularioSecundario(this.configuracion);
            this.CerrarSubMenus();
        }

        private void btnVerTurnos_Click(object sender, EventArgs e)
        {
            FrmVerTurnos verTurnos = new FrmVerTurnos();
            this.AbrirFormularioSecundario(verTurnos);
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void lblNombre_Click(object sender, EventArgs e)
        {

        }
    }
}

