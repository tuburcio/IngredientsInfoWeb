namespace IngredientsEntities.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Allergens",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Ingredients",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Dishes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.IngredientAllergens",
                c => new
                    {
                        Ingredient_Id = c.Int(nullable: false),
                        Allergen_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Ingredient_Id, t.Allergen_Id })
                .ForeignKey("dbo.Ingredients", t => t.Ingredient_Id, cascadeDelete: true)
                .ForeignKey("dbo.Allergens", t => t.Allergen_Id, cascadeDelete: true)
                .Index(t => t.Ingredient_Id)
                .Index(t => t.Allergen_Id);
            
            CreateTable(
                "dbo.DishIngredients",
                c => new
                    {
                        Dish_Id = c.Int(nullable: false),
                        Ingredient_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Dish_Id, t.Ingredient_Id })
                .ForeignKey("dbo.Dishes", t => t.Dish_Id, cascadeDelete: true)
                .ForeignKey("dbo.Ingredients", t => t.Ingredient_Id, cascadeDelete: true)
                .Index(t => t.Dish_Id)
                .Index(t => t.Ingredient_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.DishIngredients", "Ingredient_Id", "dbo.Ingredients");
            DropForeignKey("dbo.DishIngredients", "Dish_Id", "dbo.Dishes");
            DropForeignKey("dbo.IngredientAllergens", "Allergen_Id", "dbo.Allergens");
            DropForeignKey("dbo.IngredientAllergens", "Ingredient_Id", "dbo.Ingredients");
            DropIndex("dbo.DishIngredients", new[] { "Ingredient_Id" });
            DropIndex("dbo.DishIngredients", new[] { "Dish_Id" });
            DropIndex("dbo.IngredientAllergens", new[] { "Allergen_Id" });
            DropIndex("dbo.IngredientAllergens", new[] { "Ingredient_Id" });
            DropTable("dbo.DishIngredients");
            DropTable("dbo.IngredientAllergens");
            DropTable("dbo.Dishes");
            DropTable("dbo.Ingredients");
            DropTable("dbo.Allergens");
        }
    }
}
