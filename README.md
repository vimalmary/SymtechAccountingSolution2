# SymtechAccountingSolution

# SUMMARY

- Project name is changed to more meaningful name as SymtechAccountingSolution.

- In the provided solution, most of the business logics are written in controller classes, that are shifted to Model class in this version.

- SQL query executions are managed in DBManager.cs  which is placed in Utilities folder.

- SQL connection string is added in web.config. So that any change in connection string wont affect the application.

- Added unit test project. Since there is time restrictions I couldn't implement any test methods.

- Stored procedure is used for saving account transaction details. Sql Transaction is used to avoid partial saving.

- Methods in Model classes are documented with short descriptions.


## FUTURE IMPROVEMENTS

- We can use Entity Framework code first approach. In this approach we can start with creating classes rather than designing database first. 
  Then the EF API will create the database based on the domain classes and configuration.

- We can implement unit testing that varifies the accuracy of each unit.





The api is composed of the following endpoints:

| Verb     | Path                                   | Description
|----------|----------------------------------------|--------------------------------------------------------
| `GET`    | `/api/Accounts`                        | Gets the list of all accounts
| `GET`    | `/api/Accounts/{id:guid}`              | Gets an account by the specified id
| `POST`   | `/api/Accounts`                        | Creates a new account
| `PUT`    | `/api/Accounts/{id:guid}`              | Updates an account
| `DELETE` | `/api/Accounts/{id:guid}`              | Deletes an account
| `GET`    | `/api/Accounts/{id:guid}/Transactions` | Gets the list of transactions for an account
| `POST`   | `/api/Accounts/{id:guid}/Transactions` | Adds a transaction to an account, and updates the amount of money in the account

Models should conform to the following formats:

**Account**
```
{
    "Id": "01234567-89ab-cdef-0123-456789abcdef",
	"Name": "Savings",
	"Number": "012345678901234",
	"Amount": 123.4
}
```	

**Transaction**
```
{
    "Date": "2018-09-01",
    "Amount": -12.3
}
```

