using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            return base.ToString() + $"\nPoids: {this.Poids}\n";
        }
    }
}
