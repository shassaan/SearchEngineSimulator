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

namespace SearchEngineSimulator
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            CheckForIllegalCrossThreadCalls = false;
        }

        private  void btnSearch_Click(object sender, EventArgs e)
        {

            if (rdBtnMode1.Checked)
            {
                pictureBox1.Visible = true;
                pictureBox2.Visible = true;
                pictureBox3.Visible = true;
                var t = new Thread(() => {
                    btnSearch.Enabled = false;

                    new SearchEngine().Search(1, int.Parse(txtSearchField.Text), (databank, index) => {
                        btnSearch.Enabled = true;
                        pictureBox1.Visible = false;
                        pictureBox2.Visible = false;
                        pictureBox3.Visible = false;
                        txtGold.Visible = false;
                        txtPlatinum.Visible = false;
                        txtSilver.Visible = false;
                        dataGridView1.Rows.Add(databank, index);
                    }, (data) => {
                        txtGold.Text = "" + data;
                        txtSilver.Text = "" + data;
                        txtPlatinum.Text = "" + data;
                    });
                });

                t.Start();
            }
            else if (rdBtnMode2.Checked)
            {
                pictureBox1.Visible = true;
                pictureBox2.Visible = true;
                pictureBox3.Visible = true;
                var t = new Thread(() => {
                    btnSearch.Enabled = false;
                    new SearchEngine().Search(2, int.Parse(txtSearchField.Text), (databank, index) => {
                        dataGridView1.Rows.Add(databank, index);
                    }, (data) => {
                        txtGold.Text = "" + data;
                        txtSilver.Text = "" + data;
                        txtPlatinum.Text = "" + data;
                    });
                });

                t.Start();
            }
        }
    }
}
