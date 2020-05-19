<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="articlepinglun.aspx.cs"
    Inherits="PU.web.articlepinglun" %>

<%@ Register Src="/UserControl/head.ascx" TagName="head" TagPrefix="uc1" %>
<%@ Register Src="/UserControl/left.ascx" TagName="left" TagPrefix="uc2" %>
<%@ Register Src="/UserControl/footer.ascx" TagName="footer" TagPrefix="uc3" %>
<%@ Register Assembly="PubControls" Namespace="PubControls" TagPrefix="cc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>文章评论</title>
    <link href="../css/style.css" type="text/css" rel="stylesheet" />

    <script src="../js/jquery.js" type="text/javascript"></script>

    <script src="../js/PubJSLibrary.js" type="text/javascript"></script>
    <script src="../js/PUweb.js" type="text/javascript"></script>

    <script language="javascript" type="text/javascript">


        //删除报道推荐(多个)
        function deltj() {
            var newscInfoIDs = ""; //要删除的报道推荐信息ID串，多个以“,”隔开
            var sl = 0;
            $("#tabRetList").find("input[type=\"checkbox\"]").each(function (i, j) {
                if (j.checked) {
                    if (newscInfoIDs != "") newscInfoIDs += ",";
                    newscInfoIDs += j.newscInfoID;
                    sl++;
                }
            })

            if (newscInfoIDs == "") {
                alert("请至少选择一篇要删除的报道推荐！");
                return false;
            }

            //alert(newscInfoIDs);
            if (confirm("您确定要删除所选的[" + sl + "]篇报道推荐吗？")) {
                document.getElementById("HidValue").value = newscInfoIDs;
                return true;
            }
            else {
                return false;
            }

        }
    
    </script>

