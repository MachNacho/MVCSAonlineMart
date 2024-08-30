# My ITEHA assignment
# Welcome
Welcome to my ITEHA assignment. This assignment is an e-commerce website called: SA Online Mart.

# Features
- Cart functionality
- Browsing
- Account registration and login
- CRUD for products

# How to get started
## Prerequisites
- Microsoft SQL server

## setup
1. Click on the solution to load the project
2. Open the appsettings.json file, and paste this into the file
```json
   "ConnectionStrings": {
    "DefaultConnection": "Data Source=(YOUR DB));Initial Catalog=(YOUR TABLE);Integrated Security=True;Pooling=False;Encrypt=False;Trust Server Certificate=False"
  }
```

This will ensure that there is a connection to the Database

3. [Migration help](https://learn.microsoft.com/en-us/ef/core/managing-schemas/migrations/?tabs=vs) Use the guide if lost.
Run the update database command to allow for creation of tables in the database.

**Optional**
If you want example data in the DB
run this command in visual studio developer powershell
```
dotnet run seeddata
```
