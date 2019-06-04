using Cocktails.Domain.Models;
using Cocktails.Domain.Repositories;
using Cocktails.Domain.Services;
using Cocktails.Domain.Services.Communication;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;


namespace Cocktails.WebApi.Services
{
    public class IngredientService : IIngredientService
    {
        private readonly IIngredientRepository _ingredientRepository;
        private readonly IUnitOfWork _unitOfWork;

        public IngredientService(IIngredientRepository ingredientRepository, IUnitOfWork unitOfWork)
        {
            _ingredientRepository = ingredientRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<Ingredient>> ListAsync()
        {
            return await _ingredientRepository.ListAsync();
        }

        public async Task<IngredientResponse> SaveAsync(Ingredient ingredient)
        {
            try
            {
                await _ingredientRepository.AddAsync(ingredient);
                await _unitOfWork.CompleteAsync();

                return new IngredientResponse(ingredient);
            }
            catch (Exception ex)
            {
                return new IngredientResponse($"An error occurred when saving the ingredient: {ex.Message}");
            }
        }

        public async Task<IngredientResponse> UpdateAsync(int id, Ingredient ingredient)
        {
            var existingIngredient = await _ingredientRepository.FindByIdAsync(id);

            if (existingIngredient == null)
            {
                return new IngredientResponse("Ingredient not found");
            }

            existingIngredient.Name = ingredient.Name;

            try
            {
                _ingredientRepository.Update(existingIngredient);
                await _unitOfWork.CompleteAsync();

                return new IngredientResponse(existingIngredient);
            }

            catch (Exception ex)
            {
                return new IngredientResponse($"An error ocurred when updating the ingredient: {ex.Message}");
            }

        }
        public async Task<IngredientResponse> DeleteAsync(int id)
        {
            var existingIngredient = await _ingredientRepository.FindByIdAsync(id);

            if (existingIngredient == null)
                return new IngredientResponse("Category not found.");

            try
            {
                _ingredientRepository.Remove(existingIngredient);
                await _unitOfWork.CompleteAsync();

                return new IngredientResponse(existingIngredient);
            }
            catch (Exception ex)
            {
                return new IngredientResponse($"An error occurred when deleting the ingredient: {ex.Message}");
            }
        }
    }
}
