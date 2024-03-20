using Models;


namespace TP_Florian_TOCCO
{
    internal static class Display
    {

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

        public static void DisplayVehiculeByMarque(string marque)
        {
            foreach (AbstractVehicule vehicule in Garage.Vehicules
                .Where(v => v is Voiture && v.Marque.ToLower() == marque.ToLower())
                .Cast<Voiture>()
                .ToList()) 
            {
                Console.WriteLine(vehicule.ToString());
            }

            foreach (AbstractVehicule vehicule in Garage.Vehicules
                .Where(v => v is Camion && v.Marque.ToLower() == marque.ToLower())
                .Cast<Camion>()
                .ToList())
            {
                Console.WriteLine(vehicule.ToString());
            }
            DisplayContinueMessage();
        }

        public static void DisplayVehiculeByModele(string modele)
        {
            foreach (AbstractVehicule vehicule in Garage.Vehicules
                .Where(v => v is Voiture && v.Modele.ToLower() == modele.ToLower())
                .Cast<Voiture>()
                .ToList())
            {
                Console.WriteLine(vehicule.ToString());
            }

            foreach (AbstractVehicule vehicule in Garage.Vehicules
                .Where(v => v is Camion && v.Modele.ToLower() == modele.ToLower())
                .Cast<Camion>()
                .ToList())
            {
                Console.WriteLine(vehicule.ToString());
            }
            DisplayContinueMessage();
        }

        public static void DisplayVehiculeByNumero(int numero)
        {
            foreach (AbstractVehicule vehicule in Garage.Vehicules
                .Where(v => v is Voiture && v.Numero == numero)
                .Cast<Voiture>()
                .ToList())
            {
                Console.WriteLine(vehicule.ToString());
            }

            foreach (AbstractVehicule vehicule in Garage.Vehicules
                .Where(v => v is Camion && v.Numero == numero)
                .Cast<Camion>()
                .ToList())
            {
                Console.WriteLine(vehicule.ToString());
            }
            DisplayContinueMessage();
        }

        public static void DisplayVehiculeByPuissance(int puissance)
        {
            List<Voiture> voitures = Garage.Vehicules.Where(v => v is Voiture).Cast<Voiture>().ToList();
            foreach (Voiture voiture in voitures.Where(v => v.Puissance == puissance)) 
            {
                Console.WriteLine(voiture);
            }
            DisplayContinueMessage();
        }

        public static void DisplayVehiculeByPoids(int poids)
        {
            List<Camion> camions = Garage.Vehicules.Where(c => c is Camion).Cast<Camion>().ToList();
            foreach (Camion camion in camions.Where(c => c.Poids == poids))
            {
                Console.WriteLine(camion);
            }
            DisplayContinueMessage();
        }

        public static void DisplayVehiculeByType(int userChoise)
        {
            switch (userChoise)
            {
                case 1:     // Voiture
                    foreach (AbstractVehicule v in Garage.Vehicules.Where(v => v is Voiture).ToList())
                    {
                        Voiture voiture = (Voiture)v;
                        Console.WriteLine(voiture.ToString());
                    }
                    break;
                case 2:     // Camion
                    foreach (AbstractVehicule v in Garage.Vehicules.Where(v => v is Camion).ToList())
                    {
                        Camion camion = (Camion)v;
                        Console.WriteLine(camion.ToString());
                    }
                    break;
                default:
                    Display.DisplayWrongChoiceMessage();
                    break;
            }
            DisplayContinueMessage();
        }
    }
}
