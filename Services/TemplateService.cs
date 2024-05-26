using DokumentuTvirtinimoSistema.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DokumentuTvirtinimoSistema.Services
{
    public class TemplateService
    {
        private readonly AppDbContext _context;

        public TemplateService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<DocumentTemplate>> GetAllTemplatesAsync()
        {
            return await _context.DocumentTemplates.ToListAsync();
        }

        public async Task<DocumentTemplate> GetTemplateByIdAsync(int templateId)
        {
            return await _context.DocumentTemplates.FindAsync(templateId);
        }

      
        
    }
}
