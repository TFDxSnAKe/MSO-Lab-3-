using MSO_LAB_3;
using ProgrammingLearningApp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace TestProject
{
    public class FormAppButtonTest
    {

        readonly Grid emptyGrid = new Grid
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

        readonly Grid filledGrid = new Grid
                (
                    new char[,]
                    {
                        {'x','x','x','x','x','x' },
                        {'x','x','x','x','x','x' },
                        {'x','x','x','x','x','x' },
                        {'x','x','x','x','x','x' },
                        {'x','x','x','x','x','x' },
                        {'x','x','x','x','x','x' }
                    }
                );

        private static Form1 MakeFakeForm(Grid grid)
        {
            var player = new Player();
            var form = new Form1(player, grid, loadSprite: false);
            return form;
        }

        [Fact]
        public void MetricsButtonDisplays_Test()
        {
            // arranging
            var fakeForm = MakeFakeForm(emptyGrid);
            fakeForm.EditorWindow.Text = "Move 1\n"
                                       + "Turn left\n";

            // acting
            fakeForm.GetType().GetMethod("MetricsButton_Click",
                System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance)
                ?.Invoke(fakeForm, [null!, EventArgs.Empty]);

            // asserting
            Assert.Contains("No. of valid commands", fakeForm.OutputBox.Text);
        }


        [Fact]
        public void ExecuteProgramButton_Test()
        {
            // arranging
            var fakeForm = MakeFakeForm(emptyGrid);
            fakeForm.EditorWindow.Text = "Move 1\n"
                                       + "Turn left\n";

            // acting
            fakeForm.GetType().GetMethod("button1_Click",  // still couldn't be bothered with actually renaming this button
                System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance)
                ?.Invoke(fakeForm, [null!, EventArgs.Empty]);

            // asserting
            Assert.Contains("Output:", fakeForm.OutputBox.Text);
        }

        [Fact]
        public void ClearGridButton_Test()
        {
            // arranging
            var fakeForm = MakeFakeForm(filledGrid);

            // acting
            fakeForm.GetType().GetMethod("clearGridButton_Click",  // still couldn't be bothered with actually renaming this button
                System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance)
                ?.Invoke(fakeForm, [null!, EventArgs.Empty]);

            // asserting
            Assert.Equal(fakeForm._grid.Cells, emptyGrid.Cells);
        }

        [Fact]
        public void ResetPlayerButton_Test()
        {
            // arranging
            var fakeForm = MakeFakeForm(emptyGrid);

            // acting
            fakeForm.GetType().GetMethod("ResetPlayerButton_Click",  // still couldn't be bothered with actually renaming this button
                System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance)
                ?.Invoke(fakeForm, [null!, EventArgs.Empty]);

            // asserting
            Assert.Equal(Vector2.Zero, fakeForm._player.Position);
        }
    }
}
