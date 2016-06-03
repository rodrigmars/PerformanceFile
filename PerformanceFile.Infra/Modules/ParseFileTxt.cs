using System;
using System.Diagnostics;
using System.IO;
using PerformanceFile.Domain.Entities;
using System.Collections.Generic;
using NLog;

namespace PerformanceFile.Infra.File.Modules
{
    public class ParseFileTxt
    {
        public static void Parse(List<Tarifa> listTarifas, string fileSource)
        {
            try
            {
                long memoryBefore = GC.GetTotalMemory(true);

                //GetStreamFile(listTarifas, new Tarifa(), fileSource);

                var lines = GetStreamFile(fileSource);

                foreach (var line in lines)
                {
                    GetValues(listTarifas, line, new Tarifa());
                }


                var memoryAfter = GC.GetTotalMemory(false);

                var calcMemo = string.Format(((memoryAfter - memoryBefore) / 1000).ToString(), "n") + "kb";

                var logger = LogManager.GetCurrentClassLogger();

                logger.Trace(calcMemo);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
                //throw;
            }
        }

        private static IEnumerable<string> GetStreamFile(string fileSource)
        {
            using (var fs = System.IO.File.Open(fileSource, FileMode.Open, FileAccess.Read))
            {
                using (var sb = new BufferedStream(fs))
                {
                    using (var sr = new StreamReader(sb))
                    {
                        while ((sr.ReadLine()) != null)
                        {
                            var line = sr.ReadLine();

                            if (line != null)
                            {
                                yield return line;
                            }
                        }
                    }
                }
            }
        }

        private static void GetValues(List<Tarifa> listTarifas, string line, Tarifa tarifa)
        {
            var readLine = line.Split('|');

            tarifa.Uf = readLine[0].Trim();
            tarifa.Distribuidora = readLine[1].Trim();
            tarifa.TarifakWh = Convert.ToDouble(readLine[2].Trim());
            tarifa.Vigencia = readLine[3].Trim();
            tarifa.NumeroReh = int.Parse(readLine[4].Replace(".", "").Trim());

            listTarifas.Add(tarifa);
        }
    }
}
