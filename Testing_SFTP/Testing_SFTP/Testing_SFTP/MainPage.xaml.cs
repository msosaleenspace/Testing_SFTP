using System;
using System.Collections.Generic;
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

            this.TestSFTP();
        }

        private async Task TestSFTP()
        {
            try
            {
                //pi@raspberrypi.local
                /*var client = new SftpClient("192.168.200.98", "pi", "1234");
                client.Connect();

                var listing = await client.ListDirectoryAsync("./");

                List<Renci.SshNet.Sftp.SftpFile> asList = listing.ToList();

                this.MessageLbl.Text = asList.Count + "";

                for (int index = 0; index < asList.Count; index++)
                {
                    this.MessageLbl.Text = this.MessageLbl.Text + "\n" + asList[index].FullName;
                }

                var aFile =  client.DownloadAsync("test.db", new AA(), null, null);

                // directorio cache

                ///Users/martinsosa/Library/Developer/CoreSimulator/Devices/E3D559ED-53B3-444A-BB59-B52792F68510/data/Containers/Bundle/Application/CA85D7B6-57CD-4515-931C-445B9E1A242E/Testing_SFTP.iOS.app/test.db"
                
                using (var localStream = File.OpenRead(""))
                {
                    //await client.UploadAsync(localStream, "upload_path");
                }

                client.Disconnect();*/

                //-----------------------

                String Host = "192.168.200.98";
                int Port = 22;

                String RemoteFileName = "test.db";
                String LocalDestinationFilename = "./test.db";//"test.db"

                String Username = "pi";
                String Password = "1234";

                using (var sftp = new SftpClient(Host, Port, Username, Password))
                {
                    sftp.Connect();

                    using (var file = File.OpenWrite(LocalDestinationFilename))
                    {
                        sftp.DownloadFile(RemoteFileName, file);
                    }



                    string fileName = "./test.db";

                    IEnumerable<string> lines = File.ReadLines(fileName);
                    Console.WriteLine(String.Join(Environment.NewLine, lines));

                    this.MessageLbl.Text = "" + String.Join(Environment.NewLine, lines);

                    sftp.Disconnect();
                }

               // this.MessageLbl.Text = "No hubo problema!";

            }
            catch (Exception ex)
            {
                this.MessageLbl.Text = ex.Message;
            }
            

        }

    }

    public class AA : Stream
    {
        public override bool CanRead => throw new NotImplementedException();

        public override bool CanSeek => throw new NotImplementedException();

        public override bool CanWrite => throw new NotImplementedException();

        public override long Length => throw new NotImplementedException();

        public override long Position { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public override void Flush()
        {
            throw new NotImplementedException();
        }

        public override int Read(byte[] buffer, int offset, int count)
        {
            throw new NotImplementedException();
        }

        public override long Seek(long offset, SeekOrigin origin)
        {
            throw new NotImplementedException();
        }

        public override void SetLength(long value)
        {
            throw new NotImplementedException();
        }

        public override void Write(byte[] buffer, int offset, int count)
        {
            throw new NotImplementedException();
        }
    }

}