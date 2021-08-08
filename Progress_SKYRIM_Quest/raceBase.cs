﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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

        private int[] setSkills;


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

            setSkills = new int[18]; // 나무위키 스카이림/스킬의 서술 순서를 따른다
            this.setSkills = (int[])skills.Clone();

            mainQuest = new int[7]; // 나무위키 스카이림/세력의 가입 가능 순서를 따른다. 제국군이랑 스톰클록은 따로 다룰 예정
            army = "";
            equip = new string[6]; // 무기 머리 몸 다리 팔 발
            for(int slot = 0; slot < 6; slot++)
            {
                equip[slot] = "없음";
            }
        }
        public void creatNew(string raceAbility, string raceMagic)
        {
            try
            {
                using (FileStream file = new FileStream(userName + ".skyrim", FileMode.CreateNew))
                {
                    StreamWriter writer = new StreamWriter(file, Encoding.UTF8);
                    // CTD 모드 회차 추가
                    writer.WriteLine(
                        "종족" + "\n" +
                        userName + "\n" +
                        userRace + "\n" +
                        sex + "\n");

                    writer.WriteLine(
                        "기본스텟" + "\n" +
                        magicka + "\n" +
                        health + "\n" +
                        stamina + "\n"
                        );

                    writer.WriteLine(
                        "CTD모드회차" + "\n" +
                        0 + "\n" + // ctd
                        0 + "\n" + // 모드
                        1 + "\n"  // 회차
                        );

                    writer.WriteLine(
                        "진영" + "\n"
                        );

                    writer.WriteLine("스킬");
                    for (int line = 0; line < 18; line++)
                    {
                        writer.WriteLine(setSkills[line]);
                    }

                    writer.WriteLine(
                        "\n마법" + "\n" +
                        raceAbility + "\n" +
                        raceMagic
                        );

                    writer.Flush();
                    MessageBox.Show(userName + " 생성 완료!", "완료!", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    
                }
            }
            catch (Exception)
            {
                MessageBox.Show("이미 " + userName + " 이(가) 존재합니다!\n다른 이름을 사용해 주세요!", "중복이름", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                return;
            }
        }
    }
}
