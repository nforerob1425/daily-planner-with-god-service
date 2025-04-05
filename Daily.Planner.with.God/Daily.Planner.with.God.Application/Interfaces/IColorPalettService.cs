using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Daily.Planner.with.God.Common;
using Daily.Planner.with.God.Domain.Entities;

namespace Daily.Planner.with.God.Application.Interfaces
{
    public interface IColorPalettService
    {
        Task<ResponseMessage<List<ColorPalett>>> GetColorPalettsAsync();
        Task<ResponseMessage<ColorPalett>> CreateColorPalettAsync(ColorPalett colorPalett);
        Task<ResponseMessage<bool>> UpdateColorPalettAsync(ColorPalett colorPalett);
        Task<ResponseMessage<bool>> DeleteColorPalettAsync(Guid id);
    }
}
