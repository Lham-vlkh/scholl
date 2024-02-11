﻿using Microsoft.EntityFrameworkCore;
using shcool.Models.Student;
using shcool.Models.Teacher;

namespace shcool.Context
{
    public class Database : DbContext
    {

        public DbSet<StudentInfo> Students { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            #region studentDB
            optionsBuilder.UseSqlServer("Server=DESKTOP-I2J2NP3;Database=Students_DB;Trusted_Connection=true;TrustServerCertificate=true;");
            base.OnConfiguring(optionsBuilder);
            #endregion
            #region teacherDB
   
            #endregion
        }

    }
}
