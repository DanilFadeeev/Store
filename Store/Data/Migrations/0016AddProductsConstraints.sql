create index IX_Products_Name 
on Products(Name);

create index IX_Products_UserId 
on Products(UserId);

alter table Products
add primary key (Id);

alter table Products
add constraint FK_Users_Products 
foreign key(UserId) 
references Users(UserId)
on delete cascade;