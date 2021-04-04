using System;
using System.Reflection;

namespace Norbit.CRM.Tyganov.Practic13.WebApiVesrion2.Areas.HelpPage.ModelDescriptions
{
    public interface IModelDocumentationProvider
    {
        string GetDocumentation(MemberInfo member);

        string GetDocumentation(Type type);
    }
}