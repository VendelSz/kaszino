namespace kaszino
{
	internal class Program
	{
		static void Main(string[] args)
		{
			int penz = 1000;
			Console.WriteLine($"Jelenlegi összeged: {penz}");
			Console.WriteLine("Mit szeretnél játszani? (Add meg egy számot) \n\t 1. Blackjack \n\t 2. \n\t 3. \n\t 4. \n\t 5. \n\t 6. Kilépés");
			int valasztas = Convert.ToInt32(Console.ReadLine());
			switch (valasztas)
			{
				case 1:
					penz = BlackJack(penz);
					return;
				case 6:
					Console.WriteLine("Kilépés...");
					break;
				default:
					Console.WriteLine("Érvénytelen választás!");
					return;
			}
		}

		static int BlackJack(int penz)
		{
			if (penz < 1)
			{
				Console.WriteLine($"Nincs elég pénzed a játékhoz! (jelenlegi egyenleged: {penz})");
				return penz;
			}

			int bet = 0;
			while (bet <= 0 || bet > penz)
			{
				Console.WriteLine($"Adja meg a tétet (jelenlegi egyenleged: {penz}): ");
				bet = Convert.ToInt32(Console.ReadLine());

				if (bet <= 0)
					Console.WriteLine("A tét nem lehet 0 vagy negatív.");
				else if (bet > penz)
					Console.WriteLine($"A téted nem lehet nagyobb mint az egyenleged! (jelenlegi egyenleged: {penz})");
			}

			Console.WriteLine($"Feltett összeg: {bet}");

			Random huzas = new Random();
			int kartyak = 0;
			int dealer = 0;

			for (int i = 0; i < 2; i++)
			{
				kartyak += huzas.Next(1, 11);
				dealer += huzas.Next(1, 11);
			}

			Console.WriteLine($"Húzott lapok összege: {kartyak}");
			Console.WriteLine($"Dealer lapjainak összege: {dealer}");

			while (kartyak < 21)
			{
				Console.WriteLine("Szeretnél új lapot húzni? (Igen/Nem): ");
				string valasz = Console.ReadLine().ToLower();

				if (valasz == "igen")
				{
					kartyak += huzas.Next(1, 11);
					Console.WriteLine($"Új lapot húztál. Jelenlegi lapjaid összege: {kartyak}");
				}
				else if (valasz == "nem")
				{
					break;
				}
				else
				{
					Console.WriteLine("Érvénytelen válasz! Kérlek, add meg: Igen vagy Nem.");
				}
			}

			if (kartyak > 21)
			{
				Console.WriteLine("Túllépted a 21-et! Vesztettél.");
				penz -= bet;
			}
			else
			{
				while (dealer < 17)
				{
					dealer += huzas.Next(1, 11);
					Console.WriteLine($"Dealer új lapot húzott. Dealer lapjainak összege: {dealer}");
				}

				if (dealer > 21)
				{
					Console.WriteLine("A dealer túllépte a 21-et! Nyertél.");
					penz += bet;
				}
				else if (kartyak > dealer)
				{
					Console.WriteLine("Nyertél!");
					penz += bet;
				}
				else if (kartyak < dealer)
				{
					Console.WriteLine("Vesztettél!");
					penz -= bet;
				}
				else
				{
					Console.WriteLine("Döntetlen!");
				}
			}

			Console.WriteLine($"Dealer végső lapjainak összege: {dealer}");
			Console.WriteLine($"Új összeged: {penz}");
			return penz;
		}

	}
}
