using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using DokumentuTvirtinimoSistema.Models;
using DokumentuTvirtinimoSistema.Interfaces;
using DokumentuTvirtinimoSistema;
using Microsoft.EntityFrameworkCore;
using DokumentuTvirtinimoSistema.Components.Pages;


public class AuditService : IAudit
{
    private readonly AppDbContext _context;
    private readonly ILogger<AuditService> _logger;

    public AuditService(AppDbContext context, ILogger<AuditService> logger)
    {
        _context = context;
        _logger = logger;
    }

    public async Task<List<AuditLogs>> GetAuditLogsAsync()
    {
        try
        {
            return await _context.AuditLogs.ToListAsync();


        }

        catch
        {
            throw;
        }
      
    }
    public async Task <AuditLogs> AddAuditLog(AuditLogs auditlogs)
    {

        try
        {
             _context.AuditLogs.Add(auditlogs);
            await _context.SaveChangesAsync();
            return auditlogs;

        }
        catch
        {
            throw;
        }


    }
}
