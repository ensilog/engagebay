# Ensilog.Engagebay
Welcome to the Ensilog.Engagebay repository! This is a C# wrapper for the EngageBay API, designed to make it easy to interact with the API from your C# projects.
> Note: This project is a work in progress. We appreciate any feedback, contributions, or comments you may have.

## Getting Started
To get started with the Ensilog.Engagebay, you'll need to install the package from NuGet. You can do this from the NuGet package manager in Visual Studio, or by using the dotnet CLI:

```bash
dotnet add package Ensilog.Engagebay
```

Once you have the package installed, you can start using it in your project. Here's an example of how to create a new instance of the EngageBayClient:

```csharp
using Ensilog.Engagebay;

var apiKey = "your_api_key_here";
var engageBayClient = new EngageBayClient(apiKey);
```

## Examples
Here are some examples of how to use the Ensilog.Engagebay to interact with the EngageBay API:

### Creating a Contact

```csharp
using Ensilog.Engagebay;
using Ensilog.Engagebay.Contacts;

var contact = new Contact
{
    FirstName = "John",
    LastName = "Doe",
    Email = "john.doe@example.com"
};

try
{
    var createdContact = await engageBayClient.CreateContactAsync(contact);
    Console.WriteLine($"Created contact with ID: {createdContact.Id}");
}
catch (Exception ex)
{
    Console.WriteLine($"Error creating contact: {ex.Message}");
}
```

### Retrieving a Contact by ID
```csharp
using Ensilog.Engagebay;
using Ensilog.Engagebay.Contacts;

long contactId = 12345; // Replace with a valid contact ID
try
{
    var retrievedContact = await engageBayClient.GetContactByIdAsync(contactId);
    Console.WriteLine($"Retrieved contact with name: {retrievedContact.FirstName} {retrievedContact.LastName}");
}
catch (Exception ex)
{
    Console.WriteLine($"Error retrieving contact: {ex.Message}");
}
```

## Contributing
We welcome contributions to the Ensilog.Engagebay project! Whether you want to report a bug, suggest a new feature, or submit a pull request, we appreciate your help in making this library better for everyone.
To contribute, please open an issue or submit a pull request on the GitHub repository.

## License
This project is licensed under the MIT License. See the LICENSE file for more information.