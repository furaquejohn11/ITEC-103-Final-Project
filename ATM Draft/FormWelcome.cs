using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SQLite;
using ZXing;
using AForge.Video;
using AForge.Video.DirectShow;

namespace ATM_Draft
{
    public partial class FormWelcome : Form
    {
        private string id { get; set; }
        public FormWelcome()
        {
            InitializeComponent();
        }

       

        private async void btnSubmit_Click(object sender, EventArgs e)
        {
            await Login();
        }
        private async Task Login()
        {
            await CheckID(txtBoxID.Text);
              
            
        }

        private async Task CheckID(string username)
        {
            try
            {
                Database database = new Database();
                using (var connection = new SQLiteConnection(database.strConnection))
                {
                    await connection.OpenAsync();

                    string query = "SELECT * FROM tblAccounts WHERE ID = @ID";

                    using (var command = new SQLiteCommand(query, connection)) 
                    {
                        command.Parameters.AddWithValue("@ID", username);
                        using (var reader = await command.ExecuteReaderAsync()) 
                        {
                            if (reader.Read())
                            {
                                if (reader["STATUS"].ToString() == "ACTIVE")
                                {
                                    id = username;
                                    var frmLogin = new FormLogin(id);
                              

                                    videoCaptureDevice.Stop();
                                    timer1.Stop();
                                    frmLogin.Show();
                                    this.Hide();
                                }
                                else
                                {
                                    MessageBox.Show("YOUR ACCOUNT IS CURRENTLY BLOCKED");
                                }
                            }
                            else
                            {
                                MessageBox.Show("ID NOT AVAILABLE!", "ID NOT FOUND", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }


                            
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                
            }
        }

        private async void txtBoxID_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                await Login();
            }
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            var create = new FormCreateAccout();
            create.ShowDialog();
        }



        // QR SCANNER CODE

        FilterInfoCollection filterInfoCollection;
        VideoCaptureDevice videoCaptureDevice;

        private void FormWelcome_Load(object sender, EventArgs e)
        {
            panel1.Visible = false;

            filterInfoCollection = new FilterInfoCollection(FilterCategory.VideoInputDevice);
            foreach (FilterInfo filter in filterInfoCollection)
            {
                comboBox1.Items.Add(filter.Name);
            }
            comboBox1.SelectedIndex = 0;


        }

        private void btnScanner_Click(object sender, EventArgs e)
        {
            videoCaptureDevice = new VideoCaptureDevice(filterInfoCollection[comboBox1.SelectedIndex].MonikerString);
            videoCaptureDevice.NewFrame += videoCaptureDevice_NewFrame;
            videoCaptureDevice.Start();
            timer1.Start();
        }

        private void videoCaptureDevice_NewFrame(object sender, NewFrameEventArgs eventArgs)
        {
            Bitmap bitmap = (Bitmap)eventArgs.Frame.Clone();
            pictureBox1.Image = bitmap;


        }

        private async void timer1_Tick(object sender, EventArgs e)
        {
            if (pictureBox1 != null && pictureBox1.Image != null)
            {
                BarcodeReader reader = new BarcodeReader();
                Result result = reader.Decode((Bitmap)pictureBox1.Image);

                if (result != null)
                {
                    await CheckID(result.Text);
                }
            }
        }

        private void btnQR_Click(object sender, EventArgs e)
        {
            

            panel1.Visible = true;
        }

        private void FormWelcome_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (videoCaptureDevice != null && videoCaptureDevice.IsRunning)
            {
                videoCaptureDevice.SignalToStop();
                videoCaptureDevice.WaitForStop();
                videoCaptureDevice = null;
            }

            timer1.Stop();
            Application.Exit();





        }
    }
}
