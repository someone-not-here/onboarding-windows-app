// Example 1: Magic Numbers and Strings

// Before
private static void MainMenu(int subMenu) {
    if (subMenu == 1) {             // Magic number used
        // ...
    }
    else if (subMenu == 2) {        // Magic number used
        // ...
    }
    else if (subMenu == 2048) {     // Magic number used
        // ...
    }

    if (subMenu == 2) {
        string password = Console.ReadLine();

        if (password == "rabbit") {     // Magic string used
            // ...
        }
        else {
            // ...
        }
    }
}

// After
private enum SubMenuStates
{
    Continue = 1,
    InputSecretPassword = 2,
    Quit = 2048
}

private const string superSecretPassword = "rabbit";

private static void MainMenu(SubMenuStates subMenu) {
    if (subMenu == SubMenuStates.Continue) {
        // ...
    }
    else if (subMenu == SubMenuStates.InputSecretPassword) {
        // ...
    }
    else if (subMenu == SubMenuStates.Quit) {
        // ...
    }

    if (subMenu == SubMenuStates.InputSecretPassword) {
        string password = Console.ReadLine();

        if (password == superSecretPassword) {
            // ...
        }
        else {
            // ...
        }
    }
}

// ---------------------------------------------------------------------------------------------------

// Example 2: Long Functions

// Before
private List<string> passwordList = new List<string>();

private static void InputValidateStore() {

    string password;

    // Input password
    password = Console.ReadLine();

    // Validate length
    if (password.Length < 30) {
        // ...
    }

    //Store password
    passwordList.Add(password);
}


// After
private List<string> passwordList = new List<string>();

private static void ProcessPassword() {
    string password = InputPassword();

    if (ValidatePassword(password) == false) {
        // ...
    }

    StorePassword(password);

}

private static string InputPassword() {
    return Console.ReadLine();
}

private static bool ValidatePassword(string password) {
    return password => 30;
}

private static void StorePassword(string password) {
    passwordList.Add(password)
}

// ---------------------------------------------------------------------------------------------------

// Example 3: Duplicate Code

// Before
public void ProcessDomesticOrder(Order order)
{
    if (order == null || order.Items.Count == 0)
    {
        // ...
    }

    decimal total = 0;
    foreach (var item in order.Items)
    {
         total += item.Price * item.Quantity;
    }

    // Apply tax
    total += total * 0.08m;

    Console.WriteLine($"Domestic order processed. Total: ${total}");
}

public void ProcessInternationalOrder(Order order)
{
    if (order == null || order.Items.Count == 0)
    {
        // ...
    }

    decimal total = 0;
    foreach (var item in order.Items)
    {
        total += item.Price * item.Quantity;
    }

    // Apply tax
    total += total * 0.15m;  // 15% tax

    Console.WriteLine($"International order processed. Total: ${total}");
}

// After
public void ProcessDomesticOrder(Order order)
{
    ProcessOrder(order, 0.08m, "Domestic");
}

public void ProcessInternationalOrder(Order order)
{
    ProcessOrder(order, 0.15m, "International");
}

private void ProcessOrder(Order order, decimal taxRate, string orderType)
{
    // Validate order
    if (order == null || order.Items.Count == 0)
    {
        // ...
    }

    // Calculate total
    decimal total = 0;
    foreach (var item in order.Items)
    {
        total += item.Price * item.Quantity;
    }

    // Apply tax
    total += total * taxRate;

    Console.WriteLine($"{orderType} order processed. Total: ${total}");
}

// ---------------------------------------------------------------------------------------------------

// Example 4: Large Classes/God Objects

// Before
class Employee
{
    public string Name { get; set; }
    public string EmployeeID { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }

    public void AddEmployee() { }
    public void RemoveEmployee() { }
    public void SendVerificationEmail() { }
    public void UpdatePassword() { }
}

// After
class Employee
{
    public string Name { get; set; }
    public string EmployeeID { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
}

class EmployeeDatabase
{
    public void AddEmployee() { }
    public void RemoveEmployee() { }    
}

class CredentialsHandler
{
       public void UpdatePassword() { } 
}

class EmailService
{
    public void SendVerificationEmail() { }
}

// ---------------------------------------------------------------------------------------------------

// Example 5: Deeply Nested Conditionals

// Before
private static List<string> passwordStorage = new List<string>();

private static bool IsPasswordValid(string password) {
    if (password.Length >= 24) {
        if (password.Contains("!")) {
            if (!passwordStorage.Contains(password)) {
                return true;
            }
        }
    }

    return false;
}

// After
private static List<string> passwordStorage = new List<string>();

private static bool IsPasswordValid(string password) {
    if (password.Length < 24) {
        return false;
    }

    if (!password.Contains("!")) {
        return false;
    }

    if (passwordStorage.Contains(password)) {
        return false;
    }

    return true;
}

// ---------------------------------------------------------------------------------------------------

// Example 6: Commented Out Code

// Before
public void ProcessOrderDomestic(Order order)
{
    ProcessOrderDomestic(order, 0.08m);
}


// We no longer process international orders as of April 2026
/*
public void ProcessInternationalOrder(Order order)
{
    ProcessOrder(order, 0.15m, "International");
}
*/


private void ProcessOrder(Order order, decimal taxRate)
{
    // Validate order
    if (order == null || order.Items.Count == 0)
    {
        // ...
    }

    // Calculate total
    decimal total = 0;
    foreach (var item in order.Items)
    {
        total += item.Price * item.Quantity;
    }

    // Apply tax
    total += total * taxRate;

    // Console.WriteLine($"{orderType} order processed. Total: ${total}");
    Console.WriteLine($"Domestic order processed. Total: ${total}");
}

// After
public void ProcessOrderDomestic(Order order)
{
    ProcessOrder(order, 0.08m);
}

private void ProcessOrder(Order order, decimal taxRate)
{
    // Validate order
    if (order == null || order.Items.Count == 0)
    {
        // ...
    }

    // Calculate total
    decimal total = 0;
    foreach (var item in order.Items)
    {
        total += item.Price * item.Quantity;
    }

    // Apply tax
    total += total * taxRate;

    Console.WriteLine($"Domestic order processed. Total: ${total}");
}

// ---------------------------------------------------------------------------------------------------

// Example 7: Inconsistent Naming

// Before
// Unrepresentative and unclear name
public static float GetFinalDamage(float baseDamage, float mod)
{
    // Purpose of "mod" is unclear
    float final = baseDamage * mod;

    return final;
}

// After
public static float ApplyDamageReduction(float baseDamage, float damageReductionPercentage)
{
    float finalDamage = baseDamage * damageReductionPercentage;

    return finalDamage;
}
