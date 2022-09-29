--group by ile çapraz sorgular yapýlabilir, sözel olarak düþünülünce hangi markadan kaç adet satýldý, hangi hangi kategoriden ne kadar satýldý, gýda kategorisinde
--hangi markadan satýldý, ülker markasý gýda kategorisinde ne kadar satýldý gibi çapraz sorgularý group by komutuyla yapýlabilir

SELECT SUM(LINENETTOTAL) AS [TOPLAM SATIÞ], COUNT(*) AS [SATIR SAYISI], MIN(LINENETTOTAL) AS [EN DÜÞÜK SATIÞ], MAX(LINENETTOTAL) AS [EN YÜKSEK SATIÞ],
AVG(LINENETTOTAL) AS [ORTALAMA SATIÞ] FROM SALES where BRANCH = 'Ýstanbul Subesi'
--bu sadece istanbul subesi için oysa her branch için istiyoruz .böylece where þartýnda þöyle yazmayýz tek bir branch olurdu böyle

SELECT BRANCH, SUM(LINENETTOTAL) AS [TOPLAM SATIÞ], COUNT(*) AS [SATIR SAYISI], MIN(LINENETTOTAL) AS [EN DÜÞÜK SATIÞ], MAX(LINENETTOTAL) AS [EN YÜKSEK SATIÞ],
AVG(LINENETTOTAL) AS [ORTALAMA SATIÞ] FROM SALES GROUP BY BRANCH

--eðer selectten sonra branch yazýp o branch için aggregate fonksiyonlarý kullanýcaksak yani branchler içinse hata verir çünkü aggregate deðildir veya group by ile 
--kullanýlmýyodur. aggregate fonksiyýnlarý bütün branchlere uygulatmak için group by kullanýrýz. 


--en çok satýþ yapan þubeleri satýþlarýna göre sýralattýr
SELECT BRANCH as [ÞUBE ADI], COUNT(LINENETTOTAL) AS [TOPLAM SATIÞ MÝKTARI] FROM SALES  GROUP BY BRANCH ORDER BY COUNT(LINENETTOTAL) DESC

--en çok satýþ yapan 10 þube
SELECT TOP 10 BRANCH AS [ÞUBE ADI], COUNT(LINENETTOTAL) AS [TOPLAM SATIÞ MÝKTARI] FROM SALES GROUP BY BRANCH ORDER BY COUNT(LINENETTOTAL) DESC

--toplam satýþý 50.000 den büyük olan þubeler listele
--SELECT BRANCH AS [ÞUBE ADI], SUM(LINENETTOTAL) AS [TOPLAM SATIÞ MÝKTARI]  FROM SALES WHERE SUM(LINENETTTOTAL) > 50000 GROUP BY BRANCH
--GROUP BY YAPILAN FONKSÝYONU BÝR ÞEYE BAÐLANMAK ÝSTENÝRSE WHERE YERÝNE HAVÝNG KULLANILMALIDIR. HAVING GRUP BY DAN SONRA KULLANILIR
SELECT BRANCH AS [ÞUBE ADI], SUM(LINENETTOTAL) AS [TOPLAM SATIÞ MÝKTARI]  FROM SALES GROUP BY BRANCH HAVING SUM(LINENETTOTAL) > 50000 order by 2 desc
 
--maðazanýn gün bazlý satýþ satýþ rakamlarý 
SELECT BRANCH as [ÞUBE], DATE_ AS TARÝH, SUM(LINENETTOTAL) as [Toplam SATIÞ] FROM SALES WHERE BRANCH = 'Bursa Subesi' GROUP BY BRANCH,DATE_ 
order by DATE_

--- bursa þubesi 2017.01.05 tarihinde satýþý
SELECT BRANCH as [ÞUBE], DATE_ AS TARÝH, SUM(LINENETTOTAL) as [Toplam SATIÞ] FROM SALES WHERE BRANCH = 'Bursa Subesi' and DATE_='20170105' GROUP BY BRANCH,DATE_ 

 --tüm maðazalarýn günlük satýþý - 2017.01.05 tarihinde satýþý
