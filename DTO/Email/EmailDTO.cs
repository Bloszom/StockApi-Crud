namespace morningclassonapi.DTO.Email
{
    public class EmailDTO
    {
        public String To { get; set; } = string.Empty;

        public String Subject { get; set; } = string.Empty;
 
        public string UserName { get; set; }

        public string Otp {  get; set; }

    }
}
