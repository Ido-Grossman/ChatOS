﻿using System.ComponentModel.DataAnnotations.Schema;

namespace MVC.Models;

[NotMapped]
public class TraInv
{
    public string From { get; set; }

    public string To { get; set; }
    
    public string? Server { get; set; }
    
    public string? Content { get; set; }
}