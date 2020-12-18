alter table categories
add ParentCategory int;

alter table categories
add constraint FK_Categories_Categories 
foreign key(ParentCategory) 
references Categories(Id)