﻿using System;
namespace Infrastructure.Persistence;

public class DatabaseSettings
{
    public string? DBProvider { get; set; }
    public string? ConnectionString { get; set; }
}

