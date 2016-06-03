
namespace PerformanceFile.Domain.Entities
{
    public class Tarifa
    {
        public int TarifasId { get; set; }
        public string Uf { get; set; }
        public string Distribuidora { get; set; }
        public double TarifakWh { get; set; }
        public string Vigencia { get; set; }
        public int NumeroReh { get; set; }
    }
}
