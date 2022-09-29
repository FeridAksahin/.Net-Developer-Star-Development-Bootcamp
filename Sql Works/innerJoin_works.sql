SELECT top 10 * FROM Orders WHERE CustomerID = 'VINET'

Select TOP 10 * from Customers WHERE CustomerID = 'VINET'

--ili�kisel iki tabloyu join ile ba�lama (fk i�eren tabloyu ba�lama di�er tabloyla) - Inner Join

--ayn� alan ba�ka tablolarda tekrar edebilir diye, s�tun isimlerini yazarken hangi tablodan oldugunu g�stermek amac�yla tabloismi.columnName ile yaz�l�r
--customer ve orders tablosunu tamamen birle�tir customer �d olarak VINET bilgilerini getir
SELECT * FROM Orders JOIN Customers ON Orders.CustomerID = Customers.CustomerID where 
Orders.CustomerID = 'VINET'

--customer ve orders tablolar�n� birle�tir, OrderDate, RequiredDate, Adress ve �irket ismi listelensin 'VINET' customerID'si i�in
SELECT Orders.OrderDate, Orders.RequiredDate, Customers.[Address], Customers.CompanyName FROM Orders JOIN Customers ON Orders.CustomerID = Customers.CustomerID where 
Orders.CustomerID = 'VINET'

--customer tablosunun tamam� orders tablosunun sadece ship adresi
select Orders.ShipAddress, Customers.* from Orders JOIN Customers ON Orders.CustomerID = Customers.CustomerID 

--JOIN soluna INNER yazsakta ayn� �eydir, join ve inner join ayn�d�r
select Orders.ShipAddress, Customers.* from Orders INNER JOIN Customers ON Orders.CustomerID = Customers.CustomerID 


use Northwind
--�r�n ad�n�, kategorisini, tedarik�isini ve birim fiyat�n� listele en pahal�dan
Select p.ProductName AS [�r�n Ad�],c.CategoryName AS [Kategori �smi],s.CompanyName AS [Tedarik�i �smi],p.UnitPrice AS [Birim Fiyat�] from Products 
p JOIN Categories c ON c.CategoryID = p.CategoryID JOIN Suppliers s ON s.SupplierID = p.SupplierID ORDER BY p.UnitPrice DESC
 
select * from Employees

 

--en �ok sat�� yapan
Select e.FirstName, e.LastName, SUM(Distinct(od.Quantity*od.UnitPrice*(1-od.Discount))) as [Toplam Sat�� Miktar�] from Orders  
o JOIN Employees e ON e.EmployeeID = o.EmployeeID JOIN [Order Details] od ON od.OrderID = o.OrderID where e.FirstName is not null GROUP BY e.FirstName , e.LastName
Order by [Toplam Sat�� Miktar�] desc

--hangi kargoda ka� �e�it �r�n

Select * from Shippers
select * from Orders
Select * from [Order Details]

--Hangi kargoda ka� �e�it �r�n?
SELECT  Count(distinct od.ProductID) as [Ka� �e�it �r�n], 
s.CompanyName AS [Kargo Firmas�] FROM Orders o JOIN Shippers s ON o.ShipVia = s.ShipperID JOIN [Order Details] od ON o.OrderID = od.OrderID group BY s.CompanyName

--distinct ald�kki tekrar edenler say�lmas�n 

--olmayan datalar� ara�t�r left join	

Select * from Employees Where Employees.FirstName is null


--Employees tablosunda, isim, b�lge null olan kay�tlarda girilmedi bilgisi yazs�n ve �lkelerin tam ismi yazs�n
Select
	CASE WHEN FirstName is null
		then '�sim giri�i bulunamad�.'
		else FirstName
		end as �sim,
	CASE WHEN Region is null
		then 'B�lge giri�i yok'
		else Region 
		end as B�lge,
	CASE (Employees.Country)
		when 'USA'
		then 'Amerika'
		when 'UK'
		then '�ngiltere'
		else '�lke giri�i yok'
		end as �lke,
Employees.City from Employees


--sipari� veren kullan�c�lar
 select Employees.FirstName, Employees.LastName from Employees where exists(select Orders.EmployeeID from Orders where Employees.EmployeeID = Orders.EmployeeID and Employees.FirstName is not null)

 --sipari� vermeyen kullan�c�lar
 select e.FirstName from Employees e Where not exists(select o.EmployeeID from Orders o where o.EmployeeID = e.EmployeeID )