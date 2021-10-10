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

using System.Xml;
using MySql.Data.MySqlClient;
using System.Configuration;

namespace xmlOld
{
    public partial class l_nameList : Form
    {
        public l_nameList()
        {
            InitializeComponent();
            if (string.IsNullOrEmpty(l_fileLocation.Text))
            {
                l_fileLocation.Text = "선택 안함";
                l_fileName.Text = "선택 안함";
            }
        }
        private void b_selectFile_Click(object sender, EventArgs e)
        {
            OpenFileDialog select = new OpenFileDialog();
            select.ShowDialog();
            l_fileLocation.Text = select.FileName;
            l_fileName.Text = Path.GetFileName(select.FileName);
        }

        private void b_parse_Click(object sender, EventArgs e)
        {
            if(l_fileName.Text == "전국무료급식소표준데이터.xml")
            {
                XmlDocument xdoc = new XmlDocument(); 
                xdoc.Load(l_fileLocation.Text);
                XmlNodeList nodes = xdoc.SelectNodes("/dataGrid/records/record");
                foreach(XmlNode emp in nodes)
                {
                    string Name = emp.SelectSingleNode("시설명").InnerText;
                    string locationBeforeToken = emp.SelectSingleNode("소재지도로명주소").InnerText;
                    string[] locationToken = locationBeforeToken.Split('\x020');
                    if (locationToken[0] != "경기도")
                    {
                        continue;
                    }
                    string Do = locationToken[0];
                    string Si = locationToken[1];
                    string Gun = locationToken[2];
                    string Other = "";
                    for(int index = 3; index < locationToken.Length; index++)
                    {
                        Other += locationToken[index];
                    }
                    string Institution = emp.SelectSingleNode("운영기관명").InnerText;
                    string Number = emp.SelectSingleNode("전화번호").InnerText;
                    string Location = emp.SelectSingleNode("급식장소").InnerText;
                    string Target = emp.SelectSingleNode("급식대상").InnerText;
                    string Time = emp.SelectSingleNode("급식시간").InnerText;
                    string DayOfTheWeek = emp.SelectSingleNode("급식요일").InnerText;
                    double Latitude = Convert.ToDouble(emp.SelectSingleNode("위도").InnerText);
                    double Longitude = Convert.ToDouble(emp.SelectSingleNode("경도").InnerText);


                    listBox1.Items.Add(new restaurant(
                        Name,
                        Do,
                        Si,
                        Gun,
                        Other,
                        Institution,
                        Number,
                        Location,
                        Target,
                        Time,
                        DayOfTheWeek,
                        Latitude,
                        Longitude
                        ));
                }
            }

            else if(l_fileName.Text == "선택 안함")
            {
                MessageBox.Show("먼저 파일을 선택해주세요");
                return;
            }
            else
            {
                MessageBox.Show("파싱 불가능한 파일입니다");
                return;
            }
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(listBox1.SelectedIndex != -1)
            {
                propertyGrid2.SelectedObject = listBox1.SelectedItem;
            }
        }

        private void label4_Click(object sender, EventArgs e)
        {
            reallyClose q = new reallyClose();
            q.Show();
        }

        private void label5_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }
        private void b_db_Click(object sender, EventArgs e)
        {
            if (listBox1.Items.Count == 0)
            {
                MessageBox.Show("파싱부터 해");
                return;
            }
            string connectionString = ConfigurationManager.ConnectionStrings["connectionDB"].ConnectionString;
            try
            {
                using(MySqlConnection DBconnection = new MySqlConnection())
                {
                    using(MySqlCommand cmd = new MySqlCommand())
                    {
                        this.Cursor = Cursors.WaitCursor;
                        DBconnection.ConnectionString = connectionString;
                        cmd.Connection = DBconnection; 
                        DBconnection.Open();
                        if (l_fileName.Text == "전국무료급식소표준데이터.xml")
                        {
                            for (int index = 0; index < listBox1.Items.Count; index++)
                            {
                                listBox1.SelectedIndex = index;
                                restaurant view = listBox1.SelectedItem as restaurant;
                                object[] forDB = new object[13];
                                forDB = view.returnAll();
                                string forDetect =
                                    "SELECT Name, Institution, DayOfTheWeek " +
                                    "FROM 전국무료급식소";
                                cmd.CommandText = forDetect;
                                bool isThere = false;
                                using(MySqlDataReader reader = cmd.ExecuteReader())
                                {
                                    while (reader.Read()) 
                                    {
                                        if (reader.GetString(0) == forDB[0].ToString() && reader.GetString(1) == forDB[5].ToString() && reader.GetString(2) == forDB[10].ToString())
                                        {
                                            isThere = true;
                                            break;
                                        }
                                    }
                                }
                                if(isThere == true)
                                {
                                    continue;
                                }
                                string query =
                                    "INSERT INTO 전국무료급식소" +
                                    "(Name, Do, Si, Gun, Other, Institution, Number, Location, Target, Time, DayOfTheWeek, Latitude, Longtitude) " +
                                    "VALUES('" + forDB[0].ToString() + "','" + forDB[1].ToString() + "','" + forDB[2].ToString() + "','" + forDB[3].ToString() + "','"
                                    + forDB[4].ToString() + "','" + forDB[5].ToString() + "','" + forDB[6].ToString() + "','" + forDB[7].ToString() + "','" + forDB[8].ToString() + "','"
                                    + forDB[9].ToString() + "','" + forDB[10].ToString() + "','" + Convert.ToDouble(forDB[11]) + "','" + Convert.ToDouble(forDB[12]) + "')";
                                cmd.CommandText = query;
                                cmd.ExecuteNonQuery();
                            }
                            string forCount =
                                "SELECT COUNT(*) FROM 전국무료급식소";
                            cmd.CommandText = forCount;
                            object count = cmd.ExecuteScalar();
                            MessageBox.Show("완료!\n\n전국무료급식소 테이블 안의 행 수 : " + count.ToString());
                        }
                    }
                    this.Cursor = Cursors.Default;
                    DBconnection.Close();
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex + "\n\nForm1\nDB문제");
                return;
            }
        }
    }
}
