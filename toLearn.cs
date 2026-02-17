using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


class Program {
  static void Main( string[] args){
    string num = "349";
    short numParsed;
    bool succed = short.TryParse( num, out numParsed );
    Console.WriteLine ( ++numParsed );
    Console.WriteLine ( numParsed );
  }
} 