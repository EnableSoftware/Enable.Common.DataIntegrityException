using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using AutoFixture;
using Xunit;

namespace Enable.Common
{
    public class DataIntegrityExceptionTests
    {
        private readonly Fixture _fixture;

        public DataIntegrityExceptionTests()
        {
            _fixture = new Fixture();
        }

        [Fact]
        public void Should_Be_An_Exception_Type()
        {
            // Act
            var sut = new DataIntegrityException();

            // Assert
            Assert.IsAssignableFrom<Exception>(sut);
        }

        [Fact]
        public void Should_Have_Default_Constructor()
        {
            // Act
            var sut = new DataIntegrityException();

            // Assert
            Assert.NotNull(sut);
        }

        [Fact]
        public void Can_Be_Initialised_With_Exception_Message()
        {
            // Arrange
            var message = _fixture.Create<string>();

            // Act
            var sut = new DataIntegrityException(message);

            // Assert
            Assert.Equal(message, sut.Message);
        }

        [Fact]
        public void Can_Be_Initialised_With_Exception_Message_And_Inner_Exception()
        {
            // Arrange
            var message = _fixture.Create<string>();
            var innerException = _fixture.Create<Exception>();

            // Act
            var sut = new DataIntegrityException(message, innerException);

            // Assert
            Assert.Equal(message, sut.Message);
            Assert.Equal(innerException, sut.InnerException);
        }

        [Fact]
        public void Should_Roundtrip_Message_During_Serialization()
        {
            // Arrange
            var formatter = new BinaryFormatter();
            var message = _fixture.Create<string>();
            var sut = new DataIntegrityException(message);

            // Act
            DataIntegrityException result;

            using (var stream = new MemoryStream())
            {
                formatter.Serialize(stream, sut);
                stream.Position = 0;
                result = (DataIntegrityException)formatter.Deserialize(stream);
            }

            // Assert
            Assert.Equal(message, result.Message);
        }
    }
}
