using RSCG_IFormattableConsole;

Person person = new ();
person.FirstName = "Andrei";
person.LastName = "Ignat";

Console.WriteLine(person.ToString("The person name is {FirstName} {LastName}",null));