CREATE PROCEDURE [dbo].[spEmployee_Update]
	@Id int,
	@EmployeeId int,
	@FirstName nvarchar(100),
	@LastName nvarchar(100),
	@EmailAddress nvarchar(100)
AS
begin
	update [dbo].[Employee]
	set
	EmployeeId = @EmployeeId,
	FirstName = @FirstName,
	LastName = @LastName,
	EmailAddress = @EmailAddress
	where Id = @Id;
end