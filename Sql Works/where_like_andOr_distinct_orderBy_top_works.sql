
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
INSERT INTO CUSTOMER ([Name], [Surname], [Email],  [Birthdate]) VALUES('Aslýhan', 'Falanfistan', 'aslýhan@gmail.com', '1997-05-24')
INSERT INTO CUSTOMER ([Name], [Surname], [Email], [Birthdate]) VALUES('Mehmet', 'Çalýþkan', 'mehmetcaliskan@gmail.com', '1997-05-24')
INSERT INTO CUSTOMER ([Name], [Surname], [Email],  [Birthdate]) VALUES('Sevgi', 'Çiçek','sevgicicek@hotmail.com','1997-05-24')
INSERT INTO CUSTOMER ([Name], [Surname], [Email],  [Birthdate]) VALUES('Ali', 'Altýn', 'alialtin@gmail.com', '1968-05-24')
INSERT INTO CUSTOMER ([Name], [Surname], [Email],  [Birthdate]) VALUES('Mustafa', 'Elmasçý', 'diamonder@gmail.com', '1985-05-24')
INSERT INTO CUSTOMER ([Name], [Surname], [Email],  [Birthdate]) VALUES('Ahmet', 'Temiz','ahmettemiz@gmail.com' ,'1998-05-24')

UPDATE CUSTOMER SET Age=DATEDIFF(YEAR,Birthdate,GETDATE())

UPDATE CUSTOMER SET City = 'Ýstanbul' WHERE Age = 25 --yaþý 25 olanlarýn þehrini Ýstanbul olarak güncelledik
UPDATE CUSTOMER SET City = 'Ankara' WHERE [Name] = 'Ali'
Update CUSTOMER set City = 'Ýzmir' Where [Name] = 'Mustafa'
UPDATE CUSTOMER SET City = 'Yozgat' Where [Name] = 'Ahmet'

--WHERE SYNTAX -> SELECT * FROM TABLENAME WHERE COLUMNNAME = VALUENAME, sadece select için geçerli deðil update ve delete içinde geçerlidir where komutu
/*
where þartlarý

=  mesela NAME = 'Aslýhan' gibi name Aslýhan olana bir sorgu iþlemi olur
<> -> eþit deðil , name <> 'Ferid' dendiði zaman Ferid 'den farklý olanlara bir iþlem olur
>  -> ayný
< 
>=
<=
BETWEEN -> arandýndadýr mesela dogum tarihi 1905 - 1965 tekilere bir iþlem olucaksa beetween
LIKE -> ile baþlar, ile biter, içerir . -> mesela Mehmet ile baþlayan lar için %Mehmet, ile biter Mehmet%, içerir %Mehmet% 	
IN -> içindedir mesela istanbul ankara içinde olanlar City IN 'Ýstanbul', 'Ankara' gibi

*/

SELECT * FROM CUSTOMER WHERE [Name] = 'Aslýhan' --CUSTOMER tablosundan ismi Aslýhan olaný sadece getirir
SELECT * FROM CUSTOMER WHERE Id = 3 --id si 3 olan
SELECT Surname FROM CUSTOMER WHERE [Name] = 'Aslýhan'  --ismi Aslýhan olanýn sadece surname ini getirir
Select * from CUSTOMER where City='Ýstanbul'  --þehir istanbul olan tüm verilerin, tüm verilerini getirir (* var çünkü) 
Select * from CUSTOMER where Birthdate = '1997-05-24'  --tarih formatlarýný tiresizde yazýlabilir
Select * from CUSTOMER where Birthdate = '19970524'  -- gibi ama 24.05.1997 ya da 24-05-1997 vs hata verir date formatýna dönüþteremz çünkü date formatý yýl-ay-gün dür

SELECT * from CUSTOMER WHERE City = 'Ýstanbul' and [Name] = 'Aslýhan' --þehri istanbul ve ismi Aslýhan olan

