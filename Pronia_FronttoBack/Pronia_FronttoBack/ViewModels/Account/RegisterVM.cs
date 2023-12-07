namespace Pronia_FronttoBack.ViewModels
{
    public class RegisterVM
    {
        public int Id { get; set; }

        [Required]
        [MinLength(3)]
        [MaxLength(20)]
        public string Name { get; set; }

        [MaxLength(30)]
        public string Surname { get; set; }

        [Required]
        [MaxLength (35)]
        public string Username { get; set; }

        [Required]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [DataType(DataType.Password),Compare(nameof(Password))]
        public string ComfirmedPassword { get; set; }
    }
}
