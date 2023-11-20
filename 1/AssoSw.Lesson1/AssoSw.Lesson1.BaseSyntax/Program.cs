using System;

namespace AssoSw.Lesson1.BaseSyntax
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            /***** Commenti *****/
            // Questo è un commento su una singola riga

            /*
             * Questo è un commento su più righe
             */

            /***** Variabili e Costanti *****/
            int myFirstVariable;
            myFirstVariable = 100;
            Console.WriteLine("Questo è il valore della mia prima variabile: " + myFirstVariable);
            const string MyFirstConst = "Prima Costante!";
            Console.WriteLine("Questo è il valore della mia prima costante: " + MyFirstConst);
            var myFirstImplicitVariable = "Questa è una variabile implicita";
            Console.WriteLine("Questo è il valore della mia prima variabile implicita: " + myFirstImplicitVariable + " ed è di tipo " + myFirstImplicitVariable.GetType());
            var myFirstImplicitVariable1 = 512;
            Console.WriteLine("Questo è il valore della mia prima variabile implicita: " + myFirstImplicitVariable1 + " ed è di tipo " + myFirstImplicitVariable1.GetType());

            /***** Primitive Types *****/
            byte byteVar = 200;
            // byte byteVar1 = 300; // Errore!
            Console.WriteLine("Questo è il valore di una variabile di tipo byte: " + byteVar);

            int intVar = 9999;
            // int intVar1 = "9999"; // Errore!
            Console.WriteLine("Questo è il valore di una variabile di tipo intero: " + intVar);

            double doubleVar = 1564.52;
            Console.WriteLine("Questo è il valore di una variabile di tipo double: " + doubleVar);
            double doubleVarExp = 8.45e5; // Notazione scientifica: è pari a 8.45*10^5
            Console.WriteLine("Questo è il valore di una variabile di tipo double con notazione scientifica: " + doubleVarExp);
            float floatVar = 120.5f;
            // float floatVar1 = 120.5; // Errore!
            Console.WriteLine("Questo è il valore di una variabile di tipo float: " + floatVar);

            bool boolVar = true;
            Console.WriteLine("Questo è il valore di una variabile di tipo boolean: " + boolVar);

            char char1 = 'X';
            char char2 = '\x0058'; // esadecimale
            char char3 = '\u0058'; // rappresentazione Unicode
            Console.WriteLine("Questi sono i valori delle variabili di tipo char: " + char1 + " - " + char2 + " - " + char3);

            string string1 = "Questa è una stringa!";
            string string2 = "Questa è una stringa caratteri di \'escape\'!";
            Console.WriteLine("Questi sono i valori delle variabili di tipo string: " + string1 + " - " + string2);

            DateTime myFirstDatetime = DateTime.Now;
            Console.WriteLine("Questo è il valore di una variabile di tipo DateTime: " + myFirstDatetime);

            /***** Casting *****/
            // Casting implicito
            double myDoubleImplicitConvertedVar = intVar; // Automaticamente converte da int a double
            // short shortVar = intVar;
            Console.WriteLine("Questo è il valore della variable con casting implicito: " + myDoubleImplicitConvertedVar);
            // Casting esplicito
            int myIntExplicitConvertedVar = (int)doubleVar;
            Console.WriteLine("Questo è il valore della variable con casting esplicito: " + myIntExplicitConvertedVar);

            /***** Lavorare con le stringhe *****/
            string quote = "La citazione è \"Si vive una volta sola!\"";
            Console.WriteLine(quote);
            string name = "Matteo";
            string surname = "Rossi";
            string firstConcat = "Ciao sono " + name + " " + surname;
            string secondConcat = String.Format("Ciao sono {0} {1}", name, surname);
            string thirdConcat = $"Ciao sono {name} {surname}";
            Console.WriteLine(@$"Il risultato della concatenazione è:
    {firstConcat}
    {secondConcat}
    {thirdConcat}");

            string myFirstString = "Ciao mondo";
            int myLengthString = myFirstString.Length; // 10
            string myUpperString = myFirstString.ToUpper(); // CIAO MONDO
            string myLowerString = myFirstString.ToLower(); // ciao mondo
            string mySubString = myFirstString.Substring(5); // mondo
            int myIndexOfString = myFirstString.IndexOf('o'); // 3
            Console.WriteLine(@$"Il risultato della manipolazione della stringa è:
Length: {myLengthString}
ToUpper: {myUpperString} 
ToLower: {myLowerString} 
Substring: {mySubString} 
IndexOf: {myIndexOfString}");

            /***** Lavorare con i numeri *****/
            int a = 10;
            int b = 2;
            int sum = a + b;
            int sub = a - b;
            int mul = a * b;
            int div = a / b;
            int module = a % b;
            int expression = (a * b) + b;
            Console.WriteLine($@"Il risultato delle espressioni è:
Somma: {sum}
Sottrazione: {sub}
Moltiplicazione: {mul}
Divisione: {div}
Modulo: {module}
Espressione: {expression}");
            // Incremento
            int var1 = 1;
            int var2 = ++var1;
            Console.WriteLine($"Incremento prefix - var1 = {var1} | var2 = {var2}");
            int var3 = 1;
            int var4 = var3++;
            Console.WriteLine($"Incremento suffix - var3 = {var3} | var4 = {var4}");
            // Operatore di assegnazione composta
            var4 += 10; // a = a + 10
            Console.WriteLine($"Valore di var4 dopo assegnazione composta: {var4}");
            // La classe Math
            int f = -36;
            double abs = Math.Abs(f);
            double pow = Math.Pow(b, 2);
            double min = Math.Min(a, b);
            double max = Math.Max(a, b);
            double sqrt = Math.Sqrt(b);
            Console.WriteLine($@"Il risultato delle espressioni con la classe System.Math è:
Assoluto: {abs}
Pow: {pow}
Min: {min}
Max: {max}
Sqrt: {sqrt}");

            /***** Operatori Logici e di Comparazione *****/
            Console.WriteLine(@$"Il risultato delle comparazioni:
Minore {5 < 6}
Maggiore {5 > 6}
Uguale {5 == 6}
Diverso {5 != 6}");

            int myLogicalIntVar = 10;
            bool firstLogicalExpression = (5 < 6) && (myLogicalIntVar == 10);
            bool secondLogicalExpression = (5 < 6) || (myLogicalIntVar == 5);
            bool thirdLogicalExpression = !(myLogicalIntVar == 10);
            Console.WriteLine(@$"Il risultato delle espressioni logiche: {firstLogicalExpression} {secondLogicalExpression} {thirdLogicalExpression}");

            // Operatore ternario
            int x1 = 1;
            int x2 = 2;
            int x3 = x1 > x2 ? x1 : x2;
            Console.WriteLine($"Risultato operatore ternario: {x3}");

            // Operatore null coalesce
            string coalesceVar1 = null;
            string coalesceVar2 = null;
            string coalesceVar3 = "prova!";
            string coalesceResult = coalesceVar1 ?? coalesceVar2 ?? coalesceVar3 ?? "Valore predefinito";
            Console.WriteLine($"Risultato operatore null coalesce: {coalesceResult}");

            // Operatore null conditional
            string conditionalVar = null;
            // int length = conditionalVar.Length; // Errore!
            int? length = conditionalVar?.Length;
            Console.WriteLine($"Risultato operatore null conditional: {length}");

            /***** Input/Output Console *****/
            Console.WriteLine("Inserisci il primo numero: ");
            var firstNumberString = Console.ReadLine();
            Console.WriteLine("Inserisci il secondo numero: ");
            var secondNumberString = Console.ReadLine();
            int firstNumber = Convert.ToInt32(firstNumberString);
            int secondNumber = Convert.ToInt32(secondNumberString);
            int resultSum = Add(firstNumber, secondNumber);
            Console.WriteLine("Il risultato della somma è: " + resultSum);

            Console.ReadKey();
        }


        ///<summary>
        /// Il metodo esegue la somma di due numeri interi
        ///</summary>
        ///<param name="number1">Primo numero</param>
        ///<param name="number2">Secondo numero</param>
        ///<returns>Risultato della somma</returns>
        public static int Add(int number1, int number2)
        {
            return number1 + number2;
        }
    }
}