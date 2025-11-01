using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestProject
{
    public class GridParsingTest
    {
        [Fact]
        public void Test()
        {
            string tempFile = Path.GetTempFileName();
            File.WriteAllLines(tempFile, new[]
                {
                    "oo+++",
                    "+o+++",
                    "++o++",
                    "++o++",
                    "++oox"
                });

        }
    }
}
