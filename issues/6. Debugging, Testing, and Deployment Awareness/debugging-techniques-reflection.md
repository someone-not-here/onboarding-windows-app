## Research and Learn

### What are the key debugging features in Visual Studio (e.g., breakpoints, watch windows, immediate window, etc.)?
- **Breakpoint:** Pauses execution at a specified point in the code.
- **Watch/Automatic/Local:** View variable values in real time. The *Watch* window contains variables/expressions you wish to track, while *Automatic* and *Local* windows track variables based on current execution context.
- **Immediate Window:** Evaluate expressions, execute statements, and print variable values while execution is paused.
- **Call Stack:** Shows the sequence of function calls that led to the current execution point.
- **Exception Settings:** Allows developers to configure which exceptions will pause execution.

### How can you use these tools to inspect application state and monitor variable changes during runtime?
- Place a breakpoint somewhere within the code.
- Use Watch/Automatic/Local windows to keep track of variables and how they change.
- Advance execution line-by-line with the Step commands (step into, step over, step out).

### What are some best practices for debugging WPF-specific issues, such as data binding errors or UI thread problems?
- Monitor the *Output* window, as WPF logs binding errors to this window during debugging.
- Use ```Dispatcher.Invoke``` or ```Dispatcher.BeginInvoke``` when updating bound properties from background threads. Failure to do so results in runtime exceptions or silent failures.
- Use design-time data, which is mock data set to make controls easier to visualize in the XAML Designer. This helps catch binding issues early in the development cycle.

## Reflection

### Which debugging tools in Visual Studio do you find most useful and why?
I find breakpoints, the step commands, and the watch/automatic/local windows useful as they provide a way for me to see the sequeunce of function calls and how variable values are changed throughout execution.

### Reflect on a scenario where a specific debugging feature helped you identify and resolve an issue.
In the task code, a Label's binding failed due to a typo with the source object ("name" instead of "Name"), causing it to not show text. When debugging, the error appeared on the *XAML Binding Failure* window.

### How might improving your debugging skills impact your overall productivity?
With good debugging skills, you spend less time trying to wrangle the program into working correctly. Debugging also helps you better understand how the program flows during execution.

## Task

**Code:**

```
<!-- MainWindow.xaml -->
<!-- Bug: Label's Content source object is incorrect ("name" instead of "Name") -->

<Window x:Class="WPF_DataBinding.MainWindow"
        Background="#313332"
        xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"
        xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml"
        xmlns:d="http://schemas.microsoft.com/expression/blend/2008"
        xmlns:mc="http://schemas.openxmlformats.org/markup-compatibility/2006"
        xmlns:local="clr-namespace:WPF_DataBinding"
        mc:Ignorable="d"
        Title="WPF Data Binding Example" Height="450" Width="800">
    <Grid>
        <StackPanel Margin="50">
            <TextBox Text="{Binding Name, Mode=TwoWay, UpdateSourceTrigger=PropertyChanged}"
                     Style="{StaticResource TextBoxStyle}"
                     Margin="0, 125, 0, 0" 
                     HorizontalAlignment="Center" 
                     VerticalAlignment="Center"
                     Height="30"
                     Width="250"/>
            <Label Content="{Binding name}" <!-- Bug here! -->
                   Style="{StaticResource LabelStyle}"
                   Margin="0, 10, 0, 0"
                   HorizontalAlignment="Center"
                   VerticalAlignment="Center"
                   Height="30"
                   Width="250"/>
        </StackPanel>
    </Grid>
</Window>
```

```
// MainWindowViewModel.cs

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using WPF_DataBinding.Model;
using System.Runtime.CompilerServices;

namespace WPF_DataBinding.ViewModel
{
    public class MainWindowViewModel : INotifyPropertyChanged
    {

        private Person _person;

        public MainWindowViewModel()
        {
            _person = new Person { Name = "Marie" };
        }

        public string Name
        {
            get => _person.Name;
            set
            {
                _person.Name = value;
                OnPropertyChanged();
            }
        }

        // Boilerplate
        public event PropertyChangedEventHandler? PropertyChanged;

        protected void OnPropertyChanged( [CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
```

**Documentation:**

Text inside Label does not show up. *XAML Binding Failure* window shows an error:
![Test1](/issues/_images/WPF_Debugging_001.jpg)