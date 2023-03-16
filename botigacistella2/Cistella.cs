using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace botigacistella2
{
    internal class Cistella
    {
        //ATRIBUTS
        private Botiga b;
        private DateTime data;
        private Producte[] productesCistella;
        private int[] quantitat;
        private int nElem;
        private double diners; //?private/public
    

        //CONSTRUCTORS
        public Cistella()
        {
            productesCistella = new Producte[10];
            nElem=0;
            diners=0;
            b = new Botiga[0];
        }

        public Cistella(Botiga b, Producte[] productes, int[] quantitat, double diners)
        {
            this.b = b;
            this.productesCistella = productes;
            this.quantitat = quantitat;
            this.diners = diners;

        }



        //PROPIETATS
        /*public Producte[] Productes //prou espai i prous diners per afegir el producte
        {
            get { return productesCistella;}
            set //afegir un array de productes
            {
                if(nElem >= productesCistella.Length) 
                {
                    //ampliar tenda
                }
                productesCistella[nElem] = value;
                quantitat[nElem]=value.Quantitat;
                nElem++;
                //diners > (SUM(value[i]*quantitat[i]))
            }
        }
        */

        public int NElements
        {
            get { return nElem; }
        }

        public double Diners
        {
            get { return diners;}
            set
            {
                diners += value; //?descomptant elq ja hem comprat
            }
        }
        public DateTime Data
        {
            get { return data; }
        }


        //MÈTODES
        public void ComprarProducte(Producte producte, int quantitat)
        {


            
            //comprovar que la botiga conté el producte
            if(b.Contains(producte))
            {

                //comprovar espai a la cistella
                if(productesCistella.Length>nElem && this.quantitat.Length>nElem)
                {

                    //comprovar diners suficients
                    if(producte.Preu()*quantitat>=diners)
                    {

                        //afegir el producte a la cistella
                        productesCistella[nElem] = producte;
                        this.quantitat[nElem] = quantitat;
                        nElem++;
                    }

                    
                    
                }
            }
            


        }

        public void Mostra()
        {
            Console.WriteLine(b);
        }

        public double CostTotal()
        {
            double total=0;

            for (int i = 0; i < nElem; i++)
            {
                total += (productesCistella[i].Preu()) * quantitat[i];
            }

            return total;
        }

        public override string ToString()
        {
            string ticket="";
            double total=0;

            ticket+=$"Botiga: {b.Nom}, ";
            ticket += $"Data: {data}, ";

            for(int i = 0;i<nElem; i++)
            {
                ticket+=$"\r\n Producte: {productesCistella[i]} - Quantitat {quantitat[i]}";
                total += (productesCistella[i].Preu()) * quantitat[i]; //x evitar un doble bucle no poso el metode costTotal
            }

            ticket += $"\r\n TOTAL: {total}";

            return ticket;
        }


    }
}
