using NUnit.Framework;
using Allure.Commons;

namespace TutBy.Tests
{
    public class ClearResultsDir
    {
        [OneTimeSetUp]
        public void ClearResultDir()
        {
            AllureLifecycle.Instance.CleanupResultDirectory();
        }
    }
}
