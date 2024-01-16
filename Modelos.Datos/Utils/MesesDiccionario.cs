using System;
using System.Collections.Generic;
using System.Text;

namespace Modelos.Datos.Utils
{
    public class MesesDiccionario
    {
        private static readonly string[] meses = new string[]
        {
        "Enero",
        "Febrero",
        "Marzo",
        "Abril",
        "Mayo",
        "Junio",
        "Julio",
        "Agosto",
        "Septiembre",
        "Octubre",
        "Noviembre",
        "Diciembre"
        };

        public string ObtenerMes(int numeroMes)
        {
            if (numeroMes < 1 || numeroMes > 12)
            {
                throw new ArgumentOutOfRangeException("El número de mes debe estar entre 1 y 12.");
            }

            return meses[numeroMes - 1];
        }
    }
}
