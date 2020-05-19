
/*用于处理Post数据的页面地址。*/
var dataPostPageUrl = "../Command/dataPost.aspx";



/************************************************************************************************
添加报纸收藏
paperID：报纸ID
************************************************************************************************/
function addPaperCollection(paperID) {
    var senddate = "";
    senddate = "paperID=" + escape(paperID) + "&whatDo=" + escape("addPaperCollection");
    var result = PostData(senddate, dataPostPageUrl);
    alert(result);
}

/************************************************************************************************
删除报纸收藏
paperID：报纸ID
************************************************************************************************/
function delPaperCollection(paperID) {
    var senddate = "";
    senddate = "paperID=" + escape(paperID) + "&whatDo=" + escape("delPaperCollection");
    var result = PostData(senddate, dataPostPageUrl);
    $("#paper" + paperID).html("");
    alert(result);
}


/************************************************************************************************
添加版面收藏信息
paperID：报纸ID
MC：报纸名
RQ：日期(20110513)
BC：版次
BM：版面
PD：PDF文件名
JP：JPG文件名
************************************************************************************************/
function addEditionCollection(paperID, MC, RQ, BC, BM, PD, JP) {
    var senddate = "";
    senddate = "paperID=" + escape(paperID) + "&MC=" + escape(MC) + "&RQ=" + escape(RQ) + "&BC=" + escape(BC) + "&BM=" + escape(BM) + "&PD=" + escape(PD) + "&JP=" + escape(JP) + "&whatDo=" + escape("addEditionCollection");
    var result = PostData(senddate, dataPostPageUrl);
    alert(result);
}

/************************************************************************************************
删版面收藏信息
editionCollectionInfoID：版面收藏信息ID
************************************************************************************************/
function delEditionCollection(editionCollectionInfoID) {
    var senddate = "";
    senddate = "editionCollectionInfoID=" + escape(editionCollectionInfoID) + "&whatDo=" + escape("delEditionCollection");
    var result = PostData(senddate, dataPostPageUrl);
    $("#edition" + editionCollectionInfoID).html("");
    alert(result);
}


/*************************************************************************************************
收藏(从列表中选)
listID：列表ID
************************************************************************************************/
function FavoritesFormList(listID) {
    var KIDStr = getSelectValues(listID);
    if (KIDStr == "") {
        alert("请至少选择一篇要收藏的报道！");
        return;
    }
    addNewsCollection(KIDStr);
}


/*************************************************************************************************
推荐(从列表中选)
listID：列表ID
************************************************************************************************/
function RecommendFormList(listID) {
    var KIDStr = getSelectValues(listID); 
    if (KIDStr == "") {
        alert("请至少选择一篇要推荐的报道！");
        return;
    }
    addNewsRecommend(KIDStr);
}



/*************************************************************************************************
剪报推送(从列表中选)
listID：列表ID
************************************************************************************************/
function ClippingSendFormList(listID) {
    var KIDStr = getSelectValues(listID);
    if (KIDStr == "") {
        alert("请至少选择一篇要推送的报道！");
        return;
    }
    addClippingNewes(KIDStr);
}


/*************************************************************************************************
添加我的作品(从列表中选)
listID：列表ID
************************************************************************************************/
function addOpusNewsInfoFormList(listID) {
    var KIDStr = getSelectValues(listID);
    if (KIDStr == "") {
        alert("请至少选择一篇要放入作品中的报道！");
        return;
    }
    addOpusNewsInfo(KIDStr);
}






/************************************************************************************************
收藏报道(多篇)
KIDStr：文章KID，多篇以“,”隔开
************************************************************************************************/
function addNewsCollection(KIDStr) {
    var newsCollectionTypeID = 2; //报道收藏类别ID
    if (KIDStr == "") {
        alert("请选择要收藏的报道！");
        return;
    }

    newsCollectionTypeID = SelectNewsCollectionType();  
    if (newsCollectionTypeID == "" || newsCollectionTypeID == "0") {
        //alert("请选择要收藏到的类别！");
        return;
    }
    var senddate = "";
    senddate = "KIDStr=" + escape(KIDStr) + "&newsCollectionTypeID=" + escape(newsCollectionTypeID) + "&whatDo=" + escape("addNewsCollection");
    //alert(senddate);
    var ret = PostData(senddate, dataPostPageUrl);
    alertMsg(ret, KIDStr, "收藏", "收藏");
}

