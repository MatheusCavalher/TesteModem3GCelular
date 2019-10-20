using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.IO.Ports;
using System.Threading;
using System.Text.RegularExpressions;

namespace smsTeste
{
    class FunSMS
    {
        #region Variavel Global
        public AutoResetEvent receiveNow;
        #endregion

        #region Read SMS
        public ShortMessageCollection ReadSMS(SerialPort port, string p_strCommand)
        {
            ShortMessageCollection messages = null;
            try
            {
                // Check connection
                ExecCommand(port, "AT", 300, "No phone connected");
                // Use message format "Text mode"
                ExecCommand(port, "AT+CMGF=1", 300, "Failed to set message format.");
                // Use character set "PCCP437"
                //ExecCommand(port, "AT+CSCS=\"PCCP437\"", 300, "Failed to set character set.");
                // Select SIM storage
                ExecCommand(port, "AT+CPMS=\"SM\"", 300, "Failed to select message storage.");
                // Read the messages
                String input = ExecCommand(port, p_strCommand, 5000, "Failed to read the messages.");

                messages = ParseMessages(input);

            }
            catch (Exception ex)
            {
                throw ex;
            }

            if (messages != null)
                return messages;
            else
                return null;
        }
        #endregion

        #region Parse Message
        public ShortMessageCollection ParseMessages(String input)
        {
            ShortMessageCollection messages = new ShortMessageCollection();
            try
            {     
                Regex r = new Regex(@"\+CMGL: (\d+),""(.+)"",""(.+)"",(.*),""(.+)""\r\n(.+)\r\n");
                Match m = r.Match(input);
                while (m.Success)
                {
                    ShortMessage msg = new ShortMessage();
                    //msg.Index = int.Parse(m.Groups[1].Value);
                    msg.Index = m.Groups[1].Value;
                    msg.Status = m.Groups[2].Value;
                    msg.Sender = m.Groups[3].Value;
                    msg.Alphabet = m.Groups[4].Value;
                    msg.Sent = m.Groups[5].Value;
                    msg.Message = m.Groups[6].Value;
                    messages.Add(msg);

                    m = m.NextMatch();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return messages;
        }
        #endregion

        #region Count SMS
        public int CountSMSmessages(SerialPort port)
        {
            int CountTotalMessages = 0;
            try
            {
                String recievedData = ExecCommand(port, "AT", 300, "No phone connected at ");
                recievedData = ExecCommand(port, "AT+CMGF=1", 300, "Failed to set message format.");
                String command = "AT+CPMS?";
                recievedData = ExecCommand(port, command, 1000, "Failed to count SMS message");
                int uReceivedDataLength = recievedData.Length;

                if ((recievedData.Length >= 45) && (recievedData.StartsWith("AT+CPMS?")))
                {
                    String[] strSplit = recievedData.Split(',');
                    String strMessageStorageArea1 = strSplit[0];     //SM
                    String strMessageExist1 = strSplit[1];           //Msgs exist in SM
                    CountTotalMessages = Convert.ToInt32(strMessageExist1);
                }
                else if (recievedData.Contains("ERROR"))
                {
                    String recievedError = recievedData;
                    recievedError = recievedError.Trim();
                    recievedData = "Following error occured while counting the message" + recievedError;
                }
                return CountTotalMessages;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #region Delete SMS
        public bool DeleteMsg(SerialPort port, String p_strCommand)
        {
            bool isDeleted = false;
            try
            {
                String recievedData = ExecCommand(port, "AT", 300, "No phone connected");
                recievedData = ExecCommand(port, "AT+CMGF=1", 300, "Failed to set message format.");
                String command = p_strCommand;
                recievedData = ExecCommand(port, command, 300, "Failed to delete message");

                if (recievedData.EndsWith("\r\nOK\r\n"))
                {
                    isDeleted = true;
                }
                if (recievedData.Contains("ERROR"))
                {
                    isDeleted = false;
                }
                return isDeleted;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #region Abre Porta Serial
        public SerialPort OpenPort(String p_strPortName, int p_uBaudRate, int p_uDataBits, int p_uReadTimeout, int p_uWriteTimeout)
        {
            receiveNow = new AutoResetEvent(false);
            SerialPort port = new SerialPort();
            try
            {
                port.PortName = p_strPortName;                 //COM5
                port.BaudRate = p_uBaudRate;                   //9600
                port.DataBits = p_uDataBits;                   //8
                port.StopBits = StopBits.One;                  //1
                port.Parity = Parity.None;                     //None
                port.ReadTimeout = p_uReadTimeout;             //300
                port.WriteTimeout = p_uWriteTimeout;           //300
                port.Encoding = Encoding.GetEncoding("iso-8859-1");
                port.DataReceived += new SerialDataReceivedEventHandler(port_DataReceived);
                port.Open();
                port.DtrEnable = true;
                port.RtsEnable = true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return port;
        }
        #endregion

        #region Fecha a Porta Serial
        public void ClosePort(SerialPort port)
        {
            try
            {
                port.Close();
                port.Dispose();
                port.DataReceived -= new SerialDataReceivedEventHandler(port_DataReceived);
                port = null;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #region Recebe dados da porta
        public void port_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            try
            {
                if (e.EventType == SerialData.Chars)
                {
                    receiveNow.Set();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #region Enviar SMS
        public bool sendMsg(SerialPort port, String PhoneNo, String Message)
        {
            bool isSend = false;
            try
            {
                String recievedData = ExecCommand(port, "AT", 300, "Nenhum Dispositivo Conectado");
                recievedData = ExecCommand(port, "AT+CMGF=1", 300, "Erro ao setar formato da mensagem.");
                String command = "AT+CMGS=\"" + PhoneNo + "\"";
                recievedData = ExecCommand(port, command, 300, "Erro no numero de telefone");
                command = Message + char.ConvertFromUtf32(26) + "\r";
                recievedData = ExecCommand(port, command, 3000, "Erro ao mandar a mensagem"); //3 seconds
                if (recievedData.EndsWith("\r\nOK\r\n"))
                {
                    isSend = true;
                }
                else if (recievedData.Contains("ERROR"))
                {
                    isSend = false;
                }
                return isSend;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #region Comandos AT
        public String ExecCommand(SerialPort port, String command, int responseTimeout, String errorMessage)
        {
            try
            {
                port.DiscardOutBuffer();
                port.DiscardInBuffer();
                receiveNow.Reset();
                port.Write(command + "\r");

                String input = ReadResponse(port, responseTimeout);
                if ((input.Length == 0) || ((!input.EndsWith("\r\n> ")) && (!input.EndsWith("\r\nOK\r\n"))))
                    throw new ApplicationException("Sem sucesso ao receber a mensagem.");
                return input;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #region Leitura de Dados
        public String ReadResponse(SerialPort port, int timeout)
        {
            String buffer = String.Empty;
            try
            {
                do
                {
                    if (receiveNow.WaitOne(timeout, false))
                    {
                        String t = port.ReadExisting();
                        buffer += t;
                    }
                    else
                    {
                        if (buffer.Length > 0)
                            throw new ApplicationException("Response received is incomplete.");
                        else
                            throw new ApplicationException("Nenhum dado recebido do telefone.");
                    }
                }
                while (!buffer.EndsWith("\r\nOK\r\n") && !buffer.EndsWith("\r\n> ") && !buffer.EndsWith("\r\nERROR\r\n"));
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return buffer;
        }
        #endregion
    }
}