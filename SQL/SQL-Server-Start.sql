create table Employee(
Id int identity,
Name varchar(50) not null,
City varchar(50)not null,
Address varchar(50)not null,
)

drop table Employee

--create procedure [dbo].[AddNewEmpDetails]
--(
--@Id int,
--@Name varchar (50),
--@City varchar (50),
--@Address varchar (50)
--)
--as
--begin
--Insert into Employee values(@Id,@Name,@City,@Address)
--End 



alter procedure [dbo].[AddNewEmpDetails]
(
@Name varchar (50),
@City varchar (50),
@Address varchar (50)
)
as
begin
Insert into Employee values(@Name,@City,@Address)
End 


CREATE Procedure [dbo].[GetEmployees]  
as  
begin  
select Id as Empid,Name,City,Address from Employee
End  
 

 Create procedure [dbo].[UpdateEmpDetails]
(
@EmpId int,
@Name varchar (50),
@City varchar (50),
@Address varchar (50)
)
as
begin
Update Employee
set Name=@Name,
City=@City,
Address=@Address
where Id=@EmpId
End 


Create procedure [dbo].[DeleteEmpById]
(
@EmpId int
)
as
begin
Delete from Employee where Id=@EmpId
End 
