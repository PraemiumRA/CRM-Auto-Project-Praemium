CREATE PROCEDURE spDynamicDelete
@MemberID int = null,
@MemberName varchar(50) = null,
@MemberSurname nvarchar(50) = null,
@TeamID int = null, 
@TeamName nvarchar(50) = null,
@ProjectID int = null,
@ProjectName varchar(50) = null,
@ProjectCreatedDate date   = null,
@ProjectDueDate date = null,
@MemberProjectID int = null

AS
BEGIN	

	IF @MemberID is not null
		Delete From Member Where MemberID=@MemberID

	IF @MemberName is not null
		Delete From Member Where MemberName=@MemberName

	IF @MemberSurname is not null
		Delete From Member Where MemberSurname=@MemberSurname

	IF @TeamID is not null
		Delete From Team Where TeamID=@TeamID

	IF @TeamName is not null
		Delete From Team Where TeamName=@TeamName

	IF @ProjectID is not null
		Delete From Project Where ProjectID=@ProjectID

	IF @ProjectName is not null
		Delete From Project Where ProjectName=@ProjectName

	IF @ProjectCreatedDate is not null
		Delete Project Where ProjectCreatedDate=@ProjectCreatedDate

	IF @ProjectDueDate is not null
		Delete Project Where ProjectDueDate=@ProjectDueDate
	
	IF @MemberProjectID is not null
		Delete MemberProject Where ID=@MemberProjectID
	
END