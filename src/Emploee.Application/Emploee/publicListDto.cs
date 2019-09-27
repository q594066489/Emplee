using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Emploee
{
    public class publicListDto
    {
        //public List<string> lists = new List<string>();
        public publicListDto()
        {

        }
        public List<string> GetEducation()
        {
            List<string> Educationslist = new List<string>
             {
                  "不限",
                  "初中及以下",
                  "中专/中技",
                  "高中",
                  "大专",
                  "本科",
                  "硕士",
                  "博士",
                  "其他"
             };
            return Educationslist;
        }
        public List<string> GetEducationForperson()
        {
            List<string> Educationslist = new List<string>
             {
                   
                  "初中及以下",
                  "中专/中技",
                  "高中",
                  "大专",
                  "本科",
                  "硕士",
                  "博士",
                  "其他"
             };
            return Educationslist;
        }
        public List<string> GetExperiences()
        {
            List<string> Experienceslist = new List<string>
             {
                  "不限",
                  "1年以内",
                  "1-3年",
                  "3-5年",
                  "5-10年",
                  "10年以上"
             };
            return Experienceslist;
        }
        public List<string> GetExperiencesforperson()
        {
            List<string> Experienceslist = new List<string>
             {
                   
                  "1年以内",
                  "1-3年",
                  "3-5年",
                  "5-10年",
                  "10年以上"
             };
            return Experienceslist;
        }
        public List<string> GetFinanicings()
        {
            List<string> Finanicinglist = new List<string>
             {
                  "不限",
                  "未融资",
                  "天使轮",
                  "A轮",
                  "B轮",
                  "C轮",
                  "D轮及以上",
                  "已上市",
                  "不需要融资"
             };
            return Finanicinglist;
        }
        public List<string> GetCompanyScales()
        {
            List<string> CompanyScaleslist = new List<string>
             {
                  "不限",
                  "0-20人",
                  "20-99人",
                  "100-499人",
                  "500-999人",
                  "1000-9999人",
                  "10000人以上"
             };
            return CompanyScaleslist;
        }
        /// <summary>
        /// 期望行业(在职、离职、考虑中……)
        /// </summary>
        /// <returns></returns>
        public List<string> GetState()
        {
            List<string> CompanyScaleslist = new List<string>
             {
                  "在职",
                  "离职",
                  "考虑中"
             };
            return CompanyScaleslist;
        }
        /// <summary>
        /// 行业
        /// </summary>
        /// <returns></returns>
        public List<string> GetClassigys()
        {
            List<string> ClassigysList = new List<string>
             {
                "不限",
                "电子商务",
                "游戏",
                "媒体",
                "餐饮",
                "广告营销",
                "数据服务",
                "医疗健康",
                "生活服务",
                "O2O",
                "旅游",
                "分类信息",
                "音乐/视频/阅读",
                "在线教育",
                "社交网络",
                "人力资源服务",
                "企业服务",
                "信息安全",
                "智能硬件",
                "移动互联网",
                "互联网",
                "计算机软件",
                "通信/网络设备",
                "广告/公关/会展",
                "互联网金融",
                "物流/仓储",
                "贸易",
                "咨询",
                "工程",
                "制造业",
                "其他"
             };
            return ClassigysList;
        }
         
    }
}
