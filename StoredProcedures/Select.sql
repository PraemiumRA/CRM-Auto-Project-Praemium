--Creation of Stored Procedure for selecting data--
CREATE PROCEDURE spDynamicSelection
@PassportNumber varchar(50) =null,
@MemberName varchar(50) = null,
@MemberSurname nvarchar(50) = null,
@TeamName nvarchar(50) = null,
@ProjectName varchar(50) = null,
@ProjectCreatedDate date   = null,
@ProjectDueDate date = null,
@ProjectDescription varchar(max)=null,
@AllMembers bit = 0, --shows all members--
@AllProjects bit = 0, --shows all projects--
@AllTeams bit = 0 --shows all teams--

AS
 BEGIN

	  if (@AllMembers =1)
	   select  PassportNumber,MemberName,MemberSurname from Member 
	  else if(@AllTeams=1)
	   select TeamName from Team 
	  else if(@AllProjects=1)
	   select ProjectName,ProjectCreatedDate,ProjectDueDate,ProjectDescription from Project
	  else 

	  SELECT Member.PassportNumber,Member.MemberName,Member.MemberSurname,Team.TeamName,Project.ProjectName,Project.ProjectCreatedDate,Project.ProjectDueDate,Project.ProjectDescription
	 FROM MemberProject
		Inner JOIN Member
	 ON Member.MemberID = MemberProject.M_ID

	 Inner  JOIN Project
	 ON Project.ProjectID = MemberProject.P_ID
	 
	 Inner  JOIN Team
	 ON Team.TeamID = Member.T_ID
				
	 WHERE 
	 Member.PassportNumber=@PassportNumber or
	 Member.MemberName=@MemberName or
     Member.MemberSurname=@MemberSurname or
	 Team.TeamName=@TeamName or
	 Project.ProjectName=@ProjectName or
	 Project.ProjectCreatedDate=@ProjectCreatedDate or
	 Project.ProjectDueDate=@ProjectDueDate or
	 Project.ProjectDescription=@ProjectDescription
 END
