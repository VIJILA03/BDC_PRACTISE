use demo
go

select * from EmpInfo
select * from empdetails
select * from EmpSalary


/*Create a user defined function where all the employees with the 'manager' designation get a 10% increase in salary and all employees with the 'developer' designation get a 5% increase in salary.
Display all the results on screen.*/

CREATE or alter FUNCTION Getinc()  
RETURNS @Calinc TABLE  
(EmpId int,EmpName varchar(20),Designation varchar(20),new_salary float
)  
AS  
BEGIN  
insert into @Calinc    
            SELECT e.EmpId,e.EmpName,e.Designation,s.salary from empdetails e 
			INNER join EmpSalary s on e.EmpId=s.EmpId
			UPDATE @Calinc 
			SET new_salary= CASE WHEN Designation='MANAGER'  THEN new_salary+(10*new_salary)/100 
                                 WHEN  Designation='BACKEND DEVELOPER'  THEN new_salary+(5*new_salary)/100
								 else new_salary
            END
return
END 
go

SELECT * FROM Getinc()
select * from EmpSalary

/*
EmpId	EmpName	Designation	new_salary
1	VIJI	Backend Developer	28980
2	TED	IOS Developer	74600
3	ELLIOT	Backend Developer	66780
4	ZAK	Manager	43560
5	PRINCY	Manager	57860
*/



--2ND QN

/*Create a user defined function where you can calculate interest on a savings account with the formula pnr/100. 
If it is a checking account, calculate the interest as 5% on principal amount.*/

create table CustomerAccDetails(
CustId int,
CustName Varchar(50),
AccNumber Bigint,
AccType varchar(50) primary key(CustId),
Amount float
);
insert into CustomerAccDetails VALUES(1,'IMMANUEL',38792362612,'savings',34000);
insert into CustomerAccDetails VALUES(2,'VIJILA',24387923626,'checking',45000);
insert into CustomerAccDetails VALUES(3,'PRINCY',84838792362,'current',42300);
insert into CustomerAccDetails VALUES(4,'JOSE',63836387923,'current',72000);
insert into CustomerAccDetails VALUES(5,'DANIEL',63283879236,'savings',53000);
insert into CustomerAccDetails VALUES(6,'JESAN',93278387923,'checking',23000);
insert into CustomerAccDetails VALUES(7,'TOBIN',82387923626,'checking',53000);
select * from CustomerAccDetails
go



CREATE or alter FUNCTION Getincrement(@rate int ,@year int)  
RETURNS @Calinterest TABLE  
(CustId int,CustName varchar(20),AccNumber BigInt,AccType varchar(50),
Interest float)  
AS  
BEGIN  
DECLARE @type varchar(20)
insert into @Calinterest     
            SELECT CustId,CustName,AccNumber,AccType,Amount from CustomerAccDetails
            
			UPDATE @Calinterest 
			SET Interest =case  WHEN  AccType='Savings'  THEN (Interest*@rate*@year)/100 
                                WHEN AccType='Checking'  THEN ((5*Interest)*@rate*@year)/1000
                                else Interest
								end
RETURN   
END 
go

select * from CustomerAccDetails

select * from Getincrement(5,8)

/*
CustId	CustName	AccNumber	AccType	Interest
1	IMMANUEL	38792362612	savings	13600
2	VIJILA	24387923626	checking	9000
3	PRINCY	84838792362	current	42300
4	JOSE	63836387923	current	72000
5	DANIEL	63283879236	savings	21200
6	JESAN	93278387923	checking	4600
7	TOBIN	82387923626	checking	10600
*/