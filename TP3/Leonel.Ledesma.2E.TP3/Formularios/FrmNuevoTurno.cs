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
    public partial class FrmNuevoTurno : FrmSecundario
    {
        private Profesional profesionalSeleccionado;
        private Paciente pacienteSeleccionado;
        private string especialidad;
        private DateTime fechaTurno;
        private Turno turnoAModificar;
        private bool modificarTurno;

        public FrmNuevoTurno(Paciente paciente) : base($"Nuevo turno para {paciente.Nombre}")
        {
            InitializeComponent();
            this.pacienteSeleccionado = paciente;            
        }

        public FrmNuevoTurno(Turno turno) : base($"Modificar turno {turno.Id}")
        {
            InitializeComponent();

            this.modificarTurno = true;
            this.turnoAModificar = turno;
            this.CargarTurno(turno);
        }

        private void CargarSegundoPasoEspecialidad()
        {
            lblSegundoPaso.Text = "Seleccione especialidad:";
            cmbSegundoPaso.DataSource = centroMedico.ListaEspecialidades;
        }

        private void CargarSegundoPasoProfesional()
        {
            lblSegundoPaso.Text = "Seleccione profesional:";
            cmbSegundoPaso.DataSource = centroMedico.Profesionales;
        }

        private void CargarTercerPasoEspecialidad()
        {
            cmbTercerPaso.DataSource = centroMedico.BuscarProfesional(cmbSegundoPaso.Text, "Especialidad");
            lblTercerPaso.Text = "Profesionales: ";

        }

        private void CargarTercerPasoProfesional()
        {
            profesionalSeleccionado = ((Profesional)cmbSegundoPaso.SelectedItem);
            cmbTercerPaso.DataSource = profesionalSeleccionado.Especialidades;
            lblTercerPaso.Text = "Especialidades: ";
        }

        private void CargarCuartoPaso()
        {
            cmbFechas.Visible = true;
            lblSeleccioneFecha.Visible = true;

            if (cmbSeleccionarPor.Text == "Especialidad")
            {
                profesionalSeleccionado = ((Profesional)cmbTercerPaso.SelectedItem);
            }

            this.CargarFechas();
        }


        public void CargarTurno(Turno turno)
        {
            cmbSeleccionarPor.SelectedIndex = 1;

            cmbSegundoPaso.SelectedItem = turno.Profesional;

            cmbTercerPaso.SelectedItem = turno.Especialidad;

            cmbFechas.SelectedItem = turno.Fecha;
            pacienteSeleccionado = turno.Paciente;
        }

        private void CargarFechas()
        {
            DateTime fechaDeInicio = DateTime.Today;
            DateTime fechaLimite = fechaDeInicio + new TimeSpan(62, 0, 0, 0);

            try
            {

                List<DateTime> lista = centroMedico.BuscarFechasDisponibles(profesionalSeleccionado, fechaDeInicio, fechaLimite);
                cmbFechas.DataSource = lista;

                if (modificarTurno)
                {
                    string fecha = this.turnoAModificar.Fecha.ToString("dd/MM/yyyy");
                    bool encontrado = false;
                    foreach (DateTime item in lista)
                    {
                        string itemString = item.ToString("dd/MM/yyyy");
                        if (itemString == fecha)
                        {
                            cmbFechas.SelectedItem = item;
                            encontrado = true;
                            break;
                        }
                    }

                    if (!encontrado)
                    {
                        cmbFechas.Items.Add(fecha);
                        cmbFechas.DataSource = null;
                        cmbFechas.DataSource = lista;
                        cmbFechas.SelectedItem = fecha;
                    }
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Ocurrio un error al cargar las fechas disponibles");
            }



        }

        private void CargarHoras()
        {
            List<string> lista = centroMedico.BuscarHorasDisponibles(profesionalSeleccionado, (DateTime)cmbFechas.SelectedItem);
            cmbHorarios.DataSource = lista;

            if (modificarTurno)
            {
                string hora = this.turnoAModificar.Fecha.ToString("hh:mm");
                bool encontrado = false;
                foreach (string item in lista)
                {

                    if (item == hora)
                    {
                        cmbFechas.SelectedItem = item;
                        encontrado = true;
                        break;
                    }
                }

                if (!encontrado)
                {
                    lista.Add(hora);
                    cmbHorarios.DataSource = null;
                    cmbHorarios.DataSource = lista;
                    cmbHorarios.SelectedItem = hora;
                }
            }
        }

        /// <summary>
        /// Crea el turno y lo agrega a la lista de turnos del centro medico.
        /// </summary>
        private void ConfirmarTurno()
        {
            try
            {
                Turno turno = new Turno(centroMedico.ProximoId, fechaTurno, pacienteSeleccionado, profesionalSeleccionado, especialidad);
                if (centroMedico.AgregarTurno(turno))
                {
                    MessageBox.Show("Turno agregado correctamente");
                }
                else
                {
                    MessageBox.Show("No se pudo agregar el turno");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void ModificarTurno()
        {
            try
            {
                turnoAModificar.Fecha = fechaTurno;
                turnoAModificar.Paciente = pacienteSeleccionado;
                turnoAModificar.Profesional = profesionalSeleccionado;
                turnoAModificar.Especialidad = especialidad;


                MessageBox.Show("Turno modificado correctamente");
                this.Close();
            }
            catch
            {
                MessageBox.Show("No se pudo modificar el turno");
            }

        }


        private void cmbSeleccionarPor_SelectedIndexChanged(object sender, EventArgs e)
        {
            cmbSegundoPaso.Visible = true;
            lblSegundoPaso.Visible = true;


            if (cmbSeleccionarPor.Text == "Especialidad")
                this.CargarSegundoPasoEspecialidad();
            else
            {
                this.CargarSegundoPasoProfesional();
            }
        }

        private void cmbSegundoPaso_SelectedIndexChanged(object sender, EventArgs e)
        {
            cmbTercerPaso.Visible = true;
            lblTercerPaso.Visible = true;
            cmbFechas.Visible = false;
            lblSeleccioneHorario.Visible = false;

            if (cmbSeleccionarPor.Text == "Especialidad")
            {
                this.CargarTercerPasoEspecialidad();
                especialidad = cmbSegundoPaso.Text;
            }
            else
            {
                this.CargarTercerPasoProfesional();
            }
        }

        private void cmbTercerPaso_SelectedIndexChanged(object sender, EventArgs e)
        {
            cmbFechas.Visible = true;
            lblSeleccioneHorario.Visible = true;

            this.CargarCuartoPaso();
            especialidad = cmbTercerPaso.Text;
        }

        private void cmbFechas_SelectedIndexChanged(object sender, EventArgs e)
        {
            cmbHorarios.Visible = true;
            lblSeleccioneHorario.Visible = true;
            this.CargarHoras();
        }

        private void BtnConfirmar_Click(object sender, EventArgs e)
        {
            if (!modificarTurno)
            {
                this.ConfirmarTurno();
            }
            else
            {
                this.ModificarTurno();
            }
        }

        private void cmbHorarios_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (cmbHorarios.SelectedItem != null)
                {
                    string[] horaSeleccionada = ((string)cmbHorarios.SelectedItem).Split(":");
                    this.fechaTurno = (DateTime)cmbFechas.SelectedItem + new TimeSpan(int.Parse(horaSeleccionada[0]), int.Parse(horaSeleccionada[1]), 0);
                }

            }
            catch
            {

            }

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
