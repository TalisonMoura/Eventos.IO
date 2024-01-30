using Eventos.IO.Infra.Data.Context;
using Eventos.IO.Domain.Interfaces;
using Eventos.IO.Domain.Core.Commands;

namespace Eventos.IO.Infra.Data.UoW;

public class UnitOfWork : IUnitOfWork
{
    private readonly EventContext _context;

    public UnitOfWork(EventContext context)
    {
        _context = context;
    }

    public async Task<CommandResponse> CommitAsync()
    {
        var rowsAffected = await _context.SaveChangesAsync();
        return new CommandResponse(rowsAffected > 0);
    }

    public void Dispose() => _context.Dispose();
}
