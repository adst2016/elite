namespace Infrastructure.Shared.Common
{
    public class MethodResult
    {
        public bool ErrorOccured { get; private set; }
        public string ErrorMessage { get; private set; }

        private MethodResult(bool errorOccured)
        {
            ErrorOccured = errorOccured;
        }

        private MethodResult(bool errorOccured, string errorMessage)
        {
            ErrorOccured = errorOccured;
            ErrorMessage = errorMessage;
        }

        public static MethodResult ReturnSuccess()
        {
            return new MethodResult(false);
        }

        public static MethodResult ReturnError()
        {
            return new MethodResult(true);
        }

        public static MethodResult ReturnError(string errorMessage)
        {
            return new MethodResult(true, errorMessage);
        }
    }
}
