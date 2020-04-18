// <copyright file="IRepository.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Dorm.Repository
#pragma warning restore SA1652 // Enable XML documentation output
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Dorm.Data;

    /// <summary>
    /// Repository interface
    /// </summary>
    public interface IRepository
    {
        /// <summary>
        /// List students from database
        /// </summary>
        /// <returns>list of students</returns>
        IQueryable<Students> ListStudents();

        /// <summary>
        /// List rooms from database
        /// </summary>
        /// <returns>list of rooms</returns>
        IQueryable<Rooms> ListRooms();

        /// <summary>
        /// list dorms from database
        /// </summary>
        /// <returns>list of dorms</returns>
        IQueryable<Dorms> ListDorms();

        /// <summary>
        /// Adds a student to the database
        /// </summary>
        /// <param name="add">student object that will be added</param>
        /// <returns>returns 1</returns>
        int AddStudent(Students add);

        /// <summary>
        /// Adds a room to the database
        /// </summary>
        /// <param name="add">room object that will be added</param>
        /// <returns>returns 2</returns>
        int AddRoom(Rooms add);

        /// <summary>
        /// Adds a dorm to the database
        /// </summary>
        /// <param name="add">dorm object that will be added</param>
        /// <returns>returns 3</returns>
        int AddDorm(Dorms add);

        /// <summary>
        /// Deletes a student from database
        /// </summary>
        /// <param name="delete">Student object that will be deleted</param>
        void DeleteStudent(Students delete);

        /// <summary>
        /// Deletes a room from database
        /// </summary>
        /// <param name="delete">room object that will be deleted</param>
        void DeleteRoom(Rooms delete);

        /// <summary>
        /// Deletes a dorm from database
        /// </summary>
        /// <param name="delete">room object that will be deleted</param>
        void DeleteDorm(Dorms delete);

        /// <summary>
        /// Modifyes an object in database by removing the old one, and addend the new with the same ID
        /// </summary>
        /// <param name="delete">student object with old properties</param>
        /// <param name="add">student object with new properties</param>
        void ModifyStudent(Students delete, Students add);

        /// <summary>
        /// Modifyes an object in database by removing the old one, and addend the new with the same ID
        /// </summary>
        /// <param name="delete">room object with old properties</param>
        /// <param name="add">room object with new properties</param>
        void ModifyRoom(Rooms delete, Rooms add);

        /// <summary>
        /// Modifyes an object in database by removing the old one, and addend the new with the same ID
        /// </summary>
        /// <param name="delete">dorm object with old properties</param>
        /// <param name="add">dorm object with new properties</param>
        void ModifyDorm(Dorms delete, Dorms add);
    }
}
