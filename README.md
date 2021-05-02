# GroceryCo

This prototype application prints an itemized receipt in console after performing a checkout process on items scanned by a customer: pulling current prices from the catalogue, applying promotions, and calculating the total price owed using effective price of each item scanned at kiosk. 
---

## Notes

The following directory houses all data used to demo this prototype application: *GroceryCo\bin\Debug\net5.0\data*

* **Basket.txt** is a simple text file representing customer’s basket housing one item in each line.
* **Catalogue.txt** is a simple text file representing the current price of an item in the catalogue and its price separated by a comma, on each line.
* **Promotion.txt** is a simple text file representing an item on sale and its promotional price separated by a comma, on each line.
---

## Assumptions

Basket.txt can be modified to test different permutations of the items a customer can scan at checkout assuming GroceryCo is a new cute little store that only sells the following items currently:

* Apple
* Coke
* Beans	
* Cake
* Pasta
* Milk
* Peas
* Juice
---

## Limitations/Design Choices

This prototype application works best when all 3 files mentioned in notes section above are written in the described format. Each line is read into a list of objects of type *CatalogueItem*. 
In a real-world application, these may be represented by databases with appropriate data validation constraints. 
---
