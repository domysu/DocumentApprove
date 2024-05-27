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
using DokumentuTvirtinimoSistema.Components.Pages;


public class AuditService
{
    private readonly AppDbContext _context;
    private readonly ILogger<AuditService> _logger;

    public AuditService(AppDbContext context, ILogger<AuditService> logger)
    {
        _context = context;
        _logger = logger;
    }

    public async Task<AuditLog> GetAuditLogsAsync(int documentId)
    {
        _logger.LogInformation($"Fetching audit logs for DocumentId: {documentId}");

        var auditLog = await _context.AuditLogs
            .Where(al => al.AuditDocumentId == documentId)
            .OrderByDescending(al => al.AuditTimestamp)
            .FirstOrDefaultAsync();

        if (auditLog == null)
        {
            _logger.LogWarning($"No audit log found for DocumentId: {documentId}");
        }
        else
        {
            _logger.LogInformation($"Audit log details retrieved: {auditLog}");
        }

        return auditLog;
    }
}
