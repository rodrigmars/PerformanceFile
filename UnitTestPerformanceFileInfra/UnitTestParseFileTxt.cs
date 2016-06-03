using System.Collections.Generic;
using System.Diagnostics;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PerformanceFile.Infra.File.Modules;
using PerformanceFile.Domain.Entities;

namespace PerformanceFileInfra.Test
{

    [TestClass]
    public class UnitTestParseFileTxt
    {
        public string FileSource => @"F:\FileServer\carga_.text";



        private TestContext _testContextInstance;

        /// <summary>
        ///Gets or sets the test context which provides
        ///information about and functionality for the current test run.
        ///</summary>
        public TestContext TestContext
        {
            get
            {
                return _testContextInstance;
            }
            set
            {
                _testContextInstance = value;
            }
        }

        [TestMethod]
        public void UnitTestParseTarifa()
        {

            Debug.WriteLine("TestDir: {0}", _testContextInstance.TestDir);
            Debug.WriteLine("TestDeploymentDir: {0}", _testContextInstance.TestDeploymentDir);
            Debug.WriteLine("TestLogsDir: {0}", _testContextInstance.TestLogsDir);
            Debug.WriteLine("TestName: {0}", _testContextInstance.TestName);

            var listTarifas = new List<Tarifa>();

            ParseFileTxt.Parse(listTarifas, FileSource);

            Assert.IsNotNull(listTarifas);
        }


        #region Additional test attributes
        //
        // You can use the following additional attributes as you write your tests:
        //
        // Use ClassInitialize to run code before running the first test in the class
        // [ClassInitialize()]
        // public static void MyClassInitialize(TestContext testContext) { }
        //
        // Use ClassCleanup to run code after all tests in a class have run
        // [ClassCleanup()]
        // public static void MyClassCleanup() { }
        //
        // Use TestInitialize to run code before running each test 
        // [TestInitialize()]
        // public void MyTestInitialize() { }
        //
        // Use TestCleanup to run code after each test has run
        // [TestCleanup()]
        // public void MyTestCleanup() { }
        //
        #endregion
    }
}
