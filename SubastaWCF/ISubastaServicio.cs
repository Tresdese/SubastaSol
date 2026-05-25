using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace SubastaWCF {
    
    public interface ISubastaCallback
    {
        [OperationContract(IsOneWay = true)]
        void NotificarNuevaOfertaMax(string nombreUsuario, double nuevoMonto);

        [OperationContract]
        void MensajeDelSistema(string mensaje);
    }
    
    [ServiceContract(CallbackContract = typeof(ISubastaCallback))]
    public interface ISubastaServicio
    {
        [OperationContract]
        void EntrarSala(string nombreUsuario);

        [OperationContract]
        void EnviarOferta(string nombreUsuario, double montoOferta);


    }
}
