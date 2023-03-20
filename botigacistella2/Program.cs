namespace botigacistella2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Producte p1 = new Producte();
            Console.WriteLine(p1.EsapiLliure());
            int opcio=0;
            Console.WriteLine("Ets comprador o venedor? (c/v)");
            char lletra=Convert.ToChar(Console.ReadLine());

            if(lletra=='c')
            {
                Console.WriteLine("1. Comprar Producte\n\r"+
                                  "2. Comprar Productes\n\r"+
                                  "3. Ordenar Cistella\n\r"+
                                  "4. Mostra\n\r"+
                                  "5. Cost Total\n\r"+
                                  "6. To String");

                Console.WriteLine("Introdueix una opcio: ");
                opcio = Convert.ToInt32(Console.ReadLine());

                switch(opcio)
                {
                    

                }
            }
            else if (lletra=='v')
            {
                Console.WriteLine("1. Afegir producte\n\r" +
                                  "2. Modificar preu \n\r" +
                                  "3. Buscar producte\n\r" +
                                  "4. Modificar producte\n\r" +
                                  "5. Ordenar producte\n\r" +
                                  "6. Ordenar preus\n\r"+
                                  "7. Esborrar producte\n\r" +
                                  "8. Mostrar\n\r" +
                                  "9. To String");

                Console.WriteLine("Introdueix una opcio: ");
                opcio = Convert.ToInt32(Console.ReadLine());

                switch (opcio)
                {


                }
            }
        }
    }
}