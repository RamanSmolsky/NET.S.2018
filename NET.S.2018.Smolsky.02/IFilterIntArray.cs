namespace ArrayFilters
{
    /// <summary>
    /// Provides functionality to decide if particular integer is to be filtered out or not
    /// </summary>
    public interface IFilterInt
    {
        bool ShouldBeIncluded(int elementToCheck);
    }
}
