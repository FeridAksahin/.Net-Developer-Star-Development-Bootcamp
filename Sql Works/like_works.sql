 
use Northwind

Select * from Employees

DELETE FROM Employees Where FirstName is null and LastName is null

Select * from Customers

--ilk harfi A ile ba�layan �irketler
Select * from Customers Where CompanyName LIKE 'A%' 
--'An' ile ba�layanlar
Select * from Customers WHERE CompanyName LIKE 'An%'
--�irket ismi son harf a olanlar
Select * from Customers Where CompanyName LIKE '%A'
--�irket ismi tersten s�ral� bir �ekilde, i�inde 'al' ge�enler (sadece �irket isimleri gelsin)
Select CompanyName from Customers WHERE CompanyName LIKE '%al%' ORDER BY CompanyName DESC --veya ORDER BY 1 DESC, 1 CompanyName s�tunua denk gelir
--�irket ismi ilk harfi ve son harfi a olanlar sadece �irket isimleri
Select CompanyName as [�irket �smi] from Customers WHERE CompanyName LIKE 'A%' AND CompanyName LIKE '%A'
--�irket ismi ilk harf a veya b olanlar sadece �irket ismi
SELECT CompanyName as [�irket �smi] from Customers WHERE CompanyName LIKE 'A%' OR CompanyName LIKE 'B%' 
--veya di�er syntax
SELECT CompanyName as [�irket �smi] from Customers WHERE CompanyName LIKE '[AB]%' 
--�irket isminde a veya r bulunanlar
SELECT CustomerID, CompanyName, ContactName, ContactTitle from Customers WHERE CompanyName LIKE '%[AR]%'
--veya
SELECT CustomerID, CompanyName, ContactName, ContactTitle from Customers WHERE CompanyName LIKE '%A%' or CompanyName LIKE '%R%'
--�irket ismi alfabetik s�rayla A-C aral���nda olanlar
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
--�lk harf a-c aras�nda olmayanlar
SELECT CompanyName FROM Customers WHERE CompanyName LIKE '[^A-C]%' ORDER BY CompanyName  --yani a,b,c harfle ba�layanlar olmaz
--veya
Select CompanyName FROM Customers WHERE CompanyName Not Like '[A-C]%' order by CompanyName
--ikinci harfi a veya b olmayanlar
Select CompanyName FROM Customers WHERE CompanyName Like '_[^AB]%' order by CompanyName  
-- Ad�n�n ilk iki harfi LA, LN, AA veya AN olanlar
Select CompanyName From Customers Where CompanyName Like '[AB][LB]%' Order by CompanyName --ilk [] i�i ilk harf a veya b, 2. [] k�s�mda 2. harf i�in l veya b
--yani �irket ismi AL, AB, BL, BB ile ba�layanlar anlam�na gelir.
-- ��erisinde _ i�artei ge�en isimlerin listelenmesi :
--Normalde '_' karakterinin �zel bir anlam� vard�r ve tek bir karakter yerine ge�er, ancak [] i�inde belirtti�imizde s�radan bir karakter gibi arat�labilir.
insert into Customers (CustomerID,CompanyName, ContactName) values ('DENEM','De_neme','vsvs')
SELECT CompanyName From Customers WHERE CompanyName like '%[_]%' --g�r�ld��� �zere De_neme gelir
SELECT CompanyName FROM Customers WHERE CompanyName LIKE '%\_%' ESCAPE '\'; --di�er syntax�
-- Customers tablosundan CustomerID'sinin 2. harfi S, 4. harfi E olanlar�n %30'luk k�sm�n� getiren sorguyu yaz�n�z.
SELECT TOP 30 PERCENT CustomerID from Customers WHERE CustomerID like '_S_E%' 