</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:Button ID="BtRef" runat="server" Text="刷新" CssClass="hide"  />
        <asp:HiddenField ID="HidValue" runat="server" />
        <asp:HiddenField ID="HidCommand" runat="server" />
        <asp:Button ID="BtCommand" runat="server" Text="多功能按钮" CssClass="hide"  />
        <uc1:head ID="head2" runat="server" />
        <table width="100%" height="500" border="0" cellpadding="0" cellspacing="0">
            <tr>
                <td width="212" align="center" valign="top" background="images/leftdi.jpg">
                    <uc2:left ID="left2" runat="server" />
                </td>
                <td width="1" align="center" valign="top" bgcolor="#FFFFFF">
                </td>
                <td width="5" bgcolor="#5F87BC">
                </td>
                <td valign="top" align="center">
                    <table width="100%" border="0" cellspacing="0" cellpadding="0">
                        <tr>
                            <td height="1" bgcolor="#FFFFFF">
                            </td>
                        </tr>
                    </table>
                    <table width="100%" border="0" cellspacing="0" cellpadding="0">
                        <tr>
                            <td height="31" background="../images/middle_di_01.jpg">
                                <table width="93%" border="0" align="center" cellpadding="0" cellspacing="1">
                                    <tr>
                                        <td align="left" class="mo_title_l4">
                                            <table width="500" border="0" cellspacing="1" cellpadding="0">
                                                <tr>
                                                    <td width="21">
                                                        <span class="mo_title_l21">
                                                            <img src="../images/tubiao100.gif" width="15" height="15" /></span>
                                                    </td>
                                                    <td width="176">
                                                        <span class="mo_title_l31">文章评论</span>
                                                    </td>
                                                </tr>
                                            </table>
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                    </table>
                    <table width="100%" border="0" cellspacing="0" cellpadding="0">
                        <tr>
                            <td height="1" bgcolor="#CCCCCC">
                            </td>
                        </tr>
                    </table>
                    <table width="93%" border="0" align="center" cellpadding="0" cellspacing="0">
                        <tr>
                            <td height="5">
                            </td>
                        </tr>
                    </table>
                    <table width="93%" border="0" align="center" cellpadding="0" cellspacing="0" style="font-size: 12px;">
                        <tr>
                            <td align="left">
                                &nbsp;
                            </td>
                            <td align="right" height="40">
                                <asp:Button ID="BtdelSelect" runat="server" Text="删除" CssClass="btn-btn01"
                                     OnClientClick="return deltj();" />
                                <asp:Button ID="BtFavorites" runat="server" Text="收藏" CssClass="btn-btn01" OnClientClick="FavoritesFormList('tabRetList');return false;" />
                                <asp:Button ID="BtClippingSend" runat="server" Text="剪报推送" CssClass="btn-btn01" OnClientClick="ClippingSendFormList('tabRetList');return false;"/>
                                <asp:Button ID="BtMyOpus" runat="server" Text="放入作品" CssClass="btn-btn01" OnClientClick="addOpusNewsInfoFormList('tabRetList');return false;"/>
                                &nbsp;
                            </td>
                        </tr>
                    </table>
                    <table width="93%" id="tabRetList" border="0" align="center" cellpadding="0" cellspacing="1" bgcolor="#E4E4E4">
                        <tbody><tr class="trTop">
                            <td>
                                选择
                            </td>
                            <td>
                                评论人
                            </td>
                            <td>
                                标题
                            </td>
                            
                            <td>
                                评论内容
                            </td>
                        </tr>
                                <tr class="trData">
                                    <td style="background-color: #ffffe6;" align="center">
                                        <input name="rptRetList$ctl01$ckbox" type="checkbox" id="rptRetList_ctl01_ckbox" value="2016011126481000085" newscinfoid="15">
                                        <input type="hidden" name="rptRetList$ctl01$HidnewscInfoID" id="rptRetList_ctl01_HidnewscInfoID" value="15">
                                        <input type="hidden" name="rptRetList$ctl01$HidKID" id="rptRetList_ctl01_HidKID" value="2016011126481000085">
                                        <input type="hidden" name="rptRetList$ctl01$HidPD" id="rptRetList_ctl01_HidPD" value="b07111c.pdf">
                                        <input type="hidden" name="rptRetList$ctl01$HidJP" id="rptRetList_ctl01_HidJP" value="b07111cb.jpg">
                                        <input type="hidden" name="rptRetList$ctl01$HidpaperID" id="rptRetList_ctl01_HidpaperID" value="2648">
                                    </td>
                                    <td align="center">
                                        <span id="rptRetList_ctl01_LbuserName">系统管理员</span>
                                    </td>
                                    <td align="left" style="padding-left: 8px;">
                                        <a id="rptRetList_ctl01_HLinkBT" href="../Paper/ArticlePage.aspx?KID=2016011126481000085" target="_blank">    浙江鼓励教师医生“跳槽”</a>
                                    </td>
                                   
                                    <td align="center">
                                        <span id="rptRetList_ctl01_LBBC">内容挺好的，很新颖</span>
                                    </td>
                                </tr>
                            
                                <tr class="trData">
                                    <td style="background-color: #ffffe6;" align="center">
                                        <input name="rptRetList$ctl02$ckbox" type="checkbox" id="rptRetList_ctl02_ckbox" value="2016030226481000024" newscinfoid="14">
                                        <input type="hidden" name="rptRetList$ctl02$HidnewscInfoID" id="rptRetList_ctl02_HidnewscInfoID" value="14">
                                        <input type="hidden" name="rptRetList$ctl02$HidKID" id="rptRetList_ctl02_HidKID" value="2016030226481000024">
                                        <input type="hidden" name="rptRetList$ctl02$HidPD" id="rptRetList_ctl02_HidPD" value="b13302c.pdf">
                                        <input type="hidden" name="rptRetList$ctl02$HidJP" id="rptRetList_ctl02_HidJP" value="b13302cb.jpg">
                                        <input type="hidden" name="rptRetList$ctl02$HidpaperID" id="rptRetList_ctl02_HidpaperID" value="2648">
                                    </td>
                                    <td align="center">
                                        <span id="rptRetList_ctl02_LbuserName">系统管理员</span>
                                    </td>
                                    <td align="left" style="padding-left: 8px;">
                                        <a id="rptRetList_ctl02_HLinkBT" href="../Paper/ArticlePage.aspx?KID=2016030226481000024" target="_blank">    新王“登基”
