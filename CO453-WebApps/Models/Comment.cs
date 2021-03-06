﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CO453_WebApps.Models
{
    public class Comment
    {
        // Primary Key
        public int CommentID { get; set; }

        //Foreign Key
        public int PostID { get; set; }

        [DataType(DataType.MultilineText)]
        public string Text { get; set; }

        public virtual Post Post { get; set; }

        public Post Post1
        {
            get => default;
            set
            {
            }
        }
    }
}