using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Base.Entity
{
    public class Recebimentohub
    {

        public Recebimentohub()
        {

        }
        public int Id { get; set; }

        public string DataRecebimento { get; set; }

        public string HoraRecebimento { get; set; }

        public string Cliente { get; set; }

        public string Hora_Inicial { get; set; }

        public string Hora_Final { get; set; }

        public string Volume { get; set; }

        public string TipoEmbalagem { get; set; }

        public string Placa { get; set; }
    }
}
