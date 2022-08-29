CREATE PROCEDURE [dbo].[spEmployee_Create]
	@EmployeeId int,
	@FirstName nvarchar(50),
	@LastName nvarchar(50),
	@EmailAddress nvarchar(50)
AS
begin
	insert into [dbo].[Employee]
	(EmployeeId, FirstName, LastName, EmailAddress)
	values
	(@EmployeeId, @FirstName, @LastName, @EmailAddress);
end
