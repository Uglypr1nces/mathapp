using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Media;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using System.Windows.Forms.Layout;
using System.Net;
using System.Net.Mail;

namespace MATH
{
    public partial class Form1 : Form
    {
        private const int NumberOfOperators = 2;
        private const int MaxPointsDefault = 15;
        private int answer = 0;
        private int points = -1;
        private int maxpoint = MaxPointsDefault;
        private int range = 10;
        private Random rnd = new Random();

        public Form1()
        {
            InitializeComponent();
            panel4.Hide();
            roundstarter();
            emailsender();
    }
        private void emailsender()
        {
            string senderEmail = "shpatavdiu74@gmail.com";
            string senderPassword = "gevg vbix oaka qpyd";

            // Recipient's email address
            string recipientEmail = "akonosuba3@gmail.com";

            // Create the email message
            MailMessage mail = new MailMessage(senderEmail, recipientEmail);
            mail.Subject = "Test Email";
            string message = " ";
            foreach (string item in listBox1.Items)
            {
                message = message + " " + item;
            }
            mail.Body = "this is a test";

            SmtpClient smtpClient = new SmtpClient("smtp.gmail.com");
            smtpClient.Port = 587;
            smtpClient.Credentials = new NetworkCredential(senderEmail, senderPassword);
            smtpClient.EnableSsl = true;
            smtpClient.UseDefaultCredentials = true;

            try
            {
                // Send the email
                smtpClient.Send(mail);
                Console.WriteLine("Email sent successfully.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error sending email: {ex.Message}");
            }

        }
        private void playSimpleSound(string soundname)
        {
            SoundPlayer simpleSound = new SoundPlayer(Path.Combine(Application.StartupPath, "content", soundname));
            simpleSound.Play();
        }

        private void playSimpleSound2(string soundname)
        {
            SoundPlayer simpleSound = new SoundPlayer(Path.Combine(Application.StartupPath, "content", soundname));
            simpleSound.Play();
        }

        public void roundstarter()
        {
            points++;
            label3.Text = points.ToString();

            int a = rnd.Next(range);
            int b = rnd.Next(range);

            int operato = rnd.Next(NumberOfOperators);

            char operat = (operato == 0) ? '+' : '-';
            label1.Text = $"{a} {operat} {b}";

            answer = (operat == '+') ? a + b : a - b;

            int changer1 = rnd.Next(10);
            int changer2 = rnd.Next(10);
            int changer3 = rnd.Next(10);

            int[] answers = { answer, answer + changer1, answer - changer2, answer - changer3 };

            for (int i = answers.Length - 1; i > 0; i--)
            {
                int j = rnd.Next(i + 1);
                int temp = answers[i];
                answers[i] = answers[j];
                answers[j] = temp;
            }

            button1.Text = answers[0].ToString();
            button2.Text = answers[1].ToString();
            button3.Text = answers[2].ToString();
            button4.Text = answers[3].ToString();
        }

   
        private void ButtonClickHandler(Button clickedButton)
        {
            if (int.TryParse(clickedButton.Text, out int clickedValue) && clickedValue == answer && maxpoint != Convert.ToInt16(label3.Text))
            {
                playSimpleSound("yes.wav");
                listBox1.Items.Add(label1.Text);
                roundstarter();
            }
            else if (Convert.ToInt16(label3.Text) == maxpoint)
            {
                MessageBox.Show("You won!");
                panel4.Show();
            }
            else
            {
                points--;
                playSimpleSound2("wrong.wav");
                listBox2.Items.Add(label1.Text);
                roundstarter();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ButtonClickHandler((Button)sender);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            ButtonClickHandler((Button)sender);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ButtonClickHandler((Button)sender);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            ButtonClickHandler((Button)sender);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            maxpoint = 15;
     
        }
        private void button6_Click(object sender, EventArgs e)
        {
            maxpoint = 30;
        }

        private void button7_Click(object sender, EventArgs e)
        {
            maxpoint = 45;
        }

        private void button10_Click(object sender, EventArgs e)
        {
            panel1.Hide();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            range = 15;
            panel1.Hide();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            range = 30;
            panel1.Hide();
        }

        private void label11_Click(object sender, EventArgs e)
        {
            panel1.Show();
            points = -1;
        }
    }
}
