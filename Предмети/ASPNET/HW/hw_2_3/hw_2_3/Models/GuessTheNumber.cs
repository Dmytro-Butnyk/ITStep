namespace hw_2_3.Models;

public class GuessTheNumber
{
    private int _number = new Random().Next(1, 100);

    public int Number
    {
        get => _number;
    }

    public Task GenerateNumberAsync()
    {
        _number = new Random().Next(1, 100);
        return Task.CompletedTask;
    }

    public Task<string> GameProcessAsync(int clientGuess)
    {
        if(clientGuess > Number) return Task.FromResult("Your number is higher than needed!"); 
        else if(clientGuess < Number) return Task.FromResult("Your number is lower than needed!");
        else
        {
            return Task.FromResult($"You won!!!\n" +
                                   $"The number was {Number}.");
        }
    }

    public override string ToString()
    {
        return $"Number: {Number}";
    }
}