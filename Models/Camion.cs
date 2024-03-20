
namespace Models
{
    public class Camion : AbstractVehicule
    {
        public int Poids { get; set; }

        public Camion(string marque, string modele, int numero, int poids)
        {
            this.Marque = marque;
            this.Modele = modele;
            this.Numero = numero;
            this.Poids = poids;
        }

        public override string ToString()
        {
            return "\nType: Camion" + base.ToString() + $"\nPoids: {this.Poids}\n";
        }
    }
}
