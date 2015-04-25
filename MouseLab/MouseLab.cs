using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace MouseLab
{
    public partial class frmMouseLab : Form
    {
        const int LEFTDOWN = 0;
        const int LEFTUP = 1;
        const int MIDDOWN = 2;
        const int MIDUP = 3;
        const int RIGHTDOWN = 4;
        const int RIGHTUP = 5;
        const int ALLUP = 7;

        Bitmap bGraph;
        Graphics gGraph;

        DateTime startTime;
        DateTime stopTime;

        Dictionary<int, string> buttons;
        Dictionary<double, int> data;

        Point loggingPosition;
        bool logButtons;
        bool running;
        int maxY;
        int minY;
        int mousePos;

        public frmMouseLab()
        {
            InitializeComponent();
        }

        private void frmMouseLab_Load(object sender, EventArgs e)
        {
            logButtons = true;
            running = false;

            bGraph = new Bitmap(imgGraph.Width, imgGraph.Height);
            gGraph = Graphics.FromImage(bGraph);
            imgGraph.Image = bGraph;

            loggingPosition = new Point(Left + imgGraph.Left + imgGraph.Width / 2,
                                        Top + imgGraph.Top + imgGraph.Height);

            buttons = new Dictionary<int, string>();
            buttons.Add(LEFTDOWN, "Left Down");
            buttons.Add(LEFTUP, "Left Up");
            buttons.Add(MIDDOWN, "Middle Down");
            buttons.Add(MIDUP, "Middle Up");
            buttons.Add(RIGHTDOWN, "Right Down");
            buttons.Add(RIGHTUP, "Right Up");
            buttons.Add(ALLUP, "All Up");

            data = new Dictionary<double, int>();

            maxY = 0;
            minY = 0;
            mousePos = 0;
        }

        private void frmMouseLab_Resize(object sender, EventArgs e)
        {
            bGraph = new Bitmap(imgGraph.Width, imgGraph.Height);
            gGraph = Graphics.FromImage(bGraph);
        }

        private void UpdateStatus()
        {
            if (running)
            {
                tslStatus.Text = "Running";

                if (!logButtons)
                {
                    tslStatus.Text += ": Click to stop";
                }
            }
            else
            {
                double runTime = (stopTime - startTime).TotalSeconds;
                if (runTime == 0)
                {
                    tslStatus.Text = "Ready";
                }
                else
                {
                    tslStatus.Text = "Ran for " + (stopTime - startTime).TotalSeconds + " seconds: Ready";
                }
            }
        }

        private void StartRecording()
        {
            mousePos = 0;
            maxY = 0;
            minY = 0;
            startTime = DateTime.Now;
            data.Clear();
            lstData.Items.Clear();
            tmrTimer.Enabled = true;
            running = true;
            Cursor.Position = loggingPosition;
            btnGo.Text = "Stop Recording";
            UpdateStatus();
        }

        private void StopRecording()
        {
            stopTime = DateTime.Now;
            tmrTimer.Enabled = false;
            running = false;
            btnGo.Text = "Start Recording";
            UpdateStatus();
        }

        private void StoreClick(MouseEventArgs e, bool isDown)
        {
            if (logButtons)
            {
                double time = (DateTime.Now - startTime).TotalSeconds;
                string button = "";

                try
                {
                    switch (e.Button)
                    {
                        case System.Windows.Forms.MouseButtons.Left:
                            if (isDown)
                            {
                                data.Add(time, LEFTDOWN);
                                button = "Left Down";
                            }
                            else
                            {
                                data.Add(time, LEFTUP);
                                button = "Left Up";
                            }
                            break;
                        case System.Windows.Forms.MouseButtons.Middle:
                            if (isDown)
                            {
                                data.Add(time, MIDDOWN);
                                button = "Middle Down";
                            }
                            else
                            {
                                data.Add(time, MIDUP);
                                button = "Middle Up";
                            }
                            break;
                        case System.Windows.Forms.MouseButtons.Right:
                            if (isDown)
                            {
                                data.Add(time, RIGHTDOWN);
                                button = "Right Down";
                            }
                            else
                            {
                                data.Add(time, RIGHTUP);
                                button = "Right Up";
                            }
                            break;
                        default:
                            break;
                    }
                }
                catch (ArgumentException)
                {
                    try
                    {
                        data.Add(time, ALLUP);
                    }
                    catch (ArgumentException)
                    { }
                }

                lstData.Items.Add(time + "s: " + button);
            }
            else
            {
                if (isDown)
                {
                    StopRecording();
                }
            }
        }

        private void StoreMove(MouseEventArgs e)
        {
            if (!logButtons && running && Cursor.Position != loggingPosition)
            {
                double time = (DateTime.Now - startTime).TotalSeconds;
                mousePos += 248 - e.Y;
                Cursor.Position = loggingPosition;

                if (mousePos > maxY)
                {
                    maxY = mousePos;
                }
                else if (mousePos < minY)
                {
                    minY = mousePos;
                }

                try
                {
                    data.Add(time, mousePos);
                }
                catch (ArgumentException)
                { }

                lstData.Items.Add(time + "s: " + mousePos);
            }
        }

        private void imgGraph_MouseDown(object sender, MouseEventArgs e)
        {
            StoreClick(e, true);
        }

        private void imgGraph_MouseMove(object sender, MouseEventArgs e)
        {
            StoreMove(e);
        }

        private void imgGraph_MouseUp(object sender, MouseEventArgs e)
        {
            StoreClick(e, false);
        }

        private void btnGo_Click(object sender, EventArgs e)
        {
            running = !running;

            if (running)
            {
                StartRecording();
            }
            else
            {
                StopRecording();
            }

        }

        private void tmrTimer_Tick(object sender, EventArgs e)
        {
            gGraph.Clear(Color.Black);

            if (logButtons)
            {
                int down = imgGraph.Height / 4;
                int up = 3 * imgGraph.Height / 4;

                Pen pen = Pens.White;
                Point point1 = new Point(0, up);

                foreach (var d in data)
                {
                    try
                    {
                        double timeRatio = d.Key / (DateTime.Now - startTime).TotalSeconds;

                        Point point2 = new Point((int)(timeRatio * imgGraph.Width), d.Value % 2 == 0 ? down : up);

                        gGraph.DrawLine(pen, point1, new Point(point2.X, point1.Y));

                        switch (d.Value)
                        {
                            case 0:
                                pen = Pens.Red;
                                break;
                            case 1:
                                pen = Pens.White;
                                break;
                            case 2:
                                pen = Pens.Green;
                                break;
                            case 3:
                                pen = Pens.White;
                                break;
                            case 4:
                                pen = Pens.Blue;
                                break;
                            case 5:
                                pen = Pens.White;
                                break;
                            default:
                                pen = Pens.Gray;
                                break;
                        }

                        gGraph.DrawLine(pen, new Point(point2.X, point1.Y), point2);

                        point1.X = point2.X;
                        point1.Y = point2.Y;
                    }
                    catch (DivideByZeroException)
                    { }
                }

                gGraph.DrawLine(pen, point1, new Point(imgGraph.Width, point1.Y));
            }
            else if (!logButtons)
            {
                int midPoint = imgGraph.Height / 2;

                Pen pen = Pens.White;
                Point point1 = new Point(0, midPoint);

                foreach (var d in data)
                {
                    try
                    {
                        double timeRatio = d.Key / (DateTime.Now - startTime).TotalSeconds;

                        Point point2 = new Point((int)(timeRatio * imgGraph.Width),
                                                 midPoint + ((3 * imgGraph.Height / 4) / (maxY - minY)) * -d.Value);

                        gGraph.DrawLine(pen, point1, new Point(point2.X, point1.Y));

                        if (d.Value > 0)
                        {
                                pen = Pens.Green;
                        }
                        else if (d.Value < 0)
                        {
                                pen = Pens.Red;
                        }

                        gGraph.DrawLine(pen, new Point(point2.X, point1.Y), point2);

                        point1.X = point2.X;
                        point1.Y = point2.Y;
                    }
                    catch (DivideByZeroException)
                    { }
                }

                gGraph.DrawLine(pen, point1, new Point(imgGraph.Width, point1.Y));
            }

            imgGraph.Invalidate();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (running)
            {
                StopRecording();
            }

            if (data.Count > 0)
            {
                dlgSave.Filter = "Comma-Separated Values|*.csv";
                dlgSave.AddExtension = true;
                dlgSave.DefaultExt = ".csv";

                DialogResult result = dlgSave.ShowDialog();

                if (result == System.Windows.Forms.DialogResult.OK)
                {
                    StreamWriter output = new StreamWriter(dlgSave.FileName);

                    output.WriteLine("Time (s),Value");
                    output.WriteLine("0,Start");
                    foreach (var d in data)
                    {
                        if (logButtons)
                        {
                            output.WriteLine(d.Key + "," + buttons[d.Value]);
                        }
                        else
                        {
                            output.WriteLine(d.Key + "," + d.Value);
                        }
                    }
                    output.Close();
                }
            }
        }

        private void rdoButtons_CheckedChanged(object sender, EventArgs e)
        {
            logButtons = rdoButtons.Checked;
        }

        private void rdoYAxis_CheckedChanged(object sender, EventArgs e)
        {
            logButtons = !rdoYAxis.Checked;
        }

        private void frmMouseLab_Move(object sender, EventArgs e)
        {
            loggingPosition = new Point(Left + imgGraph.Left + imgGraph.Width / 2,
                                        Top + imgGraph.Top + imgGraph.Height);
        }
    }
}
