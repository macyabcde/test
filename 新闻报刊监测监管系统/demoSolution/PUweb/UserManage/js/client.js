

var webUrl = "/UserWeb"; //用户登录站点根地址


/******************************************************************************
多用户选择
IDtxtObjID：用来存放ID串的文本输入框ID；
NametxtObjID：：用来存放名称串的文本输入框ID；
返回的ID格式：UserGUID,UserGUID
返回的名称格式：DepartName,DepartName
******************************************************************************/
function selectUserMore(IDtxtObjID, NametxtObjID) {
    var IDtxtObj = document.getElementById(IDtxtObjID);
    var NametxtObj = document.getElementById(NametxtObjID);
    var arr = selectUserOrDepMore(IDtxtObj.value, NametxtObj.value);
    if (arr != null) {
        IDtxtObj.value = arr['id'];
        NametxtObj.value = arr['name'];
    }
    return false;
}

/******************************************************************************
单用户选择
IDtxtObjID：用来存放ID串的文本输入框ID；
NametxtObjID：：用来存放名称串的文本输入框ID；
返回的ID格式：UserGUID
返回的名称格式：DepartName
******************************************************************************/
function selectOneUser(IDtxtObjID, NametxtObjID) {
    var IDtxtObj = document.getElementById(IDtxtObjID);
    var NametxtObj = document.getElementById(NametxtObjID);

    var UserGUID = IDtxtObj.value;
    var UserName = NametxtObj.value;


    var wz = "dialogWidth:490px; dialogHeight:620px; status:0;center:yes";
    var url = webUrl + "/select/selectOneUser.aspx?UserGUID=" + UserGUID + "&UserName=" + UserName;
    var ret = showModalDialog(url, "Dialog", wz);

    if (ret == "" || ret == null) {
        IDtxtObj.value = "";
        NametxtObj.value = "";
        return false;
    }

    IDtxtObj.value = ret.split(";")[0];
    NametxtObj.value = ret.split(";")[1];
    return false;
}

/******************************************************************************
单部门选择
IDtxtObjID：用来存放ID串的文本输入框ID；
NametxtObjID：：用来存放名称串的文本输入框ID；
返回的ID格式：DepartID
返回的名称格式：DepartName
******************************************************************************/
function selectOneDepart(IDtxtObjID, NametxtObjID) {
    var IDtxtObj = document.getElementById(IDtxtObjID);
    var NametxtObj = document.getElementById(NametxtObjID);

    var DepartID = IDtxtObj.value;
    var DepartName = NametxtObj.value;

    var wz = "dialogWidth:275px; dialogHeight:620px; status:0;center:yes";
    var url = webUrl + "/select/selectDep.aspx?DepartID=" + DepartID;
    var ret = showModalDialog(url, "Dialog", wz);

    if (ret == "" || ret == null) {
        IDtxtObj.value = "";
        NametxtObj.value = "";
        return false;
    }

    IDtxtObj.value = ret.split(";")[0];
    NametxtObj.value = ret.split(";")[1];
    return false;
}

/*多用户及部门选择
inItIDStr：初始化已选列表的ID串。多个间以“,”隔开
inItNameStr：初始化已选列表的名称串。格式为：多个间以“,”隔开，如：谢炳集,陈法涌
*/
function selectUserOrDepMore(inItIDStr, inItNameStr) {
    var DataValue = "";
    if (inItIDStr != "") DataValue = inItIDStr + ";" + inItNameStr;
    var DataKey = SetExchangeData(DataValue);
    var wz = "dialogWidth:640px; dialogHeight:620px; status:0;center:yes";
    var url = webUrl + "/select/HZselectIndex.aspx?DataKey=" + DataKey;
    showModalDialog(url, "Dialog", wz);
    DataValue = getExchangeData(DataKey);
    var arr = new Array();
    if (DataValue != "#null#") {
        var DataValueArr = DataValue.split(";");
        arr["id"] = DataValueArr[0];
        if (DataValueArr.length >= 2)
            arr["name"] = DataValueArr[1];
        else
            arr["name"] = "";
    }
    else {
        arr = null;
    }
    return arr;
}

/******************************************************************************
修改用户个人信息
******************************************************************************/
function UserInfoEdit() {
    var ran = Math.random();
    var wz = "dialogWidth:825px; dialogHeight:450px; status:0;center:yes";
    var url = webUrl + "/UserInfoEdit.aspx?ran=" + ran;
    showModalDialog(url, "Dialog", wz);
}

/******************************************************************************
修改用户密码
******************************************************************************/
function UserPwdEdit() {
    var ran = Math.random();
    var wz = "dialogWidth:825px; dialogHeight:450px; status:0;center:yes";
    var url = webUrl + "/UserPwdEdit.aspx?ran=" + ran;
    showModalDialog(url, "Dialog", wz);
}

