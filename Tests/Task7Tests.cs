using Microsoft.VisualStudio.TestTools.UnitTesting;
using Task7;

namespace Tests
{
    [TestClass]
    public class Task7Tests
    {
        [TestMethod]
        public void NotHammingCode()
        {
            Assert.IsFalse(HammingCode.IsHammingCode("214"));
        }
        [DataRow("1110")]
        [DataRow("100110000100001011101")]
        [TestMethod]
        public void HammingCodeWithoutError(string message)
        {
            HammingCode code = new HammingCode(message);
            Assert.IsTrue(code.ProcessHammingCode() == 0);
        }
        
        [DataRow("1111", 4)]
        [DataRow("0110", 1)]
        [DataRow("100110000110001011101", 11)]
        [TestMethod]
        public void HammingCodeWithError(string message, int index)
        {
            HammingCode code = new HammingCode(message);
            HammingCode.IsHammingCode(message);
            Assert.IsTrue(code.ProcessHammingCode() == index);
        }

        [TestMethod]
        public void ExceptionWhileProcessing()
        {
            HammingCode code = new HammingCode("1101");
            Assert.ThrowsException<HammingCode.ProcessingException>(delegate { code.ProcessHammingCode(); });
        }

        [TestMethod]
        public void TryToGetCodeWithoutProcessing()
        {
            HammingCode code = new HammingCode("1101");
            Assert.ThrowsException<HammingCode.NotProcessedHammingCodeException>(delegate { code.ToString(); });
        }
        
    }
}