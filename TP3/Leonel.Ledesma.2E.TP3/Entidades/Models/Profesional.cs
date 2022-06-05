﻿using Entidades.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Entidades
{
    public class Profesional : Persona, ICloneable
    {
        private string matricula;
        private List<string> especialidades;
        private DiasDeAtencion diasDeAtencion;

        public Profesional(string nombre, string apellido, DateTime fechaDeNacimiento, eGenero genero, eNacionalidad nacionalidad, string documento, string telefono, string matricula, List<string> especialidades)
            : base(nombre, apellido, fechaDeNacimiento, genero, nacionalidad, documento, telefono)
        {
            Matricula = matricula;
            this.Especialidades = especialidades;
            this.DiasDeAtencion = new DiasDeAtencion();
        }

        public Profesional(string nombre, string apellido, DateTime fechaDeNacimiento, eGenero genero, eNacionalidad nacionalidad, string documento, string telefono, string matricula, List<string> especialidades, DiasDeAtencion diasDeAtencion)
            : this(nombre, apellido, fechaDeNacimiento, genero, nacionalidad, documento, telefono, matricula, especialidades)
        {
            this.DiasDeAtencion = diasDeAtencion;
        }

        public Profesional() : base()
        {
            this.especialidades = new List<string>();
            this.DiasDeAtencion = new DiasDeAtencion();
        }

        public List<string> Especialidades { get => especialidades; set => especialidades = value; }
        public DiasDeAtencion DiasDeAtencion { get => diasDeAtencion; set => diasDeAtencion = value; }

        public string Matricula
        {
            get { return matricula; }
            set
            {
                matricula = value;
            }
        }       
        

        private Profesional ClonarProfesional()
        {
            Profesional nuevaReferencia = new Profesional();

            nuevaReferencia.Nombre = this.Nombre;
            nuevaReferencia.Apellido = this.Apellido;
            nuevaReferencia.FechaDeNacimiento = this.FechaDeNacimiento;
            nuevaReferencia.genero = this.genero;
            nuevaReferencia.nacionalidad = this.nacionalidad;
            nuevaReferencia.Documento = this.Documento;
            nuevaReferencia.Telefono = this.Telefono;
            nuevaReferencia.Matricula = this.Matricula;
            nuevaReferencia.Especialidades = this.Especialidades;
            nuevaReferencia.DiasDeAtencion = this.DiasDeAtencion;

            return nuevaReferencia;
        }

        public object Clone()
        {
            return this.ClonarProfesional();
        }
    }
}
