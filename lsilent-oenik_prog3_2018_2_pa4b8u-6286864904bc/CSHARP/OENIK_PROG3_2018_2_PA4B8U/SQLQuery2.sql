IF OBJECT_ID('Students', 'U') IS NOT NULL DROP TABLE Students;
IF OBJECT_ID('Rooms', 'U') IS NOT NULL DROP TABLE Rooms;
IF OBJECT_ID('Dorms', 'U') IS NOT NULL DROP TABLE Dorms;

CREATE TABLE Dorms
(dorm_id			VARCHAR(3),
 dorm_name			VARCHAR(40) UNIQUE,
 address			VARCHAR(50) not null,
 spots				NUMERIC(3),
 phone_num			VARCHAR(11),
 CONSTRAINT DORM_PRIMARY_KEY PRIMARY KEY (dorm_id)
);

INSERT INTO Dorms(dorm_id,dorm_name,address,spots,phone_num)
VALUES('kak','Kiss Árpád Kollégium','Doberdo út 6',159,06301234567);

INSERT INTO Dorms(dorm_id,dorm_name,address,spots,phone_num)
VALUES('hbd','Hotel@BMF diákotthon','Tavaszmező út 13',200,06307654321);

INSERT INTO Dorms(dorm_id,dorm_name,address,spots,phone_num)
VALUES('geo','Geo Kollégium','Hosszúsétatér 8',159,0622200448);

CREATE TABLE Rooms
(room_id			VARCHAR(6),
 roomnum			NUMERIC(3),
 beds				NUMERIC(1),
 dorm_id			VARCHAR(3),
 CONSTRAINT ROOM_PRIMARY_KEY PRIMARY KEY (room_id),
 CONSTRAINT DORM_FOREIGN_KEY FOREIGN KEY (dorm_id) REFERENCES Dorms (dorm_id)
);

INSERT INTO Rooms VALUES('kak504',504,4,'kak');

INSERT INTO Rooms(room_id,roomnum,beds,dorm_id)
VALUES('kak501',501,4,'kak');

INSERT INTO Rooms(room_id,roomnum,beds,dorm_id)
VALUES('kak708',708,3,'kak');

INSERT INTO Rooms(room_id,roomnum,beds,dorm_id)
VALUES('hbd504',504,2,'hbd');

INSERT INTO Rooms(room_id,roomnum,beds,dorm_id)
VALUES('geo102',102,4,'geo');

CREATE TABLE Students
(neptuncode			VARCHAR(6),
 name				VARCHAR(30),
 email				VARCHAR(40),
 bdate				DATETIME,
 phone_num			VARCHAR(11),
 room_id			VARCHAR(6),
 CONSTRAINT STUD_PRIMARY_KEY PRIMARY KEY (neptuncode),
 CONSTRAINT ROOM_FOREIGN_KEY FOREIGN KEY (room_id) REFERENCES Rooms (room_id)
);

INSERT INTO Students(neptuncode,name,email,bdate,phone_num,room_id)
VALUES('PA4B8U','Csendes Lőrinc','csendes.lorinc@gmail.com','25-FEB-1998',06207789668,'kak504');

INSERT INTO Students(neptuncode,name,email,bdate,phone_num,room_id)
VALUES('CH3VR3','Balogh Attila','balogh.attila@gmail.com','27-SEP-1997',06307895674,'kak504');

INSERT INTO Students(neptuncode,name,email,bdate,phone_num,room_id)
VALUES('SOROS1','Soros Györgyi','soros.gyorgyi@gmail.com','12-AUG-1930',06705572666,'kak708');

INSERT INTO Students(neptuncode,name,email,bdate,phone_num,room_id)
VALUES('0RB4NV','Orbán Viktoria','orbanvitya63@gmail.com','31-MAY-1963',06306767834,'kak708');

INSERT INTO Students(neptuncode,name,email,bdate,phone_num,room_id)
VALUES('M3SZ11','Mészáros Laura','meszaroslorincz@hotmail.com','24-FEB-1966',06705566778,'kak708');
 