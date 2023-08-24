using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Oqtane.Models;

namespace MyCompany.Module.Dapper.Models
{
    [Table("MyCompanyClient")]
    public class Client : IAuditable
    {
        [Key]
        public int ClientId { get; set; }
        public int SiteId { get; set; }
        public string Name { get; set; }

        public string CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime ModifiedOn { get; set; }
    }
}
