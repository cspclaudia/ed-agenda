#pragma checksum "C:\Users\cspcl\Documents\GitHub\ed-agenda\Agenda\Views\LinkedList\Navigation.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "49af868476bc061308987eced471a934b744deef"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_LinkedList_Navigation), @"mvc.1.0.view", @"/Views/LinkedList/Navigation.cshtml")]
namespace AspNetCore
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.AspNetCore.Mvc.ViewFeatures;
#nullable restore
#line 1 "C:\Users\cspcl\Documents\GitHub\ed-agenda\Agenda\Views\_ViewImports.cshtml"
using Agenda;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\cspcl\Documents\GitHub\ed-agenda\Agenda\Views\_ViewImports.cshtml"
using Agenda.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"49af868476bc061308987eced471a934b744deef", @"/Views/LinkedList/Navigation.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"d36845afd86d39266a46b24ffb4cec0212e7cd5a", @"/Views/_ViewImports.cshtml")]
    public class Views_LinkedList_Navigation : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<Agenda.Models.Node>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Index", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        #line hidden
        #pragma warning disable 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperExecutionContext __tagHelperExecutionContext;
        #pragma warning restore 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner __tagHelperRunner = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner();
        #pragma warning disable 0169
        private string __tagHelperStringValueBuffer;
        #pragma warning restore 0169
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __backed__tagHelperScopeManager = null;
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __tagHelperScopeManager
        {
            get
            {
                if (__backed__tagHelperScopeManager == null)
                {
                    __backed__tagHelperScopeManager = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager(StartTagHelperWritingScope, EndTagHelperWritingScope);
                }
                return __backed__tagHelperScopeManager;
            }
        }
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 3 "C:\Users\cspcl\Documents\GitHub\ed-agenda\Agenda\Views\LinkedList\Navigation.cshtml"
  
    ViewData["Title"] = "Contatos";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<h1>Navegando pelos Contatos</h1>\r\n\r\n<p>\r\n    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "49af868476bc061308987eced471a934b744deef3696", async() => {
                WriteLiteral("Voltar");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n</p>\r\n\r\n<table class=\"table\" id=\"table\">\r\n    <thead>\r\n        <tr>\r\n            <th>\r\n                ");
#nullable restore
#line 17 "C:\Users\cspcl\Documents\GitHub\ed-agenda\Agenda\Views\LinkedList\Navigation.cshtml"
           Write(Html.DisplayNameFor(model => model.Id));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
#nullable restore
#line 20 "C:\Users\cspcl\Documents\GitHub\ed-agenda\Agenda\Views\LinkedList\Navigation.cshtml"
           Write(Html.DisplayNameFor(model => model.Contato));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
#nullable restore
#line 23 "C:\Users\cspcl\Documents\GitHub\ed-agenda\Agenda\Views\LinkedList\Navigation.cshtml"
           Write(Html.DisplayNameFor(model => model.Before));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
#nullable restore
#line 26 "C:\Users\cspcl\Documents\GitHub\ed-agenda\Agenda\Views\LinkedList\Navigation.cshtml"
           Write(Html.DisplayNameFor(model => model.Next));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </th>\r\n            <th></th>\r\n        </tr>\r\n    </thead>\r\n    <tbody>\r\n");
#nullable restore
#line 32 "C:\Users\cspcl\Documents\GitHub\ed-agenda\Agenda\Views\LinkedList\Navigation.cshtml"
       var aux = Model; 

#line default
#line hidden
#nullable disable
            WriteLiteral("        <tr>\r\n            <td>\r\n                ");
#nullable restore
#line 35 "C:\Users\cspcl\Documents\GitHub\ed-agenda\Agenda\Views\LinkedList\Navigation.cshtml"
           Write(Html.DisplayFor(modelItem => aux.Id));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n                ");
#nullable restore
#line 38 "C:\Users\cspcl\Documents\GitHub\ed-agenda\Agenda\Views\LinkedList\Navigation.cshtml"
           Write(Html.DisplayFor(modelItem => aux.Contato));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n                ");
#nullable restore
#line 41 "C:\Users\cspcl\Documents\GitHub\ed-agenda\Agenda\Views\LinkedList\Navigation.cshtml"
           Write(Html.DisplayFor(modelItem => aux.Before));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n                ");
#nullable restore
#line 44 "C:\Users\cspcl\Documents\GitHub\ed-agenda\Agenda\Views\LinkedList\Navigation.cshtml"
           Write(Html.DisplayFor(modelItem => aux.Next.Id));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </td>\r\n        </tr>\r\n    </tbody>\r\n</table>\r\n\r\n");
            WriteLiteral("\r\n<input type=\"hidden\"");
            BeginWriteAttribute("value", " value=\"", 1349, "\"", 1369, 1);
#nullable restore
#line 53 "C:\Users\cspcl\Documents\GitHub\ed-agenda\Agenda\Views\LinkedList\Navigation.cshtml"
WriteAttributeValue("", 1357, aux.Next.Id, 1357, 12, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" id=\"next\">\r\n<input type=\"hidden\"");
            BeginWriteAttribute("value", " value=\"", 1403, "\"", 1422, 1);
#nullable restore
#line 54 "C:\Users\cspcl\Documents\GitHub\ed-agenda\Agenda\Views\LinkedList\Navigation.cshtml"
WriteAttributeValue("", 1411, aux.Before, 1411, 11, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" id=\"before\">\r\n\r\n");
            DefineSection("Scripts", async() => {
                WriteLiteral("\r\n");
#nullable restore
#line 57 "C:\Users\cspcl\Documents\GitHub\ed-agenda\Agenda\Views\LinkedList\Navigation.cshtml"
      await Html.RenderPartialAsync("_ValidationScriptsPartial");

#line default
#line hidden
#nullable disable
                WriteLiteral(@"    <script>
    document.addEventListener(""keydown"", keyDown, true);
        function keyDown(e) {
            if (e.keyCode == 39) {
                window.location.href = ""/LinkedList/Navigation/"" + $('#next').val();
            }
            else if (e.keyCode == 37) {
                window.location.href = ""/LinkedList/Navigation/"" + $('#before').val();
            }
        }
    </script>
");
            }
            );
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<Agenda.Models.Node> Html { get; private set; }
    }
}
#pragma warning restore 1591
