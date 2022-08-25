use demo
go

/*Create table PassportDetails 
(PassportNumber varchar(50),
CandidateName varchar(50),
IssueDate date,ExpDate date,Validity int,AppliedChannel nchar(10));

select * from PassportDetails
go
*/
Create or alter procedure Passportinfo @PassportNumber varchar(50),@CandidateName varchar(50),
@IssueDate date,@ExpDate date,@Validity int,@AppliedChannel nchar(10)  as
 
 if object_id('dbo.PassportDetails') IS NULL
 begin
 Create table PassportDetails 
(PassportNumber varchar(50),
CandidateName varchar(50),
IssueDate date,ExpDate date,Validity int,AppliedChannel nchar(10));
end
insert into PassportDetails values(@PassportNumber,@CandidateName,@IssueDate,@ExpDate,@Validity,@AppliedChannel)

select * from PassportDetails;
drop table PassportDetails
drop  procedure Passportinfo
go

Create or alter procedure fetchPassportInformation  as
select * from  PassportDetails
 

/*
PassportNumber	CandidateName	IssueDate	ExpDate	Validity	AppliedChannel
EF12vwiji	VIJILA	2000-12-03	2023-12-03	24	DIRECT    
GH42ijdh	PRINCY	2001-11-23	2009-11-23	9	DIRECT    
NR12ijhe	JOHN	2008-06-14	2014-05-30	6	DIRECT    
JH56sken	ELLIOT	2021-03-12	2041-03-12	21	ONLINE    
JQ16jels	TED	2019-12-27	2023-12-14	4	ONLINE    
KE54hdke	SAM	2018-11-10	2025-11-10	8	ONLINE    
LX84hdsi	JOSE	2022-03-12	2031-03-12	10	ONLINE    
ZN23jshd	DANIEL	2007-05-23	2021-04-23	14	DIRECT    
MW48jhdi	TOM	2021-11-23	2031-11-23	11	ONLINE    
XV93idei	NANCY	2007-06-01	2019-07-02	13	DIRECT    
*/


create table studentdb(name varchar(20),Age int, Sex nchar(10), Course varchar(20), YearofStudy int);
go

create or alter procedure studentdet as
insert into studentdb VALUES('viji',21,'F','JAVA','4');
insert into studentdb VALUES('ELLIOT',22,'M','C','4');
insert into studentdb VALUES('TED',19,'M','JAVA','2');
insert into studentdb VALUES('HELEN',18,'F','PYTHON','1');
insert into studentdb VALUES('PRINCY',21,'F','C','4');
insert into studentdb VALUES('JOSE',18,'M','JAVA','1');
insert into studentdb VALUES('ELZA',19,'F','PYTHON','2');
insert into studentdb VALUES('CIYOLA',20,'F','JAVA','3');
insert into studentdb VALUES('VINTA',20,'F','PYTHON','3');

exec studentdet
go
drop procedure studentdet
drop table studentdb
select * from studentdb
go

CREATE OR ALTER PROCEDURE STUDENTYR @year INT AS 
select * from studentdb WHERE YearofStudy=@year

exec STUDENTYR 4
/*
name	Age	Sex	Course	YearofStudy
viji	21	F         	JAVA	4
ELLIOT	22	M         	C	4
PRINCY	21	F         	C	4*/