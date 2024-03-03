class Program
{
    static void Main(string[] args)
    {
        TrafficLight trafficLight = new();
        trafficLight.SetState(new RedState());
        while (true)
        {
            trafficLight.Change();
        }
    }
}

// State
public interface ITrafficLightState
{
    void Handle(TrafficLight context);
}

// Context
public class TrafficLight
{
    private ITrafficLightState _state;

    public void SetState(ITrafficLightState state)
    {
        _state = state;
    }

    public void Change()
    {
        _state.Handle(this);
    }
}

// ConcreteState 1
public class RedState : ITrafficLightState
{
    public void Handle(TrafficLight context)
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("Red light - STOP!");
        Thread.Sleep(5000);
        context.SetState(new GreenState());
    }
}

// ConcreteState 2
public class GreenState : ITrafficLightState
{
    public void Handle(TrafficLight context)
    {
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("Green light - Go!");
        Thread.Sleep(4000);
        context.SetState(new YellowState());
    }
}

// ConcreteState 3
public class YellowState : ITrafficLightState
{
    public void Handle(TrafficLight context)
    {
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine("Yellow light - Get ready...");
        Thread.Sleep(3000);
        context.SetState(new RedState());
    }
}





