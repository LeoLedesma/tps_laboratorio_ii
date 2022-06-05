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
using Entidades.Exceptions;

namespace Formularios
{
    public partial class FrmBuscar : FrmSecundario
    {
        private List<Paciente> coincidenciasPacientes;
        private List<Profesional> coincidenciasProfesionales;
        private List<Turno> coincidenciasTurnos;
        private FrmCentroSalud frmCentroSalud;
        private bool abrirFuncionPaciente;
        private bool abrirFuncionTurnos;
        private FrmBuscar(string titulo) : base(titulo)
        {
            InitializeComponent();
            frmCentroSalud = FrmCentroSalud.Instancia();
            cmbBuscarPor.SelectedIndex = 0;
            coincidenciasPacientes = new List<Paciente>();
            coincidenciasProfesionales = new List<Profesional>();
            coincidenciasTurnos = new List<Turno>();
        }

        public FrmBuscar(bool abrirFuncionPaciente, string titulo) : this(titulo)
        {
            this.abrirFuncionPaciente = abrirFuncionPaciente;
                       
            this.abrirFuncionTurnos = false;
            
        }

        public FrmBuscar(bool abrirFuncionTurnos) : this("Buscar turnos")
        {
            this.abrirFuncionTurnos = abrirFuncionTurnos;
            this.abrirFuncionPaciente = false;
            this.CargarVisualTurnos();
        }

        static FrmBuscar()
        {
            FrmBuscar.errorProvider = new ErrorProvider();
        }


        public void CargarVisualTurnos()
        {
            cmbBuscarPor.DataSource = new List<string>()
            {
                "Id turno",
                "Documento paciente",
                "Apellido profesional"
            };

            cmbBuscarTurnos.Visible = true;
            cmbBuscarTurnos.DataSource = new List<string>()
            {
                "Futuros",
                "Pasados",
                "Todos"
            };
        }

        private void cmbBuscarPor_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.lblTextoBusqueda.Text = this.cmbBuscarPor.SelectedItem.ToString() + ":";
            this.txbBusqueda.Text = "";
        }

        private void BtnBuscar_Click(object sender, EventArgs e)
        {
            this.Buscar();
        }

