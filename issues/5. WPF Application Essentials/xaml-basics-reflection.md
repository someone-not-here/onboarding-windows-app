## Research and Learn

### What are the basic elements and syntax of XAML?
- Object Elements: Represents UI controls and layout panels, such as ```Button```, ```TextBox```, ```Grid```, and ```StackPanel```.
- Attributes/Properties: Determines the appearance and behavior of object elements, such as ```Margin```, ```Text```/```Content```, and ```Click```.

**Example Usage:**
```
<Button Content="I'm a button" Width="100" Height="50" Click="OnButtonClick"/>
```

### How do layout panels like Grid, StackPanel, and DockPanel function?
```Grid``` divides the layout into a number of rows and columns where elements can reside in:

```
<Grid>
    <!-- Definitions for the grid's rows (can be filled iwth attributes) -->
    <Grid.RowDefinitions>
        <RowDefinition/>
        <RowDefinition/>
    </Grid.RowDefinitions>

    <!-- Definitions for the grid's columns (can be filled iwth attributes) -->
    <Grid.RowDefinitions>
        <ColumnDefinition/>
        <ColumnDefinition/>
    </Grid.RowDefinitions>

    <!-- Defining a button at row 0, column 0 -->
    <Button Grid.Row="0" Grid.Column="0" Content"Button."/>
</Grid>
```

```StackPanel``` arranges elements vertically or horizontally in a "stack":

```
<!-- Defining a StackPanel that stacks vertically -->
<StackPanel Orientation="Vertical">
    <Button Content="Button."/>
    <Button Content="Another button."/>
</StackPanel>
```

```DockPanel``` positions elements along the four edges of a layout (top, bottom, left, right). By default, the last element in a ```DockPanel``` will fill out the rest of the free space.

```
<DockPanel>
	<Button DockPanel.Dock="Left">Left</Button>
	<Button DockPanel.Dock="Top">Top</Button>
	<Button DockPanel.Dock="Right">Right</Button>
	<Button DockPanel.Dock="Bottom">Bottom</Button>
	<Button>Center</Button>
</DockPanel>
```

### What properties and events are commonly used with WPF controls?
**Properties:**
- ```Width``` and ```Height```
- ```Margin```
- ```Padding```
- ```Background``` and ```Foreground```
- ```HorizontalAlignment``` and ```VerticalAlignment```
- ```Visibility```
- ```Content``` or ```Text```

**Events:**
- ```Click```
- ```TextChanged```
- ```Check``` and ```Unchecked```
- ```SelectionChanged```
- ```MouseEnter```, ```MouseLeave``` and ```MouseMove```
- ```MouseDown```, ```MouseUp``` and ```MouseWheel```
- ```GetFocus``` and ```LostFocus```

## Reflection

### How do different layout panels influence UI flexibility?
UI designers have a lot more freedom in how to arrange and space out elements within the UI without having to resort to use hacky code to achieve what they envision. If you want elements at the edges of the window, instead of using ```Grid``` with its rows and columns, you can use ```DockPanel``` — this is much easier to implement and cleaner, the latter more so if you intend to have a nested ```Grid``` or some other layout panel.

### What challenges might arise when building responsive UIs with XAML?
Some challenges include:
- Knowing how to handle diverse screen resolutions and DPI scaling
- Managing layout complexity with deep nesting
- Avoiding fixed sizes and hardcoded dimensions
- Performance issues with complex layouts
- Maintaing consistent spacing and alignment

### How does separating UI and logic benefit application development?
Typically in projects, UI designers and backend programmers work in separate teams. They would need to be able to test their own "side" of the project separately — you can't do that if logic code is coupled with the UI. Separating UI and logic allows for easier unit testing and maintenance.

## Task

**Code:**
```
<!-- MainWindow.xaml -->
<Window x:Class="WPF_Layouts.MainWindow"
        xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"
        xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml"
        xmlns:d="http://schemas.microsoft.com/expression/blend/2008"
        xmlns:mc="http://schemas.openxmlformats.org/markup-compatibility/2006"
        xmlns:local="clr-namespace:WPF_Layouts"
        mc:Ignorable="d"
        Title="MainWindow" Height="450" Width="800">
    <DockPanel>
        <Border x:Name="TopPanel" DockPanel.Dock="Top" Height="80" Background="White"/>
        <Border x:Name="BottomPanel" DockPanel.Dock="Bottom" Height="80" Background="White"/>
        <Border x:Name="LeftPanel" DockPanel.Dock="Left" Width="80" Background="White"/>
        <Border x:Name="RightPanel" DockPanel.Dock="Right" Width="80" Background="White"/>

        <StackPanel DockPanel.Dock="Top" Orientation="Vertical" Height="100">
            <Button Content="Turn Top Red" Click="Click_RedTop" Width="100" Margin="0 3 0 5"/>
            <Button Content="Turn Bottom Blue" Click="Click_BlueBottom" Width="100" Margin="0 0 0 5"/>
            <Button Content="Turn Left Green" Click="Click_GreenLeft" Width="100" Margin="0 0 0 5"/>
            <Button Content="Turn Right Yellow" Click="Click_YellowRight" Width="100" Margin="0 0 0 5"/>
        </StackPanel>
    </DockPanel>
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

namespace WPF_Layouts
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Click_RedTop(object sender, RoutedEventArgs e)
        {

            TopPanel.Background = TopPanel.Background == Brushes.White ? Brushes.Red : Brushes.White;
        }

        private void Click_BlueBottom(object sender, RoutedEventArgs e)
        {
            BottomPanel.Background = BottomPanel.Background == Brushes.White ? Brushes.Blue : Brushes.White;
        }

        private void Click_GreenLeft(object sender, RoutedEventArgs e)
        {
            LeftPanel.Background = LeftPanel.Background == Brushes.White ? Brushes.Green : Brushes.White;
        }

        private void Click_YellowRight(object sender, RoutedEventArgs e)
        {
            RightPanel.Background = RightPanel.Background == Brushes.White ? Brushes.Yellow : Brushes.White;
        }
    }
}
```
**Documentation**:

![Test1](/issues/_images/XAML_Layout_001.gif)