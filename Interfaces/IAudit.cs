using DokumentuTvirtinimoSistema.Models;

namespace DokumentuTvirtinimoSistema.Interfaces
{
    public interface IAudit
    {
        public Task<List<AuditLogs>> GetAuditLogsAsync();
    }
}
