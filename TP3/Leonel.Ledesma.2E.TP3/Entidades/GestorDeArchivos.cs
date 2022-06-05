using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades.Exceptions;
using Entidades.Interfaces;
using Entidades.Models;
using System.Xml.Serialization;


namespace Entidades
{
    public abstract class GestorDeArchivos
    {

        public static bool EscribirLog(string mensaje)
        {
            try
            {
                using (StreamWriter sw = new StreamWriter($"{Directory.GetCurrentDirectory()}\\Logs\\errores.log", true))
                {
                    sw.WriteLine($"{DateTime.Now}: {mensaje}");
                }
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public static bool GuardarArchivo(string path, string datos)
        {
            try
            {
                using (StreamWriter sw = new StreamWriter(path))
                {
                    sw.WriteLine(datos);
                }
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public static string LeerArchivo(string path)
        {
            try
            {
                using (StreamReader sr = new StreamReader(path))
                {
                    return sr.ReadToEnd();
                }
            }
            catch (Exception)
            {
                return "";
            }
        }

        public static void GuardarArchivo<T>(string fullPath, List<T> lista)
        {
            StringBuilder sb = new StringBuilder();

            foreach (T item in lista)
            {
                sb.AppendLine(item.ToString());                    
            }

            GestorDeArchivos.GuardarArchivo(fullPath, sb.ToString());
        }

    }
}
