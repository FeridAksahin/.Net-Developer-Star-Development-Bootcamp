CREATE DATABASE WORKS02

CREATE TABLE CUSTOMER(
Id INT PRIMARY KEY IDENTITY(1,1), --Id isimli kolon a�t�k int tipinde primary key yap�ld� ve otomatik artan yani identity spec �zelli�i aktif edildi
[Name] VARCHAR(50) NOT NULL, --Name isimde bir kolon Name mavi oldu�undan yani sql i�inde oldu�undan [] ile �n�ne ge�ildi
Surname VARCHAR(50) NOT NULL, --surname isimli kolon varchar tipinde, not null yani bo� ge�ilemez
Email VARCHAR(50) NOT NULL); 

/*
Select kullan�m�, 
Select kolon�smi from tabloAd�

e�er veritaban�nda de�ilsek o sytax ��yle

select kolon�smi from dbAd�.dbo.tabloAd�
*/

Select Id,[Name],Surname,Email from CUSTOMER --Customer tablosundaki t�m kolonlar� �ektik manuel olarak 

Select * from CUSTOMER  --t�m kolonlar� direk y�ld�z ile �ektik

--E�er kolon isimlerinde t�rk�e karakter vs var ise sql server i�in sorun olan �eyler var ise  [ ] �eklinde i�ine yaz�l�r kolon ismi
--mesela bo�luklu kolon ismi var ise Ayr�l�s Tarihi gibi, bunu [] i�inde yaz�lmal�, yoksa Ayr�l�s'� sadece tek ba��na bir kolon ismi g�r�r. 

Select [Name], [Surname] from CUSTOMER --tabloda sadece name ve surname kolonlar�n� getirildi

/*Insert kullan�m�
INSERT INTO TABLOADI (COLUMN1,COLUMN2..) VALUES (VALUE1,VALUE2)
*/
INSERT INTO CUSTOMER ([Name], [Surname], [Email]) values ('Ferid', 'Ak�ahin', 'vsvs@gmail.com') --ID kolonunu yazmay�z ��nk� otomatik artan �eklinde o
insert into CUSTOMER ([Name], Surname, Email) values ('Selin','V','falanfilan@gmail.com')

--sqlde string ifadeler tek t�rnak ile 
--TRUNCATE TABLE CUSTOMER     CUSTOMER tablosunun i�ini siler, ilk haline d�nd�r�r

/*
Update kullan�m�
UPDATE TABLOADI SET COLUMN1NAME = VALUE1, COLUMN2NAME=VALUE2..  
*/
 
ALTER TABLE CUSTOMER ADD Age int  --column constraint yani not null eklemeden alter table komunu ile customer tablosuna Age kolonu eklendi
--e�er not null isteseydik  ALTER TABLE CUSTOMER ADD Age int NOT NULL �eklinde yaz�l�rd�.

--UPDATE CUSTOMER SET Age=35 WHERE Name='Selin' --�smi Selin olan�n ya��n� 35 yapt�k

 ALTER TABLE CUSTOMER ADD Birthdate date

 UPDATE CUSTOMER SET Birthdate='1995-05-24' WHERE Name='Selin' --Selin'in do�um tarihini g�ncelledik, null idi
  UPDATE CUSTOMER SET Birthdate='1998-03-06' WHERE Name='Ferid'

  UPDATE CUSTOMER SET Age=DATEDIFF(YEAR,Birthdate,GETDATE()) 
  /*Direk b�t�n verilerin ya��n� g�ncelledik, SQL server�n kendi fonksiyonlar� vard�r, tarih fonksiyonlar�, string fonksiyonlar�, birle�tirme fonksiyonlar�
  vs, bunlardan DATEDIFF isimli fonksiyonu kulland�k. fonksiyonu yazd���m�zdan paremetreler g�z�k�yor zaten verilebilcek
  ilk paremetre y�l hesaplayaca��m�z i�in fark olarak g�rmek isted�imize YEAR girdik. ikinci olarak ba�lang�� tarihi, 3. paremetre getdate metodunu �a��rd�k
  o ise �uan� temsilen yani �imdiki tarih. bu update koduyla ageleri otomatik do�um taihine g�re ayarland� ve yaz�ld� tabloda.*/

  UPDATE CUSTOMER SET AGE = AGE +1 --YA�LARI 1 ARTTIRDIK

  UPDATE CUSTOMER SET AGE = AGE-1

  --e�er se�meden �al��t�r�l�rsa t�m sayfa s�rayla �al���r sorgularda. se�erek �al��t�r�l�rsa sorgu, o sorgu �al���r

  /*
  DELETE KOMUTU
  DELETE FROM TABLOADI - TABLODAK� T�M KAYITLARI S�LER
  */

  SELECT * INTO CUSTOMERBACKUP FROM CUSTOMER --BA�KA B�R TABLOYA KAYITLARI AKTARIR. CUSTOMER TABLOSUNDAK� T�M VER�LER� CUSTOMERBACKUP TABLOSUNA AKTARIR 
  --CUSTOMERBACKUP TABLOSUNUDA OTOMAT�KMAN A�AR
  DELETE FROM CUSTOMER --CUSTOMER ���NDEK� T�M VER�LER S�L�ND�
  SELECT * FROM CUSTOMER --CUSTOMER ��� BO� ARTIK FAKAT MESELA YEN� VER� EKLEND���NDE ID 1 DEN BA�LAMAZ, EN SON KA�SA ORDAN +1 LE DEVAM EDER. 
  --E�ER ID S� DE 1 DEN BA�LASIN �STERSEK TRUNCATE TABLE KOMUTUNU UYGULARIZ. ID'LER�DE 0 LAR.
  TRUNCATE TABLE CUSTOMER --CUSTOMER A�ILDIGI HALE D�ND�
  SELECT * FROM CUSTOMERBACKUP 