# BMI Calculator Documentation

## Overview
This project consists of a BMI (Body Mass Index) calculator implemented in **.NET MAUI**. The code is organized using the **MVVM (Model-View-ViewModel)** pattern, which ensures a clean separation between UI logic, business logic, and data binding. The four main files are:

![Screenshot 2024-10-10 at 10 42 17 AM](https://github.com/user-attachments/assets/51216a59-209a-4e18-ace2-ddc5dc4b4826)

1. **BMIView.xaml**: Defines the User Interface (UI) of the BMI Calculator.
2. **BMIView.xaml.cs**: Code-behind for `BMIView.xaml` which contains UI-related logic.
3. **BMIViewModel.cs**: The ViewModel that handles the data and commands for the BMI calculation.
4. **BMI.cs**: The Model representing the logic for BMI calculations.

### 1. BMIView.xaml
**File Path**: `BMIView.xaml`

**Purpose**:  
This file defines the layout and UI components of the BMI Calculator. It is a XAML file that contains the structure of the visual elements, such as text boxes for user input, labels for displaying results, and a button for triggering the BMI calculation.

**Key Components**:
- **TextBox for Height and Weight**: Allows users to input their height and weight.
- **Button for Calculation**: A button that triggers the calculation of BMI.
- **Label for BMI Result**: Displays the calculated BMI value and any associated health message.

**Example Structure**:
```xml
<ContentPage xmlns="http://schemas.microsoft.com/dotnet/2021/maui"
             xmlns:x="http://schemas.microsoft.com/winfx/2009/xaml"
             x:Class="YourNamespace.BMIView">
    <StackLayout Padding="20">
        <Entry x:Name="HeightEntry" Placeholder="Enter Height (m)" />
        <Entry x:Name="WeightEntry" Placeholder="Enter Weight (kg)" />
        <Button Text="Calculate BMI" Command="{Binding CalculateBmiCommand}" />
        <Label Text="{Binding BmiResult}" FontSize="Large" />
    </StackLayout>
</ContentPage>
```
- The **Entry** elements collect the user's height and weight.
- The **Button** binds to `CalculateBmiCommand` in the ViewModel.
- The **Label** displays the BMI result from the ViewModel using data binding.

### 2. BMIView.xaml.cs
**File Path**: `BMIView.xaml.cs`

**Purpose**:  
This is the code-behind for `BMIView.xaml`. It connects the UI to its behavior. In MVVM, this file usually contains minimal logic, such as initializing components and binding the ViewModel.

**Key Responsibilities**:
- **Initialization**: Initializes the UI components defined in the XAML file.
- **Binding ViewModel**: Sets the `BindingContext` for data binding.

**Example**:
```csharp
public partial class BMIView : ContentPage
{
    public BMIView()
    {
        InitializeComponent();
        BindingContext = new BMIViewModel();
    }
}
```
- **InitializeComponent()**: Sets up the visual components defined in the XAML file.
- **BindingContext = new BMIViewModel()**: Connects the View to the ViewModel (`BMIViewModel`), which is responsible for the data and commands.

### 3. BMIViewModel.cs
**File Path**: `BMIViewModel.cs`

**Purpose**:  
The ViewModel in the MVVM pattern acts as the intermediary between the View (`BMIView`) and the Model (`BMI`). It is responsible for handling the commands and exposing data to the view. It also maintains the business logic for calculating BMI and provides a clean way to perform operations through data binding.

**Key Components**:
- **Properties**: 
  - **Height** and **Weight**: User input properties.
  - **BmiResult**: The result that will be displayed in the UI.
- **Commands**:
  - **CalculateBmiCommand**: Command that triggers the BMI calculation.
  
**Example**:
```csharp
public class BMIViewModel : INotifyPropertyChanged
{
    public double Height { get; set; }
    public double Weight { get; set; }
    private string bmiResult;

    public string BmiResult
    {
        get => bmiResult;
        set
        {
            bmiResult = value;
            OnPropertyChanged(nameof(BmiResult));
        }
    }

    public ICommand CalculateBmiCommand { get; }

    public BMIViewModel()
    {
        CalculateBmiCommand = new Command(OnCalculateBmi);
    }

    private void OnCalculateBmi()
    {
        var bmi = new BMI(Height, Weight);
        BmiResult = bmi.Calculate();
    }

    public event PropertyChangedEventHandler PropertyChanged;
    protected void OnPropertyChanged(string propertyName)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}
```
- **Height and Weight**: Properties for user input.
- **BmiResult**: Stores the BMI calculation result.
- **CalculateBmiCommand**: Calls `OnCalculateBmi` to calculate BMI.
- **OnCalculateBmi()**: Creates an instance of `BMI` and calls `Calculate()`, setting the result to `BmiResult`.

### 4. BMI.cs
**File Path**: `BMI.cs`

**Purpose**:  
This file represents the **Model** and contains the business logic to calculate BMI. It is responsible for performing the calculations based on the input height and weight.

**Key Components**:
- **Properties**:
  - **Height** and **Weight**: These values are used for BMI calculation.
- **Method**:
  - **Calculate()**: Performs the BMI calculation and returns the result as a formatted string.

**Example**:
```csharp
public class BMI
{
    public double Height { get; set; }
    public double Weight { get; set; }

    public BMI(double height, double weight)
    {
        Height = height;
        Weight = weight;
    }

    public string Calculate()
    {
        if (Height <= 0 || Weight <= 0)
        {
            return "Invalid input values";
        }

        double bmiValue = Weight / (Height * Height);
        return $"Your BMI is {bmiValue:F2}";
    }
}
```
- **Height and Weight**: Used in the BMI calculation.
- **Calculate()**: Computes the BMI based on the formula: **BMI = Weight / (Height * Height)** and returns a formatted string with the BMI value.

## Summary Table of Components
| Component           | File Path         | Description                          | Key Features                          |
|---------------------|-------------------|--------------------------------------|---------------------------------------|
| **View (XAML)**     | BMIView.xaml      | Defines the user interface elements. | TextBox for input, Button for calculation, Label for result |
| **Code-Behind**     | BMIView.xaml.cs   | Handles the UI initialization.       | Binds the ViewModel to the View       |
| **ViewModel**       | BMIViewModel.cs   | Handles the logic and data binding.  | Properties for user input, Command for BMI calculation |
| **Model**           | BMI.cs            | Business logic for calculating BMI.  | Performs BMI calculation based on user input |

## Practical Usage Scenario
Consider a scenario where a user wants to know their BMI to track their health status:
- The user enters their height and weight into the respective text fields in the UI (`BMIView`).
- The **Calculate BMI** button triggers the `CalculateBmiCommand` defined in the `BMIViewModel`.
- The ViewModel passes the data to the **Model** (`BMI`), which calculates the BMI and returns the result.
- The calculated result (`BmiResult`) is then displayed in the UI, helping the user understand their health better.

## Reference Sites
- [.NET MAUI Documentation](https://learn.microsoft.com/en-us/dotnet/maui/)
- [Microsoft Learn - MVVM Pattern](https://learn.microsoft.com/en-us/xamarin/xamarin-forms/enterprise-application-patterns/mvvm)
- [INotifyPropertyChanged Interface](https://learn.microsoft.com/en-us/dotnet/api/system.componentmodel.inotifypropertychanged)

# Understanding "Convert Full Property" in C#

## Overview
In **C#**, a **full property** (also known as a "backing field property") is a property that contains both **get** and **set** accessors, and it uses a private **backing field** to store the property value. This approach allows you to add custom logic to the **getter** and **setter** methods, which provides more flexibility compared to an **auto-implemented property**. The process of converting an auto-implemented property to a full property is known as **"convert full property"**.

## Key Features of Full Property
- **Custom Logic**: You can add custom logic to the `get` and `set` methods, such as validation or triggering additional actions.
- **Backing Field**: A full property has a private backing field that stores the value. The field is typically used to add control over how the data is accessed or modified.
- **Encapsulation**: Full properties provide better encapsulation and control over the internal data.

## Example of Converting an Auto Property to a Full Property
### Auto-Implemented Property
An **auto-implemented property** is a simple property that does not require custom logic in its `get` or `set` accessors. It looks like this:

```csharp
public int Age { get; set; }
```
In this example, **Age** is an auto-implemented property, which means it does not contain any additional logic and is managed by the compiler.

### Full Property
Converting the auto property into a **full property** involves adding a private **backing field** and custom logic:

```csharp
private int age;
public int Age
{
    get => age;
    set
    {
        if (value < 0)
        {
            throw new ArgumentException("Age cannot be negative");
        }
        age = value;
    }
}
```
- **Private Backing Field** (`age`): Stores the actual value of the property.
- **Custom Logic** in Setter: Ensures that the `Age` cannot be set to a negative value.
- **Getter and Setter Accessors**: Provide controlled access to the private backing field.

## Advantages of Using Full Properties
### 1. **Validation**
You can use full properties to add validation logic to control how values are assigned. For example, ensuring that `Age` cannot be set to a negative value.

### 2. **Event Triggering**
Full properties allow you to trigger events when a property value changes, which is useful for data-binding scenarios or notifications.

### Example with Event Trigger
```csharp
private string name;
public string Name
{
    get => name;
    set
    {
        if (name != value)
        {
            name = value;
            OnPropertyChanged(nameof(Name));
        }
    }
}

public event PropertyChangedEventHandler PropertyChanged;
protected void OnPropertyChanged(string propertyName)
{
    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
}
```
- **OnPropertyChanged()**: This method is triggered whenever the `Name` property changes, which is commonly used in **MVVM** for data-binding purposes.

## Comparison Between Auto and Full Properties
| Feature                  | Auto-Implemented Property     | Full Property                          |
|--------------------------|-------------------------------|----------------------------------------|
| **Custom Logic**         | Not supported                 | Supports custom logic in getters/setters |
| **Backing Field**        | Compiler-generated            | Manually defined                      |
| **Use Case**             | Simple data storage           | Data validation, event triggering      |

## When to Use Full Properties
### 1. **Data Validation**
- **Use Case**: When you need to validate the data being assigned to a property.
- **Example**: Validating that an age value is within an acceptable range.

### 2. **Data Binding**
- **Use Case**: When using the MVVM pattern and you need to notify the UI of property changes.
- **Example**: Implementing `INotifyPropertyChanged` for a ViewModel property to automatically update the UI when the property value changes.

### 3. **Encapsulation with Additional Logic**
- **Use Case**: When you need to execute additional logic when a property value changes, such as updating other properties or raising an event.
- **Example**: Logging changes to critical properties or updating dependent values.

## Practical Scenario
Consider a user profile form in a **WPF** or **MAUI** application where users can enter their age. If an auto-implemented property is used (`public int Age { get; set; }`), there is no validation on what the user enters. By converting this to a full property, you can validate the age and ensure it is within an acceptable range, improving data integrity and application stability.

Additionally, in applications that use the **MVVM** pattern, full properties are particularly helpful because they can trigger UI updates via the `INotifyPropertyChanged` interface, which ensures that changes to the properties are reflected in the user interface.

## Summary Table
| Feature                  | Full Property                                | Use Case                                      |
|--------------------------|----------------------------------------------|-----------------------------------------------|
| **Data Validation**      | Add validation logic in the setter           | Prevent invalid data from being assigned      |
| **Event Triggering**     | Trigger `PropertyChanged` events             | Notify UI of changes for data-binding         |
| **Encapsulation**        | Control how data is accessed and modified    | Add business logic or constraints             |

## Reference Sites
- [Microsoft Learn - Properties](https://learn.microsoft.com/en-us/dotnet/csharp/programming-guide/classes-and-structs/properties)
- [Backing Fields in C#](https://learn.microsoft.com/en-us/dotnet/csharp/programming-guide/classes-and-structs/using-properties#the-propertys-backing-store)
- [INotifyPropertyChanged Interface](https://learn.microsoft.com/en-us/dotnet/api/system.componentmodel.inotifypropertychanged)
