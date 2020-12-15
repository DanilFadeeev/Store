create index IX_ProductCategory_ProductId 
on ProductCategory (ProductId);

create index IX_ProductCategory_CategoryId
on ProductCategory (CategoryId);

alter table ProductCategory
add constraint FK_Products_ProductCategory
foreign key(ProductId) 
references Products(Id);

alter table ProductCategory
add constraint FK_Categories_ProductCategory 
foreign key(CategoryId) 
references Categories(Id);

alter table ProductCategory
add primary key (ProductId, CategoryId)
