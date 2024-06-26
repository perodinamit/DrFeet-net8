﻿using Domain.Entities;
using Domain.Repository;
using Microsoft.EntityFrameworkCore;
using Infrastructure.Context;
using Domain.ViewModels;

namespace Application.Services
{
    public class ShoeService : IShoeRepository
    {
        private readonly ApplicationDbContext context;

        public ShoeService(ApplicationDbContext context)
        {
            this.context = context;
        }


        public async Task<List<Shoe>> GetAllShoes()
        {
            return await context.Shoes
                .Include(x => x.Top)
                .Include(x => x.ColorType)
                .Include(x => x.Lining)
                .Include(x => x.Purpose)
                .Include(x => x.Sole)
                .AsSplitQuery()
                .ToListAsync();
        }

        public async Task<Shoe?> FindShoe(int id)
        {
            return await context.Shoes.FindAsync(id);
        }

        public async Task<bool> Delete(int id)
        {
            var toDelete = await context.Shoes.FindAsync(id);

            if (toDelete is null)
            {
                return false;
            }

            RemoveCalculations(id);

            context.Shoes.Remove(toDelete);
            context.SaveChanges();

            return true;
        }

        private void RemoveCalculations(int id)
        {
            var calculation = context.Calculations.FirstOrDefault(x => x.ShoeId == id);
            if (calculation is not null)
            {
                var calculationItem = context.CalculationItems
                    .Where(x => x.CalculationId == calculation.Id);

                if (calculationItem is not null)
                {
                    context.RemoveRange(calculationItem);
                }

                context.Calculations.Remove(calculation);
            }
        }

        public async Task<bool> AddShoe(Shoe newShoe)
        {         
            context.Shoes.Add(newShoe);
            await context.SaveChangesAsync();

            return true; 
        }
        public async Task<bool> ModifyShoe(Shoe modifiedShoe)
        {
            var existingShoe = await context.Shoes.FindAsync(modifiedShoe.Id);

            if (existingShoe == null)
            {
                return false; 
            }
        
            existingShoe.Code = modifiedShoe.Code;
            existingShoe.Name = modifiedShoe.Name;
            existingShoe.Description = modifiedShoe.Description;
            existingShoe.TopId = modifiedShoe.TopId;
            existingShoe.LiningId = modifiedShoe.LiningId;
            existingShoe.SoleId = modifiedShoe.SoleId;
            existingShoe.PurposeId = modifiedShoe.PurposeId;
            existingShoe.ColorTypeId = modifiedShoe.ColorTypeId;
            existingShoe.ImageData = modifiedShoe.ImageData;

            await context.SaveChangesAsync();

            return true; 
        }

        public async Task<IEnumerable<SelectItem>> GetDropdownOptions<T>(string propertyName)
        {
            return propertyName.ToLower() switch
            {
                "tops" => await GetDropdownOptions<Top>(),
                "linings" => await GetDropdownOptions<Lining>(),
                "soles" => await GetDropdownOptions<Sole>(),
                "purposes" => await GetDropdownOptions<Purpose>(),
                "colortypes" => await GetDropdownOptions<ColorType>(),
                _ => throw new ArgumentException($"Invalid property name: {propertyName}"),
            };
        }

        private async Task<IEnumerable<SelectItem>> GetDropdownOptions<T>() where T : class
        {
            var entities = await context.Set<T>().ToListAsync();

            var options = entities.Select(entity => new SelectItem
            {
                Text = entity.GetType().GetProperty("Name")?.GetValue(entity)?.ToString() ?? "",
                Value = entity.GetType().GetProperty("Id")?.GetValue(entity)?.ToString() ?? ""
            });

            return options;
        }

    }
}