        private void txbBusqueda_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!abrirFuncionTurnos)
            {
                switch (cmbBuscarPor.SelectedIndex)
                {
                    case 0:
                    case 3:
                        this.ValidarCampoNumerico(sender, e);
                        break;
                    case 1:
                    case 2:
                        this.ValidarCampoChars(sender, e);
                        break;
                }
            }
            else
            {
                switch (cmbBuscarPor.SelectedIndex)
                {
                    case 0:
                    case 1:
                        this.ValidarCampoNumerico(sender, e);
                        break;

                    case 2:
                        this.ValidarCampoChars(sender, e);
                        break;
                }
            }

        }


        private List<Paciente> BuscarPacientes()
        {
            return this.centroMedico.BuscarPaciente(txbBusqueda.Text, cmbBuscarPor.SelectedItem.ToString());
        }

        private List<Profesional> BuscarProfesionales()
        {
            return this.centroMedico.BuscarProfesional(txbBusqueda.Text, cmbBuscarPor.SelectedItem.ToString());
        }

        /// <summary>
        /// Busca los turnos que coincidan con la busqueda
        /// </summary>
        /// <param name="busqueda"></param>
        /// <returns>Los turnos que coincidan con la busqueda, o lista vacia si ocurrio un error. </returns>
        private List<Turno> BuscarTurnos(string busqueda)
        {
            try
            {
                if (busqueda == "Futuros")
                {
                    return this.centroMedico.BuscarTurnosFuturos(txbBusqueda.Text, cmbBuscarPor.SelectedItem.ToString());
                }
                else if (busqueda == "Pasados")
                {
                    return this.centroMedico.BuscarTurnosPasados(txbBusqueda.Text, cmbBuscarPor.SelectedItem.ToString());
                }
                else
                {
                    return this.centroMedico.BuscarTurnos(txbBusqueda.Text, cmbBuscarPor.SelectedItem.ToString());
                }
            }
            catch (BusquedaException e)
            {
                MessageBox.Show(e.Message);
                return new List<Turno>();
            }

        }

        private void Buscar()
        {

            if (txbBusqueda.Text != "")
            {
                if (!abrirFuncionTurnos && abrirFuncionPaciente)
                {
                    coincidenciasPacientes = this.BuscarPacientes();
                }
                else if (!abrirFuncionTurnos && !abrirFuncionPaciente)
                {
                    coincidenciasProfesionales = this.BuscarProfesionales();
                }
                else
                {
                    coincidenciasTurnos = this.BuscarTurnos(cmbBuscarTurnos.Text);
                }

                MostrarCoincidencias();

            }
            else
            {
                OcultarBotones();
            }
        }

        private void MostrarCoincidencias()
        {
            if ((coincidenciasPacientes.Count > 0 || coincidenciasProfesionales.Count > 0 || coincidenciasTurnos.Count > 0)
                && txbBusqueda.Text.Length > 0)
            {
                dgvCoincidencias.Visible = true;
                dgvCoincidencias.BringToFront();

                if (abrirFuncionTurnos)
                {
                    this.CargarDiseñoColumnasTurnos();
                }
                else
                {
                    this.CargarDiseñoColumnasPersonas();
                }

                MostrarBotones();
            }
            else
            {
                dgvCoincidencias.Visible = false;
            }
        }


        private void MostrarBotones()
        {
            if (!abrirFuncionTurnos)
            {
                this.BtnVerTurnos.Visible = true;

                if (!abrirFuncionPaciente)
                {
                    this.BtnModificarHorarios.Visible = true;
                }else
                {
                    this.btnNuevoTurno.Visible = true;
                }

            }

            this.dgvCoincidencias.Visible = true;
            this.BtnEliminar.Visible = true;
            this.BtnModificar.Visible = true;
            this.BtnExportar.Visible = true;
            this.BtnConfirmarTurno.Visible = true;

        }

        private void OcultarBotones()
        {
            this.dgvCoincidencias.Visible = false;
            this.BtnEliminar.Visible = false;
            this.BtnModificar.Visible = false;
            this.BtnVerTurnos.Visible = false;
            this.BtnExportar.Visible = false;
            this.BtnConfirmarTurno.Visible = false;
            this.btnNuevoTurno.Visible = false;

            if (!abrirFuncionPaciente)
            {
                this.BtnModificarHorarios.Visible = false;
            }
        }

        private void CargarDiseñoColumnasPersonas()
        {
            if (abrirFuncionPaciente)
            {
                this.dgvCoincidencias.DataSource = this.coincidenciasPacientes;
                this.dgvCoincidencias.Columns["NumeroAfiliado"].DisplayIndex = 5;
                this.dgvCoincidencias.Columns["NumeroAfiliado"].HeaderText = "N° Afiliado";
                this.dgvCoincidencias.Columns["ObraSocial"].HeaderText = "Obra Social";
                this.dgvCoincidencias.Columns["ObraSocial"].DisplayIndex = 4;
                this.dgvCoincidencias.Columns["TelefonoContacto"].Visible = false;
            }
            else
            {
                this.dgvCoincidencias.DataSource = this.coincidenciasProfesionales;
                this.dgvCoincidencias.Columns["Matricula"].DisplayIndex = 4;
            }

            this.dgvCoincidencias.Columns["Documento"].DisplayIndex = 0;
            this.dgvCoincidencias.Columns["Nombre"].DisplayIndex = 1;
            this.dgvCoincidencias.Columns["Apellido"].DisplayIndex = 2;
            this.dgvCoincidencias.Columns["FechaDeNacimiento"].Visible = false;
            this.dgvCoincidencias.Columns["Telefono"].DisplayIndex = 3;
        }

        private void CargarDiseñoColumnasTurnos()
        {
            this.dgvCoincidencias.DataSource = this.coincidenciasTurnos;
            this.dgvCoincidencias.Columns["Id"].DisplayIndex = 0;
            this.dgvCoincidencias.Columns["Fecha"].DisplayIndex = 1;

            if (cmbBuscarTurnos.Text == "Futuros")
            {
                this.dgvCoincidencias.Columns["PacienteAsistio"].Visible = false;
            }

            this.dgvCoincidencias.Columns["PacienteAsistio"].HeaderText = "Asistió";



            dgvCoincidencias.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);

        }


        private void txbBusqueda_KeyUp(object sender, KeyEventArgs e)
        {
            this.Buscar();
        }

        private void txbBusqueda_Enter(object sender, EventArgs e)
        {
            this.Buscar();
        }

        private void AbrirModificarPaciente(Paciente paciente)
        {
            FrmNuevaPersona FrmModificar = new FrmNuevaPersona(paciente);
            frmCentroSalud.AbrirFormularioSecundario(FrmModificar);
        }

        private void AbrirModificarProfesional(Profesional profesional)
        {
            FrmNuevaPersona FrmModificar = new FrmNuevaPersona(profesional);
            frmCentroSalud.AbrirFormularioSecundario(FrmModificar);
        }

        private void AbrirModificarTurno(Turno turno)
        {
            FrmNuevoTurno FrmModificar = new FrmNuevoTurno(turno);
            frmCentroSalud.AbrirFormularioSecundario(FrmModificar);
        }

        private Paciente SeleccionarPaciente()
        {
            string documentoSeleccionado = dgvCoincidencias.CurrentRow.Cells["Documento"].Value.ToString();
            Paciente paciente = centroMedico.BuscarPaciente(documentoSeleccionado);

            return paciente;
        }

        private Profesional SeleccionarProfesional()
        {
            string documentoSeleccionado = dgvCoincidencias.CurrentRow.Cells["Documento"].Value.ToString();
            Profesional profesional = centroMedico.BuscarProfesional(documentoSeleccionado);
            return profesional;
        }

        private void EliminarPersona()
        {
            try
            {
                Persona persona;

                if (abrirFuncionPaciente)
                {
                    persona = this.SeleccionarPaciente();
                }
                else
                {
                    persona = this.SeleccionarProfesional();
                }

                if (persona is not null)
                {
                    this.centroMedico.RemoverPersona(persona);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }


        }

        /// <summary>
        /// Elimina el turno seleccionado segun su Id.
        /// </summary>
        private void EliminarTurno()
        {
            try
            {
                string idSeleccionada = dgvCoincidencias.CurrentRow.Cells["Id"].Value.ToString();
                this.centroMedico.EliminarTurno(int.Parse(idSeleccionada));
            }
            catch (TurnoNoExisteException ex)
            {
                MessageBox.Show(ex.Message);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


        private void dgvCoincidencias_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            this.Modificar();
        }

        private void BtnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                if (!abrirFuncionTurnos)
                {
                    this.EliminarPersona();
                }
                else
                {
                    this.EliminarTurno();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            Buscar();
        }

        private void dgvCoincidencias_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dgvCoincidencias.Columns[e.ColumnIndex].Name == "Nombre" || dgvCoincidencias.Columns[e.ColumnIndex].Name == "Apellido")
            {
                if (e.Value != null)
                {
                    e.Value = e.Value.ToString().TotUpperFirstLetter();
                    e.FormattingApplied = true;
                }
            }
        }

        private void BtnExportar_Click(object sender, EventArgs e)
        {
            try
            {                

                Persona persona;

                if (abrirFuncionPaciente)
                {
                    persona = this.SeleccionarPaciente();
                }
                else
                {
                    persona = this.SeleccionarProfesional();
                }

                string fullPath = FrmCentroSalud.Instancia().SeleccionarRutaGuardado();

                if (!string.IsNullOrEmpty(fullPath))
                {
                    persona.Serializar(fullPath);
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Ocurrio un error al intentar exportar");
            }

        }

        /// <summary>
        /// Confirma el turno seleccionado.
        /// </summary>
        public void ConfirmarAsistenciaTurno()
        {
            try
            {
                int idSeleccionada = (int)dgvCoincidencias.CurrentRow.Cells["Id"].Value;
                Turno turno = centroMedico.BuscarTurno(idSeleccionada);

                if (turno.Fecha < DateTime.Today || turno.Fecha > DateTime.Today || turno.PacienteAsistio == false)
                {
                    MessageBox.Show("No se puede confirmar este turno.");
                }
                else
                {
                    turno.Confirmar();
                    MessageBox.Show("Turno confirmado");
                    this.Buscar();
                }
            }
            catch (Exception)
            {
                MessageBox.Show("No se pudo confirmar el turno");
            }
        }

        private void Modificar()
        {
            try
            {
                if (!abrirFuncionTurnos)
                {

                    if (abrirFuncionPaciente)
                    {
                        AbrirModificarPaciente(this.SeleccionarPaciente());
                    }
                    else
                    {
                        AbrirModificarProfesional(this.SeleccionarProfesional());
                    }


                    dgvCoincidencias.Visible = false;
                    txbBusqueda.Text = "";
                }
                else
                {
                    int idSeleccionado = (int)dgvCoincidencias.CurrentRow.Cells["Id"].Value;
                    AbrirModificarTurno(centroMedico.BuscarTurno(idSeleccionado));
                }

            }
            catch (Exception)
            {
                MessageBox.Show("No se pudo abrir el menu modificacion");
            }
        }

        private void BtnModificarHorarios_Click(object sender, EventArgs e)
        {
            
            FrmSeleccionarHorariosAtencion form = new FrmSeleccionarHorariosAtencion(this.SeleccionarProfesional());
            FrmCentroSalud.Instancia().AbrirFormularioSecundario(form);
            form.Show();
        }

        private void cmbBuscarTurnos_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbBuscarTurnos.Text == "Pasados")
            {
                BtnModificar.Visible = false;
                BtnConfirmarTurno.Visible = false;
            }

            this.Buscar();
        }

        private void BtnConfirmarTurno_Click(object sender, EventArgs e)
        {
            this.ConfirmarAsistenciaTurno();
        }

        private void btnNuevoTurno_Click(object sender, EventArgs e)
        {
            FrmNuevoTurno nuevoTurno = new FrmNuevoTurno(this.SeleccionarPaciente());
            FrmCentroSalud.Instancia().AbrirFormularioSecundario(nuevoTurno);
        }

        private void BtnModificar_Click(object sender, EventArgs e)
        {
            this.Modificar();
        }

        private void BtnVerTurnos_Click(object sender, EventArgs e)
        {
            FrmVerTurnos verTurnos = new FrmVerTurnos(this.SeleccionarPaciente());
            FrmCentroSalud.Instancia().AbrirFormularioSecundario(verTurnos);
        }
    }
}
