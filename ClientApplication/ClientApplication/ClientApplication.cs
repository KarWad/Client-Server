using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NetworkCommsDotNet;

namespace ClientApplication
{
    class ClientApplication
    {
        static void Main(string[] args)
        {
            //Zażądaj adresu IP i numeru portu serwera
            Console.WriteLine("Wprowadź adres IP i port serwera w formacie 192.168.0.1:10000 i naciśnij klawisz powrotu:");
            string serverInfo = Console.ReadLine();


            //Przeanalizuj niezbędne informacje z podanego ciągu
            string serverIP = serverInfo.Split(':').First();
            int serverPort = int.Parse(serverInfo.Split(':').Last());

            //Zachowaj licznik pętli
            int loopCounter = 1;
            while (true)
            {

                //Zapisz informacje w oknie konsoli
                string messageToSend = "To jest wiadomość nr. #" + loopCounter;
                Console.WriteLine("Wysyłanie wiadomości do serwera z napisem'" + messageToSend + "'");


                //Wyślij wiadomość w jednej linii
                NetworkComms.SendObject("Wiadomość", serverIP, serverPort, messageToSend);


                //Sprawdź, czy użytkownik chce obejść pętlę
                Console.WriteLine("\nNaciśnij q, aby wyjść, lub dowolny inny klawisz, aby wysłać kolejną wiadomość.");
                if (Console.ReadKey(true).Key == ConsoleKey.Q) break;
                else loopCounter++;
            }

            //Użyliśmy komunikacji, więc upewnij się, że wywołaliśmy zamknięcie
            NetworkComms.Shutdown();
        }
    }
}