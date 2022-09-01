using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Threading.Tasks;
using Renci.SshNet;
using Xamarin.Forms;
using File = System.IO.File;

namespace Testing_SFTP
{

    public partial class MainPage : ContentPage
    {

        public MainPage()
        {
            InitializeComponent();

            //this.TestSFTPAndroid();
            this.TestSFTPiOS();

        }

        private async Task TestSFTPiOS()
        {
            try
            {
         
                String Host = "192.168.200.98";
                int Port = 22;

                String RemoteFileName = "test.db";
                String LocalDestinationFilename = "./testDos.db";//"./testDos.db"

                String Username = "pi";
                String Password = "1234";

                using (var sftp = new SftpClient(Host, Port, Username, Password))
                {
                    sftp.Connect();

                    using (var file = File.OpenWrite(LocalDestinationFilename))
                    {
                        sftp.DownloadFile(RemoteFileName, file);
                    }

                    string fileName = "./testDos.db";

                    IEnumerable<string> lines = File.ReadLines(fileName);
                    Console.WriteLine(String.Join(Environment.NewLine, lines));

                    this.MessageLbl.Text = "" + String.Join(Environment.NewLine, lines);

                    sftp.Disconnect();
                }

            }
            catch (Exception ex)
            {
                this.MessageLbl.Text = ex.Message;
            }

        }

        private async Task TestSFTPAndroid()
        {
            try
            {


                String Host = "192.168.200.98";
                int Port = 22;

                String RemoteFileName = "test.db";

                String LocalDestinationFilename = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal), "/data/user/0/com.companyname.testing_sftp/files/testDos.db");

                String Username = "pi";
                String Password = "1234";

                using (var sftp = new SftpClient(Host, Port, Username, Password))
                {
                    sftp.Connect();

                    using (var file = File.OpenWrite(LocalDestinationFilename))
                    {
                        sftp.DownloadFile(RemoteFileName, file);
                    }

                     string fileName = "/data/user/0/com.companyname.testing_sftp/files/testDos.db";

                     IEnumerable<string> lines = File.ReadLines(fileName);
                     Console.WriteLine(String.Join(Environment.NewLine, lines));

                     this.MessageLbl.Text = "" + String.Join(Environment.NewLine, lines);

                     sftp.Disconnect();
                }

                //this.MessageLbl.Text = "No hubo problema!";

            }
            catch (Exception ex)
            {
                this.MessageLbl.Text = ex.Message;
            }

        }

    }

}