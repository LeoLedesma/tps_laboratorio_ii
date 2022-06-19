using Entidades.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using static Entidades.CentroMedico;
using static Entidades.Persona;

namespace Entidades
{
    public class GestorSQL
    {
        private static string cadenaConexion;
        public static string querys;

        static GestorSQL()
        {
            GestorSQL.cadenaConexion = "Server=LEONEL-NOTEBOOK;Database=LedesmaLeonel2ETP4;Trusted_Connection=True;";
        }

        //----------------------Busqueda

        /// <summary>
        /// Busca si el profesional ya contiene asociada la especialidad
        /// </summary>
        /// <param name="idProfesional"></param>
        /// <param name="especialidad"></param>
        /// <returns>true si la tiene, false si no la tiene </returns>
        public static bool BuscarEspecialidadProfesional(int idProfesional, string especialidad)
        {
            string query = "SELECT * FROM especialidadesProfesionales WHERE idProfesional = @idProfesional and idEspecialidadesCentro = @idEspecialidad";

            using (SqlConnection connection = new SqlConnection(GestorSQL.cadenaConexion))
            {
                SqlCommand cmd = new SqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@idProfesional", idProfesional);
                cmd.Parameters.AddWithValue("@idEspecialidad", BuscarIdEspecialidad(especialidad));
                connection.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                int i = 0;

                while (reader.Read())
                {
                    i++;
                }

                if (i == 0)
                    return false;

                else
                    return true;
            }

        }

        /// <summary>
        /// B
        /// </summary>
        /// <param name="idTurno"></param>
        /// <returns></returns>
        public static int BuscarIdTurno(Turno turno)
        {
            string query = "SELECT id FROM turnos WHERE idProfesional = @idProfesional and idPaciente = @idPaciente and fecha = @fecha and idEspecialidad = @idEspecialidad";

            using (SqlConnection connection = new SqlConnection(GestorSQL.cadenaConexion))
            {
                SqlCommand cmd = new SqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@idProfesional", BuscarIdProfesional(turno.Profesional.Documento));
                cmd.Parameters.AddWithValue("@idPaciente", BuscarIdPaciente(turno.Paciente.Documento));
                cmd.Parameters.AddWithValue("@fecha", turno.Fecha);
                cmd.Parameters.AddWithValue("@idEspecialidad", BuscarIdEspecialidad(turno.Especialidad));
                connection.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                Paciente paciente = null;
                int i = 0;

                while (reader.Read())
                {
                    return reader.GetInt32(0);
                }

                return -1;
            }
        }

        public static int BuscarIdProfesional(string documento)
        {

            string query = "SELECT id FROM profesionales WHERE documento = @documento";

            using (SqlConnection connection = new SqlConnection(GestorSQL.cadenaConexion))
            {
                SqlCommand cmd = new SqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@documento", documento);
                connection.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                Paciente paciente = null;


                while (reader.Read())
                {
                    return reader.GetInt32(0);
                }

                return -1;
            }
        }

        public static int BuscarIdPaciente(string documento)
        {

            string query = "SELECT id FROM pacientes WHERE documento = @documento";

            using (SqlConnection connection = new SqlConnection(GestorSQL.cadenaConexion))
            {
                SqlCommand cmd = new SqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@documento", documento);
                connection.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                Paciente paciente = null;

                while (reader.Read())
                {
                    return reader.GetInt32(0);
                }

                return -1;
            }
        }


        public static int BuscarIdDiasDeAtencion(string documento)
        {
            string query = "SELECT id FROM diasDeAtencion WHERE documentoProfesional = @documento";

            using (SqlConnection connection = new SqlConnection(GestorSQL.cadenaConexion))
            {
                SqlCommand cmd = new SqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@documento", documento);
                connection.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                reader.Read();
                return reader.GetInt32(0);
            }
        }

        public static int BuscarIdEspecialidad(string especialidad)
        {
            string query = "SELECT ID FROM especialidadesCentro WHERE nombre = @especialidad";

            using (SqlConnection connection = new SqlConnection(GestorSQL.cadenaConexion))
            {
                SqlCommand cmd = new SqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@especialidad", especialidad);
                connection.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    return reader.GetInt32(0);
                }

                return -1;
            }
        }

