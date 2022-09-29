--Northwind Employees table

--�nvani Mr. veya Dr. olanlarin listelenmesi 
Select * from Employees WHERE TitleOfCourtesy = 'Mr.' OR TitleOfCourtesy = 'Dr.'
--

-- EmployeeID de�eri 5'ten b�y�k olanlarin isim ve soyisimlerinin listelenmesi
SELECT FirstName as �sim , LastName as Soyisim FROM Employees Where EmployeeID > 5
--

-- 1960 yilinda do�anlarin listelenmesi
SELECT * FROM Employees WHERE YEAR(Birthdate) = 1960
--

-- 1944 ile 1978 yillari arasinda do�anlar�n isim soyisim ve do�um tarihi
SELECT FirstName as �sim, LastName as Soyisim, BirthDate as [Do�um Tarihi] FROM Employees WHERE Year(BirthDate)>=1944 AND YEAR(Birthdate)<=1978
--

-- ingiltere'de oturan bayanlarin adi, soyadi, mesle�i, �nvani, �lkesi ve do�um tarihini listeleyiniz (Employees)
select FirstName as �sim, LastName as Soyisim, Title as Meslek, TitleOfCourtesy as �nvan, Country as �lke, BirthDate as [Do�um Tarihi] from Employees WHERE 
Country = 'UK' AND TitleOfCourtesy = 'Ms.' OR TitleOfCourtesy='Mrs.'  
--

-- �nvani Mr. olanlar veya ya�i 60'tan b�y�k olanlarin listelenmesi
SELECT FirstName as �sim, LastName as Soyisim, (Year(GetDate()) - Year(BirthDate)) as Ya�, Title as G�rev, TitleOfCourtesy as �nvan
FROM EMPLOYEES WHERE TitleOfCourtesy  = 'Mr.' AND (Year(GetDate()) - Year(BirthDate)) > 60
--

-- B�lgesi belirtilmeyen �ali�anlarin listelenmesi yani null lar. isim ve soyisimleri null larda geldi onlarda null olanlar gelmesin fakat region null olan hepsi gelsin
Select FirstName, LastName, BirthDate, Title, TitleOfCourtesy, Region FROM Employees WHERE Region IS NULL AND FirstName IS NOT NULL AND LastName IS NOT NULL
--

-- B�lgesi belirtilen �ali�anlarin listelenmesi
Select FirstName, LastName, BirthDate, Title, Region from Employees WHERE Region IS NOT NULL AND FirstName IS NOT NULL AND LastName IS NOT NULL

--Ka� �e�it �ehir var?
SELECT DISTINCT City from Employees 

--�sim soyisimler tek s�tunda yaz�ls�n ve 50 ya� b�y�k erkekler getirilsin ve null olan veriler gelmesin
SELECT (FirstName + ' ' + LastName) as [�sim Soyisim], Birthdate as [Do�um Tarihi] , (Year(GetDate())-Year(Birthdate)) as [Ya�] 
FROM Employees WHERE (Year(GetDate())-Year(Birthdate))>50 and FirstName IS NOT NULL and LastName is not null