USE TicketManagementPractice;
GO
CREATE PROCEDURE ReadSeat
	@Id INT
AS
BEGIN
	SELECT Id, AreaId, [Row], Number
	FROM Seat WHERE Id = @Id
END;