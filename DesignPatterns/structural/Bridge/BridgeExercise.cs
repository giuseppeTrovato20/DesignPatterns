using System;
namespace DesignPatterns.structural.Bridge
{
	public class BridgeExercise
	{
		public BridgeExercise()
		{
		}

        interface IScommessa
        {
			string Scommessa(string nomePartita, double puntata);
        }

        class ScommessaSingola: IScommessa
		{
			public string Scommessa(string nomePartita, double puntata)
			{
				return (nomePartita + " " + puntata);
			} 
		}

        class ScommessaMultipla : IScommessa
        {
            public string Scommessa(string nomePartita, double puntata)
            {
                return (nomePartita + " " + puntata);
            }
        }

        interface IPiattaformaScommesse
		{
			void PiazzaScommessa();
		}

		class PiattaformaBetRadar : IPiattaformaScommesse
		{

		}

        class PiattaformaBetGenius : IPiattaformaScommesse
        {

        }

		class Program
		{
			static void main()
			{

			}
		}

    }
}

