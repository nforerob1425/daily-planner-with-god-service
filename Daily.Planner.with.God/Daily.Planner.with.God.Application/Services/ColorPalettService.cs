using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Daily.Planner.with.God.Common;
using Daily.Planner.with.God.Domain.Entities;
using Daily.Planner.with.God.Application.Interfaces;
using Daily.Planner.with.God.Persistance.Interfaces;

namespace Daily.Planner.with.God.Application.Services
{
    public class ColorPalettService : IColorPalettService
    {
        private readonly IColorPalettRepository _colorPalettRepository;

        public ColorPalettService(IColorPalettRepository colorPalettRepository)
        {
            _colorPalettRepository = colorPalettRepository;
        }

        public async Task<ResponseMessage<List<ColorPalett>>> GetColorPalettsAsync()
        {
            try
            {
                return await _colorPalettRepository.GetAllAsync();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<ResponseMessage<ColorPalett?>> GetColorPalettAsync(Guid id)
        {
            try
            {
                return await _colorPalettRepository.GetByIdAsync(id);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<ResponseMessage<ColorPalett>> CreateColorPalettAsync(ColorPalett colorPalett)
        {
            try
            {
                colorPalett.Id = Guid.NewGuid();
                return await _colorPalettRepository.CreateAsync(colorPalett);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<ResponseMessage<bool>> UpdateColorPalettAsync( ColorPalett colorPalett)
        {
            try
            {
                return await _colorPalettRepository.UpdateAsync(colorPalett);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<ResponseMessage<bool>> DeleteColorPalettAsync(Guid id)
        {
            try
            {
                return await _colorPalettRepository.DeleteAsync(id);
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
