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
            get { return diners-CostTotal();}
            set
            {
                diners += value;
            }
        }
        public DateTime Data
        {
            get { return data; }
        }

        public string Botiga
        {
            get { return  b.nomBotiga; }
        }


        //MÈTODES
        public void ComprarProducte(Producte producte, int quantitat)
        {            
 
            //comprovar que la botiga conté el producte
            if(b.productes.Contains(producte))
            {
                
                //mentres no tingui prous diners i en vulgui ingresar
                char ingresar = 's';
                while (diners < producte.Preu() * quantitat && ingresar == 's')
                {
                    Console.Write("Diners insuficients. Vols ingresar més diners (s/n)? ");
                    ingresar = Convert.ToChar(Console.ReadLine());

                    if (ingresar == 's')
                    {
                        Console.Write("Introdueix la quantitat de diners a ingresar: ");
                        diners += Convert.ToDouble(Console.ReadLine());
                    }
                    else ingresar = 'n';
                }

                if (ingresar =='s' && diners >= producte.Preu() * quantitat) //si tens prous diners
                {
                    // no tinc espai a la cistella pero vull ampliar
                    char ampliar = 's';
                    while (productesCistella.Length <= nElem && ampliar == 's' || this.quantitat.Length <= nElem && ampliar == 's')
                    {
                        Console.Write("No tens espai a la cistella. La vols ampliar? (s/n)? ");
                        ampliar = Convert.ToChar(Console.ReadLine());

                        if (ampliar == 's')
                        {
                            Array.Resize(ref productesCistella, productesCistella.Length + 1);
                            Array.Resize(ref this.quantitat, this.quantitat.Length + 1);
                        }
                        else ampliar = 'n';
                    }

                    //comprovar espai a la cistella
                    if (ampliar=='s' && productesCistella.Length > nElem && this.quantitat.Length > nElem)
                    {
                        //afegir el producte a la cistella
                        productesCistella[nElem] = producte;
                        this.quantitat[nElem] = quantitat;
                        nElem++;
                        data = DateTime.Now;
                    }

                    
                }

            }
           
        }

        public void ComprarProducte(Producte[] producte, int[] quantitat)
        {
            bool c =true;
            //comprovar que la botiga conté el producte
            for(int i=0;i<producte.Length && c;i++)
            {
                if (!( b.Contains(producte[i]) )) c=false;
            }


            if (c)
            {

                //Calcular preu del array producte segons quantitat                
                double preuProductesComprar=0;
                for(int i=0; i<producte.Length; i++)
                {
                    preuProductesComprar += producte[i].Preu() * quantitat[i];
                }
                

                //mentres no tingui prous diners i en vulgui ingresar
                char ingresar = 's';
                while (diners < preuProductesComprar && ingresar == 's')
                {
                    Console.Write("Diners insuficients. Vols ingresar més diners (s/n)? ");
                    ingresar = Convert.ToChar(Console.ReadLine());

                    if (ingresar == 's')
                    {
                        Console.Write("Introdueix la quantitat de diners a ingresar: ");
                        diners += Convert.ToDouble(Console.ReadLine());
                    }
                    else ingresar = 'n';
                }

                if (ingresar == 's' && diners >= preuProductesComprar) //si tens prous diners
                {
                    // no tinc espai a la cistella pero vull ampliar
                    char ampliar = 's';
                    while (productesCistella.Length - nElem < producte.Length && ampliar == 's' || this.quantitat.Length - nElem < producte.Length && ampliar == 's')
                    {
                        Console.Write("No tens espai a la cistella. La vols ampliar? (s/n)? ");
                        ampliar = Convert.ToChar(Console.ReadLine());

                        if (ampliar == 's')
                        {
                            Array.Resize(ref productesCistella, productesCistella.Length + 1);
                            Array.Resize(ref this.quantitat, this.quantitat.Length + 1);
                        }
                        else ampliar = 'n';
                    }

                    //comprovar espai a la cistella
                    if (ampliar == 's' && productesCistella.Length-nElem>=producte.Length && this.quantitat.Length-nElem >= producte.Length)
                    {
                        //afegir el producte a la cistella
                        for(int i = 0;i<producte.Length;i++)
                        {
                            productesCistella[nElem] = producte[i];
                            this.quantitat[nElem] = quantitat[i];
                            nElem++;
                        }
                        data = DateTime.Now;
                        
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
