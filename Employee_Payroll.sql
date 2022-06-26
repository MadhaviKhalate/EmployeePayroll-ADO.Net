------------UC1-------------
create database empPayroll;
select * from sys.databases;
use empPayroll;

------------UC2-------------
create table Employee_Payroll(
id int identity(1,1) primary key not null,
name varchar(25) not null,
salary float not null,
start_date date not null)

-------------UC3---------------
insert into Employee_Payroll values('Madhavi',15000,'10-10-1993');
insert into Employee_Payroll values('Pallavi',18000,'1994-11-29');
insert into Employee_Payroll values('Sonal',20000,'1994-09-18');
insert into Employee_Payroll values('Gayatri',12000,'1994-05-11');
insert into Employee_Payroll values('Pooja',17000,'1994-08-21');
insert into Employee_Payroll values('Amit',25000,'1993-11-25','M');
insert into Employee_Payroll values('Vishal',22000,'1991-10-23','M');


-------------UC4---------------
select * from Employee_Payroll

-------------UC5---------------
select name,salary from Employee_Payroll where name = 'Madhavi'
select name,salary from Employee_Payroll where name = 'Sonal'
select * from Employee_Payroll where start_date between '1994-05-11' and CURRENT_TIMESTAMP 

-------------UC6---------------
alter table Employee_Payroll add gender varchar(10) null
update Employee_Payroll set gender = 'F' where name= 'Madhavi'
update Employee_Payroll set gender = 'F' where name= 'Pallavi'
update Employee_Payroll set gender = 'F' where name= 'Sonal'
update Employee_Payroll set gender = 'F' where name= 'Gayatri'
update Employee_Payroll set gender = 'F' where name= 'Pooja'

--------------UC7---------------
select gender, sum(salary) as sum_salary from Employee_Payroll group by gender
select gender, min(salary) as min_salary from Employee_Payroll group by gender
select gender, max(salary) as max_salary from Employee_Payroll group by gender
select gender, avg(salary) as avg_salary from Employee_Payroll group by gender
select gender, count(salary) as emp_count from Employee_Payroll group by gender

--------------UC8----------------
alter table Employee_Payroll add mobile decimal not null default(0)
update Employee_Payroll set mobile = 9873636362 where name = 'Madhavi'
update Employee_Payroll set mobile = 9879127663 where name = 'Pallavi'
update Employee_Payroll set mobile = 9074664656 where name = 'Sonal'
update Employee_Payroll set mobile = 9764678398 where name = 'Gayatri'
update Employee_Payroll set mobile = 8963567656 where name = 'Pooja'
update Employee_Payroll set mobile = 9987565657 where name = 'Amit'
update Employee_Payroll set mobile = 9683866564 where name = 'Vishal'

alter table Employee_Payroll add address varchar(100) not null default(''),department varchar(50) not null default('')
update Employee_Payroll set address = 'Baramati',department = 'Production' where name = 'Madhavi'
update Employee_Payroll set address = 'Phaltan',department = 'Tech_Support' where name = 'Pallavi'
update Employee_Payroll set address = 'Pune',department = 'Production' where name = 'Sonal'
update Employee_Payroll set address = 'Mumbai',department = 'Admin' where name = 'Gayatri'
update Employee_Payroll set address = 'Nagpur',department = 'Production' where name = 'Pooja'
update Employee_Payroll set address = 'Sangavi',department = 'NonIT_Support' where name = 'Amit'
update Employee_Payroll set address = 'Nashik',department = 'IT_Support' where name = 'Vishal'

