internal class Program
{
    private static void Main(string[] args)
    {
        /*Peso: 50%
        Juego:
        Desarrollar el juego “Adivina el número” en un programa de C#. El juego es muy sencillo, consiste en adivinar un número ℕ aleatorio que el sistema escoge de un determinado rango y lo guarda en memoria sin ser revelado.
        Por ejemplo: El sistema escoge aleatoriamente un número entre 0 y 100, ese número NO SE PUEDE REVELAR ya que es el número que se adivinará, por ende, dicho número se almacenará en memoria. Los participantes comenzarán en orden a jugar y se turnarán para ingresar por pantalla un número ℕ hasta acertar el número oculto y salir ganador.
        El juego debe tener la funcionalidad de escoger el número de participantes que jugarán: mínimo 2 y máximo 4 integrantes. Dependiendo de la cantidad de jugadores, el número ℕ aleatorio se generará en los siguientes rangos:
            - Si participan 2 jugadores, el número ℕ aleatorio se generará entre 0 y 50
            - Si participan 3 jugadores, el número ℕ aleatorio se generará entre 0 y 100
            - Si participan 4 jugadores, el número ℕ aleatorio se generará entre 0 y 200
        Cada jugador comenzará su turno intentando adivinar ese número ℕ aleatorio. El programa deberá mostrarle al jugador la siguiente información:
            - Si el número ingresado es mayor al número aleatorio, entonces mostrar por pantalla la palabra “MENOR” y darle la oportunidad al siguiente jugador.
            - Si el número ingresado es menor al número aleatorio, entonces mostrar por pantalla la palabra “MAYOR” y darle la oportunidad al siguiente jugador.
            - Si el número ingresado coincide con el número aleatorio, entonces mostrar por pantalla la palabra “¡HAS GANADO!”. Aquí ya finaliza el juego.
        El programa deberá estar en capacidad de pedir a los jugadores si desean un nuevo “tirito” para volver a jugar y borrar consola, de lo contrario, finalizar el programa. */

        // Obtener el número de jugadores
        int numJugadores;
        do
        {
            Console.WriteLine("Ingrese el número de jugadores (2-4): ");
            numJugadores = int.Parse(Console.ReadLine());
        } while (numJugadores < 2 || numJugadores > 4);

        // Generar número aleatorio
        int numeroAleatorio = GetNumeroAleatorio(numJugadores);

        // Iniciar juego
        bool seguirJugando = true;
        while (seguirJugando)
        {
            // Recorrer jugadores
            for (int i = 1; i <= numJugadores; i++)
            {
                // Mostrar turno del jugador
                Console.WriteLine("Turno del jugador {0}", i);

                // Pedir un número al jugador
                int numeroIngresado;
                do
                {
                    Console.WriteLine("Ingrese un número: ");
                    numeroIngresado = int.Parse(Console.ReadLine());
                } while (numeroIngresado < 0 || numeroIngresado > GetRangoMaximo(numJugadores));

                // Evaluar el número ingresado
                if (numeroIngresado == numeroAleatorio)
                {
                    // Jugador gana
                    Console.WriteLine("¡Felicidades, jugador {0}, has ganado!", i);
                    seguirJugando = false;
                    break;
                }
                else if (numeroIngresado > numeroAleatorio)
                {
                    Console.WriteLine("El número es menor.");
                }
                else
                {
                    Console.WriteLine("El número es mayor.");
                }
            }

            // Preguntar si quieren volver a jugar
            if (seguirJugando)
            {
                Console.WriteLine("¿Desean volver a jugar? (S/N)");
                string respuesta = Console.ReadLine().ToUpper();
                seguirJugando = respuesta == "S";
            }
        }

        Console.WriteLine("Presione cualquier tecla para salir...");
        Console.ReadKey();
    }

    static int GetNumeroAleatorio(int numJugadores)
    {
        int rangoMaximo = GetRangoMaximo(numJugadores);
        return new Random().Next(rangoMaximo + 1);
    }

    static int GetRangoMaximo(int numJugadores)
    {
        switch (numJugadores)
        {
            case 2:
                return 50;
            case 3:
                return 100;
            case 4:
                return 200;
            default:
                return 0;
        }
    }
}