// <copyright file="ILogic.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Dorm.Logic
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    /// <summary>
    /// Logic interface
    /// </summary>
    public interface ILogic
    {
        /// <summary>
        /// List the items in database
        /// </summary>
        /// <param name="num">type of database</param>
        /// 1 for Students, 2 for Rooms, 3 for Dorms
        /// <returns>retuns a string list with the choosen type of data</returns>
        List<string> Listing(int num);

        /// <summary>
        /// Adding an item to database
        /// </summary>
        /// <param name="data">properties of the object that will be added</param>
        /// <returns>return true if added an object</returns>
        bool Adding(string[] data);

        /// <summary>
        /// Deletes an object from database
        /// </summary>
        /// <param name="key">ID of the object that will be deleted</param>
        /// <returns>return true if succeded, else false</returns>
        bool Deleting(string key);

        /// <summary>
        /// Modifys an object in database
        /// </summary>
        /// <param name="data">properties of the object</param>
        /// <returns>return true if succeded, else false</returns>
        bool Modifying(string[] data);

        /// <summary>
        /// Return the oldest students name from the database
        /// </summary>
        /// <returns>oldest student name</returns>
        string OldStud();

        /// <summary>
        /// Returns the list of dorms, order by spots descanding
        /// </summary>
        /// <returns>List of dorms</returns>
        List<string> DormByPlace();

        /// <summary>
        /// Lists the students and the dorm's name they live in
        /// </summary>
        /// <returns>returns true</returns>
        bool StudentInDorm();

        /// <summary>
        /// Checks if an obejct with key as ID exists in any of the tables
        /// </summary>
        /// <param name="key">ID of new object wannabe</param>
        /// <param name="tablecode">code of table that will be checked</param>
        /// <returns>true if no object with key, false if object exists with key as ID</returns>
        bool CheckKey(string key, int tablecode);
    }
}
