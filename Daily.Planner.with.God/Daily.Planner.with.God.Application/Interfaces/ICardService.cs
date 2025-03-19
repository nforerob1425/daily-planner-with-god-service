using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Daily.Planner.with.God.Common;
using Daily.Planner.with.God.Domain.Entities;

namespace Daily.Planner.with.God.Application.Interfaces
{
    public interface ICardService
    {
        Task<ResponseMessage<List<Card>>> GetCardsAsync();
        Task<ResponseMessage<Card?>> GetCardAsync(Guid id);
        Task<ResponseMessage<Card>> CreateCardAsync(Card card);
        Task<ResponseMessage<bool>> UpdateCardAsync(Guid id, Card card);
        Task<ResponseMessage<bool>> DeleteCardAsync(Guid id);
    }
}
