namespace Shared.Resources
{
    public interface IResourceService
    {
        string GetResource(string key);
        void LoadResources();
    }
}
