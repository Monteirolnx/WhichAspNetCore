﻿CREATE PROCEDURE [dbo].[spOrders_Insert]
	@ORDERNAME NVARCHAR(50),
	@ORDERDATE DATETIME2(7),
	@FOODID INT,
	@QUANTITY INT,
	@TOTAL MONEY,
	@ID INT OUTPUT
AS
BEGIN
	SET NOCOUNT ON;

	INSERT INTO dbo.[Order](OrderName, OrderDate, FoodId, Quantity, Total)
	VALUES (@ORDERNAME, @ORDERDATE, @FOODID, @QUANTITY, @TOTAL)

	SET @ID = SCOPE_IDENTITY();
END

