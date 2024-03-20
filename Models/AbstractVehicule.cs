

namespace Models
{
    public abstract class AbstractVehicule
    {
        public string Marque { get; set; }
        public string Modele { get; set;}
        public int Numero { get; set;}

        public override string? ToString()
        {
            return $"\nMarque: {this.Marque}\nModele: {this.Modele}\nNumero: {this.Numero}";
        }
    }
}
