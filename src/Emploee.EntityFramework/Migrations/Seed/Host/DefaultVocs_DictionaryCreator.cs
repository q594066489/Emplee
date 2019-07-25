using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vocs.EntityFramework;
using Vocs.Vocs.Vocs_Classifications;
using Vocs.Vocs.Vocs_Dictionaries;
using Vocs.Vocs.Vocs_FSourceClasss;

namespace Vocs.Migrations.Seed.Host
{
    public class DefaultVocs_DictionaryCreator
    {
        private readonly VocsDbContext _context;
        public DefaultVocs_DictionaryCreator(VocsDbContext context)
        {
            _context = context;
        }
        public void Create()
        {
            AddVocs_DictionaryIfNotExists("", "001", "行业类别", 1);
            AddVocs_DictionaryIfNotExists("", "002", "数据类型", 1);
            AddVocs_DictionaryIfNotExists("001", "00101", "玻璃行业", 1);
            AddVocs_DictionaryIfNotExists("", "002", "数据类型", 0);
            AddVocs_DictionaryIfNotExists("002", "00201", "点源表模板", 1);
            AddVocs_DictionaryIfNotExists("002", "00202", "面源表模板", 2);
            AddVocs_DictionaryIfNotExists("001", "00102", "电力行业", 2);
            AddVocs_DictionaryIfNotExists("001", "00103", "工业锅炉", 3);
            AddVocs_DictionaryIfNotExists("001", "00104", "钢铁行业", 4);
            AddVocs_DictionaryIfNotExists("001", "00105", "水泥行业", 5);
            AddVocs_DictionaryIfNotExists("001", "00106", "焦化行业", 6);
            AddVocs_DictionaryIfNotExists("001", "00107", "化工化纤行业", 7);
            AddVocs_DictionaryIfNotExists("001", "00108", "印刷印染行业", 8);
            AddVocs_DictionaryIfNotExists("001", "00109", "工业喷涂行业", 9);
            AddVocs_DictionaryIfNotExists("001", "00110", "其它溶剂使用行业", 10);
            AddVocs_DictionaryIfNotExists("001", "00111", "畜禽养殖行业", 11);
            AddVocs_DictionaryIfNotExists("001", "00112", "废水处理行业", 12);
            AddVocs_DictionaryIfNotExists("001", "00113", "固废处理行业", 13);
            AddVocs_DictionaryIfNotExists("001", "00114", "烟气脱硝行业", 14);
            AddVocs_DictionaryIfNotExists("001", "00115", "餐饮业", 15);
            AddVocs_DictionaryIfNotExists("001", "00116", "生物质燃料", 16);
            AddVocs_DictionaryIfNotExists("001", "00117", "堆场扬尘", 17);
            AddVocs_DictionaryIfNotExists("001", "00118", "其它工业", 18);
            AddVocs_DictionaryIfNotExists("001", "00119", "加油站", 19);
            AddVocs_DictionaryIfNotExists("001", "00120", "机场", 20);
            AddVocs_DictionaryIfNotExists("001", "00121", "道路机动车", 21);
            AddVocs_DictionaryIfNotExists("001", "00122", "非道路移动源", 22);
            AddVocs_DictionaryIfNotExists("001", "00123", "农药使用", 23);
            AddVocs_DictionaryIfNotExists("001", "00124", "建筑涂料", 24);
            AddVocs_DictionaryIfNotExists("001", "00125", "氮肥施用", 25);
            AddVocs_DictionaryIfNotExists("001", "00126", "土壤本底", 26);
            AddVocs_DictionaryIfNotExists("001", "00127", "固氮植物", 27);
            AddVocs_DictionaryIfNotExists("001", "00128", "秸秆堆肥", 28);
            AddVocs_DictionaryIfNotExists("001", "00129", "人体粪便", 29);
            AddVocs_DictionaryIfNotExists("001", "00130", "油气储存", 30);
            AddVocs_DictionaryIfNotExists("001", "00131", "油气运输", 31);
            AddVocs_DictionaryIfNotExists("001", "00132", "生物质露天焚烧", 32);
            AddVocs_DictionaryIfNotExists("", "201", "回收方式", 0);
            AddVocs_DictionaryIfNotExists("201", "20101", "一次油气回收", 0);
            AddVocs_DictionaryIfNotExists("", "003", "浓度单位", 3);
            AddVocs_DictionaryIfNotExists("003", "00301", "ug/m3", 1);
            AddVocs_DictionaryIfNotExists("", "004", "排放标准", 1);
            AddVocs_DictionaryIfNotExists("004", "00401", "国V", 1);
            AddVocs_DictionaryIfNotExists("004", "00402", "国VI", 2);
            AddVocs_DictionaryIfNotExists("004", "00403", "国III", 3);
            AddVocs_DictionaryIfNotExists("", "005", "采集点分类", 0);






            //Add_Vocs_ClassificationIfNotExists(1, "烷烃", "01", 0, "");
            //Add_Vocs_ClassificationIfNotExists(2, "烯烃", "02", 0, "");
            //Add_Vocs_ClassificationIfNotExists(3, "卤代烃", "03", 0, "");
            //Add_Vocs_ClassificationIfNotExists(4, "芳香烃", "04", 0, "");
            //Add_Vocs_ClassificationIfNotExists(5, "含氧有机物", "05", 0, "");
            //Add_Vocs_ClassificationIfNotExists(6, "--", "---", 0, "");
            //Add_Vocs_ClassificationIfNotExists(7, "醛类", "0501", 0, "5");
            //Add_Vocs_ClassificationIfNotExists(8, "醇类", "0502", 0, "5");
            //Add_Vocs_ClassificationIfNotExists(9, "酮类", "0503", 0, "5");
            //Add_Vocs_ClassificationIfNotExists(10, "酯类", "0504", 0, "5");
            //Add_Vocs_ClassificationIfNotExists(11, "醚类", "0505", 0, "5");
            //Add_Vocs_ClassificationIfNotExists(12, "氯甲烷", "0301", 0, "3");
            //Add_Vocs_ClassificationIfNotExists(13, "乙烷", "0101", 0, "1");
            //Add_Vocs_ClassificationIfNotExists(14, "丙烷", "0102", 0, "1");
            //Add_Vocs_ClassificationIfNotExists(15, "丁烷", "0103", 0, "1");
            //Add_Vocs_ClassificationIfNotExists(16, "异丁烷", "0104", 0, "1");
            //Add_Vocs_ClassificationIfNotExists(17, "2,2二甲基丁烷", "0105", 0, "1");
            //Add_Vocs_ClassificationIfNotExists(18, "乙烯", "0201", 0, "2");
            //Add_Vocs_ClassificationIfNotExists(19, "丙烯", "0202", 0, "2");
            //Add_Vocs_ClassificationIfNotExists(20, "1-丁烯", "0203", 0, "2");
            //Add_Vocs_ClassificationIfNotExists(21, "二氯甲烷", "0302", 0, "3");
            //Add_Vocs_ClassificationIfNotExists(22, "苯", "0401", 0, "4");
            //Add_Vocs_ClassificationIfNotExists(23, "甲苯", "0402", 0, "4");
            //Add_Vocs_ClassificationIfNotExists(24, "邻二甲苯", "0403", 0, "4");
            //Add_Vocs_ClassificationIfNotExists(25, "间二甲苯", "0404", 0, "4");
            //Add_Vocs_ClassificationIfNotExists(26, "对二甲苯", "0405", 0, "4");
            //Add_Vocs_ClassificationIfNotExists(27, "乙苯", "0406", 0, "4");
            //Add_Vocs_ClassificationIfNotExists(28, "甲醛", "050101", 0, "7");
            //Add_Vocs_ClassificationIfNotExists(29, "乙醛", "050102", 0, "7");
            //Add_Vocs_ClassificationIfNotExists(30, "乙醇", "050201", 0, "8");
            //Add_Vocs_ClassificationIfNotExists(31, "2-丙醇", "050202", 0, "8");
            //Add_Vocs_ClassificationIfNotExists(32, "丙酮", "050301", 0, "9");
            //Add_Vocs_ClassificationIfNotExists(33, "2-丁酮", "050302", 0, "9");
            //Add_Vocs_ClassificationIfNotExists(34, "乙酸乙酯", "050401", 0, "10");
            //Add_Vocs_ClassificationIfNotExists(35, "乙酸丁酯", "050402", 0, "10");
            //Add_Vocs_ClassificationIfNotExists(36, "甲基叔丁基醚", "050501", 0, "11");
            //Add_Vocs_ClassificationIfNotExists(37, "甲硫醚", "050502", 0, "11");


            //table();











        }

