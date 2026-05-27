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
    [ServiceBehavior(ConcurrencyMode = ConcurrencyMode.Multiple, InstanceContextMode = InstanceContextMode.Single)]    
    
    public class SubastaServicio : ISubastaServicio
    {
        private List<ISubastaCallback> clientesConectados = new List<ISubastaCallback>();

        private double ofertaMaximaActual = 0.0;
        private string liderActual = "Sin oferta";

        public void EntrarSala(string nombreUsuario)
        {
            ISubastaCallback callback = OperationContext.Current.GetCallbackChannel<ISubastaCallback>();

            if (!clientesConectados.Contains(callback))
            {
                clientesConectados.Add(callback);
            }

            callback.MensajeDelSistema($"Bienvenido, la oferta maxima actual es: {ofertaMaximaActual} por {liderActual}");
        }

        public void EnviarOferta(string nombreUsuario, double montoOferta)
        {
            if (montoOferta > ofertaMaximaActual)
            {
                ofertaMaximaActual = montoOferta;
                liderActual = nombreUsuario;
                string mensajeHistorial = $"Nueva oferta maxima de {nombreUsuario} por el monto {montoOferta}";
                foreach (var cliente in clientesConectados) {
                    try
                    {
                        Console.WriteLine("si funciona");
                        cliente.NotificarNuevaOfertaMax(nombreUsuario, montoOferta);
                        cliente.MensajeDelSistema(mensajeHistorial);
                    } catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                }
            }

        }
    }
}
