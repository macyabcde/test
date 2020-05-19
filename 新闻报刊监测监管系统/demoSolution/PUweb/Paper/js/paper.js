
var TTSPostSrc = "http://www.cnepaper.com:8080/VoiceControl/TTSPlay.action"; //要调用的TTSPalyer的地址


function playerPlay(url, text) {
    try {
        document.TTSPlayeriframe.document.form1.TTsText.value = text;
        document.TTSPlayeriframe.document.form1.playPageUrl.value = url;
        document.TTSPlayeriframe.document.form1.action = TTSPostSrc;
        document.TTSPlayeriframe.document.form1.submit();
    } catch (e) {
        alert("页面未加载完成，请稍后再用。" + e);
    }

}

function readTxt() {

    var txtobj = document.all("ozoom");
    if (typeof (txtobj) == "object") {
        var url = document.location.href;
        var txt = txtobj.innerText;
        playerPlay(url, txt);
    }
    else {
        alert("无法获取文章内容(can't find ozoom object)");
    }

}


/*检索
paperIDStr：要检索的报纸ID串，多个以“,”分隔
*/
function searchWord(paperIDStr) {
    var KeyWord = JQ("#txtKeyWord").val();  
    var KeyWordCondition = "and";
    var searchRetOrder = 201;  
    var startDate = "1900-01-01";
    var endDate = "2200-12-31";

    if (KeyWord == "") {

        alert("请输入关键词");
        return;
    }

    
    var DataValue = "";
    DataValue += "<paperIDStr>" + paperIDStr + "</paperIDStr>";
    DataValue += "<KeyWord>" + KeyWord + "</KeyWord>";
    DataValue += "<KeyWordCondition>" + KeyWordCondition + "</KeyWordCondition>";
    DataValue += "<searchRetOrder>" + searchRetOrder + "</searchRetOrder>";
    DataValue += "<startDate>" + startDate + "</startDate>";
    DataValue += "<endDate>" + endDate + "</endDate>";

    var Key = SetExchangeData(DataValue);

    document.location = "../Search/searchRetList.aspx?Key=" + Key;
}



/*
生成日历每一天
paperID：报纸ID
yearListID：年份下拉选择框ID
monthListID：月份下拉选择框ID
nowRQ：当前所浏览的报纸日期(20101125)
*/
function setCalendar(paperID, yearListID, monthListID, nowRQ) {
    var ret = "";
    var retArr = new Array();
    var year = JQ("#" + yearListID).val();
    var month = JQ("#" + monthListID).val();
    
    ret = GetData("calendarPage.aspx?paperID=" + paperID + "&year=" + year + "&month=" + month + "&RQ=" + nowRQ);
    
    retArr = ret.split("!");
    //alert(ret + " retArr.length=" + retArr.length);
    if (retArr.length != 42) {
        alert("获取日历出错！");
        return;
    }
   
    
    for (i = 0; i < 42; i++) {
        JQ("#date" + i).html(retArr[i]);
    }

}

/*
生成日历每一天
dateHtml： 日历天html(几号)
*/
function setCalendarForValue(dateHtml) {
    var retArr = new Array();
    retArr = dateHtml.split("!");
    //alert(ret + " retArr.length=" + retArr.length);
    if (retArr.length != 42) {
        alert("获取日历出错！");
        return;
    }

    for (i = 0; i < 42; i++) {
        JQ("#date" + i).html(retArr[i]);
    }

}

function turnpage(src, mode) {

    currPos = src.selectedIndex;

    if (mode == 0) {//前翻
        if (currPos == 0) return;
        else {
            src.selectedIndex = currPos - 1;
            src.onchange();
        }
    } else {
        if (currPos == src.length - 1)
            return;
        else {
            src.selectedIndex = currPos + 1;
            src.onchange();
        }
    }
}




//浮动窗口的变色条
function blur_row(row_id) {
    document.all("row" + row_id).className = "commoncolor";
}

function blur_row2(row_id) {
    document.all("row" + row_id).className = "commoncolor2";
}

function focus_row_black(row_id) {
    document.all("row_black" + row_id).className = "commonlight2";
}

function blur_row_black(row_id) {
    document.all("row_black" + row_id).className = "commoncolor3";
}

//--------------------------- 版面导航显示位置 --------------------------- 
function setbmdh() {
    var obj = document.getElementById("bmdh");
    obj.style.left = event.clientX - obj.offsetWidth + 10;
    obj.style.top = event.clientY - 2;
}
//--------------------------- 标题导航显示位置 --------------------------- 
function setbtdh() {
    var obj = document.getElementById("btdh");
    obj.style.left = event.clientX - obj.offsetWidth + 10;
    obj.style.top = event.clientY - 2;
}

function zoomIn() {
    newZoom = parseInt(ozoom.style.zoom) + 10 + '%'
    ozoom.style.zoom = newZoom;
}

function zoomOut() {
    newZoom = parseInt(ozoom.style.zoom) - 10 + '%'
    ozoom.style.zoom = newZoom;
}