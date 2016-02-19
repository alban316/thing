using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
Ref's:
http://broadcast.oreilly.com/2010/08/understanding-c-text-mode-games.html
https://en.wikipedia.org/wiki/Code_page_437
http://stackoverflow.com/questions/5891538/listen-for-key-press-in-net-console-app

Notes:
Unhandled Exception: System.ArgumentOutOfRangeException: The value must be less than the console's current maximum window size of 84 in tha
 on screen resolution and the console font.
Parameter name: height
Actual value was 128.
   at System.Console.SetWindowSize(Int32 width, Int32 height)
   at thing.Program.Main(String[] args) in C:\Users\jbrugger\repo\thing\thing\Program.cs:line 37

//Console.Clear();
//Console.SetCursorPosition(0, 0);
//Console.ForegroundColor = ConsoleColor.Magenta;
//Console.WriteLine("o o        . .");
//Console.WriteLine(" )          ) ");
//Console.WriteLine("___        ###");
//for (int i = 0; i < 20; i++)
//{
//    Console.MoveBufferArea(i + 11, i, 3, 3, i + 12, i + 1,
//        'x', ConsoleColor.Red, ConsoleColor.White);
//    Console.MoveBufferArea(i, i, 3, 3, i + 1, i + 1);
//    //Console.Beep((i + 10) * 100, 100);
//}
//Console.SetCursorPosition(0, 23);
//Console.ResetColor();
*/



namespace thing
{
    class Program
    {
        static void Main(string[] args)
        {
            Game game = new Game();
            game.RunGame();
        }  
    }

}





/*
Early samples:
            Console.MoveBufferArea(60, 20, 10, 10, 59, 20);

            for (int x = 60, y=20; x < 70; x++, y++)
            {
                Console.SetCursorPosition(x, y);
                Console.Write("#");
            }

            System.Threading.Thread.Sleep(2000);

            Console.SetCursorPosition(1, 1);
            Console.Write(gamechar[1]);

            Console.SetCursorPosition(3, 3);
            Console.Write(gamechar[176]);

                    //Console.SetCursorPosition(40, 20);
                    //Console.Write(anim[i]);
                    //i++;
                    //if (i >= anim.Length)
                    //{
                    //    i = 0;
                    //}

                //char[] anim = new char[] {'/', '-', '\\', '|'};
            //i = 0;

*/
