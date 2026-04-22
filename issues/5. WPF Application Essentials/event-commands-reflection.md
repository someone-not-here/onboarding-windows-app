## Research and Learn

### How does WPF handle events, and what are the differences between routed events and standard events?
WPF uses an event system built around routed events. Unlike standard events, which are only limited to the elements that originated them, these can travel through the element tree and invoke controllers in multiple listeners outside of the origin element. This system allows for centralized handling and UI behaviors without tight coupling.

### What are commands in WPF, and how do they integrate with the MVVM pattern?
Commands are objects that represent actions in a reusable, decoupled way. In MVVM, commands live in the ViewModel. The View binds UI elements to these commands instead of handling events in code-behind. This keeps the View free of logic, lets the ViewModel control when actions can run, and improves testability and separation of concerns.

### How does the ICommand interface facilitate the binding of commands to UI elements?
```ICommand``` is a way to connect various UI elements to some logic in code without tightly coupling them like you would with event handlers.

```ICommand``` is an interface. It has:
- ```Execute()```: the code that runs when the command is triggered (like clicking a button).
- ```CanExecute()```: checks whether the command should be allowed right now.
- ```CanExecuteChanged()```: tells the UI to check CanExecute() again.

Any command created from ICommand lives in the ViewModel. This keeps UI and logic separate and easier to test.

## Reflection

### How does using commands improve the maintainability of your code compared to direct event handling?
Events tightly coupled with the UI, making them harder to test and not very reusable across UI elements. On the other hand, commands help keep UI and logic separate, making them easier to test and can be used by other UI elements.

### Reflect on scenarios where commands are more beneficial than event handlers.
Commands are useful for when you want multiple inputs to execute the same action, such as printing with ```File -> Print```, ```Ctrl + P```, or ```Right-Click -> Print```. With events, you would have to write three different event handlers for each input, so using them would scale well with bigger projects.

### What challenges might you encounter when implementing commands in WPF?
Implementation of commands can be tricky and confusing, especially for those not yet familiar with WPF.

## Task

**Code:**

```
<!-- MainWindow.xaml -->
<Window x:Class="WPFProject2.MainWindow"
        xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"
        xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml"
        xmlns:d="http://schemas.microsoft.com/expression/blend/2008"
        xmlns:mc="http://schemas.openxmlformats.org/markup-compatibility/2006"
        xmlns:local="clr-namespace:WPFProject2"
        mc:Ignorable="d"
        Title="Event Handling" Height="450" Width="800">
    <Grid>
        <StackPanel HorizontalAlignment="Center" VerticalAlignment="Center" Margin="0,10,0,10">
            <Button Content="Press Me!" Click="OnButtonClick" FontSize="28" HorizontalAlignment="Center" VerticalAlignment="Center" Margin="0, 0, 0, 10"/>
            <Button Content="Press Me! (ICommand)" Command="{Binding ClickCommand}" FontSize="28" HorizontalAlignment="Center" VerticalAlignment="Center" Margin="0, 10, 0, 0"/>
        </StackPanel>
    </Grid>
</Window>
```

```
// MainWindow.xaml.cs
using System.Windows;
using WPFProject2.ViewModel;

namespace WPFProject2
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            DataContext = new MainViewModel();
        }

        // Normal binding/event handler
        private void OnButtonClick(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("You've been pressed!", "Get pressed!", MessageBoxButton.OK);
        }
    }
}   
```

```
// MainViewModel.cs
using System.ComponentModel;
using System.Windows;
using System.Windows.Input;

namespace WPFProject2.ViewModel
{
    public class MainViewModel : INotifyPropertyChanged
    {
        public ICommand ClickCommand { get; }

        public MainViewModel()
        {
            ClickCommand = new RelayCommand(OnButtonClick);
        }

        public void OnButtonClick()
        {
            MessageBox.Show("You've been pressed! (ICommand)", "Get pressed! (ICommand)", MessageBoxButton.OK);
        }

        // Boilerplater
        public event PropertyChangedEventHandler? PropertyChanged;
        
        public void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
```

```
// RelayCommand.cs
using System.Windows.Input;

namespace WPFProject2.ViewModel
{
    public class RelayCommand : ICommand
    {
        private readonly Action _execute;
        private readonly Func<bool> _canExecute;

        public RelayCommand(Action execute, Func<bool> canExecute = null)
        {
            _execute = execute;
            _canExecute = canExecute;
        }

        public bool CanExecute(object parameter) =>
            _canExecute == null || _canExecute();

        public void Execute(object parameter) =>
            _execute();

        public event EventHandler CanExecuteChanged
        {
            add => CommandManager.RequerySuggested += value;
            remove => CommandManager.RequerySuggested -= value;
        }
    }
}

```

**Documentation:**
![Test1](/issues/_images/Commands_001.jpg)