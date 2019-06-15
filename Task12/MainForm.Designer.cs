namespace Task12
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.MainCanvas = new System.Windows.Forms.PictureBox();
            this.SortButton = new System.Windows.Forms.Button();
            this.ResetButton = new System.Windows.Forms.Button();
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.SelectionRadio = new System.Windows.Forms.RadioButton();
            this.CountingRadio = new System.Windows.Forms.RadioButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.ComparisonsBox = new System.Windows.Forms.Label();
            this.SwapsBox = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.MainCanvas)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // MainCanvas
            // 
            this.MainCanvas.BackColor = System.Drawing.Color.White;
            this.MainCanvas.Location = new System.Drawing.Point(115, 54);
            this.MainCanvas.Name = "MainCanvas";
            this.MainCanvas.Size = new System.Drawing.Size(868, 554);
            this.MainCanvas.TabIndex = 0;
            this.MainCanvas.TabStop = false;
            this.MainCanvas.Paint += new System.Windows.Forms.PaintEventHandler(this.MainCanvas_Paint);
            // 
            // SortButton
            // 
            this.SortButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SortButton.Location = new System.Drawing.Point(115, 722);
            this.SortButton.Name = "SortButton";
            this.SortButton.Size = new System.Drawing.Size(199, 71);
            this.SortButton.TabIndex = 1;
            this.SortButton.Text = "Sort";
            this.SortButton.UseVisualStyleBackColor = true;
            this.SortButton.Click += new System.EventHandler(this.button1_Click);
            // 
            // ResetButton
            // 
            this.ResetButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ResetButton.Location = new System.Drawing.Point(115, 835);
            this.ResetButton.Name = "ResetButton";
            this.ResetButton.Size = new System.Drawing.Size(199, 71);
            this.ResetButton.TabIndex = 2;
            this.ResetButton.Text = "Reset";
            this.ResetButton.UseVisualStyleBackColor = true;
            this.ResetButton.Click += new System.EventHandler(this.ResetButton_Click);
            // 
            // splitter1
            // 
            this.splitter1.Location = new System.Drawing.Point(0, 0);
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new System.Drawing.Size(3, 972);
            this.splitter1.TabIndex = 3;
            this.splitter1.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(442, 739);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(369, 37);
            this.label1.TabIndex = 4;
            this.label1.Text = "Number of comparisons:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(442, 856);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(277, 37);
            this.label2.TabIndex = 6;
            this.label2.Text = "Number of swaps:";
            // 
            // SelectionRadio
            // 
            this.SelectionRadio.AutoSize = true;
            this.SelectionRadio.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.875F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SelectionRadio.Location = new System.Drawing.Point(46, 14);
            this.SelectionRadio.Name = "SelectionRadio";
            this.SelectionRadio.Size = new System.Drawing.Size(223, 37);
            this.SelectionRadio.TabIndex = 8;
            this.SelectionRadio.TabStop = true;
            this.SelectionRadio.Text = "Selection sort";
            this.SelectionRadio.UseVisualStyleBackColor = true;
            this.SelectionRadio.CheckedChanged += new System.EventHandler(this.SelectionRadio_CheckedChanged);
            // 
            // CountingRadio
            // 
            this.CountingRadio.AutoSize = true;
            this.CountingRadio.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.875F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CountingRadio.Location = new System.Drawing.Point(301, 14);
            this.CountingRadio.Name = "CountingRadio";
            this.CountingRadio.Size = new System.Drawing.Size(219, 37);
            this.CountingRadio.TabIndex = 9;
            this.CountingRadio.TabStop = true;
            this.CountingRadio.Text = "Counting sort";
            this.CountingRadio.UseVisualStyleBackColor = true;
            this.CountingRadio.CheckedChanged += new System.EventHandler(this.CountingRadio_CheckedChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.CountingRadio);
            this.groupBox1.Controls.Add(this.SelectionRadio);
            this.groupBox1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.groupBox1.Location = new System.Drawing.Point(261, 634);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(580, 60);
            this.groupBox1.TabIndex = 10;
            this.groupBox1.TabStop = false;
            this.groupBox1.Enter += new System.EventHandler(this.groupBox1_Enter);
            // 
            // ComparisonsBox
            // 
            this.ComparisonsBox.AutoSize = true;
            this.ComparisonsBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ComparisonsBox.Location = new System.Drawing.Point(859, 739);
            this.ComparisonsBox.Name = "ComparisonsBox";
            this.ComparisonsBox.Size = new System.Drawing.Size(0, 37);
            this.ComparisonsBox.TabIndex = 11;
            // 
            // SwapsBox
            // 
            this.SwapsBox.AutoSize = true;
            this.SwapsBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SwapsBox.Location = new System.Drawing.Point(859, 852);
            this.SwapsBox.Name = "SwapsBox";
            this.SwapsBox.Size = new System.Drawing.Size(0, 37);
            this.SwapsBox.TabIndex = 12;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1074, 972);
            this.Controls.Add(this.SwapsBox);
            this.Controls.Add(this.ComparisonsBox);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.splitter1);
            this.Controls.Add(this.ResetButton);
            this.Controls.Add(this.SortButton);
            this.Controls.Add(this.MainCanvas);
            this.Name = "MainForm";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.MainCanvas)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox MainCanvas;
        private System.Windows.Forms.Button SortButton;
        private System.Windows.Forms.Button ResetButton;
        private System.Windows.Forms.Splitter splitter1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.RadioButton SelectionRadio;
        private System.Windows.Forms.RadioButton CountingRadio;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label ComparisonsBox;
        private System.Windows.Forms.Label SwapsBox;
    }
}

