create procedure GetProductsWithSalers
as
select Name, Cost, Description, p.UserId as SalerId, Category, Image, UserName, u.UserId
from Products as p
join
Users as u
on u.UserId = p.UserId
go
