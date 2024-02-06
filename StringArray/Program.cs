using System;
using System.Security.Cryptography.X509Certificates;
using System.Text.RegularExpressions;

namespace StringArrayApp
{
  class Program
  {
    static void Main(string[] args)
    {
      // Sample data array, these are the names of my old D&D party.
      string[] stringArray = [
        "Aleria",
        "Icathor",
        "Charles",
        "Sarah",
        "Ahraan",
        "Anri",
      ];
      // Run the function defined below
      SortStringArray(stringArray);


      // Define the function:
      List<string> SortStringArray(string[] str)
      {
        // Initialize a new list.
        List<string> _sorted = new List<string>();

        // Ask user for input about what to filter.
        Console.WriteLine("What letter do you wish to filter out?");
        string _filterLetter = Console.ReadLine()!;
        
        // For each item in the asked for list (see args for function),
        // check each item if it starts with the letter the user input
        // then add that to another object that handles the sorted items. 
        foreach(var item in str)
        {
          if(item.ToLower().StartsWith(_filterLetter.ToLower()))
          {
            _sorted.Add(item);
          }
        }

        // Sort sorted list alphabetically.
        _sorted.Order();
        
        // For each sorted item, write it on a new console line.
        // Additionally, add that item to a string, and separate
        // the items with a comma and a space.
        string _fileContent = String.Empty;
        foreach(var item in _sorted)
        {
          Console.WriteLine(item);
          _fileContent += item + ", ";
        }
        
        // Create a file, named after the letter input by the user.
        // To avoid duplicate file errors, also add a stringified 
        // and format-corrected DateTime.Now.
        // To this file, write the contents of the concatenated string "_fileContent"
        string _dateTimeString = DateTime.Now.ToString();
        File.WriteAllText($"D:/Skolkaos/{_filterLetter} --- {_dateTimeString.Replace(":", "-")}.txt", _fileContent);

        // return List<string> _sorted;     
        return _sorted;
      }
      
    }
  }

}