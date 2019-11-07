using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using Timer = System.Windows.Forms.Timer;

namespace TowerOfHanoiUI
{
    public partial class TowerOfHanoiForm : Form
    {
        private const int POLE_WIDTH = 10;
        private const int PADDING_TOP = 200;
        private const int PADDING_BETWEEN_POLES = 5;
        private const int POLE_HEIGHT = 250;
        private const int TICK_PERIOD = 190;
        private const int INITIAL_SPEED_VALUE = 2000;

        private string m_defaultTextBoxValue = "3";
        private int m_numberOfPoles;
        private int m_numberOfDiscs;
        private int m_distanceFromPoleToPole;
        private int m_timeBetweenTicks = INITIAL_SPEED_VALUE;
        private bool m_isShowingSolution = true;        
        private bool m_runJustOnce = true;
        private int[] m_polesXCoordinates;

        Controller m_controller;
        WorkerThreadClass m_workerThread;
        FormController m_formController;

        public TowerOfHanoiForm(WorkerThreadClass workerThread)
        {
            InitializeComponent();
            m_controller = new Controller();
            m_formController = new FormController(this, m_controller);
            this.m_workerThread = workerThread;
            drawArea.BackColor = Color.LightGray;
            polesNumber.Text = m_defaultTextBoxValue;
            discNumber.Text= m_defaultTextBoxValue;
            this.MinimumSize = new Size(838, 517);
            invalidPoleNumber.Text = " ";
            invalidDiscNumber.Text = " ";
        }

        private void startButton_Click(object sender, EventArgs e)
        {
            if (m_isShowingSolution)
            {
                animationSpeed.Interval = m_timeBetweenTicks;
                animationSpeed.Start();

                InitiateTowerOfHanoiSolution();

                startButton.BackColor = Color.Red;
                startButton.Text = "Stop";
                m_isShowingSolution = false;
            }
            else
            {
                ResetToStartState();
            }  
        }

        public void InitiateTowerOfHanoiSolution()
        {
            if (m_runJustOnce)
            {
                this.animationSpeed.Tick += new EventHandler(this.TimerTicker);
                m_runJustOnce = false;
            }
        }

        private void ResetToStartState()
        {
            invalidPoleNumber.Text = " ";
            invalidDiscNumber.Text = " ";
            animationSpeed.Enabled = false;
            startButton.BackColor = Color.Green;
            startButton.Text = "Start";
            m_isShowingSolution = true;
        }

        private void DrawPoles(int height)
        {
            Graphics graphics = drawArea.CreateGraphics();
            SolidBrush brush = new SolidBrush(Color.CadetBlue);
            graphics.Clear(Color.Beige);

            int width = m_distanceFromPoleToPole / 2 - PADDING_BETWEEN_POLES;            
            int poleCount = 0;

            for(int i = width;i <= drawArea.Width; i+= m_distanceFromPoleToPole)
            {
                Rectangle poleToDraw = new Rectangle(i, height - PADDING_TOP, POLE_WIDTH, POLE_HEIGHT);
                graphics.DrawRectangle(Pens.CornflowerBlue, poleToDraw);
                graphics.FillRectangle(brush, poleToDraw);
                m_polesXCoordinates[poleCount] = i;
                poleCount++;
            }

            graphics.Dispose();
        }

        public void DrawBoard()
        {            
            DrawPoles(drawArea.Height);
            int poleCount = 0;

            foreach (Pole pole in m_controller.GetPoles())
            {
               pole.DrawPole(this, m_polesXCoordinates[poleCount], drawArea.Height);
               poleCount++;
            }
        }

        public void DrawDisc(int polePosition, int y,int discWidth)
        {
            //use using
            Graphics graphics = drawArea.CreateGraphics();
            Rectangle newDisc = new Rectangle((polePosition - discWidth) + PADDING_BETWEEN_POLES, y, discWidth * 2, POLE_WIDTH);
            graphics.DrawRectangle(Pens.MediumSlateBlue, newDisc);
            SolidBrush brush = new SolidBrush(Color.MediumOrchid);
            graphics.FillRectangle(brush, newDisc);
            graphics.Dispose();
        }

