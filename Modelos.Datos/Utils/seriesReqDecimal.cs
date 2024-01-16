using System;
using System.Collections.Generic;
using System.Text;

namespace Modelos.Datos.Utils
{
    public class seriesReqDecimal
    {
        public string name { get; set; }
        public string type { get; set; }
        public List<decimal> data { get; set; }
        public seriesReqDecimal()
        {
            data = new List<decimal>();
        }
    }
}
