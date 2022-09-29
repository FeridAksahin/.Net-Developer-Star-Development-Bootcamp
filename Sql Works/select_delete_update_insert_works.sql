CREATE DATABASE WORKS02

CREATE TABLE CUSTOMER(
Id INT PRIMARY KEY IDENTITY(1,1), --Id isimli kolon açtýk int tipinde primary key yapýldý ve otomatik artan yani identity spec özelliði aktif edildi
[Name] VARCHAR(50) NOT NULL, --Name isimde bir kolon Name mavi olduðundan yani sql içinde olduðundan [] ile önüne geçildi
Surname VARCHAR(50) NOT NULL, --surname isimli kolon varchar tipinde, not null yani boþ geçilemez
Email VARCHAR(50) NOT NULL); 

/*
Select kullanýmý, 
Select kolonÝsmi from tabloAdý

eðer veritabanýnda deðilsek o sytax þöyle

select kolonÝsmi from dbAdý.dbo.tabloAdý
*/

Select Id,[Name],Surname,Email from CUSTOMER --Customer tablosundaki tüm kolonlarý çektik manuel olarak 

Select * from CUSTOMER  --tüm kolonlarý direk yýldýz ile çektik

--Eðer kolon isimlerinde türkçe karakter vs var ise sql server için sorun olan þeyler var ise  [ ] þeklinde içine yazýlýr kolon ismi
--mesela boþluklu kolon ismi var ise Ayrýlýs Tarihi gibi, bunu [] içinde yazýlmalý, yoksa Ayrýlýs'ý sadece tek baþýna bir kolon ismi görür. 

Select [Name], [Surname] from CUSTOMER --tabloda sadece name ve surname kolonlarýný getirildi

/*Insert kullanýmý
INSERT INTO TABLOADI (COLUMN1,COLUMN2..) VALUES (VALUE1,VALUE2)
*/
INSERT INTO CUSTOMER ([Name], [Surname], [Email]) values ('Ferid', 'Akþahin', 'vsvs@gmail.com') --ID kolonunu yazmayýz çünkü otomatik artan þeklinde o
insert into CUSTOMER ([Name], Surname, Email) values ('Selin','V','falanfilan@gmail.com')

--sqlde string ifadeler tek týrnak ile 
--TRUNCATE TABLE CUSTOMER     CUSTOMER tablosunun içini siler, ilk haline döndürür

/*
Update kullanýmý
UPDATE TABLOADI SET COLUMN1NAME = VALUE1, COLUMN2NAME=VALUE2..  
*/
 
ALTER TABLE CUSTOMER ADD Age int  --column constraint yani not null eklemeden alter table komunu ile customer tablosuna Age kolonu eklendi
--eðer not null isteseydik  ALTER TABLE CUSTOMER ADD Age int NOT NULL þeklinde yazýlýrdý.

--UPDATE CUSTOMER SET Age=35 WHERE Name='Selin' --Ýsmi Selin olanýn yaþýný 35 yaptýk

 ALTER TABLE CUSTOMER ADD Birthdate date

 UPDATE CUSTOMER SET Birthdate='1995-05-24' WHERE Name='Selin' --Selin'in doðum tarihini güncelledik, null idi
  UPDATE CUSTOMER SET Birthdate='1998-03-06' WHERE Name='Ferid'

  UPDATE CUSTOMER SET Age=DATEDIFF(YEAR,Birthdate,GETDATE()) 
  /*Direk bütün verilerin yaþýný güncelledik, SQL serverýn kendi fonksiyonlarý vardýr, tarih fonksiyonlarý, string fonksiyonlarý, birleþtirme fonksiyonlarý
  vs, bunlardan DATEDIFF isimli fonksiyonu kullandýk. fonksiyonu yazdýðýmýzdan paremetreler gözüküyor zaten verilebilcek
  ilk paremetre yýl hesaplayacaðýmýz için fark olarak görmek istedðimize YEAR girdik. ikinci olarak baþlangýç tarihi, 3. paremetre getdate metodunu çaðýrdýk
  o ise þuaný temsilen yani þimdiki tarih. bu update koduyla ageleri otomatik doðum taihine göre ayarlandý ve yazýldý tabloda.*/

  UPDATE CUSTOMER SET AGE = AGE +1 --YAÞLARI 1 ARTTIRDIK

  UPDATE CUSTOMER SET AGE = AGE-1

  --eðer seçmeden çalýþtýrýlýrsa tüm sayfa sýrayla çalýþýr sorgularda. seçerek çalýþtýrýlýrsa sorgu, o sorgu çalýþýr

  /*
  DELETE KOMUTU
  DELETE FROM TABLOADI - TABLODAKÝ TÜM KAYITLARI SÝLER
  */

  SELECT * INTO CUSTOMERBACKUP FROM CUSTOMER --BAÞKA BÝR TABLOYA KAYITLARI AKTARIR. CUSTOMER TABLOSUNDAKÝ TÜM VERÝLERÝ CUSTOMERBACKUP TABLOSUNA AKTARIR 
  --CUSTOMERBACKUP TABLOSUNUDA OTOMATÝKMAN AÇAR
  DELETE FROM CUSTOMER --CUSTOMER ÝÇÝNDEKÝ TÜM VERÝLER SÝLÝNDÝ
  SELECT * FROM CUSTOMER --CUSTOMER ÝÇÝ BOÞ ARTIK FAKAT MESELA YENÝ VERÝ EKLENDÝÐÝNDE ID 1 DEN BAÞLAMAZ, EN SON KAÇSA ORDAN +1 LE DEVAM EDER. 
  --EÐER ID SÝ DE 1 DEN BAÞLASIN ÝSTERSEK TRUNCATE TABLE KOMUTUNU UYGULARIZ. ID'LERÝDE 0 LAR.
  TRUNCATE TABLE CUSTOMER --CUSTOMER AÇILDIGI HALE DÖNDÜ
  SELECT * FROM CUSTOMERBACKUP 