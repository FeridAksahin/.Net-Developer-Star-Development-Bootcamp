--group by ile �apraz sorgular yap�labilir, s�zel olarak d���n�l�nce hangi markadan ka� adet sat�ld�, hangi hangi kategoriden ne kadar sat�ld�, g�da kategorisinde
--hangi markadan sat�ld�, �lker markas� g�da kategorisinde ne kadar sat�ld� gibi �apraz sorgular� group by komutuyla yap�labilir

SELECT SUM(LINENETTOTAL) AS [TOPLAM SATI�], COUNT(*) AS [SATIR SAYISI], MIN(LINENETTOTAL) AS [EN D���K SATI�], MAX(LINENETTOTAL) AS [EN Y�KSEK SATI�],
AVG(LINENETTOTAL) AS [ORTALAMA SATI�] FROM SALES where BRANCH = '�stanbul Subesi'
--bu sadece istanbul subesi i�in oysa her branch i�in istiyoruz .b�ylece where �art�nda ��yle yazmay�z tek bir branch olurdu b�yle

SELECT BRANCH, SUM(LINENETTOTAL) AS [TOPLAM SATI�], COUNT(*) AS [SATIR SAYISI], MIN(LINENETTOTAL) AS [EN D���K SATI�], MAX(LINENETTOTAL) AS [EN Y�KSEK SATI�],
AVG(LINENETTOTAL) AS [ORTALAMA SATI�] FROM SALES GROUP BY BRANCH

--e�er selectten sonra branch yaz�p o branch i�in aggregate fonksiyonlar� kullan�caksak yani branchler i�inse hata verir ��nk� aggregate de�ildir veya group by ile 
--kullan�lm�yodur. aggregate fonksiy�nlar� b�t�n branchlere uygulatmak i�in group by kullan�r�z. 


--en �ok sat�� yapan �ubeleri sat��lar�na g�re s�ralatt�r
SELECT BRANCH as [�UBE ADI], COUNT(LINENETTOTAL) AS [TOPLAM SATI� M�KTARI] FROM SALES  GROUP BY BRANCH ORDER BY COUNT(LINENETTOTAL) DESC

--en �ok sat�� yapan 10 �ube
SELECT TOP 10 BRANCH AS [�UBE ADI], COUNT(LINENETTOTAL) AS [TOPLAM SATI� M�KTARI] FROM SALES GROUP BY BRANCH ORDER BY COUNT(LINENETTOTAL) DESC

--toplam sat��� 50.000 den b�y�k olan �ubeler listele
--SELECT BRANCH AS [�UBE ADI], SUM(LINENETTOTAL) AS [TOPLAM SATI� M�KTARI]  FROM SALES WHERE SUM(LINENETTTOTAL) > 50000 GROUP BY BRANCH
--GROUP BY YAPILAN FONKS�YONU B�R �EYE BA�LANMAK �STEN�RSE WHERE YER�NE HAV�NG KULLANILMALIDIR. HAVING GRUP BY DAN SONRA KULLANILIR
SELECT BRANCH AS [�UBE ADI], SUM(LINENETTOTAL) AS [TOPLAM SATI� M�KTARI]  FROM SALES GROUP BY BRANCH HAVING SUM(LINENETTOTAL) > 50000 order by 2 desc
 
--ma�azan�n g�n bazl� sat�� sat�� rakamlar� 
SELECT BRANCH as [�UBE], DATE_ AS TAR�H, SUM(LINENETTOTAL) as [Toplam SATI�] FROM SALES WHERE BRANCH = 'Bursa Subesi' GROUP BY BRANCH,DATE_ 
order by DATE_

--- bursa �ubesi 2017.01.05 tarihinde sat���
SELECT BRANCH as [�UBE], DATE_ AS TAR�H, SUM(LINENETTOTAL) as [Toplam SATI�] FROM SALES WHERE BRANCH = 'Bursa Subesi' and DATE_='20170105' GROUP BY BRANCH,DATE_ 

 --t�m ma�azalar�n g�nl�k sat��� - 2017.01.05 tarihinde sat���
