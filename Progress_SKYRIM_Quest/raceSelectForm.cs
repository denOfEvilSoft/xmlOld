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
    public partial class raceSelectForm : Form
    {
        public raceSelectForm()
        {
            InitializeComponent();
        }
        private string userName;
        private string race;

        private void b_nord_Click(object sender, EventArgs e)
        {
            race = "노드";
            r_raceSkill.Text =
                "+10 양손무기\n" +
                "+5 방어술\n" +
                "+5 한손무기\n" +
                "+5 대장기술\n" +
                "+5 화술\n";
            r_raceStartMagic.Text =
                "+2 불길\n" +
                "+2 치유\n";
            r_raceAbility.Text =
                "+0 전투의 함성 : 10 레벨 이하의 목표를 30초 동안 도망치게 합니다.\n" +
                "+50 냉기 저항력";
            r_raceDescription.Text =
                "스카이림의 주민들은 큰 키와 금발을 가진 사람들입니다." +
                " 강인하기 그지없는 노드는 그들의 추위에 대한 저항력과" +
                " 전사로서의 재능으로 유명합니다. 노드는 특유의 전투의 함성" +
                "으로 상대방을 도망치게 만들 수 있습니다";
        }

        private void b_darkElf_Click(object sender, EventArgs e)
        {
            race = "다크엘프";
            r_raceSkill.Text =
                "+10 파괴마법\n" +
                "+5 연금술\n" +
                "+5 변화마법\n" +
                "+5 환영마법\n" +
                "+5 경갑 방어구\n" +
                "+5 은신";
            r_raceStartMagic.Text =
                "+1 번갯불\n" +
                "+1 불길\n" +
                "+1 치유";
            r_raceAbility.Text =
                "+0 선조의 영혼 : 60초 동안 매 초마다 주변 적에게 8 의 화염 피해를 입힙니다.\n" +
                "+50 화염 저항력";
            r_raceDescription.Text =
                "고향 모로윈드에서 '던머'로 알려져 있는 다크엘프의 마법과 은신 기술은 주목할 만합니다. 선천적으로 불에 강하며" +
                "선조의 영혼 능력을 이용하여 자신을 불로 감쌀 수 있습니다.";
        }

        private void redGurad_Click(object sender, EventArgs e)
        {
            race = "레드가드";
            r_raceSkill.Text =
                "+10 한손무기\n" +
                "+5 변화마법\n" +
                "+5 궁술\n" +
                "+5 방어\n" +
                "+5 파괴마법\n" +
                "+5 재련";
            r_raceStartMagic.Text =
                "+2 불길\n" +
                "+2 치유";
            r_raceAbility.Text =
                "+0 아드레날린 분출 : 60초 동안 지구력 재생이 10배 증가합니다.\n" +
                "+50 독 저항력";
            r_raceDescription.Text =
                "해머펠 출신이며 탐리엘에서 가장 타고난 천성적인 전사인 레드가드는 체격이 단단하고 선천적으로" +
                "독에 강합니다. 그들은 전투에서 아드레날린 분출을 사용할 수 있습니다.";
        }

        private void button11_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void b_creat_Click(object sender, EventArgs e)
        {
            if (t_userName.Text == "")
            {
                MessageBox.Show("이름부터 입력해주세요!", "이름 입력 빠짐", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                return;
            }
            if (r_raceAbility.Text == "")
            {
                MessageBox.Show("종족부터 선택해주세요!", "종족 선택 안함", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                return;
            }
            userName = t_userName.Text;
            try 
            {
                using (FileStream userData = new FileStream(userName + ".skyrim", FileMode.CreateNew))
                {
                    var write = new StreamWriter(userData, Encoding.UTF8);
                    write.WriteLine(
                        "정보" +
                        userName + "\n" +
                        race + "\n\n"+)
                    write.Flush();
                }
            }
            catch (Exception)
            {
                MessageBox.Show("이미 있는 이름입니다!", "이미 있는 이름", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                return;
            }
        }
    }
}
