Create Database Batch_Advisory
Use Batch_Advisory


GO

drop table if exists Advisor
drop table if exists Students
drop table if exists Batch
drop table if exists Courses
drop table if exists Terms
CREATE TABLE Terms
(
	[TermID] VARCHAR(3) NOT NULL PRIMARY KEY,
	TermName varchar(6)
)
Insert into Terms values
('SPR','Spring'),
('WIN','Winter'),
('SUM','Summer'),
('AUT','Autumn')


go
drop table if exists Courses
Create Table Courses
(
Course_Code varchar(5) primary key NOT NULL,
CourseName varchar(max) NOT NULL,
CreditHour int check(CreditHour>2),
Prerequsite_Course varchar(5),
OnYear int check(OnYear<5 AND OnYear>0) NOT NULL,
OnTerm varchar(3) NOT NULL,
)

alter table Courses
add constraint PreCourse
foreign key (Prerequsite_Course) references Courses(Course_Code)

alter table Courses
add constraint CourseTerm
foreign key (OnTerm) references Terms(TermID)

go

drop table if exists Advisor
drop table if exists Students
drop table if exists Batch
Create Table Batch
(
BatchID varchar(7) primary key NOT NULL,
BatchSize int NOT NULL,
CurrentYear int check(CurrentYear<5 AND CurrentYear>0) NOT NULL,
CurrentTerm varchar(3) NOT NULL,
TotalCourses int
)


alter table Batch
add constraint BatchTerm
foreign key (CurrentTerm) references Terms(TermID)

GO

drop table if exists Students
Create Table Students
(
SRC varchar(6) primary key NOT NULL,
Name varchar(max) NOT NULL,
Batch varchar(7) NOT NULL,
GPA float,
Password varchar(max) NOT NULL,
CoursesCompleted int,
CoursesRegistered int
)



alter table Students
add constraint StudentBatch_Fk
foreign key (Batch) references Batch(BatchID)


GO

drop table if exists Advisor
Create Table Advisor
(
ID int primary key NOT NULL,
Name varchar(max) NOT NULL,
AssignedBatch varchar(7) NOT NULL,
Password varchar(max) NOT NULL,
)

alter table Advisor
add constraint AdvisorBatch_Fk
foreign key (AssignedBatch) references Batch(BatchID)

GO

drop table if exists ClassRoom
Create Table ClassRoom
(
Room varchar(6) NOT NULL primary key,
Class_Size int NOT NULL,
Available int NOT NULL
)

/*Select Students.Name,Students.SRC,Students.Class
From Students
Join Advisor on Students.SRC=Advisor.ID; 
*/
GO

Insert into Advisor Values
(1,'Abebe','DRB1902','1234')

select*from Advisor


insert into ClassRoom values
('LEC201',60,10),
('LEC202',55,9),
('LEC301',60,14),
('LEC302',50,15),
('LEC303',45,5),
('LEC401',60,17),
('LEC501',45,10)


Insert into Batch values
('DRB1901',70,4,'SPR',36),
('DRB1902',80,3,'SUM',32),
('DRB2001',50,3,'SPR',28),
('DRB2002',124,3,'SUM',24),
('DRB2101',110,2,'SPR',20),
('DRB2102',90,2,'SUM',16),
('DRB2201',80,1,'SPR',8),
('DRB2202',160,1,'SUM',0)

SELECT * FROM [Batch_Advisory].[dbo].[Batch]


