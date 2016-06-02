using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PerformanceFile.Infra.File;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using PerformanceFile.Domain.Entities;

namespace PerformanceFileInfra.Test
{
    [TestClass]
    public class UnitTestParseFileCsv
    {
        public string Path => ConfigurationManager.AppSettings["pathfilecsv"];

        private static readonly string File = DateTime.Now.ToString("yyyyMMddHHmmssffff") + "_Notasfiscais-teste.csv";

        [TestInitialize]
        //[TestInitialize, Ignore]
        public void Setup()
        {
            LoadFileCsv.CopyFile(
                System.IO.Path.Combine(Path, "Notasfiscais-teste.csv"),
                System.IO.Path.Combine(Path, File));
        }

        [TestMethod]
        //[TestMethod, Ignore]
        public void Testemapeandonotafiscalcomarquivocsv()
        {
            try
            {
                var sut = new LoadFileCsv();

                IEnumerable<NotaFiscal> notas;

                sut.ParseFileCsv(out notas, sut.GetFileCsv(Path, File.Replace(".csv","")));

                Assert.IsTrue(notas.Any());
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);
            }
        }

        [TestCleanup]
        //[TestCleanup, Ignore]
        public void FinalizaTest()
        {
            LoadFileCsv.DeleteFile(System.IO.Path.Combine(Path, File));
        }
    }
}
