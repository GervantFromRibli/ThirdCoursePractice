#pragma checksum "D:\programms\ThirdCoursePractice\ThirdCoursePractice\TicketManagementPractice\src\TicketManagement.Web\Views\Seat\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "ad520ec1f718d510a5dd12d31b1bf81fb78a9f6e"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Seat_Index), @"mvc.1.0.view", @"/Views/Seat/Index.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"ad520ec1f718d510a5dd12d31b1bf81fb78a9f6e", @"/Views/Seat/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"5c1d669a81af8e4833eb66ffa47e8bb37e667a78", @"/Views/_ViewImports.cshtml")]
    public class Views_Seat_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<TicketManagement.Web.Models.SeatViewModel>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("method", "get", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Index", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-route-type", "Id", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-route-type", "areaDes", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-route-type", "row", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_5 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-route-type", "numb", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_6 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("btn"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_7 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("style", new global::Microsoft.AspNetCore.Html.HtmlString("border:2px solid white;"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_8 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("onbeforeunload", new global::Microsoft.AspNetCore.Html.HtmlString("SetSession()"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_9 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("onload", new global::Microsoft.AspNetCore.Html.HtmlString("GetSession()"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.BodyTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 2 "D:\programms\ThirdCoursePractice\ThirdCoursePractice\TicketManagementPractice\src\TicketManagement.Web\Views\Seat\Index.cshtml"
  
    ViewBag.Title = "Таблица мест";

#line default
#line hidden
#nullable disable
            WriteLiteral(@"<script>
    function changeAddVisibility() {
        document.getElementById('UpdateSeat').style.display = ""none"";
        document.getElementById('AddSeat').style.display = ""block"";
    }
    function changeUpdateVisibility(id) {
        document.getElementById('UpdateSeat').style.display = ""block"";
        document.getElementById('AddSeat').style.display = ""none"";
        $(""#id"").val(id);
    }
    function SetSession() {
        sessionStorage.setItem(""areaDescr"", $(""#value1 option:selected"").val());
    }
    function GetSession() {
        $(""#value1"").val(sessionStorage.getItem(""areaDescr""));
    }
</script>

");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("body", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "ad520ec1f718d510a5dd12d31b1bf81fb78a9f6e7928", async() => {
                WriteLiteral("\n    <H1 style=\"margin-top:15px;\">");
#nullable restore
#line 24 "D:\programms\ThirdCoursePractice\ThirdCoursePractice\TicketManagementPractice\src\TicketManagement.Web\Views\Seat\Index.cshtml"
                            Write(ViewBag.Title);

#line default
#line hidden
#nullable disable
                WriteLiteral(":</H1>\n    ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "ad520ec1f718d510a5dd12d31b1bf81fb78a9f6e8525", async() => {
                    WriteLiteral("\n        <div>\n            <label class=\"control-label\">Описание зоны:&nbsp;</label>\n            <select name=\"areaDescr\" id=\"value1\" class=\"form-control\">\n");
#nullable restore
#line 29 "D:\programms\ThirdCoursePractice\ThirdCoursePractice\TicketManagementPractice\src\TicketManagement.Web\Views\Seat\Index.cshtml"
                 foreach (var elem in Model.FilterAreaDescriptions)
                {

#line default
#line hidden
#nullable disable
                    WriteLiteral("                    ");
                    __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "ad520ec1f718d510a5dd12d31b1bf81fb78a9f6e9308", async() => {
#nullable restore
#line 31 "D:\programms\ThirdCoursePractice\ThirdCoursePractice\TicketManagementPractice\src\TicketManagement.Web\Views\Seat\Index.cshtml"
                       Write(elem);

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
#line 32 "D:\programms\ThirdCoursePractice\ThirdCoursePractice\TicketManagementPractice\src\TicketManagement.Web\Views\Seat\Index.cshtml"
                }

#line default
#line hidden
#nullable disable
                    WriteLiteral("            </select>\n        </div>\n        <br />\n        <div>\n            <input type=\"submit\" value=\"Фильтр\" class=\"btn btn-default\" />\n        </div>\n    ");
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
                __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
                __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Method = (string)__tagHelperAttribute_0.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\n    <br />\n    <div>\n        <table border=\"1\">\n            <thead>\n                <tr>\n                    <td>\n                        ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "ad520ec1f718d510a5dd12d31b1bf81fb78a9f6e12390", async() => {
                    WriteLiteral("Id");
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
                __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_1.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
                if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
                {
                    throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-type", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
                }
                __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["type"] = (string)__tagHelperAttribute_2.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\n                    </td>\n                    <td>\n                        ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "ad520ec1f718d510a5dd12d31b1bf81fb78a9f6e14219", async() => {
                    WriteLiteral("Описание зоны");
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
                __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_1.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
                if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
                {
                    throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-type", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
                }
                __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["type"] = (string)__tagHelperAttribute_3.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_3);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\n                    </td>\n                    <td>\n                        ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "ad520ec1f718d510a5dd12d31b1bf81fb78a9f6e16059", async() => {
                    WriteLiteral("Ряд");
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
                __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_1.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
                if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
                {
                    throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-type", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
                }
                __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["type"] = (string)__tagHelperAttribute_4.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_4);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\n                    </td>\n                    <td>\n                        ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "ad520ec1f718d510a5dd12d31b1bf81fb78a9f6e17889", async() => {
                    WriteLiteral("Место");
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
                __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_1.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
                if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
                {
                    throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-type", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
                }
                __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["type"] = (string)__tagHelperAttribute_5.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_5);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\n                    </td>\n                </tr>\n            </thead>\n");
#nullable restore
#line 59 "D:\programms\ThirdCoursePractice\ThirdCoursePractice\TicketManagementPractice\src\TicketManagement.Web\Views\Seat\Index.cshtml"
             foreach (var elem in Model.Seats)
            {

#line default
#line hidden
#nullable disable
                WriteLiteral("                <tr>\n                    <td>\n                        <input type=\"button\" class=\"btn-default\" style=\"border:hidden; width:100%; background-color: rgba(0,100,0,0.9); color:white;\"");
                BeginWriteAttribute("value", " value=\"", 2229, "\"", 2245, 1);
#nullable restore
#line 63 "D:\programms\ThirdCoursePractice\ThirdCoursePractice\TicketManagementPractice\src\TicketManagement.Web\Views\Seat\Index.cshtml"
WriteAttributeValue("", 2237, elem.Id, 2237, 8, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                BeginWriteAttribute("onclick", " onclick=\"", 2246, "\"", 2288, 3);
                WriteAttributeValue("", 2256, "changeUpdateVisibility(", 2256, 23, true);
#nullable restore
#line 63 "D:\programms\ThirdCoursePractice\ThirdCoursePractice\TicketManagementPractice\src\TicketManagement.Web\Views\Seat\Index.cshtml"
WriteAttributeValue("", 2279, elem.Id, 2279, 8, false);

#line default
#line hidden
#nullable disable
                WriteAttributeValue("", 2287, ")", 2287, 1, true);
                EndWriteAttribute();
                WriteLiteral(" />\n                    </td>\n                    <td>\n                        ");
#nullable restore
#line 66 "D:\programms\ThirdCoursePractice\ThirdCoursePractice\TicketManagementPractice\src\TicketManagement.Web\Views\Seat\Index.cshtml"
                   Write(elem.AreaDescription);

#line default
#line hidden
#nullable disable
                WriteLiteral("\n                    </td>\n                    <td>\n                        ");
#nullable restore
#line 69 "D:\programms\ThirdCoursePractice\ThirdCoursePractice\TicketManagementPractice\src\TicketManagement.Web\Views\Seat\Index.cshtml"
                   Write(elem.Row);

#line default
#line hidden
#nullable disable
                WriteLiteral("\n                    </td>\n                    <td>\n                        ");
#nullable restore
#line 72 "D:\programms\ThirdCoursePractice\ThirdCoursePractice\TicketManagementPractice\src\TicketManagement.Web\Views\Seat\Index.cshtml"
                   Write(elem.Number);

#line default
#line hidden
#nullable disable
                WriteLiteral("\n                    </td>\n                </tr>\n");
#nullable restore
#line 75 "D:\programms\ThirdCoursePractice\ThirdCoursePractice\TicketManagementPractice\src\TicketManagement.Web\Views\Seat\Index.cshtml"
            }

#line default
#line hidden
#nullable disable
                WriteLiteral("        </table>\n    </div>\n    <div>\n");
#nullable restore
#line 79 "D:\programms\ThirdCoursePractice\ThirdCoursePractice\TicketManagementPractice\src\TicketManagement.Web\Views\Seat\Index.cshtml"
         if (Model.PageViewModel.HasPreviousPage)
        {

#line default
#line hidden
#nullable disable
                WriteLiteral("            ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "ad520ec1f718d510a5dd12d31b1bf81fb78a9f6e22949", async() => {
                    WriteLiteral("\n                <i class=\"glyphicon glyphicon-chevron-left\"></i>\n                Назад\n            ");
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
                __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_1.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
                if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
                {
                    throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-page", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
                }
                BeginWriteTagHelperAttribute();
#nullable restore
#line 82 "D:\programms\ThirdCoursePractice\ThirdCoursePractice\TicketManagementPractice\src\TicketManagement.Web\Views\Seat\Index.cshtml"
                    WriteLiteral(Model.PageViewModel.PageNumber - 1);

#line default
#line hidden
#nullable disable
                __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
                __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["page"] = __tagHelperStringValueBuffer;
                __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-page", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["page"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_6);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_7);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\n");
#nullable restore
#line 87 "D:\programms\ThirdCoursePractice\ThirdCoursePractice\TicketManagementPractice\src\TicketManagement.Web\Views\Seat\Index.cshtml"
        }

#line default
#line hidden
#nullable disable
#nullable restore
#line 88 "D:\programms\ThirdCoursePractice\ThirdCoursePractice\TicketManagementPractice\src\TicketManagement.Web\Views\Seat\Index.cshtml"
         if (Model.PageViewModel.HasNextPage)
        {

#line default
#line hidden
#nullable disable
                WriteLiteral("            ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "ad520ec1f718d510a5dd12d31b1bf81fb78a9f6e26058", async() => {
                    WriteLiteral("\n                Вперед\n                <i class=\"glyphicon glyphicon-chevron-right\"></i>\n            ");
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
                __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_1.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
                if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
                {
                    throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-page", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
                }
                BeginWriteTagHelperAttribute();
#nullable restore
#line 91 "D:\programms\ThirdCoursePractice\ThirdCoursePractice\TicketManagementPractice\src\TicketManagement.Web\Views\Seat\Index.cshtml"
                    WriteLiteral(Model.PageViewModel.PageNumber + 1);

#line default
#line hidden
#nullable disable
                __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
                __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["page"] = __tagHelperStringValueBuffer;
                __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-page", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["page"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_6);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_7);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\n");
#nullable restore
#line 96 "D:\programms\ThirdCoursePractice\ThirdCoursePractice\TicketManagementPractice\src\TicketManagement.Web\Views\Seat\Index.cshtml"
        }

#line default
#line hidden
#nullable disable
                WriteLiteral("    </div>\n    <br />\n    <div>\n        <input type=\"submit\" class=\"btn-default\" value=\"Добавить запись\" onclick=\"changeAddVisibility()\" />\n    </div>\n    <hr />\n    ");
#nullable restore
#line 103 "D:\programms\ThirdCoursePractice\ThirdCoursePractice\TicketManagementPractice\src\TicketManagement.Web\Views\Seat\Index.cshtml"
Write(ViewData["Message"]);

#line default
#line hidden
#nullable disable
                WriteLiteral("\n    <div>\n        <div id=\"AddSeat\" style=\"display:none;\">\n");
#nullable restore
#line 106 "D:\programms\ThirdCoursePractice\ThirdCoursePractice\TicketManagementPractice\src\TicketManagement.Web\Views\Seat\Index.cshtml"
              await Html.RenderPartialAsync("_AddSeat");

#line default
#line hidden
#nullable disable
                WriteLiteral("        </div>\n        <div id=\"UpdateSeat\" style=\"display:none;\">\n");
#nullable restore
#line 109 "D:\programms\ThirdCoursePractice\ThirdCoursePractice\TicketManagementPractice\src\TicketManagement.Web\Views\Seat\Index.cshtml"
              await Html.RenderPartialAsync("_UpdateSeat");

#line default
#line hidden
#nullable disable
                WriteLiteral("        </div>\n    </div>\n");
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.BodyTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_8);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_9);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<TicketManagement.Web.Models.SeatViewModel> Html { get; private set; }
    }
}
#pragma warning restore 1591
