using System;
using System.Collections.Generic;
using System.Text;
using Dapper.Contrib.Extensions;

namespace Modelos.Datos.Mapeo.Base.Datos.configuracion
{
    [Table("[configuracion].[menu]")]
    public class t_menu
    {
        public int id                       { get; set; }
        public string path                  { get; set; }
        public string title                 { get; set; }
        public string moduleName            { get; set; }
        public string iconType              { get; set; }
        public string icon                  { get; set; }
        public string @class             { get; set; }
        public int groupTitle               { get; set; }
        public string badge                 { get; set; }
        public string badgeClass            { get; set; }
        public string rol                   { get; set; }
        public int parentField              { get; set; }
        public int isSubMenu                { get; set; }
        public int idRole                   { get; set; }
        public int esActivo                 { get; set; }
    }
}
