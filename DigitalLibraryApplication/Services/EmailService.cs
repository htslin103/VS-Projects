namespace DigitalLibraryApplication.Services
{
    public class EmailService
    {
        public bool MailSent
        {
            get; set;
        }

        public void SendEmail()
        {
            //#TODO: Add logic
            MailSent = true;
        }
    }
}
