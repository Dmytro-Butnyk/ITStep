using task_2;
using static System.Console;


var busStop = new BusStop();
var buses = new List<Bus>
        {
            new Bus(1, 20),
            new Bus(2, 20),
            new Bus(3, 20),
            new Bus(4, 20),
            new Bus(5, 20)
        };

var random = new Random();

for (int i = 0; i < 23; i++)
{
    WriteLine($"Hour: {i}");
    WriteLine(busStop);

    foreach (var bus in buses)
    {
        await busStop.ArriveAsync(bus);
        WriteLine($"The bus {bus} arived");
    }

    foreach (var bus in buses)
    {
        await busStop.AddPassengersAsync(bus.Id, (uint)random.Next(0, 15));
        await bus.RefreshPassengers();
    }

    await Task.Delay(1000);
}