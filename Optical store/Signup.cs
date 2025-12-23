using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Optical_store
{
    public partial class Signup : Form
    {
        public Signup()
        {
            InitializeComponent();
        }

        private void Signup_Load(object sender, EventArgs e)
        {
            this.Text = "Optical Store - Signup";
            this.StartPosition = FormStartPosition.CenterScreen;
            this.BackColor = Color.FromArgb(245, 247, 250);
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;

            Font inputFont = new Font("Segoe UI", 11);

            // Username
            textBox1.Font = inputFont;

            // Password
            textBox2.Font = inputFont;
            textBox2.UseSystemPasswordChar = true;

            // City
            textBox3.Font = inputFont;

            // Street
            textBox4.Font = inputFont;

            // House Number
            textBox5.Font = inputFont;

            // Phone
            textBox1.TabIndex = 0; // Username
            textBox2.TabIndex = 1; // Password
            textBox6.TabIndex = 2; // Phone (3rd)

            textBox3.TabIndex = 3; // City
            textBox4.TabIndex = 4; // Street
            textBox5.TabIndex = 5; // House Number

            button1.TabIndex = 6;  // Sign Up
            // Button Styling
            button1.Text = "SIGN UP";
            button1.Font = new Font("Segoe UI", 11, FontStyle.Bold);
            button1.FlatStyle = FlatStyle.Flat;
            button1.FlatAppearance.BorderSize = 0;
            button1.BackColor = Color.FromArgb(52, 152, 219);
            button1.ForeColor = Color.White;
            button1.Height = 40;

            // Hover effect
            button1.MouseEnter += (s, ev) =>
            {
                button1.BackColor = Color.FromArgb(41, 128, 185);
            };

            button1.MouseLeave += (s, ev) =>
            {
                button1.BackColor = Color.FromArgb(52, 152, 219);
            };
       
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // VALIDATION
            if (textBox1.Text == "" ||
                textBox2.Text == "" ||
                textBox3.Text == "" ||
                textBox4.Text == "" ||
                textBox5.Text == "" ||
                textBox6.Text == "")
            {
                MessageBox.Show("Please fill all fields");
                return;
            }

            string connectionString = @"Server=LAPTOP-28SVJLGB ;Database=Optical;Integrated Security=True;";
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string query = "INSERT INTO users (name, password, phone , city , street ,house_number) VALUES (@u, @p ,@phone,@city, @street,@h)";

                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@u", textBox1.Text);
                cmd.Parameters.AddWithValue("@p", textBox2.Text);
                cmd.Parameters.AddWithValue("@phone", textBox6.Text);
                cmd.Parameters.AddWithValue("@city", textBox3.Text);
                cmd.Parameters.AddWithValue("@street", textBox4.Text);
                cmd.Parameters.AddWithValue("@h", textBox5.Text);

                cmd.ExecuteNonQuery();
            }

            MessageBox.Show("Signup successful.");
            Login loginForm = new Login();
            loginForm.Show();

        }
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            button1.Region = new Region(GetRoundedRect(button1.ClientRectangle, 20));
        }

        private System.Drawing.Drawing2D.GraphicsPath GetRoundedRect(Rectangle rect, int radius)
        {
            var path = new System.Drawing.Drawing2D.GraphicsPath();
            path.AddArc(rect.X, rect.Y, radius, radius, 180, 90);
            path.AddArc(rect.Right - radius, rect.Y, radius, radius, 270, 90);
            path.AddArc(rect.Right - radius, rect.Bottom - radius, radius, radius, 0, 90);
            path.AddArc(rect.X, rect.Bottom - radius, radius, radius, 90, 90);
            path.CloseFigure();
            return path;
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
