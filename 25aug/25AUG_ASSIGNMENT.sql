USE demo
go

/*1.Write a C# program to display Account details and Customer information of users (Account number, Customer name, Aadhar number, Account opened date, date of last transaction, etc) whose account balance is greater than 200000.
Pull information from 2 tables, Use UDF and display information on screen.*/

--creating customer table

Create table BankCustDetails(
CustId int primary key,
CustName varchar(20),
AccNum bigint,
Aadhar bigint ,
DOB date,
FOREIGN KEY (AccNum) REFERENCES BankaccDetails(AccNum)
)

--create account details

create table BankaccDetails(
AccNum bigint primary key,
AccType Varchar(20),
AccOpenedDate datetime,
LastTransDate datetime,
AccBalance float,
Branch varchar(20)
)

select * from BankaccDetails
select * from BankCustDetails

--insert into Account table

INSERT into BankaccDetails values(37245645,'Savings','2019-05-08 12:54:53','2022-08-23 11:55:03',453000.50,'MUMBAI')
INSERT into BankaccDetails values(85748392,'checking','2012-02-09 10:50:03','2022-08-21 21:04:53',123450.43,'KOLKATA')
INSERT into BankaccDetails values(38482823,'current','2018-09-10 07:52:13','2022-07-29 10:30:33',318479.53,'CHENNAI')
INSERT into BankaccDetails values(23487834,'checking','2011-11-05 14:15:30','2020-02-09 18:45:26',246700.54,'BANGALORE')
INSERT into BankaccDetails values(28474482,'current','2014-03-05 17:51:04','2022-07-30 17:00:03',98360.17,'HYDERABAD')
INSERT into BankaccDetails values(42892829,'Savings','2018-08-22 11:30:08','2021-12-29 13:08:09',195890.78,'CHENNAI')
INSERT into BankaccDetails values(29482382,'current','2020-10-09 16:45:10','2019-01-19 10:28:37',638760.83,'BANGALORE')
INSERT into BankaccDetails values(28423848,'checking','2009-03-28 09:59:09','2022-08-05 16:07:43',736273.47,'MUMBAI')

--insert into customer table

insert into BankCustDetails values(534,'JOY',37245645,837722998532,'1991-07-12');
insert into BankCustDetails values(823,'JANE',85748392,238423823623,'1989-08-11');
insert into BankCustDetails values(322,'LISA',38482823,328272732822,'1993-02-06');
insert into BankCustDetails values(493,'TOM',23487834,923423722384,'1981-06-12');
insert into BankCustDetails values(233,'JERRY',28474482,238423746745,'1987-05-22');
insert into BankCustDetails values(349,'SAM',42892829,247247292243,'1991-04-08');
insert into BankCustDetails values(383,'DAVE',29482382,742872829334,'1992-07-25');
insert into BankCustDetails values(393,'BEN',28423848,874282892945,'1988-07-17');
GO

--function

CREATE or alter FUNCTION GetHigherBalance()  
RETURNS @HighBalance TABLE  
(AccNumber BigInt,CustId int,CustName varchar(20),AccType varchar(50),AccOpenedDate datetime,
LastTransDate datetime,AccBalance float,Branch varchar(20),Aadhar bigint ,DOB date)  
AS  
BEGIN  
insert into @HighBalance   
            SELECT a.AccNum,c.CustId,c.CustName,a.AccType,a.AccOpenedDate,a.LastTransDate,
			a.AccBalance,a.Branch,c.Aadhar,c.DOB from BankaccDetails a 
			join BankCustDetails c  
			on a.AccNum=c.AccNum
			where A.AccBalance>200000		
RETURN   
END 
go

SELECT * FROM GetHigherBalance()

/*OUTPUT

AccNumber	CustId	CustName	AccType	AccOpenedDate	LastTransDate	AccBalance	Branch	Aadhar	DOB
38482823	322	LISA	current	2018-09-10 07:52:13.000	2022-07-29 10:30:33.000	318479.53	CHENNAI	328272732822	1993-02-06
29482382	383	DAVE	current	2020-10-09 16:45:10.000	2019-01-19 10:28:37.000	638760.83	BANGALORE	742872829334	1992-07-25
28423848	393	BEN	checking	2009-03-28 09:59:09.000	2022-08-05 16:07:43.000	736273.47	MUMBAI	874282892945	1988-07-17
23487834	493	TOM	checking	2011-11-05 14:15:30.000	2020-02-09 18:45:26.000	246700.54	BANGALORE	923423722384	1981-06-12
37245645	534	JOY	Savings	2019-05-08 12:54:53.000	2022-08-23 11:55:03.000	453000.5	MUMBAI	837722998532	1991-07-12
*/

/*2. Write a C# program and display Movie information to customers, according to the genre they choose: If they say, "horror" , atleast 5 horror movies must be displayed; 
similarly if they choose 'kids' , animation and kids friendly movies should be displayed. Use UDF and display information on screen.*/

create table Movies
(
MovieName Varchar(60),
MovieGenre Varchar(30),
MovieSubGenre Varchar(60),
MovieYear int
)

Insert into Movies values('The conjuring 3','HORROR','THRILLER',2021);
Insert into Movies values('The Ring','HORROR','THRILLER',2002);
Insert into Movies values('The Invisibele Man','HORROR','THRILLER',2020);
Insert into Movies values('The NUN','HORROR','THRILLER',2018);
Insert into Movies values('Annabelle:creation','HORROR','THRILLER',2017);
Insert into Movies values('Inception','Action','Scientific',2010);
Insert into Movies values('The Gray Man','Action','Thriller',2022);
Insert into Movies values('John Wick','Action','Thriller',2019);
Insert into Movies values('F&F 9','Action','Adventure',2021);
Insert into Movies values('No Time to Die','Action','Thriller',2021);
Insert into Movies values('Spider-Man: No Way Home','Action','Adventure',2021);
Insert into Movies values('Pirates of the Caribbean: Salazars Revenge','Fantasy','Adventure',2017 );
Insert into Movies values('Harry Potter And The Deathly Hallows II','Fantasy','Fantasy',2011);
Insert into Movies values('Beauty and the Beast','Fantasy','Musical',2017);
Insert into Movies values('Frozen 2','Fantasy','Animated',2019);
Insert into Movies values('Moana Sing-Along','Animated','Family',2016);
Insert into Movies values('Encanto','Animated','Family',2021);
Insert into Movies values('Luca','Animated','Family',2021);
Insert into Movies values('The Boss Baby','Animated','Family',2021);

select * from Movies
go

CREATE or alter FUNCTION GetMovies(@genre varchar(30) ) 
RETURNS @genreMovies TABLE  
(
MovieName Varchar(60),
MovieYear int
)
  
AS  
BEGIN  
insert into @genreMovies   
            SELECT MovieName,MovieYear from Movies where MovieGenre=@genre OR MovieSubGenre=@genre 
RETURN          
END 
go

select * from GetMovies('horror')
/*
MovieName	MovieYear
The conjuring 3	2021
The Ring	2002
The Invisibele Man	2020
The NUN	2018
Annabelle:creation	2017*/

select * from GetMovies('animated')

/*MovieName	MovieYear
Frozen 2	2019
Moana Sing-Along	2016
Encanto	2021
Luca	2021
The Boss Baby	2021*/