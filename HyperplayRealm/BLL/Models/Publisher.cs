﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;

namespace BLL.Models;

public partial class Publisher
{
    //we do need another ID here - fixed Publisher ID - modify later

    public Publisher()
    {

    }

    public int PublisherId { get; set; }

    public string Name { get; set; }

    public virtual ICollection<Game> Games { get; set; } = new List<Game>();
}