        public static int BuscarIdEspecialidadProfesional(int idProfesional, string especialidad)
        {
            string query = "SELECT id FROM especialidadesProfesionales WHERE idProfesional = @idProfesional and idEspecialidadesCentro = @idEspecialidad";

            using (SqlConnection connection = new SqlConnection(GestorSQL.cadenaConexion))
            {
                SqlCommand cmd = new SqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@idEspecialidad", BuscarIdEspecialidad(especialidad));
                cmd.Parameters.AddWithValue("@idProfesional", idProfesional);
                connection.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    return reader.GetInt32(0);
                }

                return -1;

            }
        }

        /// <summary>
        /// Busca si el paciente existe en la base de datos
        /// </summary>
        /// <param name="documento"></param>
        /// <returns>0 si no existe, 1 si ya existe</returns>
        public static bool BuscarPaciente(string documento)
        {
            string query = "SELECT id FROM pacientes WHERE documento = @documento";

            using (SqlConnection connection = new SqlConnection(GestorSQL.cadenaConexion))
            {
                SqlCommand cmd = new SqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@documento", documento);
                connection.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                Paciente paciente = null;
                int i = 0;
                while (reader.Read())
                {
                    i++;
                }

                if (i == 0)
                    return false;

                else
                    return true;
            }
        }

        public static bool BuscarProfesional(string documento)
        {
            string query = "SELECT id FROM profesionales WHERE documento = @documento";

            using (SqlConnection connection = new SqlConnection(GestorSQL.cadenaConexion))
            {
                SqlCommand cmd = new SqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@documento", documento);
                connection.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                Paciente paciente = null;
                int i = 0;

                while (reader.Read())
                {
                    i++;
                }

                if (i == 0)
                    return false;

                else
                    return true;
            }
        }

        public static bool BuscarCentroMedico()
        {
            string query = "SELECT * FROM centroMedico";

            using (SqlConnection connection = new SqlConnection(GestorSQL.cadenaConexion))
            {
                SqlCommand cmd = new SqlCommand(query, connection);
                connection.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                Paciente paciente = null;
                int i = 0;

                while (reader.Read())
                {
                    i++;
                }

                if (i == 0)
                    return false;

                else
                    return true;
            }

        }


        //-----------------------Guardar----------------------------

        public static string GuardarCentroMedico(CentroMedico centroMedico)
        {
            string query;
            if (BuscarCentroMedico())
            {
                query = "UPDATE centroMedico set nombre = @nombre, duracionTurno = @duracionTurno, idDiasDeAtencion=@idDiasDeAtencion WHERE id = @id";
            }else
            {
                query = "INSERT INTO centroMedico (nombre, duracionTurno, idDiasDeAtencion) VALUES (@nombre, @duracionTurno, @idDiasDeAtencion)";
            }

            int pacientes;
            int profesionales;
            int turnos;
            using (SqlConnection connection = new SqlConnection(GestorSQL.cadenaConexion))
            {
                SqlCommand cmd = new SqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@id", 1);
                cmd.Parameters.AddWithValue("@nombre", centroMedico.Nombre);
                cmd.Parameters.AddWithValue("@duracionTurno", (int)centroMedico.DuracionDeTurnos);
                cmd.Parameters.AddWithValue("@idDiasDeAtencion", GestorSQL.GuardarDiasDeAtencion(centroMedico.DiasDeAtencion));
                connection.Open();
                cmd.ExecuteNonQuery();

                ActualizarEspecialidadesCentro(centroMedico.ListaEspecialidades);
                profesionales = GestorSQL.GuardarProfesionales(centroMedico.Profesionales);
                pacientes = GestorSQL.GuardarPacientes(centroMedico.Pacientes);
                turnos = GestorSQL.GuardarTurnos(centroMedico.Turnos);
            }
            return $"{profesionales} profesionales cargados, {pacientes} pacientes cargados, {turnos} cargados";

        }

        public static int GuardarTurnos(List<Turno> turnos)
        {
            int contador = 0;
            foreach (Turno turno in turnos)
            {
                if (GestorSQL.GuardarTurno(turno))
                    contador++;
            }

            return contador;

        }

        public static bool GuardarTurno(Turno turno)
        {
            string query = "INSERT INTO turnos (idPaciente, idProfesional, idEspecialidad, fecha, pacienteAsistio) VALUES (@idPaciente, @idProfesional, @idEspecialidad, @fecha, @pacienteAsistio)";

            if (BuscarIdTurno(turno) == -1)
            {
                using (SqlConnection connection = new SqlConnection(GestorSQL.cadenaConexion))
                {
                    SqlCommand cmd = new SqlCommand(query, connection);
                    cmd.Parameters.AddWithValue("@idPaciente", BuscarIdPaciente(turno.Paciente.Documento));
                    cmd.Parameters.AddWithValue("@idProfesional", BuscarIdProfesional(turno.Profesional.Documento));
                    int id = GestorSQL.BuscarIdEspecialidad(turno.Especialidad);
                    cmd.Parameters.AddWithValue("@idEspecialidad", BuscarIdEspecialidad(turno.Especialidad));
                    cmd.Parameters.AddWithValue("@fecha", turno.Fecha);
                    cmd.Parameters.AddWithValue("@pacienteAsistio", turno.PacienteAsistio);

                    connection.Open();
                    cmd.ExecuteNonQuery();
                    return true;
                }
            }

            return false;

        }

        public static void GuardarEspecialidadesCentro(List<string> especialidades)
        {
            foreach (string especialidad in especialidades)
            {
                if (GestorSQL.BuscarIdEspecialidad(especialidad) == -1)
                {
                    string query = "INSERT INTO especialidadesCentro (nombre, isActive) VALUES (@nombre, @isActive)";

                    using (SqlConnection connection = new SqlConnection(GestorSQL.cadenaConexion))
                    {
                        SqlCommand cmd = new SqlCommand(query, connection);
                        cmd.Parameters.AddWithValue("@nombre", especialidad);
                        cmd.Parameters.AddWithValue("@isActive", 1);
                        connection.Open();
                        cmd.ExecuteNonQuery();
                    }
                }

            }
        }

        public static void GuardarEspecialidadesProfesional(int idProfesional, List<string> especialidades)
        {
            foreach (string especialidad in especialidades)
            {
                if (!GestorSQL.BuscarEspecialidadProfesional(idProfesional, especialidad))
                {
                    string query = "INSERT INTO especialidadesProfesionales (idProfesional, idEspecialidadesCentro, isActive) VALUES (@idProfesional, @idEspecialidad, @isActive)";

                    using (SqlConnection connection = new SqlConnection(GestorSQL.cadenaConexion))
                    {
                        SqlCommand cmd = new SqlCommand(query, connection);
                        cmd.Parameters.AddWithValue("@idProfesional", idProfesional);
                        cmd.Parameters.AddWithValue("@idEspecialidad", GestorSQL.BuscarIdEspecialidad(especialidad));
                        cmd.Parameters.AddWithValue("@isActive", 1);
                        connection.Open();
                        cmd.ExecuteNonQuery();
                    }
                }
            }
        }

        public static int GuardarHorariosAtencion(HorarioDeAtencion horario)
        {
            string query = "INSERT INTO horarioDeAtencion (atiende, esPorDefecto, desde, hasta) " +
                "VALUES (@atiende, @esPorDefecto, @desde, @hasta)";
            using (SqlConnection connection = new SqlConnection(GestorSQL.cadenaConexion))
            {
                SqlCommand cmd = new SqlCommand(query, connection);

                int atiende = horario.Atiende ? 1 : 0;
                int esPorDefecto = horario.EsPorDefecto ? 1 : 0;
                cmd.Parameters.AddWithValue("@atiende", atiende);
                cmd.Parameters.AddWithValue("@esPorDefecto", esPorDefecto);
                cmd.Parameters.AddWithValue("@desde", horario.Desde);
                cmd.Parameters.AddWithValue("@hasta", horario.Hasta);
                connection.Open();
                cmd.ExecuteNonQuery();

                cmd.CommandText = "SELECT MAX(id) FROM horarioDeAtencion";
                return (int)cmd.ExecuteScalar();
            }
        }

        /// <summary>
        /// Guarda los datos del centro medico en la base de datos.
        /// </summary>
        /// <param name="diasAtencion"></param>
        /// <returns></returns>
        public static int GuardarDiasDeAtencion(DiasDeAtencion diasAtencion)
        {
            string query = "INSERT INTO diasDeAtencion(idLunes, idMartes, idMiercoles, idJueves, idViernes, idSabado, idDomingo) " +
                "VALUES (@lunes, @martes, @miercoles, @jueves, @viernes, @sabado, @domingo)";
            using (SqlConnection connection = new SqlConnection(GestorSQL.cadenaConexion))
            {
                SqlCommand cmd = new SqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@lunes", GestorSQL.GuardarHorariosAtencion(diasAtencion.Lunes));
                cmd.Parameters.AddWithValue("@martes", GestorSQL.GuardarHorariosAtencion(diasAtencion.Martes));
                cmd.Parameters.AddWithValue("@miercoles", GestorSQL.GuardarHorariosAtencion(diasAtencion.Miercoles));
                cmd.Parameters.AddWithValue("@jueves", GestorSQL.GuardarHorariosAtencion(diasAtencion.Jueves));
                cmd.Parameters.AddWithValue("@viernes", GestorSQL.GuardarHorariosAtencion(diasAtencion.Viernes));
                cmd.Parameters.AddWithValue("@sabado", GestorSQL.GuardarHorariosAtencion(diasAtencion.Sabado));
                cmd.Parameters.AddWithValue("@domingo", GestorSQL.GuardarHorariosAtencion(diasAtencion.Domingo));

                connection.Open();
                cmd.ExecuteNonQuery();

                cmd.CommandText = "SELECT MAX(id) FROM diasDeAtencion";
                return (int)cmd.ExecuteScalar();
            }
        }

        /// <summary>
        /// Guarda los dias de atencion del profesional con su documento.
        /// </summary>
        /// <param name="diasAtencion"></param>
        /// <param name="documento"></param>
        /// <returns></returns>
        public static int GuardarDiasDeAtencion(DiasDeAtencion diasAtencion, string documento)
        {
            string query = "INSERT INTO diasDeAtencion(idLunes, idMartes, idMiercoles, idJueves, idViernes, idSabado, idDomingo) " +
               "VALUES (@lunes, @martes, @miercoles, @jueves, @viernes, @sabado, @domingo)";
            using (SqlConnection connection = new SqlConnection(GestorSQL.cadenaConexion))
            {
                SqlCommand cmd = new SqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@lunes", GestorSQL.GuardarHorariosAtencion(diasAtencion.Lunes));
                cmd.Parameters.AddWithValue("@martes", GestorSQL.GuardarHorariosAtencion(diasAtencion.Martes));
                cmd.Parameters.AddWithValue("@miercoles", GestorSQL.GuardarHorariosAtencion(diasAtencion.Miercoles));
                cmd.Parameters.AddWithValue("@jueves", GestorSQL.GuardarHorariosAtencion(diasAtencion.Jueves));
                cmd.Parameters.AddWithValue("@viernes", GestorSQL.GuardarHorariosAtencion(diasAtencion.Viernes));
                cmd.Parameters.AddWithValue("@sabado", GestorSQL.GuardarHorariosAtencion(diasAtencion.Sabado));
                cmd.Parameters.AddWithValue("@domingo", GestorSQL.GuardarHorariosAtencion(diasAtencion.Domingo));

                connection.Open();
                cmd.ExecuteNonQuery();

                cmd.CommandText = "SELECT MAX(id) FROM diasDeAtencion";
                return (int)cmd.ExecuteScalar();
            }
        }

        /// <summary>
        /// Guarda un profesional
        /// </summary>
        /// <param name="profesional"></param>
        /// <returns>true </returns>
        public static bool GuardarProfesional(Profesional profesional)
        {
            string query = "INSERT INTO profesionales (nombre, apellido, fechaNacimiento, indiceGenero, indiceNacionalidad, documento, telefono, matricula, idDiasDeAtencion, isActive) " +
                "VALUES (@nombre, @apellido, @fechaNacimiento, @genero, @nacionalidad, @documento, @telefono, @matricula, @idDiasDeAtencion, @isActive)";
            if (!BuscarProfesional(profesional.Documento))
            {
                using (SqlConnection connection = new SqlConnection(GestorSQL.cadenaConexion))
                {
                    SqlCommand cmd = new SqlCommand(query, connection);
                    cmd.Parameters.AddWithValue("@nombre", profesional.Nombre);
                    cmd.Parameters.AddWithValue("@apellido", profesional.Apellido);
                    cmd.Parameters.AddWithValue("@fechaNacimiento", profesional.FechaDeNacimiento);
                    cmd.Parameters.AddWithValue("@genero", (int)profesional.genero);
                    cmd.Parameters.AddWithValue("@nacionalidad", (int)profesional.nacionalidad);
                    cmd.Parameters.AddWithValue("@documento", profesional.Documento);
                    cmd.Parameters.AddWithValue("@telefono", profesional.Telefono);
                    cmd.Parameters.AddWithValue("@matricula", profesional.Matricula);
                    cmd.Parameters.AddWithValue("@idDiasDeAtencion", GestorSQL.GuardarDiasDeAtencion(profesional.DiasDeAtencion, profesional.Documento));
                    cmd.Parameters.AddWithValue("@isActive", 1);                    
                    connection.Open();
                    cmd.ExecuteNonQuery();
                    GestorSQL.GuardarEspecialidadesProfesional(BuscarIdProfesional(profesional.Documento), profesional.Especialidades);

                }
                return true;
            }

            return false;
        }

        public static int GuardarProfesionales(List<Profesional> profesionales)
        {
            int i = 0;
            foreach (Profesional profesional in profesionales)
            {

                if (GestorSQL.GuardarProfesional(profesional))
                {
                    i++;
                }

            }

            return i;
        }

        public static int GuardarPacientes(List<Paciente> pacientes)
        {
            int i = 0;
            foreach (Paciente paciente in pacientes)
            {
                if (!BuscarPaciente(paciente.Documento))
                {
                    GestorSQL.GuardarPaciente(paciente);
                    i++;
                }
            }

            return i;
        }

        public static bool GuardarPaciente(Paciente paciente)
        {
            string query = "INSERT INTO pacientes (nombre, apellido, fechaNacimiento, indiceGenero, indiceNacionalidad, documento, telefono, telefonoContacto, obraSocial, numeroAfiliado, isActive) " +
                "VALUES (@nombre, @apellido, @fechaNacimiento, @genero, @nacionalidad, @documento, @telefono, @telefonoContacto, @obraSocial, @numeroAfiliado, @isActive)";

            using (SqlConnection connection = new SqlConnection(GestorSQL.cadenaConexion))
            {
                SqlCommand cmd = new SqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@nombre", paciente.Nombre);
                cmd.Parameters.AddWithValue("@apellido", paciente.Apellido);
                cmd.Parameters.AddWithValue("@fechaNacimiento", paciente.FechaDeNacimiento);
                cmd.Parameters.AddWithValue("@genero", (int)paciente.genero);
                cmd.Parameters.AddWithValue("@nacionalidad", (int)paciente.nacionalidad);
                cmd.Parameters.AddWithValue("@documento", paciente.Documento);
                cmd.Parameters.AddWithValue("@telefono", paciente.Telefono);
                cmd.Parameters.AddWithValue("@telefonoContacto", paciente.TelefonoContacto);
                cmd.Parameters.AddWithValue("@obraSocial", paciente.ObraSocial);
                cmd.Parameters.AddWithValue("@numeroAfiliado", paciente.NumeroAfiliado);
                cmd.Parameters.AddWithValue("@isActive", 1);

                connection.Open();
                cmd.ExecuteNonQuery();
            }
            return true;
        }

        //-----------------------Eliminar----------------------------

        public static bool EliminarPaciente(Paciente paciente)
        {
            string query = "UPDATE pacientes set isActive = 0 WHERE id = @id";

            using (SqlConnection connection = new SqlConnection(GestorSQL.cadenaConexion))
            {
                SqlCommand cmd = new SqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@id", paciente.Id);

                connection.Open();
                cmd.ExecuteNonQuery();
                return true;
            }
        }

        public static bool EliminarEspecialidadProfesional(int idProfesional, int idEspecialidad)
        {
            string query = " UPDATE especialidadesProfesional SET isActive = 0 WHERE idProfesional = @idProfesional, idEspecialidad = @idEspecialidad";

            using (SqlConnection connection = new SqlConnection(GestorSQL.cadenaConexion))
            {
                SqlCommand cmd = new SqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@idProfesional", idProfesional);
                cmd.Parameters.AddWithValue("@idEspecialidad", idEspecialidad);

                connection.Open();
                cmd.ExecuteNonQuery();
                return true;
            }
        }

        public static bool EliminarEspecialidadCentro(int idEspecialidad)
        {
            string query = " UPDATE especialidadesProfesionales SET isActive = 0 WHERE idEspecialidadesCentro = @idEspecialidad";

            using (SqlConnection connection = new SqlConnection(GestorSQL.cadenaConexion))
            {
                SqlCommand cmd = new SqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@idEspecialidad", idEspecialidad);

                connection.Open();
                cmd.ExecuteNonQuery();
                return true;
            }

        }

        public static bool EliminarTurno(int idTurno)
        {
            string query = " UPDATE turnos SET isActive = 0 WHERE id = @id";

            using (SqlConnection connection = new SqlConnection(GestorSQL.cadenaConexion))
            {
                SqlCommand cmd = new SqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@id", idTurno);

                connection.Open();
                cmd.ExecuteNonQuery();
                return true;
            }
        }

        //-----------------------Actualizar--------------------------
        public static bool ActualizarPaciente(Paciente paciente)
        {
            string query = "UPDATE pacientes set nombre = @nombre, apellido = @apellido, fechaNacimiento = @fechaNacimiento, " +
                "indiceGenero = @genero, indiceNacionalidad = @nacionalidad, documento = @documento, telefono = @telefono, " +
                "telefonoContacto = @telefonoContacto, obraSocial = @obraSocial, numeroAfiliado = @numeroAfiliado WHERE id = @id";

            using (SqlConnection connection = new SqlConnection(GestorSQL.cadenaConexion))
            {
                SqlCommand cmd = new SqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@id", paciente.Id);
                cmd.Parameters.AddWithValue("@nombre", paciente.Nombre);
                cmd.Parameters.AddWithValue("@apellido", paciente.Apellido);
                cmd.Parameters.AddWithValue("@fechaNacimiento", paciente.FechaDeNacimiento);
                cmd.Parameters.AddWithValue("@genero", (int)paciente.genero);
                cmd.Parameters.AddWithValue("@nacionalidad", (int)paciente.nacionalidad);
                cmd.Parameters.AddWithValue("@documento", paciente.Documento);
                cmd.Parameters.AddWithValue("@telefono", paciente.Telefono);
                cmd.Parameters.AddWithValue("@telefonoContacto", paciente.TelefonoContacto);
                cmd.Parameters.AddWithValue("@obraSocial", paciente.ObraSocial);
                cmd.Parameters.AddWithValue("@numeroAfiliado", paciente.NumeroAfiliado);

                connection.Open();
                if (cmd.ExecuteNonQuery() == 1)
                    return true;
                else
                    return false;
            }
        }

        public static void ActualizarDiasDeAtencion(DiasDeAtencion diasDeAtencion, string documento)
        {
            string query = "SELECT idLunes, idMartes, idMiercoles, idJueves, idViernes, idSabado, idDomingo FROM diasDeAtencion WHERE id = @id";
            int idDiasDeAtencion = BuscarIdDiasDeAtencion(documento);

            using (SqlConnection connection = new SqlConnection(GestorSQL.cadenaConexion))
            {
                SqlCommand cmd = new SqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@id", idDiasDeAtencion);
                connection.Open();

                List<int> idsHorarioDeAtencion = new List<int>();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    idsHorarioDeAtencion.Add(reader.GetInt32(0));
                }

                int indice = 0;
                foreach (int idHorarioDeAtencion in idsHorarioDeAtencion)
                {
                    GestorSQL.ActualizarHorarioDeAtencion(idHorarioDeAtencion, diasDeAtencion[indice]);
                    indice++;
                }



            }
        }

        public static void ActualizarHorarioDeAtencion(int id, HorarioDeAtencion horarioDeAtencion)
        {
            string query = "UPDATE horarioDeAtencion SET atiende = @atiende, esPorDefecto = @esPorDefecto, desde = @desde, hasta = @hasta WHERE id = @id";

            using (SqlConnection connection = new SqlConnection(GestorSQL.cadenaConexion))
            {
                SqlCommand cmd = new SqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@atiende", horarioDeAtencion.Atiende);
                cmd.Parameters.AddWithValue("@esPorDefecto", horarioDeAtencion.EsPorDefecto);
                cmd.Parameters.AddWithValue("@desde", horarioDeAtencion.Desde);
                cmd.Parameters.AddWithValue("@hasta", horarioDeAtencion.Hasta);

                connection.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public static bool ActualizarProfesional(Profesional profesional)
        {
            string query = "UPDATE profesionales set nombre = @nombre, apellido = @apellido, fechaNacimiento = @fechaNacimiento, " +
                "indiceGenero = @genero, indiceNacionalidad = @nacionalidad, documento = @documento, telefono = @telefono, " +
                "matricula = @matricula, idDiasDeAtencion = @idDiasDeAtencion WHERE documento = @documento";

            using (SqlConnection connection = new SqlConnection(GestorSQL.cadenaConexion))
            {
                SqlCommand cmd = new SqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@nombre", profesional.Nombre);
                cmd.Parameters.AddWithValue("@apellido", profesional.Apellido);
                cmd.Parameters.AddWithValue("@fechaNacimiento", profesional.FechaDeNacimiento);
                cmd.Parameters.AddWithValue("@genero", (int)profesional.genero);
                cmd.Parameters.AddWithValue("@nacionalidad", (int)profesional.nacionalidad);
                cmd.Parameters.AddWithValue("@documento", profesional.Documento);
                cmd.Parameters.AddWithValue("@telefono", profesional.Telefono);
                cmd.Parameters.AddWithValue("@matricula", profesional.Matricula);
                cmd.Parameters.AddWithValue("@idDiasDeAtencion", BuscarIdDiasDeAtencion(profesional.Documento));
                GestorSQL.ActualizarEspecialidadesProfesional(profesional.Especialidades, profesional.Id);
            }

            return true;
        }

        public static void ActualizarEspecialidadesProfesional(List<string> especialidades, int idProfesional)
        {

            List<string> especialidadesExistentes = RecuperarEspecialidadesProfesional(idProfesional);

            GestorSQL.GuardarEspecialidadesProfesional(idProfesional, especialidades.Except(especialidadesExistentes).ToList());

            foreach (string especialidad in especialidadesExistentes.Except(especialidades).ToList())
            {
                GestorSQL.EliminarEspecialidadProfesional(idProfesional, BuscarIdEspecialidadProfesional(idProfesional, especialidad));
            }

        }

        public static void ActualizarEspecialidadesCentro(List<string> especialidades)
        {
            List<string> especialidadesExistentes = RecuperarEspecialidadesCentro();

            GestorSQL.GuardarEspecialidadesCentro(especialidades.Except(especialidadesExistentes).ToList());

            foreach (string especialidad in especialidadesExistentes.Except(especialidades).ToList())
            {
                GestorSQL.EliminarEspecialidadCentro(BuscarIdEspecialidad(especialidad));
            }

        }

        public static bool ActualizarPersona(Persona persona)
        {
            if (persona is Paciente)
            {
                return GestorSQL.ActualizarPaciente((Paciente)persona);
            }
            else if (persona is Profesional)
            {
                return GestorSQL.ActualizarProfesional((Profesional)persona);
            }

            return false;
        }

        //-----------------------Carga--------------------------

        public static Paciente RecuperarPaciente(int id)
        {
            string query = "SELECT * FROM pacientes where id = @id";
            using (SqlConnection connection = new SqlConnection(GestorSQL.cadenaConexion))
            {
                SqlCommand cmd = new SqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@id", id);
                connection.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    id = reader.GetInt32(0);
                    string nombre = reader.GetString(1);
                    string apellido = reader.GetString(2);
                    DateTime fechaNacimiento = reader.GetDateTime(3);
                    eGenero genero = (eGenero)reader.GetInt32(4);
                    eNacionalidad nacionalidad = (eNacionalidad)reader.GetInt32(5);
                    string documento = reader.GetString(6);
                    string telefono = reader.GetString(7);
                    string telefonoContacto = reader.GetString(8);
                    string obraSocial = reader.GetString(9);
                    string numeroAfiliado = reader.GetString(10);

                    return new Paciente(id, nombre, apellido, fechaNacimiento, genero, nacionalidad, documento, telefono, telefonoContacto, obraSocial, numeroAfiliado);

                }

                return null;
            }
        }

        public static List<Paciente> RecuperarPacientes()
        {
            List<Paciente> pacientes = new List<Paciente>();

            string query = "SELECT * FROM pacientes where isActive = 1";
            using (SqlConnection connection = new SqlConnection(GestorSQL.cadenaConexion))
            {
                SqlCommand cmd = new SqlCommand(query, connection);
                connection.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    pacientes.Add(RecuperarPaciente(reader.GetInt32(0)));
                }

                return pacientes;
            }
        }

        public static DiasDeAtencion RecuperarDiasDeAtencion(int id)
        {
            string query = "SELECT * FROM diasDeAtencion where id = @id";

            using (SqlConnection connection = new SqlConnection(GestorSQL.cadenaConexion))
            {
                SqlCommand cmd = new SqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@id", id);
                connection.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {

                    HorarioDeAtencion lunes = RecuperarHorarioDeAtencion(reader.GetInt32(1));
                    HorarioDeAtencion martes = RecuperarHorarioDeAtencion(reader.GetInt32(2));
                    HorarioDeAtencion miercoles = RecuperarHorarioDeAtencion(reader.GetInt32(3));
                    HorarioDeAtencion jueves = RecuperarHorarioDeAtencion(reader.GetInt32(4));
                    HorarioDeAtencion viernes = RecuperarHorarioDeAtencion(reader.GetInt32(5));
                    HorarioDeAtencion sabado = RecuperarHorarioDeAtencion(reader.GetInt32(6));
                    HorarioDeAtencion domingo = RecuperarHorarioDeAtencion(reader.GetInt32(7));

                    DiasDeAtencion diasDeAtencion = new DiasDeAtencion();
                    diasDeAtencion.Lunes = lunes;
                    diasDeAtencion.Martes = martes;
                    diasDeAtencion.Miercoles = miercoles;
                    diasDeAtencion.Jueves = jueves;
                    diasDeAtencion.Viernes = viernes;
                    diasDeAtencion.Sabado = sabado;
                    diasDeAtencion.Domingo = domingo;

                    return diasDeAtencion;
                }

                return null;

            }
        }

        public static HorarioDeAtencion RecuperarHorarioDeAtencion(int id)
        {
            string query = "SELECT * FROM horarioDeAtencion where id = @id";

            using (SqlConnection connection = new SqlConnection(GestorSQL.cadenaConexion))
            {
                SqlCommand cmd = new SqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@id", id);
                connection.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    bool atiende = reader.GetBoolean(1);
                    bool esPorDefecto = reader.GetBoolean(2);
                    string desde = reader.GetString(3);
                    string hasta = reader.GetString(4);

                    return new HorarioDeAtencion(atiende, desde, hasta, esPorDefecto);
                }

                return null;
            }
        }

        public static Profesional RecuperarProfesional(int id)
        {
            string query = "SELECT * FROM profesionales where id = @id";
            using (SqlConnection connection = new SqlConnection(GestorSQL.cadenaConexion))
            {
                SqlCommand cmd = new SqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@id", id);
                connection.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    id = reader.GetInt32(0);
                    string nombre = reader.GetString(1);
                    string apellido = reader.GetString(2);
                    DateTime fechaNacimiento = reader.GetDateTime(3);
                    eGenero genero = (eGenero)reader.GetInt32(4);
                    eNacionalidad nacionalidad = (eNacionalidad)reader.GetInt32(5);
                    string documento = reader.GetString(6);
                    string telefono = reader.GetString(7);
                    string matricula = reader.GetString(8);
                    List<string> especialidades = GestorSQL.RecuperarEspecialidadesProfesional(id);
                    DiasDeAtencion diasDeAtencion = GestorSQL.RecuperarDiasDeAtencion(reader.GetInt32(9));

                    return new Profesional(id, nombre, apellido, fechaNacimiento, genero, nacionalidad, documento, telefono, matricula, especialidades);
                }

                return null;
            }
        }

        public static List<Profesional> RecuperarProfesionales()
        {
            List<Profesional> pacientes = new List<Profesional>();

            string query = "SELECT * FROM profesionales where isActive = 1";
            using (SqlConnection connection = new SqlConnection(GestorSQL.cadenaConexion))
            {
                SqlCommand cmd = new SqlCommand(query, connection);
                connection.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    int id = reader.GetInt32(0);
                    string nombre = reader.GetString(1);
                    string apellido = reader.GetString(2);
                    DateTime fechaNacimiento = reader.GetDateTime(3);
                    eGenero genero = (eGenero)reader.GetInt32(4);
                    eNacionalidad nacionalidad = (eNacionalidad)reader.GetInt32(5);
                    string documento = reader.GetString(6);
                    string telefono = reader.GetString(7);
                    string matricula = reader.GetString(8);
                    List<string> especialidades = GestorSQL.RecuperarEspecialidadesProfesional(id);

                    pacientes.Add(new Profesional(id, nombre, apellido, fechaNacimiento, genero, nacionalidad, documento, telefono, matricula, especialidades));

                }

                return pacientes;
            }
        }

        public static List<string> RecuperarEspecialidadesProfesional(int idProfesional)
        {
            List<string> especialidades = new List<string>();

            string query = "SELECT * FROM especialidadesProfesionales where idProfesional = @idProfesional and isActive = @isActive";
            using (SqlConnection connection = new SqlConnection(GestorSQL.cadenaConexion))
            {
                SqlCommand cmd = new SqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@idProfesional", idProfesional);
                cmd.Parameters.AddWithValue("@isActive", 1);
                connection.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    especialidades.Add(RecuperarEspecialidad(reader.GetInt32(0)));
                }

                return especialidades;
            }
        }

        public static List<string> RecuperarEspecialidadesCentro()
        {
            string query = "SELECT * FROM especialidadesCentro WHERE isActive = 1";
            List<string> especialidades = new List<string>();
            using (SqlConnection connection = new SqlConnection(GestorSQL.cadenaConexion))
            {
                SqlCommand cmd = new SqlCommand(query, connection);
                connection.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                int i = 0;

                while (reader.Read())
                {
                    especialidades.Add(reader.GetString(1));
                }

                return especialidades;
            }

        }

        public static string RecuperarEspecialidad(int id)
        {

            string query = "SELECT * FROM especialidadesCentro where id = @id and isActive = 1";
            using (SqlConnection connection = new SqlConnection(GestorSQL.cadenaConexion))
            {
                SqlCommand cmd = new SqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@id", id);
                connection.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    return reader.GetString(1);
                }
                return "";
            }
        }

        public static List<Turno> RecuperarTurnos()
        {
            string query = "SELECT * FROM TURNOS";
            List<Turno> turnos = new List<Turno>();
            using (SqlConnection connection = new SqlConnection(GestorSQL.cadenaConexion))
            {
                SqlCommand cmd = new SqlCommand(query, connection);
                connection.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    int id = reader.GetInt32(0);
                    DateTime fecha = reader.GetDateTime(1);
                    Paciente paciente = RecuperarPaciente(reader.GetInt32(2));
                    Profesional profesional = RecuperarProfesional(reader.GetInt32(3));
                    string especialidad = RecuperarEspecialidad(reader.GetInt32(4));
                    bool pacienteAsistio = reader.GetBoolean(5);

                    turnos.Add(new Turno(id, fecha, paciente, profesional, especialidad, pacienteAsistio));
                }
                return turnos;
            }


        }

        public static void RecuperarCentroMedico(CentroMedico centro)
        {

            centro.AgregarPersonas(RecuperarProfesionales());
            centro.AgregarPersonas(RecuperarPacientes());
            centro.ListaEspecialidades.AddRange(RecuperarEspecialidadesCentro());
            centro.Turnos.AddRange(RecuperarTurnos());

            string query = "SELECT * FROM centroMedico";

            using (SqlConnection connection = new SqlConnection(GestorSQL.cadenaConexion))
            {
                SqlCommand cmd = new SqlCommand(query, connection);
                connection.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    centro.Nombre = reader.GetString(1);
                    centro.DuracionDeTurnos = (EDuracionTurno)reader.GetInt32(2);
                    centro.DiasDeAtencion = RecuperarDiasDeAtencion(reader.GetInt32(3));
                }
            }

        }
    }
}