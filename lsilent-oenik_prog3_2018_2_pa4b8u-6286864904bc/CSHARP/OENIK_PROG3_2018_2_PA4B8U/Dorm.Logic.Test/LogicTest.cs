using Dorm.Data;
using Dorm.Repository;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dorm.Logic.Test
{
    /// <summary>
    /// Testing methods in logic
    /// </summary>
    [TestFixture]
    public class LogicTest
    {

        /// <summary>
        /// Testing listing for dorms
        /// </summary>
        [Test]
        public void TestingListingShouldReturnNotEmptyListForDorms()
        {
            // Arrange
            Mock<IRepository> mock = new Mock<IRepository>();
            List<Dorms> dorms = new List<Dorms>()
            {
                new Dorms() { dorm_id="kek", dorm_name="SRRIN", address="Aprajafalva Kismano utca 2", spots=42, phone_num="06406969696"},
                new Dorms() { dorm_id="zad", dorm_name="ZAODI", address="Aprajafalva Közepesmano utca 20", spots=34, phone_num="06607895096"},
                new Dorms() { dorm_id="apg", dorm_name="APGÉS", address="Aprajafalva Nagymano utca 34", spots=56, phone_num="06406969420"},
            };
            // Act
            List<string> expected = new List<string>();
            foreach (Dorms item in dorms)
            {
                expected.Add(string.Format(
                            "Kollégium ID: {0} \t Kollégium név: {1} Cím: {2} Férőhelyek száma: {3} Telefonszám: {4}",
                            item.dorm_id,
                            item.dorm_name,
                            item.address,
                            item.spots,
                            item.phone_num));
            }

            mock.Setup(repo => repo.ListDorms()).Returns(dorms.AsQueryable());
            Logic logika = new Logic(mock.Object);

            // Assert
            var actual = logika.Listing(3);
            Assert.That(actual, Is.EquivalentTo(expected));
            mock.Verify(repo => repo.ListDorms(), Times.Exactly(1));

        }

        /// <summary>
        /// Testing listing for rooms
        /// </summary>
        [Test]
        public void TestingListingOfRoomsShouldNotReturnEmptyList()
        {
            // Arrange
            Mock<IRepository> mock = new Mock<IRepository>();
            List<Rooms> rooms = new List<Rooms>()
            {
                new Rooms() { room_id="asd123", roomnum=123, beds=3, dorm_id="asd"},
                new Rooms() { room_id="asd333", roomnum=333, beds=3, dorm_id="asd"},
                new Rooms() { room_id="asd124", roomnum=124, beds=3, dorm_id="asd"},
            };
            // Act
            List<string> expected = new List<string>();
            foreach (Rooms item in rooms)
            {
                expected.Add(string.Format(
                            "SzobaID: {0} \t Szobaszam: {1} Helyek: {2} KollégiumID: {3}",
                            item.room_id,
                            item.roomnum,
                            item.beds,
                            item.dorm_id));
            }

            mock.Setup(repo => repo.ListRooms()).Returns(rooms.AsQueryable());
            Logic logika = new Logic(mock.Object);

            // Assert
            var actual = logika.Listing(2);
            Assert.That(actual, Is.EquivalentTo(expected));
            mock.Verify(repo => repo.ListRooms(), Times.Exactly(1));
        }

        /// <summary>
        /// testing listing for students
        /// </summary>
        [Test]
        public void TestingListingOfStudentsShoudNotReturnEmptyList()
        {
            // Arrange
            Mock<IRepository> mock = new Mock<IRepository>();
            List<Students> students = new List<Students>()
            {
                new Students() { neptuncode="ASD123", name="andor sandor daniel", email="asd@gmail.com", bdate=DateTime.Parse("01-12-1998"), phone_num="06301234567", room_id="asd123"},
                new Students() { neptuncode="ASD124", name="andor sandor danwdfaiel", email="asfed@gmail.com", bdate=DateTime.Parse("01-11-1998"), phone_num="06301234567", room_id="asd123"},
                new Students() { neptuncode="ASD125", name="andor sandorfsds daniel", email="asdfd@gmail.com", bdate=DateTime.Parse("04-05-1998"), phone_num="06301654767", room_id="asd123"},
                new Students() { neptuncode="ASD126", name="andor sandfsor daniel", email="asdafa@gmail.com", bdate=DateTime.Parse("01-04-1996"), phone_num="06307245647", room_id="asd123"}
            };
            // Act
            List<string> expected = new List<string>();
            foreach (Students item in students)
            {
                expected.Add(string.Format(
                            "Neptunkod: {0} \t Nev: {1} Email: {2} Szul.datum: {3} Tel.szam: {4} SzobaID: {5}",
                            item.neptuncode,
                            item.name,
                            item.email,
                            item.bdate,
                            item.phone_num,
                            item.room_id));
            }

            mock.Setup(repo => repo.ListStudents()).Returns(students.AsQueryable());
            Logic logika = new Logic(mock.Object);

            // Assert
            var actual = logika.Listing(1);
            Assert.That(actual, Is.EquivalentTo(expected));
            mock.Verify(repo => repo.ListStudents(), Times.Exactly(1));
        }

        /// <summary>
        /// Testing adding a student should return false , since there is no existing room to add him to
        /// </summary>
        [Test]
        public void TestAddingStudentShouldReturnFalse()
        {
            // Arrange
            Mock<IRepository> mock = new Mock<IRepository>();

            // Act
            string[] samplestud = new string[6] {
                "ASD123",
                "andor sandor daniel",
                "asd@hotmail.com",
                "01-12-1998",
                "06301234567",
                "asd123"
            };

            Students example = new Students()
            {
                neptuncode = "ASD123",
                name = "andor sandor daniel",
                email = "asd@gmail.com",
                bdate = DateTime.Parse("01-12-1998"),
                phone_num = "06301234567",
                room_id = "asd123"
            };

            mock.Setup(repo => repo.AddStudent(example)).Returns(1);

            // Assert
            Logic logika = new Logic(mock.Object);
            Assert.That(logika.Adding(samplestud), Is.False);
            mock.Verify(repo => repo.AddStudent(example), Times.Never);
        }

        /// <summary>
        /// Testin adding room should return false since there is no existing dorm to add it to
        /// </summary>
        [Test]
        public void TestingAddingRoomShouldReturnFalse()
        {
            // Arrange
            Mock<IRepository> mock = new Mock<IRepository>();

            // Act
            string[] sampleroom = new string[4] {
                "asd123",
                "123",
                "3",
                "asd"
            };

            Rooms example = new Rooms()
            {
                room_id = "asd123",
                roomnum = 123,
                beds = 3,
                dorm_id = "asd"
            };

            mock.Setup(repo => repo.AddRoom(example)).Returns(1);

            // Assert
            Logic logika = new Logic(mock.Object);
            Assert.That(logika.Adding(sampleroom), Is.False);
            mock.Verify(repo => repo.AddRoom(example), Times.Never);
        }

        /// <summary>
        /// Testing adding dorm should return true since it is the highest in the hierarchy
        /// </summary>
        [Test]
        public void TestingAddingDormShouldReturnTrue()
        {
            // Arrange
            Mock<IRepository> mock = new Mock<IRepository>();

            // Act
            string[] sampledorm = new string[5] {
                "asd",
                "Asd dorm",
                "asd str 8",
                "123",
                "03642536148"
            };

            Dorms example = new Dorms()
            {
                dorm_id = "asd",
                dorm_name = "Asd dorm",
                address = "asd str 8",
                spots = 123,
                phone_num = "03642536148"
            };

            mock.Setup(repo => repo.AddDorm(example)).Returns(3);

            // Assert
            Logic logika = new Logic(mock.Object);
            Assert.That(logika.Adding(sampledorm), Is.True);
            mock.Verify(repo => repo.AddDorm(example), Times.Once);
        }

        /// <summary>
        /// Testing deleting a dorm from database returns false since its an empty database
        /// </summary>
        [Test]
        public void TestingDeletingDormShouldReturnFalse()
        {
            // Arrange
            Mock<IRepository> mock = new Mock<IRepository>();

            Dorms dorm = new Dorms() { dorm_id = "kek", dorm_name = "SRRIN", address = "Aprajafalva Kismano utca 2", spots = 42, phone_num = "06406969696" };
            string key = "kek";

            // Act
            Logic logika = new Logic(mock.Object);

            // Assert
            Assert.That(logika.Deleting(key), Is.False);
            mock.Verify(repo => repo.DeleteDorm(dorm), Times.Never);
        }

        /// <summary>
        /// Testing deleting a room from database returns false since its an empty database
        /// </summary>
        [Test]
        public void TestingDeletingRoomShouldReturnFalse()
        {
            // Arrange
            Mock<IRepository> mock = new Mock<IRepository>();

            Rooms room = new Rooms() { room_id = "asd123", roomnum = 123, beds = 3, dorm_id = "asd" };
            string key = "asd123";

            // Act
            Logic logika = new Logic(mock.Object);

            // Assert
            Assert.That(logika.Deleting(key), Is.False);
            mock.Verify(repo => repo.DeleteRoom(room), Times.Never);
        }

        /// <summary>
        /// Testing deleting a student from database returns false since its an empty database
        /// </summary>
        [Test]
        public void TestingDeletingStudentShouldReturnFalse()
        {
            // Arrange
            Mock<IRepository> mock = new Mock<IRepository>();

            Students stud = new Students() { neptuncode = "ASD123", name = "andor sandor daniel", email = "asd@gmail.com", bdate = DateTime.Parse("01-12-1998"), phone_num = "06301234567", room_id = "asd123" };
            string key = "ASD123";

            // Act
            Logic logika = new Logic(mock.Object);

            // Assert
            Assert.That(logika.Deleting(key), Is.False);
            mock.Verify(repo => repo.DeleteStudent(stud), Times.Never);
        }

        /// <summary>
        /// Testing modifying student
        /// </summary>
        [Test]
        public void TestingModifyingStudentShouldReturnFalse()
        {
            // Arrange
            Mock<IRepository> mock = new Mock<IRepository>();

            Students studold = new Students() { neptuncode = "ASD123", name = "andor sandor daniel", email = "asd@gmail.com", bdate = DateTime.Parse("01-12-1998"), phone_num = "06301234567", room_id = "asd123" };
            Students studnew = new Students() { neptuncode = "ASD123", name = "andor sandor", email = "asd@gmail.com", bdate = DateTime.Parse("01-12-1998"), phone_num = "06301234567", room_id = "asd123" };
            string[] samplestud = new string[6] {
                "ASD123",
                "andor sandor daniel",
                "asd@hotmail.com",
                "01-12-1998",
                "06301234567",
                "asd123"
            };

            // Act
            Logic logika = new Logic(mock.Object);

            // Assert
            Assert.That(logika.Modifying(samplestud), Is.False);
            mock.Verify(repo => repo.ModifyStudent(studold, studnew), Times.Never);
        }

        /// <summary>
        /// Testing modifying room
        /// </summary>
        [Test]
        public void TestingModifyingRoomShouldReturnFalse()
        {
            // Arrange
            Mock<IRepository> mock = new Mock<IRepository>();

            Rooms oldroom = new Rooms() { room_id = "asd123", roomnum = 123, beds = 3, dorm_id = "asd" };
            Rooms newroom = new Rooms() { room_id = "asd123", roomnum = 123, beds = 5, dorm_id = "asd" };
            string[] sampleroom = new string[4] {
                "asd123",
                "123",
                "3",
                "asd"
            };

            // Act
            Logic logika = new Logic(mock.Object);

            // Assert
            Assert.That(logika.Modifying(sampleroom), Is.False);
            mock.Verify(repo => repo.ModifyRoom(oldroom, newroom), Times.Never);
        }

        /// <summary>
        /// Modifyingdorms should return false since its an empty database
        /// </summary>
        [Test]
        public void TestingModifyingDormShouldReturnFalse()
        {
            // Arrange
            Mock<IRepository> mock = new Mock<IRepository>();

            Dorms olddorm = new Dorms() { dorm_id = "kek", dorm_name = "SRRIN", address = "Aprajafalva Kismano utca 2", spots = 42, phone_num = "06406969696" };
            Dorms newdorm = new Dorms() { dorm_id = "kek", dorm_name = "SRRIN", address = "Aprajafalva nagymano utca 2", spots = 42, phone_num = "06406969696" };
            string[] sampledorm = new string[5] {
                "kek",
                "SRRIN",
                "Aprajafalva nagymano utca 2",
                "42",
                "06406969696"
            };

            // Act
            Logic logika = new Logic(mock.Object);

            // Assert
            Assert.That(logika.Modifying(sampledorm), Is.False);
            mock.Verify(repo => repo.ModifyDorm(olddorm, newdorm), Times.Never);
        }

        /// <summary>
        /// Testing oldest student query, return the oldest student in database
        /// </summary>
        [Test]
        public void TestingOldestStudentShouldReturnSoros()
        {
            // Arrange
            Mock<IRepository> mock = new Mock<IRepository>();
            List<Students> students = new List<Students>()
            {
                new Students() { neptuncode="ASD123", name="andor sandor daniel", email="asd@gmail.com", bdate=DateTime.Parse("01-12-1998"), phone_num="06301234567", room_id="asd123"},
                new Students() { neptuncode="ASD124", name="andor sandor danwdfaiel", email="asfed@gmail.com", bdate=DateTime.Parse("01-11-1998"), phone_num="06301234567", room_id="asd123"},
                new Students() { neptuncode="ASD125", name="andor sandorfsds daniel", email="asdfd@gmail.com", bdate=DateTime.Parse("04-05-1998"), phone_num="06301654767", room_id="asd123"},
                new Students() { neptuncode="ASD126", name="andor sandfsor daniel", email="asdafa@gmail.com", bdate=DateTime.Parse("01-04-1980"), phone_num="06307245647", room_id="asd123"}
            };
            
            // Act
            mock.Setup(repo => repo.ListStudents()).Returns(students.AsQueryable);
            Logic logika = new Logic(mock.Object);
            
            // Assert
            Assert.That(logika.OldStud(), Is.EquivalentTo("andor sandfsor daniel"));
            mock.Verify(repo => repo.ListStudents(), Times.Once);
        }

        /// <summary>
        /// Testing dormsbyplaces method, that list all dorm names in order of spots
        /// </summary>
        [Test]
        public void TestingDormByPlaceShouldReturnDormsInCorrectOrder()
        {
            // Arrange
            Mock<IRepository> mock = new Mock<IRepository>();
            List<Dorms> dorms = new List<Dorms>()
            {
                new Dorms() { dorm_id="kek", dorm_name="SRRIN", address="Aprajafalva Kismano utca 2", spots=42, phone_num="06406969696"},
                new Dorms() { dorm_id="zad", dorm_name="ZAODI", address="Aprajafalva Közepesmano utca 20", spots=34, phone_num="06607895096"},
                new Dorms() { dorm_id="apg", dorm_name="APGÉS", address="Aprajafalva Nagymano utca 34", spots=56, phone_num="06406969420"},
            };

            List<string> dormsinorder = new List<string>
            {
                "APGÉS",
                "SRRIN",
                "ZAODI"
            };
            // Act
            mock.Setup(repo => repo.ListDorms()).Returns(dorms.AsQueryable);
            Logic logika = new Logic(mock.Object);

            // Assert
            Assert.That(logika.DormByPlace(), Is.EquivalentTo(dormsinorder));
            mock.Verify(repo => repo.ListDorms(), Times.Once);
        }

        /// <summary>
        /// Testing students in dorms should return true
        /// </summary>
        [Test]
        public void TestingStudentsInDormsShouldReturnTrue()
        {
            // Arrange
            Mock<IRepository> mock = new Mock<IRepository>();
            List<Dorms> dorms = new List<Dorms>()
            {
                new Dorms() { dorm_id="asd", dorm_name="SRRIN", address="Aprajafalva Kismano utca 2", spots=42, phone_num="06406969696"},
                new Dorms() { dorm_id="zad", dorm_name="ZAODI", address="Aprajafalva Közepesmano utca 20", spots=34, phone_num="06607895096"},
                new Dorms() { dorm_id="apg", dorm_name="APGÉS", address="Aprajafalva Nagymano utca 34", spots=56, phone_num="06406969420"},
            };

            List<Rooms> rooms = new List<Rooms>()
            {
                new Rooms() { room_id="asd123", roomnum=123, beds=3, dorm_id="asd"},
                new Rooms() { room_id="asd125", roomnum=125, beds=3, dorm_id="apg"},
                new Rooms() { room_id="asd124", roomnum=124, beds=3, dorm_id="zad"},
            };

            List<Students> students = new List<Students>()
            {
                new Students() { neptuncode="ASD123", name="andor sandor daniel", email="asd@gmail.com", bdate=DateTime.Parse("01-12-1998"), phone_num="06301234567", room_id="asd123"},
                new Students() { neptuncode="ASD124", name="andor sandor danwdfaiel", email="asfed@gmail.com", bdate=DateTime.Parse("01-11-1998"), phone_num="06301234567", room_id="asd123"},
                new Students() { neptuncode="ASD125", name="andor sandorfsds daniel", email="asdfd@gmail.com", bdate=DateTime.Parse("04-05-1998"), phone_num="06301654767", room_id="asd124"},
                new Students() { neptuncode="ASD126", name="andor daniel", email="asdafa@gmail.com", bdate=DateTime.Parse("01-04-1996"), phone_num="06307245647", room_id="asd125"}
            };

            // Act
            mock.Setup(repo => repo.ListStudents()).Returns(students.AsQueryable);
            mock.Setup(repo => repo.ListRooms()).Returns(rooms.AsQueryable);
            mock.Setup(repo => repo.ListDorms()).Returns(dorms.AsQueryable);
            Logic logika = new Logic(mock.Object);

            // Assert
            Assert.That(logika.StudentInDorm(), Is.True);
            mock.Verify(repo => repo.ListDorms(), Times.Once);
            mock.Verify(repo => repo.ListStudents(), Times.Once);
            mock.Verify(repo => repo.ListRooms(), Times.Once);
        }
    }
}
