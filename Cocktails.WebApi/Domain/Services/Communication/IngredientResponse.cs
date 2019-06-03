using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Cocktails.WebApi.Domain.Models;


namespace Cocktails.WebApi.Domain.Services.Communication
{
    public class IngredientResponse : BaseResponse
    {
        public Ingredient Ingredient { get; private set; }

        private IngredientResponse(bool success, string message, Ingredient ingredient) : base(success, message)
        {
            Ingredient = ingredient;
        }

        /// <summary>
        /// Creates a success response.
        /// </summary>
        /// <param name="ingredient">Saved category.</param>
        /// <returns>Response.</returns>
        public IngredientResponse(Ingredient ingredient) : this(true, string.Empty, ingredient)
        { }

        /// <summary>
        /// Creates am error response.
        /// </summary>
        /// <param name="message">Error message.</param>
        /// <returns>Response.</returns>
        public IngredientResponse(string message) : this(false, message, null)
        { }
    }
}
