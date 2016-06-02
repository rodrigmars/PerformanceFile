using System;

namespace PerformanceFile.Domain.Entities
{
    public class NotaFiscal
    {
        public int NotaFiscalId { get; set; }

        public int NumeroNf { get; set; }

        public DateTime Data { get; set; }

        public string PartNumber { get; set; }

        public string Title { get; set; }

        public decimal Valor { get; set; }

        public int Quantidade { get; set; }
    }
}
