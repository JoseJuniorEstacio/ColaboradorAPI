using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CoreFtp;
using System.IO;

namespace ColaboradorAPI.Controllers
{
    [Route("api/colaborador/ftp")]
    public class FtpController : Controller
    {

        [HttpGet]
        public async Task GetFileAsync()
        {
            await FtpControllerAsAsync();
        }

        async Task FtpControllerAsAsync()
        {

            using (var ftpClient = new FtpClient(new FtpClientConfiguration
            {
                Host = "192.168.10.246:21",
                Username = "adp",
                Password = "int3gr@c@o"
            }))
            {
                var tempFile = new FileInfo("C:\\temp\\Dados_Cadastrais_TI.txt");
                await ftpClient.LoginAsync();
                using (var ftpReadStream = await ftpClient.OpenFileReadStreamAsync("Dados_Cadastrais_TI.txt"))
                {
                    using (var fileWriteStream = tempFile.OpenWrite())
                    {
                        await ftpReadStream.CopyToAsync(fileWriteStream);
                    }
                }
            }
        }
    }
}
