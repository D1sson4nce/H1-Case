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
	Mærke nvarchar(255),
	Model nvarchar(255),
	Årgang int,
	Km decimal,
	Brændstoftype nvarchar(255),
	EjerID int Foreign Key References Kunder(ID),
	Opretdato nvarchar(12)
)

create table Værkstedsophold (
	ID int identity primary key,
	Bil nvarchar(255) Foreign Key References Biler(Regnr),
	Besøgsdato nvarchar(16)
)

