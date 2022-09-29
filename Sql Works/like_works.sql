 
use Northwind

Select * from Employees

DELETE FROM Employees Where FirstName is null and LastName is null

Select * from Customers

--ilk harfi A ile baþlayan þirketler
Select * from Customers Where CompanyName LIKE 'A%' 
--'An' ile baþlayanlar
Select * from Customers WHERE CompanyName LIKE 'An%'
--Þirket ismi son harf a olanlar
Select * from Customers Where CompanyName LIKE '%A'
--Þirket ismi tersten sýralý bir þekilde, içinde 'al' geçenler (sadece þirket isimleri gelsin)
Select CompanyName from Customers WHERE CompanyName LIKE '%al%' ORDER BY CompanyName DESC --veya ORDER BY 1 DESC, 1 CompanyName sütunua denk gelir
--þirket ismi ilk harfi ve son harfi a olanlar sadece þirket isimleri
Select CompanyName as [Þirket Ýsmi] from Customers WHERE CompanyName LIKE 'A%' AND CompanyName LIKE '%A'
--þirket ismi ilk harf a veya b olanlar sadece þirket ismi
SELECT CompanyName as [Þirket Ýsmi] from Customers WHERE CompanyName LIKE 'A%' OR CompanyName LIKE 'B%' 
--veya diðer syntax
SELECT CompanyName as [Þirket Ýsmi] from Customers WHERE CompanyName LIKE '[AB]%' 
--þirket isminde a veya r bulunanlar
SELECT CustomerID, CompanyName, ContactName, ContactTitle from Customers WHERE CompanyName LIKE '%[AR]%'
--veya
SELECT CustomerID, CompanyName, ContactName, ContactTitle from Customers WHERE CompanyName LIKE '%A%' or CompanyName LIKE '%R%'
--þirket ismi alfabetik sýrayla A-C aralýðýnda olanlar
SELECT * FROM Customers WHERE CompanyName LIKE '[A-C]%' ORDER BY CompanyName  
--veya
SELECT * FROM Customers WHERE CompanyName LIKE 'A%' OR CompanyName LIKE 'B%' OR CompanyName LIKE 'C%' ORDER BY CompanyName  
--ilk harf a olmayanlar
SELECT * FROM Customers WHERE CompanyName NOT LIKE 'A%' ORDER BY CompanyName 
--veya
SELECT * FROM Customers WHERE CompanyName LIKE '[^A]%' ORDER BY CompanyName 
--B ile bitmeyenler
SELECT * FROM Customers WHERE CompanyName NOT LIKE '%B' 
--veya
SELECT * FROM Customers WHERE CompanyName LIKE '%[^B]' 
--Ýlk harf a-c arasýnda olmayanlar
SELECT CompanyName FROM Customers WHERE CompanyName LIKE '[^A-C]%' ORDER BY CompanyName  --yani a,b,c harfle baþlayanlar olmaz
--veya
Select CompanyName FROM Customers WHERE CompanyName Not Like '[A-C]%' order by CompanyName
--ikinci harfi a veya b olmayanlar
Select CompanyName FROM Customers WHERE CompanyName Like '_[^AB]%' order by CompanyName  
-- Adýnýn ilk iki harfi LA, LN, AA veya AN olanlar
Select CompanyName From Customers Where CompanyName Like '[AB][LB]%' Order by CompanyName --ilk [] içi ilk harf a veya b, 2. [] kýsýmda 2. harf için l veya b
--yani þirket ismi AL, AB, BL, BB ile baþlayanlar anlamýna gelir.
-- ýçerisinde _ iþartei geçen isimlerin listelenmesi :
--Normalde '_' karakterinin özel bir anlamý vardýr ve tek bir karakter yerine geçer, ancak [] içinde belirttiðimizde sýradan bir karakter gibi aratýlabilir.
insert into Customers (CustomerID,CompanyName, ContactName) values ('DENEM','De_neme','vsvs')
SELECT CompanyName From Customers WHERE CompanyName like '%[_]%' --görüldüðü üzere De_neme gelir
SELECT CompanyName FROM Customers WHERE CompanyName LIKE '%\_%' ESCAPE '\'; --diðer syntaxý
-- Customers tablosundan CustomerID'sinin 2. harfi S, 4. harfi E olanlarýn %30'luk kýsmýný getiren sorguyu yazýnýz.
SELECT TOP 30 PERCENT CustomerID from Customers WHERE CustomerID like '_S_E%' 