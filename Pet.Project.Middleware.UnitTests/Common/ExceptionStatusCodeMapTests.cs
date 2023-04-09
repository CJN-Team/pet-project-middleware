using FluentAssertions;
using Microsoft.AspNetCore.Http;
using Pet.Project.Middleware.Common;

namespace Pet.Project.Middleware.UnitTests.Common
{
    public class ExceptionStatusCodeMapTests
    {
        [Theory]
        [InlineData(typeof(ArgumentException), StatusCodes.Status400BadRequest)]
        [InlineData(typeof(ArgumentNullException), StatusCodes.Status400BadRequest)]
        [InlineData(typeof(ArgumentOutOfRangeException), StatusCodes.Status400BadRequest)]
        [InlineData(typeof(IndexOutOfRangeException), StatusCodes.Status400BadRequest)]
        [InlineData(typeof(FormatException), StatusCodes.Status400BadRequest)]
        [InlineData(typeof(DivideByZeroException), StatusCodes.Status400BadRequest)]
        [InlineData(typeof(ArithmeticException), StatusCodes.Status400BadRequest)]
        [InlineData(typeof(OverflowException), StatusCodes.Status400BadRequest)]
        [InlineData(typeof(InvalidOperationException), StatusCodes.Status400BadRequest)]
        [InlineData(typeof(PathTooLongException), StatusCodes.Status400BadRequest)]
        [InlineData(typeof(ObjectDisposedException), StatusCodes.Status400BadRequest)]
        [InlineData(typeof(NullReferenceException), StatusCodes.Status400BadRequest)]
        [InlineData(typeof(InvalidCastException), StatusCodes.Status400BadRequest)]
        [InlineData(typeof(NotSupportedException), StatusCodes.Status415UnsupportedMediaType)]
        [InlineData(typeof(NotImplementedException), StatusCodes.Status501NotImplemented)]
        [InlineData(typeof(TimeoutException), StatusCodes.Status408RequestTimeout)]
        [InlineData(typeof(TaskCanceledException), StatusCodes.Status408RequestTimeout)]
        [InlineData(typeof(OperationCanceledException), StatusCodes.Status408RequestTimeout)]
        [InlineData(typeof(UnauthorizedAccessException), StatusCodes.Status401Unauthorized)]
        [InlineData(typeof(FileNotFoundException), StatusCodes.Status404NotFound)]
        [InlineData(typeof(DirectoryNotFoundException), StatusCodes.Status404NotFound)]
        [InlineData(typeof(IOException), StatusCodes.Status500InternalServerError)]
        [InlineData(typeof(SystemException), StatusCodes.Status500InternalServerError)]
        [InlineData(typeof(OutOfMemoryException), StatusCodes.Status500InternalServerError)]
        [InlineData(typeof(StackOverflowException), StatusCodes.Status500InternalServerError)]
        [InlineData(typeof(TypeInitializationException), StatusCodes.Status500InternalServerError)]
        [InlineData(typeof(FileLoadException), StatusCodes.Status500InternalServerError)]
        [InlineData(typeof(DllNotFoundException), StatusCodes.Status500InternalServerError)]
        [InlineData(typeof(AccessViolationException), StatusCodes.Status500InternalServerError)]
        [InlineData(typeof(MemberAccessException), StatusCodes.Status400BadRequest)]
        [InlineData(typeof(InvalidProgramException), StatusCodes.Status500InternalServerError)]
        public void ExceptionStatusCodes_ShouldReturnExpectedStatusCode(Type exceptionType, int expectedStatusCode)
        {
            // Act
            int actualStatusCode = ExceptionStatusCodeMap.exceptionStatusCodes[exceptionType];

            // Assert
            actualStatusCode.Should().Be(expectedStatusCode);
        }
    }
}