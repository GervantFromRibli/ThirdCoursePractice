#pragma checksum "D:\programms\ThirdCoursePractice\ThirdCoursePractice\TicketManagementPractice\src\TicketManagement.Web\Views\Venue\_AddVenue.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "7b21f7a2cb61b8ea70e2cf8c227a3c773adf450e"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Venue__AddVenue), @"mvc.1.0.view", @"/Views/Venue/_AddVenue.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"7b21f7a2cb61b8ea70e2cf8c227a3c773adf450e", @"/Views/Venue/_AddVenue.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"5c1d669a81af8e4833eb66ffa47e8bb37e667a78", @"/Views/_ViewImports.cshtml")]
    public class Views_Venue__AddVenue : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<VenueViewModel>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("<h3 style=\"margin-top:15px;\">\n    Добавление записи\n</h3>\n<hr />\n");
#nullable restore
#line 6 "D:\programms\ThirdCoursePractice\ThirdCoursePractice\TicketManagementPractice\src\TicketManagement.Web\Views\Venue\_AddVenue.cshtml"
 using (Html.BeginForm("AddVenue", "Venue", FormMethod.Post))
{

#line default
#line hidden
#nullable disable
            WriteLiteral("    <div>\n        ");
#nullable restore
#line 9 "D:\programms\ThirdCoursePractice\ThirdCoursePractice\TicketManagementPractice\src\TicketManagement.Web\Views\Venue\_AddVenue.cshtml"
   Write(Html.LabelFor(m => m.Description));

#line default
#line hidden
#nullable disable
            WriteLiteral("\n        <div class=\"col-md-10\">\n            ");
#nullable restore
#line 11 "D:\programms\ThirdCoursePractice\ThirdCoursePractice\TicketManagementPractice\src\TicketManagement.Web\Views\Venue\_AddVenue.cshtml"
       Write(Html.TextBoxFor(m => m.Description));

#line default
#line hidden
#nullable disable
            WriteLiteral("\n        </div>\n    </div>\n    <div>\n        ");
#nullable restore
#line 15 "D:\programms\ThirdCoursePractice\ThirdCoursePractice\TicketManagementPractice\src\TicketManagement.Web\Views\Venue\_AddVenue.cshtml"
   Write(Html.LabelFor(m => m.Address));

#line default
#line hidden
#nullable disable
            WriteLiteral("\n        <div class=\"col-md-10\">\n            ");
#nullable restore
#line 17 "D:\programms\ThirdCoursePractice\ThirdCoursePractice\TicketManagementPractice\src\TicketManagement.Web\Views\Venue\_AddVenue.cshtml"
       Write(Html.TextBoxFor(m => m.Address));

#line default
#line hidden
#nullable disable
            WriteLiteral("\n        </div>\n    </div>\n    <div>\n        ");
#nullable restore
#line 21 "D:\programms\ThirdCoursePractice\ThirdCoursePractice\TicketManagementPractice\src\TicketManagement.Web\Views\Venue\_AddVenue.cshtml"
   Write(Html.LabelFor(m => m.Phone));

#line default
#line hidden
#nullable disable
            WriteLiteral("\n        <div class=\"col-md-10\">\n            ");
#nullable restore
#line 23 "D:\programms\ThirdCoursePractice\ThirdCoursePractice\TicketManagementPractice\src\TicketManagement.Web\Views\Venue\_AddVenue.cshtml"
       Write(Html.TextBoxFor(m => m.Phone));

#line default
#line hidden
#nullable disable
            WriteLiteral("\n        </div>\n    </div>\n    <br />\n    <input type=\"submit\" class=\"btn btn-default\" style=\"left:15px; position:relative\" value=\"Добавить\" />\n");
#nullable restore
#line 28 "D:\programms\ThirdCoursePractice\ThirdCoursePractice\TicketManagementPractice\src\TicketManagement.Web\Views\Venue\_AddVenue.cshtml"
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<VenueViewModel> Html { get; private set; }
    }
}
#pragma warning restore 1591
