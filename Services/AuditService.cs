using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using DokumentuTvirtinimoSistema.Models;
using DokumentuTvirtinimoSistema;
using Microsoft.EntityFrameworkCore;

public class AuditService
{
    private readonly AppDbContext _context;

    public AuditService(AppDbContext context)
    {
        _context = context;
    }

    public async Task<List<AuditLog>> GetAuditLogsAsync()
    {
        return await _context.AuditLogs.ToListAsync();
    }

    public async Task AddAuditLogAsync(AuditLog log)
    {
        _context.AuditLogs.Add(log);
        await _context.SaveChangesAsync();
    }
}
