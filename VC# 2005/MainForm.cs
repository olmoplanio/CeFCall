using System;
using System.Collections;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using System.Text;

namespace CeFDllDemo
{
    /*
    * This document contains programming examples.
    * 
    * Custom Engineering grants you a nonexclusive copyright license to use all programming code examples from which you can generate similar function tailored to your own specific needs.
    * 
    * All sample code is provided by Custom Engineering for illustrative purposes only. These examples have not been thoroughly tested under all conditions. 
    * Custom Engineering, therefore, cannot guarantee or imply reliability, serviceability, or function of these programs.
    * 
    * In no event shall Custom Engineering be liable for any direct, indirect, incidental, special, exemplary, or consequential damages (including, but not limited to, procurement of substitute goods or services; loss of use, data, or profits; or business interruption) however caused and on any theory of liability, whether in contract, strict liability, or tort 
    * (including negligence or otherwise) arising in any way out of the use of this software, even if advised of the possibility of such damage.
    * 
    * All programs contained herein are provided to you "as is" without any warranties of any kind.
    * The implied warranties of non-infringement, merchantability and fitness for a particular purpose are expressly disclaimed.
    *  
    */

    internal partial class MainForm : System.Windows.Forms.Form
	{
        private const byte bData = 7;
        private const byte bParity = 1;
        private const byte bFlow = 1;
        private const byte bStop = 0;
        private const uint bRate = 19200;

        private int bPort = 0;

