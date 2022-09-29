--Northwind Employees table

--Ünvani Mr. veya Dr. olanlarin listelenmesi 
Select * from Employees WHERE TitleOfCourtesy = 'Mr.' OR TitleOfCourtesy = 'Dr.'
--

-- EmployeeID deðeri 5'ten büyük olanlarin isim ve soyisimlerinin listelenmesi
SELECT FirstName as Ýsim , LastName as Soyisim FROM Employees Where EmployeeID > 5
--

-- 1960 yilinda doðanlarin listelenmesi
SELECT * FROM Employees WHERE YEAR(Birthdate) = 1960
--

-- 1944 ile 1978 yillari arasinda doðanlarýn isim soyisim ve doðum tarihi
SELECT FirstName as Ýsim, LastName as Soyisim, BirthDate as [Doðum Tarihi] FROM Employees WHERE Year(BirthDate)>=1944 AND YEAR(Birthdate)<=1978
--

-- ingiltere'de oturan bayanlarin adi, soyadi, mesleði, ünvani, ülkesi ve doðum tarihini listeleyiniz (Employees)
select FirstName as Ýsim, LastName as Soyisim, Title as Meslek, TitleOfCourtesy as Ünvan, Country as Ülke, BirthDate as [Doðum Tarihi] from Employees WHERE 
Country = 'UK' AND TitleOfCourtesy = 'Ms.' OR TitleOfCourtesy='Mrs.'  
--

-- Ünvani Mr. olanlar veya yaþi 60'tan büyük olanlarin listelenmesi
SELECT FirstName as Ýsim, LastName as Soyisim, (Year(GetDate()) - Year(BirthDate)) as Yaþ, Title as Görev, TitleOfCourtesy as Ünvan
FROM EMPLOYEES WHERE TitleOfCourtesy  = 'Mr.' AND (Year(GetDate()) - Year(BirthDate)) > 60
--

-- Bölgesi belirtilmeyen çaliþanlarin listelenmesi yani null lar. isim ve soyisimleri null larda geldi onlarda null olanlar gelmesin fakat region null olan hepsi gelsin
Select FirstName, LastName, BirthDate, Title, TitleOfCourtesy, Region FROM Employees WHERE Region IS NULL AND FirstName IS NOT NULL AND LastName IS NOT NULL
--

-- Bölgesi belirtilen çaliþanlarin listelenmesi
Select FirstName, LastName, BirthDate, Title, Region from Employees WHERE Region IS NOT NULL AND FirstName IS NOT NULL AND LastName IS NOT NULL

--Kaç çeþit þehir var?
SELECT DISTINCT City from Employees 

--Ýsim soyisimler tek sütunda yazýlsýn ve 50 yaþ büyük erkekler getirilsin ve null olan veriler gelmesin
SELECT (FirstName + ' ' + LastName) as [Ýsim Soyisim], Birthdate as [Doðum Tarihi] , (Year(GetDate())-Year(Birthdate)) as [Yaþ] 
FROM Employees WHERE (Year(GetDate())-Year(Birthdate))>50 and FirstName IS NOT NULL and LastName is not null