using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Progress_SKYRIM_Quest
{
    public partial class startForm : Form
    {
        private string selectedFile; 
        public startForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            raceSelectForm newStart = new raceSelectForm();
            newStart.Show();
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            var saveFile = new OpenFileDialog();
            saveFile.DefaultExt = "skyrim";
            saveFile.Filter = "저장된 데이터(*.skyrim;)|*skyrim";
            saveFile.ShowDialog();
            selectedFile = saveFile.FileName;

            GAME main = new GAME();
            main.Show();
        }
    }
}
