using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

#nullable disable

namespace App
{
    class Program
    {
        static void Main(string[] args)
        {
            bool onPlay = true; //setting a bool to control the game end and start
            string[] boardLine1 = new string[] { "_", "_", "_" }; // drawing board with arrays
            string[] boardLine2 = new string[] { "_", "_", "_" };
            string[] boardLine3 = new string[] { "_", "_", "_" };
            bool cpuHasWon = false; //sets bool to control computer's loss and win
            bool playerHasWon = false; // same thing for the player
            boardPrinter(boardLine1, boardLine2, boardLine3); // calling the function that draws the game board
            int userChoiceToInt = 0; //the player will input his moves with integer inputs
            int cpuChoice = 0; //sets an integer for the cpu's move

            // a list of possible moves so its impossible to do the same move twice 
            List<int> possibleMoves = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9 }; 
            Console.WriteLine("You are X, choose from 1 to 9 to put your X");
            while (onPlay == true)
            {
                //player always starts first
                bool isPlayerTurn = true;
                Console.WriteLine("Your Move :");

                while (isPlayerTurn == true)
                {
                    //making sure the player doesnt input something other than an integer
                    while (!int.TryParse(Console.ReadLine(), out userChoiceToInt))
                    {
                        Console.WriteLine("Please input a valid move (not already made by the Player or the Computer)");
                    }
                    //also making sure that the move he put is possible to make
                    if (!possibleMoves.Contains(userChoiceToInt) || userChoiceToInt == cpuChoice)
                    {
                        Console.WriteLine("Please input a valid move that is not already done");
                        continue; 
                    }

                    // player's move
                    if (userChoiceToInt < 4)
                    {
                        // a logic to put the player's "X" in the appropriate place in the board
                        boardLine1[userChoiceToInt - 1] = "X";
                        Console.WriteLine("---------------");
                        //removes the player's move from the possible moves list
                        possibleMoves.Remove(userChoiceToInt);
                    }
                    else if (userChoiceToInt > 3 && userChoiceToInt < 7)
                    {
                        boardLine2[userChoiceToInt - 4] = "X";
                        Console.WriteLine("----------------");
                        possibleMoves.Remove(userChoiceToInt);
                    }
                    else if (userChoiceToInt > 6)
                    {
                        boardLine3[userChoiceToInt - 7] = "X";
                        Console.WriteLine("----------------");
                        possibleMoves.Remove(userChoiceToInt);
                    }
                    //prints the board again with the player's move
                    boardPrinter(boardLine1, boardLine2, boardLine3);

                    // Check if the player has won
                    if ((boardLine1[0] == "X" && boardLine1[1] == "X" && boardLine1[2] == "X")
                        || (boardLine2[0] == "X" && boardLine2[1] == "X" && boardLine2[2] == "X")
                        || (boardLine3[0] == "X" && boardLine3[1] == "X" && boardLine3[2] == "X")
                        || (boardLine1[1] == "X" && boardLine2[1] == "X" && boardLine3[1] == "X")
                        || (boardLine1[0] == "X" && boardLine2[0] == "X" && boardLine3[0] == "X")
                        || (boardLine1[2] == "X" && boardLine2[2] == "X" && boardLine3[2] == "X")
                        || (boardLine1[2] == "X" && boardLine2[1] == "X" && boardLine3[0] == "X")
                        || (boardLine1[0] == "X" && boardLine2[1] == "X" && boardLine3[2] == "X"))
                    {
                        Console.WriteLine("You won!");
                        playerHasWon = true;
                        onPlay = false;
                        break;
                    }
                    /*if you see here why i made playerHasWon and cpuHasWon booleans, it's to avoid a tie if the player
                    or the cpu wins with a full board*/
                    else if(boardLine1[0] != "_" && boardLine1[1] != "_" && boardLine1[2] != "_"
                        && boardLine2[0] != "_" && boardLine2[1] != "_" && boardLine2[2] != "_"
                        && boardLine3[0] != "_" && boardLine3[1] != "_" && boardLine3[2] != "_"
                        && cpuHasWon == false && playerHasWon == false)
                    {
                        Console.WriteLine("Tie !");
                        onPlay = false;
                        break;
                    }                   
                    else
                    {
                        //player's turn has finished
                        isPlayerTurn = false;
                    }
                }

                // Check if the game has ended after the player's turn
                if (!onPlay)
                {
                    break;
                }
                // cpu's turn
                // clearing the console for better gaming experience
                Console.Clear();
                Console.WriteLine("----------------");
                Console.WriteLine("The computer made it's move");
                //cpu's move will be a random number
                Random rnd = new Random();
                cpuChoice = rnd.Next(1, 10);
                /* checks if the cpu's choice is the same as the player's one or it's not in the possible moves to avoid 
                making a move twice*/
                while (cpuChoice == userChoiceToInt || !possibleMoves.Contains(cpuChoice))
                {
                    cpuChoice = rnd.Next(1, 10);
                }

                if (cpuChoice < 4)
                {
                    boardLine1[cpuChoice - 1] = "O";
                }
                else if (cpuChoice > 3 && cpuChoice < 7)
                {
                    boardLine2[cpuChoice - 4] = "O";
                }
                else
                {
                    boardLine3[cpuChoice - 7] = "O";
                }
                //removes the cpu's choice from the possible move
                possibleMoves.Remove(cpuChoice);
                //redraws the board
                boardPrinter(boardLine1, boardLine2, boardLine3);

                // Check if the CPU has won
                if ((boardLine1[0] == "O" && boardLine1[1] == "O" && boardLine1[2] == "O")
                    || (boardLine2[0] == "O" && boardLine2[1] == "O" && boardLine2[2] == "O")
                    || (boardLine3[0] == "O" && boardLine3[1] == "O" && boardLine3[2] == "O")
                    || (boardLine1[1] == "O" && boardLine2[1] == "O" && boardLine3[1] == "O")
                    || (boardLine1[0] == "O" && boardLine2[0] == "O" && boardLine3[0] == "O")
                    || (boardLine1[2] == "O" && boardLine2[2] == "O" && boardLine3[2] == "O")
                    || (boardLine1[2] == "O" && boardLine2[1] == "O" && boardLine3[0] == "O")
                    || (boardLine1[0] == "O" && boardLine2[1] == "O" && boardLine3[2] == "O"))
                {
                    Console.WriteLine("The Computer Won!");
                    cpuHasWon = true;
                    onPlay = false;
                    break;
                }
                else if(boardLine1[0] != "_" && boardLine1[1] != "_" && boardLine1[2] != "_"
                        && boardLine2[0] != "_" && boardLine2[1] != "_" && boardLine2[2] != "_"
                        && boardLine3[0] != "_" && boardLine3[1] != "_" && boardLine3[2] != "_"
                        && cpuHasWon == false && playerHasWon == false)
                {
                    Console.WriteLine("Tie !");
                    onPlay = false;
                    break;
                }
                else
                {
                    //it's player's turn
                    isPlayerTurn = true;
                }
            }
        }
        //Method that returns nothing but writes the game board
        public static void boardPrinter(string[] boardLine1, string[] boardLine2, string[] boardLine3)
        {
            string bl1 = string.Join(" ", boardLine1);
            string bl2 = string.Join(" ", boardLine2);
            string bl3 = string.Join(" ", boardLine3);
            Console.WriteLine(bl1);
            Console.WriteLine(bl2);
            Console.WriteLine(bl3);
        }
    }
}











