using Microsoft.EntityFrameworkCore.Migrations;

namespace Cocktails.WebApi.Migrations
{
    public partial class SEED : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CocktailIngredient_Ingredients_CocktailId",
                table: "CocktailIngredient");

            migrationBuilder.DropForeignKey(
                name: "FK_CocktailIngredient_Cocktails_IngredientId",
                table: "CocktailIngredient");

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 100, "Cocktail" },
                    { 101, "Beer" }
                });

            migrationBuilder.InsertData(
                table: "Ingredients",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 100, "Ingrediente 1" },
                    { 101, "Ingrediente 2" }
                });

            migrationBuilder.InsertData(
                table: "Cocktails",
                columns: new[] { "Id", "CategoryId", "Instructions", "Name", "Thumb" },
                values: new object[] { 100, 100, "How To Make it", "Cocktail Name 1", "Image/URL" });

            migrationBuilder.InsertData(
                table: "Cocktails",
                columns: new[] { "Id", "CategoryId", "Instructions", "Name", "Thumb" },
                values: new object[] { 101, 100, "How To Make it", "Cocktail Name 2", "Image/URL" });

            migrationBuilder.InsertData(
                table: "Cocktails",
                columns: new[] { "Id", "CategoryId", "Instructions", "Name", "Thumb" },
                values: new object[] { 102, 100, "How To Make it", "Cocktail Name 3", "Image/URL" });

            migrationBuilder.InsertData(
                table: "CocktailIngredient",
                columns: new[] { "CocktailId", "IngredientId" },
                values: new object[] { 100, 100 });

            migrationBuilder.InsertData(
                table: "CocktailIngredient",
                columns: new[] { "CocktailId", "IngredientId" },
                values: new object[] { 100, 101 });

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CocktailIngredient_Cocktails_CocktailId",
                table: "CocktailIngredient");

            migrationBuilder.DropForeignKey(
                name: "FK_CocktailIngredient_Ingredients_IngredientId",
                table: "CocktailIngredient");

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 101);

            migrationBuilder.DeleteData(
                table: "CocktailIngredient",
                keyColumns: new[] { "CocktailId", "IngredientId" },
                keyValues: new object[] { 100, 100 });

            migrationBuilder.DeleteData(
                table: "CocktailIngredient",
                keyColumns: new[] { "CocktailId", "IngredientId" },
                keyValues: new object[] { 100, 101 });

            migrationBuilder.DeleteData(
                table: "Cocktails",
                keyColumn: "Id",
                keyValue: 101);

            migrationBuilder.DeleteData(
                table: "Cocktails",
                keyColumn: "Id",
                keyValue: 102);

            migrationBuilder.DeleteData(
                table: "Cocktails",
                keyColumn: "Id",
                keyValue: 100);

            migrationBuilder.DeleteData(
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: 100);

            migrationBuilder.DeleteData(
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: 101);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 100);

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
    }
}
