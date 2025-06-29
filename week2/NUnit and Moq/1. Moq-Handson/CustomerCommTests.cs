using NUnit.Framework;
using Moq;
using CustomerCommLib;

namespace CustomerComm.Tests
{
    [TestFixture]
    public class CustomerCommTests
    {
        private CustomerCommunication _service;
        private Mock<IMailSender> _mockMailSender;

        [SetUp]
        public void Setup()
        {
            _mockMailSender = new Mock<IMailSender>();
            _service = new CustomerCommunication(_mockMailSender.Object);

            _mockMailSender
                .Setup(m => m.SendMail(It.IsAny<string>(), It.IsAny<string>()))
                .Returns(true);
        }

        [Test]
        public void SendMailToCustomer_WhenCalled_ReturnsTrue()
        {
            var result = _service.SendMailToCustomer();

            Assert.That(result, Is.True);
            _mockMailSender.Verify(
                m => m.SendMail(It.IsAny<string>(), It.IsAny<string>()),
                Times.Once);
        }
    }
}