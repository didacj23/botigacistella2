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

        public bool AfegirProduct(Producte producte, Producte[] productes, int NumElements)
        {
            int index;
            

            if(EsapiLliure(productes) == -1)
            {
                return false;
            }
            else
            {
                index = EsapiLliure(productes);
                productes[index] = producte;
                return true;
                NumElements++;
                

            }
        }

        //falta inserir conjunt de productes

        private void AmpliarBotiga(int NombreProductes, ref Producte[] productes)
        {
            NombreProductes++;
            productes = new Producte[NombreProductes];
        }

        public bool ModificarPreu(string producte, double preu)
        {
            for (int i = 0; i < NumElements; i++)
            {
                if (productes[i].Nom == producte)
                {
                    productes[i].PreuSenseIva = preu;
                    return true;
                }
            }
            Console.WriteLine("El producte no s'ha trobat.");
            return false;
        }


        public bool BuscarProducte(Producte producte)
        {
            for (int i = 0; i < NumElements; i++)
            {
                if (productes[i].Nom == producte.Nom)
                {
                    return true;
                }
            }
            return false;
        }

        public bool ModificarProducte(Producte producte, string nouNom, double nouPreu, int novaQuantitat)
        {
            
            int index = -1;
            for (int i = 0; i < NumElements; i++)
            {
                if (productes[i].Equals(producte))
                {
                    index = i;
                    break;
                }
            }

            
            if (index == -1)
            {
                Console.WriteLine("El producte no existeix a la botiga.");
                return false;
            }

            // Modifiquem les dades del producte
            productes[index].Nom = nouNom;
            productes[index].PreuSenseIva = nouPreu;
            productes[index].Quantitat = novaQuantitat;

            return true;
        }

        public void OrdenarProducte()
        {
            for (int i = 0; i < NumElements - 1; i++)
            {
                int minIndex = i;
                for (int j = i + 1; j < NumElements; j++)
                {
                    if (productes[j].Nom.CompareTo(productes[minIndex].Nom) < 0)
                    {
                        minIndex = j;
                    }
                }
                if (minIndex != i)
                {
                    Producte temp = productes[i];
                    productes[i] = productes[minIndex];
                    productes[minIndex] = temp;
                }
            }
        }

        public void OrdenarPreus()
        {
            for (int i = 0; i < NumElements - 1; i++)
            {
                int minIndex = i;
                for (int j = i + 1; j < NumElements; j++)
                {
                    if (productes[j].PreuSenseIva < productes[minIndex].PreuSenseIva)
                    {
                        minIndex = j;
                    }
                }
                if (minIndex != i)
                {
                    Producte temp = productes[i];
                    productes[i] = productes[minIndex];
                    productes[minIndex] = temp;
                }
            }
        }


        public bool EsborrarProducte(Producte producte)
        {
            int index = -1;
            for (int i = 0; i < NumElements; i++)
            {
                if (productes[i].Equals(producte))
                {
                    index = i;
                    break;
                }
            }

            if (index >= 0)
            {
                for (int i = index; i < NumElements - 1; i++)
                {
                    productes[i] = productes[i + 1];
                }
                NumElements--;
                return true;
            }

            return false;
        }

        public void Mostrar()
        {
            Console.WriteLine("Llista de productes:");
            Console.WriteLine("--------------------");
            for (int i = 0; i < NumElements; i++)
            {
                Console.WriteLine("{0}: {1} ({2} unitats) - Preu sense IVA: {3:C2} | Preu amb IVA: {4:C2}", i + 1, productes[i].Nom, productes[i].Quantitat, productes[i].Preu, productes[i].PreuSenseIva);
            }
        }

        public override string ToString()
        {
            string result = "";
            for (int i = 0; i < NumElements; i++)
            {
                result += $"{productes[i].Nom}: {productes[i].PreuSenseIva.ToString("C2")} + {Iva.ToString("P0")} = {(productes[i].PreuSenseIva * (1 + Iva)).ToString("C2")}\n";
            }
            return result;
        }











        //métodes
    }
}

