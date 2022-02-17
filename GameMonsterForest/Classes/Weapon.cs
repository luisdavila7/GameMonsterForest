using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameMonsterForest.Classes
{
    public class Weapon
    {
        string name;
        int minDamage;
        int maxDamage;
        public int Damage { get => RNG.random.Next(minDamage, maxDamage);}
        public string Name { get => name; set => name = value; }

        public Weapon(string name, int minDamage, int maxDamage)
        {
            this.Name = name;
            this.minDamage = minDamage;
            this.maxDamage = maxDamage;

        }
/*        public int GetDamage()
        {
            int damage;
            Random random = new Random();
            damage = random.Next(minDamage, maxDamage);
            return damage;
        }*/

     



    /*    public void WoodStick()
        {
            this.minDamage = 5;
            this.maxDamage = 15;
        }
        public void BigRock()
        {
            this.minDamage = 20;
            this.maxDamage = 30;
        }
        public void Torch()
        {
            this.minDamage = 35;
            this.maxDamage = 45;
        }
        public void MagicSword()
        {
            this.minDamage = 50;
            this.maxDamage = 60;
        }*/
    }
}
