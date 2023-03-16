using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

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
            NomBotiga = "";
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
            NumElements = 0;

            for(int i = 0; i < productes.Length; i++)
            {
                if (productes[i] != null)
                {
                    NumElements++;
                }
            }
            
        }

        //Constructors

        //Propietats

        public string nomBotiga
        {
            get { return NomBotiga; }
            set { NomBotiga = value; }
        }

        public Producte[] productes
        {
            get { return Productes; }
            set { Productes = value; }
        }

        public int numElements
        {
            get { return NumElements; }
            set { NumElements = value; }
        }
        //Propietats

        //Mètodes

        private int EsapiLliure(Producte[] productes)
        {
            bool semafor = true;
            for(int i = 0; i < productes.Length; i++)
            {
                if (productes[i] == null)
                {
                    return i;
                }
                
            }

            return -1;
        }

        public Producte this[string nom]
        {
            get
            {
         
                for (int i = 0; i < NumElements; i++)
                {
                    
                    if (productes[i] != null && productes[i].Nom == nom)
                    {
                        return productes[i];
                    }
                }

                throw new ArgumentException("No s'ha trobat cap producte amb el nom " + nom);
            }
        }

        private 



        //Mètodes





    }
}

