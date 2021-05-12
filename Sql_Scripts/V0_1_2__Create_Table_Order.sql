CREATE TABLE brg_Orders
(
	Id INT NOT NULL IDENTITY(1,1) PRIMARY KEY,
	UserId int not null,
	Meat int null,
	Salad int null,
	Cheese int null,
	TotalPrice int null,
	CreateDate smalldatetime,
	Status int,
	Comment nVarchar(1024),
	Rate int
)