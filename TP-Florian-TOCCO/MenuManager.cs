using Models;


namespace TP_Florian_TOCCO
{
    internal static class MenuManager
    {
        public static int Start()                  // Propose des choix à l'utilisateur
        {
            string choix = "\nQuelle action ?\n";
            string choix1 = "\n\t1 - Créer un véhicule";
            string choix2 = "\n\t2 - Voir tous les véhicules";
            string choix3 = "\n\t3 - Filtrer les véhicules";
            string choix4 = "\n\t4 - Trier les véhicules";
            string choix5 = "\n\t5 - Voir un véhicule";
            string choix6 = "\n\t6 - Supprimer un véhicule";
            string choix7 = "\n\t7 - Sauvegarder les véhicules";
            string choix8 = "\n\t8 - Mettre à jour un véhicule";

            string menu = choix + choix1 + choix2 + choix3 + choix4 + choix5 + choix6 + choix7 + choix8;

            int userChoice = InputManager.GetIntResponse(menu);
            Console.Clear();
            return userChoice;
        }

        public static void Search()
        {
            int responseInt = InputManager.GetIntResponse("Quel numéro recherchez-vous ?");
            AbstractVehicule vehicule = Garage.Vehicules.Where(v => v.Numero == responseInt).ToList()[0];
            if (vehicule is Voiture)
            {
                Voiture voiture = (Voiture)vehicule;
                Console.WriteLine(voiture.ToString());
            }
            else if (vehicule is Camion)
            {
                Camion camion = (Camion)vehicule;
                Console.WriteLine(camion.ToString());
            }
            Display.DisplayContinueMessage();
        }

        public static void SortBy()
        {
            switch (ReadBy("\nSur quelle propriété souhaitez-vous trier ?\n"))
            {
                case 1: // marque
                    foreach (AbstractVehicule v in Garage.Vehicules.OrderBy(v => v.Marque).ToList())
                    {
                        if (v is Voiture)
                        {
                            Voiture voiture = (Voiture)v;
                            Console.WriteLine(voiture.ToString());
                        }
                        else if (v is Camion)
                        {
                            Camion camion = (Camion)v;
                            Console.WriteLine(camion.ToString());
                        }
                    }
                    Display.DisplayContinueMessage();
                    break;

                case 2: // modele
                    foreach (AbstractVehicule v in Garage.Vehicules.OrderBy(v => v.Modele).ToList())
                    {
                        if (v is Voiture)
                        {
                            Voiture voiture = (Voiture)v;
                            Console.WriteLine(voiture.ToString());
                        }
                        else if (v is Camion)
                        {
                            Camion camion = (Camion)v;
                            Console.WriteLine(camion.ToString());
                        }
                        Display.DisplayContinueMessage();
                    }
                    break;

                case 3: // numero
                    foreach (AbstractVehicule v in Garage.Vehicules.OrderBy(v => v.Numero).ToList())
                    {
                        if (v is Voiture)
                        {
                            Voiture voiture = (Voiture)v;
                            Console.WriteLine(voiture.ToString());
                        }
                        else if (v is Camion)
                        {
                            Camion camion = (Camion)v;
                            Console.WriteLine(camion.ToString());
                        }
                        Display.DisplayContinueMessage();
                    }
                    break;

                case 4: // puissance -> Voiture
                    foreach (AbstractVehicule v in Garage.Vehicules
                        .Where(v => v is Voiture)
                        .Cast<Voiture>()
                        .OrderBy(v => v.Puissance)
                        .ToList())
                    {
                        Console.WriteLine(v.ToString());
                    }
                    Display.DisplayContinueMessage();
                    break;

                case 5: // poids -> Camion
                    foreach (AbstractVehicule v in Garage.Vehicules
                        .Where(v => v is Camion)
                        .Cast<Camion>()
                        .OrderBy(v => v.Poids)
                        .ToList())
                    {
                        Console.WriteLine(v.ToString());
                    }
                    Display.DisplayContinueMessage();
                    break;

                case 6:     // Type
                    foreach (AbstractVehicule v in Garage.Vehicules.Where(v => v is Voiture).ToList())
                    {
                        Voiture voiture = (Voiture)v;
                        Console.WriteLine(voiture.ToString());
                    }
                    foreach (AbstractVehicule v in Garage.Vehicules.Where(v => v is Camion).ToList())
                    {
                        Camion camion = (Camion)v;
                        Console.WriteLine(camion.ToString());
                    }
                    Display.DisplayContinueMessage();
                    break;

                default:
                    Display.DisplayWrongChoiceMessage();
                    break;
            }
        }