SELECT BRANCH, DATE_, SUM(LINENETTOTAL) AS [TOPLAM SATI�] FROM SALES WHERE DATE_ = '20170105' GROUP BY BRANCH, DATE_ order by BRANCH

--�r�n kategorilerine g�re sat�� miktar� nullar gelmesin
select CATEGORY_NAME1, SUM(LINENETTOTAL) as [toplam sat��] FROM SALES WHERE CATEGORY_NAME1 IS NOT NULL GROUP BY CATEGORY_NAME1 ORDER BY SUM(LINENETTOTAL) DESC

--�r�n kategorilerinin markalar�na g�re sat�� miktar� nullar gelmesin
select CATEGORY_NAME1, BRAND, SUM(LINENETTOTAL) as [toplam sat��] FROM SALES WHERE CATEGORY_NAME1 IS NOT NULL and BRAND IS NOT NULL 
GROUP BY CATEGORY_NAME1,BRAND ORDER BY SUM(LINENETTOTAL) DESC

--g�da kategorisinin markalar�na g�re sat�� miktar� nullar gelmesin
select CATEGORY_NAME1, BRAND, SUM(LINENETTOTAL) AS [TOPLAM SATI�] FROM SALES WHERE CATEGORY_NAME1 IS NOT NULL AND BRAND IS NOT NULL AND CATEGORY_NAME1 = 'GIDA'
GROUP BY CATEGORY_NAME1, BRAND ORDER BY SUM(LINENETTOTAL)  DESC

--markalar�n sat���
select BRAND, SUM(LINENETTOTAL) AS [TOPLAM SATI�] FROM SALES WHERE BRAND IS NOT NULL
GROUP BY BRAND ORDER BY BRAND   

--hangi kategoride ka� �e�it marka
select CATEGORY_NAME1, COUNT(DISTINCT BRAND) AS [TOPLAM MARKA SAYISI] FROM SALES GROUP BY CATEGORY_NAME1 
--count sat�r say�s�n� sayar, tekrar edenleri say�d�rmamak i�in distinct 
--�lker, hangi kategoride ka� sat��
select BRAND,  CATEGORY_NAME1, SUM(LINENETTOTAL) AS [TOPLAM SATI�] FROM SALES WHERE BRAND IS NOT NULL AND BRAND = '�LKER'
GROUP BY BRAND, CATEGORY_NAME1  ORDER BY SUM(LINENETTOTAL)  desc

--�lker, hangi kategoride hangi alt kategoride ka� sat��
select BRAND,  CATEGORY_NAME1, CATEGORY_NAME2 AS ALTKATEGOR�, SUM(LINENETTOTAL) AS [TOPLAM SATI�] FROM SALES WHERE BRAND IS NOT NULL AND BRAND = '�LKER'
GROUP BY BRAND, CATEGORY_NAME1, CATEGORY_NAME2  ORDER BY BRAND, CATEGORY_NAME1, CATEGORY_NAME2

--ma�azalar�n m��teri say�s�
SELECT BRANCH, COUNT(DISTINCT CLIENTNAME) as [M��teri Say�s�] FROM SALES GROUP BY BRANCH ORDER BY BRANCH 

DELETE FROM SALES WHERE CLIENTNAME = ''-- isim bo� olanlar� sildik

--m��terinin gitt�i ma�aza say�s�
select CLIENTNAME, COUNT(DISTINCT BRANCH) as [Gidilen Ma�aza Say�s�] FROM SALES where CLIENTNAME IS NOT NULL GROUP BY CLIENTNAME ORDER BY CLIENTNAME

--5 ten fazla ma�azaya giden m��teriler 
--art�k aggregate oldugundan where �art�na de�il having e yaz�l�r
select CLIENTNAME, COUNT(DISTINCT BRANCH) as [Gidilen Ma�aza Say�s�] from 
SALES WHERE CLIENTNAME IS NOT NULL GROUP BY CLIENTNAME HAVING COUNT(DISTINCT BRANCH)>5 order by CLIENTNAME

 