CREATE TABLE IF NOT EXISTS InteractedUsersTableV1(Id INT PRIMARY KEY AUTO_INCREMENT, UserIdentifier VARCHAR(15)) ENGINE=INNODB;

CREATE TABLE IF NOT EXISTS InvUserTableV1(Id INT PRIMARY KEY AUTO_INCREMENT, UserIdentifier VARCHAR(15), Level VARCHAR(10), Firstname NVARCHAR(20), Lastname NVARCHAR(20), City NVARCHAR(20), PhoneNumber NVARCHAR(20), CourseDegree NVARCHAR(30), IAG VARCHAR(5), CG VARCHAR(5), PSG VARCHAR(5), DG VARCHAR(5), KW VARCHAR(5), PR VARCHAR(5), EXCV VARCHAR(5), EXMD VARCHAR(5), EXPS VARCHAR(5), EXSP VARCHAR(5), EXJC VARCHAR(5), EXTC VARCHAR(5), EXOT VARCHAR(5), FM VARCHAR(5), MD VARCHAR(5), IT VARCHAR(5), MG VARCHAR(5)) ENGINE=INNODB;

CREATE TABLE IF NOT EXISTS SndUserTableV1(Id INT PRIMARY KEY AUTO_INCREMENT, UserIdentifier VARCHAR(15), Level VARCHAR(10), Firstname NVARCHAR(20), Lastname NVARCHAR(20), City NVARCHAR(20), FullAddress NVARCHAR(100), PhoneNumber NVARCHAR(20), CourseDegree NVARCHAR(30), AdditionalDescription NVARCHAR(100)) ENGINE=INNODB;

--CREATE TABLE IF NOT EXISTS NonAlwaysInvitationTableV1(Id INT PRIMARY KEY AUTO_INCREMENT, UserIdentifier VARCHAR(15), Level VARCHAR(10), IAG VARCHAR(5), CG VARCHAR(5), PSG VARCHAR(5), DG VARCHAR(5), KW VARCHAR(5)) ENGINE=INNODB;

--CREATE TABLE IF NOT EXISTS AlwaysInvitationTableV1(Id INT PRIMARY KEY AUTO_INCREMENT, UserIdentifier VARCHAR(15), Level VARCHAR(10), PR VARCHAR(5), EXCV VARCHAR(5), EXMD VARCHAR(5), EXPS VARCHAR(5), EXSP VARCHAR(5), EXJC VARCHAR(5), EXTC VARCHAR(5), EXOT VARCHAR(5), FM VARCHAR(5), MD VARCHAR(5), IT VARCHAR(5), MG VARCHAR(5)) ENGINE=INNODB;

--CREATE TABLE IF NOT EXISTS SendersTableV2(Id INT PRIMARY KEY AUTO_INCREMENT, UserIdentifier VARCHAR(15), Level VARCHAR(10), AdditionalDescription NVARCHAR(100)) ENGINE=INNODB;

SET character_set_results=utf8,character_set_client=utf8,character_set_connection=utf8, character_set_database=utf8,character_set_server=utf8;

INSERT INTO VolunteerTableV4 (UserIdentifier,Firstname,Lastname,Fathersname,Gender,Marriage,CellPhone,NationalCode,BirthPlace,BirthDate,UniversityCourse,UniversityPlace,CourseDegree,Level) SELECT UserIdentifier, Firstname, Lastname, Fathersname, Gender, Marriage, CellPhone, NationalCode, BirthPlace, BirthDate, UniversityCourse, UniversityPlace, CourseDegree, Level FROM VolunteerTableV2;

-- Check MainMenu(s)