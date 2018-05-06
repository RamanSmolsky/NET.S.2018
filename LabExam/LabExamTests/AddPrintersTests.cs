using LabExam;
using Moq;
using NUnit.Framework;

namespace LabExamTests
{
    [TestFixture]
    public class AddPrintersTests
    {
        private PrinterManager _printerManager;
        private Mock<ILogger> _mockLogger;

        [SetUp]
        public void SetUp()
        {
            _mockLogger = new Mock<ILogger>();
            _printerManager = PrinterManager.GetPrinterManager(_mockLogger.Object);
        }
        
        [TearDown]
        public void TearDown()
        {
            _printerManager.Printers.Clear();
        }

        [Test]
        public void AddCanonPrinterTest()
        {
            // Arrange
            var canonPrinter = new CanonPrinter();

            // Act
            _printerManager.Add(canonPrinter);

            // Assert
            CollectionAssert.AllItemsAreInstancesOfType(_printerManager.Printers, typeof(CanonPrinter));
        }

        [Test]
        public void AddEpsonPrinterTest()
        {
            // Arrange
            var epsonPrinter = new EpsonPrinter();

            // Act
            _printerManager.Add(epsonPrinter);

            // Assert
            CollectionAssert.AllItemsAreInstancesOfType(_printerManager.Printers, typeof(EpsonPrinter));
        }

        [Test]
        public void AddUserDefinedPrinterPrinterTest()
        {
            // Arrange
            var userDefinedPrinter = new UserDefinedPrinter("user defined", "model 1");

            // Act
            _printerManager.Add(userDefinedPrinter);

            // Assert
            CollectionAssert.AllItemsAreInstancesOfType(_printerManager.Printers, typeof(UserDefinedPrinter));
        }
    }
}