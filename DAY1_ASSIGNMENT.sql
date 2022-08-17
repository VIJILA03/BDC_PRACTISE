USE [demo]
GO
/*1.From the following table, write a SQL query to find salespeople who receive commissions between 0.12 and 0.14 (begin and end values are included). 
Return salesman_id, name, city, and commission.
create a table with name salesman which contains the columns salesman_id,name,city,commission*/
INSERT INTO salesman VALUES (5001,'James Hoog','New York','0.15');
INSERT INTO salesman VALUES (5002,'Nail Knite','Paris','0.13');
INSERT INTO salesman VALUES (5005,'Pit Alex ','London','0.11');
INSERT INTO salesman VALUES (5006,' Mc Lyon ', 'Paris', '0.14');
INSERT INTO salesman VALUES (5007,'Paul Adam', 'Rome', '0.13');
INSERT INTO salesman VALUES (5003, 'Lauson Hen ', 'San Jose',' 0.12');

Select * from salesman;
select salesman_id, name, city,  commission from salesman where commission between 0.12 and 0.14;

/*output
salesman_id  name    city   commission
5002	Nail Knite	Paris	0.13
5003	Lauson Hen 	San Jose	0.12
5006	 Mc Lyon 	Paris	0.14
5007	Paul Adam	Rome	0.13*/


/*2.From the following table, write a SQL query to select orders between 500 and 4000 (begin and end values are included). 
Exclude orders amount 948.50 and 1983.43. Return ord_no, purch_amt, ord_date, customer_id, and salesman_id.*/

INSERT INTO orders VALUES (70001,150.5,'2012-10-05',3005,5002);
INSERT INTO orders VALUES (70009,270.65,'2012-09-10',3001,5005);
INSERT INTO orders VALUES (70002,65.26,'2012-10-05',3002,5001);
INSERT INTO orders VALUES (70004,110.5,'2012-08-17',3009,5003);
INSERT INTO orders VALUES (70007,948.5,'2012-09-10',3005,5002);
INSERT INTO orders VALUES (70005,2400.6,'2012-07-27',3007,5001);
INSERT INTO orders VALUES (70008,5760,'2012-09-10',3002,5001);
INSERT INTO orders VALUES (70010,1983.43,'2012-10-10',3004,5006);
INSERT INTO orders VALUES (70003,2480.4,'2012-10-10',3009,5003);
INSERT INTO orders VALUES (70012,250.45,'2012-06-27 ',3008,5002);
INSERT INTO orders VALUES (70011,75.29,'2012-08-17',3003,5007);
INSERT INTO orders VALUES (70013,3045.6,'2012-04-25',3002,5001);

SELECT * FROM orders;

select ord_no, purch_amt, ord_date, customer_id,salesman_id from orders where (purch_amt between 500 and 4000 )AND NOT purch_amt IN (948.50,1983.43 );
--purch!=948.50 and purch_amt!=1983.43

/*OUTPUT
ord_no	purch_amt	ord_date	customer_id	salesman_id
70003     	2480.40	2012-10-10	3009	5003
70005     	2400.60	2012-07-27	3007	5001
70013     	3045.60	2012-04-25	3002	5001
*/

/*3. From the following table, write a SQL query to identify those rows where totalValue does not contain the escape character underscore ( _ ). 
Return totalValue.*/

insert into totalvalue values('A001/DJ-402\44_/100/2015');
insert into totalvalue values('A001_\DJ-402\44_/100/2015');
insert into totalvalue values('A001_DJ-402-2014-2015');
insert into totalvalue values('A002_DJ-401-2014-2015');
insert into totalvalue values('A001/DJ_401');
insert into totalvalue values('A001/DJ_402\44');
insert into totalvalue values('A001/DJ_402\44\2015');
insert into totalvalue values('A001/DJ-402%45\2015/200');
insert into totalvalue values('A001/DJ_402\45\2015%100');
insert into totalvalue values('A001/DJ_402%45\2015/300');
insert into totalvalue values('A001/DJ-402\44');

select* from totalvalue WHERE totalvalue NOT LIKE '%/_%' ESCAPE '/';
/*output
totalvalue
A001/DJ-402%45\2015/200
A001/DJ-402\44
*/


