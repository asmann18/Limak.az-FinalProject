﻿using Limak.Domain.Entities.Common;

namespace Limak.Domain.Entities;

public class Category:BaseAuditableEntity
{
    public string Name { get; set; }
    public string ImagePath { get; set; }
    public ICollection<ShopCategory> ShopCategories{ get; set; }
}
