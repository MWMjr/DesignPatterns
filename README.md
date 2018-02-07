# DesignPatterns
The idea of this repository is to build a library of design patterns implementations built in C#.  This is simply to be used as a personal reference. All code is quick and dirty - just to demonstrate the principal in code.
## Creational Patterns
These are the patterns that create objects, rather than being instantiated directly.
#### Abstract Factory Pattern
#### Builder
*Purpose*
Simplifies the construction of an object into multiple steps

*When to use*
An object requires a lot of ceremony to properly create.  Reduces the necessity of having a constructor with a ton of arguments.
#### Factory Pattern
*Purpose*  
Consumers of the factory can get a THING of a certain type without having to know about the dependencies of the THING.  The only thing that comes from the consumer is something that identifies the type of the THING that needs to be created (i.e. a string or enum).  

*When to Use*  
Client knows  to create an object of the required functionality, but the type of the object will remain undecided or it will be decided by dyanmic parameters being passed.  

*How is this different from the Abstract Factory Pattern*  
Enter text here.  

#### Prototype
#### Singleton
*Purpose*
Ensure that a component is created only once

*When to use*
When it doesn't make any sense for multiple copies of a class to exist.  For instance, a class that creates objects, or a class that represents a database connection or repository.

*Monostate Variation*
The properties of a class are statics, which means that all instances of the object will have the same property values.

## Structural Patterns
These are the patterns that define new ways to compose objects for new functionality.
#### Adapter
*Purpose*
Get the interface you want from the interface that you have.  Often referred to as a wrapper.

*When to use*
When you have a class that can do what you need it to do, but the inputs you have don't fit nicely into it. For instance, having a class that can only draw a point, and asking it to draw a line.  Using an adapter can isolate the code that orchestrates it.  

*Caching* 
Should intermediate representations begin to pile up, use caching or other optimizations.  Make sure you clean up after yourself too.

#### Bridge
*Purpose*
To connect components together using abstractions.  Prevents a cartesian product complexity explosion.  Where you have to define many classes to cover multiple situations.  

Decouples an interface (hierarchy) from an implementation (hierarchy)

*When to use*
When you start start to profilerate classes to deal with different scenarios (i.e. a scheduler class that can work on 3 platforms (Win, Unix, IOS) that can schedule in two ways (Method1, Method2) leads to six classes. (WindowsMethod1Scheduler, WindowsMethod2Scheduler, UnixMethod1Scheduler, UnixMethod2Scheduler, IOSMethod1Scheduler, IOSMethod2SCheduler)

#### Composite
*Purpose*
To treat individual and aggregate object the same.

#### Decorator
#### Facade
#### Flywight
#### Proxy
## Behaviorial Patterns
These patterns are conerned with communication between objects.
#### Chain of Responsibility
#### Command
#### Interpreter
#### Iterator
#### Mediator
#### Memento
#### Observer
#### State
#### Strategy
#### Template Method
#### Visitor
## Other Patterns
#### Specification
