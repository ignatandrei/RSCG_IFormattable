using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using System;
using System.Collections.Immutable;

namespace RSCG_IFormattable;
[Generator]
public class GeneratorIFormattable : IIncrementalGenerator
{
    public void Initialize(IncrementalGeneratorInitializationContext context)
    {

        var classToImplement = context.SyntaxProvider
                         .ForAttributeWithMetadataName("RSCG_IFormattableCommon.AddIFormattableAttribute",
                                                       CouldBeClass,
                                                       GetClassInfo)
                         .Collect();
       ; 
        context.RegisterSourceOutput(classToImplement,
            (info, source) =>
            GeneratorData(info, source)
        );
        
    }

    private void GeneratorData(SourceProductionContext spc,ImmutableArray<InfoClass> source)
    {
        if(source.Length == 0)
            return;

        foreach (var item in source)
        {
            var gen = new RazorGenerator(item);
            var data = gen.Render();
            spc.AddSource($"{item.name}.gen.cs", data);
        }
    }

    private static bool CouldBeClass(
    SyntaxNode syntaxNode,
    CancellationToken cancellationToken)
    {
        return syntaxNode is ClassDeclarationSyntax classDeclaration 
               ;
    }
    private static InfoClass GetClassInfo(
    GeneratorAttributeSyntaxContext context,
    CancellationToken cancellationToken)
    {
        var type = (INamedTypeSymbol)context.TargetSymbol;
        var enumInfo = new InfoClass(type);

        return enumInfo;
    }
}
