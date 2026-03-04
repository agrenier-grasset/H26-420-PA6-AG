class ErreurTechniqueException : Exception
{
    public ErreurTechniqueException(string message, Exception innerException) : base(message, innerException)
    {
    }
}
