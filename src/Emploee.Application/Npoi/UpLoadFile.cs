using Abp.UI;
using Emploee.Npoi;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Vocs.Npoi
{
    public class UpLoadFile
    {
        public List<CommonResult> UpLoadList(HttpFileCollectionBase files)
        {
            var list = new List<CommonResult>();
            if (files != null)
            {
                foreach (string key in files.Keys)
                {
                    CommonResult result = new CommonResult();
                    try
                    {
                        #region  
                        HttpPostedFileBase fileData = files[key];
                        if (fileData != null)
                        {
                            string filePathName = string.Empty;
                            string ex = Path.GetExtension(fileData.FileName);
                            filePathName = Guid.NewGuid().ToString("N") + ex;
                            // 文件上传后的保存路径

                            string VirtualPath = ConfigurationManager.AppSettings["Emploee_TemplatePath"].ToString();
                            //物理路径

                            string filePath = HttpContext.Current.Server.MapPath(VirtualPath);

                            if (!Directory.Exists(filePath))
                            {
                                Directory.CreateDirectory(filePath);
                            }

                            fileData.SaveAs(Path.Combine(filePath, filePathName));
                            string newname = filePath + "/" + filePathName;
                            //  result.AttmentPath = newname; 物理路径
                            result.AttmentPath = VirtualPath + filePathName;
                            //result.Status = true;
                            result.FileName = fileData.FileName;
                            result.TotalSize = fileData.ContentLength / 1024;
                        }
                        #endregion
                    }
                    catch (Exception ex)
                    {
                        throw new UserFriendlyException( ex.Message);

                    }
                    list.Add(result);
                }
            }
         
            return list;
        }

        public CommonResult UpLoad(HttpFileCollectionBase files)
        {
            CommonResult result = new CommonResult();
            if (files != null)
            {
                foreach (string key in files.Keys)
                {
                    try
                    {
                        #region  
                        HttpPostedFileBase fileData = files[key];
                        if (fileData != null)
                        {
                            string filePathName = string.Empty;
                            string ex = Path.GetExtension(fileData.FileName);
                            filePathName = Guid.NewGuid().ToString("N") + ex;
                            // 文件上传后的保存路径

                            string VirtualPath = ConfigurationManager.AppSettings["Emploee_TemplatePath"].ToString();
                            //物理路径
                            string filePath = HttpContext.Current.Server.MapPath(VirtualPath);

                            if (!Directory.Exists(filePath))
                            {
                                Directory.CreateDirectory(filePath);
                            }

                            fileData.SaveAs(Path.Combine(filePath, filePathName));
                            string newname = filePath + "/" + filePathName;
                            //  result.AttmentPath = newname;

                            result.AttmentPath = VirtualPath + filePathName;
                            result.FileName = fileData.FileName;
                            result.TotalSize = fileData.ContentLength / 1024;
                        }
                        #endregion
                    }
                    catch (Exception ex)
                    {

                        throw new UserFriendlyException(ex.ToString());

 
                    }
                }
            }
            return result;
        }

    }
}
