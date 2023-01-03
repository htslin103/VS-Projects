using DigitalLibraryApplication.Services;
using Xunit;

namespace DigitalLibraryUnitTests
{
    public class EmailServiceTests
    {
        //Send Email
        [Fact]
        public void SendEmail_NoConditions_Success()
        {
            var service = new EmailService();
            service.SendEmail();

            Assert.True(service.MailSent);
        }
    }
}
