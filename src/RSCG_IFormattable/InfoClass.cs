using Microsoft.CodeAnalysis;

namespace RSCG_IFormattable;
internal class InfoClass
{
    internal readonly string name;
    internal readonly string nameSpace;
    internal readonly PropertyGet[] propsWithGet;
    public InfoClass(INamedTypeSymbol type)
    {
        name = type.Name;
        nameSpace = type.ContainingNamespace.ToDisplayString();
        propsWithGet = type
            .GetMembers()
            .OfType<IPropertySymbol>()
            .Where(it=>it !=null)
            .Where(it => it.GetMethod != null)
            .Select(it=>it!)
            .Select(it=>new PropertyGet(it))
            .ToArray(); 
    }


    
}
internal class PropertyGet
{
    internal string Name;
    public PropertyGet(IPropertySymbol it)
    {
        this.Name = it.Name;
    }
}
