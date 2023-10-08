using Azure;
using Azure.Data.Tables;

namespace IBAS_menu.Models
{
    public class IbasMenuDTO : ITableEntity
    {
        // Represents the partition key in Azure Table Storage.
        public string PartitionKey { get; set; }
        // Represents the row key in Azure Table Storage.
        public string RowKey { get; set; }
        
        //Represents the different properties
        public string Weekday { get; set; }
        public string ColdDish { get; set; }
        public string WarmDish { get; set; }

        // Obligatory for if implementeing an interface of TableEntity. 
        public DateTimeOffset? Timestamp { get; set; }
        public ETag ETag { get; set; }
    }
}
