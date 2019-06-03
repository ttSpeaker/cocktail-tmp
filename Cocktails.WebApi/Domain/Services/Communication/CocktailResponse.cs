using Cocktails.WebApi.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cocktails.WebApi.Domain.Services.Communication
{
    public class CocktailResponse : BaseResponse
    {
            public Cocktail Cocktail { get; private set; }

            private CocktailResponse(bool success, string message, Cocktail cocktail) : base(success, message)
            {
                Cocktail = cocktail;
            }

            /// <summary>
            /// Creates a success response.
            /// </summary>
            /// <param name="cocktail">Saved category.</param>
            /// <returns>Response.</returns>
            public CocktailResponse(Cocktail cocktail) : this(true, string.Empty, cocktail)
            { }

            /// <summary>
            /// Creates am error response.
            /// </summary>
            /// <param name="message">Error message.</param>
            /// <returns>Response.</returns>
            public CocktailResponse(string message) : this(false, message, null)
            { }
        
    }
}
