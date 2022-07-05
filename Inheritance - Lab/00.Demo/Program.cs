using _00.Demo;

var firstDog = new Dog();
firstDog.Name = "Sharo";
Console.WriteLine(firstDog.Bark());

Employee employee;
employee = new SoftwareEngineer("Ivan", 1000);

//((SoftwareEngineer)employee).Laptop

SoftwareEngineer programmer = new SoftwareEngineer("Nikolai", 5000);
programmer.Experience = 13;
Console.WriteLine(programmer.Name);
Console.WriteLine(programmer.Salary);
Console.WriteLine(programmer.Experience);

Intern intern = new Intern("Krasi", 1200);
intern.GetHelp();