//les commentaires  ::


//console.title change le titre de la console
//decimal, int, long, float, double :; ca c des types de variables portants des nombres
//reecrire le nom de la variable sert a changer sa valeur
// nomdevariable = (type_de_variable)nomdevariable2  ;; sert a transformer nomdovariable2 au type entre ()
//pour ecrire une valeur binaire on ajoute 0b_  ;;  pour une valeur hexadecimale on ajoute 0x_
//la variable long/decimal convient les nombres hexadecimaux
/*
Long -> l ou L
float -> f ou F
double -> d ou D
decimal -> m ou M
puissance -> e ou E  (les puissances marchent avec les variables de type double)
*/
//Arithmetique on a : +, -, *, /, %(sert a donner le reste d'une division euclidienne)
//Egalité ou inegalité :  ==, !, <, >, <=, >=,
// (5 != 6) est ce que 5 est different de 6
// raccourci pour ajouter une valeur a une variable :: +=, -=, *=, /=
// le ++ et -- ajoute ou retire de 1 ;; par exemple trois = 3 ;; trois++; :: on a ajouté 1 a la variable trois
// ++result ajoute 1 avant, result++ ajoute 1 après
// !true veut dire false, l'inverse est correct, on peut mettre des variables au lieu de true ou false
/*booleen binaire conditionel   :  &&, ||,   exemple : bool reda = (true && true); ca va afficher true
&& veut dire : je veux que cette expression ses deux valeurs soient true a le meme fois, si false et true : ca va donner false
|| veut dire : si un de ces deux est present (true et false) donc c'est ok
*/
/*
int time = 20
string result = (time > 18) ? "good day" : "good evening";
Console.Writeline(result);

c'est une autre methode de dire if
*/

