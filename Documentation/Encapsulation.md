# Encapsulation and Cohesion (10%)

## Code Showcasing Encapsulation And Cohesion
```cs
 /// <summary>
 /// This class is responsible for parsing the name of the cinema from a text file.
 /// Static class to provide a method for retrieving the name.
 /// </summary>
 public static class NameParser
 {
     // Path to the text file containing the name data
     private static string path = $@"{Environment.CurrentDirectory}\Resources\Name.txt";

     /// <summary>
     /// Struct representing the name data.
     /// </summary>
     public struct NameData
     {
         public string Name;
     }
     /// <summary>
     /// Method to retrieve the name data from the text file.
     /// </summary>
     /// <returns></returns>
     public static List<NameData> GetName()
     {
         // List to store the name data. type struct
         List<NameData> NameDataList = new List<NameData>();

         // Read all lines from the file and process each line
         foreach (string line in File.ReadAllLines(path))
         {
             // Split the line into parts using '%' as a delimiter and trim the brackets
             string[] parts = line.Trim('[', ']').Split('%');

             // Create a new instance of NameData for each line
             NameData Name = new NameData();

             // Process each part of the line
             foreach (string part in parts)
             {
                 // Split the part into key-value pairs using ':' as a delimiter
                 string[] keyValue = part.Split(':');

                 // Check if the key-value pair has exactly two elements
                 if (keyValue.Length == 2)
                 {
                     // Gets the Name data from the file
                     switch (keyValue[0])
                     {
                         case "Name":
                             Name.Name = keyValue[1];
                             break;
                     }
                 }
             }
             // Add the processed NameData to the list
             NameDataList.Add(Name);
         }
         // Return the list of NameData
         return NameDataList;
     }
 }
```
## Explain On How Encapsulation Is Accomplished
In The Program Above It's Retrieving The Name Of The Cinema Application Which Is Hullywood Cinema From a File By Using a Parser. The Class is Static Meaning Multiple Instances Of a Class Isn't Possible. Methods And Member Varaibles Have To Be Identified As Static. Encapsulation Is Applied Above Since The Member Varaible "path" Is Private Making It an Internal State, Allowing It To Only Be Specific Towards The Class. Cohesion Is Executed Because The Attributes Of The Class Allow a Certain Purpose To Be Fulfilled. 

## Class Diagram For Encapsulation And Cohesion
![Encapsulation And Cohesion Class Digram (1)](https://github.com/user-attachments/assets/fd1a1854-f747-43fc-8d4c-fcca8b1d5f05)
