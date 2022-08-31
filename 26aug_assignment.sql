USE [demo]
GO

/*1.Write a simple stored procedure to get the total of a particular student 
and call another stored procedure to list all the students with marks below than that student.
Input: Student ID
Output: Student Total (From first SP) Student2, Student3, etc (From Second SP)*/

CREATE OR ALTER   procedure student_total @StdId int as
begin
declare @total int=(select Maths+Economics+Commerce+English+ComputerSceince as total from StudentMarks where StdId=@StdId)
exec std_lessthan @total
end
GO

exec student_total 12
select * from StudentMarks
go

CREATE OR ALTER   procedure std_lessthan @total int as
SELECT StdId,StdName,Maths,Economics,Commerce,English,ComputerSceince,Maths+Economics+Commerce+English+ComputerSceince 
as total 
from StudentMarks 
where @total>Maths+Economics+Commerce+English+ComputerSceince
GO


--exec std_lessthan 407
/*output
StdId	StdName	Maths	Economics	Commerce	English	ComputerSceince	total
2	Ted	96	83	87	65	46	377
3	Robert	67	87	98	56	74	382
4	Elizabeth	90	87	80	68	79	404
5	Zak	80	97	86	75	68	406
6	Princy	70	72	83	94	75	394
7	Jose	97	82	71	60	79	389
11	Emily	76	85	94	58	77	390
*/



/* 2.Write a Stored Procedure to fetch the rate of interest for a specific account type. Pass this ROI to a function, calculate the interest inside the function and display the interest on screen.
Input: Account type.
Output: ROI (From SP) Interest (From the UDF)*/


select * from BankaccDetails
go

create or alter procedure roi @acctype varchar(30)
as
declare @roi int
begin 
if(@acctype='savings') set @roi=4;
if(@acctype='current') set @roi=5;
if(@acctype='checking')set @roi=3;
select * from demo.dbo.calcinterest(@roi,@acctype)
end
go

exec roi 'savings'
/*output
Accnum	Acctype	Interest
37245645	Savings	54360.06
42892829	Savings	23506.8936*/

select AccNum,AccType,AccBalance from BankaccDetails
go

create or alter function calcinterest(@roi int,@acctype varchar(30))
returns @calcinc table(Accnum int,Acctype varchar(20),Interest float)  
AS
BEGIN  
declare @yr int=3
insert into @calcinc    
            SELECT AccNum,AccType,AccBalance from BankaccDetails where AccType=@acctype
            
			UPDATE @calcinc 
			SET Interest=(Interest*@roi*@yr)/100 where Acctype=@acctype
RETURN   
END 
go

select * from demo.dbo.calcinterest(3,'savings')

/*Write a UDF to get the sales values of a particular region.
Call another function within to calculate the average sales of that region.
Input: for example, Delhi
Output: sales amt1, sales amt2, sales amt3, etc...... (From first function) 
Output: Average sales in Delhi (from the second function)*/

create table sales(
Region varchar(30),
ProductQuantity int,
unitprice int)

insert into sales valueS('DELHI',45,4),
('DELHI',67,3),
('DELHI',76,4),
('MUMBAI',73,2),
('MUMBAI',65,4),
('MUMBAI',76,3),
('HYDERABAD',87,2),
('HYDERABAD',54,6),
('HYDERABAD',63,2),
('CHENNAI',87,3),
('CHENNAI',84,2),
('CHENNAI',45,6);
go

select * from sales
go

create or alter function salesvalue(@region varchar(30)) 
returns @salesval table(salesval int) as
begin
insert into @salesval
       select ProductQuantity* unitprice  from sales where region=@region;
	  return 
end
go

create or alter function avgsalesvalue(@region varchar(20)) 
returns int as
begin
declare @avg int
  select @avg=(select avg(salesval) from salesvalue(@region))
  return @avg
end
go


select dbo.avgsalesvalue('hyderabad') as averagesalesvalue

/*output
averagesalesvalue
208*/

CREATE TYPE salesval AS TABLE(
	salesval int
)
GO


create or alter function salesvalue(@region varchar(30)) 
returns int as
begin
declare @avg int 
declare @salesval as salesval
insert into @salesval
       select ProductQuantity* unitprice  from sales where region=@region;
	  select @avg=(select dbo.avgsalesvalue(@salesval))
	  return @avg
end
go


SELECT dbo.salesvalue('DELHI') as average
go


create or alter function avgsalesvalue(@salesval salesval READONLY) 
returns int as
begin
declare @avg int
  select @avg=(select avg(salesval) from @salesval)
  return @avg
end
go