// Console.Writeline($"you name is {variable}"); ;; le $ et les {} permettent de faire enter une ou plusieurs variables dans une chaine de caracteres
// on a pas besoin de mettre des {} apres un if si on a une seule instruction 
//pour les conditions on a if, else, else if  ;; on peut mettre plusieurs if ou else if successifs
/*si on a plusieurs if, on peut utiliser switch()

exemple : 
int nombre = 13
switch(nombre){
    case 13:
        Console.Writeline("test");
    break;
    default:
        Console.Writeline("si aucun cas des précendent n'a marché, le default sera exécuté");
}
*/
/*on a :
int age = 13
bool result;
result = (age >= 13) ? true : false;
Console.Writeline(result)             ::       ca va afficher true

*/
/*
string word = "i should get";
            int i = 0;
            while(i < 10){
                i++;
                Console.WriteLine(word);

                if(i == 6)
                    continue;
                
                Console.WriteLine("better");
            }


            ca c un exemple d'une boucle
*/
/*
            string word = "i need a gf";
            int i;
            for(i = 1; i <= 10; i++)
                Console.WriteLine(word);


                autre exemple de boucle
*/

// accès au methodes : public, private, protected
/*
exemple dune methode
        static void Main(string[] args)
        {  
            say("Have you changed Reda ?", "2024");
            say("I don't know, you know", "Reda");
        }
        public static void say(string message, string name)
        {
            Console.WriteLine(name + " : " + message);
        }
*/
/*
modification avec reference
        static void Main(string[] args)
        {  
            int num = 3;
            int num2 = 4;
            NumReset(ref num, ref num2);
            Console.WriteLine(num);
            Console.WriteLine(num2);
        }

        public static void NumReset(ref int nb1, ref int nb2)
        {
            nb1 = 0;
            nb2 = 1;
        }
*/
/*
references chez les methodes ?:
        static void Main(string[] args)
        {  
            int num = 3;
            int num2 = 4;
            NumReset(ref num, ref num2);
            Console.WriteLine(num);
            Console.WriteLine(num2);
        }

        public static void NumReset(ref int nb1, ref int nb2)
        {
            nb1 = 0;
            nb2 = 1;
        }

*/

//Wesh c trop compliqué tout ca
/*
Les structures, exemple je crois
    struct Disk{
        public string brand;
        public int capacity;
    }
        class Program
    {
        //Main est la méthode de Program
        static void Main(string[] args)
        {
            Disk e;
            e.Brand = "Toshiba";
            e.Capacity = "2000"
        }
    
    }
*/

/*
ca c la structure
public struct Disk
    {

        les champs :

        public string Brand;
        public int Capacity;

        un constructeur

        public Disk(string brand, int capacity)
        {
            Brand = brand;
            Capacity = capacity;
        }

        une methode :

        public override string ToString() => $"Disque de marque {Brand} et d'une capacité de {Capacity}";
    }
    class Program
    {
        //Main est la méthode de Program
        static void Main(string[] args)
        {
            Disk e = new Disk("Toshiba", 2000);
            Console.WriteLine(e);
        }
    
    }
*/

/*

using System;

namespace MyApp // Note: actual namespace depends on the project name.
{
    public class Stock
    {
        public int Capacity;
        public string Marque;
        public Stock()
        {   
            Capacity = default(int);
            Marque = "";
        }

    }
    class Program
    {
        //Main est la méthode de Program
        static void Main(string[] args)
        {
            Stock new_disques = new Stock();
            Stock new_mouses = new Stock();
            new_disques.Capacity = 23;
            new_disques.Marque = "Samsung";
            Console.WriteLine("The new stock of hard drives contains : "+ new_disques.Capacity + " Drives ");
            Console.WriteLine("The brand of those hard drives is : " + new_disques.Marque);
        }
    
    }
}


CA C UN AUTRE EXEMPLE DE CLASSE PERSONALISEE
MAIS PUTAIN CA SE TERMINE PAS C PRESQUE 220 LIGNES DE COMMENTAIRES
*/
/*
encapsulation ?? exemple ??

    public class Window
    {
        private string _title;
        public string Title
        {
            get
            {
                return _title;
            }
            set 
            {
                _title = value;
            }
        }
        public Window(string title)
        {
            this.Title = title;
        }
    }
    class Program
    {
        //Main est la méthode de Program
        static void Main(string[] args)
        {   
            Window win = new Window("Ma fenetre");
            Console.WriteLine(win.Title);
            
        }


*/