--------------UC9--------------
alter table Employee_Payroll add basic_pay float not null default(0),deductions float not null default(0),
taxable_pay float not null default(0), net_pay float not null default(0)
update Employee_Payroll set basic_pay = 10000,deductions = 200,taxable_pay = 200,net_pay = 9400 where id = 1
update Employee_Payroll set basic_pay = 12000,deductions = 200,taxable_pay = 200,net_pay = 8200 where id = 3
update Employee_Payroll set basic_pay = 14000,deductions = 200,taxable_pay = 200,net_pay = 8000 where id = 14
update Employee_Payroll set basic_pay = 16000,deductions = 200,taxable_pay = 200,net_pay = 9000 where id = 15
update Employee_Payroll set basic_pay = 18000,deductions = 200,taxable_pay = 200,net_pay = 7500 where id = 16
update Employee_Payroll set basic_pay = 13000,deductions = 200,taxable_pay = 200,net_pay = 7000 where id = 17
update Employee_Payroll set basic_pay = 15000,deductions = 200,taxable_pay = 200,net_pay = 6600 where id = 18
update Employee_Payroll set basic_pay = 11000,deductions = 200,taxable_pay = 200,net_pay = 6200 where id = 19

------------UC10 and UC11----------
insert into Employee_Payroll values('Sagar',15000,'2021-01-01','M',9876543210,'Pune','Sales',15000,200,200,14600)
update Employee_Payroll set name = 'Sagarika' where ID = 20
update Employee_Payroll set department = 'Sales&Market' where name = 'Sagarika'
insert into Employee_Payroll values('Sagarika',15000,'2021-01-01','F',9876543210,'Chennai','Marketing',15000,200,200,14600)


-----Creating Companies Table-----
create table Companies(
company_id int identity(101,1) primary key not null,
company_name varchar(25) not null)

insert into Companies values('ABC')
insert into Companies values('XYZ')

-----Creating employee details table-----
create table Employee_Details(
emp_id int identity(1,1) primary key not null,
name varchar(50) not null,
gender varchar(2) not null,
phone int not null,
email varchar(50) not null)

alter table Employee_Details add start_date date not null
alter table Employee_Details add company_id int not null default(0)

insert into Employee_Details values('Amit','M',9087654321,'amit@gmail.com','2018-10-11',1)
insert into Employee_Details values('Madhavi','F',9807654321,'madhavi@gmail.com','2020-09-15',2)
insert into Employee_Details values('Pooja','F',9123456780,'pooja@gmail.com','2021-04-20',3)
insert into Employee_Details values('Vishal','M',8907651234,'vishal@gmail.com','2019-02-18',4)

update Employee_Details set company_id = 101
update Employee_Details set start_date = '2018-10-11' where name = 'Madhavi'

select * from Employee_Details

-----Creating department details table-----
create table dept_details(
dept_id int identity(11,1) primary key not null,
dept_name varchar(25) not null)

insert into dept_details values('Administration'),('Sales'),('Marketing'),('Production')

------Creating Employee Address Table-------
create table Emp_Address(
name varchar(50) primary key not null,
address varchar(25) not null,
city varchar(25) not null,
state varchar(25) not null,
zip_code int not null)

insert into Emp_Address values('Sagarika','15C','Pune','Maharashtra',400001)
insert into Emp_Address values('Madhavi','11A','Baramati','Maharashtra',400001)
insert into Emp_Address values('Pooja','12D','Solapur','Maharashtra',400001)
insert into Emp_Address values('Pallavi','14C','Phaltan','Maharashtra',400001)

-------Creating Employee Salary Table--------
create table Emp_Salary(
emp_id int identity(1,1) primary key not null,
name varchar(50) not null,
basic_pay float not null,
deductions float not null,
taxable_pay float not null,
income_tax float not null,
net_pay float not null )

insert into Emp_Salary values('Sagarika',40000,1000,1000,2000,45000)
insert into Emp_Salary values('Madhavi',50000,1000,1000,2000,25000)
insert into Emp_Salary values('Pallavi',30000,1000,1000,2000,35000)
insert into Emp_Salary values('Pooja',60000,1000,1000,2000,45000)

------Creating Employee Department Table-------
create table Emp_Department(
emp_id int not null,
emp_name varchar(25) not null,
dept_id int not null,
dept_name varchar(25) not null)

insert into Emp_Department values(1,'Sagarika',12,'Sales'),(1,'Sagarika',13,'Marketing'),
(2,'Madhavi',14,'Production'),(3,'Pallavi',14,'Production'),(4,'Pooja',11,'Administration')

