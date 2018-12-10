if db_ID('ProjektDB') is not null 
begin
	drop database ProjektDB
end

use master
go

create database ProjektDB

create table Kunder (
	ID int identity Primary Key,
	Navn nvarchar(50),
	Adresse nvarchar(80),
	Alder int,
)

create table Biler (
	Regnr nvarchar Primary Key,
	M�rke nvarchar,
	Model nvarchar,
	�rgang int,
	Km decimal,
	Br�ndstoftype nvarchar,
	EjerID int Foreign Key References Kunder(ID)
)