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
public class WorkflowService
{
    private readonly AppDbContext _context;

    public WorkflowService(AppDbContext context)
    {
        _context = context;
    }

    public async Task<List<WorkflowStatus>> GetWorkflowStatusesAsync()
    {
        return await _context.WorkflowStatus.ToListAsync();
    }

    public async Task<WorkflowStatus> GetWorkflowStatusByIdAsync(int id)
    {
        return await _context.WorkflowStatus.FindAsync(id);
    }

    public async Task UpdateWorkflowStatusAsync(WorkflowStatus status)
    {
        _context.WorkflowStatus.Update(status);
        await _context.SaveChangesAsync();
    }
}