-------Adding Constraints To The Table------
alter table Employee_Details add constraint fk_comp_id foreign key(company_id) references Companies(company_id)
alter table Emp_Salary add constraint fk_emp_id foreign key(emp_id) references Employee_Details(emp_id)
alter table Employee_Details add constraint fk_name foreign key(name) references Emp_Address(name)
alter table Emp_Department add constraint fk_emp_dept_id foreign key(emp_id) references Employee_Details(emp_id)

select gender,sum(basic_pay) as salary_sum from Employee_Details ed inner join Emp_Salary es on es.emp_id = ed.emp_id group by gender
select gender,min(basic_pay) as min_salary from Employee_Details ed inner join Emp_Salary es on es.emp_id = ed.emp_id group by gender
select gender,max(basic_pay) as max_salary from Employee_Details ed inner join Emp_Salary es on es.emp_id = ed.emp_id group by gender
select gender,avg(basic_pay) as avg_salary from Employee_Details ed inner join Emp_Salary es on es.emp_id = ed.emp_id group by gender
select gender,count(gender) as emp_count from Employee_Details ed inner join Emp_Salary es on es.emp_id = ed.emp_id group by gender

----------------UC12--------------------
select ed.emp_id,ed.name,gender,phone,start_date,basic_pay,deductions,taxable_pay,income_tax,net_pay from Employee_Details ed inner join
Emp_Salary es on ed.emp_id = es.emp_id where start_date between '2018-10-11' and CURRENT_TIMESTAMP

select ed.name,basic_pay from Employee_Details ed inner join Emp_Salary es on ed.emp_id = es.emp_id where ed.name = 'Pooja'

select * from Companies
select * from Employee_Details
select * from Emp_Address
select * from dept_details
select * from Emp_Salary
select * from Emp_Department

select c.company_id,company_name,dd.dept_id,dd.dept_name,ed.emp_id,ea.name,gender,phone,email,start_date,address,city,state,zip_code,basic_pay,net_pay from 
Companies c inner join Employee_Details ed on c.company_id = ed.company_id inner join Emp_Department empd on ed.emp_id = empd.emp_id inner join dept_details dd 
on dd.dept_id = empd.dept_id inner join Emp_Address ea on ea.name inner join Emp_Salary es on es.emp_id = ed.emp_id



--------------UC1 ADO.NET--------------
--PROCEDURE FOR CHECKING CONNECTIVITY
GO
CREATE PROCEDURE ConnectivityCheck
AS
BEGIN
SELECT * FROM EMPLOYEE_PAYROLL
END

--PROCEDURE FOR ADD DATA TO THE TABLE
GO
CREATE OR ALTER PROCEDURE [dbo].[SpAddEmployeeDetails]
(@NAME VARCHAR(25),
@SALARY FLOAT,
@START_DATE DATE,
@GENDER VARCHAR(10),
@MOBILE DECIMAL,
@ADDRESS VARCHAR(100),
@DEPARTMENT VARCHAR(50),
@BASIC_PAY FLOAT,
@DEDUCTIONS FLOAT,
@TAXABLE_PAY FLOAT,
@NET_PAY FLOAT)
AS
BEGIN
INSERT INTO EMPLOYEE_PAYROLL VALUES(@NAME,@SALARY,@START_DATE,@GENDER,@MOBILE,@ADDRESS,@DEPARTMENT,@BASIC_PAY,@DEDUCTIONS,@TAXABLE_PAY,@NET_PAY)
END

SELECT * FROM EMPLOYEE_PAYROLL

--PROCEDURE FOR UPDATING DATA IN THE TABLE
GO
CREATE OR ALTER PROCEDURE [dbo].[UpdateEmployee_Payroll]
(@NAME VARCHAR(25),
@BASIC_PAY FLOAT)
AS
BEGIN
UPDATE EMPLOYEE_PAYROLL SET BASIC_PAY = @BASIC_PAY WHERE NAME = @NAME
END

--PROCEDURE
GO
CREATE OR ALTER PROCEDURE [dbo].[DeleteEmployee_Payroll]
(@NAME VARCHAR(25))
AS
BEGIN
DELETE FROM EMPLOYEE_PAYROLL WHERE NAME = @NAME
END
