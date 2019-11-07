namespace TowerOfHanoiUI
{
    partial class TowerOfHanoiForm
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
            this.components = new System.ComponentModel.Container();
            this.animationSpeed = new System.Windows.Forms.Timer(this.components);
            this.startButton = new System.Windows.Forms.Button();
            this.drawInitialBoard = new System.Windows.Forms.Button();
            this.polesNumber = new System.Windows.Forms.TextBox();
            this.Speed = new System.Windows.Forms.Label();
            this.trackBar1 = new System.Windows.Forms.TrackBar();
            this.NumberOfDiscs = new System.Windows.Forms.Label();
            this.discNumber = new System.Windows.Forms.TextBox();
            this.NumberOfPoles = new System.Windows.Forms.Label();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.resetButton = new System.Windows.Forms.Button();
            this.anotherWIndowButton = new System.Windows.Forms.Button();
            this.drawArea = new System.Windows.Forms.PictureBox();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.invalidPoleNumber = new System.Windows.Forms.Label();
            this.invalidDiscNumber = new System.Windows.Forms.Label();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).BeginInit();
            this.tableLayoutPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.drawArea)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // startButton
            // 
            this.startButton.BackColor = System.Drawing.Color.Green;
            this.startButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.startButton.Font = new System.Drawing.Font("Microsoft YaHei", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.startButton.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.startButton.Location = new System.Drawing.Point(4, 4);
            this.startButton.Margin = new System.Windows.Forms.Padding(4);
            this.startButton.Name = "startButton";
            this.startButton.Size = new System.Drawing.Size(170, 71);
            this.startButton.TabIndex = 6;
            this.startButton.Text = "Start";
            this.startButton.UseVisualStyleBackColor = false;
            this.startButton.Visible = false;
            this.startButton.Click += new System.EventHandler(this.startButton_Click);
            // 
            // drawInitialBoard
            // 
            this.drawInitialBoard.BackColor = System.Drawing.SystemColors.HotTrack;
            this.drawInitialBoard.Dock = System.Windows.Forms.DockStyle.Fill;
            this.drawInitialBoard.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.drawInitialBoard.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.drawInitialBoard.Location = new System.Drawing.Point(4, 242);
            this.drawInitialBoard.Margin = new System.Windows.Forms.Padding(4);
            this.drawInitialBoard.Name = "drawInitialBoard";
            this.drawInitialBoard.Size = new System.Drawing.Size(170, 64);
            this.drawInitialBoard.TabIndex = 12;
            this.drawInitialBoard.Text = "Draw ";
            this.drawInitialBoard.UseVisualStyleBackColor = false;
            this.drawInitialBoard.Click += new System.EventHandler(this.drawInitialBoard_Click);
            // 
            // polesNumber
            // 
            this.polesNumber.Dock = System.Windows.Forms.DockStyle.Fill;
            this.polesNumber.Location = new System.Drawing.Point(4, 109);
            this.polesNumber.Margin = new System.Windows.Forms.Padding(4);
            this.polesNumber.Name = "polesNumber";
            this.polesNumber.Size = new System.Drawing.Size(170, 22);
            this.polesNumber.TabIndex = 7;
            this.polesNumber.Validating += new System.ComponentModel.CancelEventHandler(this.polesNumber_Validating);
            // 
            // Speed
            // 
            this.Speed.AutoSize = true;
            this.Speed.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Speed.Location = new System.Drawing.Point(4, 409);
            this.Speed.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Speed.Name = "Speed";
            this.Speed.Size = new System.Drawing.Size(170, 22);
            this.Speed.TabIndex = 15;
            this.Speed.Text = "Animation Speed";
            // 
            // trackBar1
            // 
            this.trackBar1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.trackBar1.Location = new System.Drawing.Point(4, 435);
            this.trackBar1.Margin = new System.Windows.Forms.Padding(4);
            this.trackBar1.Name = "trackBar1";
            this.trackBar1.Size = new System.Drawing.Size(170, 33);
            this.trackBar1.TabIndex = 14;
            this.trackBar1.Scroll += new System.EventHandler(this.trackBar1_Scroll);
            // 
            // NumberOfDiscs
            // 
            this.NumberOfDiscs.AutoSize = true;
            this.NumberOfDiscs.Dock = System.Windows.Forms.DockStyle.Fill;
            this.NumberOfDiscs.Location = new System.Drawing.Point(4, 160);
            this.NumberOfDiscs.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.NumberOfDiscs.Name = "NumberOfDiscs";
            this.NumberOfDiscs.Size = new System.Drawing.Size(170, 23);
            this.NumberOfDiscs.TabIndex = 10;
            this.NumberOfDiscs.Text = "Number Of Discs";
            // 
            // discNumber
            // 
            this.discNumber.Dock = System.Windows.Forms.DockStyle.Fill;
            this.discNumber.Location = new System.Drawing.Point(4, 187);
            this.discNumber.Margin = new System.Windows.Forms.Padding(4);
            this.discNumber.Name = "discNumber";
            this.discNumber.Size = new System.Drawing.Size(170, 22);
            this.discNumber.TabIndex = 9;
            this.discNumber.Validating += new System.ComponentModel.CancelEventHandler(this.discNumber_Validating);
            // 
            // NumberOfPoles
            // 
            this.NumberOfPoles.AutoSize = true;
            this.NumberOfPoles.Dock = System.Windows.Forms.DockStyle.Fill;
            this.NumberOfPoles.Location = new System.Drawing.Point(4, 79);
            this.NumberOfPoles.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.NumberOfPoles.Name = "NumberOfPoles";
            this.NumberOfPoles.Size = new System.Drawing.Size(170, 26);
            this.NumberOfPoles.TabIndex = 8;
            this.NumberOfPoles.Text = "Number Of Poles";
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 2;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 47.67442F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 52.32558F));
            this.tableLayoutPanel2.Controls.Add(this.resetButton, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.anotherWIndowButton, 1, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 313);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(172, 93);
            this.tableLayoutPanel2.TabIndex = 19;
            // 
            // resetButton
            // 
            this.resetButton.BackColor = System.Drawing.SystemColors.HotTrack;
            this.resetButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.resetButton.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.resetButton.Location = new System.Drawing.Point(3, 3);
            this.resetButton.Name = "resetButton";
            this.resetButton.Size = new System.Drawing.Size(76, 87);
            this.resetButton.TabIndex = 17;
            this.resetButton.Text = "Reset";
            this.resetButton.UseVisualStyleBackColor = false;
            this.resetButton.Click += new System.EventHandler(this.resetButton_Click);
            // 
            // anotherWIndowButton
            // 
            this.anotherWIndowButton.BackColor = System.Drawing.SystemColors.HotTrack;
            this.anotherWIndowButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.anotherWIndowButton.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.anotherWIndowButton.Location = new System.Drawing.Point(85, 3);
            this.anotherWIndowButton.Name = "anotherWIndowButton";
            this.anotherWIndowButton.Size = new System.Drawing.Size(84, 87);
            this.anotherWIndowButton.TabIndex = 16;
            this.anotherWIndowButton.Text = "Create Window";
            this.anotherWIndowButton.UseVisualStyleBackColor = false;
            this.anotherWIndowButton.Click += new System.EventHandler(this.anotherWindowButton_Click);
            // 
            // drawArea
            // 
            this.drawArea.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.drawArea.Location = new System.Drawing.Point(188, 4);
            this.drawArea.Margin = new System.Windows.Forms.Padding(4);
            this.drawArea.Name = "drawArea";
            this.drawArea.Size = new System.Drawing.Size(630, 470);
            this.drawArea.TabIndex = 13;
            this.drawArea.TabStop = false;
            this.drawArea.Resize += new System.EventHandler(this.drawArea_Resize);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.invalidPoleNumber, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.trackBar1, 0, 10);
            this.tableLayoutPanel1.Controls.Add(this.discNumber, 0, 5);
            this.tableLayoutPanel1.Controls.Add(this.startButton, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.NumberOfDiscs, 0, 4);
            this.tableLayoutPanel1.Controls.Add(this.NumberOfPoles, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 0, 8);
            this.tableLayoutPanel1.Controls.Add(this.Speed, 0, 9);
            this.tableLayoutPanel1.Controls.Add(this.drawInitialBoard, 0, 7);
            this.tableLayoutPanel1.Controls.Add(this.polesNumber, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.invalidDiscNumber, 0, 6);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 11;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 79F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 26F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 31F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 24F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 23F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 33F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 22F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 72F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 99F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 22F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 21F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(178, 472);
            this.tableLayoutPanel1.TabIndex = 20;
            // 
            // invalidPoleNumber
            // 
            this.invalidPoleNumber.AutoSize = true;
            this.invalidPoleNumber.Dock = System.Windows.Forms.DockStyle.Fill;
            this.invalidPoleNumber.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.invalidPoleNumber.ForeColor = System.Drawing.Color.Red;
            this.invalidPoleNumber.Location = new System.Drawing.Point(3, 136);
            this.invalidPoleNumber.Name = "invalidPoleNumber";
            this.invalidPoleNumber.Size = new System.Drawing.Size(172, 24);
            this.invalidPoleNumber.TabIndex = 21;
            this.invalidPoleNumber.Text = "Invalid Number Of Poles";
            // 
            // invalidDiscNumber
            // 
            this.invalidDiscNumber.AutoSize = true;
            this.invalidDiscNumber.Dock = System.Windows.Forms.DockStyle.Fill;
            this.invalidDiscNumber.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.invalidDiscNumber.ForeColor = System.Drawing.Color.Red;
            this.invalidDiscNumber.Location = new System.Drawing.Point(3, 216);
            this.invalidDiscNumber.Name = "invalidDiscNumber";
            this.invalidDiscNumber.Size = new System.Drawing.Size(172, 22);
            this.invalidDiscNumber.TabIndex = 20;
            this.invalidDiscNumber.Text = "Invalid Number Of Discs";
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.ColumnCount = 2;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 22.48521F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 77.51479F));
            this.tableLayoutPanel3.Controls.Add(this.drawArea, 1, 0);
            this.tableLayoutPanel3.Controls.Add(this.tableLayoutPanel1, 0, 0);
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 1;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(822, 478);
            this.tableLayoutPanel3.TabIndex = 21;
            // 
            // TowerOfHanoiForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(822, 478);
            this.Controls.Add(this.tableLayoutPanel3);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "TowerOfHanoiForm";
            this.Text = "Tower Of Hanoi Application";
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).EndInit();
            this.tableLayoutPanel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.drawArea)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.tableLayoutPanel3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Timer animationSpeed;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Button resetButton;
        private System.Windows.Forms.Button anotherWIndowButton;
        private System.Windows.Forms.TextBox discNumber;
        private System.Windows.Forms.Label NumberOfDiscs;
        private System.Windows.Forms.TrackBar trackBar1;
        private System.Windows.Forms.Label Speed;
        private System.Windows.Forms.TextBox polesNumber;
        private System.Windows.Forms.Button drawInitialBoard;
        private System.Windows.Forms.Label NumberOfPoles;
        private System.Windows.Forms.Button startButton;
        private System.Windows.Forms.PictureBox drawArea;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label invalidPoleNumber;
        private System.Windows.Forms.Label invalidDiscNumber;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
    }
}

