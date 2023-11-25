using System.ComponentModel.DataAnnotations;
using LR10.Attributes;

namespace LR10.Models
{
    public class RegisterModel
    {
        [Required(ErrorMessage = "Поле Повне ім'я є обов'язковим!")]
        public string FullName { get; set; }

        [Required(ErrorMessage = "Поле Email є обов'язковим!")]
        [EmailAddress(ErrorMessage = "Введіть коректний Email!")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Поле дата консультації є обов'язковим!")]
        [CheckDate(ErrorMessage = "Дата має бути не менше поточної!")]
        [CheckWeekday(ErrorMessage = "Консультація не проходить на вихідні!")]
        public DateTime ConsultationDate { get; set; }

        [Required(ErrorMessage = "Поле Продукт є обов'язковим")]
        public string SelectedProduct { get; set; }
    }
}
