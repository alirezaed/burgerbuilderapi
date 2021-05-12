CREATE TABLE brg_Users
(
	Id INT NOT NULL IDENTITY(1,1) PRIMARY KEY,
	Username nvarchar(512) not null,
	Password nvarchar(512) not null,
	FullName nvarchar(1024),
	CreateDate smalldatetime,
	Confirmed bit,
	Email varchar(1024)
)