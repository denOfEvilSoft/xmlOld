using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace Progress_SKYRIM_Quest
{
    public partial class GAME : Form
    {
        private string saveLocation;
        public GAME(string saveLocation)
        {
            this.saveLocation = saveLocation;
            InitializeComponent();
        }

        private void GAME_Load(object sender, EventArgs e)
        {
            string[] data = System.IO.File.ReadAllLines(saveLocation);
            for(int line =0; line < data.Length; line++)
            {
                string cheak = data[line].ToString();
                if(cheak == "캐릭터시트")
                {
                    line++;
                    string name = data[line].ToString();
                    string race = data[line + 1].ToString();
                    string sex = data[line + 2].ToString();
                    line += 3;

                    var item = new ListViewItem("이름");
                    item.SubItems.Add(name);
                    l_char.Items.Add(item);

                    item = new ListViewItem("종족");
                    item.SubItems.Add(race);
                    l_char.Items.Add(item);

                    item = new ListViewItem("성별");
                    item.SubItems.Add(sex);
                    l_char.Items.Add(item);
                }
                if(cheak == "캐릭터스탯")
                {
                    line++;

                }
            }
        }

    }
}
