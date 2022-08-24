USE [demo]
GO

/*1.From the following table, create a view to count the number of salespeople in each city. 
 Return city, number of salespersons.*/
select * from salesman;
go 

create view num_salespeople AS 
SELECT city,COUNT(distinct salesman_id)as count_salesperson
FROM salesman
group by city;
go

select * from num_salespeople;
/*output
city	count_salesperson
London	1
New York	1
Paris	2
Rome	1
San Jose	1
*/

/*2.From the following table, write a SQL query to select all the salespeople. 
Return salesman_id, name, city, commission with the percent sign (%).*/

SELECT *from salesman;

--using format
select salesman_id,name,city,format(commission,'p')as commission_percent from salesman;

/*output
salesman_id	name	city	commission_percent
5001	James Hoog	New York	15.00%
5002	Nail Knite	Paris	13.00%
5003	Lauson Hen 	San Jose	12.00%
5005	Pit Alex 	London	11.00%
5006	 Mc Lyon 	Paris	14.00%
5007	Paul Adam	Rome	13.00%
*/

/* From the following tables, write a SQL query to find the number of goals scored by each team in each match during normal play.
Return match number, country name and goal score.*/

select *from match_details
insert into match_details values(1,'G',1207,'W','N',2,'',80016,160140)
insert into match_details values(1,'G',1216,'L','N',1,'',80020,160348)
insert into match_details values(2,'G',1201,'L','N',0,'',80003,160001)
insert into match_details values(2,'G',1207,'W','N',1,'',80023,160463)
insert into match_details values(3,'G',1214,'W','N',2,'',80031,160532)
insert into match_details values(3,'G',1213,'L','N',1,'',80025,160392);
insert into match_details values(4,'G',1206,'D','N',1,'',80008,160117);
insert into match_details values(4,'G',1210,'D','N',1,'',80019,160369);
insert into match_details values(5,'G',1211,'L','N',0,'',80011,160486);
insert into match_details values(5,'G',1204,'W','N',1,'',80022,160071);
insert into match_details values(6,'G',1213,'W','N',1,'',80036,160279);
insert into match_details values(6,'G',1212,'L','N',0,'',80029,160256);
insert into match_details values(7,'G',1208,'W','N',2,'',80014,160163);
insert into match_details values(7,'G',1201,'L','N',0,'',80006,160508);
insert into match_details values(8,'G',1205,'L','N',0,'',80012,160093);
insert into match_details values(8,'G',1204,'L','N',0,'',80012,160093);
insert into match_details values(9,'G',1214,'D','N',1,'',80017,160324);
insert into match_details values(9,'G',1201,'D','N',1,'',80010,160439);
insert into match_details values(10,'G',1203,'L','N',0,'',80004,160047);
insert into match_details values(10,'G',1211,'W','N',2,'',80007,160231);
insert into match_details values(11,'G',1202,'L','N',0,'',80026,160024);
insert into match_details values(11,'G',1209,'W','N',2,'',80028,160187);
insert into match_details values(12,'G',1214,'D','N',1,'',80009,160302);
insert into match_details values(12,'G',1210,'D','N',1,'',80015,160208);

select *from soccer_country
insert into soccer_country values(1201,'ALB','Albania');
insert into soccer_country values(1202,'AUT','Austria');
insert into soccer_country values(1203,'BEL','Belgium');
insert into soccer_country values(1204,'CRO','Croatia');
insert into soccer_country values(1205,'CZE','zech Republic');
insert into soccer_country values(1206,'ENG','England');
insert into soccer_country values(1207,'FRA','France');
insert into soccer_country values(1208,'GER','Germany');
insert into soccer_country values(1209,'HUN','Hungary');
insert into soccer_country values(1210,'ISL','Iceland');
insert into soccer_country values(1211,'ITA','Italy');
insert into soccer_country values(1212,'NIR','Northern Ireland');
insert into soccer_country values(1213,'POL','Poland');
insert into soccer_country values(1214,'POR','Portugal');

--using where clause

select m.match_no,s.country_name,m.goal_score from match_details m,soccer_country s where m.team_id=s.country_id;

--using joins

select m.match_no,s.country_name,m.goal_score from match_details m join soccer_country s on m.team_id=s.country_id;
/*output
match_no	country_name	goal_score
1	France	2
2	Albania	0
2	France	1
3	Poland	1
3	Poland	1
4	England	1
4	Iceland	1
5	Italy	0
5	Croatia	1
6	Poland	1
6	Northern Ireland	0
7	Germany	2
7	Albania	0
8	zech Republic	0
8	Croatia	0
9	Portugal	1
9	Albania	1
10	Belgium	0
10	Italy	2
11	Austria	0
11	Hungary	2
12	Portugal	1
12	Iceland	1*/

/*4. Create a student database which has information about Students, their marks, courses, etc.
Display on screen the maximum marks, each student has obtained in each course, order it by course.*/

SELECT*  from StudentExam

insert into StudentExam values('ELLIOT',78,'JAVA');
insert into StudentExam values('ROBERT',67,'PYTHON');
insert into StudentExam values('ALICE',85,'C');
insert into StudentExam values('JESI',78,'ML');
insert into StudentExam values('JULIET',95,'JAVA');
insert into StudentExam values('PRINCY',89,'ML');
insert into StudentExam values('DAVID',56,'PYTHON');
insert into StudentExam values('CHRISMA',86,'C');
insert into StudentExam values('ZAK',98,'AI');
insert into StudentExam values('JACK',76,'AI');
insert into StudentExam values('ANTON',99,'AI');

select StdName,Marks as firstmark,CourseName from StudentExam 
where marks in (select max(marks)  from StudentExam 
group by CourseName)
order by CourseName;

/*OUTPUT
StdName	firstmark	CourseName
ANTON	99	AI
CHRISMA	86	C
JULIET	95	JAVA
PRINCY	89	ML
ROBERT	67	PYTHON
*/