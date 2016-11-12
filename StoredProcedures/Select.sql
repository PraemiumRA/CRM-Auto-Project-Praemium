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
@ProjectDescription varchar(max)=null,
@All int = null

AS
 BEGIN

	  if (@All=1)
	   select  MemberName,MemberSurname from Member 
	  else if(@All=2)
	   select TeamName from Team 
	  else if(@All=3)
	   select ProjectName,ProjectCreatedDate,ProjectDueDate,ProjectDescription from Project
	  else if(@All=4)
	   select Member.MemberName,Member.MemberSurname,Team.TeamName,Project.ProjectName,Project.ProjectCreatedDate,Project.ProjectDueDate,Project.ProjectDescription from Member,Project,Team
	  else 

	  SELECT Member.MemberName,Member.MemberSurname,Team.TeamName,Project.ProjectName,Project.ProjectCreatedDate,Project.ProjectDueDate,Project.ProjectDescription
	 FROM MemberProject
		Inner JOIN Member
	 ON Member.MemberID = MemberProject.M_ID

	 Inner  JOIN Project
	 ON Project.ProjectID = MemberProject.P_ID
	 
	 Inner  JOIN Team
	 ON Team.TeamID = Member.T_ID
				
	 WHERE 
	 Member.MemberID=@MemberID or
	 Member.MemberName=@MemberName or
     Member.MemberSurname=@MemberSurname or
	 Team.ID=@TeamID or
	 Team.TeamName=@TeamName or
	 Project.ProjectID=@ProjectID or
	 Project.ProjectName=@ProjectName or
	 Project.ProjectCreatedDate=@ProjectCreatedDate or
	 Project.ProjectDueDate=@ProjectDueDate or
	 Project.ProjectDescription=@ProjectDescription
 END