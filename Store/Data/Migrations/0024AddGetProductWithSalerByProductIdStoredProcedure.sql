create procedure GetProductWithSalerByProductId
@id int
as
select id, Name, Cost, Description, p.UserId as SalerId, Category, Image, UserName, u.UserId
from Products as p
join
Users as u
on u.UserId = p.UserId and p.id =@id
