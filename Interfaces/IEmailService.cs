using morningclassonapi.DTO.Email;

namespace morningclassonapi.Interfaces
{
    public interface IEmailService
    {
        void SendEmail(EmailDTO mail);
    }
}
