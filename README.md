# ELMAKON - JSON REST API
JSON REST API is available for third party developers to make custom client application for the website. 
Document illustrates following aspects of API:
* Available endpoints 
* HTTP methods
* Expected request bodies (query or routes) 
* Returned response from endpoints 


## Product Endpoints
#### Request - Get all products
```Method: GET``` 
```URL: /api/products```
```Authentication: none```
#### Response
```JS
[
	{
		id, // int
		categoryId, // int
		title, // string
		description, // string
		price, // double
		amount, // int
	}
]
```
***
#### Request - Get product by id
```Mehtod: GET```
```URL: /api/products/<ProductID>```
#### Response
```JS
{
	Id, // int <ProductID>
	CategoryId, // int
	Title, // string
	Description, // string
	Price, // double
	Amount, // int
}
```
***
#### Request - Create product
```Mehtod: POST```
```URL: /api/products```
```Content-Type: application/json```
```JS
// Request body
{
	CategoryId, 	// int
	Title, 		// string
	Description,	// string
	Price, 		// double
	Amount, 	// int
}
```
#### Response
```JS
{
	data,  // product object - undefined if errors occured
}
```
***
#### Request - Update product
```Mehtod: PUT```
```URL: /api/products/<ProductId>```
```Content-Type: application/json```
```JS
// Request body
{
	CategoryId, 	// int
	Title, 		// string
	Description,	// string
	Price, 		// double
	Amount, 	// int
}
```
#### Response
```JS
{
	data,  // product object - undefined if errors occured
}
```
***
#### Request - Delete product
```Mehtod: DELETE```
```URL: /api/product/<ProductID>```
#### Response
```JS
{
	done,  // boolean - true if successfully done
}
```
## Filter Endpoint
#### Request - Get all products paged, sorted, searched
```Method: POST```
```URL: /api/filter```
```Content-Type: application/json```
```JS
// Request Body
{
	Title,		// string - search by title, empty '' to unset
	CategoryId,	// int - get all by category id, 0 to unset
	PriceFrom,	// double - get by starting price, 0 to unset
	PriceTo,	// double - get by ending price, 0 to unset
	ASC,		// boolean - true for ascending price, vice-versa
	Page,		// int - which page you want?
}
```
#### Response
```JS
{
	page,		// int - currently served page
	pageCount, 	// int - number of pages that match given filters
	products,	// array - array of product objects matching filters 
}
```
#### Request - Get all categories
```Method: GET```
```URL: /api/filter```
#### Response
```JS
[
	{
		id, 	// array of categories
		name, 
	}
]
```

---
Made with ❤️ in 🇺🇿 by [Nodirbek Sharipov](https://nodir.dev)