SELECT * from CUSTOMER WHERE City = 'Ýstanbul' and [Name] <> 'Aslýhan' --þehir istanbul ve ismi Aslýhan olmayan
SELECT * FROM CUSTOMER WHERE Age>25 --yaþý 25 ten büyük olanlar
SELECT * FROM CUSTOMER WHERE Age<25
SELECT * FROM CUSTOMER WHERE Age>=25
SELECT * FROM CUSTOMER WHERE Birthdate>='19970524'
SELECT * FROM CUSTOMER WHERE Age BETWEEN 20 AND 24 --yaþý 20-24 arasý olanlar
SELECT * FROM CUSTOMER WHERE Age BETWEEN 20 AND 55 -- aslýnda þunla ayný SELECT * FROM CUSTOMER WHERE Age>=20 AND Age<=55 and ile yapýlabilir daha kolay between

--LIKE --

Select * from CUSTOMER WHERE [Name] LIKE 'Aslýhan' -- like yerine = yazsakta ayný þuan ismi Aslýhan olaný getirir sadece
Insert into CUSTOMER ([Name], [Surname], Email, Birthdate, City) VALUES('Aslýhan', 'Kibritçi', 'özgekibritci@gmail.com', '19950512','Ýstanbul')
Delete from CUSTOMER where Id between 9 and 10
Update CUSTOMER Set [Name]='Aslýhan Yonca' Where Id=8
Update CUSTOMER set [Name] = 'Mehmet Ali' where [Name] = 'Mehmet' --ismi Mehmet olanlarýn ismini Mehmet Ali diye güncelledik
Select * from CUSTOMER WHERE [Name] LIKE 'Aslýhan%' --ismi Aslýhan ile baþyalanlarý getirir
Select * from CUSTOMER WHERE [Name] LIKE '%c%' --isminin içinde c geçen büyük C harfinide sayar
Select * from CUSTOMER WHERE [Name] LIKE '%a%' --isminin içinde a geçen büyük A harfinide sayar
Select * from CUSTOMER WHERE [Name] LIKE '%Ali%' --isim içerisinde Ali geçen
Select * from CUSTOMER WHERE [Name] LIKE '%A' --isim sonu A ile biten
Select * from CUSTOMER WHERE [Name] LIKE '%Yonca' --sonu Yonca ile biten

Select * from CUSTOMER

Select * From CUSTOMER where City ='Ýstanbul' and Age IN (25,27) --Ýstanbul þehrinde yaþý 25 ve 27 olanlar
Select * From CUSTOMER where City ='Ýstanbul' and Age not IN (25) --Ýstanbul þehrinde yaþý 25 olmyanlar
Select * From CUSTOMER where City ='Ýstanbul' and Age IN (25,27) and [Name] LIKE 'A%' --Ýstanbul þehrinde yaþý 25 ve 27 olanlar ve isim A veya a ile baþlayanlar

--Delete from Customer where [Name] like 'Aslýhan%' --ismi Aslýhan ile baþlayanlarý siler
UPDATE CUSTOMER SET [City] = 'Istanbul' Where City = 'Ýstanbul' --Þehir Ýstanbul olanlarý, Istanbul olarak güncelledik

/*
and operatorunda 2 þartta doðru olmalý
or da 1 i doðru olsa yeter. 2 si yanlýs olmamalý or da
*/

SELECT * FROM CUSTOMER WHERE City='Istanbul' and [Name] = 'Aslýhan' --ismi sadece Aslýhan olaný getirir
SELECT * FROM CUSTOMER WHERE City='Istanbul' and [Name] like 'Aslýhan%' -- ismi Aslýhan ile baþlayanlarý getirir
SELECT * FROM CUSTOMER WHERE City='Istanbul' or [Name] like 'Aslýhan%' --birleþim getirir hem þehri istanbul olanlar + ismi Aslýhan ile baþlayanlar
SELECT * FROM CUSTOMER WHERE City='Ferid' or [Name] like 'Aslýhan%' --or oldugundan 1. þart yanlýs olur ama 2. þartta ismi Aslýhan olanlar mevcut, isim Aslýhan ile baþlayanlarý getirir
--eðer and olsaydý hata verirdi çünkü and de iki þartta doðru olmalý
SELECT * FROM CUSTOMER WHERE City='Ferid' and [Name] like 'Aslýhan%' -- hiç biþi getirmez çünkü þartlardan Ferid yazýlan yanlýþtýr

