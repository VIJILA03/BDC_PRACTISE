USE [demo]
GO

/*1. From an orders table, fetch the maximum purchase amount a salesman has made in the last 6 months. Also, index the table based on order id.*/
select * from orders

insert into orders values(70016,567.56,'2022-07-12',3002,5001);
insert into orders values(70017,678.78,'2022-08-13',3003,5004);

SELECT MAX(purch_amt) AS Max_Purchase_Amount FROM orders
where datediff(month, ord_date, getdate()) between 0 and 6;

CREATE INDEX idx_order
ON orders (ord_no);       --indexing the order table 
/* output
Max_Purchase_Amount
678.78
*/

/* Use CTE to fetch the employee salary, employee name, etc and display the salaries higher than 45000.*/


Select * from EmpInfo

insert into EmpInfo values(1,'VIJI','Backend Developer','2000-12-03','2018-05-06','Bangalore');
insert into EmpInfo values(2,'TED','IOS Developer','2001-11-17','2018-06-06','Bangalore');
insert into EmpInfo values(3,'ELLIOT','Backend Developer','2000-10-19','2018-05-06','CHENNAI');
insert into EmpInfo values(4,'ZAK','NETWORK ENGINEER','1998-12-03','2014-07-01','HYDERABAD');
insert into EmpInfo values(5,'PRINCY','DATA ANALYST','2002-04-12','2022-07-14','CHENNAI');

select * from EmpSalary
insert into EmpSalary values(1,20000);
insert into EmpSalary values(2,67000);
insert into EmpSalary values(3,56000);
insert into EmpSalary values(4,32000);
insert into EmpSalary values(5,45000);

WITH highest_salary AS (
        SELECT  e.EmpId,e.EmpName,s.salary,e.Designation,e.DOB,e.DOJ
        FROM EmpInfo e JOIN EmpSalary s ON e.EmpId=s.EmpId)
 
SELECT  EmpId,
        EmpName,
        Salary,
        Designation,
		DOB,DOJ
FROM highest_salary
WHERE Salary>45000;

/* output
EmpId	EmpName	Salary	Designation	DOB	DOJ
2	TED	67000	IOS Developer	2001-11-17 00:00:00.000	2018-06-06 00:00:00.000
3	ELLIOT	56000	Backend Developer	2000-10-19 00:00:00.000	2018-05-06 00:00:00.000
*/