using Entidades;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Formularios
{
    public partial class FrmVerTurnos : FrmSecundario
    {
        public FrmVerTurnos() : base("Ver turnos")
        {
            InitializeComponent();
            cmbProfesionales.Items.Add("Todos");
            cmbProfesionales.Items.AddRange(centroMedico.Profesionales.ToArray());
            cmbProfesionales.SelectedIndex = 0;
            dtpFecha.Visible = false;
            cbxTodasLasFechas.Checked = true;
        }

        public FrmVerTurnos(Paciente paciente) : base($"Turnos de {paciente}")
        {
            InitializeComponent();
            cmbProfesionales.Items.Add("Todos");
            cmbProfesionales.Items.AddRange(centroMedico.Profesionales.ToArray());
        }

        public void BuscarTurnos()
        {
            try
            {
                List<Turno> coincidencias = new List<Turno>();

                if (cbxTodasLasFechas.Checked)
                {
                    coincidencias = this.BuscarTurnosTodasLasFechas();
                }
                else //No son todas las fechas
                {
                    coincidencias = this.BuscarTurnosFechaEspecifica();
                }

                if (coincidencias.Count > 0)
                {
                    dgvTurnos.DataSource = coincidencias;
                    dgvTurnos.Visible = true;
                }
                else
                {
                    this.OcultarCoincidencias();
                    MessageBox.Show("No hubo coincidencias en la busqueda.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void OcultarCoincidencias()
        {
            dgvTurnos.Visible = false;
            this.OcultarBotones();
        }

        private void OcultarBotones()
        {

        }

        private List<Turno> BuscarTurnosTodasLasFechas()
        {
            List<Turno> coincidencias = new List<Turno>();
            if (cmbProfesionales.Text == "Todos" && txtDocumentoPaciente.Text == "")
            {
                coincidencias = centroMedico.Turnos;
            }
            else if (cmbProfesionales.Text == "Todos" && txtDocumentoPaciente.Text != "")
            {
                coincidencias = centroMedico.BuscarTurnos(centroMedico.BuscarPaciente(txtDocumentoPaciente.Text));
            }
            else if (cmbProfesionales.Text != "Todos" && txtDocumentoPaciente.Text == "")
            {
                coincidencias = centroMedico.BuscarTurnos((Profesional)cmbProfesionales.SelectedItem);
            }
            else if (cmbProfesionales.Text != "Todos" && txtDocumentoPaciente.Text != "")
            {
                coincidencias = centroMedico.BuscarTurnos((Profesional)cmbProfesionales.SelectedItem, centroMedico.BuscarPaciente(txtDocumentoPaciente.Text));
            }

            return coincidencias;
        }

        private List<Turno> BuscarTurnosFechaEspecifica()
        {
            Profesional profesionalSeleccionado = (Profesional)cmbProfesionales.SelectedItem;
            List<Turno> coincidencias = new List<Turno>();

            if (txtDocumentoPaciente.Text == "")
            {
                coincidencias = centroMedico.BuscarTurnos(dtpFecha.Value, profesionalSeleccionado);
            }
            else
            {
                coincidencias = centroMedico.BuscarTurnos(dtpFecha.Value, profesionalSeleccionado, txtDocumentoPaciente.Text);
            }

            return coincidencias;
        }


        //DateTime fechaSeleccionada = dtpFecha.Value;
        //Profesional profesionalSeleccionado = (Profesional)cmbProfesionales.SelectedItem;
        //List<Turno> coincidencias = new List<Turno>();

        //if (txtDocumentoPaciente.Text == "")
        //{
        //    coincidencias = centroMedico.BuscarTurnos(fechaSeleccionada, profesionalSeleccionado);
        //}
        //else
        //{
        //    coincidencias = centroMedico.BuscarTurnos(fechaSeleccionada, profesionalSeleccionado, txtDocumentoPaciente.Text);
        //}

        //dgvTurnos.DataSource = coincidencias;
        //dgvTurnos.Visible = true;




        private void BtnEliminar_Click(object sender, EventArgs e)
        {

        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            if (cmbProfesionales.SelectedIndex != -1)
            {
                this.BuscarTurnos();
            }
        }

        private void cbxFecha_CheckedChanged(object sender, EventArgs e)
        {
            if (cbxTodasLasFechas.Checked)
            {
                dtpFecha.Visible = false;
            }
            else
            {
                dtpFecha.Visible = true;
            }
        }

        private void btnExportarCoincidencias_Click(object sender, EventArgs e)
        {
            try
            {
                SaveFileDialog saveFile = new SaveFileDialog();
                saveFile.Filter = "Archivo JSON |*.json|Archivo XML |*.xml|Archivo de texto .txt |*.txt";
                
                if (saveFile.ShowDialog() == DialogResult.OK)
                {
                    string fullPath = saveFile.FileName;
                    if (!string.IsNullOrEmpty(fullPath))
                    {
                        List<Turno> coincidencias = (List<Turno>)dgvTurnos.DataSource;
                        if (fullPath.Contains(".xml"))
                        {
                            centroMedico.SerializarListaToXML(fullPath, (List<Turno>)dgvTurnos.DataSource);
                        }
                        else if (fullPath.Contains(".json"))
                        {
                            centroMedico.SerializarListaToJSON(fullPath, (List<Turno>)dgvTurnos.DataSource);
                        }
                        else
                        {
                            GestorDeArchivos.GuardarArchivo(fullPath, coincidencias);
                        }
                    }
                }

            }
            catch (Exception)
            {
                MessageBox.Show("Ocurrio un error al intentar exportar");
            }
        }

        private void FrmVerTurnos_Load(object sender, EventArgs e)
        {

        }
    }
}
