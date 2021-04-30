# MongoDB Helper
It's a simple helper class for **MongoDB** on **C#**.

## Installation
- Install **MongoDB.Driver** from **NuGet**
- Add `MongoDBMethods.cs` to your project

## Usage
- Create models like at `Example.cs`
- Add this line to your model:
```cs
public static MongoDBMethods<ModelName> methods = new MongoDBMethods<ModelName>("Table name on MongoDB");
```