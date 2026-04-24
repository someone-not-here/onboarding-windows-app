## Research and Learn

### What are the differences between unit testing and UI testing in WPF applications?
Unit testing involves testing individual pieces of logic in isolation to verify that they function as expected. This usually doesn't involve the UI, as most of the time, unit testing is done only in memory and you don't have to launch the application itself. Thus, unit testing is typically fast.

In contrast, UI testing involves testing the visual and interactive elements by simulating user actions like clicking, typing, etc. and making sure they behave as expected. This involves the UI, meaning you have to launch the application. Becuase of this, UI testing is slower.

### Which testing frameworks (e.g., NUnit, MSTest) and UI automation tools are commonly used for WPF apps?
For WPF, common tools include *NUnit*, *XUnit*, and *MSTest* for unit testing, and *FlaUI*, *TestStack.White*, and *Windows Application Driver* for UI testing.

### How can you design tests to cover critical functionalities and edge cases?
Adopt a risk-based approach. Combine boundary value analysis, exploratory testing, and equivalence partitioning to cover both expected behaviors and extreme or invalid scenarios.

## Reflection

### How does implementing tests improve your development process?
Automated tests help speed up development time immensely as you don't have to manually test each unit or the UI. It also helps in catching any potential errors that could occur before pushing the code into production.

### Reflect on the trade-offs between the ease of unit tests and the complexity of UI tests.
In unit testing, you are essentially taking a snippet of logic, feeding it inputs, and verifying that whatever comes out of it is correct based on those inputs, like feeding a calculator *1 + 1* and testing whether it outputs *2*. Because of this, unit testing is generally fast, as you don't need to launch the actual calculator app in order to test the add function — you just test the actual add function itself within memory.

With UI testing, you need to test the actual UI itself. You're not testing the add function, but rather testing whether pressing the *1*, *+*, and *=* buttons work. As such, you do need to launch the calculator app. This can be slow depending on how complex your calculator app is.

### What strategies could you employ to overcome challenges specific to testing WPF applications?
- Use the MVVM pattern, as logic and UI are decoupled and can be tested much easier.
- Avoid coupling logic to UI, like using logic code in the code-behind.
- Use dependency injection.

## Task

**Documentation:**

I wrote a unit test using XUnit that verifies ```OnPropertyChanged()``` is called whenever the ```Name``` property of a ```Person``` object is changed (this would be via some Control within the UI).

**Code:**

```
// UnitTest1.cs

using WPF_DataBinding.ViewModel;

namespace WPF_DataBinding_Tests
{
    public class UnitTest1
    {
        [Fact]
        public void MainWindowViewModel_Should_Raise_OnPropertyChanged()
        {
            var viewModel = new MainWindowViewModel();
            bool eventRaised = false;

            string? actualPropertyName = null;

            viewModel.PropertyChanged += (sender, args) =>
            {
                eventRaised = true;
                actualPropertyName = args.PropertyName;
            };

            // Act
            viewModel.Name = "Marie";

            // Assert
            Assert.True(eventRaised, "PropertyChanged event was not raised.");
            Assert.Equal("Name", actualPropertyName);
        }
    }
}
```

**Documentation:**

![Test1](/issue/_images/WPF_Unit_Testing_001.gif)