        #region Call Methods
        private int OpenPort(int intCom, uint dwBaudRate, byte byParity, byte byDataBit, byte byStopBit, byte byFlowControl, ref int lpdwSysError)
        {
            int result = int.MinValue;
            try
            {
                result = IntercomModule.CEFOpen(intCom, dwBaudRate, byParity, byDataBit, byStopBit, byFlowControl, ref lpdwSysError);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            return result;

        }

        private int ClosePort(ref int lpdwSysError)
        {
            int result = -1;
            try
            {
                result = IntercomModule.CEFClose(ref lpdwSysError);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            return result;

        }


        private int SendCommand(string textcmd, ref int lpdwSysError)
        {
            int result = int.MinValue;
            try
            {
                result = IntercomModule.CEFWrite(textcmd, ref lpdwSysError);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            return result;
        }

        private int ReadPort(StringBuilder retData, ref int pdwByteRead, ref int lpdwSysError)
        {
            int result = -1;
            try
            {
                result = IntercomModule.CEFRead(retData, ref pdwByteRead, ref lpdwSysError);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            return result;
        }
        #endregion


        private void buttonPrintTicket_Click(object eventSender, System.EventArgs eventArgs)
		{
			int  i = 0;
			int  vRetA = 2;
			int  vRet = int.MinValue;
			int  vRetErr = int.MinValue;
			string s = null;

            //Get the number of ticket lines
            int.TryParse(this.Combo1.Text, out vRetA);

			// Open Communication on Com Port
			vRet = this.OpenPort(bPort, bRate, bParity, bData, bStop, bFlow, ref vRetErr);
			// Check Init
			if (vRet != 0)
			{
				MessageBox.Show("Error on Init Communication", "Communication Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
				return;
			}
            
			// Set to Buffer/NotBuffer Mode
            if (checkBuffer.Checked)		
			{
				s = "30161";
			}
			else
			{
				s = "30160";
			}
			vRet = this.SendCommand( s, ref vRetErr);

			i = 0;

			while (i < vRetA)
			{

				if (checkReadStatus.Checked)
				{
					CheckStatus();
				}
				// Write 1 Line on Printer
				if (i >= 9)
				{
					s = "3001111articolo " + System.Convert.ToString(i + 1) + "000000100";
				}
				else
				{
					s = "3001111articolo 0" + System.Convert.ToString(i + 1) + "000000100";
				}
				vRet = this.SendCommand(s, ref vRetErr);
				i++;;
			}

			// Set the payment of 90.00 Euro
			s = "300408CONTANTE000009000";
            vRet = this.SendCommand(s, ref vRetErr);
			// Close Document
			s = "3011";
            vRet = this.SendCommand(s, ref vRetErr);
			// Print and Cut
			s = "3013";
            vRet = this.SendCommand(s, ref vRetErr);
			// Close Communication on Com Port        
			vRet = this.ClosePort(ref vRetErr);
       	}
        private void buttonReadDate_Click(object eventSender, System.EventArgs eventArgs)
        {
            int vRet = int.MinValue;
            int vRetErr = int.MinValue;
            int vRetA = 0;
            string s = null;
            StringBuilder pBytBuffOut = new StringBuilder(null);

            // Open Communication on Com Port
            vRet = this.OpenPort(bPort, bRate, bParity, bData, bStop, bFlow, ref vRetErr);

            // Check Init
            if (vRet != 0)
            {
                MessageBox.Show("Error on Init Communication", "Communication Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Get DATE
            s = "1001";
            vRet = this.SendCommand(s, ref vRetErr);
            vRet = this.ReadPort(pBytBuffOut, ref vRetA, ref vRetErr);
            if (vRet != 0)
            {
                MessageBox.Show("Error on Read Port", "Communication Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            // Close Communication on Com Port
            vRet = this.ClosePort(ref vRetErr);

            Text1.Text = string.Format("Data: {0}/{1}/{2}  Ore:{3}.{4}",
                                        pBytBuffOut.ToString(0, 2),
                                        pBytBuffOut.ToString(2, 2),
                                        pBytBuffOut.ToString(4, 2),
                                        pBytBuffOut.ToString(6, 2),
                                        pBytBuffOut.ToString(8, 2));

        }

        private void buttonReadLine_Click(object eventSender, System.EventArgs eventArgs)
        {
            int vRet = int.MinValue;
            int vRetErr = int.MinValue;
            int vRetA = int.MinValue;
            string s = string.Empty;
            StringBuilder pBytBuffOut = new StringBuilder(1024);
            int i = 1;

            // Open Communication on Com Port
            vRet = this.OpenPort(bPort, bRate, bParity, bData, bStop, bFlow, ref vRetErr);

            // Check Init
            if (vRet != 0)
            {
                MessageBox.Show("Error on Init Communication", "Communication Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Read the HEAD line
            //Protoocol command 1002
            s = "10021";

            vRet = this.SendCommand(s, ref vRetErr);
            vRet = this.ReadPort( pBytBuffOut, ref vRetA, ref vRetErr);
            // Close Communication on Com Port
            vRet = this.ClosePort(ref vRetErr);

         
            Text2.Text = pBytBuffOut.ToString();
        }

        private void buttonReadStatus_Click(object eventSender, System.EventArgs eventArgs)
		{
			int vRet = 0;
            int vRetErr = 0;
			byte[] pBytBuffOut = new byte[1001];


			// Open Communication on Com Port
			vRet = this.OpenPort(bPort, bRate, bParity, bData, bStop, bFlow, ref vRetErr);
			// Check Init
			if (vRet != 0)
			{
				MessageBox.Show("Error on Init Communication", "Communication Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
				return;
			}

			CheckStatus();
			// Close Communication on Com Port
			vRet = this.ClosePort(ref vRetErr);
		}

		public void CheckStatus()
		{
            int vRet = int.MinValue;
			int vRetErr = int.MinValue;
			int vRetA = int.MinValue;
			string s = null;
			StringBuilder pBytBuffOut = new StringBuilder(null);
			int err_Renamed = 0;

			// Protocol command Get printer Status
			s = "1109";
			vRet = this.SendCommand(s, ref vRetErr);
			vRet = this.ReadPort(pBytBuffOut, ref vRetA, ref vRetErr);

			err_Renamed = 0;
			if (vRet != 0)
			{
				err_Renamed = err_Renamed + 1;
			}


			//Cover Open
			if (pBytBuffOut[0] == 48 /* '0' */)
			{
				checkCoverOpen.CheckState = System.Windows.Forms.CheckState.Unchecked;
			}
			else
			{
				checkCoverOpen.CheckState = System.Windows.Forms.CheckState.Checked;
			}

			//End Paper
            if (pBytBuffOut[1] == 48 /* '0' */)
            {
                checkPaperEnd.CheckState = System.Windows.Forms.CheckState.Unchecked;
            }
            else
            {
                checkPaperEnd.CheckState = System.Windows.Forms.CheckState.Checked;
            }

			//Near Paper End
            if (pBytBuffOut[2] == 48 /* '0' */)
            {
                checkNearPaperEnd.CheckState = System.Windows.Forms.CheckState.Unchecked;
            }
            else
            {
                checkNearPaperEnd.CheckState = System.Windows.Forms.CheckState.Checked;
            }

			//DGFE full
            if (pBytBuffOut[3] == 48 /* '0' */)
            {
                checkDGFEFull.CheckState = System.Windows.Forms.CheckState.Unchecked;
            }
            else
            {
                checkDGFEFull.CheckState = System.Windows.Forms.CheckState.Checked;
            }

			//DGFE Almost full
            if (pBytBuffOut[4] == 48 /* '0' */)
            {
                checkDGFEAlmostFull.CheckState = System.Windows.Forms.CheckState.Unchecked;
            }
            else
            {
                checkDGFEAlmostFull.CheckState = System.Windows.Forms.CheckState.Checked;
            }

		}

        private void buttonReadVersion_Click(object eventSender, System.EventArgs eventArgs)
		{
			int vRet = int.MinValue;
			int vRetErr = int.MinValue;
			int bPort = 0;
            StringBuilder strOut = new StringBuilder(null);
			int i = 1;

			// Get DLL Version
            try
            {
                vRet = IntercomModule.CEFGetVersion(strOut, ref vRetErr);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }
           

			Text3.Text = strOut.ToString();
		}

        private void MainForm_Load(object eventSender, System.EventArgs eventArgs)
		{
            int i = 0;
			string s = null;

			i = 0;
			Combo1.Items.Clear();
			while (i < 50)
			{
				Combo1.Items.Add(System.Convert.ToString(i + 1));
				i = i + 1;
			}
			Combo1.Text = "5";

			i = 0;
			ComboPort.Items.Clear();
			while (i < 5)
			{
				s = "COM " + System.Convert.ToString(i + 1);
				ComboPort.Items.Add((s));
				i = i + 1;
			}
			ComboPort.SelectedIndex = 0;
       	}

        private void ComboPort_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.bPort = (ComboPort.SelectedIndex) + 1; //Com Port
        }

	}
} //end of root namespace