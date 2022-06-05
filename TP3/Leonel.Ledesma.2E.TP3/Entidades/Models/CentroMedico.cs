using Entidades.Exceptions;
using Entidades.Interfaces;
using Entidades.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Entidades
{
    public sealed class CentroMedico : ISerializable, IDeserializable<CentroMedico>
    {

        public enum EDuracionTurno
        {
            Corto = 10,
            Mediano = 15,
            Largo = 30
        }

        private static CentroMedico instancia;
        private string nombre;

        private List<Paciente> pacientes;
        private List<Profesional> profesionales;
        private List<Turno> turnos;
        private List<string> listaEspecialidades;
        private DiasDeAtencion diasDeAtencion;
        private EDuracionTurno duracionDeTurnos;

        private CentroMedico(string nombre)
        {
            this.nombre = nombre;
            this.Pacientes = new List<Paciente>();
            this.Profesionales = new List<Profesional>();
            this.Turnos = new List<Turno>();
            this.listaEspecialidades = new List<string>();
            this.diasDeAtencion = new DiasDeAtencion();
            this.duracionDeTurnos = EDuracionTurno.Largo;
        }

        public static CentroMedico Instanciar(string nombre)
        {
            if (CentroMedico.Instancia is null)
            {
                CentroMedico.Instancia = new CentroMedico(nombre);
            }
            return CentroMedico.Instancia;
        }


        #region propiedades

        public string Nombre { get => nombre; set => nombre = value; }
        public List<Paciente> Pacientes { get => pacientes; set => pacientes = value; }
        public List<Profesional> Profesionales { get => profesionales; set => profesionales = value; }
        public List<string> ListaEspecialidades { get => listaEspecialidades; set => listaEspecialidades = value; }
        public List<Turno> Turnos { get => this.turnos; set => this.turnos = value; }
        public static CentroMedico Instancia { get => instancia; set => instancia = value; }
        public DiasDeAtencion DiasDeAtencion { get => this.diasDeAtencion; set => this.diasDeAtencion = value; }
        public EDuracionTurno DuracionDeTurnos { get => duracionDeTurnos; set => duracionDeTurnos = value; }

        public int ProximoId
        {
            get
            {
                int id = 0;

                try
                {
                    foreach (Turno turno in turnos)
                    {
                        if (id < turno.Id)
                        {
                            id = turno.Id;
                        }
                    }
                }
                catch
                {
                    throw new Exception("No se pudo obtener el proximo id");
                }

                return id + 1;
            }
        }


        #endregion

        #region Manejo listas
        /// <summary>
        /// Agrega un turno a la lista de turnos.
        /// </summary>
        /// <param name="turno"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="TurnoYaExisteException"></exception>
        public bool AgregarTurno(Turno turno) //Hecho - 1
        {

            if (turno is null)
            {
                throw new ArgumentNullException("Ocurrio un error al agregar el turno");
            }
            if (this.Turnos.Contains(turno))
            {
                throw new TurnoYaExisteException("El turno ya existe");
            }

            this.Turnos.Add(turno);

            return true;
        }

        /// <summary>
        /// Elimina un turno por su id de la lista de turnos.
        /// </summary>
        /// <param name="idTurno"></param>
        /// <returns></returns>
        /// <exception cref="TurnoNoExisteException"></exception>
        /// <exception cref="Exception"></exception>
        public bool EliminarTurno(int idTurno) //Hecho - 1
        {
            try
            {
                Turno turno = this.BuscarTurno(idTurno);
                this.Turnos.Remove(turno);
                return true;
            }
            catch (TurnoNoExisteException ex)
            {
                throw ex;
            }
            catch (Exception)
            {
                throw new Exception("Ocurrio un error al eliminar el turno");
            }
        }


        /// <summary>
        /// Busca todos los turnos de hoy y los futuros.
        /// </summary>
        /// <param name="busqueda"></param>
        /// <param name="nombreAtributo"></param>
        /// <returns></returns>
        /// <exception cref="BusquedaException"></exception>
        public List<Turno> BuscarTurnosFuturos(string busqueda, string nombreAtributo) //Hecho - 1
        {
            try
            {
                List<Turno> turnosA = this.BuscarTurnos(busqueda, nombreAtributo);
                List<Turno> turnos = new List<Turno>();

                foreach (Turno turno in turnosA)
                {
                    if (turno.Fecha > DateTime.Today)
                    {
                        turnos.Add(turno);
                    }
                }

            }
            catch (Exception ex)
            {
                throw new BusquedaException(ex.Message);
            }

            return turnos;
        }

        /// <summary>
        /// Busca los turnos que sean anteriores al dia de hoy.
        /// </summary>
        /// <param name="busqueda"></param>
        /// <param name="nombreAtributo"></param>
        /// <returns></returns>
        /// <exception cref="BusquedaException"></exception>
        public List<Turno> BuscarTurnosPasados(string busqueda, string nombreAtributo) //Hecho - 1
        {
            try
            {

                List<Turno> turnosA = this.BuscarTurnos(busqueda, nombreAtributo);
                List<Turno> turnos = new List<Turno>();

                foreach (Turno turno in turnosA)
                {
                    if (turno.Fecha < DateTime.Today)
                    {
                        turnos.Add(turno);
                    }
                }
            }
            catch (Exception ex)
            {
                throw new BusquedaException(ex.Message);
            }

            return turnos;
        }

        /// <summary>
        /// Busca turnos segun buscar por y busqueda.
        /// </summary>
        /// <param name="busqueda"></param>
        /// <param name="nombreAtributo"></param>
        /// <returns></returns>
        /// <exception cref="BusquedaException"></exception>
        public List<Turno> BuscarTurnos(string busqueda, string buscarPor) //Hecho - 3
        {
            List<Turno> coincidencias = new List<Turno>();
            buscarPor = buscarPor.ToLower();

            try
            {
                switch (buscarPor)
                {
                    case "id turno":
                        foreach (Turno turno in this.Turnos)
                        {
                            if (turno.Id.ToString() == busqueda)
                                coincidencias.Add(turno);
                        }
                        break;
                    case "documento paciente":
                        foreach (Turno turno in this.Turnos)
                        {
                            if (turno.Paciente.Documento.Contains(busqueda))
                                coincidencias.Add(turno);
                        }
                        break;
                    case "apellido profesional":
                        {
                            foreach (Turno turno in this.Turnos)
                            {
                                if (turno.Profesional.Apellido.Contains(busqueda))
                                    coincidencias.Add(turno);
                            }
                        }
                        break;
                }

            }
            catch (Exception)
            {
                throw new BusquedaException("Ocurrio un error al buscar los turnos.");
            }


            return coincidencias;
        }

        /// <summary>
        /// Busca un turno por Id.
        /// </summary>
        /// <param name="idTurno"></param>
        /// <returns></returns>
        /// <exception cref="TurnoNoExisteException"></exception>
        public Turno BuscarTurno(int idTurno) // Hecho - 3
        {
            try
            {
                foreach (Turno turno in this.Turnos)
                {
                    if (turno.Id == idTurno)
                    {
                        return turno;
                    }
                }
            }
            catch (Exception)
            {
                throw new TurnoNoExisteException("El turno no existe");
            }


            return null;
        }

        /// <summary>
        /// Busca todos los turnos del profesional
        /// </summary>
        /// <param name="profesional"></param>
        /// <returns></returns>
        /// <exception cref="BusquedaException"></exception>
        public List<Turno> BuscarTurnos(Profesional profesional)
        {
            try
            {
                List<Turno> turnos = new List<Turno>();

                foreach (Turno turno in this.Turnos)
                {
                    if (turno.Profesional == profesional)
                    {
                        turnos.Add(turno);
                    }
                }

                return turnos;

            }
            catch (Exception)
            {
                throw new BusquedaException("Ocurrio un error en la busqueda de los turnos.");
            }


        }

        /// <summary>
        /// Busca todos los turnos del paciente.
        /// </summary>
        /// <param name="paciente"></param>
        /// <returns></returns>
        /// <exception cref="BusquedaException"></exception>
        public List<Turno> BuscarTurnos(Paciente paciente)
        {
            try
            {
                List<Turno> turnos = new List<Turno>();

                foreach (Turno turno in this.Turnos)
                {
                    if (turno.Paciente == paciente)
                    {
                        turnos.Add(turno);
                    }
                }

                return turnos;
            }
            catch (Exception)
            {
                throw new BusquedaException("Ocurrio un erro en la busqueda de los turnos.");
            }
        }

        public List<Turno> BuscarTurnos(Profesional profesional, Paciente paciente)
        {
            try
            {
                List<Turno> coincidencias = new List<Turno>();

                foreach (Turno turno in this.Turnos)
                {
                    if(turno.Profesional == profesional && turno.Paciente == paciente)
                    {
                        coincidencias.Add(turno);
                    }
                }

                return coincidencias;
            }catch(Exception)
            {
                throw new BusquedaException("Ocurrió un error al buscar los turnos.");
            }
        }

        public List<Turno> BuscarTurnos(DateTime fecha)
        {
            try
            {
                List<Turno> coincidencias = new List<Turno>();
                foreach (Turno turno in this.Turnos)
                {
                    if (turno.Fecha.Day == fecha.Day &&
                        turno.Fecha.Month == fecha.Day &&
                        turno.Fecha.Year == fecha.Year)
                    {
                        coincidencias.Add(turno);
                    }
                }

                return coincidencias;

            }
            catch (Exception)
            {
                throw new BusquedaException("Ocurrio un error en la busqueda de los turnos");
            }
        }


        public List<Turno> BuscarTurnos(DateTime fecha, Profesional profesional)
        {
            try
            {
                List<Turno> coincidencias = new List<Turno>();
                foreach (Turno turno in this.Turnos)
                {
                    if (turno.Fecha.Day == fecha.Day &&
                        turno.Fecha.Month == fecha.Day &&
                        turno.Fecha.Year == fecha.Year &&
                        turno.Profesional == profesional)
                    {
                        coincidencias.Add(turno);
                    }
                }

                return coincidencias;

            }
            catch (Exception)
            {
                throw new BusquedaException("Ocurrio un error en la busqueda de los turnos");
            }
        }

        public List<Turno> BuscarTurnos(DateTime fecha, Profesional profesional, string documentoPaciente)
        {
            try
            {
                List<Turno> turnos = new List<Turno>();
                Paciente paciente = this.BuscarPaciente(documentoPaciente);
                foreach (Turno turno in this.Turnos)
                {
                    if (turno.Fecha.Day == fecha.Day && turno.Fecha.Month == fecha.Day && turno.Fecha.Year == fecha.Year &&
                        turno.Profesional == profesional && turno.Paciente == paciente)
                    {
                        turnos.Add(turno);
                    }
                }

                return turnos;

            }
            catch (Exception)
            {
                throw new BusquedaException("Ocurrio un error en la busqueda de los turnos");
            }
        }



        //Especialidad

        /// <summary>
        /// Agrega la especialidad siempre y cuando esta no se encuentre en la lista de forma textual.
        /// </summary>
        /// <param name="especialidad"></param>
        /// <returns>True si fue agregada, false si no</returns>
        /// <exception cref="Exception"></exception>
        public bool AgregarEspecialidad(string especialidad) //Hecho - 1
        {
            try
            {
                especialidad = especialidad.TotUpperFirstLetter();
                if (this.ListaEspecialidades.IndexOf(especialidad) != -1)
                {
                    return false;
                }
                else
                {
                    this.ListaEspecialidades.Add(especialidad);
                    return true;
                }

            }
            catch (Exception)
            {
                throw new Exception("Ocurrio un error al agregar la especialidad");
            }
        }

        //Personas

        /// <summary>
        /// Agrega un paciente a la lista de pacientes, siempre y cuando éste no se encuentre en la lista.
        /// </summary>
        /// <param name="paciente"></param>
        /// <returns>True si fue agregado, false si no</returns>
        /// <exception cref="Exception"></exception>
        public bool AgregarPersona(Persona persona) //Hecho - 3
        {
            return this + persona;
        }

        /// <summary>
        /// Elimina un paciente de la lista de pacientes, siempre y cuando este se encuentre en la lista.
        /// </summary>
        /// <param name="paciente"></param>
        /// <returns>True si fue removida, false si no.</returns>
        /// <exception cref="Exception"></exception>
        public bool RemoverPersona(Persona persona) //Hecho - 2
        {
            return this - persona;
        }

        /// <summary>
        /// Agrega lista a la lista de pacientes, validando que estos ya no esten en la lista.
        /// </summary>
        /// <param name="lista"></param>
        /// <returns>La cantidad de pacientes que fueron agregados.</returns>
        /// <exception cref="AgregarException"></exception>
        public int AgregarPersonas(List<Paciente> lista) //Hecho - 2
        {
            try
            {
                int contadorPacientesAgregados = 0;
                foreach (Paciente paciente in lista)
                {
                    if (this + paciente)
                    {
                        contadorPacientesAgregados++;
                    }
                }
                return contadorPacientesAgregados;
            }
            catch (Exception ex)
            {
                throw new AgregarException(ex.Message);
            }
        }

        /// <summary>
        /// Agrega lista a la lista de profesionales, validando que estos ya no esten en la lista.
        /// </summary>
        /// <param name="lista"></param>
        /// <returns>La cantidad de profesionales que fueron agregados. </returns>
        /// <exception cref="AgregarException"></exception>
        public int AgregarPersonas(List<Profesional> lista) //Hecho -2 
        {
            try
            {

                int contadorProfesionaeslAgregados = 0;
                foreach (Profesional profesional in lista)
                {
                    if (this + profesional)
                    {
                        contadorProfesionaeslAgregados++;
                    }
                }
                return contadorProfesionaeslAgregados;
            }
            catch (Exception ex)
            {
                throw new AgregarException(ex.Message);
            }
        }

        //Pacientes

        /// <summary>
        /// Busca un paciente en la lista de pacientes por documento, siempre y cuando éste se encuentre en la lista.
        /// </summary>
        /// <param name="documento"></param>
        /// <returns></returns>
        /// <exception cref="PersonaNoExisteException"></exception>
        /// <exception cref="BusquedaException"></exception>
        public Paciente BuscarPaciente(string documento) //Hecho - 3
        {
            try
            {
                return this.BuscarPaciente(documento, "documento")[0];
            }
            catch (PersonaNoExisteException)
            {
                throw new PersonaNoExisteException("El paciente no existe");
            }
            catch (Exception)
            {
                throw new BusquedaException("Ha ocurrido un error al buscar el paciente");
            }
        }

        /// <summary>
        /// Busca un paciente por el nombre del atributo segun busqueda.
        /// </summary>
        /// <param name="busqueda"></param>
        /// <param name="nombreAtributo"></param>
        /// <returns>La lista de pacientes que tuvieron coincidencia.</returns>
        /// <exception cref="BusquedaException"></exception>
        public List<Paciente> BuscarPaciente(string busqueda, string nombreAtributo)
        {
            List<Paciente> coincidencias = new List<Paciente>();

            try
            {
                nombreAtributo = nombreAtributo.ToLower();

                if (this.Pacientes.Count > 0)
                {

                    switch (nombreAtributo)
                    {
                        case "documento":
                            foreach (Paciente paciente in this.Pacientes)
                            {
                                if (paciente.Documento.Contains(busqueda))
                                    coincidencias.Add(paciente);
                            }
                            break;
                        case "apellido":
                            foreach (Paciente paciente in this.Pacientes)
                            {
                                if (paciente.Apellido.Contains(busqueda))
                                    coincidencias.Add(paciente);
                            }
                            break;
                        case "nombre":
                            foreach (Paciente paciente in this.Pacientes)
                            {
                                if (paciente.Nombre.Contains(busqueda))
                                    coincidencias.Add(paciente);
                            }
                            break;
                        case "telefono":
                            foreach (Paciente paciente in this.Pacientes)
                            {
                                if (paciente.Telefono.Contains(busqueda))
                                    coincidencias.Add(paciente);
                            }
                            break;
                    }
                }

            }
            catch (Exception)
            {
                throw new BusquedaException("Ocurrio un error al buscar el paciente");
            }

            return coincidencias;
        }

        //Profesionales

        public Profesional BuscarProfesional(string documento)
        {
            try
            {
                Profesional profesional = this.BuscarProfesional(documento, "documento")[0];
                return profesional;
            }
            catch (Exception)
            {
                throw new BusquedaException("Ocurrio un error al buscar el profesional");
            }
        }

        /// <summary>
        /// Busca un profesional en la lista por n° de documento
        /// </summary>
        /// <param name="documento"></param>
        /// <returns>El paciente si fue encontrado, null si no.</returns>
        public List<Profesional> BuscarProfesional(string busqueda, string nombreAtributo)
        {
            List<Profesional> coincidencias = new List<Profesional>();
            try
            {

                nombreAtributo = nombreAtributo.ToLower();

                switch (nombreAtributo)
                {
                    case "documento":
                        foreach (Profesional profesional in this.Profesionales)
                        {
                            if (profesional.Documento.Contains(busqueda))
                                coincidencias.Add(profesional);
                        }
                        break;
                    case "apellido":
                        foreach (Profesional profesional in this.Profesionales)
                        {
                            if (profesional.Apellido.Contains(busqueda))
                                coincidencias.Add(profesional);
                        }
                        break;
                    case "nombre":
                        foreach (Profesional profesional in this.Profesionales)
                        {
                            if (profesional.Nombre.Contains(busqueda))
                                coincidencias.Add(profesional);
                        }
                        break;
                    case "telefono":
                        foreach (Profesional profesional in this.Profesionales)
                        {
                            if (profesional.Telefono.Contains(busqueda))
                                coincidencias.Add(profesional);
                        }
                        break;
                    case "especialidad":
                        {
                            foreach (Profesional profesional in this.profesionales)
                            {
                                if (profesional.Especialidades.Contains(busqueda))
                                    coincidencias.Add(profesional);
                            }
                        }
                        break;
                }

                return coincidencias;
            }
            catch (Exception)
            {
                throw new BusquedaException("Ocurrio un error en la busqueda del profesional");
            }
        }


        public List<DateTime> BuscarFechasDisponibles(Profesional profesional, DateTime fechaInicio, DateTime fechaLimite)
        {
            List<DateTime> fechasQueTrabaja = new List<DateTime>();
            List<DateTime> fechasDisponibles = new List<DateTime>();

            try
            {

                if (profesional is not null)
                {
                    for (DateTime fecha = fechaInicio; fecha <= fechaLimite; fecha = fecha.AddDays(1)) //Recorro los dias desde la fecha de inicio hasta la fecha limite
                    {
                        if (this.Atienden(profesional, fecha.DayOfWeek.ToString()))
                        {
                            fechasQueTrabaja.Add(fecha);
                        }
                    }

                    foreach (DateTime dia in fechasQueTrabaja)
                    {
                        if (BuscarHorasDisponibles(profesional, dia).Count != 0)
                        {
                            fechasDisponibles.Add(dia);
                        }
                    }
                }
            }
            catch (Exception)
            {
                throw new Exception("Ocurrio un error al buscar las fechas disponibles.");
            }


            return fechasDisponibles;
        }



        public List<string> BuscarHorasDisponibles(Profesional profesional, DateTime fecha)
        {
            List<string> horariosPosibles = new List<string>();
            string dia = fecha.DayOfWeek.ToString();

            if (this.Atienden(profesional, dia))
            {
                List<Turno> turnosQueTiene = this.BuscarTurnosProfesionalDiaEspecifico(fecha, profesional.Documento);
                horariosPosibles = profesional.DiasDeAtencion[(int)fecha.DayOfWeek].HorariosPosibles(this.DuracionDeTurnos);

                foreach (Turno turno in turnosQueTiene)
                {
                    if (horariosPosibles.Contains(turno.Fecha.ToString("hh:mm")))
                    {
                        horariosPosibles.Remove(turno.Fecha.ToString("hh:mm"));
                    }
                }

            }

            return horariosPosibles;

        }

        public List<Turno> BuscarTurnosProfesionalDiaEspecifico(DateTime fecha, string documento)
        {
            List<Turno> turnos = new List<Turno>();

            foreach (Turno turno in this.Turnos)
            {
                if (turno.Fecha.Year == fecha.Year && turno.Fecha.Month == fecha.Month && turno.Fecha.Day == fecha.Day
                    && turno.Profesional.Documento.Equals(documento))
                {
                    turnos.Add(turno);
                }
            }

            return turnos;
        }

        public bool Atienden(Profesional profesional, string dia)
        {
            return profesional.DiasDeAtencion.diasQueAtiende().Contains(dia) &&
                this.DiasDeAtencion.diasQueAtiende().Contains(dia);
        }



        #endregion

        #region Serializacion

        //XML
        public void SerializarToXML(string fullPath)
        {
            StreamWriter streamWriter = null;
            try
            {
                CentroMedicoData centro = new CentroMedicoData();

                streamWriter = new StreamWriter(fullPath);

                XmlSerializer xml = new XmlSerializer(typeof(CentroMedicoData));
                xml.Serialize(streamWriter, centro);
            }
            catch (Exception e)
            {
                throw new SerializarException("Error al serializar el centro medico", e);
            }
            finally
            {
                if (streamWriter != null)
                    streamWriter.Close();
            }
        }

        /// <summary>
        /// Deserializa una lista del centro medico desde un archivo XML.
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        /// <exception cref="SerializarException"></exception>
        public CentroMedico DeserializarFromXML(string path)
        {


            StreamReader streamReader = null;
            try
            {
                streamReader = new StreamReader(path);

                XmlSerializer xml = new XmlSerializer(typeof(CentroMedicoData));
                CentroMedicoData centroMedico = xml.Deserialize(streamReader) as CentroMedicoData;
                return (CentroMedico)centroMedico;

            }
            catch (FileNotFoundException e)
            {
                throw new DeserializarException("No se ha encontrado el archivo del centro medico.", e);
            }
            catch (Exception e)
            {
                throw new DeserializarException("Error al deserializar del centro medico", e);
            }
            finally
            {
                if (streamReader != null)
                    streamReader.Close();
            }


        }

        /// <summary>
        /// Serializa una lista del centro medico a un archivo XML.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="fullPath"></param>
        /// <param name="lista"></param>
        /// <exception cref="SerializarException"></exception>
        public void SerializarListaToXML<T>(string fullPath, List<T> lista)
        {
            StreamWriter streamWriter = null;
            try
            {
                streamWriter = new StreamWriter(fullPath);

                XmlSerializer xml = new XmlSerializer(typeof(List<T>));
                xml.Serialize(streamWriter, lista);
            }
            catch (Exception e)
            {
                throw new SerializarException("Error al serializar la lista", e);
            }
            finally
            {
                if (streamWriter != null)
                    streamWriter.Close();
            }
        }

        /// <summary>
        /// Deserializa una lista del centro medico desde un archivo XML.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="fullPath"></param>
        /// <param name="listaBase"></param>
        /// <returns></returns>
        /// <exception cref="SerializarException"></exception>
        public List<T> DeserializarListaFromXML<T>(string fullPath, List<T> listaBase)
        {
            StreamReader streamReader = null;
            try
            {
                streamReader = new StreamReader(fullPath);

                XmlSerializer xml = new XmlSerializer(typeof(List<T>));
                List<T> lista = xml.Deserialize(streamReader) as List<T>;

                return lista;

            }
            catch (Exception e)
            {
                throw new SerializarException("Error al deserializar la lista.", e);
            }
            finally
            {
                if (streamReader != null)
                    streamReader.Close();
            }
        }

        //JSON

        /// <summary>
        /// Serializa el centro medico a un archivo JSON.
        /// </summary>
        /// <param name="fullPath"></param>
        /// <exception cref="SerializarException"></exception>
        public void SerializarToJSON(string fullPath)
        {
            StreamWriter streamWriter = null;
            try
            {
                streamWriter = new StreamWriter(fullPath);

                JsonSerializerOptions options = new JsonSerializerOptions();
                options.WriteIndented = true;
                string jsonString = JsonSerializer.Serialize(this, options);

                streamWriter.WriteLine(jsonString);
            }
            catch (Exception e)
            {
                throw new SerializarException("Error al serializar el centro medico.", e);
            }
            finally
            {
                if (streamWriter != null)
                    streamWriter.Close();
            }

        }

        /// <summary>
        /// Deserializa un centro medico desde un archivo JSON.
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        /// <exception cref="SerializarException"></exception>
        public CentroMedico DeserializarFromJson(string path)
        {
            StreamReader streamReader = null;
            try
            {
                streamReader = new StreamReader(path);

                JsonSerializerOptions options = new JsonSerializerOptions();
                string jsonString = streamReader.ReadToEnd();
                CentroMedicoData centroMedico = JsonSerializer.Deserialize<CentroMedicoData>(jsonString);

                return (CentroMedico)centroMedico;
            }
            catch (Exception e)
            {
                throw new DeserializarException("Error al deserializar el centro medico", e);
            }
            finally
            {
                if (streamReader != null)
                    streamReader.Close();
            }
        }

        /// <summary>
        /// Serializa una lista del centro medico a un archivo JSON.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="fullPath"></param>
        /// <param name="lista"></param>
        /// <exception cref="SerializarException"></exception>
        public void SerializarListaToJSON<T>(string fullPath, List<T> lista)
        {
            StreamWriter streamWriter = null;
            try
            {
                streamWriter = new StreamWriter(fullPath);

                JsonSerializerOptions options = new JsonSerializerOptions();
                options.WriteIndented = true;
                string jsonString = JsonSerializer.Serialize(lista, options);

                streamWriter.WriteLine(jsonString);
            }
            catch (Exception e)
            {
                throw new SerializarException("Error al serializar el centro medico.", e);
            }
            finally
            {
                if (streamWriter != null)
                    streamWriter.Close();
            }

        }

        /// <summary>
        /// Deserializa una lista del centro medico desde un archivo JSON.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="fullPath"></param>
        /// <param name="listaBase"></param>
        /// <returns></returns>
        /// <exception cref="SerializarException"></exception>
        public List<T> DeserializarListaFromJSON<T>(string fullPath, List<T> listaBase)
        {
            StreamReader streamReader = null;
            try
            {
                streamReader = new StreamReader(fullPath);

                JsonSerializerOptions options = new JsonSerializerOptions();
                string jsonString = streamReader.ReadToEnd();
                List<T> lista = JsonSerializer.Deserialize<List<T>>(jsonString);

                return lista;

            }
            catch (Exception e)
            {
                throw new SerializarException("Error al deserializar la lista.", e);
            }
            finally
            {
                if (streamReader != null)
                    streamReader.Close();
            }
        }


        #endregion


        /// <summary>
        /// Guarda la lista de pacientes a un archivo .XML o .JSON
        /// </summary>
        /// <param name="fullPath"></param>
        /// <exception cref="SerializarException"></exception>
        public void GuardarPacientes(string fullPath)
        {
            if (fullPath.Contains(".xml"))
            {
                this.SerializarListaToXML(fullPath, this.Pacientes);
            }
            else if (fullPath.Contains(".json"))
            {
                this.SerializarListaToJSON(fullPath, this.Pacientes);
            }
        }

        /// <summary>
        /// Guarda una lista de profesionales a un archivo .XML o .JSON.
        /// </summary>
        /// <param name="fullPath"></param>
        /// /// <exception cref="SerializarException"></exception>
        public void GuardarProfesionales(string fullPath)
        {
            if (fullPath.Contains(".xml"))
            {
                this.SerializarListaToXML(fullPath, this.Profesionales);
            }
            else if (fullPath.Contains(".json"))
            {
                this.SerializarListaToJSON(fullPath, this.Profesionales);
            }
        }

        public void GuardarCentroMedico(string fullPath)
        {
            if (fullPath.Contains(".json"))
            {
                this.SerializarToJSON(fullPath);
            }
            else if (fullPath.Contains(".xml"))
            {
                this.SerializarToXML(fullPath);
            }
        }

        /// <summary>
        /// Importa pacientes al centro medico desde un archivo XML o JSON.
        /// </summary>
        /// <param name="fullPath"></param>
        /// <returns>La cantidad de pacientes que fue posible agregar.</returns>
        /// <exception cref="SerializarException"></exception>
        /// <exception cref=""
        public int ImportarPacientes(string fullPath)
        {
            try
            {
                if (fullPath.Contains(".xml"))
                {
                    List<Paciente> lista = this.DeserializarListaFromXML(fullPath, this.Pacientes);
                    return this.AgregarPersonas(lista);
                }
                else if (fullPath.Contains(".json"))
                {
                    List<Paciente> lista = this.DeserializarListaFromJSON(fullPath, this.Pacientes);
                    return this.AgregarPersonas(lista);
                }
            }
            catch (SerializarException ex)
            {
                throw new SerializarException(ex.Message, ex.InnerException);
            }

            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return 0;
        }

        /// <summary>
        /// Importa profesionales al centro medico desde un archivo XML o JSON.
        /// </summary>
        /// <param name="fullPath"></param>
        /// <returns>La cantidad de profesionales que fue posible agregar.</returns>
        /// <exception cref="SerializarException"></exception>
        /// <exception cref="Exception"></exception>
        public int ImportarProfesionales(string fullPath)
        {
            try
            {
                if (fullPath.Contains(".xml"))
                {
                    List<Profesional> lista = this.DeserializarListaFromXML(fullPath, this.Profesionales);
                    return this.AgregarPersonas(lista);
                }
                else if (fullPath.Contains(".json"))
                {
                    List<Profesional> lista = this.DeserializarListaFromJSON(fullPath, this.Profesionales);
                    return this.AgregarPersonas(lista);
                }
            }
            catch (SerializarException ex)
            {
                throw new SerializarException(ex.Message);
            }
            catch (AgregarException ex)
            {
                throw new AgregarException(ex.Message);
            }

            return 0;
        }

        /// <summary>
        /// Importa una lista de personas al centro medico.
        /// </summary>
        /// <param name="fullPath"></param>
        /// /// <exception cref="SerializarException"></exception>
        public void ImportarCentroMedico(string fullPath)
        {

            if (fullPath.Contains(".xml"))
            {
                CentroMedico.Instancia = this.DeserializarFromXML(fullPath);

            }
            else if (fullPath.Contains(".json"))
            {
                CentroMedico.Instancia = this.DeserializarFromJson(fullPath);

            }

        }


        #region Operadores


        /// <summary>
        /// Busca si la persona esta ya esta en la lista de su tipo.
        /// </summary>
        /// <param name="centro">Centro medico a ser consultado</param>
        /// <param name="persona">Persona a ser buscada</param>
        /// <returns>True si ya esta en la lista, false si no lo esta.</returns>
        /// <exception cref="BusquedaException"></exception>
        public static bool operator ==(CentroMedico centro, Persona persona)
        {
            try
            {
                if (persona.GetType().Name == "Paciente")
                {
                    foreach (Paciente paciente in centro.Pacientes)
                    {
                        if (persona.Documento == paciente.Documento)
                        {
                            return true;
                        }
                    }
                }
                else
                {
                    foreach (Profesional profesional in centro.Profesionales)
                    {
                        if (persona.Documento == profesional.Documento)
                        {
                            return true;
                        }
                    }
                }
            }
            catch (Exception)
            {
                throw new BusquedaException("Ocurrio un error al buscar la persona en el centro medico.");
            }
            return false;
        }

        /// <summary>
        /// Busca si la persona esta ya esta en la lista de su tipo.
        /// </summary>
        /// <param name="centro">Centro medico a ser consultado</param>
        /// <param name="persona">Persona a ser buscada</param>
        /// <returns>False si ya esta en la lista de su tipo, True si no lo esta.</returns>
        /// <exception cref="BusquedaException"></exception>
        public static bool operator !=(CentroMedico centro, Persona persona)
        {
            return !(centro == persona);
        }


        /// <summary>
        /// Agrega un paciente a la lista de su tipo, siempre y cuando éste no se encuentre en la lista.
        /// </summary>
        /// <param name="centro"></param>
        /// <param name="paciente"></param>
        /// <returns>true si fue agregado, false si el paciente ya se encontraba en la lista</returns>
        /// <exception cref="Exception"></exception>
        public static bool operator +(CentroMedico centro, Persona persona)
        {
            try
            {
                if (persona.GetType().Name == "Paciente")
                {
                    if (centro != persona)
                    {
                        centro.Pacientes.Add((Paciente)persona);
                        return true;
                    }
                }
                else
                {
                    if (centro != persona)
                    {
                        centro.Profesionales.Add((Profesional)persona);
                        return true;
                    }
                }
            }
            catch (Exception)
            {
                throw new Exception("Ocurrio un error al agregar la persona.");
            }

            return false;
        }


        /// <summary>
        /// Elimina un paciente de la la lista de su tipo, siempre y cuando este se encuentre en la lista.
        /// </summary>
        /// <param name="centro"></param>
        /// <param name="paciente"></param>
        /// <returns>true si paciente fue removido, false si el paciente no se encontraba en la lista</returns>
        /// <exception cref="Exception"></exception>
        public static bool operator -(CentroMedico centro, Persona persona)
        {
            try
            {
                if (persona.GetType().Name == "Paciente")
                {
                    if (centro == persona)
                    {
                        return centro.Pacientes.Remove((Paciente)persona);
                    }
                }
                else
                {
                    if (centro == persona)
                    {
                        centro.Profesionales.Remove((Profesional)persona);
                        return true;
                    }
                }

                return false;

            }
            catch (Exception)
            {
                throw new Exception("Ocurrio un error al eliminar la persona.");
            }
        }

        #endregion


    }
}
