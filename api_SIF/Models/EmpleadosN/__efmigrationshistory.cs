using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace api_SIF.Models.EmpleadosN
{
    [Table("__efmigrationshistory")]
    [MySqlCharSet("utf8mb4")]
    [MySqlCollation("utf8mb4_general_ci")]
    public partial class __efmigrationshistory
    {
        [Key]
        [StringLength(150)]
        public string MigrationId { get; set; }
        [Required]
        [StringLength(32)]
        public string ProductVersion { get; set; }
    }
}
