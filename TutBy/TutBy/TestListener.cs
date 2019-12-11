using Allure.Commons;
using AShotNet;
using AShotNet.Coordinates;
using log4net;
using System;
using System.IO;

namespace TutBy
{
    public class TestListener
    {
        static private ILog Log = LogManager.GetLogger(typeof(TestListener));

        public static ILog log
        {
            get { return Log; }
        }

        public static void OnTestFailure()
        {
            MakeScreenshot();
            Log.Error("TestFailure");
        }

        public static void OnTestSuccess()
        {
            Log.Info("TestSuccess");
        }

        private static void MakeScreenshot()
        {
            string screenFolder = AppDomain.CurrentDomain.BaseDirectory + @"..\..\..\Screenshots";
            string screenName = $"{DateTime.Now.ToString("HH_mm_ss")}{DriverSingleton.GetDriver().Title}.jpg";
            string fullPath = $@"{screenFolder}\{screenName}";
            Directory.CreateDirectory(screenFolder);

            new AShot()
             .CoordsProvider(new WebDriverCoordsProvider())
             .TakeScreenshot(DriverSingleton.GetDriver())
             .getImage()
             .Save(fullPath);

            AllureLifecycle.Instance.AddAttachment("Screen", "Screenshot", fullPath);
        }
    }
}
