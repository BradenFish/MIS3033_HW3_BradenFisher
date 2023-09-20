using Microsoft.EntityFrameworkCore;

namespace a
{
    public class ReceiptDB:DbContext
    {
        public DbSet<Receipt> receiptTbl { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder opt)
        {
            opt.UseSqlite("Data Source = receipt.db");
        }
    }
}
