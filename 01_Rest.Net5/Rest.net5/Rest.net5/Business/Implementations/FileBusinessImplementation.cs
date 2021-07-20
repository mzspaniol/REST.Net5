using Microsoft.AspNetCore.Http;
using Rest.net5.Data.VO;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Rest.net5.Business.Implementations
{
    public class FileBusinessImplementation : IFileBusiness
    {
        private readonly string _basePath;
        private readonly IHttpContextAccessor _context;

        public FileBusinessImplementation(IHttpContextAccessor context)
        {
            _context = context;
            _basePath = Directory.GetCurrentDirectory() + "\\UploadDir\\";
        }

        public byte[] GetFile(string filename)
        {
            throw new NotImplementedException();
        }

        public async Task<List<FileDetailVO>> SaveFilesToDisk(IList<IFormFile> files)
        {
            List<FileDetailVO> list = new List<FileDetailVO>();
            foreach (var file in files)
            {
                list.Add(await SaveFileToDisk(file));
            }
            return list;
        }

        public async Task<FileDetailVO> SaveFileToDisk(IFormFile file)
        {
            FileDetailVO FileDetail = new FileDetailVO();

            var fileType = Path.GetExtension(file.FileName);
            var baseUrl = _context.HttpContext.Request.Host;

            if(fileType.ToLower() == ".pdf" || fileType.ToLower() == ".jpg"  || fileType.ToLower() == ".png" || fileType.ToLower() == ".jpeg"){
                var docName = Path.GetFileName(file.FileName);
                if (file != null && file.Length > 0)
                {
                    var destination = Path.Combine(_basePath, "", docName);
                    FileDetail.DocumentName = docName;
                    FileDetail.DocumentType = fileType;
                    FileDetail.DocumentUrl = Path.Combine(baseUrl + "/api/file/v1/" + FileDetail.DocumentName);

                    using var stream = new FileStream(destination, FileMode.Create);
                    await file.CopyToAsync(stream);
                }
            }
            return FileDetail;
        }
    }
}
