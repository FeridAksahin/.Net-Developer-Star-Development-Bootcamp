SELECT * FROM SALES

SELECT * FROM SALES WHERE ITEMNAME LIKE '%fal�m%' --fal�m i�eren veriler getirildi
DELETE FROM SALES WHERE ITEMNAME LIKE '%FALIM%' --fal�m i�eren b�t�n veriler silindi

DELETE FROM SALES WHERE ITEMCODE IS NULL OR ITEMNAME IS NULL --null veriler silindi

/*
aggregate functions 
sum, count, min, max ve avg fonksyionlar�d�r

�rne�in
mesela sat��lar tablosu var bu tabloda price isimli o �r�n ka�a sat�ld��� bilgisi var.
SUM(PRICE) denildigi zaman toplam sat�� fiyat� getirilir
COUNT(ID) dendigi zaman ya da count(herhangi bir alan) dendi�i zaman sat�r say�s� getirilir
MIN(PRICE) dendi�i zaman en ucuz hangi fiyattan sat�ld� bilgisi gelir
MAX(PRICE) dendi�i zaman en pahal� hangi fiyattan sat�ld�
AVG(PRICE) ortalama olarak ne kadardan sat�ld�
kullan�m� �RN
SELECT SUM(PRICE), COUNT(ID), MIN(PRICE),MAX(PRICE),AVG(PRICE) FROM TABLENAME
*/

SELECT LINENET, LINENETTOTAL,BRANCH,ITEMNAME, AMOUNT, PRICE FROM SALES WHERE BRANCH = '�stanbul Subesi'
--sales tablosundan �stanbul Subesi taraf�ndan yap�lan sat��lar�n toplam tutar�
SELECT SUM(LINENETTOTAL) as [�stanbul �ubesi Toplam Sat�� Miktar�] FROM SALES WHERE BRANCH ='�stanbul Subesi'
--Branch yani yeri istanbul �ubesi olan t�m datalar�n linenettotal yani sat�� mesela istanbul �ubesinde 2 adet gazoz sat�ld� totali linenettotalde yazar
--istanbul i�in t�m bu verileri toplad�k sum ile b�ylece istanbul �ubesi i�in toplam sat���n paras� bulunur
--istanbul �ubesinden ka� tane var
SELECT COUNT(*) AS [�stanbul �ubesi Adet] from SALES WHERE BRANCH = '�stanbul Subesi'
--istanbul �ubesinde en az yap�lan sat���n tutar�
SELECT MIN(LINENETTOTAL) AS [�stanbul �ubesi En Az Sat�� Tutar�] FROM SALES WHERE BRANCH = '�stanbul Subesi' 
--istanbul �ubesinde en az sat�� yap�lan miktar
SELECT MIN(AMOUNT) AS [�stanbul �ubesi En Az Sat�� Miktar�] FROM SALES WHERE BRANCH = '�stanbul Subesi' 
--ortalama sat�� tutar� ve istanbul �ubesinde en �ok sat�� yap�lan miktar
 SELECT AVG(LINENETTOTAL) as [Ortalama Sat�� Tutar�], MAX(AMOUNT) AS [�stanbul �ubesi En �ok Miktar�] FROM SALES WHERE BRANCH ='�stanbul Subesi'
 


