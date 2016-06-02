using System;
using CsvHelper.Configuration;
using System.Globalization;
using PerformanceFile.Domain.Entities;

namespace PerformanceFile.Infra.File.Map
{
    public sealed class NotaFiscalMap : CsvClassMap<NotaFiscal>
    {
        public NotaFiscalMap()
        {
            Map(m => m.NumeroNf).Index(0).ConvertUsing(
                m =>
                {
                    int numeronf;

                    if (string.IsNullOrEmpty(m.GetField(0))) throw new Exception("Erro linha [" + m.Row + "] - Campo Numero NF vázio");

                    if (!int.TryParse(m.GetField(0), out numeronf)) throw new Exception("ERRO LINHA [" + m.Row + "] | CAMPO [Numero NF] - Formato inválido, informe apenas números.");

                    if (m.GetField(0).Length > 9) throw new Exception("ERRO LINHA [" + m.Row + "] | CAMPO [Numero NF] - Formato inválido, informe no máximo 9 dígitos.");

                    return numeronf;
                });

            Map(m => m.Data).Index(1).ConvertUsing(m =>
                DateTime.Parse(m.GetField(1).Trim(), CultureInfo.GetCultureInfo("pt-BR")));

            Map(m => m.PartNumber).Index(2).ConvertUsing(m => m.GetField(2).Trim());

            Map(m => m.Title).Index(3).ConvertUsing(m => m.GetField(3).Trim());

            Map(m => m.Valor).Index(4).ConvertUsing(m => decimal.Parse(m.GetField(4).Trim()));

            Map(m => m.Quantidade).Index(5).ConvertUsing(m => int.Parse(m.GetField(5).Trim()));
        }
    }
}
