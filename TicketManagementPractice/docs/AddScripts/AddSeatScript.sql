USE TicketManagementPractice;
GO
CREATE PROCEDURE AddSeat
	@AreaId INT,
	@Row INT,
	@Number INT
AS
BEGIN
	DECLARE @Id INT = (SELECT MAX(Id) FROM Seat) + 1;
	INSERT INTO Seat(Id, AreaId, [Row], Number)
	VALUES (@Id, @AreaId, @Row, @Number)
END;