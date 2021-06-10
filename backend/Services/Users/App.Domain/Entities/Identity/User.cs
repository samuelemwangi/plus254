/// <summary>
/// User Entity
/// </summary>

namespace App.Domain.Entities.Identity
{
    public class User : BaseEntity
    {
        //PK for user should be string 
        public new string Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UserEmail { get; set; }
        public string EmailConfirmationToken { get; set; }
        public string ForgotPasswordToken { get; set; }

    }
}