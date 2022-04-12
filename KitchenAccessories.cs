namespace Lab4;

public interface IConnectable
{

    public void Connect();

    public void Disconnect();
}

public interface IWashable
{
    public void Wash()
    {
        Console.WriteLine("Washing");
    }

    public void Dry()
    {
        Console.WriteLine("Drying");
    }
}

public abstract class KitchenAccessory
{
    public double Weight { get; protected set; }
    private Location _location;
    public Location Location => _location;


    protected KitchenAccessory(double weight,int x, int y)
    {
        Weight = weight;
        _location.X = x;
        _location.Y = y;
    }

    public void MoveBy(int x, int y)
    {
        _location.X += x;
        _location.Y += y;
    }
    
}

public struct Location
{
    public int X { get; set; }
    public int Y { get; set; }

    public override string ToString()
    {
        return $"X={X},Y={Y}";
    }
}

public abstract class Dish : KitchenAccessory, IWashable
{
    protected Dish(double weight, int x, int y) : base(weight, x, y) {}

    public void Wash()
    {
        Console.WriteLine("Washing dish");
    }
}

public class Plate : Dish
{
    public Plate(double weight, int x, int y) : base(weight, x, y) {}
    public int FoodWeight { get; private set; }
    public void PlaceFood(int food)
    {
        if (food < 0) Console.WriteLine("Nope, you can't put food with negative weight");
        else
        {
            Console.WriteLine("Placed food on dish");
            FoodWeight += food;
        }
    }

    public void Empty()
    {
        Console.WriteLine($"Removed {FoodWeight} food");
        FoodWeight = 0;
    }
    public void TakeFood(int food)
    {
        if (food > FoodWeight)
        {
            FoodWeight = 0;
            Console.WriteLine("Easy,easy! Don't hurry");
        }
        else FoodWeight -= food;

    }
}
public class Fork : Dish, IConnectable
{
    public Fork(double weight, int x, int y) : base(weight, x, y) {}
    private bool _withFood=false;
    private int portion = 20;
    public void Connect()
    {
        Console.WriteLine("Bzzzz! Ur dead");
    }
    public void Disconnect()
    {
        Console.WriteLine("Wow, you're still alive");
    }

    public void Prick(Plate plate)
    {
        if (!_withFood)
        {
            _withFood = true;
            plate.TakeFood(portion);
            Console.WriteLine("Pricked on a fork");
        }
        else
        {
            Console.WriteLine("Eat first");
        }
    }

    public void Eat()
    {
        if (_withFood)
        {
            _withFood = false;
            Console.WriteLine("Mmm, delicious");
        }
        else
        {
            Console.WriteLine("Oops, looks like you don't have food on a fork");
        }
    }
    
}

public class Microwave : KitchenAccessory, IConnectable, IWashable
{
    public Microwave(double weight, int x, int y) : base(weight, x, y){}
    public bool IsConnected { get; private set; }
    public bool IsBroken { get; private set; }
    public void Wash()
    {
        if(IsConnected) Console.WriteLine("Boom! Ur dead");
        else Console.WriteLine("Microwave is now dead");
        IsBroken = true;
    }

    public void Connect()
    {
        Console.WriteLine("Connected");
        IsConnected = true;
    }

    public void Disconnect()
    {
        Console.WriteLine("Disconnected");
        IsConnected = false;
    }

    public void Heat(Dish dish)
    {
        if(!IsConnected || IsBroken) Console.WriteLine("Why would you put dish in disconnected microwave?");
        else Console.WriteLine("Heating");
    }
}