

namespace Models
{
    public class Voiture : AbstractVehicule
    {

        public int Puissance { get; set; }

        public Voiture(string marque, string modele, int numero, int puissance) 
        {
            this.Marque = marque;
            this.Modele = modele;
            this.Numero = numero;
            this.Puissance = puissance;
        }

        public override string ToString()
        {
            return "\nType: Voiture" + base.ToString() + $"\nPuissance: {this.Puissance}\n";
        }
    }
}
