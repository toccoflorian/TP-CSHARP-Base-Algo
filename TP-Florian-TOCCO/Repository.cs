using Models;
using System.Text.Json;

namespace TP_Florian_TOCCO
{
    public static class Repository
    {
        private static readonly string BaseFilePath = Path.GetFullPath("../../../Data");
        private static readonly string FileNameVoitures = @"\Voitures.json";
        public static readonly string FilePathVoitures = BaseFilePath + FileNameVoitures;
                
        private static readonly string FileNameCamions = @"\Camions.json";
        public static readonly string FilePathCamions = BaseFilePath + FileNameCamions;


        public static void CreateVehicule()
        {
            string marque = InputManager.GetStringResponse("Quel est la marque du véhicule ? (Pas de chiffres)");
            while (marque.Any(char.IsDigit))
            {
                Display.DisplayErrorMessage();
                marque = InputManager.GetStringResponse("Quelle est la marque du véhicule ? (Pas de chiffres)");
            }

            string modele = InputManager.GetStringResponse("Quel est le modèle du véhicule ? ( minimum 2 caracteres)");
            int numero = InputManager.GetIntResponse("Quel est le numéro du véhicule ? (entre 4 et 6 chiffres)", 6, 4);
            int vehiculeType = InputManager.GetIntResponse("Quel est le type du véhicule ? ( 1: voiture, 2: camion )", 2);

            if (vehiculeType == 1)
            {
                int puissance = InputManager.GetIntResponse("Quel est la puissance du véhicule ?");
                Garage.AddVehicule(new Voiture(marque, modele, numero, puissance));
            }
            else if (vehiculeType == 2)
            {
                int poids = InputManager.GetIntResponse("Quel est le poids du véhicule ?");
                Garage.AddVehicule(new Camion(marque, modele, numero, poids));
            }
            Display.DisplayCreationVehiculeMessage();
            Display.DisplayContinueMessage();
        }
        public static void Save()
        {
            try
            {
                List<Voiture> voitures = Garage.Vehicules.Where(v => v is Voiture).Cast<Voiture>().ToList();
                List<Camion> camions = Garage.Vehicules.Where(c => c is Camion).Cast<Camion>().ToList();

                if (voitures.Count > 0)
                    File.WriteAllText(FilePathVoitures, JsonSerializer.Serialize(voitures));

                if (camions.Count > 0)
                    File.WriteAllText(FilePathCamions, JsonSerializer.Serialize(camions));
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
                Display.DisplayErrorMessage();
            }
            
        }

        

        public static void LoadVoitures()
        {
            List<Voiture> voitures = JsonSerializer.Deserialize<List<Voiture>>(File.ReadAllText(FilePathVoitures)).ToList();
            foreach(Voiture voiture in voitures)
            {
                Garage.AddVehicule(voiture);
            }
        }

        public static void LoadCamions()
        {
            List<Camion> camions = JsonSerializer.Deserialize<List<Camion>>(File.ReadAllText(FilePathCamions)).ToList();
            foreach (Camion camion in camions)
            {
                Garage.AddVehicule(camion);
            }
        }

        public static void LoadAll()
        {
            DirectoryInfo directory = new("Data");
            if (File.Exists(Repository.FilePathVoitures))
                Repository.LoadVoitures();
            if (File.Exists(Repository.FilePathCamions))
                Repository.LoadCamions();
        }

        public static int Update(AbstractVehicule v)
        {
            string choix = $"Que voulez-vous modifier ?";
            string choix1 = "\n\t1 - Marque";
            string choix2 = "\n\t2 - Modele";
            string choix3 = "\n\t3 - Numero";
            string choix4 = v is Voiture ? "\n\t4 - Puissance" : "\n\t4 - Poids";

            string updateChoices = choix + choix1 + choix2 + choix3 + choix4;

            int userChoice = InputManager.GetIntResponse(updateChoices);
            Console.Clear();
            return userChoice;
        }

        

        public static void Delete()
        {
            int responseInt = InputManager.GetIntResponse("Quel est le numéro du véhicule que vous souhaitez supprimer ?");
            Garage.DeleteVehicule(responseInt);
        }
    }
}
