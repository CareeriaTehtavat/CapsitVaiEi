


using HelloWorld; // Ensure this is the correct namespace for the Program class
using Microsoft.VisualStudio.TestPlatform.TestHost;
using System.Reflection;

namespace HelloWorldTest
{
    public class UnitTest1
    {


        //Harjoitus - Piirtelyä
        [Fact]
        [Trait("TestGroup", "ArtPrinting")]
        public void ArtPrinting()
        {

            var sw = new StringWriter();
            Console.SetOut(sw);

            // Act: Run the main program
            HelloWorld.Program.Main(null);

            var result = sw.ToString().Split(new[] { "\r\n", "\n" }, StringSplitOptions.None)
                         .ToArray();


            // Assert: Verify output
            Assert.True(HaveSame("   *", result[0]), "row 1 Expected: " + "   *"
                + " printed: " + result[0]);
            Assert.True(string.IsNullOrWhiteSpace(result[1]), "row 2 Expected: " + ""
    + " printed: " + result[1]);

            Assert.True(HaveSame("   *", result[2]), "row 3 Expected: " + "   *"
                + " printed: " + result[2]);

            Assert.True(HaveSame("  ***", result[3]), "row 4 Expected: " + "   *"
               + " printed: " + result[3]);

            Assert.True(HaveSame(" *****", result[4]), "row 5 Expected: " + "   *"
               + " printed: " + result[4]);
            Assert.True(HaveSame("*******", result[5]), "row 6 Expected: " + "   *"
               + " printed: " + result[5]);
        }

        public bool HaveSame(string expected, string Goted)
        {
            return expected.Contains(Goted.Trim());


        }
        private bool CompareLines(string[] actualLines, string[] expectedLines)
        {
            if (actualLines.Length != expectedLines.Length)
            {
                return false;
            }

            for (int i = 0; i < actualLines.Length; i++)
            {
                if (actualLines[i] != expectedLines[i])
                {
                    return false;
                }
            }

            return true;
        }

    }
}


    

