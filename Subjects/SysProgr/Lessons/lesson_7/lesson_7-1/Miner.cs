using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace lesson_7_1
{
    public class Miner
    {
        private readonly GoldMine goldMine;
        private readonly string name;
        private int goldMined = 0;
        private readonly Random random = new Random();
        private Timer timer;

        public Miner(GoldMine mine, string name)
        {
            goldMine = mine;
            this.name = name;
        }

        public void StartWorking(CancellationToken token)
        {
            timer = new Timer(_ =>
            {
                if (!goldMine.IsEmpty() && !token.IsCancellationRequested) 
                {
                    goldMined += goldMine.MineGold(random.Next(1, 100));
                    WriteLine($"{name} mined {goldMined} gold.");
                    WriteLine();
                }
                else
                {
                    if (token.IsCancellationRequested)
                    {
                        WriteLine($"{name} has finished working, stopped by the King.");
                        return;
                    }
                    else
                    {
                        WriteLine($"{name} has finished working, the gold has run out.");
                    }
                    timer.Dispose();
                }
            }, null, 0, random.Next(500, 2000));
        }


        public void ShowInfo()
        {
            WriteLine($"Result: {name} has mined {goldMined} of gold!");
        }
    }
}
