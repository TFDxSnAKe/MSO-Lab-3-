using MSO_LAB_3;
using ProgrammingLearningApp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestProject
{
    public class FormFileIOTest
    {
        private static Form1 MakeFakeForm()
        {
            var player = new Player();
            var grid = new Grid
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
            var form = new Form1(player, grid, loadSprite: false);
            return form;
        }

        [Fact]
        public void LoadingExampleIntoEditor_Test()
        {
            // arraging
            var fakeForm = MakeFakeForm();

            // acting
            typeof(Form1).GetMethod("LoadExampleIntoBox",
                System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance)
                ?.Invoke(fakeForm, ["TestProgram"]);

            // asserting
            Assert.Contains("Move", fakeForm.EditorWindow.Text);
        }
    }
}
