using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;

namespace ArchiveStation
{
    public class Reader
    {
        [DllImport("RFIDRD201H.dll", CallingConvention = CallingConvention.Cdecl)]
        public   static extern int RD_OpenDevice(string port);

        [DllImport("RFIDRD201H.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern int RD_CloseUSB( IntPtr hdl );

        [DllImport("RFIDRD201H.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr RD_OpenDevice();

        [DllImport("RFIDRD201H.dll", CallingConvention = CallingConvention.Cdecl)]
        public  static extern int RD_GetSerialNum(StringBuilder port, ref Int32 num);

        [DllImport("RFIDRD201H.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern int RD_GetSysInfo(IntPtr hComm, int nIndex,  StringBuilder param);

        [DllImport("RFIDRD201H.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern int RD_InventoryTagPsSingle(IntPtr hComm, int nIndex, StringBuilder pUid);




        public System.Timers.Timer timer;
        public IntPtr deviceId = IntPtr.Zero;
        public delegate void CallBack(string uid);
        public event CallBack GetUIDCallBack=null; 

        public Reader()
        {
            timer = new System.Timers.Timer(200);
            timer.Elapsed += timer_Elapsed;
            timer.Enabled = false;
           
        }

        public void Start()
        {
            timer.Start();

            OpenDevice();
        }
        public void Stop()
        {
            timer .Stop();

            CloseDevice();
        }

        protected void CloseDevice()
        {
            if (deviceId == IntPtr.Zero) return;
            int result = Reader.RD_CloseUSB(deviceId);
            if (result == 0)
            {
                //MessageBox.Show("关闭ok");
            }
            else
            {
                //MessageBox.Show("关闭failed");
            }
        }

        protected void OpenDevice()
        {
            try
            {
                if (deviceId != IntPtr.Zero) return;


                deviceId = Reader.RD_OpenDevice();
                if (deviceId != IntPtr.Zero)
                {
                    //MessageBox.Show("打开设备成功");
                }
                else
                {
                    //MessageBox.Show("打开设备失败");
                }
            }
            catch (Exception ex)
            {
                //MessageBox.Show(ex.Message);
            }
        }

        protected int  Inventory(ref string  uid )
        {
            try
            {
                StringBuilder puid = new StringBuilder(255);
                int result = Reader.RD_InventoryTagPsSingle(deviceId, 1, puid);
                if (result == 0)
                {
                    uid = puid.ToString();
                    return result;
                    //MessageBox.Show(puid.ToString());
                }
                else
                {
                    return result;
                    //MessageBox.Show("error code " + result);
                }
            }
            catch (Exception ex)
            {
                //MessageBox.Show(ex.Message);

                return 9999;
            }         
        }

        void timer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            string uid ="";
            int result = 0;
            result = Inventory( ref uid);


            if (GetUIDCallBack != null)
            {
                GetUIDCallBack.BeginInvoke(uid, null, null);
            }
        }

    }
}
