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
            listBox1.Items.Clear();
            XmlDocument xdoc = new XmlDocument();
            xdoc.Load(l_fileLocation.Text);
            if (l_fileName.Text == "전국무료급식소표준데이터.xml")
            {
                XmlNodeList nodes = xdoc.SelectNodes("/dataGrid/records/record");
                foreach (XmlNode emp in nodes)
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
                    for (int index = 3; index < locationToken.Length; index++)
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

                    listBox1.Items.Add(new restaurant(Name, Do, Si, Gun, Other, Institution, Number, Location, Target, Time, DayOfTheWeek, Latitude, Longitude));
                }
                l_countNum.Text = listBox1.Items.Count.ToString();
            }
            else if (l_fileName.Text == "사고다발지현황.xml")
            {
                listBox1.Items.Clear();
                XmlNodeList nodes = xdoc.SelectNodes("/사고다발지현황/row");
                foreach (XmlNode emp in nodes)
                {
                    string isThisString; int returnYear = 0; bool result;
                    isThisString = emp.SelectSingleNode("ACDNT_YY").InnerText;
                    result = int.TryParse(isThisString, out returnYear);
                    if (!result)
                    {
                        continue; // xml 첫줄 확인용
                    }
                    string Gun = emp.SelectSingleNode("SIGUN_NM").InnerText;
                    int Year = Convert.ToInt32(isThisString.ToString());
                    string locationBeforeToken = emp.SelectSingleNode("LOC_INFO").InnerText;
                    string nearBy = null;
                    for (int index = 0; index < locationBeforeToken.Length; index++)
                    {
                        char search = locationBeforeToken[index];
                        if (search == '(')
                        {
                            for (int index2 = index + 1; index2 < locationBeforeToken.Length - 1; index2++)
                            {
                                nearBy += locationBeforeToken[index2]; // () 안 주소 추출
                            }
                            break;
                        }
                    }
                    string willToken = locationBeforeToken.Replace('(' + nearBy + ')', "");
                    string[] token = willToken.Split('\x020'); // 도 군 면(읍)
                    if (token[2].IndexOf('(') != -1)
                    {
                        token[2] = token[2].Substring(0, token[2].IndexOf('('));
                    }
                    int count = Convert.ToInt32(emp.SelectSingleNode("OCCUR_NOC").InnerText);
                    int roadCasualties = Convert.ToInt32(emp.SelectSingleNode("CASLT_CNT").InnerText);
                    int dead = Convert.ToInt32(emp.SelectSingleNode("DPRS_CNT").InnerText);
                    int severelyInjured = Convert.ToInt32(emp.SelectSingleNode("SERINJRY_INDVDL_CNT").InnerText);
                    int minorInjury = Convert.ToInt32(emp.SelectSingleNode("SLTINJRY_INDVDL_CNT").InnerText);
                    int injured = Convert.ToInt32(emp.SelectSingleNode("INJURY_APLCNT_CNT").InnerText);
                    double latitude = Convert.ToDouble(emp.SelectSingleNode("LAT").InnerText);
                    double longtitude = Convert.ToDouble(emp.SelectSingleNode("LOGT").InnerText);

                    listBox1.Items.Add(new accidentProne(Year, count, roadCasualties, dead, severelyInjured, minorInjury, injured, latitude, longtitude, Gun, token[2], nearBy, locationBeforeToken));
                }
                l_countNum.Text = listBox1.Items.Count.ToString();
            }
            else if (l_fileName.Text == "보행노인사고다발지현황.xml")
            {
                listBox1.Items.Clear();
                XmlNodeList nodes = xdoc.SelectNodes("/보행노인사고다발지현황/row");
                foreach (XmlNode emp in nodes)
                {
                    string isThisString; int returnYear; bool result;
                    isThisString = emp.SelectSingleNode("ACDNT_YY").InnerText;
                    result = int.TryParse(isThisString, out returnYear);
                    if (!result)
                    {
                        continue;
                    }
                    int Year = Convert.ToInt32(isThisString.ToString());
                    string locationBeforeToken = emp.SelectSingleNode("LOC_INFO").InnerText;
                    string nearBy = null;
                    for (int index = 0; index < locationBeforeToken.Length; index++)
                    {
                        char search = locationBeforeToken[index];
                        if (search == '(')
                        {
                            for (int index2 = index + 1; index2 < locationBeforeToken.Length - 1; index2++)
                            {
                                nearBy += locationBeforeToken[index2]; // () 안 주소 추출
                            }
                            break;
                        }
                    }
                    string willToken = locationBeforeToken.Replace('(' + nearBy + ')', ""); // 원본 주소에소 () 삭제
                    string[] token = willToken.Split('\x020'); // 도 군 면(읍)
                    if (token[2].IndexOf('(') != -1)
                    {
                        token[2] = token[2].Substring(0, token[2].IndexOf('('));
                    }
                    int roadCasualties = Convert.ToInt32(emp.SelectSingleNode("CASLT_CNT").InnerText);
                    int dead = Convert.ToInt32(emp.SelectSingleNode("DPRS_CNT").InnerText);
                    int severelyInjured = Convert.ToInt32(emp.SelectSingleNode("SERINJRY_INDVDL_CNT").InnerText);
                    int minorInjury = Convert.ToInt32(emp.SelectSingleNode("SLTINJRY_INDVDL_CNT").InnerText);
                    int injured = Convert.ToInt32(emp.SelectSingleNode("INJURY_APLCNT_CNT").InnerText);
                    double latitude = Convert.ToDouble(emp.SelectSingleNode("LAT").InnerText);
                    double longtitude = Convert.ToDouble(emp.SelectSingleNode("LOGT").InnerText);

                    listBox1.Items.Add(new walk(Year, locationBeforeToken, dead, severelyInjured, minorInjury, injured, latitude, longtitude, nearBy));
                }
                l_countNum.Text = listBox1.Items.Count.ToString();
            }
            else if (l_fileName.Text == "무단횡단사고다발지현황.xml")
            {
                listBox1.Items.Clear();
                XmlNodeList nodes = xdoc.SelectNodes("/무단횡단사고다발지현황/row");
                foreach (XmlNode emp in nodes)
                {
                    string isThisString; int returnYear; bool result;
                    isThisString = emp.SelectSingleNode("ACDNT_YY").InnerText;
                    result = int.TryParse(isThisString, out returnYear);
                    if (!result)
                    {
                        continue;
                    }
                    int Year = Convert.ToInt32(isThisString.ToString());
                    string locationBeforeToken = emp.SelectSingleNode("LOC_INFO").InnerText;
                    string nearBy = null;
                    for (int index = 0; index < locationBeforeToken.Length; index++)
                    {
                        char search = locationBeforeToken[index];
                        if (search == '(')
                        {
                            for (int index2 = index + 1; index2 < locationBeforeToken.Length - 1; index2++)
                            {
                                nearBy += locationBeforeToken[index2]; // () 안 주소 추출
                            }
                            break;
                        }
                    }
                    string willToken = locationBeforeToken.Replace('(' + nearBy + ')', ""); // 원본 주소에소 () 삭제
                    string[] token = willToken.Split('\x020'); // 도 군 면(읍)
                    if (token[2].IndexOf('(') != -1)
                    {
                        token[2] = token[2].Substring(0, token[2].IndexOf('('));
                    }
                    int roadCasualties = Convert.ToInt32(emp.SelectSingleNode("CASLT_CNT").InnerText);
                    int dead = Convert.ToInt32(emp.SelectSingleNode("DPRS_CNT").InnerText);
                    int severelyInjured = Convert.ToInt32(emp.SelectSingleNode("SERINJRY_INDVDL_CNT").InnerText);
                    int minorInjury = Convert.ToInt32(emp.SelectSingleNode("SLTINJRY_INDVDL_CNT").InnerText);
                    int injured = Convert.ToInt32(emp.SelectSingleNode("INJURY_APLCNT_CNT").InnerText);
                    double latitude = Convert.ToDouble(emp.SelectSingleNode("LAT").InnerText);
                    double longtitude = Convert.ToDouble(emp.SelectSingleNode("LOGT").InnerText);

                    listBox1.Items.Add(new walk(Year, locationBeforeToken, dead, severelyInjured, minorInjury, injured, latitude, longtitude, nearBy));
                }
                l_countNum.Text = listBox1.Items.Count.ToString();
            }
            else if (l_fileName.Text == "선택 안함")
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
                                using (MySqlDataReader reader = cmd.ExecuteReader())
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
                                if (isThere == true)
                                {
                                    continue;
                                }
                                string query =
                                    "INSERT INTO 전국무료급식소" +
                                    "(Name, Do, Si, Gun, Other, Institution, Number, Location, Target, Time, DayOfTheWeek, latitude, longtitude) " +
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
                        else if (l_fileName.Text == "사고다발지현황.xml")
                        {
                            for(int index = 0; index < listBox1.Items.Count; index++)
                            {
                                listBox1.SelectedIndex = index;
                                accidentProne view = listBox1.SelectedItem as accidentProne;
                                object[] forDB = new object[13];
                                forDB = view.returnAll();
                                string forDetect =
                                    "SELECT Latitude, Longtitude " +
                                    "FROM 사고다발지현황";
                                cmd.CommandText = forDetect;
                                bool isThere = false;
                                using(MySqlDataReader reader = cmd.ExecuteReader())
                                {
                                    while (reader.Read())
                                    {
                                        if(reader.GetDouble(0) == Convert.ToDouble(forDB[7]) && reader.GetDouble(1) == Convert.ToDouble(forDB[8]))
                                        {
                                            isThere = true;
                                            break;
                                        }
                                    }
                                }
                                if (isThere == true)
                                {
                                    continue;
                                }
                                string query =
                                "INSERT INTO 사고다발지현황" +
                                "(Year, Count, roadCasualties, dead, severelyInjured, minorInjury, injured, latitude, longtitude, Gun, Other1, Other2, fullLocation) " +
                                "VALUES('" + Convert.ToInt64(forDB[0]) + "','" + Convert.ToInt64(forDB[1]) + "','" + Convert.ToInt64(forDB[2]) + "','" + Convert.ToInt64(forDB[3]) + "','"
                                + Convert.ToInt64(forDB[4]) + "','" + Convert.ToInt64(forDB[5]) + "','" + Convert.ToInt64(forDB[6]) + "','" + Convert.ToDouble(forDB[7]) + "','" + Convert.ToDouble(forDB[8]) + "','"
                                + forDB[9].ToString() + "','" + forDB[10].ToString() + "','" + forDB[11].ToString() + "','" + forDB[12].ToString() + "')";
                                cmd.CommandText = query;
                                cmd.ExecuteNonQuery();
                            }
                            string forCount =
                            "SELECT COUNT(*) FROM 사고다발지현황";
                            cmd.CommandText = forCount;
                            object count = cmd.ExecuteScalar();
                            MessageBox.Show("완료!\n\n사고다발지현황 테이블 안의 행 수 : " + count.ToString());
                        }
                        else if(l_fileName.Text == "보행노인사고다발지현황.xml")
                        {
                            for(int index = 0; index < listBox1.Items.Count; index++)
                            {
                                listBox1.SelectedIndex = index;
                                walk view = listBox1.SelectedItem as walk;
                                object[] forDB = new object[9];
                                forDB = view.returnAll();
                                string forDetect =
                                    "SELECT Year, Latitude, Longitude " +
                                    "FROM 보행노인사고다발지현황";
                                cmd.CommandText = forDetect;
                                bool isThere = false;
                                using(MySqlDataReader reader = cmd.ExecuteReader())
                                {
                                    while (reader.Read())
                                    {
                                        if(reader.GetInt32(0) == Convert.ToInt32(forDB[0]) && reader.GetDouble(1) == Convert.ToDouble(forDB[6]) && reader.GetDouble(2) == Convert.ToDouble(forDB[7]))
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
                                    "INSERT INTO 보행노인사고다발지현황" +
                                    "(Year, fullLocation, dead, severelyInjured, minorInjury, injured, Latitude, Longitude, nearBy) " +
                                    "VALUES('" + Convert.ToInt32(forDB[0]) + "','" + Convert.ToString(forDB[1]) + "','" + Convert.ToInt32(forDB[2]) + "','" + Convert.ToInt32(forDB[3]) + "','" + Convert.ToInt32(forDB[4]) + "','" + Convert.ToInt32(forDB[5]) + "','" + Convert.ToDouble(forDB[6]) + "','" + Convert.ToDouble(forDB[7])  + "','" + Convert.ToString(forDB[8]) + "')";
                                cmd.CommandText = query;
                                cmd.ExecuteNonQuery();
                            }
                            string forCount =
                                "select count(*) " +
                                "from 보행노인사고다발지현황";
                            cmd.CommandText = forCount;
                            object count = cmd.ExecuteScalar();
                            MessageBox.Show("완료!\n\n보행노인사고다발지현황 테이블 안의 행 수 : " + count.ToString());
                        }
                        else if (l_fileName.Text == "무단횡단사고다발지현황.xml")
                        {
                            for (int index = 0; index < listBox1.Items.Count; index++)
                            {
                                listBox1.SelectedIndex = index;
                                walk view = listBox1.SelectedItem as walk;
                                object[] forDB = new object[9];
                                forDB = view.returnAll();
                                string forDetect =
                                    "SELECT Year, Latitude, Longitude " +
                                    "FROM 무단횡단사고다발지현황";
                                cmd.CommandText = forDetect;
                                bool isThere = false;
                                using (MySqlDataReader reader = cmd.ExecuteReader())
                                {
                                    while (reader.Read())
                                    {
                                        if (reader.GetInt32(0) == Convert.ToInt32(forDB[0]) && reader.GetDouble(1) == Convert.ToDouble(forDB[6]) && reader.GetDouble(2) == Convert.ToDouble(forDB[7]))
                                        {
                                            isThere = true;
                                            break;
                                        }
                                    }
                                }
                                isThere = false;
                                if (isThere == true)
                                {
                                    continue;
                                }
                                string query =
                                    "INSERT INTO 무단횡단사고다발지현황" +
                                    "(Year, fullLocation, dead, severelyInjured, minorInjury, injured, Latitude, Longitude, nearBy) " +
                                    "VALUES('" + Convert.ToInt32(forDB[0]) + "','" + Convert.ToString(forDB[1]) + "','" + Convert.ToInt32(forDB[2]) + "','" + Convert.ToInt32(forDB[3]) + "','" + Convert.ToInt32(forDB[4]) + "','" + Convert.ToInt32(forDB[5]) + "','" + Convert.ToDouble(forDB[6]) + "','" + Convert.ToDouble(forDB[7]) + "','" + Convert.ToString(forDB[8]) + "')";
                                cmd.CommandText = query;
                                cmd.ExecuteNonQuery();
                            }
                            string forCount =
                                "select count(*) " +
                                "from 무단횡단사고다발지현황";
                            cmd.CommandText = forCount;
                            object count = cmd.ExecuteScalar();
                            MessageBox.Show("완료!\n\n무단횡단사고다발지현황 테이블 안의 행 수 : " + count.ToString());
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

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
    }
}
