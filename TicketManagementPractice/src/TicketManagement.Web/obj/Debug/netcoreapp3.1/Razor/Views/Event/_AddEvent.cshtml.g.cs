#pragma checksum "D:\programms\ThirdCoursePractice\ThirdCoursePractice\TicketManagementPractice\src\TicketManagement.Web\Views\Event\_AddEvent.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "fc668ed1a638a1ff0a2bba75eee85e36896cdaa7"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Event__AddEvent), @"mvc.1.0.view", @"/Views/Event/_AddEvent.cshtml")]
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
#line 1 "D:\programms\ThirdCoursePractice\ThirdCoursePractice\TicketManagementPractice\src\TicketManagement.Web\Views\_ViewImports.cshtml"
using TicketManagement.Web;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "D:\programms\ThirdCoursePractice\ThirdCoursePractice\TicketManagementPractice\src\TicketManagement.Web\Views\_ViewImports.cshtml"
using TicketManagement.Web.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"fc668ed1a638a1ff0a2bba75eee85e36896cdaa7", @"/Views/Event/_AddEvent.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"5c1d669a81af8e4833eb66ffa47e8bb37e667a78", @"/Views/_ViewImports.cshtml")]
    public class Views_Event__AddEvent : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<EventViewModel>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("type", "date", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("min", new global::Microsoft.AspNetCore.Html.HtmlString("2021-01-01"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.InputTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 2 "D:\programms\ThirdCoursePractice\ThirdCoursePractice\TicketManagementPractice\src\TicketManagement.Web\Views\Event\_AddEvent.cshtml"
   
    List<string> layoutDescr = new List<string>();
    layoutDescr.AddRange(Model.FilterLayoutDescriptions);
    layoutDescr.Remove("Все");

#line default
#line hidden
#nullable disable
            WriteLiteral("<h3 style=\"margin-top:15px;\">\n    Добавление записи\n</h3>\n<hr />\n");
#nullable restore
#line 11 "D:\programms\ThirdCoursePractice\ThirdCoursePractice\TicketManagementPractice\src\TicketManagement.Web\Views\Event\_AddEvent.cshtml"
 using (Html.BeginForm("AddEvent", "Event", FormMethod.Post))
{

#line default
#line hidden
#nullable disable
            WriteLiteral("    <div>\n        ");
#nullable restore
#line 14 "D:\programms\ThirdCoursePractice\ThirdCoursePractice\TicketManagementPractice\src\TicketManagement.Web\Views\Event\_AddEvent.cshtml"
   Write(Html.LabelFor(m => m.Name));

#line default
#line hidden
#nullable disable
            WriteLiteral("\n        <div class=\"col-md-10\">\n            ");
#nullable restore
#line 16 "D:\programms\ThirdCoursePractice\ThirdCoursePractice\TicketManagementPractice\src\TicketManagement.Web\Views\Event\_AddEvent.cshtml"
       Write(Html.TextBoxFor(m => m.Name));

#line default
#line hidden
#nullable disable
            WriteLiteral("\n        </div>\n    </div>\n    <div>\n        ");
#nullable restore
#line 20 "D:\programms\ThirdCoursePractice\ThirdCoursePractice\TicketManagementPractice\src\TicketManagement.Web\Views\Event\_AddEvent.cshtml"
   Write(Html.LabelFor(m => m.Description));

#line default
#line hidden
#nullable disable
            WriteLiteral("\n        <div class=\"col-md-10\">\n            ");
#nullable restore
#line 22 "D:\programms\ThirdCoursePractice\ThirdCoursePractice\TicketManagementPractice\src\TicketManagement.Web\Views\Event\_AddEvent.cshtml"
       Write(Html.TextBoxFor(m => m.Description));

#line default
#line hidden
#nullable disable
            WriteLiteral("\n        </div>\n    </div>\n    <div>\n        ");
#nullable restore
#line 26 "D:\programms\ThirdCoursePractice\ThirdCoursePractice\TicketManagementPractice\src\TicketManagement.Web\Views\Event\_AddEvent.cshtml"
   Write(Html.LabelFor(m => m.LayoutDescription));

#line default
#line hidden
#nullable disable
            WriteLiteral("\n        <div class=\"col-md-10\">\n            <select name=\"LayoutDescription\">\n");
#nullable restore
#line 29 "D:\programms\ThirdCoursePractice\ThirdCoursePractice\TicketManagementPractice\src\TicketManagement.Web\Views\Event\_AddEvent.cshtml"
                 foreach (var addr in layoutDescr)
                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "fc668ed1a638a1ff0a2bba75eee85e36896cdaa76850", async() => {
#nullable restore
#line 31 "D:\programms\ThirdCoursePractice\ThirdCoursePractice\TicketManagementPractice\src\TicketManagement.Web\Views\Event\_AddEvent.cshtml"
                       Write(addr);

#line default
#line hidden
#nullable disable
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\n");
#nullable restore
#line 32 "D:\programms\ThirdCoursePractice\ThirdCoursePractice\TicketManagementPractice\src\TicketManagement.Web\Views\Event\_AddEvent.cshtml"
                }

#line default
#line hidden
#nullable disable
            WriteLiteral("            </select>\n        </div>\n    </div>\n    <div>\n        ");
#nullable restore
#line 37 "D:\programms\ThirdCoursePractice\ThirdCoursePractice\TicketManagementPractice\src\TicketManagement.Web\Views\Event\_AddEvent.cshtml"
   Write(Html.LabelFor(m => m.StartDate));

#line default
#line hidden
#nullable disable
            WriteLiteral("\n        <div class=\"col-md-10\">\n            ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("input", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "fc668ed1a638a1ff0a2bba75eee85e36896cdaa78684", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.InputTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper.InputTypeName = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
#nullable restore
#line 39 "D:\programms\ThirdCoursePractice\ThirdCoursePractice\TicketManagementPractice\src\TicketManagement.Web\Views\Event\_AddEvent.cshtml"
__Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper.For = ModelExpressionProvider.CreateModelExpression(ViewData, __model => __model.StartDate);

#line default
#line hidden
#nullable disable
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-for", __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper.For, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\n        </div>\n    </div>\n    <div>\n        ");
#nullable restore
#line 43 "D:\programms\ThirdCoursePractice\ThirdCoursePractice\TicketManagementPractice\src\TicketManagement.Web\Views\Event\_AddEvent.cshtml"
   Write(Html.LabelFor(m => m.EndDate));

#line default
#line hidden
#nullable disable
            WriteLiteral("\n        <div class=\"col-md-10\">\n            ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("input", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "fc668ed1a638a1ff0a2bba75eee85e36896cdaa710839", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.InputTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper.InputTypeName = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
#nullable restore
#line 45 "D:\programms\ThirdCoursePractice\ThirdCoursePractice\TicketManagementPractice\src\TicketManagement.Web\Views\Event\_AddEvent.cshtml"
__Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper.For = ModelExpressionProvider.CreateModelExpression(ViewData, __model => __model.EndDate);

#line default
#line hidden
#nullable disable
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-for", __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper.For, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\n        </div>\n    </div>\n    <div>\n        ");
#nullable restore
#line 49 "D:\programms\ThirdCoursePractice\ThirdCoursePractice\TicketManagementPractice\src\TicketManagement.Web\Views\Event\_AddEvent.cshtml"
   Write(Html.LabelFor(m => m.ImagePath));

#line default
#line hidden
#nullable disable
            WriteLiteral("\n        <div class=\"col-md-10\">\n            ");
#nullable restore
#line 51 "D:\programms\ThirdCoursePractice\ThirdCoursePractice\TicketManagementPractice\src\TicketManagement.Web\Views\Event\_AddEvent.cshtml"
       Write(Html.TextBoxFor(m => m.ImagePath));

#line default
#line hidden
#nullable disable
            WriteLiteral("\n        </div>\n    </div>\n    <br />\n    <input type=\"submit\" class=\"btn btn-default\" style=\"left:15px; position:relative\" value=\"Добавить\" />\n");
#nullable restore
#line 56 "D:\programms\ThirdCoursePractice\ThirdCoursePractice\TicketManagementPractice\src\TicketManagement.Web\Views\Event\_AddEvent.cshtml"
}

#line default
#line hidden
#nullable disable
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<EventViewModel> Html { get; private set; }
    }
}
#pragma warning restore 1591