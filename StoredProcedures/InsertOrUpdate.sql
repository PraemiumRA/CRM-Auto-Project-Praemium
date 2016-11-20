CREATE PROCEDURE spDynamicInsertOrUpdate
	@teamData TeamType READONLY,
	@memberData MemberType READONLY,
	@projectData ProjectType READONLY,
	@memberProjectData MemberProjectType READONLY

AS
BEGIN

 BEGIN
   MERGE Team AS baseTeam
		USING (SELECT Distinct TeamID, TeamName FROM @teamData) AS comparingTeam
		ON (baseTeam.TeamID=comparingTeam.TeamID)
		WHEN MATCHED THEN
			UPDATE SET baseTeam.TeamName=comparingTeam.TeamName 
		WHEN NOT MATCHED THEN  
			INSERT (TeamID, TeamName)  
			VALUES (comparingTeam.TeamID, comparingTeam.TeamName);
 END
		
 BEGIN
   MERGE Member AS baseMember
		USING (SELECT Distinct MemberID,TeamID, MemberName, MemberSurname FROM @memberData) AS comparingMember
		ON (baseMember.MemberID=comparingMember.MemberID)
		WHEN MATCHED THEN
			UPDATE SET baseMember.MemberName=comparingMember.MemberName,
			           baseMember.MemberSurname=comparingMember.MemberSurname 
		WHEN NOT MATCHED THEN  
			INSERT (MemberID,T_ID, MemberName, MemberSurname)  
			VALUES (comparingMember.MemberID,comparingMember.TeamID, comparingMember.MemberName, comparingMember.MemberSurname);
 END

 BEGIN

   MERGE Project AS baseProject
		USING(SELECT Distinct ProjectID, ProjectName,ProjectCreatedDate,ProjectDueDate,ProjectDescription FROM @projectData) AS comparingProject
		ON (baseProject.ProjectID=comparingProject.ProjectID)
		WHEN MATCHED THEN
			UPDATE SET baseProject.ProjectName=comparingProject.ProjectName,
			           baseProject.ProjectCreatedDate=comparingProject.ProjectCreatedDate,
			           baseProject.ProjectDueDate=comparingProject.ProjectDueDate,
			           baseProject.ProjectDescription=comparingProject.ProjectDescription
		WHEN NOT MATCHED THEN  
			INSERT (ProjectID, ProjectName, ProjectCreatedDate, ProjectDueDate, ProjectDescription)  
			VALUES (comparingProject.ProjectID, comparingProject.ProjectName, comparingProject.ProjectCreatedDate, comparingProject.ProjectDueDate, comparingProject.ProjectDescription);
 END
 
 BEGIN
 MERGE MemberProject AS baseMemberProject
		USING (SELECT Distinct MemberID, ProjectID FROM @memberProjectData) AS comparingMemberProject
		ON (baseMemberProject.M_ID=comparingMemberProject.MemberID and baseMemberProject.P_ID=comparingMemberProject.ProjectID)
		WHEN MATCHED THEN
			UPDATE SET baseMemberProject.M_ID=comparingMemberProject.MemberID,
			           baseMemberProject.P_ID=comparingMemberProject.ProjectID
		WHEN NOT MATCHED THEN  
			INSERT (M_ID, P_ID)  
			VALUES (comparingMemberProject.MemberID, comparingMemberProject.ProjectID);
 END
END

