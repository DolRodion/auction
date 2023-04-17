using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MBC.Core.Domain.Controls
{
    /// <summary>
    /// Базовый контрол для доступа к внешним базам
    /// </summary>
    public class BaseEntity
    {
        /// <summary>
        /// Primary
        /// </summary>
        [Column("id")]
        [Description("Primary")]
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public Guid Id { get; set; }
    }
}
