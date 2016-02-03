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

    public static int REQUEST_SCUESS = 1;
    public static int REQUEST_FAILED = 0;

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

    public static String URL_FILE="url_file";
    public static String URL_API ="url_api";

    public static int PAGESIZE=20;
}
