using Entidades.Exceptions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using System.Text.Json;

namespace Entidades
{   
    public class Paciente : Persona, ICloneable
    {
        private string obraSocial;
        private string numeroAfiliado;
        private string telefonoContacto;

        public Paciente(string nombre, string apellido, DateTime fechaDeNacimiento, eGenero genero,
            eNacionalidad nacionalidad, string documento, string telefono, string telefonoContacto,
            string obraSocial, string numeroAfiliado)
            : base(nombre, apellido, fechaDeNacimiento, genero, nacionalidad, documento, telefono)
        {
            this.ObraSocial = obraSocial;
            this.NumeroAfiliado = numeroAfiliado;
            this.TelefonoContacto = telefonoContacto;
        }

        public Paciente() : this("", "", DateTime.Now, eGenero.Otro, eNacionalidad.Otra, "", "", "", "", "")
        {
        }

        private Paciente ClonarPaciente()
        {
            Paciente nuevaReferencia = new Paciente();
                        
            nuevaReferencia.Nombre = this.Nombre;
            nuevaReferencia.Apellido = this.Apellido;
            nuevaReferencia.FechaDeNacimiento = this.FechaDeNacimiento;
            nuevaReferencia.genero = this.genero;
            nuevaReferencia.nacionalidad = this.nacionalidad;
            nuevaReferencia.Documento = this.Documento;
            nuevaReferencia.Telefono = this.Telefono;
            nuevaReferencia.TelefonoContacto = this.TelefonoContacto;            
            nuevaReferencia.ObraSocial = this.ObraSocial;
            nuevaReferencia.NumeroAfiliado = this.NumeroAfiliado;
            return nuevaReferencia;
        }

        public object Clone()
        {
            return this.ClonarPaciente();
        }

        /// <summary>
        /// Deserealiza un paciente desde un archivo XML.
        /// </summary>
        /// <param name="path"></param>
        /// <returns>Una nueva instancia de paciente.</returns>
        /// <exception cref="DeserializarException"></exception>
        public static Paciente DeserializarFromXML(string path)
        {

            StreamReader streamReader = null;
            try
            {
                streamReader = new StreamReader(path);
                XmlSerializer xml = new XmlSerializer(typeof(Paciente));                
                return xml.Deserialize(streamReader) as Paciente;
            }
            catch (Exception e)
            {
                throw new DeserializarException("Error al cargar el paciente", e);                
            }
            finally
            {
                if (streamReader != null)
                    streamReader.Close();
            }

        }

        /// <summary>
        /// Deserializa un paciente desde un archivo JSON
        /// </summary>
        /// <param name="path"></param>
        /// <returns>Una nueva instancia de paciente.</returns>
        /// <exception cref="DeserializarException"></exception>
        public static Paciente DeserializarFromJson(string path)
        {
            StreamReader streamReader = null;
            try
            {
                streamReader = new StreamReader(path);

                JsonSerializerOptions options = new JsonSerializerOptions();
                string jsonString = streamReader.ReadToEnd();
                
                return JsonSerializer.Deserialize<Paciente>(jsonString); ;

            }
            catch (Exception e)
            {
                throw new DeserializarException("Error al deserializar el paciente", e);
            }
            finally
            {
                if (streamReader != null)
                    streamReader.Close();
            }
        }

        public string ObraSocial { get => obraSocial; set => obraSocial = value; }
        public string NumeroAfiliado { get => numeroAfiliado; set => numeroAfiliado = value; }
        public string TelefonoContacto { get => telefonoContacto; set => telefonoContacto = value; }
    }
}
