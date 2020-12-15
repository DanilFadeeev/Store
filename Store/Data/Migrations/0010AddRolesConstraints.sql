alter table Roles
add primary key(Id);

alter table Roles
add constraint QK_Roles_Name 
unique(Name);