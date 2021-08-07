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
        private int magicka;
        private int health;
        private int stamina;

        private int[] skills;

        private int[] mainQuest;

        private string army; // 제국? 스톰?

        private string[] equip;
        raceBase()
        {
            magicka = 0;
            health = 0;
            stamina = 0;
            skills = new int[18]; // 나무위키 스카이림/스킬의 서술 순서를 따른다
            mainQuest = new int[7]; // 나무위키 스카이림/세력의 가입 가능 순서를 따른다. 제국군이랑 스톰클록은 따로 다룰 예정
            army = "";
            equip = new string[6]; // 무기 머리 몸 다리 팔 발
        }
        bool creatNew(string race, string name)
        {
            using(FileStream file = new FileStream(name + ".skyrim", FileMode.Create))
            {
                StreamWriter writer = new StreamWriter(file, Encoding.UTF8);
                writer.WriteLine(
                    race + "\n"+
                    name + "\n"+
                    )
            }
            return true;
        }
    }
}
