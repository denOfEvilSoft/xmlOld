using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.IO;

namespace Progress_SKYRIM_Quest
{
    class raceBase
    {
        private string userName;
        private string userRace;
        private string sex; // true 는 남성

        private int magicka;
        private int health;
        private int stamina;

        private int[] skills;

        private int[] mainQuest;

        private string army; // 제국? 스톰?

        private string[] equip;
        public raceBase(string userName, string userRace, string sex, int[] skills)
        {
            this.userName = userName;
            this.userRace = userRace;
            this.sex = sex;

            magicka = 100;
            health = 100;
            stamina = 100;

            skills = new int[18]; // 나무위키 스카이림/스킬의 서술 순서를 따른다
            this.skills = (int[])skills.Clone();

            mainQuest = new int[7]; // 나무위키 스카이림/세력의 가입 가능 순서를 따른다. 제국군이랑 스톰클록은 따로 다룰 예정
            army = "";
            equip = new string[6]; // 무기 머리 몸 다리 팔 발
            for(int slot = 0; slot < 6; slot++)
            {
                equip[slot] = "없음";
            }
        }
        public void creatNew()
        {
            using(FileStream file = new FileStream(userName + ".skyrim", FileMode.Create))
            {
                StreamWriter writer = new StreamWriter(file, Encoding.UTF8);
                writer.WriteLine(
                    "종족" + "\n" +
                    userName + "\n" +
                    userRace + "\n" +
                    sex + "\n");
                writer.WriteLine("스텟스킬");
                for(int line = 0; line < 18; line++)
                {
                    writer.WriteLine(skills[line]);
                }
                writer.Flush();
            }
        }
    }
}
