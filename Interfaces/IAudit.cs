using DokumentuTvirtinimoSistema.Models;

namespace DokumentuTvirtinimoSistema.Interfaces
{
    public interface IAudit
    {
        public Task<List<AuditLogs>> GetAuditLogsAsync();
        public Task<AuditLogs> AddAuditLog(AuditLogs auditlogs);
    }
}
