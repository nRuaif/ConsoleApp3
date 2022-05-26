// C# program to find the
// next optimal move for a player
using System;
using System.Collections.Generic;

class GFG
{
	class Move
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

		// Else if none of them have won then return 0
		return 0;
	}

	// This is the minimax function. It considers all
	// the possible ways the game can go and returns
	// the value of the board
	static int minimax(char[,] board,
					int depth, Boolean isMax)
	{
		int score = evaluate(board);

		// If Maximizer has won the game
		// return his/her evaluated score
		if (score == 10)
			return score;

		// If Minimizer has won the game
		// return his/her evaluated score
		if (score == -10)
			return score;

		// If there are no more moves and
		// no winner then it is a tie
		if (isMovesLeft(board) == false)
			return 0;

		// If this maximizer's move
		if (isMax)
		{
			int best = -1000;

			// Traverse all cells
			for (int i = 0; i < 3; i++)
			{
				for (int j = 0; j < 3; j++)
				{
					// Check if cell is empty
					if (board[i, j] == 'V')
					{
						// Make the move
						board[i, j] = player;

						// Call minimax recursively and choose
						// the maximum value
						best = Math.Max(best, minimax(board,
										depth + 1, !isMax));

						// Undo the move
						board[i, j] = 'V';
					}
				}
			}
			return best;
		}

		// If this minimizer's move
		else
		{
			int best = 1000;

			// Traverse all cells
			for (int i = 0; i < 3; i++)
			{
				for (int j = 0; j < 3; j++)
				{
					// Check if cell is empty
					if (board[i, j] == 'V')
					{
						// Make the move
						board[i, j] = opponent;

						// Call minimax recursively and choose
						// the minimum value
						best = Math.Min(best, minimax(board,
										depth + 1, !isMax));

						// Undo the move
						board[i, j] = 'V';
					}
				}
			}
			return best;
		}
	}

	// This will return the best possible
	// move for the player
	static Move findBestMove(char[,] board)
	{
		int bestVal = -1000;
		Move bestMove = new Move();
		bestMove.row = -1;
		bestMove.col = -1;

		// Traverse all cells, evaluate minimax function
		// for all empty cells. And return the cell
		// with optimal value.
		for (int i = 0; i < 3; i++)
		{
			for (int j = 0; j < 3; j++)
			{
				// Check if cell is empty
				if (board[i, j] == 'V')
				{
					// Make the move
					board[i, j] = player;

					// compute evaluation function for this
					// move.
					int moveVal = minimax(board, 0, false);

					// Undo the move
					board[i, j] = 'V';

					// If the value of the current move is
					// more than the best value, then update
					// best/
					if (moveVal > bestVal)
					{
						bestMove.row = i;
						bestMove.col = j;
						bestVal = moveVal;
					}
				}
			}
		}

		Console.Write("The value of the best Move " +
							"is : {0}\n\n", bestVal);

		return bestMove;
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
					table[x, y] = 'X';
					turn++;
				}
				else
				{

					if (turn % 2 == 0)
					{
						Move bestMove = findBestMove(table);
						turn++;
						table[bestMove.row, bestMove.col] = 'Y';
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

