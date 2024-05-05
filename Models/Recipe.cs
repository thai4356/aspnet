using System;
using System.Collections.Generic;

namespace Italian_Restaurant.Models;

public partial class Recipe
{
    public int RecipeId { get; set; }

    public string? RecipeName { get; set; }

    public int? UserId { get; set; }

    public int? Category { get; set; }

    public string? RecipeRole { get; set; }

    public string? Material { get; set; }

    public string? Description { get; set; }

    public virtual Category? CategoryNavigation { get; set; }

    public virtual ICollection<Comment> Comments { get; set; } = new List<Comment>();

    public virtual User? User { get; set; }
}