倒计时</a>
                                    </td>
                                    
                                    <td align="center">
                                        <span id="rptRetList_ctl02_LBBC">内容很详细，图文并茂</span>
                                    </td>
                                </tr>
                            
                                <tr class="trData">
                                    <td style="background-color: #ffffe6;" align="center">
                                        <input name="rptRetList$ctl03$ckbox" type="checkbox" id="rptRetList_ctl03_ckbox" value="2016030226481000070" newscinfoid="13">
                                        <input type="hidden" name="rptRetList$ctl03$HidnewscInfoID" id="rptRetList_ctl03_HidnewscInfoID" value="13">
                                        <input type="hidden" name="rptRetList$ctl03$HidKID" id="rptRetList_ctl03_HidKID" value="2016030226481000070">
                                        <input type="hidden" name="rptRetList$ctl03$HidPD" id="rptRetList_ctl03_HidPD" value="b03302c.pdf">
                                        <input type="hidden" name="rptRetList$ctl03$HidJP" id="rptRetList_ctl03_HidJP" value="b03302cb.jpg">
                                        <input type="hidden" name="rptRetList$ctl03$HidpaperID" id="rptRetList_ctl03_HidpaperID" value="2648">
                                    </td>
                                    <td align="center">
                                        <span id="rptRetList_ctl03_LbuserName">系统管理员</span>
                                    </td>
                                    <td align="left" style="padding-left: 8px;">
                                        <a id="rptRetList_ctl03_HLinkBT" href="../Paper/ArticlePage.aspx?KID=2016030226481000070" target="_blank">    90后帅哥演绎“梦想合伙人”</a>
                                    </td>
                                    <td align="center">
                                        <span id="rptRetList_ctl03_LBBC">反映了广大用户的心声</span>
                                    </td>
                                </tr>
                            
                                <tr class="trData">
                                    <td style="background-color: #ffffe6;" align="center">
                                        <input name="rptRetList$ctl04$ckbox" type="checkbox" id="rptRetList_ctl04_ckbox" value="2016030426481000027" newscinfoid="12">
                                        <input type="hidden" name="rptRetList$ctl04$HidnewscInfoID" id="rptRetList_ctl04_HidnewscInfoID" value="12">
                                        <input type="hidden" name="rptRetList$ctl04$HidKID" id="rptRetList_ctl04_HidKID" value="2016030426481000027">
                                        <input type="hidden" name="rptRetList$ctl04$HidPD" id="rptRetList_ctl04_HidPD" value="c01304c.pdf">
                                        <input type="hidden" name="rptRetList$ctl04$HidJP" id="rptRetList_ctl04_HidJP" value="c01304cb.jpg">
                                        <input type="hidden" name="rptRetList$ctl04$HidpaperID" id="rptRetList_ctl04_HidpaperID" value="2648">
                                    </td>
                                    <td align="center">
                                        <span id="rptRetList_ctl04_LbuserName">系统管理员</span>
                                    </td>
                                    <td align="left" style="padding-left: 8px;">
                                        <a id="rptRetList_ctl04_HLinkBT" href="../Paper/ArticlePage.aspx?KID=2016030426481000027" target="_blank">    少了亲子秀，三月还有哪些综艺？</a>
                                    </td>
                                   
                                    <td align="center">
                                        <span id="rptRetList_ctl04_LBBC">找了很久的文章，赞一下</span>
                                    </td>
                                </tr>
                            
                                <tr class="trData">
                                    <td style="background-color: #ffffe6;" align="center">
                                        <input name="rptRetList$ctl05$ckbox" type="checkbox" id="rptRetList_ctl05_ckbox" value="2016030426481000028" newscinfoid="11">
                                        <input type="hidden" name="rptRetList$ctl05$HidnewscInfoID" id="rptRetList_ctl05_HidnewscInfoID" value="11">
                                        <input type="hidden" name="rptRetList$ctl05$HidKID" id="rptRetList_ctl05_HidKID" value="2016030426481000028">
                                        <input type="hidden" name="rptRetList$ctl05$HidPD" id="rptRetList_ctl05_HidPD" value="c02304c.pdf">
                                        <input type="hidden" name="rptRetList$ctl05$HidJP" id="rptRetList_ctl05_HidJP" value="c02304cb.jpg">
                                        <input type="hidden" name="rptRetList$ctl05$HidpaperID" id="rptRetList_ctl05_HidpaperID" value="2648">
                                    </td>
                                    <td align="center">
                                        <span id="rptRetList_ctl05_LbuserName">系统管理员</span>
                                    </td>
                                    <td align="left" style="padding-left: 8px;">
                                        <a id="rptRetList_ctl05_HLinkBT" href="../Paper/ArticlePage.aspx?KID=2016030426481000028" target="_blank">    傅艺伟涉毒，曾是“最美妲己”</a>
                                    </td>
                                    <td align="center">
                                        <span id="rptRetList_ctl05_LBBC">呵呵</span>
                                    </td>
                                </tr>
                            
                                <tr class="trData">
                                    <td style="background-color: #ffffe6;" align="center">
                                        <input name="rptRetList$ctl06$ckbox" type="checkbox" id="rptRetList_ctl06_ckbox" value="2014110610031000173" newscinfoid="10">
                                        <input type="hidden" name="rptRetList$ctl06$HidnewscInfoID" id="rptRetList_ctl06_HidnewscInfoID" value="10">
                                        <input type="hidden" name="rptRetList$ctl06$HidKID" id="rptRetList_ctl06_HidKID" value="2014110610031000173">
                                        <input type="hidden" name="rptRetList$ctl06$HidPD" id="rptRetList_ctl06_HidPD">
                                        <input type="hidden" name="rptRetList$ctl06$HidJP" id="rptRetList_ctl06_HidJP" value="LA10.JPG">
                                        <input type="hidden" name="rptRetList$ctl06$HidpaperID" id="rptRetList_ctl06_HidpaperID" value="1003">
                                    </td>
                                    <td align="center">
                                        <span id="rptRetList_ctl06_LbuserName">系统管理员</span>
                                    </td>
                                    <td align="left" style="padding-left: 8px;">
                                        <a id="rptRetList_ctl06_HLinkBT" href="../Paper/ArticlePage.aspx?KID=2014110610031000173" target="_blank">    四万多人是如何混进低保队伍的</a>
                                    </td>
                                
                                    <td align="center">
                                        <span id="rptRetList_ctl06_LBBC">编辑写的很好</span>
                                    </td>
                                </tr>
                            
                                <tr class="trData">
                                    <td style="background-color: #ffffe6;" align="center">
                                        <input name="rptRetList$ctl07$ckbox" type="checkbox" id="rptRetList_ctl07_ckbox" value="2014110610031000175" newscinfoid="9">
                                        <input type="hidden" name="rptRetList$ctl07$HidnewscInfoID" id="rptRetList_ctl07_HidnewscInfoID" value="9">
                                        <input type="hidden" name="rptRetList$ctl07$HidKID" id="rptRetList_ctl07_HidKID" value="2014110610031000175">
                                        <input type="hidden" name="rptRetList$ctl07$HidPD" id="rptRetList_ctl07_HidPD">
                                        <input type="hidden" name="rptRetList$ctl07$HidJP" id="rptRetList_ctl07_HidJP" value="LA11.JPG">
                                        <input type="hidden" name="rptRetList$ctl07$HidpaperID" id="rptRetList_ctl07_HidpaperID" value="1003">
                                    </td>
                                    <td align="center">
                                        <span id="rptRetList_ctl07_LbuserName">系统管理员</span>
                                    </td>
                                    <td align="left" style="padding-left: 8px;">
                                        <a id="rptRetList_ctl07_HLinkBT" href="../Paper/ArticlePage.aspx?KID=2014110610031000175" target="_blank">    繁荣文化凝聚人心引领发展</a>
                                    </td>
                                    <td align="center">
                                        <span id="rptRetList_ctl07_LBBC">内容很详实，好文章</span>
                                    </td>
                                </tr>
                            
                                <tr class="trData">
                                    <td style="background-color: #ffffe6;" align="center">
                                        <input name="rptRetList$ctl08$ckbox" type="checkbox" id="rptRetList_ctl08_ckbox" value="2015120211111000839" newscinfoid="8">
                                        <input type="hidden" name="rptRetList$ctl08$HidnewscInfoID" id="rptRetList_ctl08_HidnewscInfoID" value="8">
                                        <input type="hidden" name="rptRetList$ctl08$HidKID" id="rptRetList_ctl08_HidKID" value="2015120211111000839">
                                        <input type="hidden" name="rptRetList$ctl08$HidPD" id="rptRetList_ctl08_HidPD" value="hnrb20151202020.pdf">
                                        <input type="hidden" name="rptRetList$ctl08$HidJP" id="rptRetList_ctl08_HidJP" value="hnrb20151202020_b.jpg">
                                        <input type="hidden" name="rptRetList$ctl08$HidpaperID" id="rptRetList_ctl08_HidpaperID" value="1111">
                                    </td>
                                    <td align="center">
                                        <span id="rptRetList_ctl08_LbuserName">系统管理员</span>
                                    </td>
                                    <td align="left" style="padding-left: 8px;">
                                        <a id="rptRetList_ctl08_HLinkBT" href="../Paper/ArticlePage.aspx?KID=2015120211111000839" target="_blank">    椰壳餐具 伴你吃顿环保特色的海南饭</a>
                                    </td>
                                   
                                    <td align="center">
                                        <span id="rptRetList_ctl08_LBBC">终于找到这篇文章了，很好</span>
                                    </td>
                                </tr>
                            
                                <tr class="trData">
                                    <td style="background-color: #ffffe6;" align="center">
                                        <input name="rptRetList$ctl09$ckbox" type="checkbox" id="rptRetList_ctl09_ckbox" value="2013100121831000038" newscinfoid="7">
                                        <input type="hidden" name="rptRetList$ctl09$HidnewscInfoID" id="rptRetList_ctl09_HidnewscInfoID" value="7">
                                        <input type="hidden" name="rptRetList$ctl09$HidKID" id="rptRetList_ctl09_HidKID" value="2013100121831000038">
                                        <input type="hidden" name="rptRetList$ctl09$HidPD" id="rptRetList_ctl09_HidPD" value="ynrb_2013-10-1_04.pdf">
                                        <input type="hidden" name="rptRetList$ctl09$HidJP" id="rptRetList_ctl09_HidJP" value="ynrb_2013-10-1_04_b.jpg">
                                        <input type="hidden" name="rptRetList$ctl09$HidpaperID" id="rptRetList_ctl09_HidpaperID" value="2183">
                                    </td>
                                    <td align="center">
                                        <span id="rptRetList_ctl09_LbuserName">系统管理员</span>
                                    </td>
                                    <td align="left" style="padding-left: 8px;">
                                        <a id="rptRetList_ctl09_HLinkBT" href="../Paper/ArticlePage.aspx?KID=2013100121831000038" target="_blank">报脚</a>
                                    </td>
                                    
                                    <td align="center">
                                        <span id="rptRetList_ctl09_LBBC">图片很漂亮</span>
                                    </td>
                                </tr>
                            
                                <tr class="trData">
                                    <td style="background-color: #ffffe6;" align="center">
                                        <input name="rptRetList$ctl10$ckbox" type="checkbox" id="rptRetList_ctl10_ckbox" value="2013100121831000030" newscinfoid="6">
                                        <input type="hidden" name="rptRetList$ctl10$HidnewscInfoID" id="rptRetList_ctl10_HidnewscInfoID" value="6">
                                        <input type="hidden" name="rptRetList$ctl10$HidKID" id="rptRetList_ctl10_HidKID" value="2013100121831000030">
                                        <input type="hidden" name="rptRetList$ctl10$HidPD" id="rptRetList_ctl10_HidPD" value="ynrb_2013-10-1_03.pdf">
                                        <input type="hidden" name="rptRetList$ctl10$HidJP" id="rptRetList_ctl10_HidJP" value="ynrb_2013-10-1_03_b.jpg">
                                        <input type="hidden" name="rptRetList$ctl10$HidpaperID" id="rptRetList_ctl10_HidpaperID" value="2183">
                                    </td>
                                    <td align="center">
                                        <span id="rptRetList_ctl10_LbuserName">系统管理员</span>
                                    </td>
                                    <td align="left" style="padding-left: 8px;">
                                        <a id="rptRetList_ctl10_HLinkBT" href="../Paper/ArticlePage.aspx?KID=2013100121831000030" target="_blank">肯尼亚已拘捕9名 恐怖袭击嫌疑人</a>
                                    </td>
                                  
                                    <td align="center">
                                        <span id="rptRetList_ctl10_LBBC">文章内容很易懂，推荐下。</span>
                                    </td>
                                </tr>
                            
                                <tr class="trData">
                                    <td style="background-color: #ffffe6;" align="center">
                                        <input name="rptRetList$ctl11$ckbox" type="checkbox" id="rptRetList_ctl11_ckbox" value="2013100121831000031" newscinfoid="5">
                                        <input type="hidden" name="rptRetList$ctl11$HidnewscInfoID" id="rptRetList_ctl11_HidnewscInfoID" value="5">
                                        <input type="hidden" name="rptRetList$ctl11$HidKID" id="rptRetList_ctl11_HidKID" value="2013100121831000031">
                                        <input type="hidden" name="rptRetList$ctl11$HidPD" id="rptRetList_ctl11_HidPD" value="ynrb_2013-10-1_03.pdf">
                                        <input type="hidden" name="rptRetList$ctl11$HidJP" id="rptRetList_ctl11_HidJP" value="ynrb_2013-10-1_03_b.jpg">
                                        <input type="hidden" name="rptRetList$ctl11$HidpaperID" id="rptRetList_ctl11_HidpaperID" value="2183">
                                    </td>
                                    <td align="center">
                                        <span id="rptRetList_ctl11_LbuserName">系统管理员</span>
                                    </td>
                                    <td align="left" style="padding-left: 8px;">
                                        <a id="rptRetList_ctl11_HLinkBT" href="../Paper/ArticlePage.aspx?KID=2013100121831000031" target="_blank">尼日利亚东北部
