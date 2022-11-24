using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;

namespace Microservicios_common.Common
{
    [Serializable]
    [DataContract]
    public class ResponseQuery<T>
    {
        [DataMember]
        public bool Exitoso { get; set; }

        [DataMember]
        public string CodigoResultado { get; set; }

        [DataMember]
        public string Mensaje { get; set; }

        [DataMember]
        public T ObjetoResultado { get; set; }
    }
}
