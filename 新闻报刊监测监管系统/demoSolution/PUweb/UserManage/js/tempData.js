
//添加临时交换数据，以指定的DataKey来存储
function SetExchangeData(DataValue, DataKey) {
    var senddate = "";
    senddate = "DataValue=" + escape(DataValue) + "&DataKey=" + escape(DataKey) + "&whatDo=" + escape("SetExchangeData");
    var result = PostData(senddate, "../dataService/tempData.aspx");
    if (result != "T") alert("存储数据出错！" + result);
    return result;
}
//添加临时交换数据，返回DataKey
function SetExchangeData_RetrunDataKey(DataValue) {
    var senddate = "";
    senddate = "DataValue=" + escape(DataValue) + "&whatDo=" + escape("SetExchangeData_RetrunDataKey");
    var result = PostData(senddate, "../dataService/tempData.aspx");
    return result;
}

//存获取临时交换数据， 返回“#null#”说明没有找到该 数据键 的数据
function getExchangeData(DataKey) {
    var senddate = "";
    senddate = "DataKey=" + escape(DataKey) + "&whatDo=" + escape("getExchangeData");
    var result = PostData(senddate, "../dataService/tempData.aspx");
    return result;
}

