using Models;

namespace TP_Florian_TOCCO
{
    public static class Garage
    {
        public static List<AbstractVehicule> Vehicules { get; set; } = new List<AbstractVehicule>();

        public static void AddVehicule(AbstractVehicule vehicule)
        {
            Vehicules.Add(vehicule);
        }

        //public static Voiture CreateVoiture(string marque, string modele, int numero, int puissance)
        //{
        //    Voiture voiture = new(marque, modele, numero, puissance);
        //    Console.WriteLine(voiture.ToString() + "\ncréer avec succès");
        //    return voiture;
        //}

        //public static Camion CreateCamion(string marque, string modele, int numero, int poids)
        //{

        //    Camion camion = new Camion(marque, modele, numero, poids);
        //    Console.WriteLine(camion.ToString() + "\ncréer avec succès");
        //    return camion;
        //}
    }
}
