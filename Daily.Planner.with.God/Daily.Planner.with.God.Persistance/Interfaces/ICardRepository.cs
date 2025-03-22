using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Daily.Planner.with.God.Common;
using Daily.Planner.with.God.Domain.Entities;

namespace Daily.Planner.with.God.Persistance.Interfaces
{
    public interface ICardRepository : IRepository<Card>
    {
        Task<ResponseMessage<List<Card>>> GetAllCardsByUserId(Guid userId);
    }
}
