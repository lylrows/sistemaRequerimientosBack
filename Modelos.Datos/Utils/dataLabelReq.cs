using System;
using System.Collections.Generic;
using System.Text;

namespace Modelos.Datos.Utils
{
    public class dataLabelReq
    {
        public List<int> data { get; set; }
        public string label { get; set; }
        public dataLabelReq()
        {
            data = new List<int>();
        }
    }
}
