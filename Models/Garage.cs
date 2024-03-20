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

        public static void DeleteVehicule(int numero)
        {
            List<AbstractVehicule> newList = new();
            foreach(AbstractVehicule vehicule in Vehicules)
            {
                if(vehicule.Numero != numero)
                {
                    newList.Add(vehicule);
                }
            }
            Vehicules = newList;
        }
    }
}
