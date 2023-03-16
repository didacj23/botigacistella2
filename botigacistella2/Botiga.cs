using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace botigacistella2
{
    internal class Botiga
    {
        public string NomBotiga;
        public Producte[] Productes;
        public int NumElements;


        //Constructors

        public Botiga()
        {
            Productes = new Producte[10];
            NumElements = 0;
        }

        
        public Botiga(string nom, int nombreProductes)
        {
            NomBotiga = nom;
            Productes = new Producte[nombreProductes];
            NumElements = 0;
        }

        
        public Botiga(string nom, Producte[] productes)
        {
            NomBotiga = nom;
            Productes = productes;
            NumElements = Productes != null
    
        //Constructors

            //Propietats



    }
}