insert into Courses values
('CS211','ICT Fundamentals',5,NULL,1,'SPR'),
('CS221','Computer Programming I',5,NULL,1,'SPR'),
('CS222','Computer programming II',5,'CS221',1,'SUM'),
('CS223','Windows Programming',5,NULL,1,'SPR'),
('CS224','Object Oriented programming',5,NULL,1,'SPR'),
('CS262','Introduction To UNIX',3,NULL,1,'SUM'),
('CS301','Logic Design',4,NULL,1,'SUM'),
('CS302','Computer Org And Ass Lang Prog',5,NULL,1,'SUM'),
('CS321','Data Structure and Algorithm Analysis',5,NULL,1,'AUT'),
('CS322','Web Design & Development I',5,NULL,1,'AUT'),
('CS323','Web Design & Development II',4,'CS323',2,'WIN'),
('CS341','Database Management Systems',5,NULL,1,'AUT'),
('CS342','Database Programming & Administration',5,'CS341',2,'WIN'),
('CS343','System Analysis & Design',4,NULL,1,'AUT'),
('CS363','Operating Systems',4,NULL,2,'WIN'),
('CS446','Object Oriented Software Engineering',4,NULL,2,'WIN'),
('CS461','Computer Networks',5,NULL,2,'SPR'),
('CS465','Computer Administration',4,NULL,2,'SPR'),
('CS485','Infromation Retrieval',4,NULL,2,'SPR'),
('CS486','Computer Systems Security',5,NULL,2,'SPR'),
('CC111','Introduction To Emerging Technologies',4,NULL,2,'SUM'),
('CC112','Critical Thinking',4,NULL,2,'SUM'),
('CC113','General Psychology',4,NULL,2,'SUM'),
('CC114','Social Anthropology',3,NULL,2,'SUM'),
('CC115','Moral And Civics Education',4,NULL,3,'AUT'),
('CC121','Geography Of Ethiopia And The Horn',4,NULL,3,'AUT'),
('CC122','History Of Ethiopia And The Horn',4,NULL,3,'AUT'),
('CC130','Mathematics For Natural Science',4,NULL,3,'AUT'),
('CC140','General Physics',3,NULL,3,'WIN'),
('CC150','English Lang Skills I',4,NULL,3,'WIN'),
('CC151','English Lang Skills II',4,'CC150',3,'SPR'),
('CC213','Inclusiveness',3,NULL,3,'WIN'),
('CC214','Global Trends',3,NULL,3,'WIN'),
('CC234','Statistics And Probability',4,NULL,3,'SPR'),
('CC313','Economics',4,NULL,3,'SPR'),
('CC399','Entrepreneurship',4,NULL,3,'SPR'),
('CS362','Unix Systems Administration',5,NULL,4,'SPR'),
('CS415','Focusing Area In ICT',3,NULL,4,'SUM'),
('CS427','Compiler Design',4,NULL,4,'SUM'),
('CS447','Data Mining',4,NULL,4,'SUM'),
('CS448','Software Testing',4,NULL,4,'AUT'),
('CS468','Mobile Application',4,NULL,4,'AUT'),
('CS481','IT Research Methods',4,NULL,4,'AUT'),
('CS488','Artificial Intelligence',4,NULL,4,'AUT'),
('CS489','Computer Graphics',4,NULL,4,'WIN'),
('CS497','Geographic Info System',5,NULL,4,'WIN'),
('CS500','Senior Project',6,NULL,4,'SPR')

SELECT * FROM [Batch_Advisory].[dbo].[Courses] ORDER BY [OnYear] ASC ,[OnTerm]

insert into Students values
('AB1234','Abebe Balcha','DRB1901',3.26,'1234',33,3),
('BC1234','Kebede Girma','DRB1901',3.75,'1234',36,4),
('CD1234','Bekele David','DRB1902',2.56,'1234',30,1),
('DE1234','Michael Belayneh','DRB1902',2.75,'1234',24,2),
('EF1234','Samrawit Meshehsa','DRB2001',3.81,'1234',20,4),
('FG1234','Firehiwot Tamiru','DRB1901',2.22,'1234',30,2)

Select * From Students


Select * From Batch

GO
CREATE PROCEDURE AvailableCourses
AS
SELECT Courses.Course_Code, Courses.CourseName, Courses.CreditHour, Courses.Prerequsite_Course , Batch.BatchID AS 'Batch Taking Course'
FROM Courses INNER JOIN Batch 
ON Batch.CurrentYear=Courses.OnYear AND Batch.CurrentTerm=Courses.OnTerm
ORDER BY Batch.BatchID DESC
EXEC AvailableCourses

Select count(Course_Code) From Courses


CREATE TABLE CoursesTaken
(
	SRC varchar(6) NOT NULL,
	Course_Code varchar(5) NOT NULL,
	Grade varchar(2) NOT NULL
)
alter table CoursesTaken
add constraint CoursesTakenSRC_Fk
foreign key (SRC) references Students(SRC)

alter table CoursesTaken
add constraint CoursesTakenCode_Fk
foreign key (Course_Code) references Courses(Course_Code)

CREATE TABLE CoursesRegistered
(
	SRC varchar(6) NOT NULL,
	Course_Code varchar(5) NOT NULL,
)
alter table CoursesRegistered
add constraint CoursesRegisteredSRC_Fk
foreign key (SRC) references Students(SRC)

alter table CoursesRegistered
add constraint CoursesRegisteredCode_Fk
foreign key (Course_Code) references Courses(Course_Code)

Insert into CoursesTaken Values
('AB1234','CS461','AD'),
('AB1234','CS461','F'),
('AB1234','CC150','F'),
('AB1234','CS211','A'),
('AB1234','CS221','B'),
('AB1234','CS222','F'),
('AB1234','CS211','C')

Insert into CoursesRegistered Values
('AB1234','CS362'),
('AB1234','CS500')


Select Course_Code from Courses 

GO

ALTER PROCEDURE EligibleCourses @id varchar(6) 
AS
SELECT Courses.Course_Code, Courses.CourseName, Courses.CreditHour, Courses.Prerequsite_Course ,Batch.BatchID AS 'Batch Taking Course'
FROM Courses INNER JOIN Batch
ON Batch.CurrentYear=Courses.OnYear AND Batch.CurrentTerm=Courses.OnTerm 
INNER JOIN CoursesTaken 
ON Courses.Course_Code=CoursesTaken.Course_Code
WHERE CoursesTaken.SRC=@id AND CoursesTaken.Grade='F'
ORDER BY Courses.CourseName DESC

EXEC EligibleCourses @id='AB1234'

Select * from CoursesTaken