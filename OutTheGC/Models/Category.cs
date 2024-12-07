﻿using System;
namespace OutTheGC.Models;

public class Category
{
	public Guid Id { get; set; }
	public string Name { get; set; }
	public bool Default { get; set; } = true;
}

