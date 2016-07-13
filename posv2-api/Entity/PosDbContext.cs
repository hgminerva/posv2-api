using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;

namespace posv2_api.Entity
{
    public class PosDbContext : DbContext
    {
        public PosDbContext() : base("PosDbContext") { }

        // Masters
        public DbSet<MstTableGroup> MstTableGroups { get; set; }
        public DbSet<MstTable> MstTables { get; set; }

        // New MSTs
        public DbSet<MstAccount> MstAccount { get; set; }
        public DbSet<MstCustomer> MstCustomer { get; set; }
        public DbSet<MstDiscount> MstDiscount { get; set; }
        public DbSet<MstDiscountItem> MstDiscountItem { get; set; }
        public DbSet<MstItem> MstItem { get; set; }
        public DbSet<MstItemComponent> MstItemComponent { get; set; }
        public DbSet<MstItemGroup> MstItemGroup { get; set; }
        public DbSet<MstItemGroupItem> MstItemGroupItem { get; set; }
        public DbSet<MstItemInventory> MstItemInventory { get; set; }
        public DbSet<MstItemPackage> MstItemPackage { get; set; }
        public DbSet<MstItemPrice> MstItemPrice { get; set; }
        public DbSet<MstPayType> MstPayType { get; set; }
        public DbSet<MstPeriod> MstPeriod { get; set; }
        public DbSet<MstSupplier> MstSupplier { get; set; }
        public DbSet<MstTax> MstTax { get; set; }
        public DbSet<MstTerm> MstTerm { get; set; }
        public DbSet<MstTerminal> MstTerminal { get; set; }
        public DbSet<MstUnit> MstUnit { get; set; }
        public DbSet<MstUser> MstUser { get; set; }
        public DbSet<MstUserForm> MstUserForm { get; set; }
        
        //New TRNs
        public DbSet<TrnCollection> TrnCollection { get; set; }
        public DbSet<TrnCollectionLine> TrnCollectionLine { get; set; }
        public DbSet<TrnDebitCreditMemo> TrnDebitCreditMemo { get; set; }
        public DbSet<TrnDebitCreditMemoLine> TrnDebitCreditMemoLine { get; set; }
        public DbSet<TrnDisbursement> TrnDisbursement { get; set; }
        public DbSet<TrnJournal> TrnJournal { get; set; }
        public DbSet<TrnPurchaseOrder> TrnPurchaseOrder { get; set; }
        public DbSet<TrnPurchaseOrderLine> TrnPurchaseOrderLine { get; set; }
        public DbSet<TrnSales> TrnSales { get; set; }
        public DbSet<TrnSalesDraft> TrnSalesDraft { get; set; }
        public DbSet<TrnSalesLine> TrnSalesLine { get; set; }
        public DbSet<TrnSalesReleased> TrnSalesReleased { get; set; }
        public DbSet<TrnStockCount> TrnStockCount { get; set; }
        public DbSet<TrnStockCountLine> TrnStockCountLine { get; set; }
        public DbSet<TrnStockIn> TrnStockIn { get; set; }
        public DbSet<TrnStockInLine> TrnStockInLine { get; set; }
        public DbSet<TrnStockOut> TrnStockOut { get; set; }
        public DbSet<TrnStockOutLine> TrnStockOutLine { get; set; }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}