using Microsoft.AspNetCore.Http;
using Rest.net5.Data.VO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Rest.net5.Business
{
    public interface IFileBusiness
    {
        public byte[] GetFile(string filename);
        public Task<FileDetailVO> SaveFileToDisk(IFormFile file);
        public Task<List<FileDetailVO>> SaveFilesToDisk(IList<IFormFile> file);

    }
}
