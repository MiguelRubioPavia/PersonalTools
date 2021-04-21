CREATE TABLE AppVersion (
	Version TEXT,
	LastUpdated TEXT
);

CREATE TABLE FamilyGroups (
	FamilyGroupId INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT,
	Code NVARCHAR(100) NOT NULL
);

CREATE TABLE Families (
	FamilyId INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT,
	FamilyGroupId INTEGER NOT NULL,
	Code NVARCHAR(100) NOT NULL,
	CONSTRAINT Fk_Families_FamilyGroups FOREIGN KEY (FamilyGroupId) REFERENCES FamilyGroups(FamilyGroupId) ON DELETE RESTRICT
);

CREATE TABLE SubFamilies (
	SubFamilyId INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT,
	FamilyId INTEGER NOT NULL,
	Code NVARCHAR(100) NOT NULL,
	CONSTRAINT Fk_SubFamilies_Families FOREIGN KEY (FamilyId) REFERENCES Families(FamilyId) ON DELETE RESTRICT
);

CREATE TABLE FinanceMovements (
	FinanceMovementId INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT,
	Date INTEGER NOT NULL,
	Concept TEXT NOT NULL,
	Comment TEXT,
	Quantity NUMERIC DEFAULT 1,
	Amount NUMERIC DEFAULT 0,
	SubFamilyId INTEGER NOT NULL,
	IsBreakdown INTEGER DEFAULT 0,
	BreakDownId INTEGER,
	CONSTRAINT Fk_FinanceMovements_SubFamilies FOREIGN KEY (SubFamilyId) REFERENCES SubFamilies(SubFamilyId) ON DELETE RESTRICT,
	CONSTRAINT Fk_FinanceMovements_FinanceMovements FOREIGN KEY (BreakDownId) REFERENCES FinanceMovements(FinanceMovementId) ON DELETE CASCADE
);

CREATE INDEX Idx_FinanceMovements_Date ON FinanceMovements (Date);

INSERT INTO AppVersion('Version', 'LastUpdated') VALUES ('0.0.1', date('now'));