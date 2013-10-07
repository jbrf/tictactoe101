using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public class Program
{
    static void Main()
    {
        // Setting the size of the console window
        Console.SetWindowSize(50, 26);
        Console.SetBufferSize(50, 26);

        // Starts off by sending players to UserGreeting.AskNames method, saving playernames in a string array
        string [] Names = UserGreeting.AskNames();

        // Creates a new board
        Board MyBoard = new Board();

        // Creates 2 new players, where we fetch the names from the array, 
        // originally inherited from the UserGreeting.AskNames method
        Player Player1 = new Player(Names[0], "X", MyBoard);
        Player Player2 = new Player(Names[1], "O", MyBoard);

        MyBoard.DrawBoard();
        while (MyBoard.SpaceLeft())
        {
            Player1.MakeMove();            
            if(!MyBoard.SpaceLeft()) break;
            MyBoard.CheckWinner();
            if (MyBoard.Winner) break;
            Player2.MakeMove();
            if (!MyBoard.SpaceLeft() || MyBoard.Winner) break;
            MyBoard.CheckWinner();
            if (MyBoard.Winner) break;
        
        }
    }
}

public class UserGreeting
{
    // Welcomes the player and ask of hen's name
    public static string [] AskNames()
    {
        string [] PlayerName = new string[2];
        Console.SetCursorPosition(12, 8);
        Console.WriteLine("Välkommen till Tac Tac Toe\n\n");
        Console.SetCursorPosition(18, 9);
        Console.Write("Vad heter du? \n");
        PlayerName [0] = Console.ReadLine();
        Console.Clear();
        Console.SetCursorPosition(12, 8);
        Console.WriteLine("Vad heter din medspelare? ");
        PlayerName [1] = Console.ReadLine();
        return PlayerName;
    }
}

public class Board
{
    // Draws a board to the console, also set the board to be in the center
    public void DrawBoard()
    {
        Console.Clear();
        Console.SetCursorPosition(0, 8);
        Console.WriteLine(
            "                   -------------\n" +
            "                   | " + Memory[6] + " | " + Memory[7] + " | " + Memory[8] + " |\n" +
            "                   -------------\n" +
            "                   | " + Memory[3] + " | " + Memory[4] + " | " + Memory[5] + " |\n" +
            "                   -------------\n" +
            "                   | " + Memory[0] + " | " + Memory[1] + " | " + Memory[2] + " |\n" +
            "                   -------------\n\n\n"              
       
            
            );
        Console.SetCursorPosition(13,16);
        Console.WriteLine("Choose with 1-9 where you");
        Console.SetCursorPosition(13, 17);
        Console.WriteLine("want to place your marker");
    }

    public string[] Memory {get;set;}
     
    public Player PlayerX { get; set; }
    public Player PlayerO { get; set; }

    public bool Winner { get; set; }
    
    // Creates a board as an string array
    public Board()
    {
        Memory = new string[]{ " ", " ", " ", " ", " ", " ", " ", " ", " " };
    }

    // Check to see if there's any "free" space to put a marker on
    public bool SpaceLeft() 
    {
        return Memory.Contains(" ");
    }

    // Places the marker that the player chooses as long as it's a nr from 1-9
    // also converts position that we choose to machines way of viewing positions
    public bool PlaceMarker(int position, string markerType)
    {
        if (position > 9 || position < 1 || Memory[position - 1] != " ")
        {
            return false;
        }

        Memory[position - 1] = markerType;

        return true;
    }

    // Check if there's a winner that've succeded with 3 in a row
    public void CheckWinner()
    {
        foreach (string markerType in new[] { "X", "O" })
        {
            if (Memory[0] == markerType && Memory[1] == markerType && Memory[2] == markerType)
            {
                Console.Write(markerType == "X" ? PlayerX.Name + " wins!" : PlayerO.Name + " wins!");
                Winner = true;
            }
            if (Memory[3] == markerType && Memory[4] == markerType && Memory[5] == markerType)
            {
                Console.Write(markerType == "X" ? PlayerX.Name + " wins!" : PlayerO.Name + " wins!");
                Winner = true;
            }
            if (Memory[6] == markerType && Memory[7] == markerType && Memory[8] == markerType)
            {
                Console.Write(markerType == "X" ? PlayerX.Name + " wins!" : PlayerO.Name + " wins!");
                Winner = true;
            }
            if (Memory[0] == markerType && Memory[3] == markerType && Memory[6] == markerType)
            {
                Console.Write(markerType == "X" ? PlayerX.Name + " wins!" : PlayerO.Name + " wins!");
                Winner = true;
            }
            if (Memory[1] == markerType && Memory[4] == markerType && Memory[7] == markerType)
            {
                Console.Write(markerType == "X" ? PlayerX.Name + " wins!" : PlayerO.Name + " wins!");
                Winner = true;
            }
            if (Memory[2] == markerType && Memory[5] == markerType && Memory[8] == markerType)
            {
                Console.Write(markerType == "X" ? PlayerX.Name + " wins!" : PlayerO.Name + " wins!");
                Winner = true;
            }
            if (Memory[0] == markerType && Memory[4] == markerType && Memory[8] == markerType)
            {
                Console.Write(markerType == "X" ? PlayerX.Name + " wins!" : PlayerO.Name + " wins!");
                Winner = true;
            }
            if (Memory[2] == markerType && Memory[4] == markerType && Memory[6] == markerType)
            {
                Console.Write(markerType == "X" ? PlayerX.Name + " wins!" : PlayerO.Name + " wins!");
                Winner = true;
            }
        }
    }
   
} 

public class Player
{
    // Let's the player place hen's markertype
    public void MakeMove()
    {
        int pos = 0;
        do
        {
            int.TryParse(Console.ReadKey().KeyChar.ToString(), out pos);
            MyBoard.DrawBoard();
        }
        while (!MyBoard.PlaceMarker(pos, MarkerType));
        MyBoard.DrawBoard();
    }
   
    public string Name { get; set; }
    public string MarkerType { get; set; }
    public Board MyBoard { get; set; }

    // Constructor for creating a new Player
    public Player(string name, string markerType, Board myboard)
    {
        Name = name;
        MarkerType = markerType;
        MyBoard = myboard;
        if (MarkerType == "X")
        {
            MyBoard.PlayerX = this;
        }
        else 
        { 
            MyBoard.PlayerO = this; 
        }
    }
}
