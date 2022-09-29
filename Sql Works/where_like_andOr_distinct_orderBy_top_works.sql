
CREATE TABLE CUSTOMER(
Id INT PRIMARY KEY IDENTITY(1,1),  
[Name] VARCHAR(50) NOT NULL,  
Surname VARCHAR(50) NOT NULL, 
Email VARCHAR(50) NOT NULL); 

ALTER TABLE CUSTOMER ADD Birthdate date
ALTER TABLE CUSTOMER ADD Age int
ALTER TABLE CUSTOMER ADD City varchar(50)

SELECT * FROM CUSTOMER
truncate table CUSTOMER
INSERT INTO CUSTOMER ([Name], [Surname], [Email],  [Birthdate]) VALUES('Asl�han', 'Falanfistan', 'asl�han@gmail.com', '1997-05-24')
INSERT INTO CUSTOMER ([Name], [Surname], [Email], [Birthdate]) VALUES('Mehmet', '�al��kan', 'mehmetcaliskan@gmail.com', '1997-05-24')
INSERT INTO CUSTOMER ([Name], [Surname], [Email],  [Birthdate]) VALUES('Sevgi', '�i�ek','sevgicicek@hotmail.com','1997-05-24')
INSERT INTO CUSTOMER ([Name], [Surname], [Email],  [Birthdate]) VALUES('Ali', 'Alt�n', 'alialtin@gmail.com', '1968-05-24')
INSERT INTO CUSTOMER ([Name], [Surname], [Email],  [Birthdate]) VALUES('Mustafa', 'Elmas��', 'diamonder@gmail.com', '1985-05-24')
INSERT INTO CUSTOMER ([Name], [Surname], [Email],  [Birthdate]) VALUES('Ahmet', 'Temiz','ahmettemiz@gmail.com' ,'1998-05-24')

UPDATE CUSTOMER SET Age=DATEDIFF(YEAR,Birthdate,GETDATE())

UPDATE CUSTOMER SET City = '�stanbul' WHERE Age = 25 --ya�� 25 olanlar�n �ehrini �stanbul olarak g�ncelledik
UPDATE CUSTOMER SET City = 'Ankara' WHERE [Name] = 'Ali'
Update CUSTOMER set City = '�zmir' Where [Name] = 'Mustafa'
UPDATE CUSTOMER SET City = 'Yozgat' Where [Name] = 'Ahmet'

--WHERE SYNTAX -> SELECT * FROM TABLENAME WHERE COLUMNNAME = VALUENAME, sadece select i�in ge�erli de�il update ve delete i�inde ge�erlidir where komutu
/*
where �artlar�

=  mesela NAME = 'Asl�han' gibi name Asl�han olana bir sorgu i�lemi olur
<> -> e�it de�il , name <> 'Ferid' dendi�i zaman Ferid 'den farkl� olanlara bir i�lem olur
>  -> ayn�
< 
>=
<=
BETWEEN -> arand�ndad�r mesela dogum tarihi 1905 - 1965 tekilere bir i�lem olucaksa beetween
LIKE -> ile ba�lar, ile biter, i�erir . -> mesela Mehmet ile ba�layan lar i�in %Mehmet, ile biter Mehmet%, i�erir %Mehmet% 	
IN -> i�indedir mesela istanbul ankara i�inde olanlar City IN '�stanbul', 'Ankara' gibi

*/

SELECT * FROM CUSTOMER WHERE [Name] = 'Asl�han' --CUSTOMER tablosundan ismi Asl�han olan� sadece getirir
SELECT * FROM CUSTOMER WHERE Id = 3 --id si 3 olan
SELECT Surname FROM CUSTOMER WHERE [Name] = 'Asl�han'  --ismi Asl�han olan�n sadece surname ini getirir
Select * from CUSTOMER where City='�stanbul'  --�ehir istanbul olan t�m verilerin, t�m verilerini getirir (* var ��nk�) 
Select * from CUSTOMER where Birthdate = '1997-05-24'  --tarih formatlar�n� tiresizde yaz�labilir
Select * from CUSTOMER where Birthdate = '19970524'  -- gibi ama 24.05.1997 ya da 24-05-1997 vs hata verir date format�na d�n��teremz ��nk� date format� y�l-ay-g�n d�r

