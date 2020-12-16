create CLUSTERED index IX_UserRole_UserID_RoleId
on UserRole (UserId, RoleId);

create index IX_UserRole_UserID
on UserRole (UserId);

create index IX_UserRole_RoleId
on UserRole (RoleId);

alter table UserRole
add constraint FK_Users_UserRole 
foreign key(UserId)
references Users(UserId)
on delete cascade;

alter table UserRole
add constraint FK_Roles_UserRole 
foreign key(RoleId)
references Roles(Id)
on delete cascade;

alter table UserRole
add primary key (UserId, RoleId)
