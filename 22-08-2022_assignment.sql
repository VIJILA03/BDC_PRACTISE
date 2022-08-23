USE [demo]
GO

SELECT [EmpId]
      ,[EmpName]
      ,[Designation]
      ,[DOB]
      ,[DOJ]
      ,[BaseLocation]
  FROM [dbo].[EmpInfo]

GO


/*select * into empdetails from EmpInfo;
select * from empdetails
alter table empdetails add  WorkingLanguage nchar(20);  
update empdetails set WorkingLanguage='PYTHON' where EmpId=4
*/
/*1.Create a Stored Procedure to show only the Employees working on C# in the base location of Bangalore.
Display the result set with Employee ID, Name, Working Language and Base Location.*/
select * from empdetails
GO
CREATE procedure c#banglore as
select EmpId,EmpName,WorkingLanguage,BaseLocation from empdetails
where WorkingLanguage='C#' AND BaseLocation='Bangalore';

Exec c#banglore
go
/*output
EmpId	EmpName	WorkingLanguage	BaseLocation
2	TED	C#                  	Bangalore*/

/*2. Create a Stored Procedure to calculate total marks and display ranks of students accordingly. Have atleast 10 students in the result set. 
Total marks should include marks from Maths, Economics, Commerce, English and Computer Science.*/

create table StudentMarks(
StdId int primary key,
StdName varchar(50),
Maths int,
Economics int,
Commerce int,
English int,
ComputerSceince int); 
 
insert into StudentMarks values(1,'Elliot',87,78,96,83,87);
insert into StudentMarks values(2,'Ted',96,83,87,65,46);
insert into StudentMarks values(3,'Robert',67,87,98,56,74);
insert into StudentMarks values(4,'Elizabeth',90,87,80,68,79);
insert into StudentMarks values(5,'Zak',80,97,86,75,68);
insert into StudentMarks values(6,'Princy',70,72,83,94,75);
insert into StudentMarks values(7,'Jose',97,82,71,60,79);
insert into StudentMarks values(8,'Albert',87,78,65,87,92);
insert into StudentMarks values(9,'Sam',87,95,76,83,71);
insert into StudentMarks values(10,'Anto',91,87,73,85,79);
insert into StudentMarks values(11,'Emily',76,85,94,58,77);
insert into StudentMarks values(12,'Esther',88,91,80,79,69);

select * from StudentMarks
go

create or alter procedure Result as
select StdId,StdName, Maths+Economics+Commerce+English+ComputerSceince as TotalMarks,rank() over( order by  Maths+Economics+Commerce+English+ComputerSceince DEsc)as Rank
from StudentMarks
order by Rank;
go



exec Result
go

/*output
StdId	StdName	TotalMarks	Rank
1	Elliot	431	1
10	Anto	415	2
9	Sam	412	3
8	Albert	409	4
12	Esther	407	5
5	Zak	406	6
4	Elizabeth	404	7
6	Princy	394	8
11	Emily	390	9
7	Jose	389	10
3	Robert	382	11
2	Ted	377	12
*/