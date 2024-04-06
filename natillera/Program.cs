internal class Program
{
    private static void Main(string[] args)
    {
        /*Natillera, PARTE 2!
        Como ustedes recuerdan, resolvimos el Ejercicio #18 del Taller de Algoritmos, que se trata de una Natillera Navideña. A este ejercicio, le van a añadir una solución a lo siguiente:
        Ya tenemos nuestra natillera navideña diseñada para calcular los aportes y bonos durante un año de 1 socio y liquidación de dicha natillera al final del año. Ahora quiero modificar el código para que me haga lo siguiente:
            - La posibilidad de ingresar 2 socios y calcular el mes de ambos (o sea, mostrar el ahorro del mes, si ganó bono, cuánto fue su rendimiento, etc.) tal como se hace con 1 solo, pero esta vez que sean 2.
            - Si el socio no aportó/ahorró nada ($0), entonces cobrar una multa de $20.000 en ese mes.
            - Si el socio quiere hacer un préstamo en cualquiera de los meses, solo se le aprueba siempre y cuando el valor del préstamo no supere lo ahorrado hasta ese momento. Si supera el valor aportado, mostrar un mensaje que informe a ese socio que no se aprobó la solicitud de préstamo.
            - Al liquidar la natillera a final de año, hacer la deducción del préstamo y calcular los intereses generados contados a partir del mes que hizo el préstamo. Por ejemplo, si el préstamo lo solicitó en Abril, entonces calcular la tasa desde Mayo hasta Diciembre. La tasa mensual para cobrar será del 2.5% sobre el préstamo.
            - Adicional a lo que el algoritmo ya está mostrando en el momento de liquidar la natillera de los dos socios, también la aplicación deberá mostrar valor del préstamo (si la hicieron), cuántas multas pagó en el año y el valor neto a liquidarle a ambos socios. */

        //Variables
        bool volver = true;
        const double BONO = 0.4; //Snake Case:Notación para constantes.

        while (volver)
        {
            decimal aporteMensual1 = 0, rendimientoMensual1 = 0, aporteTotal1 = 0, rendimientoTotal1 = 0, bonoMensual1 = 0, bonoTotal1 = 0, aporteTotalNeto1 = 0, tasaMensual1;
            decimal aporteMensual2 = 0, rendimientoMensual2 = 0, aporteTotal2 = 0, rendimientoTotal2 = 0, bonoMensual2 = 0, bonoTotal2 = 0, aporteTotalNeto2 = 0, tasaMensual2;
            string continuar;

            //Clase random
            Random random = new Random(); //Esta es la forma de instanciar una clase en objeto

            for (int mes = 1; mes <= 12; mes++)
            {
                Console.WriteLine($"Mes {mes}: Socio 1");
                Console.Write("Ingrese la cantidad que desea ahorrar: ");
                aporteMensual1 = Convert.ToDecimal(Console.ReadLine());

                tasaMensual1 = (decimal)random.Next(1, 51) / 10;
                rendimientoMensual1 = aporteMensual1 * (tasaMensual1 / 100);

                if (aporteMensual1 == 0)
                {
                    Console.WriteLine("Multa aplicada: $20.000");
                    aporteMensual1 -= 20000;
                }

                if (tasaMensual1 < 3.5M)
                {
                    bonoMensual1 = aporteMensual1 * (decimal)BONO;
                    bonoTotal1 += bonoMensual1;
                    bonoMensual1 = 0;
                }

                aporteTotal1 += aporteMensual1;
                rendimientoTotal1 += rendimientoMensual1;

                Console.WriteLine($"Aportes: {aporteMensual1:C}");
                Console.WriteLine($"Tasa: {tasaMensual1}%");
                Console.WriteLine($"Rendimientos: {rendimientoMensual1:C}");
                Console.WriteLine($"Bono: {bonoMensual1:C}");
                Console.WriteLine("---------------------------------------");

                Console.WriteLine($"Mes {mes}: Socio 2");
                Console.Write("Ingrese la cantidad que desea ahorrar: ");
                aporteMensual2 = Convert.ToDecimal(Console.ReadLine());

                tasaMensual2 = (decimal)random.Next(1, 51) / 10;
                rendimientoMensual2 = aporteMensual2 * (tasaMensual2 / 100);

                if (aporteMensual2 == 0)
                {
                    Console.WriteLine("Multa aplicada: $20.000");
                    aporteMensual2 -= 20000;
                }

                if (tasaMensual2 < 3.5M)
                {
                    bonoMensual2 = aporteMensual2 * (decimal)BONO;
                    bonoTotal2 += bonoMensual2;
                    bonoMensual2 = 0;
                }

                aporteTotal2 += aporteMensual2;
                rendimientoTotal2 += rendimientoMensual2;

                Console.WriteLine($"Aportes: {aporteMensual2:C}");
                Console.WriteLine($"Tasa: {tasaMensual2}%");
                Console.WriteLine($"Rendimientos: {rendimientoMensual2:C}");
                Console.WriteLine($"Bono: {bonoMensual2:C}");
                Console.WriteLine("---------------------------------------");
            }
            Console.WriteLine("Socio 1:");
            Console.WriteLine($"Aportes totales: {aporteTotal1:C}");
            Console.WriteLine($"Rendimientos totales: {rendimientoTotal1:C}");
            Console.WriteLine($"Bonos totales: {bonoTotal1:C}");
            Console.WriteLine("---------------------------------------");

            Console.WriteLine("Socio 2:");
            Console.WriteLine($"Aportes totales: {aporteTotal2:C}");
            Console.WriteLine($"Rendimientos totales: {rendimientoTotal2:C}");
            Console.WriteLine($"Bonos totales: {bonoTotal2:C}");
            Console.WriteLine("---------------------------------------");

            aporteTotalNeto1 = rendimientoTotal1 + aporteTotal1 + bonoTotal1;
            aporteTotalNeto2 = rendimientoTotal2 + aporteTotal2 + bonoTotal2;

            Console.WriteLine($"TOTAL NETO Socio 1: {aporteTotalNeto1:C}");
            Console.WriteLine($"TOTAL NETO Socio 2: {aporteTotalNeto2:C}");

            Console.WriteLine("¿Desea ingresar a la natillera para el siguiente año? (s/n)");
            continuar = Console.ReadLine().ToLower();
            if (continuar != "s")
            {
                volver = false;
            }
        }
    }
}