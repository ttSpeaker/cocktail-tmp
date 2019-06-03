using Microsoft.EntityFrameworkCore.Migrations;

namespace Cocktails.WebApi.Migrations
{
    public partial class ModifiedRelation2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CocktailIngredient_Cocktails_CocktailId",
                table: "CocktailIngredient");

            migrationBuilder.DropForeignKey(
                name: "FK_CocktailIngredient_Ingredients_IngredientId",
                table: "CocktailIngredient");

            migrationBuilder.AddForeignKey(
                name: "FK_CocktailIngredient_Ingredients_CocktailId",
                table: "CocktailIngredient",
                column: "CocktailId",
                principalTable: "Ingredients",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CocktailIngredient_Cocktails_IngredientId",
                table: "CocktailIngredient",
                column: "IngredientId",
                principalTable: "Cocktails",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CocktailIngredient_Ingredients_CocktailId",
                table: "CocktailIngredient");

            migrationBuilder.DropForeignKey(
                name: "FK_CocktailIngredient_Cocktails_IngredientId",
                table: "CocktailIngredient");

            migrationBuilder.AddForeignKey(
                name: "FK_CocktailIngredient_Cocktails_CocktailId",
                table: "CocktailIngredient",
                column: "CocktailId",
                principalTable: "Cocktails",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CocktailIngredient_Ingredients_IngredientId",
                table: "CocktailIngredient",
                column: "IngredientId",
                principalTable: "Ingredients",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
