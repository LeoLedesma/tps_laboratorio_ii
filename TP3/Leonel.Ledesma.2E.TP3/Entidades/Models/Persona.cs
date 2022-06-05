using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using System.Xml.Serialization;

namespace Entidades
{
    [XmlInclude(typeof(Paciente)), XmlInclude(typeof(Profesional))]
    public abstract class Persona : ISerializable
    {
        public enum eGenero { Femenino, Masculino, NoBinario, Otro }
        public enum eNacionalidad { Argentina, Brasilera, Boliviana, Chilena, Colombiana, Paraguaya, Uruguaya, Venezolana, Otra }

        private string nombre;
        private string apellido;
        private DateTime fechaDeNacimiento;
        private int edad;
        public eNacionalidad nacionalidad;
        public eGenero genero;
        private string documento;
        private string telefono;
        private List<Turno> turnosFuturos;
        private List<Turno> turnosPasados;

        internal Persona(string nombre, string apellido, DateTime fechaDeNacimiento, eGenero sexo, eNacionalidad nacionalidad, string documento, string telefono)
        {
            this.Nombre = nombre;
            this.Apellido = apellido;
            this.FechaDeNacimiento = fechaDeNacimiento;
            this.genero = sexo;
            this.Documento = documento;
            this.Telefono = telefono;
            this.nacionalidad = nacionalidad;
        }

        internal Persona()
        {            
        }

        public string Nombre { get => nombre; set => nombre = value.ToLower(); }
        public string Apellido { get => apellido; set => apellido = value.ToLower(); }
        public int Edad
        {
            get => edad;
        }

        public DateTime FechaDeNacimiento
        {
            get { return fechaDeNacimiento; }
            set
            {
                if (fechaDeNacimiento < DateTime.Now)
                {
                    this.fechaDeNacimiento = value;
                    edad = DateTime.Now.Year - fechaDeNacimiento.Year;

                    if (fechaDeNacimiento.Month > DateTime.Now.Month)
                    {
                        edad--;
                    }
                }
            }
        }

        public string Documento { get => documento; set => documento = value; }
        public string Telefono { get => telefono; set => telefono = value; }
        internal List<Turno> TurnosFuturos { get => turnosFuturos; set => turnosFuturos = value; }
        internal List<Turno> TurnosPasados { get => turnosPasados; set => turnosPasados = value; }


        //Sobrecarga de operadores


        public static bool operator ==(Persona p1, Persona p2)
        {
            return p1.Documento == p2.Documento;
        }

        public static bool operator !=(Persona p1, Persona p2)
        {
            return !(p1 == p2);
        }

        public void Serializar(string fullPath)
        {
            if (fullPath.Contains(".xml"))
            {
                XmlSerializer serializer = new XmlSerializer(typeof(Persona));
                StreamWriter writer = new StreamWriter(fullPath);
                serializer.Serialize(writer, this);
                writer.Close();
            }
            else if (fullPath.Contains(".json"))
            {
                string json = JsonSerializer.Serialize(this);
                StreamWriter writer = new StreamWriter(fullPath);
                writer.WriteLine(json);
                writer.Close();
            }
        }


        public void SerializarToXML(string fullPath)
        {
            StreamWriter streamWriter = null;
            try
            {
                streamWriter = new StreamWriter(fullPath);
                XmlSerializer xml;
                
                if (this is Paciente)
                {
                    List<Paciente> lista = new List<Paciente>() { (Paciente) this };
                    xml = new XmlSerializer(typeof(List<Paciente>));
                    xml.Serialize(streamWriter, lista);                    

                }
                else if (this is Profesional)
                {
                    List<Profesional> lista = new List<Profesional>() { (Profesional)this };                    
                    xml = new XmlSerializer(typeof(List<Paciente>));
                    xml.Serialize(streamWriter, lista);
                }               

            }
            catch (Exception e)
            {
                throw new SerializarException($"Error al guardar el {this.GetType()}", e);
            }
            finally
            {
                if (streamWriter != null)
                    streamWriter.Close();
            }
        }

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
                throw new SerializarException($"Error al serializar el {this.GetType()}.", e);
            }
            finally
            {
                if (streamWriter != null)
                    streamWriter.Close();
            }
        }


        public override string ToString()
        {
            return $"{this.Nombre.TotUpperFirstLetter()} {this.Apellido.TotUpperFirstLetter()}";
        }


    }
}
