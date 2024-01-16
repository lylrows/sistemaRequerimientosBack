using System;
using System.Collections.Generic;
using System.Text;

namespace Modelos.Datos.Utils
{
    public class seriesReq
    {
        public string name         {get;set;}
        public string type         {get;set;}
        public List<int> data { get; set; }
        public seriesReq()
        {
            data = new List<int>();
        }
    }
}
