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
        private const int _columnSize = 20;
        private const int _lineWidth = _columnSize / 2;
        private int typeOfSort = 0; // 1 - SelectionSort, 2 - CountingSort
        private int _timeOut = 20;
        private int _numOfComparisons = 0;
        private int _numOfSwaps = 0;

        public MainForm()
        {
            InitializeComponent();
            arrayWithValues = new ArrayWithLineValues(MainCanvas.Width / _columnSize);
        }

        public void ShowArray(PaintEventArgs e)
        {
            var currentPen = new Pen(Color.Red, _lineWidth);
            var graphics = e.Graphics;
            for (int i = 0; i < arrayWithValues.Length; i++)
            {
                if (arrayWithValues[i].XPosition == null) // showing array for the first time (XPosition is null)
                {
                    if (i == _currentHighlightedIndex1 || i == _currentHighlightedIndex2)
                    {
                        var newPen = new Pen(Color.Blue, _lineWidth);
                        graphics.DrawLine(newPen, i * _columnSize + 5, MainCanvas.Height, i * _columnSize + 5,
                            MainCanvas.Height - arrayWithValues[i]);
                    }

                    else
                        graphics.DrawLine(currentPen, i * _columnSize + 5, MainCanvas.Height, i * _columnSize + 5,
                            MainCanvas.Height - arrayWithValues[i]);

                    arrayWithValues[i].XPosition = i * _columnSize + 5;
                }
                else
                {
                    if (i == _currentHighlightedIndex1 || i == _currentHighlightedIndex2)
                    {
                        var newPen = new Pen(Color.Blue, _lineWidth);
                        graphics.DrawLine(newPen, (int)arrayWithValues[i].XPosition, MainCanvas.Height, (int)arrayWithValues[i].XPosition,
                            MainCanvas.Height - arrayWithValues[i]);
                    }

                    else
                        graphics.DrawLine(currentPen, i * _columnSize + 5, MainCanvas.Height, i * _columnSize + 5,
                            MainCanvas.Height - arrayWithValues[i]);
                }
            }
        }

        private void MainCanvas_Paint(object sender, PaintEventArgs e)
        {
            ShowArray(e);
        }

        private void RenderCanvasWithSwaps(int index1, int index2)
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
                        Thread.Sleep(_timeOut);
                    }
                }
            }
            MainCanvas.Refresh();
            
        }

        private void RenderCanvasWithoutSwaps(int index1, int index2)
        {
            MainCanvas.Refresh();

            Thread.Sleep(_timeOut*2);
        }

        public delegate void RenderDelegate(int index1, int index2);
        private void button1_Click(object sender, EventArgs e)
        {
            Console.WriteLine(arrayWithValues);
            if (typeOfSort == 0)
            {
                MessageBox.Show("Try choosing a type of sorting via radiobutton");
                return;
            }
            if (typeOfSort == 1)
            {
                RenderDelegate renderDelegateForSwapping = RenderCanvasWithSwaps;
                RenderDelegate renderDelegateForChoosing = RenderCanvasWithoutSwaps;
                arrayWithValues.SelectionSort(ref _currentHighlightedIndex1, ref _currentHighlightedIndex2, renderDelegateForChoosing, renderDelegateForSwapping, out _numOfComparisons, out _numOfSwaps);
            }

            if (typeOfSort == 2)
            {
                RenderDelegate renderDelegate = RenderCanvasWithoutSwaps;
                arrayWithValues.CountingSort(ref _currentHighlightedIndex1, ref _currentHighlightedIndex2, renderDelegate, out _numOfComparisons, out _numOfSwaps);
            }

            this.ComparisonsBox.Text = _numOfComparisons.ToString();
            this.SwapsBox.Text = _numOfSwaps.ToString();

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void CountingRadio_CheckedChanged(object sender, EventArgs e)
        {
            RadioButton Sender = (RadioButton) sender;
            if (Sender.Checked)
                typeOfSort = 2;
        }

        private void SelectionRadio_CheckedChanged(object sender, EventArgs e)
        {
            RadioButton Sender = (RadioButton)sender;
            if (Sender.Checked)
                typeOfSort = 1;
        }

        private void ResetButton_Click(object sender, EventArgs e)
        {
            this.arrayWithValues = new ArrayWithLineValues(this.arrayWithValues.Length);
            MainCanvas.Refresh();
        }
    }
}
