﻿using Entities.Concrete;

namespace Entities.Dtos;

public class ProductListDto:Product
{
    public decimal Price { get; set; }
    public decimal Discount { get; set; }
   
}