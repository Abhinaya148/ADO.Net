create table prod(prodid int,prodname varchar(255),price money,qty int);
go
create procedure usp_products(@prodid int ,@prodname varchar(255),@price money,@qty int)
as
begin
insert into prod(prodid,prodname,price,qty) values(@prodid,@prodname,@price,@qty)
end
go
create procedure usp_insertprod(@prodid int,@prodname varchar(255),@price money,@qty int)
as
begin
insert into prod(prodid,prodname,price,qty)values(@prodid,@prodname,@price,@qty)
end
go

create procedure usp_updateprice(@prodid int, @updatedprice money)
as
begin
update product set price=@updatedprice where prodid=@prodid;
END
GO
drop table prod;
go
create procedure selectproduct(@prodid int   ,
@prodname varchar(30),
@price int,
@qty int)
as
begin
select * from prod;
end
go