        private void table()
        {
            Add_Vocs_FSourceClassIfNotExists(1, "生物质燃烧源", "", "001", 0, "", "", "", 1);

            Add_Vocs_FSourceClassIfNotExists(2, "生物质燃烧源", "", "002", 0, "", "", "", 1);
            Add_Vocs_FSourceClassIfNotExists(3, "生物质燃烧源", "", "003", 0, "", "", "", 1);

            Add_Vocs_FSourceClassIfNotExists(4, "生物质燃烧源", "", "1", 0, "", "", "", 1);
            Add_Vocs_FSourceClassIfNotExists(5, "化石燃料燃烧源", "", "2", 0, "", "", "", 1);
            Add_Vocs_FSourceClassIfNotExists(6, "工艺过程排放源", "", "3", 0, "", "", "", 1);
            Add_Vocs_FSourceClassIfNotExists(7, "溶剂使用源", "", "4", 0, "", "", "", 1);
            Add_Vocs_FSourceClassIfNotExists(8, "移动源", "", "5", 0, "", "", "", 1);
            Add_Vocs_FSourceClassIfNotExists(9, "生物质燃料", "4", "101", 0, "", "", "", 2);
            Add_Vocs_FSourceClassIfNotExists(10, "生物质露天焚烧", "4", "102", 0,"", "", "", 2);
            Add_Vocs_FSourceClassIfNotExists(11, "秸秆", "9", "10101", 0, "", "", "", 3);
            Add_Vocs_FSourceClassIfNotExists(12, "薪柴", "9", "10102", 0, "", "5.3", "g /kg", 5);
            Add_Vocs_FSourceClassIfNotExists(13, "玉米", "11", "1010101", 0, "秸秆", "5.3", "g /kg", 5);
            Add_Vocs_FSourceClassIfNotExists(14, "小麦", "11", "1010102", 0, "秸秆", "5.3", "g /kg", 5);
            Add_Vocs_FSourceClassIfNotExists(15, "水稻", "11", "1010103", 0, "秸秆", "5.3", "g /kg", 5);
            Add_Vocs_FSourceClassIfNotExists(16, "油料作物秸秆", "11", "1010104", 0, "", "5.3", "g /kg", 5);
            Add_Vocs_FSourceClassIfNotExists(17, "水稻", "12", "1010201", 0, "", "", "", 4);
            Add_Vocs_FSourceClassIfNotExists(18, "小麦", "12", "1010202", 0, "", "", "", 4);
            Add_Vocs_FSourceClassIfNotExists(19, "玉米", "12", "1010203", 0, "", "", "", 4);
            Add_Vocs_FSourceClassIfNotExists(20, "油料作物", "12", "1010204", 0, "", "", "", 4);
            Add_Vocs_FSourceClassIfNotExists(21, "薯类", "12", "1010205", 0, "", "", "", 4);
            Add_Vocs_FSourceClassIfNotExists(22, "秸秆", "10", "10201", 0, "", "", "", 3);
            Add_Vocs_FSourceClassIfNotExists(23, "水稻", "22", "1020101", 0, "", "", "", 3);
            Add_Vocs_FSourceClassIfNotExists(24, "小麦", "22", "1020102", 0, "", "", "", 3);
            Add_Vocs_FSourceClassIfNotExists(25, "玉米", "22", "1020103", 0, "", "", "", 3);
            Add_Vocs_FSourceClassIfNotExists(26, "油料作物", "22", "1020104", 0, "", "", "", 4);
            Add_Vocs_FSourceClassIfNotExists(27, "薯类", "22", "1020105", 0, "", "", "", 4);
            Add_Vocs_FSourceClassIfNotExists(28, "发电", "5", "201", 0, "", "", "", 2);
            Add_Vocs_FSourceClassIfNotExists(29, "供热", "5", "202", 0, "", "", "", 2);
            Add_Vocs_FSourceClassIfNotExists(30, "工商业消费", "5", "203", 0, "", "", "", 2);
            Add_Vocs_FSourceClassIfNotExists(31, "居民生活消费", "5", "204", 0, "", "", "", 2);
            Add_Vocs_FSourceClassIfNotExists(32, "煤", "28", "20101", 0, "", "", "", 3);
            Add_Vocs_FSourceClassIfNotExists(33, "燃料油", "28", "20102", 0, "", "", "", 3);
            Add_Vocs_FSourceClassIfNotExists(34, "液化石油气", "28", "20103", 0, "", "", "", 3);
            Add_Vocs_FSourceClassIfNotExists(35, "天然气", "28", "20104", 0, "", "", "", 3);
            Add_Vocs_FSourceClassIfNotExists(36, "石油化工业", "6", "301", 0, "", "", "", 2);
            Add_Vocs_FSourceClassIfNotExists(37, "其他工艺过程", "6", "302", 0, "", "", "", 2);
            Add_Vocs_FSourceClassIfNotExists(38, "天然原油和天然气开采", "36", "30101", 0,"", "", "", 3);
            Add_Vocs_FSourceClassIfNotExists(39, "基础化学原料制造", "36", "30102", 0, "", "", "", 3);
            Add_Vocs_FSourceClassIfNotExists(40, "肥料制造", "36", "30103", 0, "", "", "", 3);
            Add_Vocs_FSourceClassIfNotExists(41, "农药制造", "36", "30104", 0, "", "", "", 3);
            Add_Vocs_FSourceClassIfNotExists(42, "水泥、石灰、和石膏的制造", "37", "30201", 0, "", "", "", 3);
            Add_Vocs_FSourceClassIfNotExists(43, "染色过程", "7", "401", 0, "", "", "", 2);
            Add_Vocs_FSourceClassIfNotExists(44, "沥青铺路", "7", "402", 0, "", "", "", 2);
            Add_Vocs_FSourceClassIfNotExists(45, "表面涂层", "7", "403", 0, "", "", "", 2);
            Add_Vocs_FSourceClassIfNotExists(46, "农药使用", "7", "404", 0, "", "", "", 2);
            Add_Vocs_FSourceClassIfNotExists(47, "其他", "7", "405", 0, "", "", "", 2);
            Add_Vocs_FSourceClassIfNotExists(48, "印刷", "43", "40101", 0, "", "", "", 3);
            Add_Vocs_FSourceClassIfNotExists(49, "印染布", "43", "40102", 0, "", "", "", 3);
            Add_Vocs_FSourceClassIfNotExists(50, "传统油墨印刷", "48", "4010101", 0, "", "", "", 4);
            Add_Vocs_FSourceClassIfNotExists(51, "水性油墨印刷", "48", "4010102", 0, "", "", "", 4);
            Add_Vocs_FSourceClassIfNotExists(52, "沥青", "44", "40201", 0, "", "", "", 3);
            Add_Vocs_FSourceClassIfNotExists(53, "建筑涂料", "45", "40301", 0, "", "", "", 3);
            Add_Vocs_FSourceClassIfNotExists(54, "家具制造", "45", "40302", 0, "", "", "", 3);
            Add_Vocs_FSourceClassIfNotExists(55, "汽车制造", "45", "40303", 0, "", "", "", 3);
            Add_Vocs_FSourceClassIfNotExists(56, "摩托车制造", "45", "40304", 0, "", "", "", 3);
            Add_Vocs_FSourceClassIfNotExists(57, "自行车制造", "45", "40305", 0, "", "", "", 3);
            Add_Vocs_FSourceClassIfNotExists(58, "机械涂层", "45", "40306", 0, "", "", "", 3);
            Add_Vocs_FSourceClassIfNotExists(59, "易拉罐生产/漆包线生产/汽车维修/工 艺品表面涂层", "45", "40307", 0, "", "", "", 3);
            Add_Vocs_FSourceClassIfNotExists(60, "杀虫剂/除草剂/除菌剂", "46", "40401", 0, "", "", "", 3);
            Add_Vocs_FSourceClassIfNotExists(61, "干洗剂", "47", "40501", 0, "", "", "", 3);
            Add_Vocs_FSourceClassIfNotExists(62, "日用化妆品", "47", "40502", 0, "", "", "", 3);
            Add_Vocs_FSourceClassIfNotExists(63, "去污脱脂", "47", "40503", 0, "", "", "", 3);
            Add_Vocs_FSourceClassIfNotExists(64, "道路机动车", "8", "501", 0, "", "", "", 2);
            Add_Vocs_FSourceClassIfNotExists(65, "非道路移动源", "8", "502", 0, "", "", "", 2);
            Add_Vocs_FSourceClassIfNotExists(66, "轻型客车", "64", "50101", 0, "", "", "", 3);
            Add_Vocs_FSourceClassIfNotExists(67, "飞机", "65", "50201", 0, "", "", "", 3);
            Add_Vocs_FSourceClassIfNotExists(68, "沼气", "9", "10104", 0, "沼气", "0.18", "g /m3", 3);
            Add_Vocs_FSourceClassIfNotExists(69, "沼气", "9", "10103", 0, "沼气", "0.18", "g /m3", 3);
            Add_Vocs_FSourceClassIfNotExists(70, "工业", "30", "20301", 0, "",  "", "", 3);
            Add_Vocs_FSourceClassIfNotExists(71, "煤", "70", "2030101", 0, "", " 0.39", "g /kg", 4);
            Add_Vocs_FSourceClassIfNotExists(72, "燃料油", "70", "2030102", 0, "", "0.35", "g /kg", 4);
            Add_Vocs_FSourceClassIfNotExists(73, "城市/农村", "31", "20401", 0, "", "", "", 3);
            Add_Vocs_FSourceClassIfNotExists(74, "住宿和餐饮业", "30", "20302", 0, "", "",  "", 3);
        }


