// <copyright file="Program.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace OENIK_PROG3_2018_2_PA4B8U
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Dorm.Logic;
    using Dorm.Repository;

    /// <summary>
    /// Program
    /// </summary>
    public class Program
    {
        /// <summary>
        /// Main program
        /// </summary>
        /// <param name="args">default args</param>
        public static void Main(string[] args)
        {
            Repository r = new Repository();
            Logic l = new Logic(r);
            Methods.Menu(l);

            Console.ReadKey();
        }
    }
}
