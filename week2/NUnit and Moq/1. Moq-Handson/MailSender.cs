namespace CustomerCommLib
{
    public interface IMailSender
    {
        bool SendMail(string toAddress, string message);
    }

    public class MailSender : IMailSender
    {
        public bool SendMail(string toAddress, string message)
        {
            throw new System.NotImplementedException();
        }
    }

    public class CustomerCommunication
    {
        private readonly IMailSender _mailSender;

        public CustomerCommunication(IMailSender mailSender)
        {
            _mailSender = mailSender;
        }

        public bool SendMailToCustomer()
        {
            return _mailSender.SendMail("cust123@abc.com", "Test Message");
        }
    }
}