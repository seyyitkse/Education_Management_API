﻿using System.ComponentModel.DataAnnotations;

namespace Education.EntityLayer.Concrete
{
    public class Announcement
    {
        [Key]
        public int ID { get; set; }
        public string? Title { get; set; }
        public string? Content { get; set; }
        public DateTime Date { get; set; }
        public int TypeID { get; set; }
        public bool Status { get; set; }
        public Announcement()
        {
            Status = true;
        }
    }
}
