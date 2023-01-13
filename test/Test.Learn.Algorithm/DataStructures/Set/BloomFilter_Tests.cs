using Learn.Algorithm.DataStructures.Set;

namespace Test.Learn.Algorithm.DataStructures.Set
{
    [TestClass]
    public class BloomFilterTests
    {
        [TestMethod]
        public void BloomFilter_Test()
        {
            var filter = new BloomFilter(100);
            filter.AddKey("abc");
            filter.AddKey("bac");
            filter.AddKey("cba");
            Assert.IsTrue(filter.KeyExists("abc"));
            Assert.IsTrue(filter.KeyExists("bac"));
            Assert.IsTrue(filter.KeyExists("cba"));

            filter.AddKey("sdfasdufasifosadfo");
            filter.AddKey("阿达大ada付款方sd欧派波阿伯过");
            Assert.IsTrue(filter.KeyExists("sdfasdufasifosadfo"));
            Assert.IsTrue(filter.KeyExists("阿达大ada付款方sd欧派波阿伯过"));

            filter.AddKey("阿斯顿发送到发斯蒂芬破局部分");
            filter.AddKey("mntyryineirtb");
            filter.AddKey("俺的沙发上店铺并发速度不发顺丰");

            Assert.IsTrue(filter.KeyExists("阿斯顿发送到发斯蒂芬破局部分"));
            Assert.IsTrue(filter.KeyExists("mntyryineirtb"));
            Assert.IsTrue(filter.KeyExists("俺的沙发上店铺并发速度不发顺丰"));
        }

    }
}