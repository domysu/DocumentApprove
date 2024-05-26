using DokumentuTvirtinimoSistema.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DokumentuTvirtinimoSistema.Services
{
    public class DocumentReviewService
    {
        private readonly AppDbContext _context;

        public DocumentReviewService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<DocumentReview>> GetDocumentReviewsAsync()
        {
            return await _context.DocumentReviews
                .Include(dr => dr.ValidationLogs)
                .ToListAsync();
        }

        public async Task<DocumentReview> GetDocumentReviewByIdAsync(int id)
        {
            return await _context.DocumentReviews
                .Include(dr => dr.ValidationLogs)
                .FirstOrDefaultAsync(dr => dr.Id == id);
        }

        public async Task UpdateDocumentReviewAsync(DocumentReview documentReview)
        {
            _context.DocumentReviews.Update(documentReview);
            await _context.SaveChangesAsync();
        }
    }
}
