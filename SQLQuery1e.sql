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
	Mærke nvarchar,
	Model nvarchar,
	Årgang int,
	Km decimal,
	Brændstoftype nvarchar,
	EjerID int Foreign Key References Kunder(ID)
)