## Research and Learn

### What are the differences between styling and templating in WPF?
- Styles are used to set the properties on a control without changing its structure.
- ControlTemplates define the entire visual structure of the control.
- Styles affect only the properties of a control (color, fonts, margins, etc.), while ControlTemplates affect the layout of the control.

### How do you define and apply styles and control templates?
Styles are defined as so:
```
<Style x:Key="PressMeButtonStyle" TargetType="Button">
    <Setter Property="Background" Value="SteelBlue"/>
    <Setter Property="Foreground" Value="White"/>
    <Setter Property="FontSize" Value="14"/>
</Style>
```

...and applied through:
```
<Button Content="Press Me!" Style="{StaticResource PressMeButtonStyle}"/>
```

Ttemplates are defined as so:
```
<ControlTemplate x:Key="PressMeButtonTemplate" TargetType="Button">
    <Border Background="SteelBlue" CornerRadius="5">
        <ContentPresenter HorizontalAlignment="Center"
                          VerticalAlignment="Center"/>
    </Border>
</ControlTemplate>
```

...and applied through:
```
<Button Content="Press Me!" Template="{StaticResource PressMeButtonTemplate}" />
```

### What are best practices for designing reusable and adaptive UI elements?
- Use styles first 
- Centralize styling with resource dictionaries
- Use DataTemplates for reusable data presentation
- Support theming from the start

## Reflection

### How can using styles enforce consistency across your application?
Styles affect all components that use them; you change the style, you change the look of all the components. This helps maintain consistency across the application without having to individually modify each component.

### Reflect on the benefits and challenges of using control templates.
- **Benefits**
    - Full visual customization
    - Separation of design and logic
    - Reuse without rewriting behavior
- **Challenges**
    - Difficult to debug
    - More XAML complexity
    - Easy to break built-in behavior visually

### How might templating improve the maintainability of your UI?
- Changes to templates don't affect logic.
- Reusable UI components.
- Easier redesigns.
- Centralized UI changes.


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
        Title="MainWindow" Height="450" Width="800">
    <Grid>
        <TextBox Text="Hello World!" HorizontalAlignment="Center" FontSize="32" TextWrapping="Wrap" TextAlignment="Center" VerticalAlignment="Center" Width="292" Height="52" Style="{StaticResource ResourceKey=TextBoxStyle}" Template="{StaticResource ResourceKey=TextBoxTemplate}"/>
        <Button Content="Press Me!" FontSize="28" HorizontalAlignment="Center" Margin="0,264,0,0" VerticalAlignment="Top" Height="51" Width="160"  Style="{StaticResource PressMeButtonStyle}" Template="{StaticResource PressMeButtonTemplate}"/>
    </Grid>
</Window>
```

```
<!-- App.xaml -->

<Application x:Class="WPFProject2.App"
             xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"
             xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml"
             xmlns:local="clr-namespace:WPFProject2"
             StartupUri="MainWindow.xaml">
    <Application.Resources>
        <!-- Button Style -->
        <Style x:Key="PressMeButtonStyle" TargetType="Button">
            <Setter Property="Background" Value="SteelBlue"/>
            <Setter Property="Foreground" Value="White"/>
            <Setter Property="FontSize" Value="14"/>
        </Style>

        <!-- Button ControlTemplate -->
        <ControlTemplate x:Key="PressMeButtonTemplate" TargetType="Button">
            <Border x:Name="border" Background="{TemplateBinding Background}" CornerRadius="5">
                <ContentPresenter HorizontalAlignment="Center"
                                  VerticalAlignment="Center"/>
            </Border>

            <ControlTemplate.Triggers>
                <!-- Hover -->
                <Trigger Property="IsMouseOver" Value="True">
                    <Setter TargetName="border" Property="Background" Value="#FFBEE6FD"/>
                    <Setter TargetName="border" Property="BorderBrush" Value="#FF3C7FB1"/>
                </Trigger>

                <!-- Pressed -->
                <Trigger Property="IsPressed" Value="True">
                    <Setter TargetName="border" Property="Background" Value="#FFC4E5F6"/>
                    <Setter TargetName="border" Property="BorderBrush" Value="#FF2C628B"/>
                </Trigger>
            </ControlTemplate.Triggers>
        </ControlTemplate>

        <!-- Text Box Style -->
        <Style x:Key="TextBoxStyle" TargetType="TextBox">
            <Setter Property="Foreground" Value="White"/>
            <Setter Property="FontSize" Value="14"/>
        </Style>

        <!-- Text Box ControlTemplate -->
        <ControlTemplate x:Key="TextBoxTemplate" TargetType="TextBox">
            <Border x:Name="Border"
                    Background="CadetBlue"
                    CornerRadius="6">

                <ScrollViewer x:Name="PART_ContentHost"
                              Margin="0"
                              VerticalAlignment="Center"/>
            </Border>
        </ControlTemplate>
    </Application.Resources>
</Application>
```

**Documentation:**
![Test1](issues/_images/Styling_Templating_001.jpg)