using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/* simple

class Program {
  static void Main( string[] args){
    string num = "349";
    short numParsed;
    bool succed = short.TryParse( num, out numParsed );
    Console.WriteLine ( ++numParsed );
    Console.WriteLine ( numParsed );
  }
} 

*/

/* simple operation

class Program {
  static void Main( string[] args){

    const float discount = 20f;

    float totalPrice;

    if ( float.TryParse (Console.ReadLine(), out totalPrice) ){
      Console.WriteLine( totalPrice*(1-(discount/100)) );
    }

  }
} 

*/

/* Simple input output

class Program {
  static void Main( string[] args ){

    string name;
    long phoneNumber;
    byte age;

    Console.Write( "Write your name: ");
    name = Console.ReadLine();

    Console.Write("Write your phone number: ");
    long.TryParse( Console.ReadLine(), out phoneNumber );
    
    Console.Write("Write your age: ");
    byte.TryParse( Console.ReadLine(), out age );

    Console.WriteLine($"\n{name}.\n{phoneNumber}.\n{age}.");

  }
}

*/