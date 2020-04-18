// <copyright file="Logic.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Dorm.Logic
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Dorm.Data;
    using Dorm.Repository;

    /// <summary>
    /// Logic class
    /// </summary>
    public class Logic : ILogic
    {
        private readonly IRepository repo;

        /// <summary>
        /// Initializes a new instance of the <see cref="Logic"/> class.
        /// Logic constructor
        /// </summary>
        /// <param name="repo"> repo interface </param>
        public Logic(IRepository repo)
        {
            this.repo = repo;
        }

        /// <summary>
        /// List the items in database
        /// </summary>
        /// <param name="num">type of database</param>
        /// 1 for Students, 2 for Rooms, 3 for Dorms
        /// <returns>retuns a string list with the choosen type of data</returns>
        public List<string> Listing(int num)
        {
            switch (num)
            {
                case 1:
                    List<string> studlist = new List<string>();
                    foreach (Students item in this.repo.ListStudents())
                    {
                        studlist.Add(string.Format(
                            "Neptunkod: {0} \t Nev: {1} Email: {2} Szul.datum: {3} Tel.szam: {4} SzobaID: {5}",
                            item.neptuncode,
                            item.name,
                            item.email,
                            item.bdate,
                            item.phone_num,
                            item.room_id));
                    }

                    return studlist;
                case 2:
                    List<string> roomlist = new List<string>();
                    foreach (Rooms item in this.repo.ListRooms())
                    {
                        roomlist.Add(string.Format(
                            "SzobaID: {0} \t Szobaszam: {1} Helyek: {2} KollégiumID: {3}",
                            item.room_id,
                            item.roomnum,
                            item.beds,
                            item.dorm_id));
                    }

                    return roomlist;
                case 3:
                    List<string> dormlist = new List<string>();
                    foreach (Dorms item in this.repo.ListDorms())
                    {
                        dormlist.Add(string.Format(
                            "Kollégium ID: {0} \t Kollégium név: {1} Cím: {2} Férőhelyek száma: {3} Telefonszám: {4}",
                            item.dorm_id,
                            item.dorm_name,
                            item.address,
                            item.spots,
                            item.phone_num));
                    }

                    return dormlist;
                default:
                    List<string> asd = new List<string>();
                    return asd;
            }
        }

        /// <summary>
        /// Adds an object to the database
        /// </summary>
        /// <param name="data">properties of the object</param>
        /// <returns>return true if adding was succesful</returns>
        public bool Adding(string[] data)
        {
            switch (data.Length)
            {
                case 6:
                    Console.Clear();
                    if (this.CheckKey(data[0], 1) == true && this.CheckKey(data[5], 2) == false)
                    {
                        Students student = new Students()
                        {
                            neptuncode = data[0],
                            name = data[1],
                            email = data[2],
                            bdate = DateTime.Parse(data[3]),
                            phone_num = data[4],
                            room_id = data[5]
                        };

                        int done = this.repo.AddStudent(student);
                        if (done == 1)
                        {
                            return true;
                        }
                        else
                        {
                            return false;
                        }
                    }
                    else
                    {
                        Console.WriteLine("Valamilyen adatot rosszul adtál meg," +
                            "vagy ilyen IDs hallgato már van," +
                            " esteleg nincs olyan szoba amibe be akartad rakni");
                        return false;
                    }

                case 4:
                    if (this.CheckKey(data[0], 2) == true && this.CheckKey(data[3], 3) == false)
                    {
                        Rooms room = new Rooms()
                        {
                            room_id = data[0],
                            roomnum = int.Parse(data[1]),
                            beds = int.Parse(data[2]),
                            dorm_id = data[3]
                        };

                        int done = this.repo.AddRoom(room);
                        if (done == 2)
                        {
                            Console.WriteLine("Sikeresen hozzáadva");
                            return true;
                        }
                        else
                        {
                            return false;
                        }
                    }
                    else
                    {
                        Console.WriteLine("Valamilyen adatot rosszul adtál meg," +
                            "van már ilyen azonosítoju szoba," +
                            "esetleg nem létezik a kollégium ahova hozzá akartad adni");
                        return false;
                    }

                case 5:
                    if (this.CheckKey(data[0], 3) == true)
                    {
                        Dorms dorm = new Dorms()
                        {
                            dorm_id = data[0],
                            dorm_name = data[1],
                            address = data[2],
                            spots = int.Parse(data[3]),
                            phone_num = data[4]
                        };
                        int done = this.repo.AddDorm(dorm);
                        if (done == 3)
                        {
                            Console.WriteLine("Sikeresen hozzáadva");
                            return true;
                        }
                        else
                        {
                            return false;
                        }
                    }
                    else
                    {
                        Console.WriteLine("Valamilyen adatot rosszul adtál meg," +
                            "vagy van már ilyen azonositoval rendelkezö kollégium.");
                        return false;
                    }

                default:
                    Console.WriteLine("Rossz választ adtál meg!");
                    return false;
            }
        }

        /// <summary>
        /// Deletes an object from database
        /// </summary>
        /// <param name="key">ID of the object that will be deleted</param>
        /// <returns>return true</returns>
        public bool Deleting(string key)
        {
            if (key.Length == 3)
            {
                foreach (Dorms item in this.repo.ListDorms())
                {
                    if (item.dorm_id == key)
                    {
                        Dorms delete = item;
                        this.repo.DeleteDorm(delete);
                        return true;
                    }
                }
            }
            else
            {
                foreach (Students item in this.repo.ListStudents())
                {
                    if (item.neptuncode == key)
                    {
                        Students delete = item;
                        this.repo.DeleteStudent(delete);
                        return true;
                    }
                }

                foreach (Rooms item in this.repo.ListRooms())
                {
                    if (item.room_id == key)
                    {
                        Rooms delete = item;
                        this.repo.DeleteRoom(delete);
                        return true;
                    }
                }
            }

            return false;
        }

        /// <summary>
        /// Modifys an object in database
        /// </summary>
        /// <param name="data">properties of the object</param>
        /// <returns>return true if succeded, else false</returns>
        public bool Modifying(string[] data)
        {
            switch (data.Length)
            {
                case 6:
                    Console.Clear();
                    if (this.CheckKey(data[0], 1) == false && this.CheckKey(data[5], 2) == false)
                    {
                        Students modifyed = new Students()
                        {
                            neptuncode = data[0],
                            name = data[1],
                            email = data[2],
                            bdate = DateTime.Parse(data[3]),
                            phone_num = data[4],
                            room_id = data[5]
                        };

                        Students updated = new Students();
                        foreach (Students item in this.repo.ListStudents())
                        {
                            if (item.neptuncode == data[0])
                            {
                                updated = item;
                            }
                        }

                        this.repo.ModifyStudent(updated, modifyed);
                        return true;
                    }
                    else
                    {
                        Console.WriteLine("Valamilyen adatot rosszul adtál meg," +
                            "vagy nincs ilyen IDs hallgato," +
                            " esteleg nincs olyan szoba amibe be akartad rakni");
                        return false;
                    }

                case 4:
                    if (this.CheckKey(data[0], 2) == false && this.CheckKey(data[3], 3) == false)
                    {
                        Rooms room = new Rooms()
                        {
                            room_id = data[0],
                            roomnum = int.Parse(data[1]),
                            beds = int.Parse(data[2]),
                            dorm_id = data[3]
                        };

                        Rooms updated = new Rooms();
                        foreach (Rooms item in this.repo.ListRooms())
                        {
                            if (item.room_id == data[0])
                            {
                                updated = item;
                            }
                        }

                        this.repo.ModifyRoom(updated, room);
                        return true;
                    }
                    else
                    {
                        Console.WriteLine("Valamilyen adatot rosszul adtál meg," +
                            "van nincs ilyen azonosítoju szoba," +
                            "esetleg nem létezik a kollégium ahova hozzá akartad adni");
                        return false;
                    }

                case 5:
                    if (this.CheckKey(data[0], 3) == false)
                    {
                        Dorms dorm = new Dorms()
                        {
                            dorm_id = data[0],
                            dorm_name = data[1],
                            address = data[2],
                            spots = int.Parse(data[3]),
                            phone_num = data[4]
                        };

                        Dorms updated = new Dorms();
                        foreach (Dorms item in this.repo.ListDorms())
                        {
                            if (item.dorm_id == data[0])
                            {
                                updated = item;
                            }
                        }

                        this.repo.ModifyDorm(updated, dorm);
                        return true;
                    }
                    else
                    {
                        Console.WriteLine("Valamilyen adatot rosszul adtál meg," +
                            "vagy van már ilyen azonositoval rendelkezö kollégium.");
                        return false;
                    }

                default:
                    Console.WriteLine("Rossz választ adtál meg!");
                    break;
            }

            return false;
        }

        /// <summary>
        /// Return the oldest students name from the database
        /// </summary>
        /// <returns>oldest student name</returns>
        public string OldStud()
        {
            IQueryable<Students> lista = this.repo.ListStudents();
            var q = lista.OrderBy(x => x.bdate).Select(x => x.name).First();
            return q;
        }

        /// <summary>
        /// Returns the list of dorms, order by spots descanding
        /// </summary>
        /// <returns>List of dorms</returns>
        public List<string> DormByPlace()
        {
            IQueryable<Dorms> lista = this.repo.ListDorms();
            var q = lista.OrderByDescending(x => x.spots).Select(x => x.dorm_name).ToList();
            return q;
        }

        /// <summary>
        /// Lists the students and the dorm's name they live in
        /// </summary>
        /// <returns>return true</returns>
        public bool StudentInDorm()
        {
            var q = from x in this.repo.ListStudents()
                    join y in this.repo.ListRooms() on x.room_id equals y.room_id
                    join z in this.repo.ListDorms() on y.dorm_id equals z.dorm_id
                    select new { x.name, y.roomnum, z.dorm_name };
            foreach (var item in q)
            {
                Console.WriteLine(item);
            }

            return true;
        }

        /// <summary>
        /// Checks if a key exists in the coded database
        /// </summary>
        /// <param name="key"> ID of object</param>
        /// <param name="tablecode">code of the table where the search will be done</param>
        /// <returns>returns false if the object exists, returns true if the object with key as ID does not exists in database</returns>
        public bool CheckKey(string key, int tablecode)
        {
            switch (tablecode)
            {
                case 1:

                        foreach (var item in this.repo.ListStudents())
                        {
                            if (key.ToLower() == item.neptuncode.ToLower())
                            {
                                Console.WriteLine("Ilyen hallgato már van");
                                return false;
                            }
                        }

                        return true;

                case 2:
                    foreach (var item in this.repo.ListRooms())
                    {
                        if (key.ToLower() == item.room_id.ToLower() && this.repo.ListStudents().Count(x => x.room_id == key) < item.beds)
                        {
                            Console.WriteLine("Ilyen ID-jú szoba már van");
                            return false;
                        }
                    }

                    return true;

                case 3:
                    foreach (var item in this.repo.ListDorms())
                    {
                        if (item.dorm_id.ToLower() == key.ToLower())
                        {
                            Console.WriteLine("Van már ilyen kodu kolesz!");
                            return false;
                        }
                    }

                    return true;

                default:
                    Console.WriteLine("U faqed up the code brah");
                    break;
            }

            return false;
        }
    }
}
