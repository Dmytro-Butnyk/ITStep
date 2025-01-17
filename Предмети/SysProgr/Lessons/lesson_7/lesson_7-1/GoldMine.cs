using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lesson_7_1
{
    public class GoldMine
    {
        private int gold = 1000;

        public int MineGold(int amount)
        {
            lock (this)
            {
                if (gold < amount)
                {
                    amount = gold;
                    gold = 0;
                }
                else
                {
                    gold -= amount;
                }
                return amount;
            }
        }

        public bool IsEmpty()
        {
            return gold <= 0;
        }
    }
}
