using Microsoft.VisualStudio.TestTools.UnitTesting;
using Entidades;

namespace TestCentroMedico
{
    [TestClass]
    public class TestCentroMedico
    {
        [TestMethod]
        public void EliminarPaciente_CuandoNoExisteEnLaListaDePacientes_DeberiaRetornarFalse()
        {
            // Arrange
            CentroMedico centroMedico = CentroMedico.Instanciar("centro");
            Paciente paciente = new Paciente("Leonel", "Ledesma", new System.DateTime(2000, 02, 10), 
                Persona.eGenero.Masculino, Persona.eNacionalidad.Argentina, "41458745", "1145858574", "", "", "");
            centroMedico.AgregarPersona(paciente);
            Paciente paciente2 = new Paciente("Juan", "Perez", new System.DateTime(1960, 10, 05), 
                Persona.eGenero.Masculino, Persona.eNacionalidad.Argentina, "18458969", "458599*/", "", "", "");

            bool result;            
            //act
            result = centroMedico.RemoverPersona(paciente2);

            //Assert
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void IgualarPacientes_CuandoLosDosTienenElMismoDocumento_DeberiaRetornarTrue()
        {
            //Arrange
            Paciente paciente = new Paciente("Leonel", "Ledesma", new System.DateTime(2000, 02, 10),
                Persona.eGenero.Masculino, Persona.eNacionalidad.Argentina, "41458745", "1145858574", "", "", "");            
            Paciente paciente2 = new Paciente("Juan", "Perez", new System.DateTime(1960, 10, 05),
                Persona.eGenero.Masculino, Persona.eNacionalidad.Argentina, "41458745", "458599*/", "", "", "");

            bool result;

            //act
            result = paciente == paciente2;

            //Assert
            Assert.IsTrue(result);
        }
    }
}
