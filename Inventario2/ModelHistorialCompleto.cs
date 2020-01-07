using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Inventario2
{
    public class ModelHistorialCompleto
    {
        [JsonProperty(PropertyName ="ID")]
        public string ID { get; set; }

        [JsonProperty(PropertyName = "movimento")]
        public string movimiento { get; set; }

        [JsonProperty(PropertyName = "lugar")]
        public string lugar { get; set; }

        [JsonProperty(PropertyName = "usuario")]
        public string usuario { get; set; }

        [JsonProperty(PropertyName = "observ")]
        public string observ { get; set; }

        [JsonProperty(PropertyName = "producto")]
        public string producto { get; set; }

        [JsonProperty(PropertyName = "cantidad")]
        public string cantidad { get; set; }

        [JsonProperty(PropertyName = "IdProducto")]
        public string IdProducto { get; set; }

        [JsonProperty(PropertyName = "fecha")]
        public DateTime fecha { get; set; }

        public string foto { get; set; }

        public string modelo { get; set; }

        public string marca { get; set; }

    }
}
