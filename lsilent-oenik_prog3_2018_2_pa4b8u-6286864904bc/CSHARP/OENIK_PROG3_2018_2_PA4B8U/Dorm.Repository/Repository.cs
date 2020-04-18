// <copyright file="Repository.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Dorm.Repository
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Dorm.Data;

    /// <summary>
    /// Class to communicate with database
    /// </summary>
    public class Repository : IRepository
    {
        private DBEntities database = new DBEntities();

        /// <summary>
        /// Gets or sets the database to use
        /// </summary>
        public DBEntities Database { get => this.database; set => this.database = value; }

        /// <summary>
        /// List the Students in database
        /// </summary>
        /// <returns>Returns Students in a list</returns>
        public IQueryable<Students> ListStudents()
        {
            IQueryable<Students> studlist = this.database.Students;
            return studlist;
        }

        /// <summary>
        /// List the Rooms in database
        /// </summary>
        /// <returns>Returns Rooms in a list</returns>
        public IQueryable<Rooms> ListRooms()
        {
            IQueryable<Rooms> roomlist = this.database.Rooms;
            return roomlist;
        }

        /// <summary>
        /// List the Dorms in database
        /// </summary>
        /// <returns>Returns Dorms in a list</returns>
        public IQueryable<Dorms> ListDorms()
        {
            IQueryable<Dorms> dormlist = this.database.Dorms;
            return dormlist;
        }

        /// <summary>
        /// Adds a Student to the database
        /// </summary>
        /// <param name="add">object that will be added</param>
        /// <returns>return 1</returns>
        public int AddStudent(Students add)
        {
            this.Database.Students.Add(add);
            this.Database.SaveChanges();
            return 1;
        }

        /// <summary>
        /// Adds a Room to the database
        /// </summary>
        /// <param name="add">object that will be added</param>
        /// <returns>return 2</returns>
        public int AddRoom(Rooms add)
        {
            this.Database.Rooms.Add(add);
            this.Database.SaveChanges();
            return 2;
        }

        /// <summary>
        /// Adds a Dorm to the database
        /// </summary>
        /// <param name="add">object that will be added</param>
        /// <returns>returns 3</returns>
        public int AddDorm(Dorms add)
        {
            this.Database.Dorms.Add(add);
            this.Database.SaveChanges();
            return 3;
        }

        /// <summary>
        /// Deletes a Student from database
        /// </summary>
        /// <param name="delete">The Student that will be deleted</param>
        public void DeleteStudent(Students delete)
        {
            this.Database.Students.Remove(delete);
            this.Database.SaveChanges();
            Console.WriteLine("Tanuló törölve");
        }

        /// <summary>
        /// Deletes a Room from database
        /// </summary>
        /// <param name="delete">The Room that will be deleted</param>
        public void DeleteRoom(Rooms delete)
        {
            this.Database.Rooms.Remove(delete);
            this.Database.SaveChanges();
            Console.WriteLine("Szoba törölve");
        }

        /// <summary>
        /// Deletes a Dorm from database
        /// </summary>
        /// <param name="delete">The Dorm that will be deleted</param>
        public void DeleteDorm(Dorms delete)
        {
            this.Database.Dorms.Remove(delete);
            this.Database.SaveChanges();
            Console.WriteLine("Kollégium törölve");
        }

        /// <summary>
        /// Modifys a Student in database
        /// </summary>
        /// <param name="delete">deletes the Student with the old properties</param>
        /// <param name="add">adds the Student with the new properties</param>
        public void ModifyStudent(Students delete, Students add)
        {
            this.Database.Students.Remove(delete);
            this.Database.Students.Add(add);
            this.Database.SaveChanges();
            Console.WriteLine("Hallgato modosítva");
        }

        /// <summary>
        /// Modifys a Room in database
        /// </summary>
        /// <param name="delete">deletes the Room with the old properties</param>
        /// <param name="add">adds the Room with the new properties</param>
        public void ModifyRoom(Rooms delete, Rooms add)
        {
            this.Database.Rooms.Remove(delete);
            this.Database.Rooms.Add(add);
            this.Database.SaveChanges();
            Console.WriteLine("Szoba modosítva");
        }

        /// <summary>
        /// Modifys a Student in database
        /// </summary>
        /// <param name="delete">deletes the Dorm with the old properties</param>
        /// <param name="add">adds the Dorm with the new properties</param>
        public void ModifyDorm(Dorms delete, Dorms add)
        {
            this.Database.Dorms.Remove(delete);
            this.Database.Dorms.Add(add);
            this.Database.SaveChanges();
            Console.WriteLine("Kollégium modosítva");
        }
    }
}
