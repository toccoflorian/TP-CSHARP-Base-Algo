
using Models;
using System.Reflection;
using System.Text.Json;
using TP_Florian_TOCCO;
using static System.Runtime.InteropServices.JavaScript.JSType;




DirectoryInfo directory = new("Data");
if (File.Exists(Repository.FilePathVoitures))
    Repository.LoadVoitures();
if (File.Exists(Repository.FilePathCamions))
    Repository.LoadCamions();



while (true)
{
    int userChoice = Display.Start();

    switch (userChoice)
    {
        case 1:

            string marque = ResponseRequest.GetStringResponse("Quel est la marque du véhicule ? (Pas de chiffres)");
            while(!ResponseTraitment.CheckMarqueValidity(marque)) 
                marque = ResponseRequest.GetStringResponse("Quel est la marque du véhicule ?");

            string modele = ResponseRequest.GetStringResponse("Quel est le modèle du véhicule ?");
            int numero = ResponseRequest.GetIntResponse("Quel est le numéro du véhicule ? (entre 4 et 6 chiffres)", 6, 4);
            int vehiculeType = ResponseRequest.GetIntResponse("Quel est le type du véhicule ? ( 1: voiture, 2: camion )", 2);

            if (vehiculeType == 1)
            {
                int puissance = ResponseRequest.GetIntResponse("Quel est la puissance du véhicule ?");
                Garage.AddVehicule(new Voiture(marque, modele, numero, puissance));
                Display.DisplayCreationVehiculeMessage();
                Display.DisplayContinueMessage();
            }
            else if (vehiculeType == 2)
            {
                int poids = ResponseRequest.GetIntResponse("Quel est le poids du véhicule ?");
                Garage.AddVehicule(new Camion(marque, modele, numero, poids));
                Display.DisplayCreationVehiculeMessage();
                Display.DisplayContinueMessage();
            }
            break;

        case 2:

            Display.DisplayAllVehicules();
            Display.DisplayContinueMessage();
            break;

        case 3:

            break;
        case 4:
            //List<>
            break;
        case 5:
            break;
        case 6:
            break;
            
        case 7:


            try
            {
                Repository.Save();
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
                Display.DisplayErrorMessage();
            }
            
            break;
        default:
            Display.DisplayWrongChoiceMessage();
            break;
    }
}