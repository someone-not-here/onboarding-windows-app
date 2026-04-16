### What were the issues with duplicated code?
The function pre-refactoring had repeated logic that checked if the provided names are null or whitespace only. This makes the original code a bit unreadable and could be prone to error since you would have to update every instance of the logic within the function.

### How did refactoring improve maintainability?
Since this null or whitespace logic has been condensed down into a single local function, if something is wrong with this logic, you would only need to change the single local function instead of multiple instances of the logic.

### Code
**Function before refactoring:**
```
public string GetFullName(string firstName, string middleName, string lastName)
{
    if (string.IsNullOrWhiteSpace(firstName))
        firstName = "";
    else
        firstName = firstName.Trim();

    if (string.IsNullOrWhiteSpace(middleName))
        middleName = "";
    else
        middleName = middleName.Trim();

    if (string.IsNullOrWhiteSpace(lastName))
        lastName = "";
    else
        lastName = lastName.Trim();

    return $"{firstName} {middleName} {lastName}".Trim();
}

```

**Function after refactoring:**
```
public string GetFullName(string firstName, string middleName, string lastName)
{
    string Clean(string s) => string.IsNullOrWhiteSpace(s) ? "" : s.Trim();

    return $"{Clean(firstName)} {Clean(middleName)} {Clean(lastName)}".Trim();
}
```