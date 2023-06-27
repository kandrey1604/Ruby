using System.ComponentModel.DataAnnotations;

namespace Ruby.Models
{
    public class Send
    {
        [Required(ErrorMessage = "Не указано имя")]

        public string Name { get; set; }
        [RegularExpression(@"[A-Za-z0-9._$+-]+@[A-Za-z0-9.-]+.[A-Za-z]{2,4}", ErrorMessage = "Некорректный адрес")]
        [Required(ErrorMessage = "Не указан Email")]

        public string Email { get; set; }
        [Required(ErrorMessage = "Поле не может быть пустым")]

        public string Message { get; set; }
    }
}
