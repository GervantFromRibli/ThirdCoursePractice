USE TicketManagementPractice;
GO
CREATE PROCEDURE AddEventSeat
	@EventAreaId INT,
	@Row INT,
	@Number INT,
	@State NVARCHAR(10)
AS
BEGIN
	DECLARE @Id INT = (SELECT MAX(Id) FROM EventSeat) + 1;
	INSERT INTO EventSeat(Id, EventAreaId, [Row], Number, [State])
	VALUES (@Id, @EventAreaId, @Row, @Number, @State)
END;