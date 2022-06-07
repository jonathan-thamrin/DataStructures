# DataStructures

**Stacks, queues, linked lists, trees, graphs, heaps, hash tables, sets... what are there and how do they work?!**

This repository contains a collection of exercises which require you to complete a data structure to satisfy a test suite. The idea is that when you've satisfied the test suite, a consumer of your data structure can rely on its behaviour. However, don't stop there! Look for opportunities to improve the performance and maintainability of your data structure as well.

## How to begin

- Clone the repository
- Open `DataStructures.sln`
- Expand the `DataStructures.Exercises` project
- Start implementing the methods by replacing the `NotImplementedException` with your code
- Test your code by running the `DataStructures.Tests` project

## Inlcuded data structures

- Linked List
- Stack
- Queue

## Solutions

**Solutions are located in the `DataStructures.Solutions` project!**
- Try to avoid peeking at the solutions unless you're completely stuck.
- The given solutions are not the only solution or even the best solution. Abstract data structures can be implemented in many different ways, all with their own strengths and weaknesses.
- Feel free to implement the abstract data structures using different underlying data structures than those used in the solutions. 

## Test structure

The unit tests are structured into a hierarchy of test classes implementing tests for the various interfaces. The abstract test classes and test cases can be found in the `GeneralTests` directory. Implementation-specific tests are located in their respective directories `LinkedList`, `Queue` etc.

You can change which implementation is being tested by modifying the constructor of the test class. For example, to change the implementation used for LinkedList tests from your solution to the given solution, you can change the constructor from:

```csharp
    // Change which implementation is tested by changing the instance passed into this()
    public LinkedListTests() : this(new Exercises.LinkedList.LinkedList<int>()) { }
```

to:

```csharp
    // Change which implementation is tested by changing the instance passed into this()
    public LinkedListTests() : this(new Solutions.LinkedList.LinkedList<int>()) { }
```

## Contributions

If you would like to contribute to this repository, please do so by opening an issue or creating a pull request.

### Ways of contributing

- Fix or identify bugs in the solutions
- Fix or identify inconsistencies in the test cases
- Add new test cases
- Add solutions using different underlying data structures
- Add new exercises with accompanying solutions and test cases

### Contributors

This repository was created by [Tom van Dinther](https://github.com/tvandinther) and [Andrew Christabel](https://github.com/ac-myob).
