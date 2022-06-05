using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{   

    public class Turno //: ISerializable
    {
        private int id;
        private DateTime fecha;
        private Paciente paciente;
        private Profesional profesional;
        private string especialidad;
        private bool pacienteAsistio;

        public Turno(int id, DateTime fecha, Paciente paciente, Profesional profesional, string especialidad)
        {
            this.Fecha = fecha;
            this.Paciente = paciente;
            this.Profesional = profesional;
            this.Especialidad = especialidad;
            this.Id = id;
        }

        public Turno()
        {            
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.Append($"Id: {this.Id} - Fecha: {this.Fecha.ToString("dddd dd/MM/yyyy hh:mm")} - Paciente:  + {this.Paciente} - " +
                $"Profesional: {this.Profesional} - Especialidad: {this.Especialidad}");

            return sb.ToString();
        }

        public DateTime Fecha { get => fecha; set => fecha = value; }
        public Paciente Paciente { get => paciente; set => paciente = value; }
        public Profesional Profesional { get => profesional; set => profesional = value; }
        public string Especialidad { get => especialidad; set => especialidad = value; }
        public int Id { get => id; set => id = value; }
        public bool PacienteAsistio { get => pacienteAsistio; set => pacienteAsistio = value; }

        public void Confirmar()
        {
            this.pacienteAsistio = true;
        }

        public static bool operator ==(Turno t1, Turno t2)
        {
            return t1.profesional == t2.profesional && t1.paciente == t2.paciente && t1.fecha == t2.fecha;
        }

        public static bool operator !=(Turno t1, Turno t2)
        {
            return !(t1 == t2);
        }
    }
}
