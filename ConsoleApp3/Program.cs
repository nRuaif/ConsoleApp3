using System;
using System.Collections.Generic;

class GFG
{
    public class Move
    {
        public int row, col;
    };

    static char player = 'X', opponent = 'O';

    // This function returns true if there are moves
    // remaining on the board. It returns false if
    // there are no moves left to play.
    static Boolean isMovesLeft(char[,] board)
    {
        for (int i = 0; i < 3; i++)
            for (int j = 0; j < 3; j++)
                if (board[i, j] == 'V')
                    return true;
        return false;
    }

    // This is the evaluation function as discussed
    // in the previous article ( http://goo.gl/sJgv68 )
    static int evaluate(char[,] b)
    {
        // Checking for Rows for X or O victory.
        for (int row = 0; row < 3; row++)
        {
            if (b[row, 0] == b[row, 1] &&
                b[row, 1] == b[row, 2])
            {
                if (b[row, 0] == player)
                    return +10;
                else if (b[row, 0] == opponent)
                    return -10;
            }
        }

        // Checking for Columns for X or O victory.
        for (int col = 0; col < 3; col++)
        {
            if (b[0, col] == b[1, col] &&
                b[1, col] == b[2, col])
            {
                if (b[0, col] == player)
                    return +10;

                else if (b[0, col] == opponent)
                    return -10;
            }
        }

        // Checking for Diagonals for X or O victory.
        if (b[0, 0] == b[1, 1] && b[1, 1] == b[2, 2])
        {
            if (b[0, 0] == player)
                return +10;
            else if (b[0, 0] == opponent)
                return -10;
        }

        if (b[0, 2] == b[1, 1] && b[1, 1] == b[2, 0])
        {
            if (b[0, 2] == player)
                return +10;
            else if (b[0, 2] == opponent)
                return -10;
        }
        return 0;
    }

    // Else if none of them have won then return 0
    static int minimax(char[,] table, int depth, Boolean isMax)
    {
        int score = evaluate(table);
        if (score == -10)
            return score;
        if (score == 10)
            return score;
        if (isMovesLeft(table) == false)
        {
            return 0;
        }
        //Maximazer move
        if (isMax)
        {
            int best = -1000;
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    if (table[i, j] == 'V')
                    {
                        table[i, j] = 'X';
                        best = Math.Max(best, minimax(table, depth + 1, !isMax));
                        table[i, j] = 'V';
                    }
                }
            }
            return best;
        }

        else
        {
            int best = 1000;
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    if (table[i, j] == 'V')
                    {
                        table[i, j] = 'O';
                        best = Math.Min(best, minimax(table, depth + 1, !isMax));
                        table[i, j] = 'V';
                    }
                }
            }
            return best;
        }

    }
    public static Move findbestmoveX(char[,] table)
    {
        int BestVal = -1000;
        Move BestMove = new Move();
        BestMove.row = -1;
        BestMove.col = -1;
        for (int i = 0; i < 3; i++)
        {
            for (int j = 0; j < 3; j++)
            {
                if (table[i, j] == 'V')
                {
                    table[i, j] = 'X';
                    int MoveVal = minimax(table, 0, false);
                    table[i, j] = 'V';
                    if (MoveVal > BestVal)
                    {
                        BestMove.row = i;
                        BestMove.col = j;
                        BestVal = MoveVal;
                    }
                }
            }
        }
        Console.Write("The value of the best Move " +
                        "is : {0}\n\n", BestVal);

        return BestMove;

    }
    public static Move findbestmoveO(char[,] table)
    {
        int BestVal = 1000;
        Move BestMove = new Move();
        BestMove.row = -1;
        BestMove.col = -1;
        for (int i = 0; i < 3; i++)
        {
            for (int j = 0; j < 3; j++)
            {
                if (table[i, j] == 'V')
                {
                    table[i, j] = 'O';
                    int MoveVal = minimax(table, 0, false);
                    table[i, j] = 'V';
                    if (MoveVal < BestVal)
                    {
                        BestMove.row = i;
                        BestMove.col = j;
                        BestVal = MoveVal;
                    }
                }
            }
        }
        Console.Write("The value of the best Move " +
                        "is : {0}\n\n", BestVal);

        return BestMove;

    }
    static void Writetable(char[,] table)
	{
		for (int i = 0; i < 3; i++)
		{
			Console.WriteLine(table[i, 0] + " " + table[i, 1] + " " + table[i, 2]);
		}
	}


	static bool isMax(int turn)
	{

		if (turn % 2 == 0)
			return false;
		else if (turn % 2 == 1)
			return true;
		return true;
	}

	static bool MoveChecker(char[,] table)
	{
		int n = evaluate(table);
		if (n == 0)
		{
			return true;
		}
		else return false;
	}
	// Driver code
	public static void Main(String[] args)

	{
		Console.WriteLine("Ban di truoc ko");
		Char answer = Convert.ToChar(Console.ReadLine());
		Char[,] table = { { 'V', 'V', 'V' }, { 'V', 'V', 'V' }, { 'V', 'V', 'V' } };
		Char[] move = { 'X', 'O' };
		bool gamenotover = true;
		int turn = 1;
		int time = 0;
		if (answer == 'n')
		{
			turn++;
		}
		while (gamenotover)
		{
			for (int i = 0; i < 3; i++)
			{
				for (int j = 0; j < 3; j++)
				{
					if (table[i, j] == 'V')
					{
						time++;

					}
				}
			}





			if (isMax(turn))
			{
				string input = Console.ReadLine();
				int x = Convert.ToInt16(input[0]);
				int y = Convert.ToInt16(input[1]);
				x = x - 49;
				y = y - 49;
				table[x, y] = 'O';
				turn++;
			}
			else
			{

				if (turn % 2 == 0)
				{
 
					Move bestMove = findbestmoveX(table);
					turn++;
					table[bestMove.row, bestMove.col] = 'X';
					MoveChecker(table);
					Writetable(table);
				}

			}


			//               }
			if (MoveChecker(table) == false)
			{

				Console.WriteLine("GG");
				Writetable(table);
			}


		}
	}
}


// This code is contributed by 29AjayKumar

