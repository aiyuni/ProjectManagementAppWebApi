using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MakePlusWebAPI.Models.Repository
{
    public class InvoiceRepository : IDataRepository<Invoice>
    {
        public readonly ApplicationDbContext _invoiceDbContext;

        public InvoiceRepository(ApplicationDbContext context)
        {
            this._invoiceDbContext = context;
        }
        public void Add(Invoice entity)
        {

            if (_invoiceDbContext.Invoices.Any(i => i.InvoiceId == entity.InvoiceId) == false)
            {
                _invoiceDbContext.Invoices.Add(entity);
            }
            else
            {
                Invoice existingInvoice = _invoiceDbContext.Invoices.FirstOrDefault(i => i.InvoiceId == entity.InvoiceId);
                this.Update(existingInvoice, entity);
            }

            _invoiceDbContext.SaveChanges();
        }

        public void Delete(Invoice entity)
        {
            throw new NotImplementedException();
        }

        public Invoice Get(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Invoice> GetAll()
        {
            return _invoiceDbContext.Invoices.ToList();
        }

        public int GetMaxId()
        {
            throw new NotImplementedException();
        }

        public void Update(Invoice dbEntity, Invoice entity)
        {
            _invoiceDbContext.Entry(dbEntity).CurrentValues.SetValues(entity);
        }
    }
}
