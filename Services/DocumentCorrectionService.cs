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
using System.Net.NetworkInformation;

public class DocumentCorrectionService
{
    private readonly AppDbContext _context;

    public DocumentCorrectionService(AppDbContext context)
    {
        _context = context;
    }

    public async Task<List<DocumentCorrection>> GetCorrectionsAsync()
    {
        return await _context.DocumentCorrections.ToListAsync();
    }

    public async Task<DocumentCorrection> GetCorrectionByIdAsync(int id)
    {
        return await _context.DocumentCorrections.FindAsync(id);
    }

    public async Task AddCorrectionAsync(DocumentCorrection correction)
    {
        _context.DocumentCorrections.Add(correction);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateCorrectionAsync(DocumentCorrection correction)
    {
        _context.DocumentCorrections.Update(correction);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteCorrectionAsync(int id)
    {
        var correction = await _context.DocumentCorrections.FindAsync(id);
        if (correction != null)
        {
            _context.DocumentCorrections.Remove(correction);
            await _context.SaveChangesAsync();
        }
    }
}
