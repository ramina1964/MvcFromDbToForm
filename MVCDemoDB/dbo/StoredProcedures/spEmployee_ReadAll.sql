CREATE PROCEDURE [dbo].[spEmployee_ReadAll]
AS
begin
	select Id, EmployeeId, FirstName, LastName, EmailAddress
	from [dbo].[Employee];
end
