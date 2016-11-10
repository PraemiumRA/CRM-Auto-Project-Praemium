CREATE PROCEDURE spDynamicSelection
@MemberID int = null,
@MemberName varchar(50) = null,
@MemberSurname nvarchar(50) = null,
@TeamID int = null, 
@TeamName nvarchar(50) = null,
@ProjectID int = null,
@ProjectName varchar(50) = null,
@ProjectCreatedDate date   = null,
@ProjectDueDate date = null,
@ProjectDescription varchar(max)=null

AS
BEGIN
	SELECT Member.MemberID, Member.MemberName,Member.MemberSurname,
	Team.TeamID,Team.TeamName,Project.ProjectID,Project.ProjectName,
	Project.ProjectCreatedDate,Project.ProjectDueDate,Project.ProjectDescription

	FROM MemberProject

	  FULL OUTER JOIN Member
	 ON Member.MemberID = MemberProject.M_ID

	  FULL OUTER JOIN Project
	 ON Project.ProjectID = MemberProject.P_ID	 

	  FULL OUTER JOIN Team
	 ON Team.TeamID = Member.T_ID
				
	WHERE 
	 Member.MemberName=@MemberName or
	 Member.MemberID=@MemberID or
	 Member.MemberSurname=@MemberSurname or
	 Team.TeamID=@TeamID  or
	 Team.TeamName=@TeamName or
	 Project.ProjectID=@ProjectID or
	 Project.ProjectName=@ProjectName or
	 Project.ProjectCreatedDate=@ProjectCreatedDate or
	 Project.ProjectDueDate=@ProjectDueDate or
	 Project.ProjectDescription=@ProjectDescription
END