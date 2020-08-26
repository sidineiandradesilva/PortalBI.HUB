using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Filtro
{
    public class FiltroRecebimentoHub
    {
        public FiltroRecebimentoHub()
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
