# 📝Inventory System App 

#### The Inventory System Application is a simple inventory management system built with ASP.NET Core 8.0 and with the MVC (Model-View-Controller) pattern to manage a store's inventory. It allows users to view a list of available products, add new products, and update existing ones.
#### Note: This project was entirely created using ChatGPT, demonstrating the efficiency of AI in software development tasks.

# 😎 Features:

⚒️ Add new products.
<br>
📝 Update existing ones.
<br>

# 🥸 Installation:

🩷 Clone this repo: https://github.com/DarjaLeonova/InventorySystem

🧡 Install dependencies:
Make sure you have .NET 8.0 SDK installed. Then, restore the NuGet packages:
```bash
dotnet restore
```
💛 Configure the database:
Update the connection string in InventorySystem/appsettings.json to point to your SQL Server instance.

💚 Apply migrations and update the database:

```bash
dotnet ef migrations add InitialCreate
dotnet ef database update
```
💙 Run the application:

```bash
dotnet run
```
🩵 Open your browser and navigate to http://localhost:5155/

# 🤔 Usage:

👉 Viewing Products
Navigate to http://localhost:5155/Products to see the list of available products.

👉 Adding a New Product
Go to http://localhost:5155/Products/Create
Enter the product details (name, description, price, quantity).
Click "Create" to add the product to the inventory.

👉 Updating an Existing Product
Navigate to http://localhost:5155/Products
Click "Edit" next to the product you want to update.
Modify the product details.
Click "Save" to apply the changes.

Tech stack: 

🟢 .NET 8.0
<br>
🟢 Entity Framework Core 8.0
<br>
🟢 MySQL.Data.EntityFrameworkCore
<br>
🟢 MySQL Server
<br>
🟢 NUnit unit test framework 6.0
<br>
🟢 MVC Pattern

# Short feedback: 
1️⃣ Was it easy to complete the task using AI?
<br>
Yes, from the first prompt ChatGPT generated a usable application.
<br>
2️⃣ How long did the task take you to complete?
<br>
To complete this task it took me about ~ 4h. 
<br>
3️⃣ Was the code ready to run after generation? What did you have to change to make it usable?
<br>
The code was ready to run after generation. 
However, the main problems occurred when it was time to test the application. Since there wasn't normal DAL and BLL I needed to add these layers and test them accordingly.
<br>
4️⃣ Which challenges did you face during the completion of the task?
<br>
The challenge was to connect to MySQL.
<br>
5️⃣ Which specific prompts did you learn as a good practice to complete the task?
<br>
By using task descriptions and giving a context for ChatGPT, I was able to complete the task of creating the inventory management system. 
The prompts provided clear and structured guidance at each step, ensuring a smooth development process.

