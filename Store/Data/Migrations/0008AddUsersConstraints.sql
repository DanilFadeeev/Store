
alter table Users
add primary key(UserId);

alter table Users
add constraint UQ_Users_Email 
unique(Email); 

alter table Users
add constraint UQ_Users_UserName 
unique(UserName);

create unique index IX_Users_UserName 
on Users(UserName);

create unique index IX_Users_Email 
on Users(Email);
