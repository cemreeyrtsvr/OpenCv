using System;
using System.Drawing;
using System.Windows.Forms;
using OpenCvSharp;
using OpenCvSharp.Extensions;

namespace OpenCv
{
    public partial class Form1 : Form
    {
        
        VideoCapture capture;
        Mat frame;
        CascadeClassifier cascade;

        
        public Form1()
        {
            InitializeComponent(); 

         
            try
            {
                frame = new Mat();
                cascade = new CascadeClassifier("haarcascade_frontalface_default.xml");

              
            }
            catch (Exception ex)
            {
                MessageBox.Show("Model yüklenirken bir hata oluþtu:\n\n" + ex.Message);
                btnStart.Enabled = false;
            }
        }

        
        private void Form1_Load(object sender, EventArgs e)
        {
        }

        
        private void btnStart_Click(object sender, EventArgs e)
        {
            if (btnStart.Text == "Kamerayý Baþlat")
            {
                
                try
                {
                    if (capture == null) 
                    {
                        capture = new VideoCapture(0, VideoCaptureAPIs.MSMF);
                        capture.FrameWidth = 640;
                        capture.FrameHeight = 480;
                    }

                    
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Kamera baþlatýlamadý:\n\n" + ex.Message);
                    return;
                }

                
                timer1.Start();
                btnStart.Text = "Kamerayý Durdur";
            }
            else
            {
                timer1.Stop();
                btnStart.Text = "Kamerayý Baþlat";
            }
        }

        
        private void timer1_Tick(object sender, EventArgs e)
        {
            try
            {
                
                capture.Read(frame);
                if (frame.Empty()) return;

                Mat gray = new Mat();
                Cv2.CvtColor(frame, gray, ColorConversionCodes.BGR2GRAY);

                OpenCvSharp.Rect[] faces = cascade.DetectMultiScale(gray, 1.1, 3, HaarDetectionTypes.ScaleImage);

                foreach (OpenCvSharp.Rect face in faces)
                {
                    Cv2.Rectangle(frame, face, Scalar.Red, 2);
                }

                pictureBox1.Image = frame.ToBitmap();
                gray.Dispose();
            }
            catch (Exception ex)
            {
                timer1.Stop();
                btnStart.Text = "Kamerayý Baþlat";
                MessageBox.Show("Video akýþýnda hata oluþtu:\n\n" + ex.ToString());
            }
        }

        
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            timer1?.Stop();
            capture?.Release();
            frame?.Dispose();
            cascade?.Dispose();
        }
    }
}