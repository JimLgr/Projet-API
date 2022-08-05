CREATE database MrTerence;

create table Emplacement(
 EmplacementId bigint auto_increment  NOT NULL,
 Casier nvarchar(5) NOT NULL,
 Etagere nvarchar(5) NOT NULL,
 constraint pkEmplacement primary key (EmplacementId));

INSERT INTO Emplacement (Casier, Etagere) 
VALUES ('C1', 'E1'),
	   ('C2', 'E1'),
	   ('C3', 'E1'),
	   ('C4', 'E1'),
	   ('C5', 'E1'),
	   ('C6', 'E1'),
	   ('C7', 'E1'), 
	   ('C8', 'E1'), 
	   ('C9', 'E1'),
	   ('C10', 'E1'), 
	   ('C1', 'E2'), 
	   ('C2', 'E2'), 
	   ('C3', 'E2'), 
	   ('C4', 'E2'), 
	   ('C5', 'E2'), 
	   ('C6', 'E2'), 
	   ('C7', 'E2'), 
	   ('C8', 'E2'), 
	   ('C9', 'E2'), 
	   ('C10', 'E2');

 create table Fournisseur(
  FournisseurId bigint auto_increment  NOT NULL,
  Nom nvarchar(50) NOT NULL,
  Prenom nvarchar(50) NOT NULL,
  Phone nvarchar(50) NOT NULL,
  Fax nvarchar(50) NULL,
  Email nvarchar(50) NULL,
  Website nvarchar(50) NULL,
  AdresseId bigint NULL,
  constraint pkFournisseur primary key (FournisseurId));

  INSERT INTO Fournisseur (Nom, Prenom, Phone, Fax, Email, Website, AdresseId)
  VALUES ('DEGAULT', 'Charle', '+33492123304', NULL, 'degaultcharle@playboy.org', NULL, NULL),
		 ('KEIRN', 'Wheeis', '+33492129215', NULL, NULL, NULL, NULL),
		 ('BJORN', 'CôteDeFer', '+33492127841', NULL, NULL, NULL, NULL),
		 ('SINGLE', 'Maxime', '+33492127412', NULL, NULL, NULL, NULL),
		 ('TAITOI', 'Kevin', '+33492125623', NULL, NULL, NULL, NULL),
		 ('SINIK', 'Dominique', '+33492121420', NULL, NULL, NULL, NULL),
		 ('DAVEM', 'Charline', '+33492120103', '+98525544256', 'degaultcharle@playboy.org', 'https://testdbtestterence.org', NULL),
		 ('DIMIZA', 'Lucia', '+33492128568', NULL, NULL, NULL, NULL),
		 ('KANIK', 'Dimitry', '+33492128989', NULL, NULL, NULL, NULL),
		 ('JHONSON', 'Nick', '+33492121245', NULL, NULL, NULL, NULL);


create table Adresse(
 AdresseId bigint auto_increment  NOT NULL,
 Numero int NOT NULL,
 Rue nvarchar(50) NOT NULL,
 Ville nvarchar(50) NOT NULL,
 CodePostale nvarchar(50) NOT NULL,
 Pays nvarchar(50) NOT NULL,
 FournisseurId bigint NOT NULL,
 constraint pkAdresse primary key (AdresseId));

 INSERT INTO Adresse (Numero, Rue, Ville, CodePostale, Pays, FournisseurId) 
 VALUES (15, 'Rue Des Champs', 'Pirrelatte', '15400', 'France', 1),
        (87, 'Avenue Montaing', 'Paris', '94000', 'France', 2),
		(189, 'Rue Dinistia Sompra', 'Palerme', '91000', 'Sicile', 3),
		(256, 'Rue Alpinoza Recif', 'Madrid', '52000', 'Espagne', 4),
		(1, 'Avenue Reine Astrid', 'Spa', '4900', 'Belgique', 5),
		(185, 'Rue Drong Marks', 'Frankfort', '15800', 'Allemagne', 6),
		(12, 'Rue Sept', 'PirreSept', '15700', 'France', 7),
		(78, 'Rue Huit', 'PirreHuit', '15800', 'France', 8),
		(52, 'Rue Neuf', 'PirreNeuf', '15900', 'France', 9),
		(41, 'Rue Dix', 'PirreDix', '16000', 'France', 10);

