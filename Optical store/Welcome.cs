using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Optical_store
{
    public partial class Welcome : Form
    {
        public Welcome()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Login loginForm = new Login();
            loginForm.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Signup signupForm = new Signup();
            signupForm.ShowDialog();
        }

        private void Welcome_Load(object sender, EventArgs e)
        {
            // ===== Form Styling =====
            this.Text = "Welcome to Optical Store";
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Size = new Size(900, 600);
            this.BackColor = Color.FromArgb(245, 247, 250);
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;

            // ===== Logo =====
            pictureBox1.Size = new Size(100, 100);
            pictureBox1.Location = new Point((this.ClientSize.Width - pictureBox1.Width) / 2, 30);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.BackColor = Color.LightGray; // placeholder
                                                     // pictureBox1.Image = Properties.Resources.logo; // optional logo

            // ===== Main Title =====
            label1.Text = "Welcome to Optical Store";
            label1.Font = new Font("Segoe UI", 18, FontStyle.Bold);
            label1.ForeColor = Color.FromArgb(52, 73, 94);
            label1.AutoSize = true;
            label1.Location = new Point((this.ClientSize.Width - label1.PreferredWidth) / 2, 150);

            // ===== Subtitle =====
            label2.Text = "Your vision, our care!";
            label2.Font = new Font("Segoe UI", 12, FontStyle.Italic);
            label2.ForeColor = Color.FromArgb(127, 140, 141);
            label2.AutoSize = true;
            label2.Location = new Point((this.ClientSize.Width - label2.PreferredWidth) / 2, 190);

            // ===== Login Button (button1) =====
            button1.Text = "Login";
            button1.Font = new Font("Segoe UI", 12, FontStyle.Bold);
            button1.Size = new Size(150, 45);
            button1.Location = new Point((this.ClientSize.Width / 2) - 160, 250);
            button1.BackColor = Color.FromArgb(52, 152, 219);
            button1.ForeColor = Color.White;
            button1.FlatStyle = FlatStyle.Flat;
            button1.FlatAppearance.BorderSize = 0;
            button1.Cursor = Cursors.Hand;
            button1.MouseEnter += (s, ev) => button1.BackColor = Color.FromArgb(41, 128, 185);
            button1.MouseLeave += (s, ev) => button1.BackColor = Color.FromArgb(52, 152, 219);

            // ===== Sign Up Button (button2) =====
            button2.Text = "Sign Up";
            button2.Font = new Font("Segoe UI", 12, FontStyle.Bold);
            button2.Size = new Size(150, 45);
            button2.Location = new Point((this.ClientSize.Width / 2) + 10, 250);
            button2.BackColor = Color.FromArgb(46, 204, 113);
            button2.ForeColor = Color.White;
            button2.FlatStyle = FlatStyle.Flat;
            button2.FlatAppearance.BorderSize = 0;
            button2.Cursor = Cursors.Hand;
            button2.MouseEnter += (s, ev) => button2.BackColor = Color.FromArgb(39, 174, 96);
            button2.MouseLeave += (s, ev) => button2.BackColor = Color.FromArgb(46, 204, 113);
        }
    }
}
