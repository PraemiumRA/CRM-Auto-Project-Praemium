CREATE TABLE Team		
( 
	ID int IDENTITY(1,1) NOT NULL
		PRIMARY KEY,                               
	TeamID bigint NOT NULL 
		UNIQUE,				  
	TeamName nvarchar(50) NOT NULL	
)
GO

CREATE TABLE Member
( 
	ID int IDENTITY(1,1) NOT NULL
		PRIMARY KEY,
	MemberID bigint NOT NULL
		UNIQUE,
	T_ID bigint NOT NULL,

	CONSTRAINT fk_teamId 

	FOREIGN KEY(T_ID) 
	REFERENCES Team(TeamID)
	ON DELETE CASCADE,

	MemberName nvarchar(50) NOT NULL,
	MemberSurname nvarchar(50) NOT NULL
)
GO

CREATE TABLE Project					
(
	ID int IDENTITY(1,1) NOT NULL
		PRIMARY KEY,                              
	ProjectID bigint NOT NULL 
		UNIQUE,				  
	ProjectName nvarchar(50) NOT NULL,
	ProjectCreatedDate date NOT NULL,
	ProjectDueDate date NOT NULL,
	ProjectDescription nvarchar(MAX) NOT NULL 
)
GO

CREATE TABLE MemberProject			
(
	ID int IDENTITY(1,1) NOT NULL
		UNIQUE,  
	M_ID bigint NOT NULL,
	P_ID bigint NOT NULL,

	CONSTRAINT fk_memberId_projectId 

	FOREIGN KEY (M_ID) 
	REFERENCES Member(MemberID)
	ON DELETE CASCADE,

	FOREIGN KEY (P_ID)
	REFERENCES Project(ProjectID)
	ON DELETE CASCADE,

	PRIMARY KEY(P_ID,M_ID)
)
GO   