SELECT BRANCH, DATE_, SUM(LINENETTOTAL) AS [TOPLAM SATIÞ] FROM SALES WHERE DATE_ = '20170105' GROUP BY BRANCH, DATE_ order by BRANCH

--ürün kategorilerine göre satýþ miktarý nullar gelmesin
select CATEGORY_NAME1, SUM(LINENETTOTAL) as [toplam satýþ] FROM SALES WHERE CATEGORY_NAME1 IS NOT NULL GROUP BY CATEGORY_NAME1 ORDER BY SUM(LINENETTOTAL) DESC

--ürün kategorilerinin markalarýna göre satýþ miktarý nullar gelmesin
select CATEGORY_NAME1, BRAND, SUM(LINENETTOTAL) as [toplam satýþ] FROM SALES WHERE CATEGORY_NAME1 IS NOT NULL and BRAND IS NOT NULL 
GROUP BY CATEGORY_NAME1,BRAND ORDER BY SUM(LINENETTOTAL) DESC

--gýda kategorisinin markalarýna göre satýþ miktarý nullar gelmesin
select CATEGORY_NAME1, BRAND, SUM(LINENETTOTAL) AS [TOPLAM SATIÞ] FROM SALES WHERE CATEGORY_NAME1 IS NOT NULL AND BRAND IS NOT NULL AND CATEGORY_NAME1 = 'GIDA'
GROUP BY CATEGORY_NAME1, BRAND ORDER BY SUM(LINENETTOTAL)  DESC

--markalarýn satýþý
select BRAND, SUM(LINENETTOTAL) AS [TOPLAM SATIÞ] FROM SALES WHERE BRAND IS NOT NULL
GROUP BY BRAND ORDER BY BRAND   

--hangi kategoride kaç çeþit marka
select CATEGORY_NAME1, COUNT(DISTINCT BRAND) AS [TOPLAM MARKA SAYISI] FROM SALES GROUP BY CATEGORY_NAME1 
--count satýr sayýsýný sayar, tekrar edenleri sayýdýrmamak için distinct 
--ülker, hangi kategoride kaç satýþ
select BRAND,  CATEGORY_NAME1, SUM(LINENETTOTAL) AS [TOPLAM SATIÞ] FROM SALES WHERE BRAND IS NOT NULL AND BRAND = 'ÜLKER'
GROUP BY BRAND, CATEGORY_NAME1  ORDER BY SUM(LINENETTOTAL)  desc

--ülker, hangi kategoride hangi alt kategoride kaç satýþ
select BRAND,  CATEGORY_NAME1, CATEGORY_NAME2 AS ALTKATEGORÝ, SUM(LINENETTOTAL) AS [TOPLAM SATIÞ] FROM SALES WHERE BRAND IS NOT NULL AND BRAND = 'ÜLKER'
GROUP BY BRAND, CATEGORY_NAME1, CATEGORY_NAME2  ORDER BY BRAND, CATEGORY_NAME1, CATEGORY_NAME2

--maðazalarýn müþteri sayýsý
SELECT BRANCH, COUNT(DISTINCT CLIENTNAME) as [Müþteri Sayýsý] FROM SALES GROUP BY BRANCH ORDER BY BRANCH 

DELETE FROM SALES WHERE CLIENTNAME = ''-- isim boþ olanlarý sildik

--müþterinin gittði maðaza sayýsý
select CLIENTNAME, COUNT(DISTINCT BRANCH) as [Gidilen Maðaza Sayýsý] FROM SALES where CLIENTNAME IS NOT NULL GROUP BY CLIENTNAME ORDER BY CLIENTNAME

--5 ten fazla maðazaya giden müþteriler 
--artýk aggregate oldugundan where þartýna deðil having e yazýlýr
select CLIENTNAME, COUNT(DISTINCT BRANCH) as [Gidilen Maðaza Sayýsý] from 
SALES WHERE CLIENTNAME IS NOT NULL GROUP BY CLIENTNAME HAVING COUNT(DISTINCT BRANCH)>5 order by CLIENTNAME

 