using LINQtoCSV;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SynelAppDemo.Models
{
    public class Employee
    {
        [Key]
        public int Id { get; set; }

        [CsvColumn(Name = "Payroll_Number", FieldIndex = 1)]
        public string PayrollNumber { get; set; }

        [CsvColumn(Name = "Forenames", FieldIndex = 2)]
        public string FirstName { get; set; }

        [CsvColumn(FieldIndex = 3)]
        public string Surname { get; set; }

        [CsvColumn(Name = "Date_of_Birth", FieldIndex = 4)]
        public DateTime DateOfBirth { get; set; }

        [CsvColumn(FieldIndex = 5)]
        public string Telephone { get; set; }

        [CsvColumn(FieldIndex = 6)]
        public string Mobile { get; set; }

        [CsvColumn(FieldIndex = 7)]
        public string Address { get; set; }

        [CsvColumn(Name = "Address_2", FieldIndex = 8)]
        public string Address2 { get; set; }

        [CsvColumn(FieldIndex = 9)]
        public string Postcode { get; set; }


        [CsvColumn(Name = "EMail_Home", FieldIndex = 10)]
        public string EmailHome { get; set; }

        [CsvColumn(Name = "Start_Date", FieldIndex = 11)]
        public DateTime StartDate { get; set; }
    }
}