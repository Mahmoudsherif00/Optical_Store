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
    public partial class Make_Makepericsion : Form
    {
        Label labelTitle, labelSubtitle, labelPatient, labelLensType, labelSphere, labelCylinder, labelAxis;
        TextBox textBoxPatient, textBoxSphere, textBoxCylinder, textBoxAxis;

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

            // ===== Validation =====
            if (string.IsNullOrWhiteSpace(textBoxPatient.Text) ||
                string.IsNullOrWhiteSpace(textBoxSphere.Text) ||
                string.IsNullOrWhiteSpace(textBoxCylinder.Text) ||
                string.IsNullOrWhiteSpace(textBoxAxis.Text))
            {
                MessageBox.Show("Please fill all fields!", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // ===== Database Save =====
            string connectionString = @"Server=LAPTOP-28SVJLGB;Database=Optical;Integrated Security=True;";
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                int userid;
                if (!int.TryParse(Global.id, out userid))
                {
                    MessageBox.Show("Invalid User ID!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                try
                {
                    conn.Open();
                    string query = @"INSERT INTO Perciption 
                     (PatientName, userid, LensType, Sphere, Cylinder, Axis) 
                     VALUES (@PatientName, @userid, @LensType, @Sphere, @Cylinder, @Axis)";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@PatientName", textBoxPatient.Text);
                        cmd.Parameters.AddWithValue("@userid", userid); // <-- Added this line
                        cmd.Parameters.AddWithValue("@LensType", comboBoxLensType.SelectedItem.ToString());
                        cmd.Parameters.AddWithValue("@Sphere", textBoxSphere.Text);
                        cmd.Parameters.AddWithValue("@Cylinder", textBoxCylinder.Text);
                        cmd.Parameters.AddWithValue("@Axis", textBoxAxis.Text);

                        cmd.ExecuteNonQuery();
                    }

                    MessageBox.Show("Prescription saved successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // Optional: Clear fields after saving
                    textBoxPatient.Clear();
                    textBoxSphere.Clear();
                    textBoxCylinder.Clear();
                    textBoxAxis.Clear();
                    comboBoxLensType.SelectedIndex = 0;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error saving prescription: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        ComboBox comboBoxLensType;
        Button buttonSave, buttonCancel;
        PictureBox pictureBoxLogo;
        public Make_Makepericsion()
        {
            InitializeComponent();
        }

        private void Make_Makepericsion_Load(object sender, EventArgs e)
        {
            // ===== Form Styling =====
            this.Text = "Create Prescription";
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Size = new Size(600, 500);
            this.BackColor = Color.FromArgb(245, 247, 250);
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;

            // ===== Logo =====
            pictureBoxLogo = new PictureBox();
            pictureBoxLogo.Size = new Size(80, 80);
            pictureBoxLogo.Location = new Point(20, 20);
            pictureBoxLogo.BackColor = Color.LightGray; // placeholder
            pictureBoxLogo.SizeMode = PictureBoxSizeMode.Zoom;
            this.Controls.Add(pictureBoxLogo);

            // ===== Title =====
            labelTitle = new Label();
            labelTitle.Text = "Create New Prescription";
            labelTitle.Font = new Font("Segoe UI", 18, FontStyle.Bold);
            labelTitle.AutoSize = true;
            labelTitle.ForeColor = Color.FromArgb(52, 73, 94);
            labelTitle.Location = new Point(150, 20);
            this.Controls.Add(labelTitle);

            // ===== Subtitle =====
            labelSubtitle = new Label();
            labelSubtitle.Text = "Enter patient details and lens measurements";
            labelSubtitle.Font = new Font("Segoe UI", 12, FontStyle.Italic);
            labelSubtitle.AutoSize = true;
            labelSubtitle.ForeColor = Color.FromArgb(127, 140, 141);
            labelSubtitle.Location = new Point(150, 60);
            this.Controls.Add(labelSubtitle);

            // ===== Patient Name =====
            labelPatient = new Label();
            labelPatient.Text = "Patient Name:";
            labelPatient.Font = new Font("Segoe UI", 12, FontStyle.Regular);
            labelPatient.Location = new Point(50, 120);
            labelPatient.AutoSize = true;
            this.Controls.Add(labelPatient);

            textBoxPatient = new TextBox();
            textBoxPatient.Font = new Font("Segoe UI", 12);
            textBoxPatient.Size = new Size(200, 30);
            textBoxPatient.Location = new Point(200, 115);
            this.Controls.Add(textBoxPatient);

            // ===== Lens Type =====
            labelLensType = new Label();
            labelLensType.Text = "Lens Type:";
            labelLensType.Font = new Font("Segoe UI", 12);
            labelLensType.Location = new Point(50, 170);
            labelLensType.AutoSize = true;
            this.Controls.Add(labelLensType);

            comboBoxLensType = new ComboBox();
            comboBoxLensType.Font = new Font("Segoe UI", 12);
            comboBoxLensType.Size = new Size(200, 30);
            comboBoxLensType.Location = new Point(200, 165);
            comboBoxLensType.Items.AddRange(new string[] { "Single Vision", "Bifocal", "Progressive", "Reading" });
            comboBoxLensType.SelectedIndex = 0;
            this.Controls.Add(comboBoxLensType);

            // ===== Sphere =====
            labelSphere = new Label();
            labelSphere.Text = "Sphere (SPH):";
            labelSphere.Font = new Font("Segoe UI", 12);
            labelSphere.Location = new Point(50, 220);
            labelSphere.AutoSize = true;
            this.Controls.Add(labelSphere);

            textBoxSphere = new TextBox();
            textBoxSphere.Font = new Font("Segoe UI", 12);
            textBoxSphere.Size = new Size(100, 30);
            textBoxSphere.Location = new Point(200, 215);
            this.Controls.Add(textBoxSphere);

            // ===== Cylinder =====
            labelCylinder = new Label();
            labelCylinder.Text = "Cylinder (CYL):";
            labelCylinder.Font = new Font("Segoe UI", 12);
            labelCylinder.Location = new Point(50, 270);
            labelCylinder.AutoSize = true;
            this.Controls.Add(labelCylinder);

            textBoxCylinder = new TextBox();
            textBoxCylinder.Font = new Font("Segoe UI", 12);
            textBoxCylinder.Size = new Size(100, 30);
            textBoxCylinder.Location = new Point(200, 265);
            this.Controls.Add(textBoxCylinder);

            // ===== Axis =====
            labelAxis = new Label();
            labelAxis.Text = "Axis:";
            labelAxis.Font = new Font("Segoe UI", 12);
            labelAxis.Location = new Point(50, 320);
            labelAxis.AutoSize = true;
            this.Controls.Add(labelAxis);

            textBoxAxis = new TextBox();
            textBoxAxis.Font = new Font("Segoe UI", 12);
            textBoxAxis.Size = new Size(100, 30);
            textBoxAxis.Location = new Point(200, 315);
            this.Controls.Add(textBoxAxis);

            // ===== Save Button =====
            button1.Text = "Save Prescription";
            button1.Font = new Font("Segoe UI", 12, FontStyle.Bold);
            button1.Size = new Size(180, 45);
            button1.Location = new Point(50, 380);
            button1.BackColor = Color.FromArgb(46, 204, 113);
            button1.ForeColor = Color.White;
            button1.FlatStyle = FlatStyle.Flat;
            button1.FlatAppearance.BorderSize = 0;
            button1.Cursor = Cursors.Hand;
            button1.MouseEnter += (s, ev) => button1.BackColor = Color.FromArgb(39, 174, 96);
            button1.MouseLeave += (s, ev) => button1.BackColor = Color.FromArgb(46, 204, 113);
            this.Controls.Add(button1);

            // ===== Cancel Button =====
            button2.Text = "Cancel";
            button2.Font = new Font("Segoe UI", 12, FontStyle.Bold);
            button2.Size = new Size(100, 45);
            button2.Location = new Point(250, 380);
            button2.BackColor = Color.FromArgb(231, 76, 60);
            button2.ForeColor = Color.White;
            button2.FlatStyle = FlatStyle.Flat;
            button2.FlatAppearance.BorderSize = 0;
            button2.Cursor = Cursors.Hand;
            button2.MouseEnter += (s, ev) => button2.BackColor = Color.FromArgb(192, 57, 43);
            button2.MouseLeave += (s, ev) => button2.BackColor = Color.FromArgb(231, 76, 60);
            button2.Click += (s, ev) => this.Close();
            this.Controls.Add(button2);
        }
        private void ButtonSave_Click(object sender, EventArgs e)
        {
          
        }
    }

}
