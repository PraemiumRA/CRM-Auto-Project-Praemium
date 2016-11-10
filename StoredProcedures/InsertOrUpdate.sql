CREATE PROCEDURE spDynamicInsertOrUpdate
	@TeamID int = null, 
	@TeamName nvarchar(50) = null,
	@MemberID int = null,
	@MemberName nvarchar(50) = null,
	@MemberSurname nvarchar(50) = null,
	@ProjectID int = null,
	@ProjectName nvarchar(50) = null,
	@ProjectCreatedDate date = null,
	@ProjectDueDate date = null,
	@ProjectDescription nvarchar(max) = null

AS
BEGIN

IF (@TeamID is not null and @TeamName is not null)
	IF EXISTS (Select TeamID from Team where TeamID=@TeamID)
		UPDATE Team
		SET
		TeamName=@TeamName
		WHERE @TeamID=TeamID
	ELSE
		BEGIN
			INSERT INTO Team VALUES (@TeamID, @TeamName)
		END

IF (@MemberID is not null and @TeamID is not null and @MemberName is not null and @MemberSurname is not null)
	IF EXISTS (Select MemberID from Member where MemberID=@MemberID)
		UPDATE Member
		SET
		MemberName=@MemberName,
		MemberSurname=@MemberSurname
		WHERE MemberID=@MemberID
	ELSE
		BEGIN
			INSERT INTO Member VALUES (@MemberID, @TeamID, @MemberName, @MemberSurname)
		END

IF (@ProjectID is not null and @ProjectName is not null and @ProjectCreatedDate is not null and @ProjectDueDate is not null and @ProjectDescription is not null)
	IF EXISTS (Select ProjectID from Project where ProjectID=@ProjectID)
		UPDATE Project
		SET 
		ProjectName=@ProjectName,
		ProjectCreatedDate=@ProjectCreatedDate,
		ProjectDueDate=@ProjectDueDate,
		ProjectDescription=@ProjectDescription
		WHERE ProjectID=@ProjectID
	ELSE 
		BEGIN
			INSERT INTO Project VALUES (@ProjectID, @ProjectName, @ProjectCreatedDate, @ProjectDueDate, @ProjectDescription)
		END

IF (@MemberID is not null and @ProjectID is not null)
	IF EXISTS (Select M_ID, P_ID from MemberProject where M_ID=@MemberID and P_ID=@ProjectID)
		UPDATE MemberProject
		SET 
		M_ID=@MemberID,
		P_ID=@ProjectID
		WHERE M_ID=@MemberID and P_ID=@ProjectID
	ELSE 
		BEGIN
			INSERT INTO MemberProject VALUES (@MemberID, @ProjectID)
		END

END