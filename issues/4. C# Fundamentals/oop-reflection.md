## Research and Learn

### What are the four main pillars of OOP in C#?
- **Encapsulation:** Bundling data and methods together into a single object, usually a class, and restricting direct access to some parts of the object.
- **Abstraction:** Exposing only the essential features of an object and hiding complex implementation details.
- **Inheritance:** Allowing classes (child classes) to inherit the properties and behaviors of another class (parent classes).
- **Polymorphism:** Meaning "many forms", methods behave differently based on the object that is calling them, even if they share the same name.

### How do concepts like inheritance, polymorphism, and encapsulation manifest in C# code?


### Which design patterns leverage OOP principles to improve code structure?
- **Factory**: Abstracts object creation.
- **Singleton**: Encapsulates how and when an object is created.
- **Strategy**: Leverages polymorphism, with different strategies sharing the same interface but behaving differently from one another.
- **Observer**: Observers implement the same interface, subjects treat them uniformly.

## Reflection

### Which OOP principle did you find most challenging and why?
I find polymorphism a bit challenging. It requires thinking with interfaces and base classes as opposed to concrete implementations.

### How does applying OOP concepts enhance code reusability and maintainability?
Encapsulation and abstraction help keep all the internal workings of various objects hidden, while inheritance and polymorphism encourage reusing already existing code.

### Reflect on a scenario where using OOP made a project easier to manage.
With something like the Factory method design pattern, you can add another type of object without having modifying existing code to accomodate the addition; just create the new object type and a Factory method and that's it. It's useful for when you want to add in new object types later down the line.

## Task

The following is a C# implementation of the Factory method as well as a demonstration in various OOP principles:

**Code:**

```csharp
// Main.cs

using System;

namespace NotificationsDesignPatterns;

class MainClass
{
    static void Main()
    {
        NotificationFactory factory;

        factory = new EmailFactory();
        INotification email = factory.CreateNotification(); // Encapsulation
        email.Send("This is an email notification!");

        factory = new SMSFactory();
        INotification SMS = factory.CreateNotification(); // Encapsulation
        SMS.Send("This is an SMS notification!");

        factory = new PushFactory();
        INotification push = factory.CreateNotification(); // Encapsulation
        push.Send("This is a push notification!");
    }
}
```

```csharp
// ConcreteFactory.cs

using System;

namespace NotificationsDesignPatterns;

public class EmailFactory : NotificationFactory // Inheritance
{
    public override INotification CreateNotification() // Polymorphism
    {
        return new EmailNotification();
    }
}

public class PushFactory : NotificationFactory // Inheritance
{
    public override INotification CreateNotification() // Polymorphism
    {
        return new PushNotification();
    }
}

public class SMSFactory : NotificationFactory // Inheritance
{
    public override INotification CreateNotification() // Polymorphism
    {
        return new SMSNotification();
    }
}
```

```csharp
// NotificationFactory.cs

using System;

namespace NotificationsDesignPatterns;

public abstract class NotificationFactory // Abstraction
{
    public abstract INotification CreateNotification(); // Factory method
}
```

```csharp
// ConcreteNotification.cs

using System;

namespace NotificationsDesignPatterns;

public class EmailNotification : INotification // Inheritance
{
    public void Send(string message) // Polymorphism
    {
        Console.WriteLine($"Sending email notification: {message}"); 
    }
}

public class PushNotification : INotification // Inheritance
{
    public void Send(string message) // Polymorphism
    {
        Console.WriteLine($"Sending push notification: {message}");
    }
}

public class SMSNotification : INotification // Inheritance
{
    public void Send(string message) // Polymorphism
    {
        Console.WriteLine($"Sending SMS notification: {message}");
    }
}
```

```csharp
// INotification.cs

using System;

namespace NotificationsDesignPatterns;

public interface INotification // Abstraction
{
    void Send(string message);
}
```