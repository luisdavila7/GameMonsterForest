using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameMonsterForest.Classes
{
    public class Monster
    {
        string name;
        int hp; 
        int ap;
        int rxp;

        public string Name { get => name; set => name = value; }
        public int Rxp { get => rxp; set => rxp = value; }

        public Monster(string name, int hp, int ap, int rxp)
        {
            this.Name = name;
            this.hp = hp;
            this.ap = ap;
            this.Rxp = rxp;
        }

        public int HPlost(int hp)
        {
            this.hp -= hp;
            return hp;
        }

        public int AP(int ap)
        {
            this.ap = ap;
            return ap;
        }

        /*        public void Dragon()
                {
                    this.hp = 120;
                    this.ap = 40;
                }
                public void Ogre()
                {
                    this.hp = 80;
                    this.ap = 20;
                }
                public void Goblin()
                {
                    this.hp = 40;
                    this.ap = 10;
                }*/

/*        public int RewardExp(string name)
        {
            switch (name)
            {
                case 'Dragon':
                    this.rxp = 3;
                    return rxp;
                case "Ogre":
                    this.rxp = 2;
                    return rxp;
                case "Goblin":
                    this.rxp = 1;
                    return rxp;
                default:
                    break;
            }
        }
*/
        public bool IsDead() 
        {
            if (this.hp <= 0)
            {
                return true;
            }
            return false;
        }

        public void TakeDamage(int damage) 
        {
            this.hp -= damage;
        }

        public void Attack(Player target)
        {
            int attack;
            Random random = new Random();
            attack = random.Next(0, this.ap);
            TakeDamage(attack);
            Message.Warning("You was hit by " + attack);
        }

        public static Monster Create_Random_Monster(int goblinChance, int ogreChance, int dragonChance)
        {
            int Max = goblinChance + ogreChance + dragonChance;
            int random = RNG.random.Next(0,Max);

            if (random <= goblinChance)
            {
                return new Monster("Goblin",40,10,1);
            } else
            if (random <= (ogreChance + goblinChance))
            {
                return new Monster("Ogre", 80, 20, 2);
            }
            else
            {
                return new Monster("Dragon", 100, 40, 3);
            }

        }
        public static Monster Create_Monster(int level)
        {
            switch (level)
            {
                case 1:
                    return Create_Random_Monster(80, 20, 0);

                case 2:
                    return Create_Random_Monster(50, 50, 0);

                case 3:
                    return Create_Random_Monster(40, 40, 20);
                default:
                    return Create_Random_Monster(30, 30, 40);
            }
        }


    }
}
