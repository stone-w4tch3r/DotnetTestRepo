namespace RazorErrorHandling;

public class CustomServiceException(string message) : Exception(message);

public class ConcurrencyException(string message) : Exception(message);