/*
DISTINCT 
Distinct komutu tabloda mesela ismi Ahmet olan birsürü satýr var, distinct komutu 1 tane satýr getirir Ahmet için

SELECT DISTINCT COLUMN1, COLUMN2.. FROM TABLENAME
*/

Select City from CUSTOMER --verilerin þehir karþýlýklarý çýkýyor mesela 8 tane Istanbul gözüküyor, 8 verinin Istanbul mus
--Kaç tane þehir olduýgunu bulmak için distinct
SELECT DISTINCT City from Customer  --þimdi görüldüðü üzere 4 tane veri old çünkü her þehir için 1 tane yazdý distinct



/*
ORDER BY

Select Column1, Column2..
from TableName ORDER BY COLUMN1 ASC, COLUMN2 DESC
order by sýralama komutudur, select ile seçilen datalarý hangi sýrada görmek istiyorsak order by kullanýrýz

asc -> a'dan z'ye sýralamak
desc - > büyükten küçüðe sýralama

Select Column1, Column2..
from TableName ORDER BY COLUMN1 ASC, COLUMN2 DESC -> burada kolon1 e gere a'dan z'ye, kolon2'ye göre z'den a'ya bir sýralama var bu komutta
*/

SELECT * FROM CUSTOMER ORDER BY [NAME] --a'dan z'ye göre name'e göre sýraladýk ama þehirler sýrasýz þuan
SELECT * FROM CUSTOMER ORDER BY [Name], City --ilk isme göre sonra þehre göre sýralama. önce isim sýralamasý sonra þehir sýralamasý. aslýnda sadece isim sýralamasýyla
--aynýdýr çünkü isim sýralamsýndan sonra þehirler içni yer deðiþtirirse isim sýralamsý olmaz.
SELECT * FROM CUSTOMER ORDER BY City,[Name] --önce þehir sýralamasý sonra ortak þehirleri olanlarda isim sýralamasý
--eðer hiç birþey yazmazsak otomatikman ASC yani a'dan z'yedir. eðer z'den a 'ya istiyorsak desc yazmalýyýz
SELECT * FROM CUSTOMER ORDER BY City DESC --z'den a'ya sýralama
SELECT * FROM CUSTOMER ORDER BY City DESC,[Name] ASC --önce tersten þehir sýralamasý sonra ortak þehirlerde a'dan z'ye isim sýralamasý

--orderby diðer kullanýmý

SELECT * FROM CUSTOMER ORDER BY 2 --name kolonu 2. sýrada yani 2 yazarsak name e göre sýralar.
SELECT * FROM CUSTOMER ORDER BY 7,2 --SELECT * FROM CUSTOMER ORDER BY City,[Name] ile ayný


/*
TOP
belli bir sayý kadar döndürmedir.
Select TOP IN COLUMN1, COLUMN2.. 
FROM TABLENAME ORDER BY COLUMN1 ASC, COLUMN2 DESC
*/

Select TOP 2 * FROM CUSTOMER --CUSTOMER tablosundan ilk iki kayýdý döndürme

Select TOP 2 * FROM CUSTOMER ORDER BY [NAME] --name e göre sýralanmýs customer tablosunun ilk iki satýrý.

Select TOP 2 * FROM CUSTOMER WHERE City = 'Istanbul' ORDER BY [NAME] --[NAME] e göre sýralanmýs customer tablosunun ilk iki satýrý ve þehri Istanbul olanlar
Select TOP 50 PERCENT * FROM CUSTOMER ORDER BY [NAME] DESC --[NAME] göre tersten sýralanmýs customer tablosunun yüzde 50 sini getirir 
