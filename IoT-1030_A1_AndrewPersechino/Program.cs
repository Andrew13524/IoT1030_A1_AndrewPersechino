using System;
using System.Collections.Generic;

namespace A1
{
	public class Program
	{
		static void Main(string[] args)
		{
			Console.WriteLine("Enter the number of cards to pick: ");
			string line = Console.ReadLine();
			if (int.TryParse(line, out int numCards))
			{
				foreach (var card in CardPicker.PickSomeCards(numCards))
				{
					Console.WriteLine(card);
				}
			}
			else
			{
				Console.WriteLine("Please enter a valid number.");
			}
		}
	}
	
	public static class SubsequenceFinder
	{
		/// <summary>
		/// Determines whether a list of integers is a subsequence of another list of integers
		/// </summary>
		/// <param name="seq">The main sequence of integers.</param>
		/// <param name="subseq">The potential subsequence.</param>
		/// <returns>True if subseq is a subsequence of seq and false otherise.</returns>
		public static bool IsValidSubsequeuce(List<int> seq, List<int> subseq)
		{
			int subseqIndex = 0;

			for (int i = 0; i < seq.Count; i++)
			{
				if (seq[i] == subseq[subseqIndex]) subseqIndex++; // Whenever a sequential value is equivalent (between the seq and subseq) 
				if (subseq.Count == subseqIndex) return true;     // increase the value of the subseq index to check for the next one.
			}													  // Onced finished, if the subseq is valid, subseqIndex and subseq.length should equal
			
			return false;
		}
	}
	enum Suit { Clubs, Spades, Hearts, Diamonds }
	enum Value { Ace, Two, Three, Four, Five, Six, Seven, Eight, Nine, Ten, Jack, Queen, King }
	public class CardPicker
	{
		static Random random = new Random(1);

		static Dictionary<Value, int> NumOfValues = new Dictionary<Value, int>();
		static Dictionary<Suit, int> NumOfSuits = new Dictionary<Suit, int>();
		/// <summary>
		/// Picks a random (with replacement) number of cards.
		/// </summary>
		/// <param name="numCards">The number of cards to choose at random.</param>
		/// <returns>An array of strings where each string represents a card.</returns>
		public static string[] PickSomeCards(int numCards)
		{
			if      (numCards > 52) numCards = 52; // If numCards exceeds limit, set to max, vice versa
			else if (numCards < 0) numCards = 0;

			string[] cards = new string[numCards];

			for (int i = 0; i < numCards; i++)
            {
				var card = $"{RandomValue()} of {RandomSuit()}";

				cards[i] = card;				
			}

			return cards;
		}
		/// <summary>
		/// Chooses a random value for a card (Ace, 2, 3, ... , Queen, King)
		/// </summary>
		/// <returns>A string that represents the value of a card</returns>
		private static Value RandomValue()
		{
            while (true) // Continuously roll for a value until non-duplicate found
			{
				Value value = (Value)random.Next(1, 14);

				if(!IsDuplicateValue(value))
                {
					if (NumOfValues.ContainsKey(value)) NumOfValues[value] = NumOfValues[value] + 1;	// Updating/creating key-value (used to check for duplicates)
					else                                NumOfValues.Add(value, 1);

					return value;
				}
			}
			
		}
		private static bool IsDuplicateValue(Value value)
        {
            try
            {
				if (NumOfValues[value] == 4) return true;    // If there are already 4 of any specific value, its a duplicate
				else                         return false;
			}
            catch (KeyNotFoundException)
            {
				return false;
			}
		}
		/// <summary>
		/// Chooses a random suit for a card (Clubs, Diamonds, Hearts, Spades)
		/// </summary>
		/// <returns>A string that represents the suit of a card.</returns>
		private static Suit RandomSuit()
		{
            while (true) // Continuously roll for a suit until non-duplicate found
            {
				Suit suit = (Suit)random.Next(1, 5);

				if (!IsDuplicateSuit(suit))
				{
					if (NumOfSuits.ContainsKey(suit)) NumOfSuits[suit] = NumOfSuits[suit] + 1;  // Updating/creating key-value (used to check for duplicates)
					else                              NumOfSuits.Add(suit, 1);

					return suit;
				}
			}
		}
		private static bool IsDuplicateSuit(Suit suit)
		{
			try
			{
				if (NumOfSuits[suit] == 13) return true;	// If there are already 13 of any specific suit, its a duplicate
				else return false;
			}
			catch (KeyNotFoundException)
			{
				return false;
			}
		}
	}
}
