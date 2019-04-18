using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
using System.Threading;

namespace Task12
{
    public partial class MainForm : Form
    {

        public ArrayWithLineValues arrayWithValues;
        private int _currentHighlightedIndex1;
        private int _currentHighlightedIndex2;
        public MainForm()
        {
            InitializeComponent();
            arrayWithValues = new ArrayWithLineValues(MainCanvas.Width / 10);
        }

        public void ShowArray(PaintEventArgs e)
        {
            var currentPen = new Pen(Color.Red, 5);
            var graphics = e.Graphics;
            for (int i = 0; i < arrayWithValues.Length; i++)
            {
                if (arrayWithValues[i].XPosition == null) // showing array for the first time (XPosition is null)
                {
                    if (i == _currentHighlightedIndex1 || i == _currentHighlightedIndex2)
                    {
                        var newPen = new Pen(Color.Blue, 5);
                        graphics.DrawLine(newPen, i * 10 + 5, MainCanvas.Height, i * 10 + 5,
                            MainCanvas.Height - arrayWithValues[i]);
                    }

                    else
                        graphics.DrawLine(currentPen, i * 10 + 5, MainCanvas.Height, i * 10 + 5,
                            MainCanvas.Height - arrayWithValues[i]);

                    arrayWithValues[i].XPosition = i * 10 + 5;
                }
                else
                {
                    if (i == _currentHighlightedIndex1 || i == _currentHighlightedIndex2)
                    {
                        var newPen = new Pen(Color.Blue, 5);
                        graphics.DrawLine(newPen, (int)arrayWithValues[i].XPosition, MainCanvas.Height, (int)arrayWithValues[i].XPosition,
                            MainCanvas.Height - arrayWithValues[i]);
                    }

                    else
                        graphics.DrawLine(currentPen, i * 10 + 5, MainCanvas.Height, i * 10 + 5,
                            MainCanvas.Height - arrayWithValues[i]);
                }
            }
        }

        private void MainCanvas_Paint(object sender, PaintEventArgs e)
        {
            ShowArray(e);
        }

        private void RenderCanvas(int index1, int index2)
        {
            if (index1 != -1) // to skip replacing elements for last showing
            {
                if (index1 > index2)
                {
                    int temp = index1;
                    index1 = index2;
                    index2 = temp;
                }

                {
                    int? temp = arrayWithValues[index1].XPosition;
                    while (arrayWithValues[index2].XPosition < temp)
                    {
                        arrayWithValues[index1].XPosition-=4;
                        arrayWithValues[index2].XPosition+=4;
                        MainCanvas.Refresh();
                        Thread.Sleep(10);
                    }
                }
            }
            MainCanvas.Refresh();
        }

        public delegate void RenderDelegate(int index1, int index2);
        private void button1_Click(object sender, EventArgs e)
        {
            Console.WriteLine(arrayWithValues);
            RenderDelegate renderDelegate = RenderCanvas;
            arrayWithValues.SelectionSort(ref _currentHighlightedIndex1, ref _currentHighlightedIndex2, renderDelegate);
            Console.WriteLine(arrayWithValues);
        }
    }
}
