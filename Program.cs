using System.ComponentModel.Design;

Robot robot = new Robot();

while (true)
{
    Console.Write("Please enter your command: on, off, north, south, west, east. ");
    string? input = Console.ReadLine();

    if (input == "stop") break;
    robot.Commands.Add(input switch
    {
        "on" => new OnCommand(),
        "off" => new OffCommand(),
        "north" => new NorthCommand(),
        "south" => new SouthCommand(),
        "west" => new WestCommand(),
        "east" => new EastCommand(),
    });
    
}

Console.WriteLine();

robot.Run();




public class Robot
{
    public int X { get; set; }
    public int Y { get; set; }  
    public bool IsPowered { get; set; }
    public List<IRobotCommand> Commands{ get; } = new List<IRobotCommand>();
    public void Run()
    {
        foreach(IRobotCommand command in Commands)
        {
            command?.Run(this);
            Console.WriteLine($"[{X} {Y} {IsPowered}]");
        }
    }

}

public interface IRobotCommand
{
    void Run(Robot robot);
    

}

public class OnCommand : IRobotCommand
{
    public void Run(Robot robot) => robot.IsPowered = true;
    
}

public class OffCommand : IRobotCommand
{
    public void Run(Robot robot) => robot.IsPowered = false;

}

public class NorthCommand : IRobotCommand
{
    public void Run(Robot robot)
    {
        if (robot.IsPowered == true)
        {
            robot.Y ++;
        }
    }
    
}
public class SouthCommand : IRobotCommand
{
    public void Run(Robot robot)
    {
        if (robot.IsPowered == true)
        {
            robot.Y --;
        }
    }

}

public class WestCommand : IRobotCommand
{
    public void Run(Robot robot)
    {
        if (robot.IsPowered == true)
        {
            robot.X --;
        }
    }

}

public class EastCommand : IRobotCommand
{
    public void Run(Robot robot)
    {
        if (robot.IsPowered == true)
        {
            robot.X ++;
        }
    }

}

