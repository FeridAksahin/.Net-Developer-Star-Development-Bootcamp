SELECT top 10 * FROM Orders WHERE CustomerID = 'VINET'

Select TOP 10 * from Customers WHERE CustomerID = 'VINET'

--iliþkisel iki tabloyu join ile baðlama (fk içeren tabloyu baðlama diðer tabloyla) - Inner Join

--ayný alan baþka tablolarda tekrar edebilir diye, sütun isimlerini yazarken hangi tablodan oldugunu göstermek amacýyla tabloismi.columnName ile yazýlýr
--customer ve orders tablosunu tamamen birleþtir customer ýd olarak VINET bilgilerini getir
SELECT * FROM Orders JOIN Customers ON Orders.CustomerID = Customers.CustomerID where 
Orders.CustomerID = 'VINET'

--customer ve orders tablolarýný birleþtir, OrderDate, RequiredDate, Adress ve þirket ismi listelensin 'VINET' customerID'si için
SELECT Orders.OrderDate, Orders.RequiredDate, Customers.[Address], Customers.CompanyName FROM Orders JOIN Customers ON Orders.CustomerID = Customers.CustomerID where 
Orders.CustomerID = 'VINET'

--customer tablosunun tamamý orders tablosunun sadece ship adresi
select Orders.ShipAddress, Customers.* from Orders JOIN Customers ON Orders.CustomerID = Customers.CustomerID 

--JOIN soluna INNER yazsakta ayný þeydir, join ve inner join aynýdýr
select Orders.ShipAddress, Customers.* from Orders INNER JOIN Customers ON Orders.CustomerID = Customers.CustomerID 


use Northwind
--ürün adýný, kategorisini, tedarikçisini ve birim fiyatýný listele en pahalýdan
Select p.ProductName AS [Ürün Adý],c.CategoryName AS [Kategori Ýsmi],s.CompanyName AS [Tedarikçi Ýsmi],p.UnitPrice AS [Birim Fiyatý] from Products 
p JOIN Categories c ON c.CategoryID = p.CategoryID JOIN Suppliers s ON s.SupplierID = p.SupplierID ORDER BY p.UnitPrice DESC
 
select * from Employees

 

--en çok satýþ yapan
Select e.FirstName, e.LastName, SUM(Distinct(od.Quantity*od.UnitPrice*(1-od.Discount))) as [Toplam Satýþ Miktarý] from Orders  
o JOIN Employees e ON e.EmployeeID = o.EmployeeID JOIN [Order Details] od ON od.OrderID = o.OrderID where e.FirstName is not null GROUP BY e.FirstName , e.LastName
Order by [Toplam Satýþ Miktarý] desc

--hangi kargoda kaç çeþit ürün

Select * from Shippers
select * from Orders
Select * from [Order Details]

--Hangi kargoda kaç çeþit ürün?
SELECT  Count(distinct od.ProductID) as [Kaç Çeþit Ürün], 
s.CompanyName AS [Kargo Firmasý] FROM Orders o JOIN Shippers s ON o.ShipVia = s.ShipperID JOIN [Order Details] od ON o.OrderID = od.OrderID group BY s.CompanyName

--distinct aldýkki tekrar edenler sayýlmasýn 

--olmayan datalarý araþtýr left join	

Select * from Employees Where Employees.FirstName is null


--Employees tablosunda, isim, bölge null olan kayýtlarda girilmedi bilgisi yazsýn ve ülkelerin tam ismi yazsýn
Select
	CASE WHEN FirstName is null
		then 'Ýsim giriþi bulunamadý.'
		else FirstName
		end as Ýsim,
	CASE WHEN Region is null
		then 'Bölge giriþi yok'
		else Region 
		end as Bölge,
	CASE (Employees.Country)
		when 'USA'
		then 'Amerika'
		when 'UK'
		then 'Ýngiltere'
		else 'Ülke giriþi yok'
		end as Ülke,
Employees.City from Employees


--sipariþ veren kullanýcýlar
 select Employees.FirstName, Employees.LastName from Employees where exists(select Orders.EmployeeID from Orders where Employees.EmployeeID = Orders.EmployeeID and Employees.FirstName is not null)

 --sipariþ vermeyen kullanýcýlar
 select e.FirstName from Employees e Where not exists(select o.EmployeeID from Orders o where o.EmployeeID = e.EmployeeID )