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
    internal string Name { get; private set; }
    public bool AdmitNulls { get; private set; }
    public bool ArrayOfIFormattable { get; private set; }
    public PropertyGet(IPropertySymbol it)
    {
        this.Name = it.Name;
        
        var gettype = it.GetMethod!.ReturnType;
        AdmitNulls = gettype.IsReferenceType || gettype.Name.ToLower()=="string" || gettype.Name.ToLower() == "system.string";
        
    }
}
