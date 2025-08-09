using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace C44_G02_OOP05
{
    #region Provided Employee/HireDate Code (For Context)

    // Defines the security privilege levels for an employee.
    public enum SecurityPrivileges
{
    Guest,
    Developer,
    Secretary,
    DBA
}

// Represents an employee in the company.
public class Employee
{
    // Private backing fields for the properties.
    private int _id;
    private string _name;
    private SecurityPrivileges _securityLevel;
    private decimal _salary;
    private HireDate _hireDate;
    private char _gender;

    // Public properties to provide controlled access to the private fields.
    public int ID
    {
        get { return _id; }
        private set { _id = value; } // ID is read-only after creation.
    }

    public string Name
    {
        get { return _name; }
        set { _name = value; }
    }

    public SecurityPrivileges SecurityLevel
    {
        get { return _securityLevel; }
        set { _securityLevel = value; }
    }

    public decimal Salary
    {
        get { return _salary; }
        set
        {
            // Ensures the salary cannot be a negative value.
            if (value < 0)
                Console.WriteLine("Error: Salary cannot be negative.");
            else
                _salary = value;
        }
    }

    public HireDate HireDate
    {
        get { return _hireDate; }
        set { _hireDate = value; }
    }

    public char Gender
    {
        get { return _gender; }
        set
        {
            // Restricts the Gender field to 'M' or 'F'.
            char upperValue = char.ToUpper(value);
            if (upperValue == 'M' || upperValue == 'F')
                _gender = upperValue;
            else
                Console.WriteLine("Error: Gender must be 'M' or 'F'.");
        }
    }

    // Constructor to initialize a new Employee object.
    public Employee(int id, string name, SecurityPrivileges securityLevel, decimal salary, HireDate hireDate, char gender)
    {
        this.ID = id;
        this.Name = name;
        this.SecurityLevel = securityLevel;
        this.Salary = salary;
        this.HireDate = hireDate;
        this.Gender = gender;
    }

    // Overrides the default ToString method to provide a comprehensive, formatted string
    // representing the employee's data. Salary is formatted as currency.
    public override string ToString()
    {
        string formattedString = String.Format(
            "Employee Details:\n" +
            "  ID: {0}\n" +
            "  Name: {1}\n" +
            "  Gender: {2}\n" +
            "  Security Level: {3}\n" +
            "  Salary: {4:C}\n" + // C format specifier for currency
            "  Hire Date: {5}",
            ID, Name, Gender, SecurityLevel, Salary, HireDate.ToString()
        );
        return formattedString;
    }
}

// Represents the hiring date for an employee.
public struct HireDate
{
    // Public fields for Day, Month, and Year.
    public int Day;
    public int Month;
    public int Year;

    // Constructor to initialize the HireDate.
    public HireDate(int day, int month, int year)
    {
        Day = day;
        Month = month;
        Year = year;
    }

    // Overrides the default ToString method to provide a formatted date string.
    public override string ToString()
    {
        return $"{Day:D2}-{Month:D2}-{Year}";
    }
}

#endregion

#region Question 1: Shape Interfaces and Classes

/// Base interface for all shapes, defining common properties and methods.
public interface IShape
{
    double Area { get; }
    void DisplayShapeInfo();
}

/// An interface representing a circle, inheriting from IShape.
public interface ICircle : IShape
{
    // Can add circle-specific members here if needed in the future.
}

/// An interface representing a rectangle, inheriting from IShape.
public interface IRectangle : IShape
{
    // Can add rectangle-specific members here if needed in the future.
}

/// Implements the ICircle interface, representing a circle with a specific radius.
public class Circle : ICircle
{
    public double Radius { get; set; }

    // Calculates the area of the circle.
    public double Area => Math.PI * Radius * Radius;

    public Circle(double radius)
    {
        Radius = radius;
    }

    // Displays the details of the circle.
    public void DisplayShapeInfo()
    {
        Console.WriteLine($"Circle Information:\n  Radius: {Radius}\n  Area: {Area:F2}");
    }
}

/// Implements the IRectangle interface, representing a rectangle with a specific width and height.
public class Rectangle : IRectangle
{
    public double Width { get; set; }
    public double Height { get; set; }

    // Calculates the area of the rectangle.
    public double Area => Width * Height;

    public Rectangle(double width, double height)
    {
        Width = width;
        Height = height;
    }

    // Displays the details of the rectangle.
    public void DisplayShapeInfo()
    {
        Console.WriteLine($"Rectangle Information:\n  Width: {Width}\n  Height: {Height}\n  Area: {Area:F2}");
    }
}

#endregion

#region Question 2: Authentication Service Interface and Class

/// Interface for an authentication service.
public interface IAuthenticationService
{
    bool AuthenticateUser(string username, string password);
    bool AuthorizeUser(string username, string role);
}

/// A basic implementation of the IAuthenticationService interface.
public class BasicAuthenticationService : IAuthenticationService
{
    // In a real application, these would be stored securely, e.g., in a database.
    private const string StoredUsername = "admin";
    private const string StoredPassword = "password123";
    private const string StoredRole = "Admin";

    /// Authenticates a user by checking their username and password.
    public bool AuthenticateUser(string username, string password)
    {
        return username == StoredUsername && password == StoredPassword;
    }

    /// Authorizes a user by checking if they have a specific role.
    public bool AuthorizeUser(string username, string role)
    {
        // This check assumes the user is already authenticated.
        return username == StoredUsername && role == StoredRole;
    }
}

#endregion

#region Question 3: Notification Service Interface and Classes

/// Interface for a notification service.
public interface INotificationService
{
    void SendNotification(string recipient, string message);
}

/// Sends notifications via Email.
public class EmailNotificationService : INotificationService
{
    public void SendNotification(string recipient, string message)
    {
        Console.WriteLine($"Sending Email to {recipient}: \"{message}\"");
    }
}

/// Sends notifications via SMS.
public class SmsNotificationService : INotificationService
{
    public void SendNotification(string recipient, string message)
    {
        Console.WriteLine($"Sending SMS to {recipient}: \"{message}\"");
    }
}

/// Sends notifications via Push Notification.
public class PushNotificationService : INotificationService
{
    public void SendNotification(string recipient, string message)
    {
        Console.WriteLine($"Sending Push Notification to device {recipient}: \"{message}\"");
    }
}

#endregion


internal class Program
{
    static void Main(string[] args)
    {
        #region Assignment 5 OOP Solutions Demonstration

        // --- Question 1: Shape Demonstration ---
        Console.WriteLine("--- Question 1: Shape Demonstration ---");
        IShape myCircle = new Circle(10);
        myCircle.DisplayShapeInfo();

        Console.WriteLine(); // For spacing

        IShape myRectangle = new Rectangle(5, 8);
        myRectangle.DisplayShapeInfo();
        Console.WriteLine("---------------------------------------\n");


        // --- Question 2: Authentication Service Demonstration ---
        Console.WriteLine("--- Question 2: Authentication Service Demonstration ---");
        IAuthenticationService authService = new BasicAuthenticationService();

        // Successful login
        bool isAuthenticated = authService.AuthenticateUser("admin", "password123");
        Console.WriteLine($"Authentication successful: {isAuthenticated}");

        // Successful authorization
        bool isAuthorized = authService.AuthorizeUser("admin", "Admin");
        Console.WriteLine($"Authorization successful: {isAuthorized}");

        // Failed login
        isAuthenticated = authService.AuthenticateUser("user", "wrongpassword");
        Console.WriteLine($"Authentication successful (with wrong credentials): {isAuthenticated}");
        Console.WriteLine("----------------------------------------------------\n");


        // --- Question 3: Notification Service Demonstration ---
        Console.WriteLine("--- Question 3: Notification Service Demonstration ---");
        // Create instances of each notification service
        INotificationService emailService = new EmailNotificationService();
        INotificationService smsService = new SmsNotificationService();
        INotificationService pushService = new PushNotificationService();

        // Send notifications using each service
        emailService.SendNotification("example@email.com", "Your order has been shipped!");
        smsService.SendNotification("+1234567890", "Your package is out for delivery.");
        pushService.SendNotification("DeviceToken-ABC-123", "You have a new message.");
        Console.WriteLine("------------------------------------------------------\n");

        #endregion



    }
}
}
