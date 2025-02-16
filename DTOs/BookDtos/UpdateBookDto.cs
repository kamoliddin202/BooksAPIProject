﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
    using DataAccessLayer.Entities;

    namespace DTOs.BookDtos
    {
        public class UpdateBookDto
        {
            public int Id { get; set; }
            public string Title { get; set; } = string.Empty;
            public string Description { get; set; } = string.Empty;
            public string Author { get; set; } = string.Empty;
            public decimal Price { get; set; }
            public int CategoryId { get; set; }
        }
    }
