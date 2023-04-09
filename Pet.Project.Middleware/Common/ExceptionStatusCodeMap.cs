using Microsoft.AspNetCore.Http;

namespace Pet.Project.Middleware.Common;

public static class ExceptionStatusCodeMap
{
    public static readonly Dictionary<Type, int> exceptionStatusCodes = new()
    {
        { typeof(ArgumentException), StatusCodes.Status400BadRequest },
        { typeof(ArgumentNullException), StatusCodes.Status400BadRequest },
        { typeof(ArgumentOutOfRangeException), StatusCodes.Status400BadRequest },
        { typeof(IndexOutOfRangeException), StatusCodes.Status400BadRequest },
        { typeof(FormatException), StatusCodes.Status400BadRequest },
        { typeof(DivideByZeroException), StatusCodes.Status400BadRequest },
        { typeof(ArithmeticException), StatusCodes.Status400BadRequest },
        { typeof(OverflowException), StatusCodes.Status400BadRequest },
        { typeof(InvalidOperationException), StatusCodes.Status400BadRequest },
        { typeof(PathTooLongException), StatusCodes.Status400BadRequest },
        { typeof(ObjectDisposedException), StatusCodes.Status400BadRequest },
        { typeof(NullReferenceException), StatusCodes.Status400BadRequest },
        { typeof(InvalidCastException), StatusCodes.Status400BadRequest },
        { typeof(NotSupportedException), StatusCodes.Status415UnsupportedMediaType },
        { typeof(NotImplementedException), StatusCodes.Status501NotImplemented },
        { typeof(TimeoutException), StatusCodes.Status408RequestTimeout },
        { typeof(TaskCanceledException), StatusCodes.Status408RequestTimeout },
        { typeof(OperationCanceledException), StatusCodes.Status408RequestTimeout },
        { typeof(UnauthorizedAccessException), StatusCodes.Status401Unauthorized },
        { typeof(FileNotFoundException), StatusCodes.Status404NotFound },
        { typeof(DirectoryNotFoundException), StatusCodes.Status404NotFound },
        { typeof(IOException), StatusCodes.Status500InternalServerError },
        { typeof(SystemException), StatusCodes.Status500InternalServerError },
        { typeof(OutOfMemoryException), StatusCodes.Status500InternalServerError },
        { typeof(StackOverflowException), StatusCodes.Status500InternalServerError },
        { typeof(TypeInitializationException), StatusCodes.Status500InternalServerError },
        { typeof(FileLoadException), StatusCodes.Status500InternalServerError },
        { typeof(DllNotFoundException), StatusCodes.Status500InternalServerError },
        { typeof(AccessViolationException), StatusCodes.Status500InternalServerError },
        { typeof(MemberAccessException), StatusCodes.Status400BadRequest },
        { typeof(InvalidProgramException), StatusCodes.Status500InternalServerError },
    };
};