using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace botigacistella2
{
    internal class Producte
    {
        //ATRIBUTS
        private string nom;
        private double preu_sense_iva;
        private double iva;
        private int quantitat;


        //CONSTRUCTORS
        public Producte()
        {
            iva=21;
            quantitat=0;
        }

        public Producte(string nom, double preu_sense_iva):this()
        {
            this.nom = nom;
            this.preu_sense_iva = preu_sense_iva;
        }

        public Producte(string nom, double preu_sense_iva, double iva, int quantitat) : this(nom, preu_sense_iva)
        {
            this.iva = iva;
            this.quantitat = quantitat;
        }


        //PROPIETATS
        public string Nom
        {
            get { return nom; }
            set { nom = value; }
        }

        public double PreuSenseIva
        {
            get { return preu_sense_iva; }
            set
            {
                if(value>0) preu_sense_iva = value;                
            }
        }

        public double Iva
        {
            get { return iva; }
            set 
            { 
                if(value>0) iva = value;
            }
        }

        public int Quantitat
        {
            get { return quantitat; }
            set
            {
                if(value>=0) quantitat = value;                
            }
        }

        //METODES
        public double Preu()
        {
            return preu_sense_iva*iva/100+preu_sense_iva;
        }

        public override string ToString()
        {
            return $"Nom:  {Nom}, {Preu()} euros";
        }
    }
}
