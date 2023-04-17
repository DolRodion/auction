using MBC.Core.Domain.Controls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace MBC.Core.Domain.Entities
{
    /// <summary>
    /// Работник
    /// </summary>
    [Table("employee")]
    [Description("Работник")]
    public class Employee : BaseEntity
    {
        /// <summary>
        /// Имя
        /// </summary>
        [Column("first_name")]
        [Description("Имя")]
        public string FirstName { get; set; }

        /// <summary>
        /// Фамилия
        /// </summary>
        [Column("last_name")]
        [Description("Фамилия")]
        public string LastName { get; set; }

        /// <summary>
        /// Отчество
        /// </summary>
        [Column("middle_name")]
        [Description("Отчество")]
        public string MiddleName { get; set; }
    }
}