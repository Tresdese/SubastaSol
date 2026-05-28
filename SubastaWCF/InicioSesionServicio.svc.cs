using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace SubastaWCF
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de clase "InicioSesionServicio" en el código, en svc y en el archivo de configuración a la vez.
    // NOTA: para iniciar el Cliente de prueba WCF para probar este servicio, seleccione InicioSesionServicio.svc o InicioSesionServicio.svc.cs en el Explorador de soluciones e inicie la depuración.
    public class InicioSesionServicio : IInicioSesionServicio
    {
        private static List<string> nombresDeUsuario = new List<string>();
        public bool IniciarSesion(string nombreDeUsuario)
        {
            bool estaSesionIniciada = false;
            if (VerificarNombre(nombreDeUsuario))
            {
                estaSesionIniciada = true;
                nombresDeUsuario.Add(nombreDeUsuario);
            }

            return estaSesionIniciada;
        }

        public bool VerificarNombre(string nombreUsuario)
        {
            bool estaNombreDisponible = true;
            foreach (var nombre in nombresDeUsuario) {
                if (nombre.ToLower() == nombreUsuario.ToLower())
                {
                    estaNombreDisponible = false;
                }
            }

            return estaNombreDisponible;
        }
    }
}
