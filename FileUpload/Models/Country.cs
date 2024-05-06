﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FileUploadOperation.Models
{
    public class Country
    {
        public int CountryId { get; set; }

        public string CountryName { get; set; }

        public bool IsActive { get; set; }=true;

        public ICollection<City> cities { get; set; }

    }
}

