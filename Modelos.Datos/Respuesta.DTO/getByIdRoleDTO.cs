using System;
using System.Collections.Generic;
using System.Text;

namespace Modelos.Datos.Respuesta.DTO
{
    public class getByIdRoleDTO
    {
        public int id { get; set; }
        public string path { get; set; }
        public string title { get; set; }
        public string moduleName { get; set; }
        public string iconType { get; set; }
        public string icon { get; set; }
        public string menuClass { get; set; }
        public int groupTitle { get; set; }
        public string badge { get; set; }
        public string badgeClass { get; set; }
        public string rol { get; set; }
        public int parentField { get; set; }
        public int isSubMenu { get; set; }
        public int idRole { get; set; }
        public int esActivo { get; set; }
    }
}
