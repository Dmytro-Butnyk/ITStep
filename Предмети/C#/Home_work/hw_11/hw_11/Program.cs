using hw_11;

// task 3
CreditCard card = new("345234", "Dima", new DateTime(2027, 4, 15), 1234, 30000);

// task 4
DailyTemperature[] temperatures =
        [
        new DailyTemperature { HighTemp = 20, LowTemp = 10 },
        new DailyTemperature { HighTemp = 25, LowTemp = 15 },
        new DailyTemperature { HighTemp = 30, LowTemp = 20 },
        new DailyTemperature { HighTemp = 35, LowTemp = 25 },
        new DailyTemperature { HighTemp = 40, LowTemp = 30 }
        ];

var dayWithMaxDifference = temperatures.Select((t, i) => new { Day = i + 1, t.Difference })
                                       .OrderByDescending(t => t.Difference)
                                       .First();

Console.WriteLine($"Day with max temperature difference: {dayWithMaxDifference.Day}");