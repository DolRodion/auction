using MBC.Core.Domain.Controls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Auction.Domain.Entities
{
    public class AspNetUsers : BaseEntity
    {
        /// <summary>
        /// Имя
        /// </summary>
        [Column("login")]
        [Description("Логин")]
        public string Login { get; set; }

        /// <summary>
        /// Фамилия
        /// </summary>
        [Column("email")]
        [Description("email")]
        public string Email { get; set; }

        /// <summary>
        /// Пароль
        /// </summary>
        [Column("password_hash")]
        [Description("Пароль")]
        public string PasswordHash { get; set; }

        /// <summary>
        /// Роль
        /// </summary>
        [Column("phone_number")]
        [Description("Телефон")]
        public string PhoneNumber { get; set; }

        /// <summary>
        /// Роль
        /// </summary>
        [Column("lockout_end")]
        [Description("Дата окончания блокировки")]
        public DateTime? LockoutEnd { get; set; }

        /// <summary>
        /// Роль
        /// </summary>
        [Column("lockout_enabled")]
        [Description("Состояние блокировки учётной записи")]
        public bool LockoutEnabled { get; set; }

        /// <summary>
        /// Роль
        /// </summary>
        [Column("access_failed_count")]
        [Description("Кол-во не удачных попыток входа")]
        public short AccessFailedCount { get; set; }

        /// <summary>
        /// Навигационное свойство
        /// </summary>
        [Description("Навигационное свойство")]
        public Employee Employee { get; set; }
    }
}
