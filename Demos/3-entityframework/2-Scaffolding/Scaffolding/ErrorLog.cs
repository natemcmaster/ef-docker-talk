using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Scaffolding
{
    public partial class ErrorLog
    {
        public int ErrorLogID { get; set; }
        public DateTime ErrorTime { get; set; }
        [Required]
        public string UserName { get; set; }
        public int ErrorNumber { get; set; }
        public int? ErrorSeverity { get; set; }
        public int? ErrorState { get; set; }
        [MaxLength(126)]
        public string ErrorProcedure { get; set; }
        public int? ErrorLine { get; set; }
        [Required]
        public string ErrorMessage { get; set; }
    }
}
