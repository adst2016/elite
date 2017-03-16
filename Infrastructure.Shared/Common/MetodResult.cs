namespace Infrastructure.Shared.Common
{
    public class MetodResult
    {
        public bool ErrorOccured { get; private set; }
        public string ErrorMessage { get; private set; }

        private MetodResult(bool errorOccured)
        {
            ErrorOccured = errorOccured;
        }

        private MetodResult(bool errorOccured, string errorMessage)
        {
            ErrorOccured = errorOccured;
            ErrorMessage = errorMessage;
        }

        public static MetodResult ReturnSuccess()
        {
            return new MetodResult(false);
        }

        public static MetodResult ReturnError()
        {
            return new MetodResult(true);
        }

        public static MetodResult ReturnError(string errorMessage)
        {
            return new MetodResult(true, errorMessage);
        }
    }
}
