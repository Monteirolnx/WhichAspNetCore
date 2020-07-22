CREATE PROCEDURE [dbo].[spOrders_GetById]
	@ID INT
AS
BEGIN
	
	SET NOCOUNT ON;

	SELECT [Id], [OrderName], [OrderDate], [FoodId], [Quantity], [Total]
	FROM dbo.[Order]
	WHERE Id = @ID;

END
