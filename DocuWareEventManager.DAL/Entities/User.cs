﻿using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace DocuWareEventManager.DAL.Entities
{
    [Table("Users")]
    public  class User
    {
        public int Id { get; set;}

        public string Email { get; set; }

        public string Password { get; set; }

        public DateTime CreateDate { get; set; }
    }
}
