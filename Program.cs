using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public class Program
{
    static void Main()
    {

        Player Player1 = new Player("Johan", "X");
        Player Player2 = new Player("Comp", "O");
        Board MyBoard = new Board();
        
       
        MyBoard.DrawBoard();
    }
}
public class UserGreeting
{
    public string Welcome()
    {
        string Player1;
        string Player2;
        Console.WriteLine("Välkommen till Tac Tac Toe");
        Console.WriteLine("Vad heter du? : ");
        Player1 = Console.ReadLine();
        Console.WriteLine("Vad heter din medspelare? : ");
        Player2 = Console.ReadLine();

        return Player1;
        Player2;

    }

}

public class Board
{
    public void DrawBoard()
    {
        Console.WriteLine(
            "-------\n" +
            "|" + Memory[0] + "|" + Memory[1] + "|" + Memory[2] + "|\n" +
             "-------\n" +
            "|" + Memory[3] + "|" + Memory[4] + "|" + Memory[5] + "|\n" +
             "-------\n" +
            "|" + Memory[6] + "|" + Memory[7] + "|" + Memory[8] + "|\n" +
             "-------\n"             
        );
    }
    public string[] Memory {get;set;}
    public Board()
    { 
        Memory = new string[] { " ", " ", " ", " ", " ", " ", " ", " ", " " };
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
    public string Name { get; set; }
    public string MarkerType { get; set; }
    public Player(string name, string markerType)
    {
        Name = name;
        MarkerType = markerType;
        
    }
    
    
    
}
