create table Student (
	Id int not null primary key,
	Naam Varchar(50) not null,
	Score int null
)

insert into Student values (1, 'Harry potter', 10)
insert into Student values (2, 'Ron Weasley', 5)
insert into Student values (3, 'Hermoine Granger', 20)
insert into Student values (4, 'Test', 12)

select * from Student

update Student set Score=8 where Naam='Ron Weasley'

select * from Student