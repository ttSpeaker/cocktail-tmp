﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Cocktails.Domain.Models;
using Cocktails.Domain.Repositories;
using Cocktails.Domain.Services;
using Cocktails.Domain.Services.Communication;


namespace Cocktails.WebApi.Services
{
    public class CocktailService : ICocktailService
    {
        private readonly ICocktailRepository _cocktailRepository;
        private readonly IUnitOfWork _unitOfWork;

        public CocktailService(ICocktailRepository cocktailRepository, IUnitOfWork unitOfWork)
        {
            _cocktailRepository = cocktailRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<Domain.Models.Cocktail>> ListAsync()
        {
            return await _cocktailRepository.ListAsync();
        }

        public async Task<IEnumerable<Domain.Models.Cocktail>> IdAsync(int id)
        {
            return await _cocktailRepository.IdAsync(id);
        }
        
        public async Task<IEnumerable<Domain.Models.Cocktail>> ListByCategoryAsync(int catId)
        {
            return await _cocktailRepository.ListByCategoryAsync(catId);
        }

        public async Task<IEnumerable<Domain.Models.Cocktail>> ListByIngredientAsync(int IngIds)
        {
            return await _cocktailRepository.ListByIngredientAsync(IngIds);
        }
        
        public async Task<IEnumerable<Domain.Models.Cocktail>> ListByNameAsync(string name)
        {
            return await _cocktailRepository.ListByNameAsync(name);
        }

        public async Task<CocktailResponse> AddAsync(Domain.Models.Cocktail cocktail, List<Ingredient> ingredients)
        {

            try
            {
                await _cocktailRepository.AddAsync(cocktail, ingredients);

                await _unitOfWork.CompleteAsync();

                return new CocktailResponse(cocktail);
            }
            catch (Exception ex)
            {
                return new CocktailResponse($"An error occurred when saving the cocktail: {ex.Message}");
            }
        }
    
        
        public async Task<CocktailResponse> UpdateAsync(int id, Domain.Models.Cocktail cocktail)
        {
            var existingCocktail = await _cocktailRepository.FindIdAsync(id);

            if (existingCocktail == null)
            {
                return new CocktailResponse("Cocktail not found");
            }

            existingCocktail.Name = cocktail.Name;
            existingCocktail.Thumb = cocktail.Thumb;
            existingCocktail.Instructions = cocktail.Instructions;


            try
            {
                 _cocktailRepository.Update(existingCocktail);
                await _unitOfWork.CompleteAsync();

                return new CocktailResponse(existingCocktail);
            }
            catch (Exception ex)
            {
                return new CocktailResponse($"An error ocurred when updating the cocktail: {ex.Message}");
            }
        }

        public async Task<CocktailResponse> DeleteAsync(int id)
        {
            var existingCocktail = await _cocktailRepository.FindIdAsync(id);

            if(existingCocktail == null)
            {
                return new CocktailResponse("Cocktail not found");
            }
            try
            {
                _cocktailRepository.Delete(existingCocktail);
                await _unitOfWork.CompleteAsync();

                return new CocktailResponse(existingCocktail);
            }
            catch (Exception ex)
            {
                return new CocktailResponse($"An error ocurred while deleting the cocktail: {ex.Message}");
            }
        }
    }
}