/*
heritage ?
using System;

namespace MyApp // Note: actual namespace depends on the project name.
{

    class Car
    {
        public int Hp {get; set;}
        public string Model {get; set;} = "";
        public string Brand {get; set;} = "";
        public Car(string model)
        {
            this.Model = model;
        }

    }

    class Engine : Car
    {

        public Engine(string Brand, int hp, string model) : base(model)
        {
            this.Hp = hp;
            this.Brand = Brand;
        }
        public void Msg()
        {
            Console.WriteLine($"This is a {Brand} {Model} Model with {Hp} of horse power");
        }
    }
    class Program
    {
        //Main est la méthode de Program
        static void Main(string[] args)
        {    
            Engine g = new Engine("Ford", 700, "Mustang");
            g.Msg();
        }
    }
}

*/
/*

surcharge des operateurs, (addition)
    public class Armor
    {
        public int defense {get; set;}
        public int hp {get; set;}
        public Armor(int armorHp = 500, int def = 100)
        {
            this.defense = def;
            this.hp = armorHp;
        }
        public static Armor operator +(Armor a, Armor b)
        {
            return new Armor(a.hp + b.hp, a.defense + b.defense);
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Armor ar = new Armor();
            Armor ar2 = new Armor(350, 300);
            Console.WriteLine($"Your Armor has {ar.hp}HP / {ar.defense}DEF");
            Console.WriteLine($"Your Armor has {ar2.hp}HP / {ar2.defense}DEF");
            Armor big = ar + ar2;
            Console.WriteLine($"Your Armor has {big.hp}HP / {big.defense}DEF");
        }
    }
*/
/*
exemple de polymorphisme
class fighter
    {
        public int healthPoints;
        public virtual void Fight()
        {
            Console.WriteLine("We are Fighters");
        }
    }
    class Dog : fighter
    {
        new public int healthPoints = 450;
        public override void Fight()
        {
            Console.WriteLine("Woof Woof");
        }
    }
    class Human : fighter
    {
        new public int healthPoints = 1500;
        public override void Fight()
        {
            base.Fight();
            Console.WriteLine("Let's go !");
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Human h1 = new Human();
            Human h2 = new Human();
            Dog d1 = new Dog();
            Dog d2 = new Dog();
            fighter[] fightersArmy = new fighter[] {h1, h2, d1, d2};
            foreach (var f in fightersArmy)
            {
                f.Fight();
            }
        }
    }
*/
/*
cibler un tableau specifique
        static void Main(string[] args)
        {
            int[,] array2D = new int[,] {{1, 2, 3}, {4, 5, 6}};
            int[] secondArray = new int[array2D.GetLength(1)];
            for(int i = 0; i < array2D.GetLength(1); i++)
            {
                secondArray[i] = array2D[1, i];
            }
            foreach(var el in secondArray)
            {
                Console.WriteLine(el);
            }
        }

*/

/*
Debug.Assert donne l erreur que pour le devlopeeur
Trace.Assert donne l erreur pour l utilisateur et le dev
*/
/*
cibler la deuxieme dimension dans un tablo
int[,] array = new int[4, 4];
for (int i = 0; i < 4; i++)
{
    array[i, 1] = 4;
}
*/

/*
joli erreur


        static void Main(string[] args)
        {
            Console.WriteLine("saisir un nombre : ");
            try
            {
            int number = Convert.ToInt32(Console.ReadLine());
            Console.Write($"Le nombre saisi est : {number}");
            }
            catch(Exception)
            {
                Console.Write("Saisi incorrect !");
            }
        }
*/

/*
trucs utiles avec les strings
--   String.Empty est comme si on dit null ou =""
--  string s = new string("M", 40) repete M 40 fois

-- char[] letters = {'b', 'j', 'r'}
   string s = new string(letters)  ceci rassemble les characteres 

*/

