﻿namespace DapperDemoProject.Entities
{
    public class Employee
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public int CompanyId { get; set; }

        public virtual Company Company { get; set; }
    }
}