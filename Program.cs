using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public class Program
{
    static void Main()
    {
        Console.SetWindowSize(50, 25);
        Console.SetBufferSize(50, 25);
        string [] Names = UserGreeting.AskNames();
        Board MyBoard = new Board();
        Player Player1 = new Player(Names[0], "X", MyBoard);
        Player Player2 = new Player(Names[1], "O", MyBoard);
        MyBoard.DrawBoard();
        while (MyBoard.SpaceLeft())
        {
            Player1.MakeMove();            
            if(!MyBoard.SpaceLeft()) break;
            Player2.MakeMove();
        
        }
        
        
        
       
       
    }
}
public class UserGreeting
{
    public static string [] AskNames()
    {
        string [] PlayerName = new string[2];
        Console.WriteLine("Välkommen till Tac Tac Toe");
        Console.WriteLine("Vad heter du? : ");
        PlayerName [0] = Console.ReadLine();
        Console.WriteLine("Vad heter din medspelare? : ");
        PlayerName [1] = Console.ReadLine();
        return PlayerName;
       

    }

}

public class Board
{
    public void DrawBoard()
    {
        Console.Clear();
        Console.SetCursorPosition(0, 8);
        Console.WriteLine(
            "                   -------------\n" +
            "                   | " + Memory[0] + " | " + Memory[1] + " | " + Memory[2] + " |\n" +
            "                   -------------\n" +
            "                   | " + Memory[3] + " | " + Memory[4] + " | " + Memory[5] + " |\n" +
            "                   -------------\n" +
            "                   | " + Memory[6] + " | " + Memory[7] + " | " + Memory[8] + " |\n" +
            "                   -------------\n"             
        );
    }
    public string[] Memory {get;set;}
    public Board()
    {
        Memory = new string[]{ " ", " ", " ", " ", " ", " ", " ", " ", " " };
    }
    public bool SpaceLeft() 
    {
        return Memory.Contains(" ");
    }
    public bool PlaceMarker(int position, string markerType)
    {
        if (position > 9 || position < 1 || Memory[position - 1] != " ")
        {
            return false;
        }

        Memory[position - 1] = markerType;

        return true;
    }
   
} 
public class Player
{
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
    public void PlayerTurn() 
    {
        
    }
    public string Name { get; set; }
    public string MarkerType { get; set; }
    public Board MyBoard { get; set; }
    public Player(string name, string markerType, Board myboard)
    {
        Name = name;
        MarkerType = markerType;
        MyBoard = myboard;
        
    }
    
    
    
}
