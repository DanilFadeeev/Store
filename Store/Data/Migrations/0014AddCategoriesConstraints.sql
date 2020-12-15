alter table Categories
add primary key(Id);

alter table Categories
add constraint UQ_Categories_Name 
unique(name);

create unique index IX_Categories_Id 
on Categories(Id);

create unique index IX_Categories_Name
on Categories(Name);