一大学遭袭击</a>
                                    </td>
                                   
                                    <td align="center">
                                        <span id="rptRetList_ctl11_LBBC">恐怖主义害死人啊。</span>
                                    </td>
                                </tr>
                            
                                <tr class="trData">
                                    <td style="background-color: #ffffe6;" align="center">
                                        <input name="rptRetList$ctl12$ckbox" type="checkbox" id="rptRetList_ctl12_ckbox" value="2013100121831000032" newscinfoid="4">
                                        <input type="hidden" name="rptRetList$ctl12$HidnewscInfoID" id="rptRetList_ctl12_HidnewscInfoID" value="4">
                                        <input type="hidden" name="rptRetList$ctl12$HidKID" id="rptRetList_ctl12_HidKID" value="2013100121831000032">
                                        <input type="hidden" name="rptRetList$ctl12$HidPD" id="rptRetList_ctl12_HidPD" value="ynrb_2013-10-1_03.pdf">
                                        <input type="hidden" name="rptRetList$ctl12$HidJP" id="rptRetList_ctl12_HidJP" value="ynrb_2013-10-1_03_b.jpg">
                                        <input type="hidden" name="rptRetList$ctl12$HidpaperID" id="rptRetList_ctl12_HidpaperID" value="2183">
                                    </td>
                                    <td align="center">
                                        <span id="rptRetList_ctl12_LbuserName">系统管理员</span>
                                    </td>
                                    <td align="left" style="padding-left: 8px;">
                                        <a id="rptRetList_ctl12_HLinkBT" href="../Paper/ArticlePage.aspx?KID=2013100121831000032" target="_blank">中方对此感到震惊</a>
                                    </td>
                                    
                                    <td align="center">
                                        <span id="rptRetList_ctl12_LBBC">文章内容很易懂，推荐下。</span>
                                    </td>
                                </tr>
                            
                                <tr class="trData">
                                    <td style="background-color: #ffffe6;" align="center">
                                        <input name="rptRetList$ctl13$ckbox" type="checkbox" id="rptRetList_ctl13_ckbox" value="2013100121831000033" newscinfoid="3">
                                        <input type="hidden" name="rptRetList$ctl13$HidnewscInfoID" id="rptRetList_ctl13_HidnewscInfoID" value="3">
                                        <input type="hidden" name="rptRetList$ctl13$HidKID" id="rptRetList_ctl13_HidKID" value="2013100121831000033">
                                        <input type="hidden" name="rptRetList$ctl13$HidPD" id="rptRetList_ctl13_HidPD" value="ynrb_2013-10-1_03.pdf">
                                        <input type="hidden" name="rptRetList$ctl13$HidJP" id="rptRetList_ctl13_HidJP" value="ynrb_2013-10-1_03_b.jpg">
                                        <input type="hidden" name="rptRetList$ctl13$HidpaperID" id="rptRetList_ctl13_HidpaperID" value="2183">
                                    </td>
                                    <td align="center">
                                        <span id="rptRetList_ctl13_LbuserName">系统管理员</span>
                                    </td>
                                    <td align="left" style="padding-left: 8px;">
                                        <a id="rptRetList_ctl13_HLinkBT" href="../Paper/ArticlePage.aspx?KID=2013100121831000033" target="_blank">云南省用能和排污计量监督管理办法</a>
                                    </td>
                                 
                                    <td align="center">
                                        <span id="rptRetList_ctl13_LBBC">文章内容很易懂，推荐下。</span>
                                    </td>
                                </tr>
        
                            
                    </tbody></table>
                    <table width="93%" border="0" cellspacing="0" cellpadding="0">
                        <tr>
                            <td align="left" height="40" style="font-size: 12px;">
                                &nbsp;<a href="javascript:QX('tabRetList');">全选</a>&nbsp;<a href="javascript:FX('tabRetList');">反选</a>
                            </td>
                            <td align="right" height="40">
                                <cc1:pageControl ID="pageControl1" runat="server" pageSize="20"  />
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
        </table>
        <uc3:footer ID="footer2" runat="server" />
    </div>
    </form>
</body>
</html>
