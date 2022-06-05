using Entidades;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace Formularios
{
    public partial class FrmNuevaPersona : FrmSecundario
    {
        private bool funcionModificar;
        private bool funcionProfesional;

        private Persona persona;
        private Persona auxiliarPersona;

        private bool cambioRealizado;


        private List<string> listaEspecialidadesAuxiliar;

        /// <summary>
        /// Constructor por defecto, donde el lblTitulo va a ser titulo. 
        /// Crea instancias para persona, auxiliarPersona y listaEspecialidadesAuxiliar.
        /// </summary>
        /// <param name="titulo">Texto que tendra el lblTitulo</param>
        private FrmNuevaPersona(string titulo) : base(titulo)
        {
            InitializeComponent();

            this.cmbGenero.DataSource = Enum.GetValues(typeof(Persona.eGenero));
            this.cmbNacionalidad.DataSource = Enum.GetValues(typeof(Persona.eNacionalidad));

            this.persona = new Paciente();
            this.auxiliarPersona = new Paciente();
            this.listaEspecialidadesAuxiliar = new List<string>();

            cambioRealizado = false;
        }


        /// <summary>
        /// Constructor donde modifica el diseño del formulario segun el contenido de "abriVisualpaciente".
        /// </summary>
        /// <param name="abrirVisualPaciente">Si es true el formulario se visualizara para pacientes, si es false para profesionales</param>
        /// <param name="titulo">Texto que tendra el lblTitul</param>
        public FrmNuevaPersona(bool abrirVisualPaciente, string titulo) : this(titulo)
        {
            if (abrirVisualPaciente)
            {
                this.DiseñoPaciente();
                funcionProfesional = false;
            }
            else
            {
                listaEspecialidadesAuxiliar = new List<string>();
                this.funcionProfesional = true;
                this.DiseñoProfesional();
            }
        }


        /// <summary>
        /// Constructor donde se podra modificar el profesional recibido por parametro. 
        /// Abriendo todas las funcionalidades para dicha entidad.
        /// </summary>
        /// <param name="profesional">Profesional a ser modificado</param>
        public FrmNuevaPersona(Profesional profesional) : this(false, "Modificar profesional")
        {
            this.BtnEnviar.Text = "Modificar profesional";
            this.funcionModificar = true;
            this.persona = profesional;
            this.CargarTextbox();
            this.cambioRealizado = false;

        }

        /// <summary>
        /// Constructor donde se podra modificar el Paciente recibido por parametro. 
        /// Abriendo todas las funcionalidades para dicha entidad.
        /// </summary>
        /// <param name="paciente">Paciente a ser modificado</param>
        public FrmNuevaPersona(Paciente paciente) : this(true, "Modificar paciente")
        {
            BtnEnviar.Text = "Modificar paciente";
            this.funcionModificar = true;
            this.persona = paciente;
            this.CargarTextbox();
            this.cambioRealizado = false;
        }


        /// <summary>
        /// Cargara las controles TextBox correspondientes segun tipo de entidad, para poder ser modificadas.
        /// </summary>
        private void CargarTextbox()
        {
            this.txbNombre.Text = this.persona.Nombre;
            this.txbApellido.Text = this.persona.Apellido;
            this.txbAñoNacimiento.Text = this.persona.FechaDeNacimiento.Year.ToString();
            this.txbDiaNacimiento.Text = this.persona.FechaDeNacimiento.Day.ToString();
            this.txbMesNacimiento.Text = this.persona.FechaDeNacimiento.Month.ToString();
            this.txbDocumento.Text = this.persona.Documento;
            this.txbTelefono.Text = this.persona.Telefono;
            this.cmbNacionalidad.SelectedItem = this.persona.nacionalidad;
            this.cmbGenero.SelectedItem = this.persona.genero;

            if (this.persona is Paciente)
            {
                this.txbObraSocial.Text = ((Paciente)this.persona).ObraSocial;
                this.txbNumeroAfiliado.Text = ((Paciente)this.persona).NumeroAfiliado;
                this.txbTelefonoContacto.Text = ((Paciente)this.persona).TelefonoContacto;
            }
            else if (this.persona is Profesional)
            {
                this.txbNumeroMatricula.Text = ((Profesional)this.persona).Matricula;
                this.ltbEspecialidadesSeleccionadas.DataSource = ((Profesional)this.persona).Especialidades;
            }
        }


        //Diseños

        /// <summary>
        /// Modifica la propiedad Visible y de CausesValidation de los controles para la correcta funcionalidad para los pacientes.
        /// Modifica la propiedad Text de BtnEnviar a "Agregar paciente"
        /// </summary>
        private void DiseñoPaciente()
        {
            this.BtnEnviar.Text = "Agregar paciente";
            this.txbNumeroMatricula.Visible = false;
            this.lblNumeroMatricula.Visible = false;
            this.BtnAgregarEspecialidad.Visible = false;
            this.BtnEliminarEspecialidad.Visible = false;
            this.ltbEspecialidades.Visible = false;
            this.lblEspecialidades.Visible = false;
            this.ltbEspecialidadesSeleccionadas.Visible = false;

            this.txbNumeroMatricula.CausesValidation = false;
            this.ltbEspecialidadesSeleccionadas.CausesValidation = false;
            this.ltbEspecialidades.CausesValidation = false;


            this.lblObraSocial.Visible = true;
            this.txbObraSocial.Visible = true;
        }

        /// <summary>
        /// Modifica la propiedad Visible y de CausesValidation de los controles para la correcta funcionalidad para los profesionales.
        /// Modifica la propiedad Text de BtnEnviar a "Agregar profesional"
        /// Carga el cmbEspecialidades con todas las especialidades que tengan los profesionales del Centro Medico.
        /// </summary>
        private void DiseñoProfesional()
        {
            this.funcionProfesional = true;
            this.BtnEnviar.Text = "Agregar profesional";
            this.txbNumeroMatricula.Visible = true;
            this.lblNumeroMatricula.Visible = true;
            this.lblObraSocial.Visible = false;
            this.txbObraSocial.Visible = false;
            this.lblEspecialidades.Visible = true;
            this.lblNumeroAfiliado.Visible = false;
            this.txbNumeroAfiliado.Visible = false;
            this.BtnAgregarEspecialidad.Visible = true;
            this.BtnEnviar.Visible = true;

            this.lblTelefonoContacto.Visible = false;
            this.txbTelefonoContacto.Visible = false;

            this.lblGenero.Location = this.lblNumeroAfiliado.Location;
            this.cmbGenero.Location = this.txbNumeroAfiliado.Location;
            this.cmbGenero.TabIndex = 8;

            this.ltbEspecialidades.DataSource = CentroMedico.Instancia.ListaEspecialidades;
            this.ltbEspecialidadesSeleccionadas.CausesValidation = true;

        }


        /// <summary>
        /// Modifica a la persona recibida por parametro con los datos que esten en los Textboxs.
        /// </summary>
        /// <param name="persona"></param>        
        private void ModificarPersona(Persona persona)
        {
            try
            {
                if (persona is Paciente)
                {
                    this.auxiliarPersona = (Paciente)((Paciente)persona).Clone();
                }
                else if (persona is Profesional)
                {
                    this.auxiliarPersona = (Profesional)((Profesional)persona).Clone();
                }

                if (this.CapturarDatosFormulario(auxiliarPersona))
                {
                    this.centroMedico.RemoverPersona(persona);

                    if (this.centroMedico.AgregarPersona(auxiliarPersona))
                    {
                        MessageBox.Show($"{persona.GetType().Name} modificado con exito!", persona.GetType().Name, MessageBoxButtons.OK);
                        FrmNuevoTurno nuevoTurno = new FrmNuevoTurno((Paciente)persona);
                        FrmCentroSalud.Instancia().AbrirFormularioSecundario(nuevoTurno);
                    }
                    else
                    {
                        MessageBox.Show("Error. Es probable que el numero de documento ya este en uso.", persona.GetType().Name, MessageBoxButtons.OK);
                        errorProvider.SetError(txbDocumento, "Por favor, Confirme el numero de documento");
                        this.centroMedico.AgregarPersona(persona);
                    }
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Ocurrio un error al modificar la persona");
            }
        }

        /// <summary>
        /// Captura los datos del formulario y los inserta en persona.
        /// </summary>
        /// <param name="persona"></param>
        /// <returns></returns>
        private bool CapturarDatosFormulario(Persona persona)
        {
            try
            {
                if (ValidarListas() && ValidarCampos())
                {
                    if (persona is not null)
                    {
                        this.CapturarPersona(persona);
                    }
                    else
                    {
                        this.persona = CapturarPersona();
                    }

                    return true;
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Ocurrio un error al capturar los datos");
            }

            return false;
        }

        /// <summary>
        /// Captura de los controles TextBox correspondientes a cada entidad, creando una instancia con dichos datos segun el atributo funcionProfesional de la instancia del formulario.
        /// </summary>
        /// <returns>Una nueva instancia de Paciente o Profesional, segun el valor de funcionProfesional. </returns>
        private Persona CapturarPersona()
        {
            if (funcionProfesional)
            {
                Profesional profesional = new Profesional();
                this.CapturarPersona(profesional);
                return profesional;
            }
            else
            {
                Paciente paciente = new Paciente();
                CapturarPersona(paciente);
                return paciente;
            }
        }

        /// <summary>
        /// Captura de los controles TextBox correspondientes a cada entidad para asignarlos a la persona recibia por parametro.
        /// </summary>
        /// <param name="persona">Persona que va a ser cargada con la propiedad Text de los TextBox correspondientes.</param>
        private void CapturarPersona(Persona persona)
        {
            try
            {
                persona.Nombre = txbNombre.Text;
                persona.Apellido = txbApellido.Text;
                int diaNacimiento = int.Parse(txbDiaNacimiento.Text);
                int mesNacimiento = int.Parse(txbMesNacimiento.Text);
                int añoNacimiento = int.Parse(txbAñoNacimiento.Text);
                persona.FechaDeNacimiento = new DateTime(añoNacimiento, mesNacimiento, diaNacimiento);
                persona.genero = (Persona.eGenero)cmbGenero.SelectedIndex;
                persona.nacionalidad = (Persona.eNacionalidad)cmbNacionalidad.SelectedIndex;
                persona.Telefono = txbTelefono.Text;
                persona.Documento = txbDocumento.Text;

                if (persona is Paciente)
                {
                    Paciente paciente = (Paciente)persona;
                    paciente.ObraSocial = txbObraSocial.Text;
                    paciente.NumeroAfiliado = txbNumeroAfiliado.Text;
                    paciente.TelefonoContacto = txbTelefono.Text;
                }
                else
                {
                    Profesional profesional = (Profesional)persona;
                    profesional.Matricula = txbNumeroMatricula.Text;
                    profesional.Especialidades.AddRange(ltbEspecialidadesSeleccionadas.Items.Cast<string>());
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Ocurrio un error al capturar la persona.");
            }
        }


        /// <summary>
        /// Valida que los campos obligatorios no esten vacios, captura los datos de los Textbox, crea una nueva instancia y la agrega a la lista correspondiente de la instancia de CentroMedico.
        /// </summary>
        private void AgregarPersona()
        {
            try
            {

                if (this.ValidarCampos() && this.ValidarListas())
                {
                    Persona persona = this.CapturarPersona();

                    if (this.centroMedico.AgregarPersona(persona))
                    {
                        MessageBox.Show($"{persona.GetType().Name} agregado con exito! {persona.GetType().Name}", persona.GetType().Name, MessageBoxButtons.OK);
                        this.cambioRealizado = false;
                    }
                    else
                    {
                        MessageBox.Show($"Error. Es probable que el {persona.GetType().Name.ToLower()} ya se encuentre registrado.", persona.GetType().Name, MessageBoxButtons.OK);
                        errorProvider.SetError(txbDocumento, "Por favor, Confirme el numero de documento");
                    }
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Ocurrio un error al agregar la persona.");
            }

        }


        #region Eventos

        /// <summary>
        /// Vacia todos los TextBox que esten en el formulario.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnVaciarCampos_Click(object sender, EventArgs e)
        {
            this.VaciarCampos();
        }

        /// <summary>
        /// Llama segun el atributo funcionModificar a ModificarPersona o AgregarPersona.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnEnviar_Click(object sender, EventArgs e)
        {

            if (funcionModificar)
            {
                this.ModificarPersona(this.persona);
            }
            else
            {
                this.AgregarPersona();
            }
        }

        private void FrmNuevaPersona_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (this.cambioRealizado)
            {
                if (MessageBox.Show("Se han realizado cambios, pero estos no se han guardado. Desea salir de todos modos?", "Alerta",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    this.Dispose();
                }
                else
                {
                    e.Cancel = true;
                }
            }
        }

        #endregion


        private void CambioRealizado(object sender, EventArgs e)
        {
            this.cambioRealizado = true;
        }

        /// <summary>
        /// Envia desde ltbEspecialidades a ltbEspecialidadesSeleccionadas el elemento seleccionado.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnAgregarEspecialidad_Click(object sender, EventArgs e)
        {
            string entrada;
            try
            {
                entrada = ltbEspecialidades.SelectedItem.ToString();

                if (entrada is not null && this.listaEspecialidadesAuxiliar.Contains(entrada))
                {
                    MessageBox.Show("La especialidad ya se encuentra seleccionada", "Error", MessageBoxButtons.OK);
                }
                else if (entrada is not null)
                {
                    this.listaEspecialidadesAuxiliar.Add(entrada);
                    this.ltbEspecialidadesSeleccionadas.DataSource = null;
                    this.ltbEspecialidadesSeleccionadas.DataSource = listaEspecialidadesAuxiliar;
                }

                errorProvider.Clear();
            }
            catch (NullReferenceException)
            {
                MessageBox.Show("No hay ninguna especialidad seleccionada", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }


        }


        private void ltbEspecialidades_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void BtnEliminarEspecialidad_Click(object sender, EventArgs e)
        {
            string entrada = ltbEspecialidadesSeleccionadas.SelectedItem.ToString();

            if (entrada is not null)
            {
                this.listaEspecialidadesAuxiliar.Remove(entrada);
                this.ltbEspecialidadesSeleccionadas.DataSource = null;
                this.ltbEspecialidadesSeleccionadas.DataSource = listaEspecialidadesAuxiliar;
            }
        }
    }
}

