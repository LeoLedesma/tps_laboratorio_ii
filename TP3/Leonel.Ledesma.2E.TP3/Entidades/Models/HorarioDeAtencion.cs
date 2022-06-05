using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades.Models
{

    public class HorarioDeAtencion
    {
        private bool atiende;
        private bool esPorDefecto;
        private float desde;
        private float hasta;

        public HorarioDeAtencion()
        {
            this.Atiende = false;
            this.EsPorDefecto = false;
        }

        public HorarioDeAtencion(bool atiende)
        {
            this.atiende = atiende;
            this.Desde = "10:00";
            this.Hasta = "11:00";
            this.EsPorDefecto = true;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="atiende"></param>
        /// <param name="desde"></param>
        /// <param name="hasta"></param>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        /// <exception cref="ArgumentException"></exception>
        public HorarioDeAtencion(bool atiende, string desde, string hasta)
        {
            this.atiende = atiende;
            this.Desde = desde;
            this.Hasta = hasta;
        }


        /// <summary>
        /// Propiedad que valida que el horario de atencion no sea menor a 0 o mayor a 23:59 
        /// </summary>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        private float DesdeFloat
        {
            get => desde;
            set
            {
                if (value < 0 || value > 23.59f)
                {
                    throw new ArgumentOutOfRangeException("value", "El horario de atencion no puede ser menor a 0 o mayor a 23:59");
                }
                else
                {
                    desde = value;
                }
            }

        }

        /// <summary>
        /// Propiedad que valida que el horario de atencion no sea menor a 0 o mayor a 23:59.
        /// </summary>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public string Desde
        {
            get
            {
                return HorarioDeAtencion.ConvertirFloatAHorario(this.DesdeFloat);
            }
            set
            {
                float valor = ConvertirHorarioAFloat(value);
                this.DesdeFloat = valor;
            }
        }

        /// <summary>
        /// Propiedad que valida que el horario de atencion no sea menor a la hora Desde, no sea menor que 0 o mayor que 23.59.
        /// </summary>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        private float HastaFloat
        {
            get => hasta;
            set
            {
                if (value < desde || (value < 0 || value > 23.59f))
                {
                    throw new ArgumentOutOfRangeException("value", "El valor debe estar entre 0 y 23 y ser mayor al valor Desde");
                }
                else
                {
                    hasta = value;
                }
            }

        }

        /// <summary>
        /// Propiedad que valida que el horario de atencion no sea menor a la hora Desde, no sea menor que 0 o mayor que 23.59.
        /// </summary>
        /// <exception cref="ArgumentException</exception>
        public string Hasta
        {
            get
            {
                return HorarioDeAtencion.ConvertirFloatAHorario(this.HastaFloat);
            }
            set
            {
                float valor = ConvertirHorarioAFloat(value);
                this.HastaFloat = valor;
            }
        }

        public bool Atiende { get => atiende; set => atiende = value; }
        public bool EsPorDefecto { get => esPorDefecto; set => esPorDefecto = value; }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            if (!this.atiende)
            {
                sb.Append("No atiende");
            }
            else
            {
                sb.Append($"Atiende desde: {this.Desde} hasta: {this.Hasta}");
            }

            return sb.ToString();
        }

        public List<string> HorariosPosibles(CentroMedico.EDuracionTurno duracion)
        {
            List<string> horarios = new List<string>();



            if (this.Atiende)
            {
                List<TimeSpan> horas = new List<TimeSpan>();
                
                string[] horaSplit = this.Desde.Split(':');
                int horasDesde = int.Parse(horaSplit[0]);
                int minutosDesde = int.Parse(horaSplit[1]);

                TimeSpan intervalo = new TimeSpan(0, (int) duracion, 0);                

                horaSplit = this.Hasta.Split(':');
                int horasHasta = int.Parse(horaSplit[0]);
                int minutosHasta = int.Parse(horaSplit[1]);

                TimeSpan horaHasta = new TimeSpan(horasHasta, minutosHasta, 0);
                TimeSpan horaActual = new TimeSpan(horasDesde, minutosDesde, 0);
                horas.Add(horaActual);


                do
                {
                    horas.Add(horaActual + intervalo);
                    horaActual = horaActual + intervalo;

                } while(horaActual < (horaHasta-intervalo));


                foreach (TimeSpan hora in horas)
                {
                    horarios.Add(hora.ToString("hh\\:mm"));
                }

            }


            return horarios;
        }


        /// <summary>
        /// Convierte el punto decimal a :
        /// </summary>
        /// <param name="numero"></param>
        /// <returns></returns>
        public static string ConvertirFloatAHorario(float numero)
        {
            string desdeStr = numero.ToString();
            string[] desdeArr = desdeStr.Split(',', '.');
                        

            if (desdeArr[0].Length == 1)
            {
                if (desdeArr[0].Length == 1)
                    desdeArr[0] = $"0{desdeArr[0]}";
            }

            if (desdeArr.Count() == 1)
            {
                return $"{desdeArr[0]}:00";
            }

            if (desdeArr[1].Length == 1)
            {
                desdeArr[1] = $"{desdeArr[1]}0";
            }

            return $"{desdeArr[0]}:{desdeArr[1]}";
        }

        /// <summary>
        /// Convierte el string con formato ##:## a float. Siendo # solo numeros
        /// </summary>
        /// <param name="horario"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentException"></exception>
        public static float ConvertirHorarioAFloat(string horario)
        {
            char[] charArr = horario.ToCharArray();
            foreach (char caracter in charArr)
            {
                if (char.IsLetter(caracter))
                {
                    throw new ArgumentException("No se admiten caracteres");
                }
            }


            string[] horarioArr = horario.Split(':', ' ', ',', '.');

            if (horarioArr.Count() == 2)
            {


                float antes = float.Parse(horarioArr[0]);
                float despues = float.Parse($"0,{horarioArr[1]}");
                float resultado = antes + despues;
                return resultado;
            }

            throw new ArgumentException("El formato enviado es incorrecto");
        }
    }
}
