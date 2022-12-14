USE [WORKS]
GO
/****** Object:  StoredProcedure [dbo].[SP_HOMEWORK]    Script Date: 11.08.2022 22:55:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


ALTER PROCEDURE [dbo].[SP_HOMEWORK]
	      @CountryName NVARCHAR(15) ,
		  @CityName NVARCHAR(35),
		  @District NVARCHAR(40),
		  @TOWN NVARCHAR(50)
 --
AS
BEGIN
DECLARE @countryIdFind INT;
DECLARE @cityIdFind INT;



IF EXISTS 
(SELECT Id FROM Country WHERE CountryName = @CountryName)
PRINT 'Bu ülke daha önceden eklenmiştir.';
ELSE
INSERT INTO Country (CountryName) VALUES ( @CountryName ); --3.soru

IF EXISTS 
(SELECT ctn.Id FROM City c JOIN Country ctn on c.CountryId = ctn.Id WHERE ctn.CountryName = @CountryName and c.CityName = @CityName)
BEGIN
PRINT 'Bu ülkeye ait şehir daha önceden eklenmiştir.';
END
ELSE
BEGIN
set @countryIdFind = IDENT_CURRENT ('Country')
INSERT INTO City (CityName,CountryId) VALUES ( @CityName,@countryIdFind );
END --4.soru

IF EXISTS 
(SELECT ds.Id FROM City ci JOIN Country ctry on ci.CountryId = ctry.Id JOIN District ds on ci.Id = ds.CityId WHERE ctry.CountryName = @CountryName and ci.CityName = @CityName and ds.DistrictName = @District)
PRINT 'Bu şehire ait ilçe daha önceden eklenmiştir.';
ELSE
BEGIN
set @countryIdFind = IDENT_CURRENT ('Country')
set @cityIdFind = IDENT_CURRENT ('City')
INSERT INTO District (DistrictName,CountryId,CityId) VALUES ( @District,@countryIdFind,@cityIdFind );
END --5.soru

END
SET NOCOUNT ON