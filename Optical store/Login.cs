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
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string connectionString = @"Server=LAPTOP-28SVJLGB ;Database=Optical;Integrated Security=True;";
            string inputUsername = textBox1.Text;
            string inputPassword = textBox2.Text;
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string query = "SELECT name ,password ,userid  FROM users WHERE name = @username AND password = @password";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@username", inputUsername);
                cmd.Parameters.AddWithValue("@password", inputPassword);

                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    string username = reader["name"].ToString();
                    string id = reader["userid"].ToString();
                    Global.username = username;
                    Global.id = id;
                    

                    MessageBox.Show("Login successful.");

                    Have_Precision itemsForm = new Have_Precision();
                    itemsForm.Show();
                }
                else
                {
                    MessageBox.Show("Invalid username or password.");
                }

                reader.Close();
            }
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


        private void Login_Load(object sender, EventArgs e)
        {

            // ===== Form Styling =====
            this.Text = "Optical Store - Login";
            this.StartPosition = FormStartPosition.CenterScreen;
            this.BackColor = Color.FromArgb(245, 247, 250);
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;

            // ===== Fonts & TextBoxes =====
            Font inputFont = new Font("Segoe UI", 11);

            // Username TextBox
            textBox1.Font = inputFont;
            textBox1.BackColor = Color.White;
            textBox1.BorderStyle = BorderStyle.FixedSingle;
            textBox1.TabIndex = 0;

            // Password TextBox (always hidden)
            textBox2.Font = inputFont;
            textBox2.BackColor = Color.White;
            textBox2.BorderStyle = BorderStyle.FixedSingle;
            textBox2.UseSystemPasswordChar = true; // hide password
            textBox2.TabIndex = 1;

            // ===== Login Button Styling =====
            button1.Text = "LOGIN";
            button1.Font = new Font("Segoe UI", 11, FontStyle.Bold);
            button1.FlatStyle = FlatStyle.Flat;
            button1.FlatAppearance.BorderSize = 0;
            button1.BackColor = Color.FromArgb(52, 152, 219);
            button1.ForeColor = Color.White;
            button1.Height = 40;
            button1.TabIndex = 2;

            // Hover effect for button
            button1.MouseEnter += (s, ev) =>
            {
                button1.BackColor = Color.FromArgb(41, 128, 185);
            };
            button1.MouseLeave += (s, ev) =>
            {
                button1.BackColor = Color.FromArgb(52, 152, 219);
            };

            // Optional: Enter key triggers login
            this.AcceptButton = button1;

        }
        }


   }


