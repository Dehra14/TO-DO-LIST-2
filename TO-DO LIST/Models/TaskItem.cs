﻿using System.ComponentModel.DataAnnotations;

namespace TO_DO_LIST.Models
{
    public class TaskItem
    {
        public int Id { get; set; }
        public string Title { get; set; }
      
        public string Description { get; set; }

        public DateTime DueDate { get; set; }

        public string Priority { get; set; } 

        public string Status { get; set; }

        
    }
}
