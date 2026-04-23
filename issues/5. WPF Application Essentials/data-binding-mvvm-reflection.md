## Research and Learn

### What is data binding in WPF, and what are its different modes (OneWay, TwoWay, etc.)?
Data binding is a mechanism that connects/binds Controls to data sources for automatic synchronization. In simpler terms, this allows any change to the data to be immediately reflected in the UI or vice versa.

Binding can be done as either:
- *OneWay:* Data flows only from the ViewModel to View. Used to update the View on source data changes and nothing else.
- *TwoWay:* Data flows both ways. Used to update the View on source data changes and vice versa.
- *OneWayToSource:* Data flows from the View to the Viewmodel. Used to update the source data when the View changes.
- *OneTime:* Updates the View only once, either on application start or when the source itself changes.

### How does the MVVM pattern organize code, and what are the roles of the Model, View, and ViewModel?
MVVM, or Model-View-ViewModel, organizes code between three layers: the View, the ViewModel, and the Model.
- **View:** This is the UI itself. There is almost no logic code here, just code that determines the look of the UI. 
- **ViewModel:** This is the layer the binds UI elements to business logic. This is where, for example, what will happen to data if you press the button or input something in a field is handled.
- **Model:** This is where data and business logic resides.

### What are some common pitfalls when implementing data binding and MVVM, and how can they be mitigated?
- Tight coupling between the View and the ViewModel.
    - Ideally, you should avoid code-behind logic.
- Overusing events within the code-behind.
    - You should use commands instead.
- Complex ViewModels or ViewModels that try do too much.
    - Split these into smaller ViewModels with separate responsibilities.

## Reflection

### How does data binding improve the separation of concerns in your application?
The UI shouldn't be concerned about how the data is being managed behind-the-scenes, it should only be concerned about what data it should display. 

### Reflect on how MVVM can simplify testing and maintenance.
A good implementation of MVVM would have the three layers decoupled and not dependent on one another to be able to function. With this independency, testing and maintenance are made easier — you can unit test the business logic within the Model independently, you can change UI elements without having to rewrite any code-behind logic, etc.

### What challenges might arise when applying these concepts to larger applications?
It would be a challenge to manage many Views simultaneously, especially if some of these Views depend on other Views. Having to data bind a very complex View with many Controls can also be daunting.

## Task

**Code:**

```
<!-- MainWindow.xaml "The View" -->

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
            <Label Content="{Binding Name}"
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
// MainWindow.xaml.cs

using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using WPF_DataBinding.ViewModel;

namespace WPF_DataBinding
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            MainWindowViewModel vm = new MainWindowViewModel();
            DataContext = vm;
        }
    }
}

```

```
// MainWindowViewModel.cs "The ViewModel"

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using WPF_DataBinding.Model;
using System.Runtime.CompilerServices;

namespace WPF_DataBinding.ViewModel
{
    internal class MainWindowViewModel : INotifyPropertyChanged
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

```
// Person.cs "The Model"

using System;
using System.Collections.Generic;
using System.Text;

namespace WPF_DataBinding.Model
{
    internal class Person
    {
        public String Name { get; set; }
    }
}

```

**Documentation:**
![Test1](issues/_images/DataBinding_001.gif)