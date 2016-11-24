--Creation of Team Table in Database--
CREATE TABLE Team		
(                             
	TeamID bigint NOT NULL 
		UNIQUE,				  
	TeamName nvarchar(50) NOT NULL	
)
GO

--Creation of Member Table in Database--
CREATE TABLE Member
( 
	MemberID bigint NOT NULL
		UNIQUE,
	PassportNumber nvarchar(50) NOT NULL
		UNIQUE,
	T_ID bigint NOT NULL,

	CONSTRAINT fk_teamId 

	FOREIGN KEY(T_ID) 
	REFERENCES Team(TeamID)
	ON DELETE CASCADE,			--Is deleting Member which was depend on deleted Team--

	MemberName nvarchar(50) NOT NULL,
	MemberSurname nvarchar(50) NOT NULL
)
GO

--Creation of Project Table in Database--
CREATE TABLE Project					
(                           
	ProjectID bigint NOT NULL 
		UNIQUE,				  
	ProjectName nvarchar(50) NOT NULL,
	ProjectCreatedDate date NOT NULL,
	ProjectDueDate date NOT NULL,
	ProjectDescription nvarchar(MAX) NOT NULL 
)
GO

--Creation of MemberProject Table in Database--
CREATE TABLE MemberProject			
(
	ID bigint IDENTITY(1,1) NOT NULL
		UNIQUE,  
	M_ID bigint NOT NULL,
	P_ID bigint NOT NULL,

	CONSTRAINT fk_memberId_projectId 

	FOREIGN KEY (M_ID) 
	REFERENCES Member(MemberID)
	ON DELETE CASCADE,			--Is deleting MemberProject reference which was depend on deleted Member--

	FOREIGN KEY (P_ID)
	REFERENCES Project(ProjectID)
	ON DELETE CASCADE,			--Is deleting MemberProject reference which was depend on deleted Project--

	PRIMARY KEY(P_ID,M_ID)
)
GO   