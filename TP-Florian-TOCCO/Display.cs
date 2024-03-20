using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP_Florian_TOCCO
{
    internal static class Display
    {

        public static int Start()                  // Propose des choix à l'utilisateur
        {
            string choix = "\nQuelle action ?\n";
            string choix1 = "\n\t1 - Créer un véhicule";
            string choix2 = "\n\t2 - Voir tous les véhicules";
            string choix3 = "\n\t3 - Rechercher un véhicule";
            string choix4 = "\n\t4 - Trier les véhicules";
            string choix5 = "\n\t5 - Filtrer les véhicules";
            string choix6 = "\n\t6 - Supprimer un véhicule";
            string choix7 = "\n\t7 - Sauvegarder les véhicules";

            string menu = choix + choix1 + choix2 + choix3 + choix4 + choix5 + choix6 + choix7;

            int userChoice = ResponseRequest.GetIntResponse(menu);
            Console.Clear();
            return userChoice;
        }

        public static void DisplayWrongChoiceMessage()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("\nVotre choix est incorrect, merci de recommencer. ( Appuyer 'Enter' pour continuer )");
            Console.ForegroundColor = ConsoleColor.White;
            Console.ReadLine();
            Console.Clear();
        }

        public static void DisplayContinueMessage()
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("\n\nAppuyer sur 'Enter' pour continuer.");
            Console.ReadLine();
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.White;
        }

        public static void DisplayErrorMessage()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Une erreur s'est produite, merci de retenter (ou de contacter le service client ☻).");
            Console.ReadLine();
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.White;
        }

        public static void DisplayCreationVehiculeMessage()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\nVéhicule créer avec succès !");
            Console.ForegroundColor = ConsoleColor.White;
        }

        public static void DisplayAllVehicules()
        {
            foreach (AbstractVehicule vehicule in Garage.Vehicules) Console.WriteLine(vehicule.ToString());
        }
    }
}