        private void drawInitialBoard_Click(object sender, EventArgs e)
        {
            ResetValues();
            ResetToStartState();
            m_numberOfDiscs = 0;
            m_numberOfPoles = 0;
            this.m_numberOfDiscs = int.Parse(discNumber.Text);
            this.m_numberOfPoles = int.Parse(polesNumber.Text);

            double percentage = 1.0 / m_numberOfPoles;
            this.m_distanceFromPoleToPole = Convert.ToInt32(drawArea.Width * percentage);
            int discWidth = m_distanceFromPoleToPole / 2 - PADDING_BETWEEN_POLES;

            m_controller.InitializePoles(m_numberOfPoles);
            m_controller.SetMaximumAmount(m_numberOfDiscs);
            m_controller.InitializeDiscs(m_numberOfDiscs, discWidth);
            m_polesXCoordinates = new int[m_numberOfPoles];
            DrawBoard();
            startButton.Visible = true;
        }
        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            animationSpeed.Interval = INITIAL_SPEED_VALUE;
            animationSpeed.Interval -= trackBar1.Value * TICK_PERIOD;
            m_timeBetweenTicks = animationSpeed.Interval;
        }
        private void TimerTicker(object sender, EventArgs e)
        {
            if (m_controller.IsPuzzleComplete())
            {
                animationSpeed.Enabled = false;
                startButton.Visible = false;
                startButton.BackColor = Color.Green;
            }
            else
            {
                m_workerThread.EnqueueTask(m_formController);
            }                     
        }
        private void resetButton_Click(object sender, EventArgs e)
        {
            ResetValues();
            ResetToStartState();
        }

        private void ResetValues()
        {
            //use using
            Graphics graphics = drawArea.CreateGraphics();
            m_numberOfDiscs = 0;
            m_numberOfPoles = 0;
            m_controller = new Controller();
            m_formController = new FormController(this, m_controller);
            graphics.Clear(Color.LightGray);
            startButton.Visible = false;
            graphics.Dispose();
        }

        private void anotherWindowButton_Click(object sender, EventArgs e)
        {
            TowerOfHanoiForm anotherForm = new TowerOfHanoiForm(m_workerThread);
            Controller anotherController = new Controller();
            FormController anotherFormController = new FormController(anotherForm, anotherController);

            anotherForm.Show();
        }

        private void discNumber_Validating(object sender, CancelEventArgs e)
        {
            string errorMsg;

            if (!ValidNumberOfDiscs(discNumber.Text, out errorMsg))
            {
                discNumber.Text = "3";
                e.Cancel = true;
                invalidDiscNumber.Text = errorMsg;                
            }
        }

        private void polesNumber_Validating(object sender, CancelEventArgs e)
        {
            string errorMsg;

            if (!ValidNumberOfPoles(polesNumber.Text, out errorMsg))
            {
                polesNumber.Text = "3";
                e.Cancel = true;
                invalidPoleNumber.Text = errorMsg;
            }
        }

        private bool ValidNumberOfDiscs(string input, out string errorMessage)
        {
            if (input.Length > 2)
            {
                errorMessage = "Enter a single digit number.";
                return false;
            }

            if (!char.IsNumber(input[0]))
            {
                errorMessage = "Enter a number.";
                return false;
            }

            if (int.Parse(input) <= 1 || int.Parse(input) >= 21)
            {
                errorMessage = "Enter number between 2 and 20";
                return false;
            }

            errorMessage = " "; 
            return true;
        }

        private bool ValidNumberOfPoles(string input, out string errorMessage)
        {
            if (input.Length > 2)
            {
                errorMessage = "Enter a single digit number.";
                return false;
            }

            if (!char.IsNumber(input[0]))
            {
                errorMessage = "Enter a number.";
                return false;
            }

            if (int.Parse(input) <= 2 || int.Parse(input) >= 13)
            {
                errorMessage = "Enter number between 3 and 12";
                return false;
            }

            errorMessage = " ";
            return true;
        }

        private void drawArea_Resize(object sender, EventArgs e)
        {
            double percentage = 1.0 / m_numberOfPoles;
            this.m_distanceFromPoleToPole = Convert.ToInt32(drawArea.Width * percentage);
            int width = m_distanceFromPoleToPole / 2 - PADDING_BETWEEN_POLES;

            m_controller.UpdateWidth(width, m_numberOfDiscs);

            DrawBoard();
        }
    }
}
