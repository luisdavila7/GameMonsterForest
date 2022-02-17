using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameMonsterForest.Classes
{
    public class Player

    {
        private string name;
        private int hp;
        private int hp_max = 170;
        private int xp = 0;
        private int gp = 0;
        private int level = 1;
        
        Weapon currentWeapon = new Weapon("Wood Strick",5,15);

        public int Hp { get => hp; set => hp = value; }

        public Player(string name, int hp)
        {
            this.name = name;
            this.Hp = hp;
        }
        public bool IsDead()
        {
            if (this.Hp <= 0)
            {
                return true;
            }
            return false;
        }
        public bool Heal()
        {
            this.Hp = hp_max;
            return true;
        }
              
        public void TakeDamage(int damage)
        {
           this.Hp -= damage;
        }

        private void Next_Level()
        {
            int requiredXP = (int) Math.Floor(10 * Math.Pow(this.level, 1.5));
            if(this.xp >= requiredXP)
            {
                this.level++;
                this.hp_max += (this.level * 5);
            }
            this.Upgrade_Weapon();

        }
        private void Upgrade_By_GP()
        {
            if (this.gp >= 500)
            {
                this.level++;
                this.hp_max += (this.level * 2);
                this.gp -= 500;
            }
        }

        public void Attack(Monster enemy)
        {
            enemy.TakeDamage(currentWeapon.Damage);
            Message.Success("You hit the monster " + enemy.Name + " by " + currentWeapon.Damage);
        }

        public void Explore()
        {
            int random = RNG.random.Next(0, 100);
            Message.Success("\nYou are exploring the forest...");
            if(random < 35)
            {
                Monster monster = Monster.Create_Monster(this.level);
                Message.Danger("Monster " + monster.Name + " approches !Prepare for battle!");
                Battle(monster);
            } else
            if (random >=35 && random <70)
            {
                int random_gp = RNG.random.Next(50, 500);
                Message.Warning("\nYou collect " + random_gp + " Gold Pieces!!");
                this.gp += random_gp;

            }else
            if (random >= 70 && random < 95)
            {
                    Message.Warning("\nYou try to exchange each 500 gold pieces for Level Up!");
                    Upgrade_By_GP();
            }
            else
            {
                Message.Success("\nYou are looking for gold pieces!!");
            }
            
        }

        public void Battle(Monster monster)
        {
            int flag = 0;

            for (int i = 0; i < 5; i++)
            {
                Attack(monster);
                if (monster.IsDead())
                {
                    Message.Success("You killed the enemy!");
                    flag++;
                    break;
                } else
                {
                    monster.Attack(this);
                }
            }

            if (flag == 1)
            {
                this.xp += monster.Rxp;
                Next_Level();
            } else
            {
                Message.Warning("You ran away with injuries!");
            }
        
        }
        public override string ToString()
        {
            string stats = "STATS: HP = " + Hp + "| XP = " + xp + " | GP = " + gp + " | Level = " + level;
            stats += " Weapon : " + currentWeapon.Name + "\n";
                return stats;
        }
        public void Upgrade_Weapon()
        {
            switch (this.level)
            {
                case 0:
                case 1:
                    this.currentWeapon = new Weapon("Wood Stick", 15, 20);
                    break;
                case 2:
                    this.currentWeapon = new Weapon("Big Rock", 20, 30);
                    break;
                case 3:
                    this.currentWeapon = new Weapon("Torch", 30, 40);
                    break;
                default:
                    this.currentWeapon = new Weapon("Magic Sword", 40, 50);
                    break;
            }
        }


    }
}
