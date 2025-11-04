using MSO_LAB_3;
using MSO_LAB_3.commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.WebSockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace TestProject
{
    public class IncorrectSyntaxTest
    {
        [Fact]
        public void incorrectMove_Test()
        {
            var tempGrid = new Grid
                (
                    new char[,]
                    {
                        {'o','o','o','o','o','o' },
                        {'o','o','o','o','o','o' },
                        {'o','o','o','o','o','o' },
                        {'o','o','o','o','o','o' },
                        {'o','o','o','o','o','o' },
                        {'o','o','o','o','o','o' }
                    }
                );
            string tempFile = Path.GetTempFileName();
            File.WriteAllLines(tempFile, new[]
                {
                    "Move 1",
                    "Repeat 2 ",
                    "   Turn right",
                    "   Move 3"
                });
            Player tempPlayer = new Player();
            var reader = new TextFileRead(tempFile, tempGrid);
            
        }
    }
}
