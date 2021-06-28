#pragma checksum "D:\programms\ThirdCoursePractice\ThirdCoursePractice\TicketManagementPractice\src\TicketManagement.Web\Views\Seat\_AddSeat.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "d436f407ea858546e94176747458b5a7592ff728"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Seat__AddSeat), @"mvc.1.0.view", @"/Views/Seat/_AddSeat.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"d436f407ea858546e94176747458b5a7592ff728", @"/Views/Seat/_AddSeat.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"5c1d669a81af8e4833eb66ffa47e8bb37e667a78", @"/Views/_ViewImports.cshtml")]
    public class Views_Seat__AddSeat : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<SeatViewModel>
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
#line 2 "D:\programms\ThirdCoursePractice\ThirdCoursePractice\TicketManagementPractice\src\TicketManagement.Web\Views\Seat\_AddSeat.cshtml"
   
    List<string> areaDescrs = new List<string>();
    areaDescrs.AddRange(Model.FilterAreaDescriptions);
    areaDescrs.Remove("Все");

#line default
#line hidden
#nullable disable
            WriteLiteral("<h3 style=\"margin-top:15px;\">\n    Добавление записи\n</h3>\n<hr />\n");
#nullable restore
#line 11 "D:\programms\ThirdCoursePractice\ThirdCoursePractice\TicketManagementPractice\src\TicketManagement.Web\Views\Seat\_AddSeat.cshtml"
 using (Html.BeginForm("AddSeat", "Seat", FormMethod.Post))
{

#line default
#line hidden
#nullable disable
            WriteLiteral("    <div>\n        ");
#nullable restore
#line 14 "D:\programms\ThirdCoursePractice\ThirdCoursePractice\TicketManagementPractice\src\TicketManagement.Web\Views\Seat\_AddSeat.cshtml"
   Write(Html.LabelFor(m => m.AreaDescription));

#line default
#line hidden
#nullable disable
            WriteLiteral("\n        <div class=\"col-md-10\">\n            <select name=\"AreaDescription\">\n");
#nullable restore
#line 17 "D:\programms\ThirdCoursePractice\ThirdCoursePractice\TicketManagementPractice\src\TicketManagement.Web\Views\Seat\_AddSeat.cshtml"
                 foreach (var addr in areaDescrs)
                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "d436f407ea858546e94176747458b5a7592ff7284694", async() => {
#nullable restore
#line 19 "D:\programms\ThirdCoursePractice\ThirdCoursePractice\TicketManagementPractice\src\TicketManagement.Web\Views\Seat\_AddSeat.cshtml"
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
#line 20 "D:\programms\ThirdCoursePractice\ThirdCoursePractice\TicketManagementPractice\src\TicketManagement.Web\Views\Seat\_AddSeat.cshtml"
                }

#line default
#line hidden
#nullable disable
            WriteLiteral("            </select>\n        </div>\n    </div>\n    <div>\n        ");
#nullable restore
#line 25 "D:\programms\ThirdCoursePractice\ThirdCoursePractice\TicketManagementPractice\src\TicketManagement.Web\Views\Seat\_AddSeat.cshtml"
   Write(Html.LabelFor(m => m.Row));

#line default
#line hidden
#nullable disable
            WriteLiteral("\n        <div class=\"col-md-10\">\n            ");
#nullable restore
#line 27 "D:\programms\ThirdCoursePractice\ThirdCoursePractice\TicketManagementPractice\src\TicketManagement.Web\Views\Seat\_AddSeat.cshtml"
       Write(Html.TextBoxFor(m => m.Row));

#line default
#line hidden
#nullable disable
            WriteLiteral("\n        </div>\n    </div>\n    <div>\n        ");
#nullable restore
#line 31 "D:\programms\ThirdCoursePractice\ThirdCoursePractice\TicketManagementPractice\src\TicketManagement.Web\Views\Seat\_AddSeat.cshtml"
   Write(Html.LabelFor(m => m.Number));

#line default
#line hidden
#nullable disable
            WriteLiteral("\n        <div class=\"col-md-10\">\n            ");
#nullable restore
#line 33 "D:\programms\ThirdCoursePractice\ThirdCoursePractice\TicketManagementPractice\src\TicketManagement.Web\Views\Seat\_AddSeat.cshtml"
       Write(Html.TextBoxFor(m => m.Number));

#line default
#line hidden
#nullable disable
            WriteLiteral("\n        </div>\n    </div>\n    <br />\n    <input type=\"submit\" class=\"btn btn-default\" style=\"left:15px; position:relative\" value=\"Добавить\" />\n");
#nullable restore
#line 38 "D:\programms\ThirdCoursePractice\ThirdCoursePractice\TicketManagementPractice\src\TicketManagement.Web\Views\Seat\_AddSeat.cshtml"
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<SeatViewModel> Html { get; private set; }
    }
}
#pragma warning restore 1591
