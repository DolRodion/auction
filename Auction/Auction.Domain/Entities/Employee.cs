using Auction.Domain.Entities;
using MBC.Core.Domain.Controls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace Auction.Domain.Entities
{
    /// <summary>
    /// Работник
    /// </summary>
    [Table("employees")]
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

        /// <summary>
        /// Тригер админ или обычный юзер
        /// </summary>
        [Column("is_admin")]
        [Description("Админ?")]
        public bool IsAdmin { get; set; }

        /// <summary>
        /// Ссылка на AspNetUsers
        /// </summary>
        [Column("asp_net_user_id")]
        [Description("Данные пользователя")]
        public Guid AspNetUserId { get; set; }

        /// <summary>
        /// Навигационное свойство
        /// </summary>
        [Description("Навигационное свойство")]
        public AspNetUsers AspNetUser { get; set; }
    }
}