using System;

#region Employee, Manager, Developer
class Employee
{
    public int Id { get; set; }
    public string Name { get; set; }
    public double Salary { get; set; }
    public string Department { get; set; }

    public Employee(int id, string name, double salary, string department)
    {
        Id = id;
        Name = name;
        Salary = salary;
        Department = department;
    }

    public virtual double CalculateBonus()
    {
        return 0;
    }

    public void DisplayInfo()
    {
        Console.WriteLine($"ID: {Id}, Name: {Name}, Salary: {Salary:C}, Department: {Department}");
    }
}

class Manager : Employee
{
    public int TeamSize { get; set; }

    public Manager(int id, string name, double salary, string department, int teamSize)
        : base(id, name, salary, department)
    {
        TeamSize = teamSize;
    }

    public override double CalculateBonus()
    {
        return Salary * 0.2;
    }
}

class Developer : Employee
{
    public string About { get; set; }

    public Developer(int id, string name, double salary, string department, string about)
        : base(id, name, salary, department)
    {
        About = about;
    }

    public override double CalculateBonus()
    {
        return Salary * 0.1;
    }
}
#endregion

#region BankAccount, SavingsAccount, CheckingAccount
class BankAccount
{
    public string AccountHolder { get; set; }
    public double Balance { get; set; }

    public BankAccount(string accountHolder, double balance)
    {
        AccountHolder = accountHolder;
        Balance = balance;
    }

    public virtual void CalculateInterest()
    {
    }

    public void DisplayInfo()
    {
        Console.WriteLine($"Account Holder: {AccountHolder}, Balance: {Balance:C}");
    }
}

class SavingsAccount : BankAccount
{
    public SavingsAccount(string accountHolder, double balance)
        : base(accountHolder, balance)
    {
    }

    public override void CalculateInterest()
    {
        double interest = Balance * 0.05;
        Console.WriteLine($"Interest Earned: {interest:C}");
    }
}

class CheckingAccount : BankAccount
{
    public CheckingAccount(string accountHolder, double balance)
        : base(accountHolder, balance)
    {
    }

    public override void CalculateInterest()
    {
        Console.WriteLine("Checking accounts do not earn interest.");
    }
}
#endregion

class Program
{
    static void Main()
    {
        Console.WriteLine("===== Employee System =====\n");

        Manager manager = new Manager(1, "Ahmet", 8000, "IT", 5);
        Developer developer = new Developer(2, "Zeynep", 6000, "Development", "Backend Developer");

        manager.DisplayInfo();
        Console.WriteLine($"Bonus: {manager.CalculateBonus():C}\n");

        developer.DisplayInfo();
        Console.WriteLine($"Bonus: {developer.CalculateBonus():C}\n");

        Console.WriteLine("===== Bank System =====\n");

        SavingsAccount savings = new SavingsAccount("Mehmet", 10000);
        CheckingAccount checking = new CheckingAccount("Ayşe", 5000);

        savings.DisplayInfo();
        savings.CalculateInterest();
        Console.WriteLine();

        checking.DisplayInfo();
        checking.CalculateInterest();
    }
}