SELECT * from CUSTOMER WHERE City = '�stanbul' and [Name] = 'Asl�han' --�ehri istanbul ve ismi Asl�han olan

SELECT * from CUSTOMER WHERE City = '�stanbul' and [Name] <> 'Asl�han' --�ehir istanbul ve ismi Asl�han olmayan
SELECT * FROM CUSTOMER WHERE Age>25 --ya�� 25 ten b�y�k olanlar
SELECT * FROM CUSTOMER WHERE Age<25
SELECT * FROM CUSTOMER WHERE Age>=25
SELECT * FROM CUSTOMER WHERE Birthdate>='19970524'
SELECT * FROM CUSTOMER WHERE Age BETWEEN 20 AND 24 --ya�� 20-24 aras� olanlar
SELECT * FROM CUSTOMER WHERE Age BETWEEN 20 AND 55 -- asl�nda �unla ayn� SELECT * FROM CUSTOMER WHERE Age>=20 AND Age<=55 and ile yap�labilir daha kolay between

--LIKE --

Select * from CUSTOMER WHERE [Name] LIKE 'Asl�han' -- like yerine = yazsakta ayn� �uan ismi Asl�han olan� getirir sadece
Insert into CUSTOMER ([Name], [Surname], Email, Birthdate, City) VALUES('Asl�han', 'Kibrit�i', '�zgekibritci@gmail.com', '19950512','�stanbul')
Delete from CUSTOMER where Id between 9 and 10
Update CUSTOMER Set [Name]='Asl�han Yonca' Where Id=8
Update CUSTOMER set [Name] = 'Mehmet Ali' where [Name] = 'Mehmet' --ismi Mehmet olanlar�n ismini Mehmet Ali diye g�ncelledik
Select * from CUSTOMER WHERE [Name] LIKE 'Asl�han%' --ismi Asl�han ile ba�yalanlar� getirir
Select * from CUSTOMER WHERE [Name] LIKE '%c%' --isminin i�inde c ge�en b�y�k C harfinide sayar
Select * from CUSTOMER WHERE [Name] LIKE '%a%' --isminin i�inde a ge�en b�y�k A harfinide sayar
Select * from CUSTOMER WHERE [Name] LIKE '%Ali%' --isim i�erisinde Ali ge�en
Select * from CUSTOMER WHERE [Name] LIKE '%A' --isim sonu A ile biten
Select * from CUSTOMER WHERE [Name] LIKE '%Yonca' --sonu Yonca ile biten

Select * from CUSTOMER

Select * From CUSTOMER where City ='�stanbul' and Age IN (25,27) --�stanbul �ehrinde ya�� 25 ve 27 olanlar
Select * From CUSTOMER where City ='�stanbul' and Age not IN (25) --�stanbul �ehrinde ya�� 25 olmyanlar
Select * From CUSTOMER where City ='�stanbul' and Age IN (25,27) and [Name] LIKE 'A%' --�stanbul �ehrinde ya�� 25 ve 27 olanlar ve isim A veya a ile ba�layanlar

--Delete from Customer where [Name] like 'Asl�han%' --ismi Asl�han ile ba�layanlar� siler
UPDATE CUSTOMER SET [City] = 'Istanbul' Where City = '�stanbul' --�ehir �stanbul olanlar�, Istanbul olarak g�ncelledik

/*
and operatorunda 2 �artta do�ru olmal�
or da 1 i do�ru olsa yeter. 2 si yanl�s olmamal� or da
*/

SELECT * FROM CUSTOMER WHERE City='Istanbul' and [Name] = 'Asl�han' --ismi sadece Asl�han olan� getirir
SELECT * FROM CUSTOMER WHERE City='Istanbul' and [Name] like 'Asl�han%' -- ismi Asl�han ile ba�layanlar� getirir
SELECT * FROM CUSTOMER WHERE City='Istanbul' or [Name] like 'Asl�han%' --birle�im getirir hem �ehri istanbul olanlar + ismi Asl�han ile ba�layanlar
SELECT * FROM CUSTOMER WHERE City='Ferid' or [Name] like 'Asl�han%' --or oldugundan 1. �art yanl�s olur ama 2. �artta ismi Asl�han olanlar mevcut, isim Asl�han ile ba�layanlar� getirir
--e�er and olsayd� hata verirdi ��nk� and de iki �artta do�ru olmal�
SELECT * FROM CUSTOMER WHERE City='Ferid' and [Name] like 'Asl�han%' -- hi� bi�i getirmez ��nk� �artlardan Ferid yaz�lan yanl��t�r

