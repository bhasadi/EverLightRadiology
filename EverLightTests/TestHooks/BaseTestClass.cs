using CommonFeatures;

namespace EverLightTests.TestHooks
{
    [TestClass]
    public class BaseTestClass
    {        
        private static CommonVars commonInstance = CommonVars.instance;       

        public TestContext testContextInstance;
        public TestContext TestContext
        {
            get { return testContextInstance; }
            set { testContextInstance = value; }// gets called after assemblyInitialize
        }

        //######################################################################################################################
        /// <summary>
        /// 
        /// </summary>
        /// <param name="contextInstance"></param>
        [AssemblyInitialize]
        public static void AssemblyInitialize(TestContext contextInstance)
        {
            DateTime timeNow = DateTime.Now;
         
        }//AssemblyInitialize

        //######################################################################################################################
        /// <summary>
        /// 
        /// </summary>
        [AssemblyCleanup]
        public static void AssemblyCleanup()
        {
            
        }//AssemblyCleanup

        //######################################################################################################################
        /// <summary>
        /// 
        /// </summary>
        [TestInitialize]
        public void TestInitialize()
        {
            // =========================================================================
            // Initialize CommonVars & BaseInvokeMethodSetup
            // =========================================================================
            CommonVars tmpobj = CommonVars.instance;
            DateTime timeNow = DateTime.Now;

            commonInstance.unqTestNumber = timeNow.ToString("ddMMyy") + timeNow.ToString("hhmmss");
            
        }//TestInitialize

        //######################################################################################################################
        /// <summary>
        /// 
        /// </summary>
        [TestCleanup]
        public void TestFinalize()
        {
            if (commonInstance.webDriver != null)
            {
                commonInstance.webDriver.Close();
                commonInstance.webDriver.Quit();
            }

        }//TestFinalize

    }//class
}//namespace