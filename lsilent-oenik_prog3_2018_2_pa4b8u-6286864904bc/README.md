# FF_PA4B8U

Third semester webprograming and advenced development techniques project.

Tables:
Students: neptuncode, name, email, birthdate, phone_num, room_id
VALUES('PA4B8U','Csendes Lõrinc','csendes.lorinc@gmail.com','25-FEB-1998',06207789668,'kak504');
VALUES('CH3VR3','Balogh Attila','balogh.attila@gmail.com','27-SEP-1997',06307895674,'kak504');
VALUES('SOROS1','Soros Györgyi','soros.gyorgyi@gmail.com','12-AUG-1930',06705572666,'kak708');
VALUES('0RB4NV','Orbán Viktoria','orbanvitya63@gmail.com','31-MAY-1963',06306767834,'kak708');
VALUES('M3SZ11','Mészáros Laura','meszaroslorincz@hotmail.com','24-FEB-1966',06705566778,'kak708');

Rooms: room_id, room_num, beds, dorm_id
VALUES('kak504',504,4,'kak');
VALUES('kak501',501,4,'kak');
VALUES('kak708',708,3,'kak');
VALUES('hbd504',504,2,'hbd');
VALUES('geo102',102,4,'geo');

Dorms: dorm_id, dorm_name, address, spots, phone_num
VALUES('kak','Kiss Árpád Kollégium','Doberdo út 6',159,06301234567);
VALUES('hbd','Hotel@BMF diákotthon','Tavaszmezõ út 13',200,06307654321);
VALUES('geo','Geo Kollégium','Hosszúsétatér 8',159,0622200448);


Querys:

OldStud() : retuns the oldest student from database

DormByPlace() : returns the name od dorms in order of spots descanding

StudentInDorm() : returns the students name, the room thye live and the name of the dorm