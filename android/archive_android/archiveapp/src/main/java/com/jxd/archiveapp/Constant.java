package com.jxd.archiveapp;

/**
 * Created by Administrator on 2016/1/27.
 */
public class Constant {
    //public static String BASE_ROOT_URL="http://192.168.1.6/yzarchiveweb/";

    public static String LOGIN_URL= "Account/LoginRestfull";
    public static String QUERY_ARCHIVE_URL = "ArchiveRestfull/GetArchiveList";
    public static String QUERY_BOXLISTOFFLOOR_URL="LabelRestfull/GetBoxListOfFloor";
    public static String UPLOAD_BOX_URL="LabelRestfull/UploadBoxListOfFloor";
    public static String GETLABELINF_URL="LabelRestfull/GetLabelInfoByRFID";
    public static String GET_INVENTORY_LABELINFO_URL="LabelRestfull/GetInventoryLabelInfo";
    public static String UPLOAD_INVENTORY_URL ="LabelRestfull/UploadInventoryInfo";

    public static int REQUEST_SCUESS = 1;
    public static int REQUEST_FAILED = 0;
    public static int REQUEST_LOGIN = -1;

    public static String USER_INFO_FILE="user_info_file";
    public static String USER_USERID="user_id";
    public static String USER_NAME="user_name";
    public static String USER_PASSWORD="user_password";
    public static String USER_REALNAME="user_realname";
    public static String USER_SEX = "user_sex";
    public static String USER_PHONE ="user_phone";

    public static String LOCATION_INFO_FILE="location_info_file";
    public static String LOCATION_FLOORNAME="location_floorname";
    public static String LOCATION_FLOORRFID ="location_floorrfid";
    public static String LOCATION_BOXDATA = "location_boxdata";

    public static String INVENTORY_INFO_FILE="inventory_info_file";
    public static String INVENTORY_Floor = "inventory_floor";

    public static String SEARCH_INFO_FILE ="search_info_file";
    public static String SEARCH_KEY ="search_key";

    public static String URL_FILE="url_file";
    public static String URL_API ="url_api";

    public static int PAGESIZE=20;

    public static int RESULT_SUCCESS = 1;
    public static int RESULT_ERROR=0;

    public static String FRAGMENT_SEARCH="档案检索";
    public static String FRAGMENT_LOCATION="标签定位";
    public static String FRAGMENT_INVENTORY="档案盘定";
    public static String FRAGMENT_INVENTORYSCAN="盘点扫描";

    public static String LABEL_NORMAL="正常";
    public static String LABEL_DAMAGE="损坏";
    public static String LABEL_MISS="丢失";

}
