# Example-of-Customer-Inquiry
Example of Customer that inquiry transaction (2P2C)
Description:
   Implement a service to provide customer inquiry and return result, which contains customer detail and
its recent payment history.

*************************************************************************
Note:
Ccould see commit step in develop branch? 
After I develop completed, it will merge to master branch.
*************************************************************************

For SQL Scripts in Project: 
1. Example.WebApi.DataAccess\SqlScripts\scripts.sql
2. Example.WebApi.DataAccess\SqlScripts\sample.sql

Link in Localhost [HTTP]: http://localhost:5000/api/transaction/inquiry
Link in Localhost [HTTPS]: https://localhost:5001/api/transaction/inquiry

--------------------------------------------------------------------------
Example validation with not send a field:
Sample Response:
{

}

Sample Response:
{
    "": [
        "No inquiry criteria"
    ]
}
--------------------------------------------------------------------------
Example validation with not like customer format:
Sample Response:
{
   "customerID" : "test_id"
}

Sample Response:
{
    "customerID": [
        "Invalid Customer ID"
    ]
}
--------------------------------------------------------------------------
Example validation with not like email format:
Sample Response:
{
   "email" : "not_email"
}

Sample Response:
{
    "email": [
        "Invalid Email"
    ]
}

--------------------------------------------------------------------------

Example validation with Transaction not found:
Sample Response:
{
  "customerID" : 90019982,
  "email" : "notfound@domain.com"
}

Sample Response: Not Found
--------------------------------------------------------------------------

Example without transaction
Sample Request:
{
  "customerID" : 90019982
}

Sample Response:
{
    "customerID": 90019982,
    "email": "user2@domain.com",
    "customerName": "Amanda PickNiSon",
    "mobile": "0810000002",
    "status": "Active",
    "transactions": []
}
--------------------------------------------------------------------------

Example with transaction
Sample Request:
{
  "customerID" : 90019981
}
OR
{
  "email" : "user1@domain.com"
}
OR
{
  "customerID" : 90019981,
  "email" : "user1@domain.com"
}

Sample Response:
{
    "customerID": 90019981,
    "email": "user1@domain.com",
    "customerName": "John Rotaminary",
    "mobile": "0810000001",
    "status": "Active",
    "transactions": [
        {
            "id": 1,
            "date": "2019-07-22T09:00:00",
            "amount": 2000,
            "currency": "USD",
            "status": "Success"
        },
        {
            "id": 2,
            "date": "2019-07-22T09:05:11",
            "amount": 100,
            "currency": "USD",
            "status": "Failed"
        },
        {
            "id": 3,
            "date": "2019-07-22T18:30:55",
            "amount": 5800.5,
            "currency": "THB",
            "status": "Failed"
        }
    ]
}
--------------------------------------------------------------------------