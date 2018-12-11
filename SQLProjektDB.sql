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
	Opretdato nvarchar(10)
)

create table Biler (
	Regnr nvarchar(255) Primary Key,
	M�rke nvarchar(255),
	Model nvarchar(255),
	�rgang int,
	Km decimal,
	Br�ndstoftype nvarchar(255),
	EjerID int Foreign Key References Kunder(ID),
	Opretdato nvarchar(10)
)

create table V�rkstedsophold (
	Bil nvarchar(255) Foreign Key References Biler(Regnr),
	Bes�gsdato decimal
)


SELECT * FROM Kunder

SELECT Fornavn, Efternavn, Regnr FROM Biler, Kunder WHERE EjerID = ID