        private void AddVocs_DictionaryIfNotExists(string ParentCode, string code, string Name, int orderindex)
        {
            if (_context.Vocs_Dictionarys.Any(l => l.Code == code))
            {
                return;
            }
            Vocs_Dictionary vocs_Dictionary = new Vocs_Dictionary();
            vocs_Dictionary.ParentCode = ParentCode;
            vocs_Dictionary.Code = code;
            vocs_Dictionary.Name = Name;
            vocs_Dictionary.OrderIndex = orderindex;
            _context.Vocs_Dictionarys.Add(vocs_Dictionary);

            _context.SaveChanges();
        }

        private void Add_Vocs_ClassificationIfNotExists(int id, string ClasssName, string ClasssId, int OrderNum, string ParentId)
        {
            if (_context.Vocs_Classifications.Any(l => l.ClasssId == ClasssId))
            {
                return;
            }
            Vocs_Classification vocs_Classification = new Vocs_Classification();
            vocs_Classification.ClasssId = ClasssId;
            vocs_Classification.ClasssName = ClasssName;
            vocs_Classification.ParentId = ParentId;
            vocs_Classification.OrderNum = OrderNum;
            _context.Vocs_Classifications.Add(vocs_Classification);

            _context.SaveChanges();
        }

        public void Add_Vocs_FSourceClassIfNotExists(int id, string ClasssName, string ParentId, string ClasssId,  int OrderNum, string Remarks,
            string DischargeEF, string DischargeEFUnit, int Level

            )
        {
            if (_context.Vocs_FSourceClasss.Any(l => l.ClasssId == ClasssId))
            {
                return;
            }
            Vocs_FSourceClass vocs_FSourceClass = new Vocs_FSourceClass();
            vocs_FSourceClass.ClasssId = ClasssId;
            vocs_FSourceClass.ClasssName = ClasssName;
            vocs_FSourceClass.ParentId = ParentId;
            vocs_FSourceClass.OrderNum = OrderNum;
            if (!string.IsNullOrEmpty(DischargeEF))
            vocs_FSourceClass.DischargeEF = float.Parse(DischargeEF.ToString());
            vocs_FSourceClass.DischargeEFUnit = DischargeEFUnit;
            vocs_FSourceClass.Level = Level;
            _context.Vocs_FSourceClasss.Add(vocs_FSourceClass);


            _context.SaveChanges();
        }


    }
}
