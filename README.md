This is a test task for DotNET.

1- Fork this repository to your own github account

2- Adjust connection string to a sql express database (Store.mdf) in the app_data directory

3- All your code should be under Areas>>Store

4- Provide a good code structure: Models | Controllers

5- Create the following 2 Models: 

Product:

		ProductName
		
		Price
		
		Stock
		
		IsActive
		

Store:
		Address
		
		Name
		
A store can have multiple products
	
6- migrate the models to databse using Code first database migration

7- Create APIs for:
	List/Add/Edit/Delete Products
	
8- tests your apis using postman (download it if you dont have)

