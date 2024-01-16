namespace Modelos.Datos.Respuesta.DTO
{
    public class PorcentajeCumplimientoDTO
    {
        public int MesNumero { get; set; }
        public string Mes { get; set; }
        public int Anio { get; set; }
        public int NumeroTickets { get; set; }
        public int CumplenANS { get; set; }
        public int NoCumplenANS { get; set; }
        public int Descartados { get; set; }
        public double PorcentajeCumplimiento { get; set; }
        public string Empresa { get; set; }
    }
}