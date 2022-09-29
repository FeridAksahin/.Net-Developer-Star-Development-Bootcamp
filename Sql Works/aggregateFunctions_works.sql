SELECT * FROM SALES

SELECT * FROM SALES WHERE ITEMNAME LIKE '%falým%' --falým içeren veriler getirildi
DELETE FROM SALES WHERE ITEMNAME LIKE '%FALIM%' --falým içeren bütün veriler silindi

DELETE FROM SALES WHERE ITEMCODE IS NULL OR ITEMNAME IS NULL --null veriler silindi

/*
aggregate functions 
sum, count, min, max ve avg fonksyionlarýdýr

örneðin
mesela satýþlar tablosu var bu tabloda price isimli o ürün kaça satýldýðý bilgisi var.
SUM(PRICE) denildigi zaman toplam satýþ fiyatý getirilir
COUNT(ID) dendigi zaman ya da count(herhangi bir alan) dendiði zaman satýr sayýsý getirilir
MIN(PRICE) dendiði zaman en ucuz hangi fiyattan satýldý bilgisi gelir
MAX(PRICE) dendiði zaman en pahalý hangi fiyattan satýldý
AVG(PRICE) ortalama olarak ne kadardan satýldý
kullanýmý ÖRN
SELECT SUM(PRICE), COUNT(ID), MIN(PRICE),MAX(PRICE),AVG(PRICE) FROM TABLENAME
*/

SELECT LINENET, LINENETTOTAL,BRANCH,ITEMNAME, AMOUNT, PRICE FROM SALES WHERE BRANCH = 'Ýstanbul Subesi'
--sales tablosundan Ýstanbul Subesi tarafýndan yapýlan satýþlarýn toplam tutarý
SELECT SUM(LINENETTOTAL) as [Ýstanbul Þubesi Toplam Satýþ Miktarý] FROM SALES WHERE BRANCH ='Ýstanbul Subesi'
--Branch yani yeri istanbul þubesi olan tüm datalarýn linenettotal yani satýþ mesela istanbul þubesinde 2 adet gazoz satýldý totali linenettotalde yazar
--istanbul için tüm bu verileri topladýk sum ile böylece istanbul þubesi için toplam satýþýn parasý bulunur
--istanbul þubesinden kaç tane var
SELECT COUNT(*) AS [Ýstanbul Þubesi Adet] from SALES WHERE BRANCH = 'Ýstanbul Subesi'
--istanbul þubesinde en az yapýlan satýþýn tutarý
SELECT MIN(LINENETTOTAL) AS [Ýstanbul Þubesi En Az Satýþ Tutarý] FROM SALES WHERE BRANCH = 'Ýstanbul Subesi' 
--istanbul þubesinde en az satýþ yapýlan miktar
SELECT MIN(AMOUNT) AS [Ýstanbul Þubesi En Az Satýþ Miktarý] FROM SALES WHERE BRANCH = 'Ýstanbul Subesi' 
--ortalama satýþ tutarý ve istanbul þubesinde en çok satýþ yapýlan miktar
 SELECT AVG(LINENETTOTAL) as [Ortalama Satýþ Tutarý], MAX(AMOUNT) AS [Ýstanbul Þubesi En Çok Miktarý] FROM SALES WHERE BRANCH ='Ýstanbul Subesi'
 


