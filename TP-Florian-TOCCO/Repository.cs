using Models;
using System.Text.Json;

namespace TP_Florian_TOCCO
{
    internal static class Repository
    {
        private static readonly string BaseFilePath = Path.GetFullPath("../../../Data");
        private static readonly string FileNameVoitures = @"\Voitures.json";
        public static readonly string FilePathVoitures = BaseFilePath + FileNameVoitures;
                
        private static readonly string FileNameCamions = @"\Camions.json";
        public static readonly string FilePathCamions = BaseFilePath + FileNameCamions;

        public static void Save()
        {
            List<Voiture> voitures = Garage.Vehicules.Where(v => v is Voiture).Cast<Voiture>().ToList();
            List<Camion> camions = Garage.Vehicules.Where(c => c is Camion).Cast<Camion>().ToList();

            if (voitures.Count > 0)
                File.WriteAllText(FilePathVoitures, JsonSerializer.Serialize(voitures));

            if (camions.Count > 0)
                File.WriteAllText(FilePathCamions, JsonSerializer.Serialize(camions));
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
    }
}
