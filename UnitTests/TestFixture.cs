using System.IO;

using NUnit.Framework;

namespace UnitTests
{
    /// <summary>
    /// This class gets the latest databse files and needs to be run before running any test case.
    /// </summary>
    [SetUpFixture]
    public class TestFixture
    {
        // Path to the Web Root
        public static string DataWebRootPath = "./wwwroot";

        // Path to the data folder for the content
        public static string DataContentRootPath = "./data/";

        /// <summary>
        /// Run this code once when the test harness starts up. This will copy over the latest version of the database files.
        /// </summary>
        [OneTimeSetUp]
        public void RunBeforeAnyTests()
        {
            // Run this code once when the test harness starts up.

            // This will copy over the latest version of the database files

            // C:\repos\Team13-CoreF12\UnitTests\bin\Debug\net5.0\wwwroot\data
            // C:\repos\Team13-CoreF12\src\wwwroot\data
            // C:\repos\Team13-CoreF12\src\bin\Debug\net5.0\wwwroot\data



            // var DataWebPath = "../../../../src/bin/Debug/net5.0/wwwroot/data";
            var DataWebPath = "../../../../src/wwwroot/data";
            var DataUTDirectory = "wwwroot";
            var DataUTPath = DataUTDirectory + "/data";

            // Delete the Detination folder
            if (Directory.Exists(DataUTDirectory))
            {
                Directory.Delete(DataUTDirectory, true);
            }
            
            // Make the directory
            Directory.CreateDirectory(DataUTPath);

            // Copy over all data files
            var filePaths = Directory.GetFiles(DataWebPath);
            foreach (var filename in filePaths)
            {
                string OriginalFilePathName = filename.ToString();
                var newFilePathName = OriginalFilePathName.Replace(DataWebPath, DataUTPath);

                File.Copy(OriginalFilePathName, newFilePathName);
            }
        }

        [OneTimeTearDown]
        public void RunAfterAnyTests()
        {
        }
    }
}