namespace ConsoleApp69;

public class Program
{
    static string[,] board =
    {
        {"1","2","3" },
        {"4","5","6" },
        {"7","8","9" }
    };

    public static void Main(string[] args)
    {
        TicTacToe();
    }


    public static void TicTacToe()
    {
        bool flag = true;
        char currentPlayer = 'X';
        while (flag)
        {
            BrettAnzeigen();
            //spielerinput bzw inputhandling
            Console.WriteLine("\n\n");
            Console.WriteLine($"Bitte im Format {currentPlayer}1, {currentPlayer}2, {currentPlayer}3... eingeben!");
            Console.Write($"Spieler {currentPlayer} - Input eingeben (zB. {currentPlayer}5): ");
            string inputAsString;

            try
            {
                inputAsString = Console.ReadLine();
                char inputSymbol = inputAsString.ElementAt(0);
                char inputZahl = inputAsString.ElementAt(1);
                bool inputIsValid = BrettUpdaten(inputSymbol.ToString(), inputZahl.ToString(), ref currentPlayer);

                //brett checken
                bool winningflag = Checker(board);
                if (winningflag)
                {
                    Console.Write("\n\n");
                    Console.WriteLine($"Spieler {currentPlayer} hat gewonnen!");
                    Console.WriteLine();
                    flag = false;
                }
                else if (inputIsValid)
                {
                    //spielerwechsel nur wenn die eingabe korrekt war
                    currentPlayer = (currentPlayer == 'X') ? 'O' : 'X';
                }
            }
            catch (Exception)
            {
                Console.WriteLine("Fehler. Bitte neu versuchen.");
            }
        }
    }



    public static void BrettAnzeigen()
    {
        //brett base
        Console.Write("\n\n");
        for (int i = 0; i < board.GetLength(0); i++)
        {
            for (int j = 0; j < board.GetLength(1); j++)
            {
                if (i == 0 && j == 0 || i == 0 && j == 1 || i == 1 && j == 0 || i == 1 && j == 1 || i == 2 && j == 0 || i == 2 && j == 1)
                {
                    Console.Write(board[i, j] + "  |  ");
                }
                else Console.Write(board[i, j] + "     ");
                if (i == 0 && j == 2 || i == 1 && j == 2)
                {
                    Console.Write("\n--------------\n");
                }
            }
        }
    }

    public static bool BrettUpdaten(string inputSymbol, string inputZahl, ref char currentPlayer)
    {
        if (inputSymbol[0] == currentPlayer)
        {
            for (int i = 0; i < board.GetLength(0); i++)
            {
                for (int j = 0; j < board.GetLength(1); j++)
                {
                    if (board[i, j] == inputZahl)
                    {
                        board[i, j] = inputSymbol;
                        return true;
                    }
                }
            }
        }
        else
        {
            Console.WriteLine($"Fehler: Spieler {currentPlayer} kann nur das Symbol '{currentPlayer}' setzen.");
        }
        return false;
    }



    public static bool Checker(string[,] board)
    {
        for (int i = 0; i < 3; i++)
        {
            //horizontal and vertikal
            if (board[i, 0] == board[i, 1] && board[i, 1] == board[i, 2]) return true;
            else if (board[0, i] == board[1, i] && board[1, i] == board[2, i]) return true;

            //diagonal
            else if (board[0, 0] == board[1, 1] && board[1, 1] == board[2, 2]) return true;
            else if (board[0, 2] == board[1, 1] && board[1, 1] == board[2, 0]) return true;

        }
        return false;
    }
}
