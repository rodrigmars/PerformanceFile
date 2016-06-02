using System;
using System.IO;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using CsvHelper;
using PerformanceFile.Infra.File.Map;
using CsvHelper.Configuration;
using NLog;
using PerformanceFile.Domain.Entities;

namespace PerformanceFile.Infra.File
{
    public class LoadFileCsv
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="notas"></param>
        /// <param name="arquivo"></param>
        public void ParseFileCsv(out IEnumerable<NotaFiscal> notas, string arquivo)
        {
            using (var f = new FileStream(arquivo, FileMode.Open))
            {
                using (var sr = new StreamReader(f))
                {
                    var config = new CsvConfiguration
                    {
                        CultureInfo = new CultureInfo("pt-BR"),
                        TrimFields = true,
                        //Delimiter = ";"
                    };

                    config.RegisterClassMap<NotaFiscalMap>();

                    using (var csv = new CsvReader(sr, config))
                    {

                        var registros = csv.GetRecords<NotaFiscal>().ToList();
                        notas = registros;
                    }
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="path"></param>
        /// <param name="fileName"></param>
        public string GetFileCsv(string path, string fileName)
        {
            string[] arquivos = Directory.GetFiles(path, "*.csv");

            foreach (var a in arquivos)
            {
                var fe = Path.GetFileNameWithoutExtension(a);

                if (fe == null) continue;
  
                if (fileName == fe) return a;
            }

            return null;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sourceFile"></param>
        /// <param name="destFile"></param>
        public static void CopyFile(string sourceFile, string destFile)
        {
            try
            {
                System.IO.File.Copy(sourceFile, destFile, true);
            }
            catch (Exception ex)
            {
                var logger = LogManager.GetCurrentClassLogger();
                logger.Trace(ex.Message);
            }            
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="file"></param>
        public static void DeleteFile(string file)
        {
            if (System.IO.File.Exists(file))
            {
                try
                {
                    System.IO.File.Delete(file);
                }
                catch (IOException e)
                {
                    var logger = LogManager.GetCurrentClassLogger();
                    logger.Trace(e.Message);
                }
            }
        }
    }
}