/*
jolie facon de string et int
     static void Main(string[] args)
        {
            var redaInfo = (name : "reda", age : 15);
            Console.Write("His name is {0} and he is {1} years old", redaInfo.name, redaInfo.age);
        }
*/
/*
string s = "reda"
string s = console.writeline(s.ToUpper());  ca rend tout en majuscule
-------------
string s = console.writeline(s.Replace('o', 'i'))  ca remplace une lettere
*/

/*
supprime les characteres au extrémités
   string s = "-_Bonjour//";
            char[] chars = {'-', '/', '_'};
            Console.WriteLine(s.Trim(chars));
*/
/*
des systems utiles
using System;
using System.Diagnostics;
using System.Linq;
using System.Text
*/
/*
            StringBuilder s = new StringBuilder();
            s.Append("Hello");
            s.Append("World");
            Console.WriteLine(s);
            s.Replace('o', 'e');
            s.Insert(0, "SO)
            s.Split(" ")
*/

/*
recuperer et afficher du texte d'un fichier txt
static void Main(string[] args)
        {
            string filePath = "data/names.txt";
            string namesTxt = File.ReadAllText(filePath);
            Console.WriteLine(namesTxt);
        }
*/
/*
mettre chaque nom dans une variable
        static void Main(string[] args)
        {
            string filePath = "data/names.txt";
            string[] namesTxt = File.ReadAllLines(filePath);
            foreach(var stringName in namesTxt)
            {
                Console.WriteLine(stringName);
            }
        }

*/
/*
affiche les lignes ?
        static void Main(string[] args)
        {
            string filePath = "data/names.txt";
            using(StreamReader sr = new StreamReader(filePath))
            {
                string? line;
                while((line = sr.ReadLine())!= null)
                {
                    Console.WriteLine(line);
                }
            }
        }
*/
/*
remplace le contenu du fichier
      static void Main(string[] args)
        {
            string filePath = "data/names.txt";
            using(StreamWriter sw = new StreamWriter(filePath))
            {
                sw.WriteLine("Voila je remplace tous les noms");
            }
        }
*/

/*
efiiin g ciblé la première dimension
            string[,,] letters = new string[,,] {{{"a", "b", "c"}, {"d", "e", "f"}, {"g", "h", "i"}}};
            
            // Loop over the second dimension to print only the first row
            for(int j = 0; j < letters.GetLength(0); j++)
                    for(int q = 0; q < letters.GetLength(2); q++)   
                        Console.Write(letters[0, j, q] + " ");



deuxieme
            string[,,] letters = new string[,,] {{{"a", "b", "c"}, {"d", "e", "f"}, {"g", "h", "i"}}};
            
            // Loop over the second dimension to print only the first row
            for(int i = 0; i < letters.GetLength(0); i++)
                    for(int q = 0; q < letters.GetLength(2); q++)   
                        Console.Write(letters[i, 1, q] + " ");



troisieme
            string[,,] letters = new string[,,] {{{"a", "b", "c"}, {"d", "e", "f"}, {"g", "h", "i"}}};
            
            // Loop over the second dimension to print only the first row
            for(int i = 0; i < letters.GetLength(0); i++)
                    for(int q = 0; q < letters.GetLength(2); q++)   
                        Console.Write(letters[i, 2, q] + " ");
*/
/*
                /*boardLine1[0] = playerPick?.FirstOrDefault() ?? '_';
                if(computerMove == 1)
                    boardLine1[0] = pcMove[0];
                    else if(computerMove == 2)
                        boardLine1[1] = pcMove[0];
                        else if(computerMove == 3)
                            boardLine1[2] = pcMove[0];*/
/*
effacer premier et dernier charactere d'un string
string s = "Hello";
s.Substring(1, s.Length -2);
*/

/*
donner la plus grande valeur et minimale valeur dans une liste
using System;
using System.Linq;


public class Kata
{
  public int Min(int[] list)
  {
    return list.Min();
  }
  
  public int Max(int[] list)
  {
    return list.Max();
  }
}

creer une liste en supprimant le max et le min
int[] arr = new int[] {1, 2, 3, 4, 5};
int min = arr.Min();
int max = arr.Max();
int[] newArr = arr.Where(n => n != min && n != max).ToArray();


----------


reverse the string
public static class Kata
{
  public static string Solution(string str) 
  {
        string reversed = new string(str.Reverse().ToArray());
        return reversed;
  }
}
*/