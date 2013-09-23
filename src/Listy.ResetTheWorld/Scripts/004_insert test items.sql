
insert into [ListyListItem] values(newid(), (select [id] from [ListyList] where [Name] = 'Test list 1'), 'Steal socks', 0)
insert into [ListyListItem] values(newid(), (select [id] from [ListyList] where [Name] = 'Test list 1'), '???', 1)
insert into [ListyListItem] values(newid(), (select [id] from [ListyList] where [Name] = 'Test list 1'), 'Profit!', 2)
