using lesson_7_1;
using static System.Console;

WriteLine("Press any key to stop miners...");
GoldMine goldMine = new GoldMine();
CancellationTokenSource cts = new CancellationTokenSource();

List<Miner> workers = new(){
            new Miner(goldMine, "Unit_Ilya"),
            new Miner(goldMine, "Unit_Dima"),
            new Miner(goldMine, "Unit_Zlata")
        };

foreach (var worker in workers)
{
    Task.Run(() => worker.StartWorking(cts.Token)).Wait();
}

ReadKey();
cts.Cancel();

Thread.Sleep(1000);
workers.ForEach(x => x.ShowInfo());

