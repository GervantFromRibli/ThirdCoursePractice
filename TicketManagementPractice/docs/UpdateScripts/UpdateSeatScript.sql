USE TicketManagementPractice;
GO
CREATE PROCEDURE UpdateSeat
	@Id INT,
	@AreaId INT,
	@Row INT,
	@Number INT
AS
BEGIN
	UPDATE Seat SET AreaId = @AreaId, [Row] = @Row, Number = @Number
	WHERE Id = @Id
END;