UPDATE Fournisseur
SET AdresseId = 1
WHERE FournisseurId = 1;
UPDATE Fournisseur
SET AdresseId = 2
WHERE FournisseurId = 2;
UPDATE Fournisseur
SET AdresseId = 3
WHERE FournisseurId = 3;
UPDATE Fournisseur
SET AdresseId = 4
WHERE FournisseurId = 4;
UPDATE Fournisseur
SET AdresseId = 5
WHERE FournisseurId = 5;
UPDATE Fournisseur
SET AdresseId = 6
WHERE FournisseurId = 6;
UPDATE Fournisseur
SET AdresseId = 7
WHERE FournisseurId = 7;
UPDATE Fournisseur
SET AdresseId = 8
WHERE FournisseurId = 8;
UPDATE Fournisseur
SET AdresseId = 9
WHERE FournisseurId = 9;
UPDATE Fournisseur
SET AdresseId = 10
WHERE FournisseurId = 10;
 
 
create table Bouteille(
 BouteilleId bigint auto_increment NOT NULL,
 Label nvarchar(50) NOT NULL,
 Type nvarchar(50) NOT NULL,
 Degree_alcool decimal(18,2) NOT NULL,
 Volume decimal(18,2) NOT NULL,
 MiseEnBouteille datetime NOT NULL,
 AnneeDeMiseEnBouteille int NOT NULL,
 Marque nvarchar(50) NOT NULL,
 Origine nvarchar(50) NOT NULL,
 Pays nvarchar(50) NOT NULL,
 Stock tinyint NOT NULL,
 Review nvarchar(50) NULL,
 FournisseurId bigint NOT NULL,
 EmplacementId bigint NOT NULL,
 constraint pkBouteille primary key (BouteilleId)); 


 INSERT INTO Bouteille (Label, Type, Degree_alcool, Volume, MiseEnBouteille, AnneeDeMiseEnBouteille, Marque, Origine, Pays, Stock, Review, FournisseurId, EmplacementId)
 VALUES ('UnLabel','Rouge', 15, 0.75, '2015-12-12', 2015, 'UneMarque', 'UneOrigine', 'UnPays', 1, NULL, 1, 1),
        ('DeuxLabel','Rosée', 12, 0.75, '2015-12-12', 2015, 'DeuxMarque', 'DeuxOrigine', 'DeuxPays', 1, NULL, 2, 2),
        ('TroisLabel','Blanc', 9, 0.75, '2015-12-12', 2015, 'TroisMarque', 'TroisOrigine', 'TroisPays', 1, NULL, 3, 3),
        ('QuatreLabel','Mousseux', 12.5, 0.75, '2015-12-12', 2015, 'QuatreMarque', 'QuatreOrigine', 'QuatrePays', 1, NULL, 4, 4),
        ('CinqLabel','Rouge', 15.8, 0.75, '2015-12-12', 2015, 'CinqMarque', 'CinqOrigine', 'CinqPays', 1, NULL, 5, 5),
        ('SixLabel','Rosée', 15, 0.75, '2015-12-12', 2015, 'SixMarque', 'SiexOrigine', 'SixPays', 1, NULL, 6, 6),
        ('SeptLabel','Blanc', 14, 0.75, '2015-12-12', 2015, 'SeptMarque', 'SeptOrigine', 'SeptPays', 1, NULL, 7, 7),
        ('HuitLabel','Mousseux', 21.6, 0.75, '2015-12-12', 2015, 'HuitMarque', 'HuitOrigine', 'HuitPays', 1, NULL, 8, 8),
        ('NeufLabel','Rouge', 8.2, 0.75, '2015-12-12', 2015, 'NeufMarque', 'NeufOrigine', 'NeufPays', 1, NULL, 9, 18),
        ('DixLabel','Rouge', 6.5, 0.75, '2015-12-12', 2015, 'DixMarque', 'DixOrigine', 'DixPays', 1, NULL, 10, 19);


alter table Adresse
add constraint fkFournisseurAdresse foreign key (FournisseurId) references Fournisseur(FournisseurId);

alter table Fournisseur 
 add constraint fkAdresseFournisseur foreign key (AdresseId) references Adresse(AdresseId);

 alter table Bouteille 
 add constraint fkFournisseurBouteille foreign key (FournisseurId) references Fournisseur(FournisseurId);

 alter table Bouteille
 add constraint fkEmplacementBouteille foreign key (EmplacementId) references Emplacement(EmplacementId);


SELECT * FROM Bouteille
SELECT * FROM Fournisseur
SELECT * FROM Adresse
SELECT * FROM Emplacement