/************************************************************************************************
添加报道推荐信息(多篇多人)
KIDStr：文章KID，多篇以“,”隔开
************************************************************************************************/
function addNewsRecommend(KIDStr) {
    var objectUserGUIDs = ""; //要推荐的人员GUID串
    if (KIDStr == "") {
        alert("请选择要推荐的报道！");
        return;
    }

    objectUserGUIDs = selectUserMoreRetUserGUID();
    if (objectUserGUIDs == "") {
        //alert("请选择要推荐的人员！");
        return;
    }
    //alert(objectUserGUIDs);
    var senddate = "";
    senddate = "KIDStr=" + escape(KIDStr) + "&objectUserGUIDs=" + escape(objectUserGUIDs) + "&whatDo=" + escape("addNewsRecommend");
    //alert(senddate);
    var ret = PostData(senddate, dataPostPageUrl);
    alertMsg(ret, KIDStr, "推荐", "推荐");
}


/************************************************************************************************
添加剪报报道信息(多篇)
KIDStr：文章KID，多篇以“,”隔开
************************************************************************************************/
function addClippingNewes(KIDStr) {
    var pressClippingBasisInfoID = 1; //剪报基本信息ID
    if (KIDStr == "") {
        alert("请选择要推送的报道！");
        return;
    }

    pressClippingBasisInfoID = SelectPressClippingNews();
    if (pressClippingBasisInfoID == "" || pressClippingBasisInfoID == "0") {
        //alert("请选择要收藏到的类别！");
        return;
    }
    var senddate = "";
    senddate = "KIDStr=" + escape(KIDStr) + "&pressClippingBasisInfoID=" + escape(pressClippingBasisInfoID) + "&whatDo=" + escape("addClippingNewes");
    //alert(senddate);
    var ret = PostData(senddate, dataPostPageUrl);
    alertMsg(ret, KIDStr, "剪报推送", "剪报");
}

/************************************************************************************************
添加我的作品(多篇)
KIDStr：文章KID，多篇以“,”隔开
************************************************************************************************/
function addOpusNewsInfo(KIDStr) {
    if (KIDStr == "") {
        alert("请选择要放入作品的报道！");
        return;
    }

    var senddate = "";
    senddate = "KIDStr=" + escape(KIDStr) + "&whatDo=" + escape("addOpusNewsInfo");

    var ret = PostData(senddate, dataPostPageUrl);
    alertMsg(ret, KIDStr, "放入您的作品", "作品");
}
/*信息提示*/
function alertMsg(ret, KIDStr, opName, msgName) {
    var total = KIDStr.split(",").length;
    var oksl = parseInt(ret.split(",")[0]);
    var delsl = parseInt(ret.split(",")[1]);
    var havesl = total - oksl - delsl;
    var errsl = total - oksl;
    var msg = "";

    if (oksl != 0) msg = oksl + " 篇报道" + opName + "成功！";
    if (errsl != 0) msg += errsl + " 篇失败！原因：";
    if (havesl != 0) msg += havesl + " 篇报道已在您的" + msgName + "中！";
    if (delsl != 0) msg += delsl + " 篇报道已被删除！";

    if (oksl == 0 && total == 1) {
        if (delsl != 0) msg = "所选的报道已被删除！";
        if (havesl != 0) msg = "所选的报道已在您的" + msgName + "中！";
    }
    if (oksl == -1 && delsl == -1) msg = "对不起，您还未开通此权限！";
    alert(msg);
}




/************************************************************************************************
收藏类别选择
************************************************************************************************/
function SelectNewsCollectionType() {
    var ran = Math.random();
    var wz = "dialogWidth:370px; dialogHeight:300px; status:0;center:yes";
    var url = "../MyInformation/newsCollectionTypeSelect.aspx?ran=" + ran;
    var ret = showModalDialog(url, "Dialog", wz);
    if (ret == null) ret = "";
    return ret;
}


/************************************************************************************************
剪报选择
************************************************************************************************/
function SelectPressClippingNews() {
    var ran = Math.random();
    var wz = "dialogWidth:370px; dialogHeight:300px; status:0;center:yes";
    var url = "../pressClipping/pressClippingSelect.aspx?ran=" + ran;
    var ret = showModalDialog(url, "Dialog", wz);
    if (ret == null) ret = "";
    return ret;
}

/************************************************************************************************
人员选择(多选)
************************************************************************************************/
function selectUserMoreRetUserGUID() {
    var ret = "904e24de-e420-48fe-b89f-dbea78134b52";
    try {
        var retArr = selectUserOrDepMore("", ""); //调用用户管理中的client.js

        if (retArr != null) {
            ret = retArr["id"];
        }
        else {
            ret = "";
        }
    } catch (e) {
        alert(e);
    }
    return ret;
}