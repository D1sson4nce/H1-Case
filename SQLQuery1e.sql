use master
go

if DB_ID('ProjektDB') is not null 
begin
	drop database ProjektDB
end
go

create database ProjektDB
go

use ProjektDB
go

create table Kunder (
	ID int identity Primary Key,
	Fornavn nvarchar(20),
	Efternavn nvarchar(40),
	Adresse nvarchar(80),
	Alder int,
	Opretdato nvarchar(12)
)

create table Biler (
	Regnr nvarchar(255) Primary Key,
	M�rke nvarchar(255),
	Model nvarchar(255),
	�rgang int,
	Km decimal,
	Br�ndstoftype nvarchar(255),
	EjerID int Foreign Key References Kunder(ID),
	Opretdato nvarchar(12)
)

create table V�rkstedsophold (
	ID int identity primary key,
	Bil nvarchar(255) Foreign Key References Biler(Regnr),
	Bes�gsdato decimal
)

insert into Kunder values
('jontsdfa', 'hejda', 'envej123', 1000, '11-12-2018'),
('jonasdsasdasdta', 'hejda', 'envdwaadwej123', 1000, '11-12-2018'),
('jonfsfeta', 'hejda', 'dawd', 1000, '11-12-2018')

insert into Biler values 
('yes', 'rws', '22', 21, 212, 'yee', 1, '11-12-1221'),
('wda', 'rws', '22', 21, 212, 'yee', 2, '11-12-1221'),
('yewws', 'rws', '22', 21, 212, 'yee', 1, '11-12-1221'),
('da', 'rws', '22', 21, 212, 'yee', 1, '11-12-1221')

select Regnr, M�rke, Model, �rgang, Km, Br�ndstoftype, Fornavn, Efternavn, Biler.Opretdato from Biler join Kunder on EjerID = ID

SELECT * FROM Kunder

SELECT Fornavn, Efternavn, Regnr FROM Biler, Kunder WHERE EjerID = ID

--delete from Biler where EjerID = 1
--delete from Kunder where ID = 1


SELECT * FROM Kunder