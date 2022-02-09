using System;

using Xunit;
using Moq;

using UnitTestProject;

namespace UnitTestProjectTests
{
    /// <summary>
    /// xUnit�椸���աA�èϥ�Moq��Mock
    /// �ѦҸ��:
    /// https://github.com/Moq/moq4/wiki/Quickstart#verification
    /// https://vimsky.com/examples/detail/csharp-ex---Mock-VerifySet-method.html
    /// https://codertw.com/%E5%89%8D%E7%AB%AF%E9%96%8B%E7%99%BC/206352/
    /// </summary>
    public class UnitTest
    {
        /// <summary>
        /// ��k�椸����
        /// </summary>
        [Fact]
        public void MethodsTest()
        {
            // �ǳ� Mock IFoo ����
            var mock = new Mock<IFoo>();
            // �t�m�ǳƼ�������k�A��I�s�������� DoSomething ��k�A�öǻ��޼� "bing" ���ɭԡA��^ true
            mock.Setup(foo => foo.DoSomething("ping")).Returns(true);
            // �{�b�A�A�i�H: 
            IFoo foo = mock.Object;
            // �ˬd�ϥήɪ�^�Ȭ�True
            Assert.True(foo.DoSomething("ping"));
        }
        /// <summary>
        /// �ݩʳ椸����
        /// </summary>
        [Fact]
        public void PropertiesTest()
        {
            // �ǳ� Mock IFoo ����
            var mock = new Mock<IFoo>();
            // �}�l "tracking" �ݩʪ� sets/gets 
            mock.SetupProperty(f => f.Name);
            // ���Ѥ@�ӹw�]����
            mock.SetupProperty(f => f.Name, "foo");
            // �{�b�A�A�i�H: 
            IFoo foo = mock.Object;
            // �x�s���� 
            Assert.Equal("foo", foo.Name);
            // ���s�]�w�@�ӭ�
            foo.Name = "bar";
            Assert.Equal("bar", foo.Name);
        }
    }
}
