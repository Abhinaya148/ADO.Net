create table student(stu_id int primary key,stu_name varchar(50));

create table grade(st_id int foreign key references student(stu_id),sub_name varchar(50),Grade int);

create procedure usp_insertstudent(@stu_id int,@stu_name varchar(50))
as begin
insert into student(stu_id,stu_name)values(@stu_id,@stu_name);
end 
go



create procedure usp_insertgrade(@st_id int,@sub_name varchar(50),@Grade int)
as begin 
insert into grade(st_id,sub_name,Grade)values(@st_id,@sub_name,@Grade);
end 
go

create procedure usp_getstudent as begin
select * from student;
end 
go

create procedure usp_getgrade as begin
select * from grade;
end 
go

create procedure usp_updategrade(@st_id int,@grade int)
as begin
update grade set grade=@grade where st_id=@st_id;
end
go