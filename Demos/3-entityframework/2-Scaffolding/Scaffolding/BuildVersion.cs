using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Scaffolding
{
    public partial class BuildVersion
    {
        public byte SystemInformationID { get; set; }
        [Required]
        [Column("Database Version")]
        [MaxLength(25)]
        public string Database_Version { get; set; }
        public DateTime VersionDate { get; set; }
        public DateTime ModifiedDate { get; set; }
    }
}
