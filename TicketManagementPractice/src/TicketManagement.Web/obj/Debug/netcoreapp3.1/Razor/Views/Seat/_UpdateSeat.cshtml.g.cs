#pragma checksum "D:\programms\ThirdCoursePractice\ThirdCoursePractice\TicketManagementPractice\src\TicketManagement.Web\Views\Seat\_UpdateSeat.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "cdad33f7b2627d6a4b1395bcbf6061d69fe449d9"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Seat__UpdateSeat), @"mvc.1.0.view", @"/Views/Seat/_UpdateSeat.cshtml")]
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
#nullable restore
#line 1 "D:\programms\ThirdCoursePractice\ThirdCoursePractice\TicketManagementPractice\src\TicketManagement.Web\Views\Seat\_UpdateSeat.cshtml"
using Microsoft.AspNetCore.Mvc.Localization;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"cdad33f7b2627d6a4b1395bcbf6061d69fe449d9", @"/Views/Seat/_UpdateSeat.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"5c1d669a81af8e4833eb66ffa47e8bb37e667a78", @"/Views/_ViewImports.cshtml")]
    public class Views_Seat__UpdateSeat : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<SeatViewModel>
    {
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
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 4 "D:\programms\ThirdCoursePractice\ThirdCoursePractice\TicketManagementPractice\src\TicketManagement.Web\Views\Seat\_UpdateSeat.cshtml"
   
    List<string> areaDescrs = new List<string>();
    areaDescrs.AddRange(Model.FilterAreaDescriptions);
    areaDescrs.Remove(Localizer["All"].Value);

#line default
#line hidden
#nullable disable
            WriteLiteral("<h3 style=\"margin-top:15px;\">\r\n    ");
#nullable restore
#line 10 "D:\programms\ThirdCoursePractice\ThirdCoursePractice\TicketManagementPractice\src\TicketManagement.Web\Views\Seat\_UpdateSeat.cshtml"
Write(Localizer["Title"]);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n</h3>\r\n");
#nullable restore
#line 12 "D:\programms\ThirdCoursePractice\ThirdCoursePractice\TicketManagementPractice\src\TicketManagement.Web\Views\Seat\_UpdateSeat.cshtml"
 using (Html.BeginForm("UpdateSeat", "Seat", FormMethod.Post))
{

#line default
#line hidden
#nullable disable
            WriteLiteral("    <div>\r\n        ");
#nullable restore
#line 15 "D:\programms\ThirdCoursePractice\ThirdCoursePractice\TicketManagementPractice\src\TicketManagement.Web\Views\Seat\_UpdateSeat.cshtml"
   Write(Html.LabelFor(m => m.Id));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        <div class=\"col-md-10\">\r\n            <select name=\"Id\" id=\"id\">\r\n");
#nullable restore
#line 18 "D:\programms\ThirdCoursePractice\ThirdCoursePractice\TicketManagementPractice\src\TicketManagement.Web\Views\Seat\_UpdateSeat.cshtml"
                 foreach (var id in Model.Ids)
                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "cdad33f7b2627d6a4b1395bcbf6061d69fe449d95247", async() => {
#nullable restore
#line 20 "D:\programms\ThirdCoursePractice\ThirdCoursePractice\TicketManagementPractice\src\TicketManagement.Web\Views\Seat\_UpdateSeat.cshtml"
                       Write(id);

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
            WriteLiteral("\r\n");
#nullable restore
#line 21 "D:\programms\ThirdCoursePractice\ThirdCoursePractice\TicketManagementPractice\src\TicketManagement.Web\Views\Seat\_UpdateSeat.cshtml"
                }

#line default
#line hidden
#nullable disable
            WriteLiteral("            </select>\r\n            &nbsp;\r\n            <input name=\"action\" type=\"submit\" style=\"border:hidden; width:200px\"");
            BeginWriteAttribute("value", " value=\"", 760, "\"", 788, 1);
#nullable restore
#line 24 "D:\programms\ThirdCoursePractice\ThirdCoursePractice\TicketManagementPractice\src\TicketManagement.Web\Views\Seat\_UpdateSeat.cshtml"
WriteAttributeValue("", 768, Localizer["Remove"], 768, 20, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" />\r\n        </div>\r\n    </div>\r\n    <div>\n        <label class=\"control-label\">");
#nullable restore
#line 28 "D:\programms\ThirdCoursePractice\ThirdCoursePractice\TicketManagementPractice\src\TicketManagement.Web\Views\Seat\_UpdateSeat.cshtml"
                                Write(Localizer["AreaDescr"]);

#line default
#line hidden
#nullable disable
            WriteLiteral(":&nbsp;</label>\n        <div class=\"col-md-10\">\n            <select name=\"AreaDescription\">\n");
#nullable restore
#line 31 "D:\programms\ThirdCoursePractice\ThirdCoursePractice\TicketManagementPractice\src\TicketManagement.Web\Views\Seat\_UpdateSeat.cshtml"
                 foreach (var addr in areaDescrs)
                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "cdad33f7b2627d6a4b1395bcbf6061d69fe449d98063", async() => {
#nullable restore
#line 33 "D:\programms\ThirdCoursePractice\ThirdCoursePractice\TicketManagementPractice\src\TicketManagement.Web\Views\Seat\_UpdateSeat.cshtml"
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
#line 34 "D:\programms\ThirdCoursePractice\ThirdCoursePractice\TicketManagementPractice\src\TicketManagement.Web\Views\Seat\_UpdateSeat.cshtml"
                }

#line default
#line hidden
#nullable disable
            WriteLiteral("            </select>\n        </div>\n    </div>\n    <div>\n        <label class=\"control-label\">");
#nullable restore
#line 39 "D:\programms\ThirdCoursePractice\ThirdCoursePractice\TicketManagementPractice\src\TicketManagement.Web\Views\Seat\_UpdateSeat.cshtml"
                                Write(Localizer["Row"]);

#line default
#line hidden
#nullable disable
            WriteLiteral(":&nbsp;</label>\n        <div class=\"col-md-10\">\n            ");
#nullable restore
#line 41 "D:\programms\ThirdCoursePractice\ThirdCoursePractice\TicketManagementPractice\src\TicketManagement.Web\Views\Seat\_UpdateSeat.cshtml"
       Write(Html.TextBoxFor(m => m.Row));

#line default
#line hidden
#nullable disable
            WriteLiteral("\n        </div>\n    </div>\n    <div>\n        <label class=\"control-label\">");
#nullable restore
#line 45 "D:\programms\ThirdCoursePractice\ThirdCoursePractice\TicketManagementPractice\src\TicketManagement.Web\Views\Seat\_UpdateSeat.cshtml"
                                Write(Localizer["Number"]);

#line default
#line hidden
#nullable disable
            WriteLiteral(":&nbsp;</label>\n        <div class=\"col-md-10\">\n            ");
#nullable restore
#line 47 "D:\programms\ThirdCoursePractice\ThirdCoursePractice\TicketManagementPractice\src\TicketManagement.Web\Views\Seat\_UpdateSeat.cshtml"
       Write(Html.TextBoxFor(m => m.Number));

#line default
#line hidden
#nullable disable
            WriteLiteral("\n        </div>\n    </div>\r\n    <br />\r\n    <input type=\"submit\" class=\"btn btn-default\" style=\"left:15px; position:relative\"");
            BeginWriteAttribute("value", " value=\"", 1623, "\"", 1651, 1);
#nullable restore
#line 51 "D:\programms\ThirdCoursePractice\ThirdCoursePractice\TicketManagementPractice\src\TicketManagement.Web\Views\Seat\_UpdateSeat.cshtml"
WriteAttributeValue("", 1631, Localizer["Change"], 1631, 20, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" />\r\n");
#nullable restore
#line 52 "D:\programms\ThirdCoursePractice\ThirdCoursePractice\TicketManagementPractice\src\TicketManagement.Web\Views\Seat\_UpdateSeat.cshtml"
}

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n");
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public IViewLocalizer Localizer { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<SeatViewModel> Html { get; private set; }
    }
}
#pragma warning restore 1591
