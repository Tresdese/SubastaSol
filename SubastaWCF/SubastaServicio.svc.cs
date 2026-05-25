using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace SubastaWCF
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de clase "SubastaServicio" en el código, en svc y en el archivo de configuración a la vez.
    // NOTA: para iniciar el Cliente de prueba WCF para probar este servicio, seleccione SubastaServicio.svc o SubastaServicio.svc.cs en el Explorador de soluciones e inicie la depuración.
    public class SubastaServicio : ISubastaServicio
    {
        private List<ISubastaServicio> clientesConectados = new List<ISubastaServicio>();

        private double ofertaMaximaActual = 0.0;
        private string liderActual = "Sin oferta";

        public void EntrarSala(string nombreUsuario)
        {
            ISubastaCallback callback = OperationContext.Current.GetCallbackChannel<ISubastaCallback>();
            if (!clientesConectados.Contains(callback))
            {

            }
        }

        public void EnviarOferta(string nombreUsuario, double montoOferta)
        {

        }
    }
}
