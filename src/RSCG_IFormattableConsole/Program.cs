using RSCG_IFormattableConsole;

Person person = new ("Ignat");
person.FirstName = "Andrei";
person.LastName = "Ignat";
person.Children = new Person[] { new Person("Ignat Matei"), new Person("Ignat Andreea") };

Console.WriteLine(person.ToString(""));

Console.WriteLine(person.ToString("The person name is {FirstName} {LastName} {DateOfBirth} {Children}"));