        public static void FilterBy()
        {
            string responseString;
            int responseInt;
            switch (ReadBy("\nSur quelle propriété souhaitez-vous rechercher ?\n"))
            {
                case 1: // marque
                    responseString = InputManager.GetStringResponse("Quelle marque recherchez-vous ? (Pas de chiffres)");
                    while (responseString.Any(char.IsDigit))
                    {
                        Display.DisplayErrorMessage();
                        responseString = InputManager.GetStringResponse("Quelle marque recherchez-vous ? (Pas de chiffres)");
                    }
                    Display.DisplayVehiculeByMarque(responseString);
                    break;

                case 2: // modele
                    responseString = InputManager.GetStringResponse("Quel modèle recherchez-vous ? ( minimum 2 caracteres)");
                    Display.DisplayVehiculeByModele(responseString);
                    break;

                case 3: // numero
                    responseInt = InputManager.GetIntResponse("Quel est le numero du véhicule ? (entre 4 et 6 chiffres)", 6, 4);
                    Display.DisplayVehiculeByNumero(responseInt);
                    break;

                case 4: // puissance -> Voiture
                    responseInt = InputManager.GetIntResponse("Quelle puissance recherchez-vous ?");
                    Display.DisplayVehiculeByPuissance(responseInt);
                    break;

                case 5: // poids -> Camion
                    responseInt = InputManager.GetIntResponse("Quel poids recherchez-vous ?");
                    Display.DisplayVehiculeByPoids(responseInt);
                    break;

                case 6:     // Type
                    responseInt = InputManager.GetIntResponse("Quel type cherchez-vous ?\n\t1 - Voiture\n\t2 - Camion");
                    Display.DisplayVehiculeByType(responseInt);
                    break;

                default:
                    Display.DisplayWrongChoiceMessage();
                    break;
            }
        }
        public static void UpdateVehicle()
        {
            int responseInt = InputManager.GetIntResponse("Quel est le numéro du véhicule que vous souhaitez modifier ?");
            if (!Garage.Vehicules.Any(v => v.Numero == responseInt))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\nAucun véhicule ne correspond à ce numéro.");
                Console.ForegroundColor = ConsoleColor.White;
                Display.DisplayContinueMessage();
                return;
            }
            foreach (AbstractVehicule v in Garage.Vehicules)
            {
                if (v.Numero == responseInt)
                {
                    responseInt = Repository.Update(v);
                    switch (responseInt)
                    {
                        case 1: // Marque
                            Console.WriteLine($"Marque: {v.Marque}");
                            string newMarque = InputManager.GetStringResponse("Nouvelle marque ?");
                            while (!InputManager.CheckMarqueValidity(newMarque))
                            {
                                Display.DisplayErrorMessage();
                                newMarque = InputManager.GetStringResponse("Nouvelle marque ?");
                            }
                            v.Marque = newMarque;
                            break;

                        case 2: // Modele
                            Console.WriteLine($"Modele: {v.Modele}");
                            string newModele = InputManager.GetStringResponse("Nouveau modele ?");
                            v.Modele = newModele;
                            break;

                        case 3: // Numero
                            Console.WriteLine($"Numero: {v.Numero}");
                            int newNumero = InputManager.GetIntResponse("Nouveau numéro ?");
                            v.Numero = newNumero;
                            break;

                        case 4: // Puissance ou Poids
                            if (v is Voiture)
                            {
                                Voiture voiture = (Voiture)v;
                                Console.WriteLine($"Puissance: {voiture.Puissance}");
                                int newPuissance = InputManager.GetIntResponse("Nouvelle puissance ?");
                                voiture.Puissance = newPuissance;
                            }
                            else if (v is Camion)
                            {
                                Camion camion = (Camion)v;
                                Console.WriteLine($"Poids: {camion.Poids}");
                                int newPoids = InputManager.GetIntResponse("Nouveau poids ?");
                                camion.Poids = newPoids;
                            }
                            break;

                        default:
                            break;
                    }
                }
            }
        }

        public static int ReadBy(string initialMessage)
        {
            string choix1 = "\n\t 1 - Marque";
            string choix2 = "\n\t 2 - Modele";
            string choix3 = "\n\t 3 - Numero";
            string choix4 = "\n\t 4 - Puissance";
            string choix5 = "\n\t 5 - Poids";
            string choix6 = "\n\t 6 - Type";

            string searchChoices = initialMessage + choix1 + choix2 + choix3 + choix4 + choix5 + choix6;

            int userChoice = InputManager.GetIntResponse(searchChoices);
            Console.Clear();
            return userChoice;
        }
    }

    
}
