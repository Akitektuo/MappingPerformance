# Mapping Performance Benchmark

# Description
This solution evaluates the benefits of different methods of mapping data to specific objects in C#.
In this repository only List and doubled Dictionaries are being tested, but by cloning or forking the repo you can test other data structures.

## Structure
The solution consists of one project having the following files and folders in the root.

### GlobalUsing.cs
Used for declaring global using

### Settings.cs
C# static class containing specifications for how the user data should be generated, mainly the range of length of strings.

### ListTests.cs
The main performance tests using the List as data structure.

### DoubleDictionaryTests.cs
The main performance tests using the doubled DIctionary as data structure. A double dictionary could be used to map the user by `Id` and by `ExternalID`, but would store duplicate data as a whole.

### Loaders/
Contains generative code for populating a specific number of users for testing.

### Metrics/
Classes used for measuring performance as exection time and memory consumption.

### Models/
The main User models.
- `User`
: the main data of an user (without clutter)
- `ExtendedUser`
: extends the `User` class and adds some properties to clutter the class such that an instance would take up more memory

### SelfTests/
Tests made to check the functionality of the custom defined utilities, such as Loaders and Metrics.

## Writing a test

### Generating users

The main methods are `UserLoader.Load(int numberOfWantedUsers)` and `UserLoader.LoadExtended(int numberOfWantedUsers)` generating objects of type `User` and, respectively, `ExtendedUser`.
```
IEnumerable<User> users = UserLoader.Load(100);

// ...
```

In case a lot more users are needed, the `BigNumber` class helps specify readable big numbers.
```
BigNumber.Thousands(1) === 1;
BigNumber.Millions(1) === 1000000;
BigNumber.Billions(1) === 1000000000;
```

Really helping with the readability of tests.
```
var users = UserLoader.LoadExtended(BigNumber.Millions(25));

// ...
```

### Performance metrics
In order to have an easy way of measuring metrics, the class `PerformanceMetrics` is available providing 4 methods:
- Start()
- Stop()
- Restart()
- GetResults()

For using the metrics, an instance of the class is needed and the code that would be analyzed should be wrapped within the `Start()` and `Stop()` method. Keep in mind that `Restart()` will stop and then start the analysis again, resetting the prevoius results.

To obtain the results, the `GetResults()` methoud can only be called while the service is **not** running.

```
var metrics = new PerformanceMetrics();

metrics.Start();
// ...
metrics.Stop();

string results = metrics.GetResults();
```

For displaying the results when a test case was run succesfully, `Assert.Pass(string message)` can be used.

In case more than one metric is taken in a test case, `MetricsFormatter` is available for use, having `AddMetricsResult(string result, string subject)` as the main method and a simple display method `PrintTestResults` for showing the results formatted.

```
var metrics = new PerformanceMetrics();
var resultBuilder = new MetricsFormatter();
metrics.Start();

UserLoader.Load(BigNumber.Millions(1));

metrics.Stop();
resultBuilder.AddMetricsResult(metrics.GetResults(), "Load of 1 Million Users");

metrics.Start();

UserLoader.LoadExtended(BigNumber.Millions(1));

metrics.Stop();
resultBuilder.AddMetricsResult(metrics.GetResults(), "Load of 1 Million Extended Users");
resultBuilder.PrintTestResults();
```
**Printing:**
```
    Load of 1 Million Users
Execution time: 00:00:10.7486819
Average memory: 821 MB
Peeked memory: 1,419 MB

	Load of 1 Million Extended Users
Execution time: 00:01:03.9863380
Average memory: 4,649 MB
Peeked memory: 7,707 MB
```

## Performance results
The tests were performed on a 8 core CPU (3.3 GHz base speed) and 32 GB of DDR4 RAM (3200 MHz speed)

| Size of collection | Number of reads | Is extended user | Data structure | Execution time | Average memory | Peek memory |
| - | - | - | - | - | - | - |
| 1 000 | 1 | Yes |  |  |  |  |
|  |  |  | List | 0.8ms | 17 MB | 17 MB |
|  |  |  | Double Dictionary | 0.5ms | 17 MB | 17 MB |
| 1 000 | 10 | Yes |  |  |  |  |
|  |  |  | List | 0.7ms | 17 MB | 17 MB |
|  |  |  | Double Dictionary | 0.5ms | 17 MB | 17 MB |
| 10 000 | 100 | Yes |  |  |  |  |
|  |  |  | List | 7ms | 27 MB | 27 MB |
|  |  |  | Double Dictionary | 0.5ms | 28 MB | 28 MB |
| 100 000 | 100 | Yes |  |  |  |  |
|  |  |  | List | 200ms | 91 MB | 91 MB |
|  |  |  | Double Dictionary | 0.5ms | 97 MB | 97 MB |
| 100 000 | 1 000 | Yes |  |  |  |  |
|  |  |  | List | 1320ms | 91 MB | 91 MB |
|  |  |  | Double Dictionary | 0.6ms | 97 MB | 97 MB |
| 1 000 000 | 1 000 | No |  |  |  |  |
|  |  |  | List | 6s | 171 MB | 171 MB |
|  |  |  | Double Dictionary | 0.7ms | 243 MB | 243 MB |
| 1 000 000 | 1 000 | Yes |  |  |  |  |
|  |  |  | List | 26s | 676 MB | 677 MB |
|  |  |  | Double Dictionary | 0.8ms | 749 MB | 749 MB |
| 1 000 000 | 100 000 | No |  |  |  |  |
|  |  |  | List | 9m 57s | 176 MB | 179 MB |
|  |  |  | Double Dictionary | 16ms | 250 MB | 250 MB |
| 1 000 000 | 100 000 | Yes |  |  |  |  |
|  |  |  | List | 43m 24s | 680 MB | 682 MB |
|  |  |  | Double Dictionary | 18ms | 744 MB | 744 MB |
|  |  |  |  |  |  |  |