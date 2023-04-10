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

## Current development status
The Ensilog.Engagebay is currently in development and I'm doing this on my spare time. I intend to finalize a version 1.0 with all the listed feature of the official Engage bay documentation
Here is the status of the implemented endpoints in this wrapper. ✅ means that the endpoint is implemented, ❌ means that it is not implemented, and 🚧 means that the class is existing but there are some issues using it that I did not have the time to investigate into.
| API Endpoint | Class | Status |
| --- | --- | :---: |
| **1. Contacts** | | |
| [Listing contacts](https://github.com/engagebay/restapi#11-listing-contacts) | ListContacts | ✅ |
| [Get contact by ID](https://github.com/engagebay/restapi#12-get-contact-by-id) | GetContactById | ✅ |
| [Creating a contact](https://github.com/engagebay/restapi#13-creating-a-contact) | CreateContact | ✅ |
| [Updating a contact](https://github.com/engagebay/restapi#14-update-properties-of-a-contact-by-id-partial-update) | UpdatePartialContact | ✅ |
| [Delete single contact](https://github.com/engagebay/restapi#15-delete-single-contact) | DeleteContact | ✅ |
| [Get contact based on email address](https://github.com/engagebay/restapi#115-get-contact-based-on-email-address) | GetContactsByEmail | ✅ |
| [Adding tags to a contact based on email address](https://github.com/engagebay/restapi#16-adding-tags-to-a-contact-based-on-email-address) | AddTagsToContactsByEmail | ✅ |
| [Delete tags to a contact based on email address](https://github.com/engagebay/restapi#17-delete-tags-to-a-contact-based-on-email-address) | DeleteTagsToContactsByEmail | ✅ |
| [List tags for a contact based on email address](https://github.com/engagebay/restapi#18-list-tags-for-a-contact-based-on-email-address) | ListContactTagsByEmail | ✅ |
| [Add score to a contact using email address](https://github.com/engagebay/restapi#19-add-score-to-a-contact-using-email-address) | AddScoreToContactByEmail | 🚧 |
| [Search contacts](https://github.com/engagebay/restapi#110-search-contacts) | SearchContacts | ✅ |
| [List tags for a contact by ID](https://github.com/engagebay/restapi#111-list-tags-for-a-contact-by-id) | ListContactTagsById | ✅ |
| [Adding tags to a contact by ID](https://github.com/engagebay/restapi#112-adding-tags-to-a-contact-by-id) | AddTagsToContactById | ✅ |
| [Delete tags value by ID](https://github.com/engagebay/restapi#113-delete-tags-value-by-id) | DeleteContactTagsById | ✅ |
| [Change contact owner](https://github.com/engagebay/restapi#114-change-contact-owner) | ChangeContactOwner | 🚧 |
| [Creating a batch of contacts](https://github.com/engagebay/restapi#116-creating-a-batch-of-contacts) | CreateBatchContacts | ✅ |
| [Get contact notes](https://github.com/engagebay/restapi#117-get-contact-notes) | GetNotesByContactId | ✅ |
| [Get contact call logs](https://github.com/engagebay/restapi#118-get-contact-call-logs) | GetContactCallLogs | ✅ |
| **2. Company APIs** | | |
| [Creating a company](https://github.com/engagebay/restapi#21-creating-a-company) | | ❌ |
| [Updating a company](https://github.com/engagebay/restapi#22-update-properties-of-a-company-by-id-partial-update) | | ❌ |
| [Get list of companies](https://github.com/engagebay/restapi#23-get-list-of-companies) | | ❌ |
| [Get company by id](https://github.com/engagebay/restapi#24-get-company-by-id) | | ❌ |
| [Delete single company](https://github.com/engagebay/restapi#25-delete-single-company) | | ❌ |
| [Search companies](https://github.com/engagebay/restapi#26-search-companies) | | ❌ |
| [Add contact to company by contact Id](https://github.com/engagebay/restapi#27-add-contact-to-company-by-contact-id) | | ❌ |
| [Add contact to company using email address](https://github.com/engagebay/restapi#28-add-contact-to-company-using-email-address) | | ❌ |
| **3. Deals** | | |
| [Listing deals](https://github.com/engagebay/restapi#31-listing-deals) | | ❌ |
| [Get deal by its ID](https://github.com/engagebay/restapi#32-get-deal-by-its-id) | | ❌ |
| [Create a deal](https://github.com/engagebay/restapi#33-create-a-deal) | | ❌ |
| [Delete a deal](https://github.com/engagebay/restapi#34-delete-a-deal) | | ❌ |
| [Create deal to a contact using email address](https://github.com/engagebay/restapi#35-create-deal-to-a-contact-using-email-address) | | ❌ |
| [Search deals](https://github.com/engagebay/restapi#36-search-deals) | | ❌ |
| [Update deal track](https://github.com/engagebay/restapi#37-update-deal-track) | | ❌ |
| [Updating a deal](https://github.com/engagebay/restapi#38-update-properties-of-a-deal-by-id-partial-update) | | ❌ |
| **4. Tracks** | | |
| [Get all tracks](https://github.com/engagebay/restapi#41-get-all-tracks) | | ❌ |
| [Create track](https://github.com/engagebay/restapi#42-create-track) | | ❌ |
| [Update track](https://github.com/engagebay/restapi#43-update-track) | | ❌ |
| [Get track by ID](https://github.com/engagebay/restapi#44-get-track-by-id) | | ❌ |
| [Delete track by ID](https://github.com/engagebay/restapi#45-delete-track-by-id) | | ❌ |
| **5. Events** | | |
| [Get list of events](https://github.com/engagebay/restapi#51-get-list-of-events) | | ❌ |
| [Get events related to contact](https://github.com/engagebay/restapi#52-get-events-related-to-contact) | | ❌ |
| [Create event](https://github.com/engagebay/restapi#53-create-event) | | ❌ |
| [Update event](https://github.com/engagebay/restapi#54-update-event) | | ❌ |
| **6. Tasks** | | |
| [Get the list of tasks based on given filters](https://github.com/engagebay/restapi#61-get-the-list-of-tasks-based-on-given-filters) | | ❌ |
| [Get the task based on ID](https://github.com/engagebay/restapi#62-get-the-task-based-on-id) | | ❌ |
| [Create task](https://github.com/engagebay/restapi#63-create-task) | | ❌ |
| [Update task](https://github.com/engagebay/restapi#64-update-task) | | ❌ |
| [Delete a task based on ID](https://github.com/engagebay/restapi#65-delete-a-task-based-on-id) | | ❌ |
| **7. Notes** | | |
| [Create a note](https://github.com/engagebay/restapi#71-create-a-note) | | ❌ |
| **8. Forms** | | |
| [List of forms](https://github.com/engagebay/restapi#81-list-of-forms) | | ❌ |
| [Add contact to a form](https://github.com/engagebay/restapi#82-add-contact-to-a-form) | | ❌ |
| **9. Sequences** | | |
| [Add contact to a sequence](https://github.com/engagebay/restapi#91-add-contact-to-a-sequence) | | ❌ |
| **10. Lists** | | |
| [List of lists](https://github.com/engagebay/restapi#101-list-of-lists) | | ❌ |
| [Add contact to list](https://github.com/engagebay/restapi#102-add-contact-to-list) | | ❌ |
| **11. Owners** | | |
| [Get list of owners](https://github.com/engagebay/restapi#111-get-list-of-owners) | | ❌ |
| **12. CustomFields** | | |
| [Get list of custom fields](https://github.com/engagebay/restapi#121-get-list-of-custom-fields) | | ❌ |
| [Create a custom field](https://github.com/engagebay/restapi#122-create-a-custom-field) | | ❌ |
| [Delete a custom field](https://github.com/engagebay/restapi#123-delete-a-custom-field-) | | ❌ |
| **13. User Profile** | | |
| [Get user profile](https://github.com/engagebay/restapi#131-get-user-profile-) | | ❌ |
| **14. Tickets** | | |
| [Listing tickets](https://github.com/engagebay/restapi#141-get-list-of-tickets) | | ❌ |
| [Listing tickets by filter](https://github.com/engagebay/restapi#142-get-list-of-tickets-by-filter) | | ❌ |
| [Get ticket by ID](https://github.com/engagebay/restapi#145-get-ticket-by-id) | | ❌ |
| [Create a ticket](https://github.com/engagebay/restapi#143-create-a-ticket) | | ❌ |
| [Delete a ticket](https://github.com/engagebay/restapi#144-delete-a-ticket) | | ❌ |
| **15. Tags** | | |
| [List of Tags](https://github.com/engagebay/restapi#151-list-of-tags) | | ❌ |
| [Add Tag](https://github.com/engagebay/restapi#152-add-tag) | | ❌ |
| **16. Products** | | |
| [List of products](https://github.com/engagebay/restapi#161-list-of-products) | | ❌ |
| [Get product by ID](https://github.com/engagebay/restapi#162-get-product-by-id) | | ❌ |
| [Create a product](https://github.com/engagebay/restapi#163-creating-a-product) | | ❌ |
| [Update a product by ID](https://github.com/engagebay/restapi#164-update-a-product-by-id) | | ❌ |
| [Update properties of a product](https://github.com/engagebay/restapi#165-update-properties-of-a-product-by-id-partial-update) | | ❌ |
| [Get product by Name](https://github.com/engagebay/restapi#166-get-product-by-name) | | ❌ |
| [Delete single product](https://github.com/engagebay/restapi#167-delete-single-product) | | ❌ |
| [Add a product to contact](https://github.com/engagebay/restapi#168-add-a-product-to-contact) | | ❌ |
| [Delete a product from contact](https://github.com/engagebay/restapi#169-delete-a-product-from-contact) | | ❌ |
| **17. Broadcast** | | |
| [Create a Broadcast](https://github.com/engagebay/restapi#171-creating-a-broadcast) | | ❌ |


## Contributing
Contributions to the Ensilog.Engagebay project are very welcome! Whether you want to report a bug, suggest a new feature, or submit a pull request, we appreciate your help in making this library better for everyone.
To contribute, please open an issue or submit a pull request on the GitHub repository.

## Disclaimer
I tried to optimize my time on this project, so I extensively used the new AI tools we have now at our disposal in this project (ChatGPT, Github copilot mainly). Feel free to open an issue if you find any weird stuff whether it being in the code or in the documentation.
I normally check eveything that went out of the AI, but I might have missed something 😄

## License
This project is licensed under the MIT License. See the LICENSE file for more information.