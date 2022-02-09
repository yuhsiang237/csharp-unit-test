using System;

using Xunit;
using Moq;

using UnitTestProject;

namespace UnitTestProjectTests
{
    /// <summary>
    /// xUnit單元測試，並使用Moq的Mock
    /// 參考資料:
    /// https://github.com/Moq/moq4/wiki/Quickstart#verification
    /// https://vimsky.com/examples/detail/csharp-ex---Mock-VerifySet-method.html
    /// https://codertw.com/%E5%89%8D%E7%AB%AF%E9%96%8B%E7%99%BC/206352/
    /// </summary>
    public class UnitTest
    {
        /// <summary>
        /// 方法單元測試
        /// </summary>
        [Fact]
        public void MethodsTest()
        {
            // 準備 Mock IFoo 介面
            var mock = new Mock<IFoo>();
            // 配置準備模擬的方法，當呼叫介面中的 DoSomething 方法，並傳遞引數 "bing" 的時候，返回 true
            mock.Setup(foo => foo.DoSomething("ping")).Returns(true);
            // 現在，你可以: 
            IFoo foo = mock.Object;
            // 檢查使用時返回值為True
            Assert.True(foo.DoSomething("ping"));
        }
        /// <summary>
        /// 屬性單元測試
        /// </summary>
        [Fact]
        public void PropertiesTest()
        {
            // 準備 Mock IFoo 介面
            var mock = new Mock<IFoo>();
            // 開始 "tracking" 屬性的 sets/gets 
            mock.SetupProperty(f => f.Name);
            // 提供一個預設的值
            mock.SetupProperty(f => f.Name, "foo");
            // 現在，你可以: 
            IFoo foo = mock.Object;
            // 儲存的值 
            Assert.Equal("foo", foo.Name);
            // 重新設定一個值
            foo.Name = "bar";
            Assert.Equal("bar", foo.Name);
        }
    }
}
