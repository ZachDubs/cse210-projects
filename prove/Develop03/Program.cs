using System;
using System.Security.Cryptography.X509Certificates;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main()
    {
        Scripture s1 = new Scripture("John 3:16", "For God so loved the World, that he gave his only begotten Son, that whosoever believeth in him should not perish, but have everlasting life.");
        Reference r1 = new Reference("John", 3, 16);
        Console.WriteLine(s1.GetOutput());

        Scripture s2 = new Scripture("Proverbs 3:5-6", "Trust in the Lord with all thine Heart; and lean not unto thine own understanding; In all thy ways acklowledge him, and he shall direct thy paths.");
        Reference r2 = new Reference("Proverbs", 3, 5, 6);
        

        
        
        

    }
}