/*
DISTINCT 
Distinct komutu tabloda mesela ismi Ahmet olan birs�r� sat�r var, distinct komutu 1 tane sat�r getirir Ahmet i�in

SELECT DISTINCT COLUMN1, COLUMN2.. FROM TABLENAME
*/

Select City from CUSTOMER --verilerin �ehir kar��l�klar� ��k�yor mesela 8 tane Istanbul g�z�k�yor, 8 verinin Istanbul mus
--Ka� tane �ehir oldu�gunu bulmak i�in distinct
SELECT DISTINCT City from Customer  --�imdi g�r�ld��� �zere 4 tane veri old ��nk� her �ehir i�in 1 tane yazd� distinct



/*
ORDER BY

Select Column1, Column2..
from TableName ORDER BY COLUMN1 ASC, COLUMN2 DESC
order by s�ralama komutudur, select ile se�ilen datalar� hangi s�rada g�rmek istiyorsak order by kullan�r�z

asc -> a'dan z'ye s�ralamak
desc - > b�y�kten k����e s�ralama

Select Column1, Column2..
from TableName ORDER BY COLUMN1 ASC, COLUMN2 DESC -> burada kolon1 e gere a'dan z'ye, kolon2'ye g�re z'den a'ya bir s�ralama var bu komutta
*/

SELECT * FROM CUSTOMER ORDER BY [NAME] --a'dan z'ye g�re name'e g�re s�ralad�k ama �ehirler s�ras�z �uan
SELECT * FROM CUSTOMER ORDER BY [Name], City --ilk isme g�re sonra �ehre g�re s�ralama. �nce isim s�ralamas� sonra �ehir s�ralamas�. asl�nda sadece isim s�ralamas�yla
--ayn�d�r ��nk� isim s�ralams�ndan sonra �ehirler i�ni yer de�i�tirirse isim s�ralams� olmaz.
SELECT * FROM CUSTOMER ORDER BY City,[Name] --�nce �ehir s�ralamas� sonra ortak �ehirleri olanlarda isim s�ralamas�
--e�er hi� bir�ey yazmazsak otomatikman ASC yani a'dan z'yedir. e�er z'den a 'ya istiyorsak desc yazmal�y�z
SELECT * FROM CUSTOMER ORDER BY City DESC --z'den a'ya s�ralama
SELECT * FROM CUSTOMER ORDER BY City DESC,[Name] ASC --�nce tersten �ehir s�ralamas� sonra ortak �ehirlerde a'dan z'ye isim s�ralamas�

--orderby di�er kullan�m�

SELECT * FROM CUSTOMER ORDER BY 2 --name kolonu 2. s�rada yani 2 yazarsak name e g�re s�ralar.
SELECT * FROM CUSTOMER ORDER BY 7,2 --SELECT * FROM CUSTOMER ORDER BY City,[Name] ile ayn�


/*
TOP
belli bir say� kadar d�nd�rmedir.
Select TOP IN COLUMN1, COLUMN2.. 
FROM TABLENAME ORDER BY COLUMN1 ASC, COLUMN2 DESC
*/

Select TOP 2 * FROM CUSTOMER --CUSTOMER tablosundan ilk iki kay�d� d�nd�rme

Select TOP 2 * FROM CUSTOMER ORDER BY [NAME] --name e g�re s�ralanm�s customer tablosunun ilk iki sat�r�.

Select TOP 2 * FROM CUSTOMER WHERE City = 'Istanbul' ORDER BY [NAME] --[NAME] e g�re s�ralanm�s customer tablosunun ilk iki sat�r� ve �ehri Istanbul olanlar
Select TOP 50 PERCENT * FROM CUSTOMER ORDER BY [NAME] DESC --[NAME] g�re tersten s�ralanm�s customer tablosunun y�zde 50 sini getirir 
